using cbt.Interface.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cbt.viewModel.User;
using cbt.dbEntity.Model;
using System.Data.Entity;

namespace cbt.repository.CBT
{
    public class RegisterUserRepository : IRegisterUserRepository
    {
        private CBTcontext _context;
        public RegisterUserRepository(CBTcontext context)
        {
            _context = context;
        }

        public bool RegisterUser(UserLoginDetailVM user)
        {

            if (UserRegistrationExist(user.userName.ToLower()) == true)
                throw new Exception("Username Exist! Please login.");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(user.password, out passwordHash, out passwordSalt);

            var userRegistration = new LoginActivity
            {
                FirstName = user.firstName,
                LastName = user.lastName,
                Email = user.email,
                UserName = user.userName,
                Gender = user.gender,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreationDate = DateTime.Now,
                IsActive = true,
                IsLocked = false,
                IsEmailConfirmed = true,
                IsLockoutEnabled = false,
                IsLogout = false,
                IsFirstLoginAttempt = false,

            };

            _context.LoginActivity.Add(userRegistration);
            if (_context.SaveChanges() > 0)
            { return true; }

            return false;

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool DeleteUserRegistration(string userName, int userId)
        {
            var selectedRecord = _context.LoginActivity.Where(o => o.UserName == userName.ToLower()).Select(o => o).FirstOrDefault();

            selectedRecord.IsActive = false;

            if (_context.SaveChanges() > 0) return true;

            return false;
        }

        public UserLoginDetailVM GetUserRegistration(string userName)
        {
            var userList = from x in _context.LoginActivity
                           where  x.UserName == userName.ToLower()
                           && x.IsActive == true
                           && x.IsLocked == false
                           select new UserLoginDetailVM
                           {
                               email = x.Email,
                               firstName = x.FirstName,
                               lastName = x.LastName,
                               userName = x.UserName,
                               gender = x.Gender
                           };

            return userList.FirstOrDefault();
        }

        public IEnumerable<UserLoginDetailVM> GetUserRegistrations()
        {
            var userList = from x in _context.LoginActivity
                           where  x.IsActive != false
                           && x.IsLocked != false
                           select new UserLoginDetailVM
                           {
                               email = x.Email,
                               firstName = x.FirstName,
                               userName = x.UserName
                           };

            return userList.ToList();
        }

        private bool UserRegistrationExist(string username)
        {
            if (_context.LoginActivity.Any(o => o.UserName == username.ToLower()))
                return true;

            return false;
        }
    }
}
