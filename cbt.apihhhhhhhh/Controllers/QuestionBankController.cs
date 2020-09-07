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
        public HttpResponseMessage GetQuestion()
        {
            try
            {
                var answer = _repo.GetQuestions();

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
        public HttpResponseMessage GetTestQuestion()
        {
            try
            {
                var answer = _repo.GetTestQuestion();

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
        public HttpResponseMessage GetQuestion(int questionBankId)
        {
            try
            {
                var answer = _repo.GetQuestionsById(questionBankId);

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
    }
}
