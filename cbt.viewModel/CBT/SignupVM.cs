using cbt.viewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.viewModel.CBT
{
    public class SignupVM : CommonVM
    {
        public int Psid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string MobileNo { get; set; }

        public string Email { get; set; }

        public DateTime DOB { get; set; }

        public int Program { get; set; }

        public string Address { get; set; }

        public string COR { get; set; }

        public string City { get; set; }

        public string Designation { get; set; }

        public string NOI { get; set; }
        public DateTime tokenExpirationDate { get; set; }
        public string otp { get; set; }
        public string ExamDate { get; set; }

        public string UserName { get; set; }
        public bool isCounsel { get; set; }
        public string State { get; set; }
        public int? SchoolID { get; set; }
        public bool isContact  { get; set; }
        public string Levels { get; set; }





    }
}
