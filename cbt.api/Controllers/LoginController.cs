using cbt.Interface.CBT;
using cbt.viewModel.User;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace cbt.api.Controllers
{
    [RoutePrefix("api/v1/login")]
    public class LoginController : ApiController
    {
        private JWTSettings _settings;
        private IAuthRepository auth;
        public LoginController(IAuthRepository _auth
            )
        {
            auth = _auth;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async Task<HttpResponseMessage> Login(UserLoginVM user)
        {
            try
            {
                var keyValue = ConfigurationManager.AppSettings["SecurityKey"];

                var result = await auth.Login(user);

                if (result == null)
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Invalid username or password" });

            //    var claims = new[]
            //    {
            //    new Claim(ClaimTypes.NameIdentifier, result.Email),
            //    new Claim(ClaimTypes.Name, result.UserName)
            //};

                //var key = new SymmetricSecurityKey(Encoding.UTF8
                //    .GetBytes(keyValue));

               // var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

               // var tokenDescriptor = new SecurityTokenDescriptor
               // {
               //     Subject = new ClaimsIdentity(claims),
               //     Expires = DateTime.Now.AddDays(1),
               //     SigningCredentials = creds
               // };

               // var tokenHandler = new JwtSecurityTokenHandler();

               //var token = tokenHandler.CreateToken(tokenDescriptor);

                  return Request.CreateResponse(HttpStatusCode.OK, new { success = true, token = result.BearerToken });
               // return Request.CreateResponse(HttpStatusCode.OK, new { success = true });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message});
            }
            
        }
    }
}
