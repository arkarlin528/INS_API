using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INS_API.Controllers
{
    public class DataPortController : Controller
    {
        [HttpPost]
        public ActionResult BookIn()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            //DataTable dt = JsonToDt(formData);
            //Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            //int id = objDataFeed.SaveStatusType(dt);
            //if (id == 0)
            //{
            //    Response.StatusCode = 409;
            //    return Json(new { success = false, message = "StatusType Creation failed." });
            //}
            //else
            //{
            //    return Json(new { success = true, message = "StatusType Creation completed successfully.", id = id });
            //}

            return Json(new { success = true, message = "Sync Book In Data completed successfully.", id = 0 });
        }

        [HttpPost]
        public ActionResult Inspection()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            //DataTable dt = JsonToDt(formData);
            //Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            //int id = objDataFeed.SaveStatusType(dt);
            //if (id == 0)
            //{
            //    Response.StatusCode = 409;
            //    return Json(new { success = false, message = "StatusType Creation failed." });
            //}
            //else
            //{
            //    return Json(new { success = true, message = "StatusType Creation completed successfully.", id = id });
            //}

            return Json(new { success = true, message = "Sync Inspection Data completed successfully.", id = 0 });
        }
    }
}