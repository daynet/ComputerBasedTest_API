using cbt.Interface.CBT;
using cbt.viewModel.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace cbt.api.Controllers
{
    [RoutePrefix("api/v1/question")]
    public class QuestionBankController : ApiController
    {
        private IQuestionBank _repo;
        public QuestionBankController(IQuestionBank repo)
        {
        _repo =repo;
        }

        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> GetQuestion()
        {
            try
            {
                var answer = await _repo.GetQuestions();

                if (!answer.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = answer });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        [Route("test")]
        public async Task<HttpResponseMessage> GetTestQuestion()
        {
            try
            {
                var answer = await _repo.GetTestQuestion();

                if (!answer.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = answer });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }


        [HttpGet]
        [Route("{questionBankId}/questionBankId")]
        public async Task<HttpResponseMessage> GetQuestion(int questionBankId)
        {
            try
            {
                var answer = await _repo.GetQuestionsById(questionBankId);

                if (answer == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = answer });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddQuestion(QuestionBankVM model)
        {
            try
            {
                var response = _repo.AddQuestion(model);

                if (response == false)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = response });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage UpdateQuestion(QuestionBankVM model)
        {
            try
            {
                var response = _repo.UpdateQuestion(model);

                if (response == false)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = response });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        [HttpPut]
        [Route("{CurrectAnswerId}/CurrectAnswerId")]
        public HttpResponseMessage DeleteQuestion(int questionBankId)
        {
            try
            {
                var response = _repo.DeleteQuestion(questionBankId);

                if (response == false)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = response });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [Route("mail")]
        [AllowAnonymous]
        public HttpResponseMessage sendMail(SignupVM signupvm)
        {
            try
            {
                var data = _repo.SendMail(signupvm);
                if (data != false)
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
    }
}
