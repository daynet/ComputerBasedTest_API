using cbt.Report.IReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace cbt.api.Controllers
{
    [RoutePrefix("api/v1/Report")]
    public class ReportController : ApiController
    {

        IReporting _repo;

        public ReportController(IReporting repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("{psid}")]
      
        [AllowAnonymous]
        public HttpResponseMessage getScoresheetById(int psid)
        {
            try
            {
                var data = _repo.getScoresheet(psid);
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


        //[HttpGet]
        //[Route("{psid}")]

        //[AllowAnonymous]
        //public HttpResponseMessage getScoresheetById(int psid)
        //{
        //    try
        //    {
        //        var data = _repo.getScoresheet(psid);
        //        if (data != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Courses Loaded Sucessfully", result = data });
        //        }

        //        return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Courses failed Loading!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Error has occured creating this user!" });
        //    }


        //}




    }
}
