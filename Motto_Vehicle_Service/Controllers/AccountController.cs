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
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Motto_Vehicle_Service.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        #region ExportAccountReconcilationReport
        [HttpGet]
        public ActionResult ExportAccountReconcilationReport(string date, string code, string seller,string svtype)
        {
            //string formData;
            //using (var reader = new StreamReader(Request.InputStream))
            //{
            //    formData = reader.ReadToEnd();
            //}

            //// Convert JSON string to DataTable
            //DataTable dtData = JsonToDt(formData);

            Account_DATAFEED objDataFeed = new Account_DATAFEED();
            DataTable dt = objDataFeed.GetAccountReconcilationReport(date, code, seller, svtype);
            if (dt.Rows.Count > 0) { 
            List<Account_Reconciliation_Raw> oraw = objDataFeed.ConvertDataToRaw(dt);

            Account_RECONCILIATION _RECONCILIATION = new Account_RECONCILIATION();
            List<Account_Reconciliation_Template> otemplate = _RECONCILIATION.ConvertToTemplateLayout(oraw);
            ExcelPackage excelPackage = _RECONCILIATION.getExcelComponent(otemplate);

            // Get the modified Excel file as a byte array
            byte[] excelData = excelPackage.GetAsByteArray();

            // Return the Excel file as a downloadable file
            return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AccountReconcilationReport.xlsx");
            }
            return new HttpStatusCodeResult(HttpStatusCode.NoContent, "No data available for the given parameters.");
        }
        #endregion

        #region GetAuctionDate
        [HttpGet]
        public ActionResult GetAuctionDate()
        {
            Account_DATAFEED objDataFeed = new Account_DATAFEED();
            DataTable dtresult = objDataFeed.GetAuctionDate();

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }
        #endregion

        [HttpGet]
        public ActionResult GetAuctionCodeByDate(string date)
        {
            Account_DATAFEED objDataFeed = new Account_DATAFEED();
            DataTable dtresult = objDataFeed.GetAuctionCodeByDate(date);

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }

        [HttpGet]
        public ActionResult GetSellerByCode(string code)
        {
            Account_DATAFEED objDataFeed = new Account_DATAFEED();
            DataTable dtresult = objDataFeed.GetSellerByCode(code);

            string jsString = DtToJSon(dtresult, "data");
            return Content(jsString, "application/json");
        }

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