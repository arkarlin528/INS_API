using MOTTO_DATAFEED.DAO;
using Motto_Vehicle_DataFeed;
using Motto_Vehicle_DataFeed.DAO;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Motto_Vehicle_Service.Controllers
{
    public class BuyNowController : Controller
    {
        // GET: BuyNow
        public ActionResult Index()
        {
            return View();
        }

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
            BuyNow_DATAFEED objDataFeed = new BuyNow_DATAFEED();
            int id = objDataFeed.SaveBuyNowUser(dt);
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
            BuyNow_DATAFEED objDataFeed = new BuyNow_DATAFEED();
            DataTable dtinfo = objDataFeed.LoginBuyNowUser(dt);
            if (dtinfo.Rows.Count > 0)
            {
                string jsonData = JsonConvert.SerializeObject(dtinfo);
                return Content(jsonData, "application/json");
            }
            else
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "Login failed."});
            }
        }
        #endregion

        #region GetBnBDataList
        [HttpPost]
        public ActionResult GetBnBDataList()
        {
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            BuyNow_DATAFEED objDataFeed = new BuyNow_DATAFEED();
            List<BnBData> Data = objDataFeed.GetBnBDataList(dt);

            string jsString = JsonConvert.SerializeObject(Data);
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetMakes
        [HttpGet]
        public ActionResult GetMakes()
        {
            BuyNow_DATAFEED objDataFeed = new BuyNow_DATAFEED();
            List<AMake> Data = objDataFeed.GetMakes();

            string jsString = JsonConvert.SerializeObject(Data);
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetModels
        [HttpGet]
        public ActionResult GetModels(string make)
        {
            BuyNow_DATAFEED objDataFeed = new BuyNow_DATAFEED();
            List<AModel> Data = objDataFeed.GetModels(make);

            string jsString = JsonConvert.SerializeObject(Data);
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetGear
        [HttpGet]
        public ActionResult GetGear()
        {
            BuyNow_DATAFEED objDataFeed = new BuyNow_DATAFEED();
            List<AGear> Data = objDataFeed.GetGear();

            string jsString = JsonConvert.SerializeObject(Data);
            return Content(jsString, "application/json");
        }
        #endregion

        #region GetBnBData
        [HttpGet]
        public ActionResult GetBnBData(string vehicleNumber)
        {
            BuyNow_DATAFEED objDataFeed = new BuyNow_DATAFEED();
            BnBData Data = objDataFeed.GetBnBData(vehicleNumber);
            objDataFeed.AddViewerCount(vehicleNumber);

            string jsString = JsonConvert.SerializeObject(Data);
            return Content(jsString, "application/json");
        }
        #endregion

        #region SaveBnBBidLog
        [HttpPost]
        public ActionResult SaveBnBBidLog()
        {
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            // Convert JSON string to DataTable
            DataTable dt = JsonToDt(formData);
            BuyNow_DATAFEED objDataFeed = new BuyNow_DATAFEED();
            int id = objDataFeed.SaveBnBBidLog(dt);

            if (id == 0)
            {
                Response.StatusCode = 409;
                return Json(new { success = false, message = "Bid Log Creation failed." });
            }
            else
            {
                return Json(new { success = true, message = "Bid Log Creation completed successfully.", id = id });
            }
        }
        #endregion

        #region GetAllImages
        [HttpGet]
        public ActionResult GetAllImages(string vehicleNumber)
        {
            BuyNow_DATAFEED objDataFeed = new BuyNow_DATAFEED();
            List<VIMImageGallery> imageGallery = objDataFeed.GetAllImages(vehicleNumber);
            List<string> imgList = new List<string>();
            int imgCount = 0;
            if (imageGallery.Count > 0)
            {
                imgList = imageGallery[0].AllImageList;
                imgCount = imgList.Count;
                for (int i = 0; i < imgList.Count; i++)
                {
                    imgList[i] = imageGallery[0].SourcePath + imgList[i].ToString();
                }
            }

            string jsString = JsonConvert.SerializeObject(imgList);
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