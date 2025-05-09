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
        public ActionResult SyncInnoData(string RefKey)
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }

            // Read the form data from the request
            string formData ="";
            Request.InputStream.Position = 0;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }


            try
            {
                //    var jsonData = JsonConvert.DeserializeObject<InnoPostData>(formData);
                //    jsonData.Data = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(formData)
                //.GetType().GetProperty("data").GetValue(JsonConvert.DeserializeObject(formData)));
                string strDataError = "";

                var doc = JsonDocument.Parse(formData);
                InnoSync innoSync = new InnoSync();
                innoSync.ID = 0;
                innoSync.RefKey = RefKey;
                innoSync.TxnDate = DateTime.Now;
                innoSync.SchemaName = doc.RootElement.GetProperty("schema").GetProperty("key").GetString();
                //Schema
                if (doc.RootElement.GetProperty("schema").TryGetProperty("key", out JsonElement SchemaKey))
                {
                    // Check if the property is null or has a value
                    if (SchemaKey.ValueKind == JsonValueKind.Null)
                    {
                        innoSync.SchemaName = "";
                        strDataError += "Schema Key's Value is missing";
                    }
                    else
                    {
                        innoSync.SchemaName = doc.RootElement.GetProperty("schema").GetProperty("key").GetString();
                    }
                }
                else
                {
                    strDataError += "Schema's Key is missing";
                }

                //Delivery
                if (doc.RootElement.GetProperty("data").TryGetProperty("DelivererName", out JsonElement devliveryName))
                {
                    // Check if the property is null or has a value
                    if (devliveryName.ValueKind == JsonValueKind.Null)
                    {
                        innoSync.SenderName = "";
                    }
                    else
                    {
                        innoSync.SenderName = doc.RootElement.GetProperty("data").GetProperty("DelivererName").GetString();
                    }
                }

                //Inspector ID
                if (doc.RootElement.GetProperty("data").TryGetProperty("inspector_user_id", out JsonElement inspectorID))
                {
                    // Check if the property is null or has a value
                    if (inspectorID.ValueKind == JsonValueKind.Null)
                    {
                        innoSync.InspectorID = "";
                        innoSync.ReceiverName = "";
                    }
                    else
                    {
                        innoSync.ReceiverName = doc.RootElement.GetProperty("inspector_user_id").GetInt32().ToString();
                        innoSync.InspectorID = doc.RootElement.GetProperty("inspector_user_id").GetInt32().ToString();
                    }
                }

                //Inspector Email
                if (doc.RootElement.TryGetProperty("inspector_user_email", out JsonElement inspectorEmail))
                {
                    // Check if the property is null or has a value
                    if (inspectorEmail.ValueKind == JsonValueKind.Null)
                    {
                        innoSync.Inspector = "";
                        strDataError += "inspector_user_email's value is missing";
                    }
                    else
                    {
                        innoSync.Inspector = doc.RootElement.GetProperty("inspector_user_email").GetString();
                        innoSync.CreatedBy = doc.RootElement.GetProperty("inspector_user_email").GetString().ToString();
                    }
                }
                else
                {
                    strDataError += "inspector_user_email is missing";
                }
                
                innoSync.SchemaInfo = doc.RootElement.GetProperty("schema").GetRawText();
                innoSync.InspectionData = doc.RootElement.GetProperty("data").GetRawText();
                //ContractNumber
                if (doc.RootElement.GetProperty("data").TryGetProperty("ContractNumber", out JsonElement contact))
                {
                    // Check if the property is null or has a value
                    if (contact.ValueKind == JsonValueKind.Null)
                    {
                        innoSync.MobileNumber = "";
                    }
                    else
                    {
                        innoSync.MobileNumber = doc.RootElement.GetProperty("data").GetProperty("ContractNumber").GetString();
                    }
                }
                innoSync.SellerCode = doc.RootElement.GetProperty("data").GetProperty("SellerName").GetString();               
                
                innoSync.VehicleId = "";
                if (doc.RootElement.GetProperty("data").TryGetProperty("ChassisNumber", out JsonElement chasis))
                {
                    // Check if the property is null or has a value
                    if (chasis.ValueKind == JsonValueKind.Null)
                    {
                        innoSync.ChasisNumber = "";
                    }
                    else
                    {
                        innoSync.ChasisNumber = doc.RootElement.GetProperty("data").GetProperty("ChassisNumber").GetString();
                    }
                }
                innoSync.VIN = "";
                if (doc.RootElement.TryGetProperty("LicensePlateNumber", out JsonElement regNumber))
                {
                    // Check if the property is null or has a value
                    if (regNumber.ValueKind == JsonValueKind.Null)
                    {
                        innoSync.RegistrationNumber = "";
                    }
                    else
                    {
                        innoSync.RegistrationNumber = doc.RootElement.GetProperty("data").GetProperty("LicensePlateNumber").GetString();
                    }
                }                
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
                if (strDataError != "")
                {
                    Response.StatusCode = 400;
                    return Json(new { success = false, message = strDataError }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    bool blRtn = innoSync.CreateInnoSyncRecord();
                    if (blRtn)
                    {
                        return Json(new { success = true, message = " Inspection Saved Successfully.", RefKey= innoSync.ID.ToString() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        Response.StatusCode = 409;
                        return Json(new { success = false, message = innoSync.strSyncError }, JsonRequestBehavior.AllowGet);
                    }
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

        public int TryFindKey(JsonElement element, string keyToFind, out JsonElement foundElement)
        {
            int Rtn = 0;
            // 0 : Not Found
            // 1: Found
            // 2: Value Null
            // 3: Value is okay
            // Check if the current element is an object
            if (element.ValueKind == JsonValueKind.Object)
            {
                // Loop through each property in the object
                foreach (JsonProperty property in element.EnumerateObject())
                {
                    // Check if the current property matches the key
                    if (property.Name.Equals(keyToFind, StringComparison.OrdinalIgnoreCase))
                    {
                        foundElement = property.Value;
                        Rtn = 1;
                        if (foundElement.ValueKind == JsonValueKind.Null)
                        {
                            Rtn = 2;
                        }
                        else
                        {
                            Rtn = 3;
                        }
                        return Rtn; // Key found
                    }

                    // If the key is not found, recurse into the child elements
                    if (TryFindKey(property.Value, keyToFind, out foundElement) == 0)
                    {
                        Rtn = 1;
                        if (foundElement.ValueKind == JsonValueKind.Null)
                        {
                            Rtn = 2;
                        }
                        else
                        {
                            Rtn = 3;
                        }
                        return Rtn; // Key found in child element
                    }
                }
            }
            else if (element.ValueKind == JsonValueKind.Array)
            {
                // If it's an array, loop through each item
                foreach (JsonElement item in element.EnumerateArray())
                {
                    if (TryFindKey(item, keyToFind, out foundElement) == 0)
                    {
                        Rtn = 1;
                        if (foundElement.ValueKind == JsonValueKind.Null)
                        {
                            Rtn = 2;
                        }
                        else
                        {
                            Rtn = 3;
                        }
                        return Rtn; // Key found in an array element
                    }
                }
            }

            // If not found, set output to default and return false
            foundElement = default;
            return Rtn;
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