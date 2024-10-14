using Motto_Vehicle_DataFeed;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace Motto_Vehicle_Service.Controllers
{
    public class RakaController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        #region User
        #region RegisterUser
        [HttpPost]
        public ActionResult RegisterUser()
        {
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            DataTable dt = JsonToDt(formData);
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            int id = objDataFeed.SaveRakaUser(dt);
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
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            DataTable dt = JsonToDt(formData);
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            int isDuplicate = objDataFeed.UpdateRakaUser(dt);
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
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            DataTable dt = JsonToDt(formData);
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
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

            DataTable dt = JsonToDt(formData);
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            objDataFeed.DeleteRakaUser(dt);

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
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dtinfo = objDataFeed.LoginRakaUser(dt);
            if (dtinfo.Rows.Count > 0)
            {
                dtinfo.Columns["UserID"].ColumnName = "userid";
                dtinfo.Columns["UserName"].ColumnName = "userName";
                dtinfo.Columns["Email"].ColumnName = "userEmail";
                dtinfo.Columns["LoginName"].ColumnName = "login";
                dtinfo.Columns.Remove("Password");
                dtinfo.Columns["PhoneNumber"].ColumnName = "phoneNumber";

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

        //#region LoginUser
        //[HttpPost]
        //public ActionResult LoginUser()
        //{
        //    // Read the form data from the request
        //    string formData;
        //    using (var reader = new StreamReader(Request.InputStream))
        //    {
        //        formData = reader.ReadToEnd();
        //    }

        //    // Convert JSON string to DataTable
        //    DataTable dt = JsonToDt(formData);
        //    Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
        //    LoginIMAPDto dtinfo = objDataFeed.LoginRakaUser(dt);
        //    if (dtinfo.guid != null)
        //    {
        //        string successMessage = "Login successful.";
        //        string jsonData = JsonConvert.SerializeObject(dtinfo);
        //        return Content(jsonData, "application/json");
        //    }
        //    else
        //    {
        //        Response.StatusCode = 409;
        //        return Json(new { success = false, message = "Login failed." });
        //    }
        //}
        //#endregion

        #region UserList
        [HttpGet]
        public ActionResult UserList()
        {
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dt = objDataFeed.GetUserList();

            dt.Columns["UserID"].ColumnName = "userid";
            dt.Columns["UserName"].ColumnName = "userName";
            dt.Columns["UserEmail"].ColumnName = "userEmail";
            dt.Columns["LoginName"].ColumnName = "login";
            dt.Columns.Remove("Password");
            dt.Columns["PhoneNumber"].ColumnName = "phoneNumber";

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion
        #endregion

        #region SearchMagicWords
        [HttpPost]
        public ActionResult SearchMagicWords()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);

            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dtresult = objDataFeed.SearchMagicWords(dt);

            //dtresult.Columns["DetailID"].ColumnName = "detailID";
            //dtresult.Columns["RequestID"].ColumnName = "requestID";

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region AdvanceSearch
        [HttpPost]
        public ActionResult AdvanceSearch()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }
            
            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);

            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dtresult = objDataFeed.AdvanceSearch(dt);

            //dtresult.Columns["DetailID"].ColumnName = "detailID";
            //dtresult.Columns["RequestID"].ColumnName = "requestID";

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetMakeForCombo
        [HttpGet]
        public ActionResult GetMakeForCombo()
        {
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dt = objDataFeed.GetMakeForCombo();

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetModelForCombo
        [HttpGet]
        public ActionResult GetModelForCombo(string make)
        {
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dt = objDataFeed.GetModelForCombo(make);

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetYearForCombo
        [HttpGet]
        public ActionResult GetYearForCombo()
        {
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dt = objDataFeed.GetYearForCombo();

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetEngineTypeForCombo
        [HttpGet]
        public ActionResult GetEngineTypeForCombo()
        {
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dt = objDataFeed.GetEngineTypeForCombo();

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetSeatingCapacityForCombo
        [HttpGet]
        public ActionResult GetSeatingCapacityForCombo()
        {
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dt = objDataFeed.GetSeatingCapacityForCombo();

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetBodyStyleForCombo
        [HttpGet]
        public ActionResult GetBodyStyleForCombo()
        {
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dt = objDataFeed.GetBodyStyleForCombo();

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetSubModelForCombo
        [HttpGet]
        public ActionResult GetSubModelForCombo(string make)
        {
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dt = objDataFeed.GetSubModelForCombo(make);

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetViewDetail
        [HttpGet]
        public ActionResult GetViewDetail(string id)
        {
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dt = objDataFeed.GetViewDetail(id);

            string jsString = DtToJSonForViewDetail(dt, "data");
            return Content(jsString, "application/json");
        }

        public static string DtToJSonForViewDetail(DataTable dt, string strHeader)
        {
            JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
            scriptSerializer.MaxJsonLength = Int32.MaxValue;
            List<Dictionary<string, object>> dictionaryList = new List<Dictionary<string, object>>();

            foreach (DataRow row in dt.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();

                foreach (DataColumn column in dt.Columns)
                {
                    var columnName = column.ColumnName;

                    if (columnName == "Prices")
                    {
                        string pricesString = row[column].ToString();
                        try
                        {
                            var pricesJson = scriptSerializer.Deserialize<object>(pricesString);
                            dictionary.Add(columnName, pricesJson);
                        }
                        catch
                        {
                            dictionary.Add(columnName, pricesString);
                        }
                    }
                    else
                    {
                        dictionary.Add(column.ColumnName, row[column]);
                    }
                }

                dictionaryList.Add(dictionary);
            }

            return "{ \"" + strHeader + "\" : " + scriptSerializer.Serialize(dictionaryList) + "}";
        }
        #endregion

        #region GetMarketShareByBrandPerMonth
        [HttpPost]
        public ActionResult GetMarketShareByBrandPerMonth()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);

            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dtresult = objDataFeed.GetMarketShareByBrandPerMonth(dt);

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetMarketShareBySegmentPerMonth
        [HttpPost]
        public ActionResult GetMarketShareBySegmentPerMonth()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);

            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dtresult = objDataFeed.GetMarketShareBySegmentPerMonth(dt);

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetSegmentSaleChart
        [HttpPost]
        public ActionResult GetSegmentSaleChart()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);

            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dtresult = objDataFeed.GetSegmentSaleChart(dt);

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetBrandSaleChart
        [HttpPost]
        public ActionResult GetBrandSaleChart()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);

            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dtresult = objDataFeed.GetBrandSaleChart(dt);

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetTopTwentySaleByMonth
        [HttpPost]
        public ActionResult GetTopTwentySaleByMonth()
        {
            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);

            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dtresult = objDataFeed.GetTopTwentySaleByMonth(dt);

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        #region ExportVehicleMasterData
        [HttpGet]
        public ActionResult ExportVehicleMasterData(string make, string family)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dt = objDataFeed.GetVehicleMasterData(make, family);
            if (dt.Rows.Count > 0)
            {
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    worksheet.Cells["A1"].LoadFromDataTable(dt, true);
                    worksheet.Cells.AutoFitColumns();

                    byte[] excelData = package.GetAsByteArray();

                    return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "VehiclesMasterData.xlsx");
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.NoContent, "No data available for the given parameters.");
        }
        #endregion

        #region ExportSearchedVehiclesExcel
        [HttpPost]
        public ActionResult ExportSearchedVehiclesExcel()
        {
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }
            DataTable dt = JsonToDt(formData);
            string strsearchMethod = dt.Rows[0]["searchMethod"] == null ? "" : dt.Rows[0]["searchMethod"].ToString();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Raka_DATAFEED objDataFeed = new Raka_DATAFEED();
            DataTable dtresult = new DataTable();
            if (strsearchMethod == "advance")
            {
                dtresult = objDataFeed.AdvanceSearch(dt);
            }
            else if (strsearchMethod == "magic")
            {
                dtresult = objDataFeed.SearchMagicWords(dt);
            }
            dtresult.Columns.Remove("ID");
            if (dtresult.Rows.Count > 0)
            {
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    worksheet.Cells["A1"].LoadFromDataTable(dtresult, true);
                    worksheet.Cells.AutoFitColumns();

                    byte[] excelData = package.GetAsByteArray();

                    return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SearchedVehiclesData.xlsx");
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.NoContent, "No data available for the given parameters.");
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