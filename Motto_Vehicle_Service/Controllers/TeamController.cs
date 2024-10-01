using Motto_Vehicle_DataFeed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Motto_Vehicle_Service.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            return View();
        }

        #region DevSprintDetail
        #region SaveDevSprintDetail
        [HttpPost]
        public ActionResult SaveDevSprintDetail()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Team_DATAFEED objDataFeed = new Team_DATAFEED();
            int id = objDataFeed.SaveDevSprintDetail(dt);
            if (id == 0)
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "Saving DevSprintDetail failed." });
            }
            else
            {
                return Json(new { success = true, message = "Saving DevSprintDetail completed successfully.", id = id });
            }
        }
        #endregion

        #region UpdateDevSprintDetail
        [HttpPost]
        public ActionResult UpdateDevSprintDetail()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Team_DATAFEED objDataFeed = new Team_DATAFEED();
            int isDuplicate = objDataFeed.UpdateDevSprintDetail(dt);
            if (isDuplicate == 0)
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "Updating DevSprintDetail failed." });
            }
            else
            {
                return Json(new { success = true, message = "Updating DevSprintDetail completed successfully." });
            }
        }
        #endregion

        #region DeleteDevSprintDetail
        [HttpPost]
        public ActionResult DeleteDevSprintDetail()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Team_DATAFEED objDataFeed = new Team_DATAFEED();
            objDataFeed.DeleteDevSprintDetail(dt);

            return Json(new { success = true, message = "Deleting DevSprintDetail completed successfully." });
        }
        #endregion

        #region GetDevSprintDetailById
        [HttpPost]
        public ActionResult GetDevSprintDetailById()
        {
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }
            DataTable dt = JsonToDt(formData);
            Team_DATAFEED objDataFeed = new Team_DATAFEED();
            DataTable dtresult = objDataFeed.GetDevSprintDetailById(dt);

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region DevSprintDetailList
        [HttpGet]
        public ActionResult DevSprintDetailList()
        {
            Team_DATAFEED objDataFeed = new Team_DATAFEED();
            DataTable dt = objDataFeed.GetDevSprintDetailList();

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #endregion

        #region JsonToDt
        public static DataTable JsonToDt(string strJSON)
        {
            System.Data.DataSet dataSet = (System.Data.DataSet)JsonConvert.DeserializeObject<System.Data.DataSet>(strJSON);
            DataTable dt = new DataTable();
            if (dataSet.Tables.Count > 0)
            {
                dt = dataSet.Tables[0];
            }
            return dt;
        }
        #endregion

        #region DtToJSon
        public static string DtToJSon(DataTable dt, string strHeader)
        {
            JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
            scriptSerializer.MaxJsonLength = Int32.MaxValue;
            List<Dictionary<string, object>> dictionaryList = new List<Dictionary<string, object>>();
            foreach (DataRow row in (InternalDataCollectionBase)dt.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                foreach (DataColumn column in (InternalDataCollectionBase)dt.Columns)
                    dictionary.Add(column.ColumnName, row[column]);
                dictionaryList.Add(dictionary);
            }
            return "{ \"" + strHeader + "\" : " + scriptSerializer.Serialize((object)dictionaryList) + "}";
        }
        #endregion
    }
}