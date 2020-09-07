using cbt.dbEntity.Model;
using cbt.viewModel.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
    public interface ISignupRepository
    {
        Signup AddProspectiveStudentEntry(SignupVM signupvm);

        int ValidateOTP(string otp, int psid);

        bool ResendOTP(string email, string phoneNumber);

        IEnumerable<ScoresheetVM> getProspectiveStudentDetails();

        bool isCounsel(SignupVM signup);

        School createSchool(SchoolVM school);

        IEnumerable<SchoolVM> getSchools();
    }
}
