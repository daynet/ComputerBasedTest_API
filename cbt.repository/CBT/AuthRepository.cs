using Authentication.Athen;
using cbt.dbEntity.Model;
using cbt.Interface.CBT;
using cbt.viewModel.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.repository.CBT
{
  public  class AuthRepository : IAuthRepository
    {
        private CBTcontext _context;

        private ISecurityManager securityMgr;
        public AuthRepository(CBTcontext context,
           ISecurityManager _securityMgr)
        {
            context = _context;
            securityMgr = _securityMgr;
        }
        public async Task<AppUserAuth> Login(UserLoginVM user)
        {
            AppUserAuth auth = new AppUserAuth();

            return securityMgr.ValidateUser(user);

        }


        public async Task<bool> UserRegistrationExist(string username)
        {
            if (await _context.LoginActivity.AnyAsync(o => o.UserName == username.ToLower()))
                return true;

            return false;
        }

        public async Task<bool> Logout(string userName)
        {
            var user = await _context.LoginActivity.Where(x => x.UserName == userName.ToLower()).FirstOrDefaultAsync();
            if (user != null)
            {
                user.IsLogout = true;
                user.LastLoginDate = DateTime.Now;

            }
            if (await _context.SaveChangesAsync() > 0)
                return true;

            return false;

        }
    }
}
