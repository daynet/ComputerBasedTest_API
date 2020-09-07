using cbt.dbEntity.Model;
using cbt.Interface.CBT;
using cbt.viewModel.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace cbt.api.Controllers
{
    [RoutePrefix("api/v1/signup")]
    public class SignupController : ApiController
    {
        ISignupRepository _repo;
        ICourse _course;
        


        public SignupController(ISignupRepository repo, ICourse course)
        {
            _repo = repo;
            _course = course;

        }

        [HttpPost]
        [Route("student")]
        [AllowAnonymous]
        public HttpResponseMessage userRegister(SignupVM model)
        {
            try
            {
                var result = _repo.AddProspectiveStudentEntry(model);
                if (result!= null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = result, message = "Created Successfully!" });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "User Creation has failed!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message =ex.Message });
            }
        }


        //Internal Student
        [HttpPost]
        [Route("internalstudent")]
        [AllowAnonymous]
        public HttpResponseMessage internalUserRegister(SignupVM model)
        {
            try
            {
                var result = _repo.AddProspectiveStudentEntry(model);
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = result, message = "Created Successfully!" });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "User Creation has failed!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        [Route("otp")]
        [AllowAnonymous]
        public HttpResponseMessage ValidateOTP(SignupVM model)
        {
            try
            {
                var result = _repo.ValidateOTP( model.otp, model.Psid);

                if (result!=0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, message = "Created Successfully!" });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "User Creation has failed!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message =ex.Message });
            }
        }

        [HttpPost]
        [Route("resend/otp")]
        [AllowAnonymous]
        public HttpResponseMessage ResendOTP(SignupVM model)
        {
            try
            {
                var result = _repo.ResendOTP(model.MobileNo, model.Email);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, message = "Created Successfully!" });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "User Creation has failed!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        [Route("course")]
        [AllowAnonymous]
        public HttpResponseMessage getCourses()
        {
            try
            {
                var data = _course.getCourse();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Courses Loaded Sucessfully", result = data });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Courses failed Loading!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }


        [HttpGet]
        [Route("nationality")]
        [AllowAnonymous]
        public HttpResponseMessage getNationality()
        {
            try
            {
                var data = _course.getNationality();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Nationality Loaded Sucessfully", result = data });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Nationality failed Loading!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }


        [HttpGet]
        [Route("state")]
        [AllowAnonymous]
        public HttpResponseMessage getState()
        {
            try
            {
                var data = _course.getState();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Nationality Loaded Sucessfully", result = data });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Nationality failed Loading!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }


        [HttpGet]
        [Route("saturday")]
        [AllowAnonymous]
        public HttpResponseMessage getSaturday()
        {
            try
            {
                var data = _course.getSaturdays();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Saturdays Loaded Sucessfully", result = data });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Saturdays failed Loading!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message  = ex.Message });
            }
        }




        [HttpGet]
        [Route("userDetails")]
        [AllowAnonymous]
        public HttpResponseMessage getUserDetails()
        {
            try
            {
                var data = _repo.getProspectiveStudentDetails();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Student Details Loaded Sucessfully", result = data });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Student Details failed Loading!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        [Route("counsel")]
        [AllowAnonymous]
        public HttpResponseMessage updateCounsel(SignupVM signup)
        {
            try
            {
                var data = _repo.isCounsel(signup);
                if (data == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, message = "Updated successfully", result = data });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No update was effected!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        [Route("school")]
        public HttpResponseMessage addSchool(SchoolVM model)
        {
             try
             {
                var data = _repo.createSchool(model);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, message = "Created successfully", result = data });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Something went wrong!" });
             }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }

        }


        [HttpGet]
        [Route("schoolList")]
        public HttpResponseMessage getSchool()
        {
            try
            {
                var data = _repo.getSchools();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, message = "Created successfully", result = data });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Something went wrong!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }

        }



    }
}
