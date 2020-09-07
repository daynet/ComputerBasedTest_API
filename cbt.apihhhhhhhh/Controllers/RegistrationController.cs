using cbt.Interface.CBT;
using cbt.viewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace cbt.api.Controllers
{
    [RoutePrefix("api/v1/register")]

    public class RegistrationController : ApiController
    {
        private IRegisterUserRepository repo;
        public RegistrationController(IRegisterUserRepository _repo)
        {
            repo = _repo;
        }


        [HttpPost]
        [Route("user")]
        [AllowAnonymous]
        public HttpResponseMessage RegisterUser(UserLoginDetailVM model)
        {
            try
            {
                var result = repo.RegisterUser(model);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Created Successfully!" });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "User Creation has failed!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Error has occured creating this user!" });
            }
        }
        [HttpGet]
        [Route("user/{userName}")]
        [AllowAnonymous]
        public HttpResponseMessage GetUserRegistration(string userName)
        {
            try
            {

                var result = repo.GetUserRegistration(userName);
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, result = result });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Failed!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Password reset has failed!" });

            }
            
        }

        

        [HttpPost]
        [AllowAnonymous]
        [Route("forgot-password")]
        public async Task<HttpResponseMessage> ForgotPassword(UserLoginDetailVM model)
        {
             return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("reset-password")]
        public async Task<HttpResponseMessage> ResetPassword(UserLoginDetailVM model)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Password reset has failed!" });

        }
    }
}
