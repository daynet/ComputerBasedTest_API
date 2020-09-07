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
    [RoutePrefix("api/v1/result")]
    public class TestResultController : ApiController
    {
        private ITestResultRepository _repo;
        public TestResultController(ITestResultRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("{psid}/psid")]
        public HttpResponseMessage GetQuestion(int psid)
        {
            try
            {
                var result = _repo.GetTestResults(psid);

                if (!result.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = result });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        [Route("{testResultId}/testResultId")]
        public HttpResponseMessage GetTestResults(int testResultId)
        {
            try
            {
                var result = _repo.GetTestResult(testResultId);

                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = result });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }



        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage>  AddTestResult(IEnumerable<TestResultVM> model)
        {
            try
            {
                var response =  await _repo.AddTestResult(model);

                if (response == 0)
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
        [Route("{testResultId}/testResultId")]
        public HttpResponseMessage UpdateTestResult(TestResultVM model)
        {
            try
            {
                var response = _repo.UpdateTestResult(model);

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
        [Route("{testResultId}/testResultId")]
        public HttpResponseMessage ResultExist(int testResultId)
        {
            try
            {
                var response = _repo.ResultExist(testResultId);

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
