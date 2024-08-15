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
    public class OperationController : Controller
    {
        // GET: Operation
        public ActionResult Index()
        {
            return View();
        }

        #region StatusType
        #region CreateStatusType
        [HttpPost]
        public ActionResult CreateStatusType()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            int id = objDataFeed.SaveStatusType(dt);
            if (id == 0)
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "StatusType Creation failed." });
            }
            else
            {
                return Json(new { success = true, message = "StatusType Creation completed successfully.", id = id });
            }
        }
        #endregion

        #region UpdateStatusType
        [HttpPost]
        public ActionResult UpdateStatusType()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            int isDuplicate = objDataFeed.UpdateStatusType(dt);
            if (isDuplicate == 0)
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "Updating StatusType failed." });
            }
            else
            {
                return Json(new { success = true, message = "Updating StatusType completed successfully." });
            }
        }
        #endregion

        #region DeleteStatusType
        [HttpPost]
        public ActionResult DeleteStatusType()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            objDataFeed.DeleteStatusType(dt);

            return Json(new { success = true, message = "Deleting StatusType completed successfully." });
        }
        #endregion

        #region StatusTypeList
        [HttpGet]
        public ActionResult StatusTypeList()
        {
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            DataTable dt = objDataFeed.GetStatusTypeList();

            dt.Columns["StatusTypeID"].ColumnName = "statusTypeID";
            dt.Columns["StatusName"].ColumnName = "statusName";
            dt.Columns["StatusName_TH"].ColumnName = "statusName_TH";
            dt.Columns["StatusType"].ColumnName = "statusType";

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion
        #endregion

        #region CreateTransportATSLog
        [HttpPost]
        public ActionResult CreateTransportATSLog()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            int id = objDataFeed.Create_Transport_ATS_Log(dt);
            if (id == 0)
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "ATS Log Creation failed." });
            }
            else
            {
                return Json(new { success = true, message = "ATS Log Creation completed successfully.", id = id });
            }
        }
        #endregion

        #region User
        #region RegisterUser
        [HttpPost]
        public ActionResult RegisterUser()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            int id = objDataFeed.SaveTransportUser(dt);
            if (id == 0)
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "User Registeration failed." });
            }
            else
            {
                return Json(new { success = true, message = "User Registeration completed successfully.", id = id });
            }
        }
        #endregion

        #region UpdateUser
        [HttpPost]
        public ActionResult UpdateUser()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            int isDuplicate = objDataFeed.UpdateTransportUser(dt);
            if (isDuplicate == 0)
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "Updating User failed." });
            }
            else
            {
                return Json(new { success = true, message = "Updating User completed successfully." });
            }
        }
        #endregion

        #region DeleteUser
        [HttpPost]
        public ActionResult DeleteUser()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            objDataFeed.DeleteTransportUser(dt);

            return Json(new { success = true, message = "Deleting User completed successfully." });
        }
        #endregion

        #region UserList
        [HttpGet]
        public ActionResult UserList()
        {
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            DataTable dt = objDataFeed.GetUserList();

            dt.Columns["UserID"].ColumnName = "userid";
            dt.Columns["UserName"].ColumnName = "userName";
            dt.Columns["UserEmail"].ColumnName = "userEmail";
            dt.Columns["LoginName"].ColumnName = "login";
            dt.Columns.Remove("Password");
            dt.Columns["DepartmentID"].ColumnName = "department";
            dt.Columns["UserType"].ColumnName = "userType";

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region LoginUser
        [HttpPost]
        public ActionResult LoginUser()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            DataTable dtinfo = objDataFeed.LoginTransportUser(dt);
            if (dtinfo.Rows.Count > 0)
            {
                dtinfo.Columns["UserID"].ColumnName = "userid";
                dtinfo.Columns["UserName"].ColumnName = "userName";
                dtinfo.Columns["UserEmail"].ColumnName = "userEmail";
                dtinfo.Columns["LoginName"].ColumnName = "login";
                dtinfo.Columns.Remove("Password");
                dtinfo.Columns["DepartmentID"].ColumnName = "department";
                dtinfo.Columns["UserType"].ColumnName = "userType";

                string jsString = DtToJSonForUserInfo(dtinfo);
                string successMessage = "Login successful.";
                return Content($"{{\"success\": true, \"message\": \"{successMessage}\", \"data\": {jsString}}}", "application/json");
            }
            else
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "Login failed." });
            }
        }
        #endregion

        #endregion

        #region GetLocations
        [HttpGet]
        public ActionResult GetLocations()
        {
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            DataTable dt = objDataFeed.GetLocations();

            dt.Columns["display_name"].ColumnName = "location";

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetLocationsByUser
        [HttpGet]
        public ActionResult GetLocationsByUser(string userid)
        {
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            DataTable dt = objDataFeed.GetLocationsByUser(userid);

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
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

        #region DtToJSonForUserInfo
        public static string DtToJSonForUserInfo(DataTable dt)
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
            return scriptSerializer.Serialize((object)dictionaryList);
        }
        #endregion

    }
}