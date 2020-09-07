using cbt.viewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
   public interface IRegisterUserRepository
    {
        bool RegisterUser(UserLoginDetailVM user);
        UserLoginDetailVM GetUserRegistration(string username);
        IEnumerable<UserLoginDetailVM> GetUserRegistrations();
        bool DeleteUserRegistration(string username, int userId);
    }
}
