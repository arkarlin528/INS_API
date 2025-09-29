using INS_API_DataFeed;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace INS_API.Controllers
{
    public class SheetController : Controller
    {
        // GET: Sheet
        #region InspectionSheet
        [HttpGet]
        public ActionResult InspectionSheet(string RefNumber)
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }
            try
            {
                INS_DataFeed objDataFeed = new INS_DataFeed();
                DataTable dt = objDataFeed.GetInspectionSheet(RefNumber);

                foreach (DataRow row in dt.Rows)
                {
                    string inspectionDataJson = row["InspectionData"]?.ToString();

                    if (!string.IsNullOrEmpty(inspectionDataJson))
                    {
                        var inspectionDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(inspectionDataJson);

                        string makeCode = inspectionDict.ContainsKey("Make") ? inspectionDict["Make"]?.ToString() : "null";
                        string variantId = inspectionDict.ContainsKey("Variant") ? inspectionDict["Variant"]?.ToString() : "null";

                        DataTable dtmake = objDataFeed.GetMakeByCode(makeCode);
                        string makeName = "";
                        if (dtmake != null && dtmake.Rows.Count > 0)
                        {
                            makeName = dtmake.Rows[0]["Desc_BU"].ToString();
                        }

                        DataTable dtvariant = objDataFeed.GetModelTemplateById(variantId == "null" ? 0 : int.Parse(variantId));
                        string variantName = "";
                        if (dtvariant != null && dtvariant.Rows.Count > 0)
                        {
                            variantName = dtvariant.Rows[0]["Variants"].ToString();
                        }

                        if (!string.IsNullOrEmpty(makeName)) inspectionDict["Make"] = makeName;
                        if (!string.IsNullOrEmpty(variantName)) inspectionDict["Variant"] = variantName;

                        row["InspectionData"] = JsonConvert.SerializeObject(inspectionDict);
                    }
                }

                string jsString = JsonConvert.SerializeObject(dt);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        // GET: Sheet
        #region BookInSheet
        [HttpGet]
        public ActionResult BookInSheet(string RefNumber)
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }
            try
            {
                INS_DataFeed objDataFeed = new INS_DataFeed();
                DataTable dt = objDataFeed.GetBookInSheet(RefNumber);

                string jsString = JsonConvert.SerializeObject(dt);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        // GET: Sheet
        #region GenerateDataSheet
        [HttpGet]
        public ActionResult GenerateDataSheet(string RefNumber)
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }
            try
            {
                INS_DataFeed objDataFeed = new INS_DataFeed();
                DataTable dt = objDataFeed.GenerateDataSheet(RefNumber);

                foreach (DataRow row in dt.Rows)
                {
                    string inspectionDataJson = row["InspectionData"]?.ToString();

                    if (!string.IsNullOrEmpty(inspectionDataJson))
                    {
                        var inspectionDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(inspectionDataJson);

                        string sellerCode = inspectionDict.ContainsKey("SellerName") ? inspectionDict["SellerName"]?.ToString() : "null";
                        string makeCode = inspectionDict.ContainsKey("Make") ? inspectionDict["Make"]?.ToString() : "null";
                        string variantId = inspectionDict.ContainsKey("Variant") ? inspectionDict["Variant"]?.ToString() : "null";
                        string receiverSign = inspectionDict.ContainsKey("ReceiverSign") &&
                                                 inspectionDict["ReceiverSign"] is JArray receiverArray &&
                                                 receiverArray.Count > 0
                                               ? receiverArray[0]?.ToString() ?? ""
                                               : "";

                        string delivererSign = inspectionDict.ContainsKey("Deliverersign") &&
                                               inspectionDict["Deliverersign"] is JArray delivererArray &&
                                               delivererArray.Count > 0
                                                ? delivererArray[0]?.ToString() ?? ""
                                                : "";

                        string tracingPaperImage = inspectionDict.ContainsKey("TracingPaperImage") &&
                                                   inspectionDict["TracingPaperImage"] is JArray tracingArray &&
                                                   tracingArray.Count > 0
                                                ? tracingArray[0]?.ToString() ?? ""
                                                : "";


                        DataTable dtseller = objDataFeed.GetSellerByCode(sellerCode);
                        string sellerName = "";
                        if (dtseller != null && dtseller.Rows.Count > 0)
                        {
                            sellerName = dtseller.Rows[0]["SellerNameEn"].ToString();
                        }

                        DataTable dtBodyType = objDataFeed.GetBodyByVarId(variantId == "null" ? 0 : int.Parse(variantId));
                        string bodyType = "";
                        if (dtBodyType != null && dtBodyType.Rows.Count > 0)
                        {
                            bodyType = dtBodyType.Rows[0]["Body_BU"].ToString();
                        }

                        DataTable dtFuelType = objDataFeed.GetFuelTypeByVarId(variantId == "null" ? 0 : int.Parse(variantId));
                        string fuelType = "";
                        if (dtFuelType != null && dtFuelType.Rows.Count > 0)
                        {
                            fuelType = dtFuelType.Rows[0]["Fuel_BU"].ToString();
                        }

                        DataTable dtmake = objDataFeed.GetMakeByCode(makeCode);
                        string makeName = "";
                        if (dtmake != null && dtmake.Rows.Count > 0)
                        {
                            makeName = dtmake.Rows[0]["Desc_BU"].ToString();
                        }

                        DataTable dtreceiverSign = objDataFeed.GetOBSImageByKey(receiverSign, RefNumber);
                        string receiver_Sign = "";
                        if (dtreceiverSign != null && dtreceiverSign.Rows.Count > 0)
                        {
                            receiver_Sign = dtreceiverSign.Rows[0]["OBSImagePath"].ToString();
                        }

                        DataTable dtdelivererSign = objDataFeed.GetOBSImageByKey(delivererSign, RefNumber);
                        string deliverer_Sign = "";
                        if (dtdelivererSign != null && dtdelivererSign.Rows.Count > 0)
                        {
                            deliverer_Sign = dtdelivererSign.Rows[0]["OBSImagePath"].ToString();
                        }

                        DataTable dtTracingPaperImage = objDataFeed.GetOBSImageByKey(tracingPaperImage, RefNumber);
                        string tracingPaper_Image = "";
                        if (dtTracingPaperImage != null && dtTracingPaperImage.Rows.Count > 0)
                        {
                            tracingPaper_Image = dtTracingPaperImage.Rows[0]["OBSImagePath"].ToString();
                        }

                        DataTable dtvariant = objDataFeed.GetModelTemplateById(variantId=="null"? 0 : int.Parse(variantId));
                        string variantName = "";
                        if (dtvariant != null && dtvariant.Rows.Count > 0)
                        {
                            variantName = dtvariant.Rows[0]["Variants"].ToString();
                        }

                        DataTable dtModelTemplate_DESC = objDataFeed.GetModelTemplateForDataEntryByVarId(variantId == "null" ? 0 : int.Parse(variantId));
                        string modelCode = "";
                        if (dtModelTemplate_DESC != null && dtModelTemplate_DESC.Rows.Count > 0)
                        {
                            modelCode = dtModelTemplate_DESC.Rows[0]["ModelCode"].ToString();
                        }

                        if (!string.IsNullOrEmpty(bodyType)) inspectionDict["BodyType"] = bodyType;
                        if (!string.IsNullOrEmpty(fuelType)) inspectionDict["FuelType"] = fuelType;
                        if (!string.IsNullOrEmpty(sellerName)) inspectionDict["SellerName"] = sellerName;
                        if (!string.IsNullOrEmpty(makeName)) inspectionDict["Make"] = makeName;
                        if (!string.IsNullOrEmpty(variantName)) inspectionDict["Variant"] = variantName;
                        if (!string.IsNullOrEmpty(modelCode)) inspectionDict["ModelCode"] = modelCode;
                        if (!string.IsNullOrEmpty(deliverer_Sign)) inspectionDict["Deliverersign"] = new[] { deliverer_Sign };
                        if (!string.IsNullOrEmpty(receiver_Sign)) inspectionDict["ReceiverSign"] = new[] { receiver_Sign };
                        if (!string.IsNullOrEmpty(tracingPaper_Image)) inspectionDict["TracingPaperImage"] = new[] { tracingPaper_Image };

                        row["InspectionData"] = JsonConvert.SerializeObject(inspectionDict);
                    }
                }

                string jsString = JsonConvert.SerializeObject(dt);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        // GET: Sheet
        #region InspectionDataList
        [HttpGet]
        public ActionResult InspectionDataList()
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }
            try
            {
                INS_DataFeed objDataFeed = new INS_DataFeed();
                DataTable dt = objDataFeed.GetInspectionDataList();

                string jsString = JsonConvert.SerializeObject(dt);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region InspectionDataListV2
        [HttpGet]
        public ActionResult InspectionDataListV2()
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }
            try
            {
                INS_DataFeed objDataFeed = new INS_DataFeed();
                DataTable dt = objDataFeed.GetInspectionDataListV2();

                string jsString = JsonConvert.SerializeObject(dt);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion
    }
}