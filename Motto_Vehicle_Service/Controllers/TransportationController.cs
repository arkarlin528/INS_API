using MOTTO_DATAFEED.DAO;
using Motto_Vehicle_DataFeed;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using ZeroBug.Service;

namespace Motto_Vehicle_Service.Controllers
{
    public class TransportationController : Controller
    {

        private string smtpAddress = System.Configuration.ConfigurationManager.AppSettings["Smtp.Address"];
        private int smtpPort = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Smtp.Port"]);
        private bool smtpEnablbeSSL = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["Smtp.EnableSSL"]);
        private string smtpUser = System.Configuration.ConfigurationManager.AppSettings["Smtp.User"];
        private string smtpSenderEmail = System.Configuration.ConfigurationManager.AppSettings["Smtp.SenderEmail"];
        private string smtpSenderName = System.Configuration.ConfigurationManager.AppSettings["Smtp.SenderName"];
        private string smtpPassword = System.Configuration.ConfigurationManager.AppSettings["Smtp.Password"];

        string strResultTemplate = @"<table width='100%' border='2' cellpadding='2' cellspacing='0' style='padding: 1rem;'>
            <tr style='background-color: #002d5d;color:#ffa200;'>
                <th>DepartureDate (dd-MM-yyyy)</th>
                <th>ArrivalDate (dd-MM-yyyy)</th>
                <th>IMAP Number</th>
                <th>Registration</th>
                <th>Seller Name</th>
                <th>Vendor Name</th>
                <th>Storage Location</th>
                <th>Destination</th> 
                <th>Make Desc</th>
                <th>Model Desc</th>
                <th>Variants</th>
                <th>Chassis No</th>
                <th>Pickuprooftype</th>
            </tr>
                {ResultDetail}
            </table>";

        string strResultDetail = @" <tr>
              <td>{DepartureDate}</td>
              <td>{ArrivalDate}</td>
              <td>{IMAPNumber}</td>
              <td>{Registration}</td>
              <td>{SellerName}</td>
              <td>{VendorName}</td>
              <td>{StorageLocation}</td>
              <td>{Destination}</td>
              <td>{MakeDesc}</td>
              <td>{ModelDesc}</td>
              <td>{Variants}</td>
              <td>{ChassisNo}</td>
              <td>{Pickuprooftype}</td>
        </tr>";

        // GET: Transportation
        public ActionResult Index()
        {
            return View();
        }

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
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
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
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
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

        #region UpdatePassword
        [HttpPost]
        public ActionResult UpdatePassword()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            objDataFeed.UpdatePassword(dt);
            return Json(new { success = true, message = "Password changed successfully." });
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
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            objDataFeed.DeleteTransportUser(dt);

            return Json(new { success = true, message = "Deleting User completed successfully." });
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
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
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

        #region UserList
        [HttpGet]
        public ActionResult UserList()
        {
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
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
        #endregion

        #region Transport Request & Detail
        #region UploadTransportRequest
        [HttpPost]
        public ActionResult UploadTransportRequest()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            objDataFeed.UploadTransportRequest(dt);

            return Json(new { success = true, message = "Uploading Transport Request completed successfully." });
        }
        #endregion
        #endregion

        #region Transport Order & Detail
        #region UploadTransportOrder
        [HttpPost]
        public ActionResult UploadTransportOrder()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            objDataFeed.UploadTransportOrder(dt);

            #region Send Email
            dt.Columns.Remove("cost");
            dt.Columns.Remove("feeCharged");

            string strSubject = $"Testing";
            string content = GetTableForEmail(dt);

            string Vname = dt.Rows[0]["vendorName"] == null ? "" : dt.Rows[0]["vendorName"].ToString();
            Vendor objv = objDataFeed.GetVendorEmailsByName(Vname);

            if(objv != null)
            {
                SendEmail(objv.Email, Vname, content, strSubject, objv.SecondaryEmails);
            }
            #endregion

            return Json(new { success = true, message = "Uploading Transport Order completed successfully." });
        }

        private string GetTableForEmail(DataTable dtdata)
        {
            var datalist = new StringBuilder();
            if (dtdata != null)
            {
                for (int i = 0; i < dtdata.Rows.Count; i++)
                {
                    double dDepartureDate = Convert.ToDouble(dtdata.Rows[i]["departureDate"] == null ? 0 : dtdata.Rows[i]["departureDate"]);
                    string strDepartureDate = dDepartureDate == 0 ? "" : UnixTimeStampToDateTime(dDepartureDate).ToString("dd-MM-yyyy");
                    double dArrivalDate = Convert.ToDouble(dtdata.Rows[i]["arrivalDate"] == null ? 0 : dtdata.Rows[i]["arrivalDate"]);
                    string strArrivalDate = dArrivalDate == 0 ? "" : UnixTimeStampToDateTime(dArrivalDate).ToString("dd-MM-yyyy");

                    var dataRec = strResultDetail
                    .Replace("{DepartureDate}", strDepartureDate)
                    .Replace("{ArrivalDate}", strArrivalDate)
                    .Replace("{IMAPNumber}", dtdata.Rows[i]["iMAPnumber"].ToString())
                    .Replace("{Registration}", dtdata.Rows[i]["registration"].ToString())
                    .Replace("{SellerName}", dtdata.Rows[i]["sellerName"].ToString())
                    .Replace("{VendorName}", dtdata.Rows[i]["vendorName"].ToString())
                    .Replace("{StorageLocation}", dtdata.Rows[i]["storageLocation"].ToString())
                    .Replace("{Destination}", dtdata.Rows[i]["destination"].ToString())
                    .Replace("{MakeDesc}", dtdata.Rows[i]["makeDesc"].ToString())
                    .Replace("{ModelDesc}", dtdata.Rows[i]["modelDesc"].ToString())
                    .Replace("{Variants}", dtdata.Rows[i]["variants"].ToString())
                    .Replace("{ChassisNo}", dtdata.Rows[i]["chassisNo"].ToString())
                    .Replace("{Pickuprooftype}", dtdata.Rows[i]["pickuprooftype"].ToString());

                    datalist.AppendLine(dataRec);
                }
            }
            string content= strResultTemplate.Replace("{ResultDetail}", datalist .ToString());
            return content;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
        #endregion

        #region UpdateTransportOrder
        [HttpPost]
        public ActionResult UpdateTransportOrder()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            objDataFeed.UpdateTransportOrder(dt);

            return Json(new { success = true, message = "Updating Transport Order completed successfully." });
        }
        #endregion

        #region DeleteTransportOrder
        [HttpPost]
        public ActionResult DeleteTransportOrder()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            objDataFeed.DeleteTransportOrder(dt);

            return Json(new { success = true, message = "Deleting Transport Order completed successfully." });
        }
        #endregion

        #region TransportOrderList
        [HttpGet]
        public ActionResult TransportOrderList()
        {
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            DataTable dt = objDataFeed.GetTransportOrderList();

            dt.Columns["OrderID"].ColumnName = "orderID";
            dt.Columns["OrderCode"].ColumnName = "orderCode";
            dt.Columns["UploadDate"].ColumnName = "uploadDate";
            dt.Columns["CreateDate"].ColumnName = "createDate";

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetTransportOrderDetailByOrderId
        [HttpPost]
        public ActionResult GetTransportOrderDetailByOrderId()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);

            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            DataTable dtresult = objDataFeed.GetTransportOrderDetailByOrderId(dt);

            dtresult.Columns["OrderID"].ColumnName = "orderID";
            dtresult.Columns["DepartureDate"].ColumnName = "departureDate";
            dtresult.Columns["ArrivalDate"].ColumnName = "arrivalDate";
            dtresult.Columns["IMAPNumber"].ColumnName = "iMAPnumber";
            dtresult.Columns["Registration"].ColumnName = "registration";
            dtresult.Columns["SellerName"].ColumnName = "sellerName";
            dtresult.Columns["VendorName"].ColumnName = "vendorName";
            dtresult.Columns["StorageLocation"].ColumnName = "storageLocation";
            dtresult.Columns["Destination"].ColumnName = "destination";
            dtresult.Columns["MakeDesc"].ColumnName = "makeDesc";
            dtresult.Columns["ModelDesc"].ColumnName = "modelDesc";
            dtresult.Columns["Variants"].ColumnName = "variants";
            dtresult.Columns["ChassisNo"].ColumnName = "chassisNo";
            dtresult.Columns["PickupRoofType"].ColumnName = "pickuprooftype";
            dtresult.Columns["Cost"].ColumnName = "cost";
            dtresult.Columns["FeeCharged"].ColumnName = "feeCharged";

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }
        #endregion
        #endregion

        #region Transport Schedule & Detail
        #region CreateSchedule
        [HttpPost]
        public ActionResult CreateSchedule()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Parse the JSON string
            JObject json = JObject.Parse(formData);

            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            int id = objDataFeed.SaveTransportSchedule(json);

            if (id == 0)
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "Schedule creation failed." });
            }
            else
            {
                return Json(new { success = true, message = "Schedule creation completed successfully.", scheduleID = id });
            }
        }
        #endregion

        #region CheckInVehicles
        [HttpPost]
        public ActionResult CheckInVehicles()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            objDataFeed.CheckInVehicles(dt);
            return Json(new { success = true, message = "Vehicles Check in successfully." });
        }
        #endregion

        #region CheckOutVehicles
        [HttpPost]
        public ActionResult CheckOutVehicles()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            objDataFeed.CheckOutVehicles(dt);
            return Json(new { success = true, message = "Vehicles Check out successfully." });
        }
        #endregion

        #region ScheduleList
        [HttpGet]
        public ActionResult ScheduleList()
        {
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            DataTable dt = objDataFeed.GetScheduleList();

            //dt.Columns["UserID"].ColumnName = "userid";
            //dt.Columns["UserName"].ColumnName = "userName";
            //dt.Columns["UserEmail"].ColumnName = "userEmail";
            //dt.Columns["LoginName"].ColumnName = "login";
            //dt.Columns["Password"].ColumnName = "password";
            //dt.Columns["DepartmentID"].ColumnName = "department";
            //dt.Columns["UserType"].ColumnName = "userType";

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region DeleteSchedule
        [HttpPost]
        public ActionResult DeleteSchedule()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            objDataFeed.DeleteTransportSchedule(dt);

            return Json(new { success = true, message = "Deleting Schedule completed successfully." });
        }
        #endregion

        #region UpdateSchedule
        [HttpPost]
        public ActionResult UpdateSchedule()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Parse the JSON string
            JObject json = JObject.Parse(formData);
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            int id = objDataFeed.UpdateTransportSchedule(json);
            if (id == 0)
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "Updating Schedule failed." });
            }
            else
            {
                return Json(new { success = true, message = "Updating Schedule completed successfully.", scheduleID = id });
            }
        }
        #endregion

        #region GetScheduleVehicleByScheduleID
        [HttpPost]
        public ActionResult GetScheduleVehicleByScheduleID()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);

            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            DataTable dtschedule = objDataFeed.GetScheduleByScheduleID(dt);
            DataTable dtscheduleDetail = objDataFeed.GetScheduleDetailByScheduleID(dt);

            int ScheduleID = int.Parse(dtschedule.Rows[0]["ScheduleID"].ToString());
            string EstimateDepartureDate = dtschedule.Rows[0]["EstimateDepartureDate"].ToString();
            string EstimateArrivalDate = dtschedule.Rows[0]["EstimateArrivalDate"].ToString();
            int FromYard = int.Parse(dtschedule.Rows[0]["FromYard"].ToString());
            int ToYard = int.Parse(dtschedule.Rows[0]["ToYard"].ToString());

            // Create an array to hold the detail objects
            var detailArray = new List<object>();

            for (int i = 0; i < dtscheduleDetail.Rows.Count; i++)
            {
                // Create an object for each detail item
                var detailItem = new
                {
                    vehicle = dtscheduleDetail.Rows[i]["Vehicle"].ToString(),
                    buildYear = dtscheduleDetail.Rows[i]["BuildYear"].ToString(),
                    makeDesc = dtscheduleDetail.Rows[i]["MakeDesc"].ToString(),
                    variants = dtscheduleDetail.Rows[i]["Variants"].ToString(),
                    auctionCode = dtscheduleDetail.Rows[i]["AuctionCode"].ToString(),
                    registration = dtscheduleDetail.Rows[i]["Registration"].ToString()
                };

                // Add the detail item to the array
                detailArray.Add(detailItem);
            }


            var result = new
            {
                data = new[]
            {
                new
                {
                     scheduleID = ScheduleID,
                     estimateDepartureDate = EstimateDepartureDate,
                     estimateArrivalDate = EstimateArrivalDate,
                     fromYard = FromYard,
                     toYard = ToYard,
                     detail = detailArray
                }
            }
            };

            // Serialize the result to JSON and return as Content result
            return Content(JsonConvert.SerializeObject(result), "application/json");
        }
        #endregion
        #endregion

        #region Vendor
        #region CreateVendor
        [HttpPost]
        public ActionResult CreateVendor()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            int id = objDataFeed.SaveVendor(dt);
            if (id == 0)
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "Vendor Creation failed." });
            }
            else
            {
                return Json(new { success = true, message = "Vendor Creation completed successfully.", id = id });
            }
        }
        #endregion

        #region UpdateVendor
        [HttpPost]
        public ActionResult UpdateVendor()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            int isDuplicate = objDataFeed.UpdateVendor(dt);
            if (isDuplicate == 0)
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "Updating Vendor failed." });
            }
            else
            {
                return Json(new { success = true, message = "Updating Vendor completed successfully." });
            }
        }
        #endregion

        #region DeleteVendor
        [HttpPost]
        public ActionResult DeleteVendor()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            objDataFeed.DeleteVendor(dt);

            return Json(new { success = true, message = "Deleting Vendor completed successfully." });
        }
        #endregion

        #region VendorList
        [HttpGet]
        public ActionResult VendorList()
        {
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            DataTable dt = objDataFeed.GetVendorList();

            dt.Columns["VendorID"].ColumnName = "vendorId";
            dt.Columns["VendorName"].ColumnName = "vendorName";
            dt.Columns["VendorCode"].ColumnName = "vendorCode";
            dt.Columns["ContactPhoneNumber"].ColumnName = "contactPhoneNumber";
            dt.Columns["Email"].ColumnName = "email";
            dt.Columns["SecondaryEmails"].ColumnName = "secondaryEmails";
            dt.Columns["Remark"].ColumnName = "remark";

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetVendorForCombo
        [HttpGet]
        public ActionResult GetVendorForCombo()
        {
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            DataTable dt = objDataFeed.GetVendorForCombo();

            dt.Columns["VendorId"].ColumnName = "vendorId";
            dt.Columns["VendorName"].ColumnName = "vendorName";

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #endregion

        #region Location
        #region CreateLocation
        [HttpPost]
        public ActionResult CreateLocation()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            int id = objDataFeed.SaveLocation(dt);
            if (id == 0)
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "Location Creation failed." });
            }
            else
            {
                return Json(new { success = true, message = "Location Creation completed successfully.", id = id });
            }
        }
        #endregion

        #region UpdateLocation
        [HttpPost]
        public ActionResult UpdateLocation()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            int isDuplicate = objDataFeed.UpdateLocation(dt);
            if (isDuplicate == 0)
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "Updating Location failed." });
            }
            else
            {
                return Json(new { success = true, message = "Updating Location completed successfully." });
            }
        }
        #endregion

        #region DeleteLocation
        [HttpPost]
        public ActionResult DeleteLocation()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            objDataFeed.DeleteLocation(dt);

            return Json(new { success = true, message = "Deleting Location completed successfully." });
        }
        #endregion

        #region LocationList
        [HttpGet]
        public ActionResult LocationList()
        {
            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            DataTable dt = objDataFeed.GetLocationList();

            dt.Columns["LocationID"].ColumnName = "locationId";
            dt.Columns["LocationCode"].ColumnName = "locationCode";
            dt.Columns["LocationName"].ColumnName = "locationName";
            dt.Columns["Email"].ColumnName = "email";

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #endregion

        #region GetVehicleInformation
        [HttpPost]
        public ActionResult GetVehicleInformation()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);

            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            DataTable dtresult = objDataFeed.GetVehicleListByRegistration(dt);

            dtresult.Columns["DetailID"].ColumnName = "detailID";
            dtresult.Columns["RequestID"].ColumnName = "requestID";
            dtresult.Columns["VehicleNumber"].ColumnName = "vehicle";
            dtresult.Columns["StorageLocation"].ColumnName = "storagelocation";
            dtresult.Columns["DestinationLocation"].ColumnName = "destinationlocation";
            dtresult.Columns["BuildYear"].ColumnName = "buildyear";
            dtresult.Columns["MakeDesc"].ColumnName = "makedesc";
            dtresult.Columns["Variants"].ColumnName = "variants";
            dtresult.Columns["AuctionCode"].ColumnName = "auctionCode";
            dtresult.Columns["Registration"].ColumnName = "registration";

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region Dashboard
        #region GetTransportStatusForDetail
        [HttpPost]
        public ActionResult GetTransportStatusForDetail()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);

            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            DataTable dtresult = objDataFeed.GetTransportStatusForDetaildb(dt);

            dtresult.Columns["IMAPNumber"].ColumnName = "iMAPNumber";
            dtresult.Columns["Registration"].ColumnName = "registration";
            dtresult.Columns["SellerName"].ColumnName = "sellerName";
            dtresult.Columns["VendorName"].ColumnName = "vendorName";
            dtresult.Columns["StorageLocation"].ColumnName = "storageLocation";
            dtresult.Columns["Destination"].ColumnName = "destination";
            dtresult.Columns["Status"].ColumnName = "status";

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetTransportStatusForCategory
        [HttpPost]
        public ActionResult GetTransportStatusForCategory()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);

            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            string jsonString = objDataFeed.GetTransportStatusForCategorydb(dt);

            return Content(jsonString, "application/json");
        }
        #endregion

        #region GetTransportLocation
        [HttpPost]
        public ActionResult GetTransportLocation()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);

            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            DataTable dtresult = objDataFeed.GetTransportLocation(dt);

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #endregion

        #region GetLocationByIMAPnumber
        [HttpPost]
        public ActionResult GetLocationByIMAPnumber()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);

            Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
            DataTable dtresult = objDataFeed.GetLocationByIMAPnumber(dt);

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        //#region GetLocation
        //[HttpGet]
        //public ActionResult GetLocation()
        //{
        //    Transport_DATAFEED objDataFeed = new Transport_DATAFEED();
        //    DataTable dt = objDataFeed.GetLocation();

        //    dt.Columns["LocationId"].ColumnName = "locationId";
        //    dt.Columns["Location"].ColumnName = "location";

        //    string jsString = DtToJSon(dt, "data");
        //    return Content(jsString, "application/json");
        //}
        //#endregion

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

        #region SendEmail
        private void SendEmail(string toEmail, string toName, string content, string subjectTitle,string ccEmails)
        {
            Mail mail = new Mail(smtpAddress, smtpPort, smtpEnablbeSSL, smtpUser, smtpPassword);
            mail.SenderEmail = smtpSenderEmail;
            mail.SenderName = smtpSenderName;

            mail.ToName = toName; 
            mail.ToEmail = toEmail; 
            mail.Subject = subjectTitle;
            mail.Content = content;
            mail.CC = ccEmails;
            mail.Send();
        }
        #endregion

    }
}