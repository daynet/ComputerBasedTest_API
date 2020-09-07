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
                if (result!=0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = result, message = "Created Successfully!" });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "User Creation has failed!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Error has occured creating this user!" });
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
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Error has occured creating this user!" });
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
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Error has occured creating this user!" });
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
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Error has occured creating this user!" });
            }
        }




    }
}
