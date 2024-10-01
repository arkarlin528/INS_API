using Motto_Vehicle_DataFeed;
using Newtonsoft.Json;
using OfficeOpenXml;
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

namespace Motto_Vehicle_Service.Controllers
{
    public class RakaController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

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

            string jsString = DtToJSon(dt, "data");
            return Content(jsString, "application/json");
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

                    byte[] excelData = package.GetAsByteArray();

                    return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "VehiclesMasterData.xlsx");
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
    }
}