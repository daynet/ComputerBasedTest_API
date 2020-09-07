using cbt.viewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
    public interface IAuthRepository
    {
        Task<AppUserAuth> Login(UserLoginVM user);

        Task<bool> UserRegistrationExist(string username);

        Task<bool> Logout(string userName);
    }
}
