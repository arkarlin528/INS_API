using Motto_Vehicle_DataFeed;
using Motto_Vehicle_DataFeed.DAO;
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
    public class SimulcastController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region GetTodayAuctionEnquiry
        [HttpGet]
        public ActionResult GetTodayAuctionEnquiry()
        {
            Simulcast_DATAFEED objDataFeed = new Simulcast_DATAFEED();
            DataTable dt = objDataFeed.GetTodayAuctionEnquiry();

            // Convert DataTable to a list of dictionaries for more flexibility
            var rows = new List<Dictionary<string, object>>();

            foreach (DataRow row in dt.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    // Check if the column is "DetailInfo" and parse its JSON value
                    if (col.ColumnName == "DetailInfo" && row[col] != DBNull.Value)
                    {
                        // Parse the JSON string in "DetailInfo" column to an object
                        dict[col.ColumnName] = JsonConvert.DeserializeObject(row[col].ToString());
                    }
                    else
                    {
                        dict[col.ColumnName] = row[col];
                    }
                }
                rows.Add(dict);
            }

            // Serialize the list of dictionaries to JSON
            string jsString = JsonConvert.SerializeObject(rows, Formatting.Indented);
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
    }
}