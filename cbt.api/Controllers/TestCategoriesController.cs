
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
    [RoutePrefix("api/v1/category")]
   // [Authorize]
    public class TestCategoriesController : ApiController
    {
        private ITestCategoryRepository _category;
        public TestCategoriesController(ITestCategoryRepository category)
        {
            _category = category;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetTestCategories()
        {
            try
            {
                var category = _category.GetTestCategories();

                if (!category.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = category });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        [Route("{TestCategoryId}/TestCategoryId")]
        public HttpResponseMessage GetTestCategory(int TestCategoryId)
        {
            try
            {
                var category = _category.GetTestCategory(TestCategoryId);

                if (category == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = category });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddTestCategory(TestCategoryVM model)
        {
            try
            {
                var response = _category.AddTestCategory(model);

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
        public HttpResponseMessage UpdateTestCategory(TestCategoryVM model)
        {
            try
            {
                var response = _category.UpdateTestCategory(model);

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
        [Route("{TestCategoryId}/TestCategoryId")]
        public HttpResponseMessage DeleteTestCategory(int TestCategoryId)
        {
            try
            {
                var response = _category.DeleteTestCategory(TestCategoryId);

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
