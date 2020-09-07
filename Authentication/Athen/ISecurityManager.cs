using cbt.viewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Athen
{
  public  interface ISecurityManager
    {
        AppUserAuth ValidateUser(UserLoginVM user);
    }
}
