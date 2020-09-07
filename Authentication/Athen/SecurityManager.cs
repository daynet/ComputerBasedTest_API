using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cbt.viewModel.User;
using cbt.dbEntity.Model;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;

namespace Authentication.Athen
{
    public class SecurityManager : ISecurityManager
    {
        private CBTcontext context;
        // private IConfiguration configuration;
        public SecurityManager(CBTcontext _context
            // IConfiguration _configuration
            )
        {
            context = _context;
            //   configuration = _configuration;
        }

        public AppUserAuth ValidateUser(UserLoginVM user)
        {
            AppUserAuth ret = new AppUserAuth();
            LoginActivity authUser = null;
            var result = false;

            // Attempt to validate user
            authUser = (from u in context.LoginActivity
                        where u.UserName.ToLower() == user.userName.ToLower()
                        select (u)).FirstOrDefault();

            if (authUser == null) throw new Exception("User not registered!");

            result = VerifyPasswordHash(user.password, authUser.PasswordHash, authUser.PasswordSalt);

            if (result == false) throw new Exception("Username or password incorrect not registered!");

            ret.BearerToken = CreateToken(authUser.UserName);

            return ret;
        }

        protected List<UserClaim> GetUserClaims(int UserId)
        {
            List<UserClaim> list = new List<UserClaim>();

            try
            {

                list = context.UserClaim.Where(
                         u => u.UserId == UserId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Exception trying to retrieve user claims.", ex);
            }

            return list;
        }

        protected AppUserAuth BuildUserAuthObject(LoginActivity authUser)
        {
            AppUserAuth ret = new AppUserAuth();
            List<UserClaim> claims = new List<UserClaim>();

            // Set User Properties
            ret.UserName = authUser.FirstName + " " + authUser.LastName;
            ret.IsAuthenticated = true;
            ret.Email = authUser.Email;
            ret.UserName = authUser.UserName;


            // Get all claims for this user
            int? userId = authUser.LoginActivityId;
            claims = GetUserClaims((int)userId);

            // Loop through all claims and 
            // set properties of user object
            foreach (UserClaim claim in claims)
            {
                try
                {
                    // TODO: Check data type of ClaimValue
                    typeof(AppUserAuth).GetProperty(claim.ClaimType)
                      .SetValue(ret, Convert.ToBoolean(claim.ClaimValue), null);
                }
                catch
                {
                }
            }

            // Set JWT bearer token
            ret.BearerToken = BuildJwtToken(ret);

            return ret;
        }


        private string CreateToken(string email)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddDays(7);

            //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, email)
            });

            const string secrectKey = "your secret key goes here";
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secrectKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


            //Create the jwt (JSON Web Token)
            //Replace the issuer and audience with your URL (ex. http:localhost:12345)
            var token =
                (JwtSecurityToken)
                tokenHandler.CreateJwtSecurityToken(
                    issuer: "http://localhost:12345/",
                    audience: "http://localhost:12345/",
                    subject: claimsIdentity,
                    notBefore: issuedAt,
                    expires: expires,
                    signingCredentials: signingCredentials);

            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }


        }
        protected string BuildJwtToken(AppUserAuth authUser)
        {
            JWTSettings settings = new JWTSettings();

            //settings.Key = configuration["JWTSettings:key"];
            //settings.MinutesToExpiration = Convert.ToInt32(configuration["JWTSettings:minutesToExpiration"]);


            SymmetricSecurityKey key = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes("1233skyline"));

            // Create standard JWT claims
            List<Claim> jwtClaims = new List<Claim>();
            jwtClaims.Add(new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, authUser.UserName));
            jwtClaims.Add(new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            jwtClaims.Add(new Claim("isAuthenticated", authUser.IsAuthenticated.ToString().ToLower()));
            jwtClaims.Add(new Claim("Email", authUser.Email.ToString().ToLower()));
            jwtClaims.Add(new Claim("UserName", authUser.UserName.ToString()));


            // Create the JwtSecurityToken object
            var token = new JwtSecurityToken(issuer: settings.Issuer, audience: settings.Audience, claims: jwtClaims,
              notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddMinutes(settings.MinutesToExpiration),
              signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            // Create a string representation of the Jwt token
            return new JwtSecurityTokenHandler().WriteToken(token); ;
        }
    }
}
