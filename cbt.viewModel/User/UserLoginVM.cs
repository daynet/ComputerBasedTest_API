using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.viewModel.User
{
   public class UserLoginVM
    {
        public string userName { get; set; }

        public string password { get; set; }

        public string Email { get; set; }

        public bool RememberMe { get; set; }
    }
}
