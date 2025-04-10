using INS_API_DataFeed;
using INS_API_DataFeed.DAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Text;
using static INS_API_DataFeed.InnoSync;
using System.Text.Json;

namespace INS_API.Controllers
{
    public class DataPortController : Controller
    {
        [HttpPost]
        public ActionResult SyncInnoData()
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }

            // Read the form data from the request
            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            try
            {
                //    var jsonData = JsonConvert.DeserializeObject<InnoPostData>(formData);
                //    jsonData.Data = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(formData)
                //.GetType().GetProperty("data").GetValue(JsonConvert.DeserializeObject(formData)));

                var doc = JsonDocument.Parse(formData);
                InnoSync innoSync = new InnoSync();
                innoSync.ID = 0;
                innoSync.TxnDate = DateTime.Now;
                innoSync.SchemaName = doc.RootElement.GetProperty("schema").GetProperty("name").GetString();
                innoSync.SchemaInfo = doc.RootElement.GetProperty("schema").GetRawText();
                innoSync.InspectionData = doc.RootElement.GetProperty("data").GetRawText();
                innoSync.SenderName = doc.RootElement.GetProperty("data").GetProperty("DelivererName").GetString();
                innoSync.ReceiverName = doc.RootElement.GetProperty("inspector_user_id").GetInt32().ToString();
                innoSync.MobileNumber = doc.RootElement.GetProperty("data").GetProperty("ContractNumber").GetString();
                innoSync.SellerCode = doc.RootElement.GetProperty("data").GetProperty("SellerName").GetString();
                innoSync.Inspector = doc.RootElement.GetProperty("inspector_user_id").GetInt32().ToString();
                innoSync.VehicleId = "";
                innoSync.ChasisNumber = doc.RootElement.GetProperty("data").GetProperty("ChassisNumber").GetString();
                innoSync.VIN = "";
                innoSync.RegistrationNumber = doc.RootElement.GetProperty("data").GetProperty("LicensePlateNumber").GetString();
                innoSync.CreatedBy = doc.RootElement.GetProperty("inspector_user_id").GetInt32().ToString();
                innoSync.CreatedDate = DateTime.Now;

                //var root = new InnoSync
                //{
                //    InspectorUserId = doc.RootElement.GetProperty("inspector_user_id").GetInt32(),
                //    EndTime = doc.RootElement.GetProperty("end_time").GetString(),
                //    CountdownTime = doc.RootElement.GetProperty("countdown_time").GetString(),
                //    Data = doc.RootElement.GetProperty("data").GetProperty("DelivererName").GetRawText(),       // stringified JSON
                //    Schema = doc.RootElement.GetProperty("schema").GetRawText()    // stringified JSON
                //};

                //if (jsonData == null || IsDieselEnginePropertiesNullOrEmpty(jsonData))
                //{
                //    Response.StatusCode = 400;
                //    return Json(new { success = false, message = "Invalid parameters: data is missing or empty." }, JsonRequestBehavior.AllowGet);
                //}

                bool blRtn = innoSync.CreateInnoSyncRecord();
                if (blRtn)
                {
                    return Json(new { success = true, message = " Inspection Saved Successfully." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Response.StatusCode = 409;
                    return Json(new { success = false, message = innoSync.strSyncError }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (System.Text.Json.JsonException)
            {
                Response.StatusCode = 400;
                return Json(new { success = false, message = "Invalid JSON format." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
            
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
    }
}