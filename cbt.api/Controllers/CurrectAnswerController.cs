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
    [RoutePrefix("api/v1/currectAnswer")]
   // [Authorize]
    public class CurrectAnswerController : ApiController
    {
        private ICorrectAnswerRepository _currentAnswer;
        public CurrectAnswerController(ICorrectAnswerRepository currentAnswer)
        {
            _currentAnswer = currentAnswer;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetCurrentAnswers()
        {
            try
            {
                var answer = _currentAnswer.GetTestCorrectAnswers();

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
        [Route("{CurrectAnswerId}/CurrectAnswerId")]
        public HttpResponseMessage GetTestanswer(int CurrectAnswerId)
        {
            try
            {
                var answer = _currentAnswer.GetCorrectAnswer(CurrectAnswerId);

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
        public HttpResponseMessage AddCurrectAnswer(CorrectAnswerVM model)
        {
            try
            {
                var response = _currentAnswer.AddCorrectAnswer(model);

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
        public HttpResponseMessage UpdateCurrectAnswer(CorrectAnswerVM model)
        {
            try
            {
                var response = _currentAnswer.UpdateCorrectAnswer(model);

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
        public HttpResponseMessage DeleteCurrectAnswer(int CurrectAnswerId)
        {
            try
            {
                var response = _currentAnswer.DeleteCorrectAnswer(CurrectAnswerId);

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
