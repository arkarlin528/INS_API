using MOTTO_DATAFEED.DAO;
using Motto_Vehicle_DataFeed;
using Motto_Vehicle_DataFeed.DAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> CreateTransportATSLog()
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
            int id = await objDataFeed.Create_Transport_ATS_Log(dt);
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
            LoginIMAPDto dtinfo = objDataFeed.LoginTransportUser(dt);
            if (dtinfo.guid != null)
            {
                string successMessage = "Login successful.";
                string jsonData = JsonConvert.SerializeObject(dtinfo);
                return Content(jsonData, "application/json");
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

        #region SearchOperationDashboard
        [HttpPost]
        public ActionResult SearchOperationDashboard()
        {
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            List<BindOprDashboardData> dashboardData = objDataFeed.SearchOprDashboard(dt);
            string jsonResult = JsonConvert.SerializeObject(dashboardData);

            return Content(jsonResult, "application/json");
        }
        #endregion

        #region OverallLocationDashboard
        [HttpPost]
        public ActionResult OverallLocationDashboard()
        {
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            List<OverallLocationPerformance> dashboardData = objDataFeed.OverallLocationDashboard(dt);
            string jsonResult = JsonConvert.SerializeObject(dashboardData);

            return Content(jsonResult, "application/json");
        }
        #endregion

        #region InspectorPerformanceDashboard
        [HttpPost]
        public ActionResult InspectorPerformanceDashboard()
        {
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            List<InspectorPerformance> dashboardData = objDataFeed.InspectorPerformanceDashboard(dt);
            string jsonResult = JsonConvert.SerializeObject(dashboardData);

            return Content(jsonResult, "application/json");
        }
        #endregion

        #region LocationPerformanceDashboard
        [HttpPost]
        public ActionResult LocationPerformanceDashboard()
        {
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            List<InspectorPerformance> dashboardData = objDataFeed.LocationDashboard(dt);
            string jsonResult = JsonConvert.SerializeObject(dashboardData);

            return Content(jsonResult, "application/json");
        }
        #endregion

        #region GetFilterStorageLocation
        [HttpGet]
        public ActionResult GetFilterStorageLocation()
        {
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            List<Inspection_StorageLocation> dt = objDataFeed.Inspection_Filter_StorageLocation();

            string jsString = JsonConvert.SerializeObject(dt);
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetFilterInspector
        [HttpGet]
        public ActionResult GetFilterInspector()
        {
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            List<Inspector> dt = objDataFeed.Inspection_Filter_Inspector();

            string jsString = JsonConvert.SerializeObject(dt);
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetFilterMonthData
        [HttpGet]
        public ActionResult GetFilterMonthData()
        {
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            List<Inspection_Month> dt = objDataFeed.Inspection_Filter_MonthData();

            string jsString = JsonConvert.SerializeObject(dt);
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetOPdbFilterSellingCategory
        [HttpGet]
        public ActionResult GetOPdbFilterSellingCategory()
        {
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            List<FilterSellingCategory> dt = objDataFeed.GetFilterSellingCategory();

            string jsString = JsonConvert.SerializeObject(dt);
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetOPdbFilterUpcomingAuction
        [HttpGet]
        public ActionResult GetOPdbFilterUpcomingAuction()
        {
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            List<AuctionDate_Combo> dt = objDataFeed.GetFilterUpcomingAuction();

            string jsString = JsonConvert.SerializeObject(dt);
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetOPdbFilterSeller
        [HttpGet]
        public ActionResult GetOPdbFilterSeller()
        {
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            List<FilterSeller> dt = objDataFeed.GetFilterSeller();

            string jsString = JsonConvert.SerializeObject(dt);
            return Content(jsString, "application/json");
        }
        #endregion

        #region QuickCheckInVehicles
        [HttpPost]
        public ActionResult QuickCheckInVehicles()
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
            int isFound = objDataFeed.QuickCheckInVehicles(dt);
            if(isFound == 1)
            {
                return Json(new { success = true, message = "Vehicle Check in successfully." });
            }
            else
            {
                return Json(new { success = false, message = "Vehicle not found for check-in to the Location!" });
            }
        }
        #endregion

        #region QuickCheckOutVehicles
        [HttpPost]
        public ActionResult QuickCheckOutVehicles()
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
            int isFound = objDataFeed.QuickCheckOutVehicles(dt);
            if (isFound == 1)
            {
                return Json(new { success = true, message = "Vehicle Check out successfully." });
            }
            else
            {
                return Json(new { success = false, message = "Previous Quick CheckOut process is not CheckIn yet!" });
            }
        }
        #endregion

        #region CheckStock
        [HttpPost]
        public ActionResult CheckStock()
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
            objDataFeed.CheckStock(dt);
            return Json(new { success = true, message = $"Checked Stock of Vehicle Successfully." });
        }
        #endregion

        #region QuickCheckOutList
        [HttpGet]
        public ActionResult QuickCheckOutList()
        {
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            DataTable dt = objDataFeed.GetQuickCheckOutList();

            dt.Columns["IMAPNumber"].ColumnName = "imapNumber";
            dt.Columns["CheckOutLocation"].ColumnName = "fromLocationId";
            dt.Columns["CheckInLocation"].ColumnName = "toLocationId";
            dt.Columns["CheckOutTime"].ColumnName = "checkOutTime";

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetLastQuickTransport
        [HttpPost]
        public ActionResult GetLastQuickTransport()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }
            DataTable dt = JsonToDt(formData);
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            int isFound = objDataFeed.GetLastQuickTransport(dt);
            if (isFound == 1)
            {
                return Json(new { success = true, message = "CheckIn" });
            }
            else
            {
                return Json(new { success = true, message = "CheckOut" });
            }
        }
        #endregion

        #region GetKanbanAllStatus
        [HttpPost]
        public ActionResult GetKanbanAllStatus()
        {
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            DataTable Data = objDataFeed.GetKanbanAllStatus(dt);

            string jsString = DtToJSon(Data, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetStockAging
        [HttpPost]
        public ActionResult GetStockAging()
        {
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            DataTable Data = objDataFeed.GetStockAging(dt);

            string jsString = DtToJSon(Data, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetSellers
        [HttpGet]
        public ActionResult GetSellers()
        {
            Operation_DATAFEED objDataFeed = new Operation_DATAFEED();
            DataTable dt = objDataFeed.GetSellers();

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