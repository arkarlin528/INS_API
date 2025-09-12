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
using System.Net.Http.Headers;
using System.Net.Http;
using OfficeOpenXml.Export.HtmlExport.StyleCollectors.StyleContracts;
using Nest;
using Newtonsoft.Json.Linq;

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
                innoSync.SchemaName = doc.RootElement.GetProperty("schema").GetProperty("key").ToString();
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
                        innoSync.SchemaName = doc.RootElement.GetProperty("schema").GetProperty("key").ToString();
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
                        innoSync.SenderName = doc.RootElement.GetProperty("data").GetProperty("DelivererName").ToString();
                    }
                }

                //Inspector ID
                if (doc.RootElement.TryGetProperty("inspector_user_id", out JsonElement inspectorID))
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
                        innoSync.Inspector = doc.RootElement.GetProperty("inspector_user_email").ToString();
                        innoSync.CreatedBy = doc.RootElement.GetProperty("inspector_user_email").ToString();
                    }
                }
                else
                {
                    strDataError += "inspector_user_email is missing";
                }
                
                innoSync.SchemaInfo = doc.RootElement.GetProperty("schema").GetRawText();
                innoSync.InspectionData = doc.RootElement.GetProperty("data").GetRawText();
                //ContractNumber
                if (doc.RootElement.GetProperty("data").TryGetProperty("PhoneNumber", out JsonElement contact))
                {
                    // Check if the property is null or has a value
                    if (contact.ValueKind == JsonValueKind.Null)
                    {
                        innoSync.MobileNumber = "";
                    }
                    else
                    {
                        innoSync.MobileNumber = doc.RootElement.GetProperty("data").GetProperty("PhoneNumber").ToString();
                    }
                }
                innoSync.SellerCode = doc.RootElement.GetProperty("data").GetProperty("SellerName").ToString();               
                
                innoSync.VehicleId = "";
                if (doc.RootElement.GetProperty("data").TryGetProperty("ChassisNumber", out JsonElement chasis))
                {
                    // Check if the property is null or has a value
                    if (chasis.ValueKind == JsonValueKind.Null)
                    {
                        innoSync.ChasisNumber = "";
                        innoSync.VIN = "";
                    }
                    else
                    {
                        innoSync.ChasisNumber = doc.RootElement.GetProperty("data").GetProperty("ChassisNumber").ToString();
                        innoSync.VIN = doc.RootElement.GetProperty("data").GetProperty("ChassisNumber").ToString();
                    }
                }
            
                if (doc.RootElement.GetProperty("data").TryGetProperty("LicensePlateNumber", out JsonElement regNumber))
                {
                    // Check if the property is null or has a value
                    if (regNumber.ValueKind == JsonValueKind.Null)
                    {
                        innoSync.RegistrationNumber = "";
                    }
                    else
                    {
                        innoSync.RegistrationNumber = doc.RootElement.GetProperty("data").GetProperty("LicensePlateNumber").ToString();
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
                        string vehicleId= SyncOnIMAP(innoSync.ID);
                        if (vehicleId.Contains("failed"))
                        {
                            Response.StatusCode = 200;
                            return Json(new { success = false, message = "Inspection Saved Successfully But Sync failed to IMAP.", refKey = innoSync.ID.ToString(), errorFromImap = vehicleId }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            innoSync.VehicleId = vehicleId;
                            innoSync.UpdateVehicleID();
                            //using (var client = new HttpClient())
                            //{
                            //    client.DefaultRequestHeaders.Add("apiKey", apiKey);
                            //    var response = client.GetAsync($"https://localhost:44327/Sheet/GenerateDataSheet?RefNumber={RefKey}").Result;

                            //    if (!response.IsSuccessStatusCode)
                            //    {
                            //    }
                            //    else
                            //    {
                            //        var responseContent = response.Content.ReadAsStringAsync().Result;
                            //        var sheetResponse = JsonConvert.DeserializeObject<SheetResponse[]>(responseContent);
                            //        ReportImageGenerator reportImageGenerator = new ReportImageGenerator();
                            //        byte[] imageBytes = reportImageGenerator.GenerateImage(sheetResponse[0]);
                            //        string filePath = Path.Combine(@"C:\Users\arkarl\Documents\Motto\INS_Report_INNO\", "CarBookIn.png");
                            //        System.IO.File.WriteAllBytes(filePath, imageBytes);
                            //    }
                            //}
                            return Json(new { success = true, message = "Inspection Saved Successfully.", refKey = innoSync.ID.ToString(), imapNo = vehicleId }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        Response.StatusCode = 200;
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
                Response.StatusCode = 500;
                return Json(new { success = false, message = "An error occurred while processing the request :" + ex.Message }, JsonRequestBehavior.AllowGet);
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

        public string SyncOnIMAP(int id)
        {
            string vehicleId = "";
            INS_DataFeed objDataFeed = new INS_DataFeed();
            DataTable dt = objDataFeed.GetINNOSyncByID(id);

            if (dt.Rows.Count > 0)
            {
                string schemaType = dt.Rows[0]["SchemaType"]?.ToString();
                string vehicleType = dt.Rows[0]["VehicleType"]?.ToString();
                string apiKey = "0930939f-512f-4399-8d94-1eab8ec06c37"; 
                string apiUrl = "";
                object requestBody = null;

                if (schemaType == "Book In" && vehicleType == "Car")
                {
                    apiUrl = "https://ins.mottoauction.com/INS/BookInCreate";
                    //apiUrl = "https://localhost:44327/INS/BookInCreate";
                    // Map data from DataTable to BookinModel
                    BookinModel bookinModel = MapToBookinCarModel(dt.Rows[0]);
                    requestBody = bookinModel;
                }
                else if (schemaType == "Inspection" && vehicleType == "Car")
                {
                    apiUrl = "https://ins.mottoauction.com/INS/InspectionCreate";
                    //apiUrl = "https://localhost:44327/INS/InspectionCreate";
                    // Map data from DataTable to CarInspection
                    CarInspection inspection = MapToCarInspection(dt.Rows[0]);
                    requestBody = inspection;
                    //vehicleId = inspection.VehicleId;
                }
                else if (schemaType == "Book In" && vehicleType == "MB")
                {
                    apiUrl = "https://ins.mottoauction.com/INS/BookInCreate";
                    //apiUrl = "https://localhost:44327/INS/BookInCreate";
                    // Map data from DataTable to BookinModel
                    BookinModel bookinModel = MapToBookinMBModel(dt.Rows[0]);
                    requestBody = bookinModel;
                }
                else if (schemaType == "Inspection" && vehicleType == "MB")
                {
                    apiUrl = "https://ins.mottoauction.com/INS/InspectionCreate";
                    //apiUrl = "https://localhost:44327/INS/InspectionCreate";
                    // Map data from DataTable to CarInspection
                    CarInspection inspection = MapToMBInspection(dt.Rows[0]);
                    requestBody = inspection;
                    //vehicleId = inspection.VehicleId;
                }
                else if (schemaType == "Book In" && vehicleType == "SVG")
                {
                    apiUrl = "https://ins.mottoauction.com/INS/BookInCreate";
                    //apiUrl = "https://localhost:44327/INS/BookInCreate";
                    // Map data from DataTable to BookinModel
                    BookinModel bookinModel = MapToSVGBookin(dt.Rows[0]);
                    requestBody = bookinModel;
                }
                else if (schemaType == "Inspection" && vehicleType == "SVG")
                {
                    apiUrl = "https://ins.mottoauction.com/INS/InspectionCreate";
                    //apiUrl = "https://localhost:44327/INS/InspectionCreate";
                    // Map data from DataTable to CarInspection
                    CarInspection inspection = MapToSVGInspection(dt.Rows[0]);
                    requestBody = inspection;
                    //vehicleId = inspection.VehicleId;
                }


                if (!string.IsNullOrEmpty(apiUrl) && requestBody != null)
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add("apiKey", apiKey); 

                        var json = JsonConvert.SerializeObject(requestBody);
                        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                        var response = client.PostAsync(apiUrl, content).Result;

                        if (!response.IsSuccessStatusCode)
                        {
                            throw new Exception($"API call failed: {response.StatusCode} - {response.ReasonPhrase}");
                        }
                        else
                        {
                            var responseContent = response.Content.ReadAsStringAsync().Result;

                            var jsonResponse = JsonConvert.DeserializeObject<JObject>(responseContent);
                            if (jsonResponse["vehicleId"] != null)
                            {
                                vehicleId = jsonResponse["vehicleId"].ToString();
                                if(schemaType == "Inspection")
                                {
                                objDataFeed.UpdateInspectionCountINNOSYNC(vehicleId, id);
                                }
                            }
                            else if (jsonResponse["success"]?.Value<bool>() == false)
                            {
                                vehicleId = jsonResponse["message"]?.ToString();  
                                objDataFeed.UpdateErrorINNOSYNC(vehicleId, id);
                            }
                        }
                    }
                }
            }

            return vehicleId;
        }

        private BookinModel MapToBookinCarModel(DataRow row)
        {
            string inspectionJson = row["InspectionData"]?.ToString();
            var inspectionData = JsonConvert.DeserializeObject<CarBookInDataModel>(inspectionJson);

            #region BodyType & FuelType
            INS_DataFeed objDataFeed = new INS_DataFeed();
            string variantId = (inspectionData.Variant == null ? "null" : inspectionData.Variant);

            DataTable dtBodyType = objDataFeed.GetBodyByVarId(variantId == "null" ? 0 : int.Parse(variantId));
            string bodyType = "";
            if (dtBodyType != null && dtBodyType.Rows.Count > 0)
            {
                bodyType = dtBodyType.Rows[0]["BodyType"].ToString();
            }

            DataTable dtFuelType = objDataFeed.GetFuelTypeByVarId(variantId == "null" ? 0 : int.Parse(variantId));
            string fuelType = "";
            if (dtFuelType != null && dtFuelType.Rows.Count > 0)
            {
                fuelType = dtFuelType.Rows[0]["FuelType"].ToString();
            }
            #endregion

            #region Plant
            DataTable dtPlant = objDataFeed.GetPlantByStorageLocation(inspectionData.ReceiveLocation == null ? "" : inspectionData.ReceiveLocation);
            string plant = "";
            if (dtPlant != null && dtPlant.Rows.Count > 0)
            {
                plant = dtPlant.Rows[0]["Plant"].ToString();
            }
            #endregion

            DataTable dtModelTemplate_DESC = objDataFeed.GetModelTemplateForDataEntryByVarId(variantId == "null" ? 0 : int.Parse(variantId));
            DataTable dtModelTemplate = objDataFeed.GetModelTemplateById(variantId == "null" ? 0 : int.Parse(variantId));

            return new BookinModel
            {
                BookInType = new BookinReceiver
                {
                    BookInNumber = "",
                    BookInDate = DateTime.Now,
                    SenderName = row["SenderName"]?.ToString(),
                    ReceiverName = row["ReceiverName"]?.ToString(),
                    ContractNumber = inspectionData.ContractNumber,
                    MobileNumber = row["MobileNumber"]?.ToString(),
                    Status = 0,//what do i need to add status
                    SellerCode = row["SellerCode"]?.ToString(),
                    Inspector = row["Inspector"]?.ToString(),
                    SenderSignature = "",//image no fields in inno
                    ReceiverSignature = "",//image no fields in inno
                    VehicleId = "",
                    LatestUpdatedDate = row.Field<DateTime?>("TxnDate"),
                    BookinType = "",//no field in inno
                    CreateBy = row["CreatedBy"]?.ToString(),
                    CreateDate = row.Field<DateTime?>("CreatedDate"),
                    ModifiedBy = "",
                    ModifiedDate = null,
                    ContractTypeCode = GetContractTypeCode(inspectionData.ContractType == null ? "" : inspectionData.ContractType),//no field in inno
                    StickVin = "",//no field in inno,
                    TenantName= (inspectionData.HirePurchaserName == null ? "" : inspectionData.HirePurchaserName),
                    TimeStartApp = row.Field<DateTime?>("CreatedDate"),
                },
                VehicleType = new Vehicle
                {
                    VID = 0,
                    VehicleId = "", 
                    BookinNumber = "",
                    Seller = row["SellerCode"]?.ToString(),
                    SellingCategory = (inspectionData.SalesCategory == null ? "" : inspectionData.SalesCategory),
                    LogisticsStatus = "",//no field in inno
                    InspectionDate = DateTime.Now,
                    SalesStatus = "",
                    Plant = plant,//(inspectionData.PlantLocation == null ? "" : inspectionData.PlantLocation),
                    StorageLocation = (inspectionData.ReceiveLocation == null ? "" : inspectionData.ReceiveLocation),
                    ReceiverLocation = (inspectionData.ReceiveLocation == null ? "" : inspectionData.ReceiveLocation),
                    BookedDate = DateTime.Now,
                    Make = (inspectionData.Make == null ? "" : inspectionData.Make),
                    Make_BU = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Make_ENG"].ToString() : "",
                    Make_LO = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Make_TH"].ToString() : "",
                    ModelCode = (inspectionData.ModelCode == null ? "" : inspectionData.ModelCode),
                    ModelCodeId = variantId == "null" ? 0 : int.Parse(variantId),
                    Model_BU = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Model_BU"].ToString() : "",
                    Model_LO = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Model_LO"].ToString() : "",
                    Body = bodyType,//(inspectionData.BodyType == null ? "" : inspectionData.BodyType),//not sure
                    BodyDesc_BU = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Body_ENG"].ToString() : "",
                    BodyDesc_LO = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Body_TH"].ToString() : "",
                    Variants = dtModelTemplate.Rows.Count > 0 ? dtModelTemplate.Rows[0]["Variants"].ToString() : "",//not sure
                    BuildYear = (inspectionData.ManufacturingYear == null ? "" : inspectionData.ManufacturingYear),//not sure
                    VIN = row["VIN"]?.ToString(),
                    ChasisNumber = row["ChasisNumber"]?.ToString(),
                    Colour = "",
                    ColourDesc = (inspectionData.Color == null || inspectionData.Color == "null" ? "" : inspectionData.Color),
                    FuelDelivery = dtModelTemplate.Rows.Count > 0 ? dtModelTemplate.Rows[0]["FuelDelivery"].ToString() : "",
                    FuelType = fuelType,//(inspectionData.FuelType == null ? "" : inspectionData.FuelType),
                    Gearbox = dtModelTemplate.Rows.Count > 0 ? dtModelTemplate.Rows[0]["Gearbox"].ToString() : "",//(inspectionData.GearType == null ? "" : inspectionData.GearType),//not sure
                    Gears = dtModelTemplate.Rows.Count > 0 ? dtModelTemplate.Rows[0]["Gears"].ToString() : "",
                    Drive = dtModelTemplate.Rows.Count > 0 ? dtModelTemplate.Rows[0]["Drive"].ToString() : "",//(inspectionData.DriveSystem == null ? "" : inspectionData.DriveSystem),//not sure
                    EngineNumber = (inspectionData.EngineNumber == null ? "" : inspectionData.EngineNumber),
                    EngineCapacity = decimal.TryParse(inspectionData.EngineSize, out var cap) ? cap : (decimal?)null,
                    EngineCapacityUnit = (inspectionData.EngineSizeUnit == null ? "" : inspectionData.EngineSizeUnit),//not sure
                    Regisration = (inspectionData.LicensePlateNumber == null ? "" : inspectionData.LicensePlateNumber),//not sure
                    RegistrationYear = (inspectionData.RegistrationYear == null ? "" : inspectionData.RegistrationYear),//not sure
                    RegistrationProvince = "",//(inspectionData.LicenseProvince == null ? "" : inspectionData.LicenseProvince),//not sure
                    RegistrationPlate = "",//(inspectionData.LicensePlateNumber == null ? "" : inspectionData.LicensePlateNumber),//not sure
                    RegistrationNote = "",//(inspectionData.TypeofLicensePlate == null ? "" : inspectionData.TypeofLicensePlate),//not sure
                    IsRegistrationMismatch = false,//inspectionData.LicenePlateMatchWithCar?.Contains("ไม่ตรง") == true,//not sure
                    RedBookCondition = "",
                    IsGasTank = false,//inspectionData.GasInstall == "ติด",//not sure
                    GasTankNumber = "",
                    GasType = 0,
                    GasNote = "",//(inspectionData.GasInstall == null ? "" : inspectionData.GasInstall),
                    IsInValidEngineNumber = null,
                    ReasonInValidEngineNumber = "",
                    IsInValidVinNumber = null,
                    ReasonInValidVinNumber = "",
                    IsInValidGasNumber = null,
                    ReasonInValidGasNumber = "",
                    VehicleDeleted = null,
                    VehicleDeletedDate = null,
                    CreateUser = row["CreatedBy"]?.ToString(),
                    CreateDate = DateTime.Now,
                    ModifiedUser = "",
                    ModifiedDate = null,
                    IsNohaveBuildYear = false,//inspectionData.ManufacturingYear == null,//not sure
                    IsNohaveRegis = false,//inspectionData.RegistrationYear == "ตรวจสอบไม่ได้",//not sure
                    briefCarConditionId = null,
                    DetallBriefCarCondition = "",//(inspectionData.VehicleRemarks == null ? "" : inspectionData.VehicleRemarks),//not sure
                    MotorNumber = "",//inspectionData.EVMotorNumber ?? inspectionData.EVMotorNumber2,//not sure
                    IsInValidMotorNumber = null,
                    ReasonInValidMotorNumber = "",
                    IsInVaidEngine1 = null,
                    IsInVaidEngine2 = null,
                    IsInVaidEngine3 = null,
                    IsInVaidVin1 = null,
                    IsInVaidVin2 = null,
                    IsInVaidVin3 = null,
                    NoPlateType = (inspectionData.TypeofLicensePlate == null ? "" : inspectionData.TypeofLicensePlate),
                    CataLogIPAD_TH = "",
                    CataLogIPAD_EN = "",
                    CatalyticOption = 0,//inspectionData.CatalyticConverter == "มี" ? 1 : 0,//not sure
                    CabTypeID ="",// (inspectionData.PickupTrayType == null ? "" : inspectionData.PickupTrayType),//not sure
                    LevelCabID = ""
                },
                ExternalType = new External//no fields in inno
                {
                    ExternalId = 0, 
                    GradeOverallId = null,
                    ColorOverallId =  null,
                    IsSpoiler = null,
                    MagWheel = null, 
                    NormalWheel = null,
                    IsTyre = null,
                    TyreQuality = null,
                    DamageDesc = "",
                    BookinNumber = "",
                    TyreBrand = "",
                    RoofTypeId = null
                },
                SpareType = new Spare
                {
                    SpareId = 0,
                    SpareOverAllId = null, 
                    SpareNote = "",
                    IsSpareType = null,
                    IsHandTool = null,
                    IsMaxliner = null,
                    IsRoofRack = null,
                    IsJackCar = null,
                    IsCableChargeEV = null,
                    AccessoriesNote = "",
                    BookinNumber = ""
                },
                CabinType = new Cabin
                {
                    CabinId = 0,
                    CabinOverAllId = 0,
                    Mileage = decimal.TryParse(inspectionData.Mileage, out var mile) ? mile : (decimal?)null,
                    MileageTypeId = null,
                    FuelVolumn = null,
                    GearSystemId = null,
                    IsAirback = null,
                    IsHeadGear = null,
                    IsPowerAmp = null,
                    IsLockGear = null,
                    IsPreAmp = null,
                    IsBookService = null,
                    IsSpeaker = null,
                    IsManual = null,
                    IsCigaretteLiter = null,
                    IsTaxPlate = null,
                    IsPlateExpireDate = "",
                    IsNavigator = null,
                    IsNavigatorBuiltin = null,
                    IsNavigatorCD = null,
                    IsNavigatorSDCard = null,
                    IsNavigatorNoCD = null,
                    IsNavigatorNoSDCard = null,
                    PlayerBrand = "",
                    IsPlayerRadio = null,
                    IsPlayerTape = null,
                    IsPlayerCD = null,
                    IsPlayerUSB = null,
                    KeyOptionId = null,
                    CabinNote = "",
                    BookInNumber = "",
                    IsInvalidMileage = null,
                    InvalidMileageReason = ""
                },
                KeyOptionType = new KeyOption
                {
                    KeyOptionId = 0,
                    NumberOfKey = null,
                    NumberOfRemote = null,
                    NumberOfKeyRemote = null,
                    NumberOfImmobilizer = null,
                    NumberOfKeyless = null,
                    BookinNumber = ""
                },
                EngineType = new Engine
                {
                    EngineId = 0,
                    EngineRoomOverAllId = null,
                    BatteryBrand = "",
                    BatteryIndicatorColor = "",
                    IsEcu = null,
                    IsCompressorAir = null,
                    DriverSystemId = null,
                    FuelSystemId = null,
                    IsFuelGas = null,
                    GasTypeId = null,
                    InsideAssetNote = "",
                    BookinNumber = ""
                }
            };
        }

        private CarInspection MapToCarInspection(DataRow row)
        {
            string inspectionJson = row["InspectionData"]?.ToString();
            var inspectionData = JsonConvert.DeserializeObject<CarInspectionDataModel>(inspectionJson);
            INS_DataFeed objDataFeed = new INS_DataFeed();
            return new CarInspection
            {
                InspectionId = 0,
                BookInNumber = objDataFeed.GetBookInNoByVehicleID(int.Parse(inspectionData.IMATNumber == null ? "0" : inspectionData.IMATNumber).ToString("D18")),
                VehicleId = int.Parse(inspectionData.IMATNumber == null ? "0" : inspectionData.IMATNumber).ToString("D18"),
                Inspector = row["Inspector"]?.ToString(),
                InspectionDate = DateTime.Now,
                InspectorName = row["Sendername"]?.ToString(),// not sure
                Chassis = row["ChasisNumber"]?.ToString(),
                Front = inspectionData.FrontBodyCondition,
                Back = inspectionData.BackBodyCondition,
                RightSide = inspectionData.RightBodyCondition,
                LeftSide = inspectionData.LeftBodyCondition,
                Roof = inspectionData.RoofCondition,
                IsFlood = null,
                BodySummary = inspectionData.StructureAndBodyRemarks,
                IsEngineWorks = null,
                FuelSystemId = null,
                IsLubricatorLow = null,
                EngineSystemId = null,
                GearTypeId = null,
                IsUseableGeneral = null,
                IsSoundAbnormal = null,
                IsLeakFuel = null,
                IsStainWater = null,
                IsMachineLightShow = null,
                IsEngineAbnomal = null,
                IsNeedRepair = null,
                EngineSummary = "",
                DriveShaftConditionId = null,
                DriveShaftConditionNote = "",
                SuspensionConditionId = null,
                SuspensionConditionNote = "",
                SuspensionSummary = "",
                GearSystemId = null,
                GearConditionId = null,
                DriveShaftId = null,
                Is4WD = null,
                GearSystemSummary = "",
                IsUseableSteerWheel = null,
                IsPowerSteering = null,
                SteeringSummary = "",
                IsUseableBrake = null,
                BreakSystemSumary = "",
                IsAirCool = null,
                IsCompressorAir = null,
                AirSystemSummary = "",
                IsUseableGuage = null,
                WarningLightNote = "",
                GaugeSummary = "",
                IsFrontLightWorking = null,
                IsTurnLightWorking = null,
                IsBackLightWorking = null,
                IsBrakeLightWoring = null,
                IsBetteryWorking = null,
                IsHooterWorking = null,
                IsRoundGaugeWorking = null,
                IsNavigator = null,
                IsNavigatorBuiltIn = null,
                IsNavigatorCD = null,
                IsNavigatorSdcard = null,
                IsNavigatorNoCD = null,
                IsNavigatorNoSdcard = null,
                ElectronicNote = "",
                ElectronicSummary = "",
                LatestUpdatedDate = null,
                Regisration = row["RegistrationNumber"]?.ToString(),
                RegistrationProvince = "",
                IsSunroof = null,
                isSideMirror_1_Working = null,
                isSideMirror_2_Working = null,
                isSideMirror_3_Working = null,
                isSideMirror_4_Working = null
            };
        }

        private BookinModel MapToBookinMBModel(DataRow row)
        {
            string inspectionJson = row["InspectionData"]?.ToString();
            var inspectionData = JsonConvert.DeserializeObject<MBBookInDataModel>(inspectionJson);

            #region BodyType & FuelType
            INS_DataFeed objDataFeed = new INS_DataFeed();
            string variantId = (inspectionData.Variant == null ? "null" : inspectionData.Variant);

            DataTable dtBodyType = objDataFeed.GetBodyByVarId(variantId == "null" ? 0 : int.Parse(variantId));
            string bodyType = "";
            if (dtBodyType != null && dtBodyType.Rows.Count > 0)
            {
                bodyType = dtBodyType.Rows[0]["BodyType"].ToString();
            }

            DataTable dtFuelType = objDataFeed.GetFuelTypeByVarId(variantId == "null" ? 0 : int.Parse(variantId));
            string fuelType = "";
            if (dtFuelType != null && dtFuelType.Rows.Count > 0)
            {
                fuelType = dtFuelType.Rows[0]["FuelType"].ToString();
            }
            #endregion

            #region Plant
            DataTable dtPlant = objDataFeed.GetPlantByStorageLocation(inspectionData.ReceiveLocation == null ? "" : inspectionData.ReceiveLocation);
            string plant = "";
            if (dtPlant != null && dtPlant.Rows.Count > 0)
            {
                plant = dtPlant.Rows[0]["Plant"].ToString();
            }
            #endregion

            DataTable dtModelTemplate_DESC = objDataFeed.GetModelTemplateForDataEntryByVarId(variantId == "null" ? 0 : int.Parse(variantId));
            DataTable dtModelTemplate = objDataFeed.GetModelTemplateById(variantId == "null" ? 0 : int.Parse(variantId));

            return new BookinModel
            {
                BookInType = new BookinReceiver
                {
                    BookInNumber = "",
                    BookInDate = DateTime.Now,
                    SenderName = row["SenderName"]?.ToString(),
                    ReceiverName = row["ReceiverName"]?.ToString(),
                    ContractNumber = inspectionData.ContractNumber,
                    MobileNumber = row["MobileNumber"]?.ToString(),
                    Status = 1,//what do i need to add status
                    SellerCode = row["SellerCode"]?.ToString(),
                    Inspector = row["Inspector"]?.ToString(),
                    SenderSignature = "",//image no fields in inno
                    ReceiverSignature = "",//image no fields in inno
                    VehicleId = "",
                    LatestUpdatedDate = row.Field<DateTime?>("TxnDate"),
                    BookinType = "",//no field in inno
                    CreateBy = row["CreatedBy"]?.ToString(),
                    CreateDate = row.Field<DateTime?>("CreatedDate"),
                    ModifiedBy = "",
                    ModifiedDate = null,
                    ContractTypeCode = "",//no field in inno
                    StickVin = ""//no field in inno
                },
                VehicleType = new Vehicle
                {
                    VID = 0,
                    VehicleId = "",
                    BookinNumber = "",
                    Seller = row["SellerCode"]?.ToString(),
                    SellingCategory = (inspectionData.SalesCategory == null ? "" : inspectionData.SalesCategory),
                    LogisticsStatus = "",//no field in inno
                    InspectionDate = DateTime.Now,
                    SalesStatus = "",
                    Plant = plant,//(inspectionData.PlantLocation == null ? "" : inspectionData.PlantLocation),
                    StorageLocation = (inspectionData.ReceiveLocation == null ? "" : inspectionData.ReceiveLocation),
                    ReceiverLocation = (inspectionData.ReceiveLocation == null ? "" : inspectionData.ReceiveLocation),
                    BookedDate = DateTime.Now,
                    Make = (inspectionData.Make == null ? "" : inspectionData.Make),
                    Make_BU = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Make_ENG"].ToString() : "",
                    Make_LO = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Make_TH"].ToString() : "",
                    ModelCode = (inspectionData.ModelCode == null ? "" : inspectionData.ModelCode),
                    ModelCodeId = variantId == "null" ? 0 : int.Parse(variantId),
                    Model_BU = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Model_BU"].ToString() : "",
                    Model_LO = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Model_LO"].ToString() : "",
                    Body = bodyType,//(inspectionData.BodyType == null ? "" : inspectionData.BodyType),//not sure
                    BodyDesc_BU = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Body_ENG"].ToString() : "",
                    BodyDesc_LO = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Body_TH"].ToString() : "",
                    Variants = dtModelTemplate.Rows.Count > 0 ? dtModelTemplate.Rows[0]["Variants"].ToString() : "",//not sure
                    BuildYear = (inspectionData.ManufacturingYear == null ? "" : inspectionData.ManufacturingYear.ToString()),//not sure
                    VIN = row["VIN"]?.ToString(),
                    ChasisNumber = row["ChasisNumber"]?.ToString(),
                    Colour = "",
                    ColourDesc = (inspectionData.Color == null || inspectionData.Color == "null" ? "" : inspectionData.Color),
                    FuelDelivery = dtModelTemplate.Rows.Count > 0 ? dtModelTemplate.Rows[0]["FuelDelivery"].ToString() : "",
                    FuelType = fuelType,//(inspectionData.FuelType == null ? "" : inspectionData.FuelType),
                    Gearbox = dtModelTemplate.Rows.Count > 0 ? dtModelTemplate.Rows[0]["Gearbox"].ToString() : "",//(inspectionData.GearType == null ? "" : inspectionData.GearType),//not sure
                    Gears = dtModelTemplate.Rows.Count > 0 ? dtModelTemplate.Rows[0]["Gears"].ToString() : "",
                    Drive = dtModelTemplate.Rows.Count > 0 ? dtModelTemplate.Rows[0]["Drive"].ToString() : "",//(inspectionData.DriveSystem == null ? "" : inspectionData.DriveSystem),//not sure
                    EngineNumber = (inspectionData.EngineNumber == null ? "" : inspectionData.EngineNumber),
                    EngineCapacity = decimal.TryParse(inspectionData.EngineSize, out var cap) ? cap : (decimal?)null,
                    EngineCapacityUnit = (inspectionData.EngineSizeUnit == null ? "" : inspectionData.EngineSizeUnit),//not sure
                    Regisration = (inspectionData.RegistrationNumber == null ? "" : inspectionData.RegistrationNumber),//not sure
                    RegistrationYear = (inspectionData.RegistrationYear == null ? "" : inspectionData.RegistrationYear),//not sure
                    RegistrationProvince = "",//(inspectionData.LicenseProvince == null ? "" : inspectionData.LicenseProvince),//not sure
                    RegistrationPlate = "",//(inspectionData.LicensePlateNumber == null ? "" : inspectionData.LicensePlateNumber),//not sure
                    RegistrationNote = "",//(inspectionData.TypeofLicensePlate == null ? "" : inspectionData.TypeofLicensePlate),//not sure
                    IsRegistrationMismatch = false,//inspectionData.LicenePlateMatchWithCar?.Contains("ไม่ตรง") == true,//not sure
                    RedBookCondition = "",
                    IsGasTank = false,//inspectionData.GasInstall == "ติด",//not sure
                    GasTankNumber = "",
                    GasType = 0,
                    GasNote = "",//(inspectionData.GasInstall == null ? "" : inspectionData.GasInstall),
                    IsInValidEngineNumber = null,
                    ReasonInValidEngineNumber = "",
                    IsInValidVinNumber = null,
                    ReasonInValidVinNumber = "",
                    IsInValidGasNumber = null,
                    ReasonInValidGasNumber = "",
                    VehicleDeleted = null,
                    VehicleDeletedDate = null,
                    CreateUser = row["CreatedBy"]?.ToString(),
                    CreateDate = DateTime.Now,
                    ModifiedUser = "",
                    ModifiedDate = null,
                    IsNohaveBuildYear = false,//inspectionData.ManufacturingYear == null,//not sure
                    IsNohaveRegis = false,//inspectionData.RegistrationYear == "ตรวจสอบไม่ได้",//not sure
                    briefCarConditionId = null,
                    DetallBriefCarCondition = "",//(inspectionData.VehicleRemarks == null ? "" : inspectionData.VehicleRemarks),//not sure
                    MotorNumber = "",//inspectionData.EVMotorNumber ?? inspectionData.EVMotorNumber2,//not sure
                    IsInValidMotorNumber = null,
                    ReasonInValidMotorNumber = "",
                    IsInVaidEngine1 = null,
                    IsInVaidEngine2 = null,
                    IsInVaidEngine3 = null,
                    IsInVaidVin1 = null,
                    IsInVaidVin2 = null,
                    IsInVaidVin3 = null,
                    NoPlateType = (inspectionData.TypeofLicensePlate == null ? "" : inspectionData.TypeofLicensePlate),
                    CataLogIPAD_TH = "",
                    CataLogIPAD_EN = "",
                    CatalyticOption = 0,//inspectionData.CatalyticConverter == "มี" ? 1 : 0,//not sure
                    CabTypeID = "",// (inspectionData.PickupTrayType == null ? "" : inspectionData.PickupTrayType),//not sure
                    LevelCabID = ""
                },
                ExternalType = new External//no fields in inno
                {
                    ExternalId = 0,
                    GradeOverallId = null,
                    ColorOverallId = null,
                    IsSpoiler = null,
                    MagWheel = null,
                    NormalWheel = null,
                    IsTyre = null,
                    TyreQuality = null,
                    DamageDesc = "",
                    BookinNumber = "",
                    TyreBrand = "",
                    RoofTypeId = null
                },
                SpareType = new Spare
                {
                    SpareId = 0,
                    SpareOverAllId = null,
                    SpareNote = "",
                    IsSpareType = null,
                    IsHandTool = null,
                    IsMaxliner = null,
                    IsRoofRack = null,
                    IsJackCar = null,
                    IsCableChargeEV = null,
                    AccessoriesNote = "",
                    BookinNumber = ""
                },
                CabinType = new Cabin
                {
                    CabinId = 0,
                    CabinOverAllId = 0,
                    Mileage = decimal.TryParse(inspectionData.Mileage, out var mile) ? mile : (decimal?)null,
                    MileageTypeId = null,
                    FuelVolumn = null,
                    GearSystemId = null,
                    IsAirback = null,
                    IsHeadGear = null,
                    IsPowerAmp = null,
                    IsLockGear = null,
                    IsPreAmp = null,
                    IsBookService = null,
                    IsSpeaker = null,
                    IsManual = null,
                    IsCigaretteLiter = null,
                    IsTaxPlate = null,
                    IsPlateExpireDate = "",
                    IsNavigator = null,
                    IsNavigatorBuiltin = null,
                    IsNavigatorCD = null,
                    IsNavigatorSDCard = null,
                    IsNavigatorNoCD = null,
                    IsNavigatorNoSDCard = null,
                    PlayerBrand = "",
                    IsPlayerRadio = null,
                    IsPlayerTape = null,
                    IsPlayerCD = null,
                    IsPlayerUSB = null,
                    KeyOptionId = null,
                    CabinNote = "",
                    BookInNumber = "",
                    IsInvalidMileage = null,
                    InvalidMileageReason = ""
                },
                KeyOptionType = new KeyOption
                {
                    KeyOptionId = 0,
                    NumberOfKey = null,
                    NumberOfRemote = null,
                    NumberOfKeyRemote = null,
                    NumberOfImmobilizer = null,
                    NumberOfKeyless = null,
                    BookinNumber = ""
                },
                EngineType = new Engine
                {
                    EngineId = 0,
                    EngineRoomOverAllId = null,
                    BatteryBrand = "",
                    BatteryIndicatorColor = "",
                    IsEcu = null,
                    IsCompressorAir = null,
                    DriverSystemId = null,
                    FuelSystemId = null,
                    IsFuelGas = null,
                    GasTypeId = null,
                    InsideAssetNote = "",
                    BookinNumber = ""
                }
            };
        }

        private CarInspection MapToMBInspection(DataRow row)
        {
            string inspectionJson = row["InspectionData"]?.ToString();
            var inspectionData = JsonConvert.DeserializeObject<MBInspectionDataModel>(inspectionJson);
            INS_DataFeed objDataFeed = new INS_DataFeed();
            return new CarInspection
            {
                InspectionId = 0,
                BookInNumber = objDataFeed.GetBookInNoByVehicleID(int.Parse(inspectionData.IMATNumber == null ? "0" : inspectionData.IMATNumber).ToString("D18")),
                VehicleId = int.Parse(inspectionData.IMATNumber == null ? "0" : inspectionData.IMATNumber).ToString("D18"),
                Inspector = row["Inspector"]?.ToString(),
                InspectionDate = DateTime.Now,
                InspectorName = row["Sendername"]?.ToString(),// not sure
                Chassis = row["ChasisNumber"]?.ToString(),
                Front = "",
                Back = "",
                RightSide = "",
                LeftSide = "",
                Roof = "",
                IsFlood = null,
                BodySummary = "",
                IsEngineWorks = null,
                FuelSystemId = null,
                IsLubricatorLow = null,
                EngineSystemId = null,
                GearTypeId = null,
                IsUseableGeneral = null,
                IsSoundAbnormal = null,
                IsLeakFuel = null,
                IsStainWater = null,
                IsMachineLightShow = null,
                IsEngineAbnomal = null,
                IsNeedRepair = null,
                EngineSummary = "",
                DriveShaftConditionId = null,
                DriveShaftConditionNote = "",
                SuspensionConditionId = null,
                SuspensionConditionNote = "",
                SuspensionSummary = "",
                GearSystemId = null,
                GearConditionId = null,
                DriveShaftId = null,
                Is4WD = null,
                GearSystemSummary = "",
                IsUseableSteerWheel = null,
                IsPowerSteering = null,
                SteeringSummary = "",
                IsUseableBrake = null,
                BreakSystemSumary = "",
                IsAirCool = null,
                IsCompressorAir = null,
                AirSystemSummary = "",
                IsUseableGuage = null,
                WarningLightNote = "",
                GaugeSummary = "",
                IsFrontLightWorking = null,
                IsTurnLightWorking = null,
                IsBackLightWorking = null,
                IsBrakeLightWoring = null,
                IsBetteryWorking = null,
                IsHooterWorking = null,
                IsRoundGaugeWorking = null,
                IsNavigator = null,
                IsNavigatorBuiltIn = null,
                IsNavigatorCD = null,
                IsNavigatorSdcard = null,
                IsNavigatorNoCD = null,
                IsNavigatorNoSdcard = null,
                ElectronicNote = "",
                ElectronicSummary = "",
                LatestUpdatedDate = null,
                Regisration = "",//row["LicensePlateNumber"]?.ToString(),
                RegistrationProvince = "",
                IsSunroof = null,
                isSideMirror_1_Working = null,
                isSideMirror_2_Working = null,
                isSideMirror_3_Working = null,
                isSideMirror_4_Working = null
            };
        }

        private BookinModel MapToSVGBookin(DataRow row)
        {
            string inspectionJson = row["InspectionData"]?.ToString();
            var inspectionData = JsonConvert.DeserializeObject<BookInDataModel>(inspectionJson);

            #region BodyType & FuelType
            INS_DataFeed objDataFeed = new INS_DataFeed();
            string variantId = (inspectionData.Variant == null ? "null" : inspectionData.Variant);

            DataTable dtBodyType = objDataFeed.GetBodyByVarId(variantId == "null" ? 0 : int.Parse(variantId));
            string bodyType = "";
            if (dtBodyType != null && dtBodyType.Rows.Count > 0)
            {
                bodyType = dtBodyType.Rows[0]["BodyType"].ToString();
            }

            DataTable dtFuelType = objDataFeed.GetFuelTypeByVarId(variantId == "null" ? 0 : int.Parse(variantId));
            string fuelType = "";
            if (dtFuelType != null && dtFuelType.Rows.Count > 0)
            {
                fuelType = dtFuelType.Rows[0]["FuelType"].ToString();
            }
            #endregion

            #region Plant
            DataTable dtPlant = objDataFeed.GetPlantByStorageLocation(inspectionData.ReceiveLocation == null ? "" : inspectionData.ReceiveLocation);
            string plant = "";
            if (dtPlant != null && dtPlant.Rows.Count > 0)
            {
                plant = dtPlant.Rows[0]["Plant"].ToString();
            }
            #endregion

            DataTable dtModelTemplate_DESC = objDataFeed.GetModelTemplateForDataEntryByVarId(variantId == "null" ? 0 : int.Parse(variantId));
            DataTable dtModelTemplate = objDataFeed.GetModelTemplateById(variantId == "null" ? 0 : int.Parse(variantId));

            return new BookinModel
            {
                BookInType = new BookinReceiver
                {
                    BookInNumber = "",
                    BookInDate = DateTime.Now,
                    SenderName = row["SenderName"]?.ToString(),
                    ReceiverName = row["ReceiverName"]?.ToString(),
                    ContractNumber = inspectionData.ContractNumber,
                    MobileNumber = row["MobileNumber"]?.ToString(),
                    Status = 0,//what do i need to add status
                    SellerCode = row["SellerCode"]?.ToString(),
                    Inspector = row["Inspector"]?.ToString(),
                    SenderSignature = "",//image no fields in inno
                    ReceiverSignature = "",//image no fields in inno
                    VehicleId = "",
                    LatestUpdatedDate = row.Field<DateTime?>("TxnDate"),
                    BookinType = "",//no field in inno
                    CreateBy = row["CreatedBy"]?.ToString(),
                    CreateDate = row.Field<DateTime?>("CreatedDate"),
                    ModifiedBy = "",
                    ModifiedDate = null,
                    ContractTypeCode = GetContractTypeCode(inspectionData.ContractType == null ? "" : inspectionData.ContractType),//no field in inno
                    StickVin = ""//no field in inno
                },
                VehicleType = new Vehicle
                {
                    VID = 0,
                    VehicleId = "",
                    BookinNumber = "",
                    Seller = row["SellerCode"]?.ToString(),
                    SellingCategory = (inspectionData.SalesCategory == null ? "" : inspectionData.SalesCategory),
                    LogisticsStatus = "",//no field in inno
                    InspectionDate = DateTime.Now,
                    SalesStatus = "",
                    Plant = plant,//(inspectionData.PlantLocation == null ? "" : inspectionData.PlantLocation),
                    StorageLocation = (inspectionData.ReceiveLocation == null ? "" : inspectionData.ReceiveLocation),
                    ReceiverLocation = (inspectionData.ReceiveLocation == null ? "" : inspectionData.ReceiveLocation),
                    BookedDate = DateTime.Now,
                    Make = (inspectionData.Make == null ? "" : inspectionData.Make),
                    Make_BU = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Make_ENG"].ToString() : "",
                    Make_LO = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Make_TH"].ToString() : "",
                    ModelCode = (inspectionData.ModelCode == null ? "" : inspectionData.ModelCode),
                    ModelCodeId = variantId == "null" ? 0 : int.Parse(variantId),
                    Model_BU = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Model_BU"].ToString() : "",
                    Model_LO = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Model_LO"].ToString() : "",
                    Body = bodyType,//(inspectionData.BodyType == null ? "" : inspectionData.BodyType),//not sure
                    BodyDesc_BU = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Body_ENG"].ToString() : "",
                    BodyDesc_LO = dtModelTemplate_DESC.Rows.Count > 0 ? dtModelTemplate_DESC.Rows[0]["Body_TH"].ToString() : "",
                    Variants = dtModelTemplate.Rows.Count > 0 ? dtModelTemplate.Rows[0]["Variants"].ToString() : "",//not sure
                    BuildYear = (inspectionData.ManufacturingYear == null ? "" : inspectionData.ManufacturingYear.ToString()),//not sure
                    VIN = row["VIN"]?.ToString(),
                    ChasisNumber = row["ChasisNumber"]?.ToString(),
                    Colour = "",
                    ColourDesc = (inspectionData.Color == null || inspectionData.Color == "null" ? "" : inspectionData.Color),
                    FuelDelivery = dtModelTemplate.Rows.Count > 0 ? dtModelTemplate.Rows[0]["FuelDelivery"].ToString() : "",
                    FuelType = fuelType,//(inspectionData.FuelType == null ? "" : inspectionData.FuelType),
                    Gearbox = dtModelTemplate.Rows.Count > 0 ? dtModelTemplate.Rows[0]["Gearbox"].ToString() : "",//(inspectionData.GearType == null ? "" : inspectionData.GearType),//not sure
                    Gears = dtModelTemplate.Rows.Count > 0 ? dtModelTemplate.Rows[0]["Gears"].ToString() : "",
                    Drive = dtModelTemplate.Rows.Count > 0 ? dtModelTemplate.Rows[0]["Drive"].ToString() : "",//(inspectionData.DriveSystem == null ? "" : inspectionData.DriveSystem),//not sure
                    EngineNumber = (inspectionData.EngineNumber == null ? "" : inspectionData.EngineNumber),
                    EngineCapacity = decimal.TryParse(inspectionData.EngineSize, out var cap) ? cap : (decimal?)null,
                    EngineCapacityUnit = (inspectionData.EngineSizeUnit == null ? "" : inspectionData.EngineSizeUnit),//not sure
                    Regisration = (inspectionData.LicensePlateNumber == null ? "" : inspectionData.LicensePlateNumber),//not sure
                    RegistrationYear = (inspectionData.RegistrationYear == null ? "" : inspectionData.RegistrationYear),//not sure
                    RegistrationProvince = "",//(inspectionData.LicenseProvince == null ? "" : inspectionData.LicenseProvince),//not sure
                    RegistrationPlate = "",//(inspectionData.LicensePlateNumber == null ? "" : inspectionData.LicensePlateNumber),//not sure
                    RegistrationNote = "",//(inspectionData.TypeofLicensePlate == null ? "" : inspectionData.TypeofLicensePlate),//not sure
                    IsRegistrationMismatch = false,//inspectionData.LicenePlateMatchWithCar?.Contains("ไม่ตรง") == true,//not sure
                    RedBookCondition = "",
                    IsGasTank = false,//inspectionData.GasInstall == "ติด",//not sure
                    GasTankNumber = "",
                    GasType = 0,
                    GasNote = "",//(inspectionData.GasInstall == null ? "" : inspectionData.GasInstall),
                    IsInValidEngineNumber = null,
                    ReasonInValidEngineNumber = "",
                    IsInValidVinNumber = null,
                    ReasonInValidVinNumber = "",
                    IsInValidGasNumber = null,
                    ReasonInValidGasNumber = "",
                    VehicleDeleted = null,
                    VehicleDeletedDate = null,
                    CreateUser = row["CreatedBy"]?.ToString(),
                    CreateDate = DateTime.Now,
                    ModifiedUser = "",
                    ModifiedDate = null,
                    IsNohaveBuildYear = false,//inspectionData.ManufacturingYear == null,//not sure
                    IsNohaveRegis = false,//inspectionData.RegistrationYear == "ตรวจสอบไม่ได้",//not sure
                    briefCarConditionId = null,
                    DetallBriefCarCondition = "",//(inspectionData.VehicleRemarks == null ? "" : inspectionData.VehicleRemarks),//not sure
                    MotorNumber = "",//inspectionData.EVMotorNumber ?? inspectionData.EVMotorNumber2,//not sure
                    IsInValidMotorNumber = null,
                    ReasonInValidMotorNumber = "",
                    IsInVaidEngine1 = null,
                    IsInVaidEngine2 = null,
                    IsInVaidEngine3 = null,
                    IsInVaidVin1 = null,
                    IsInVaidVin2 = null,
                    IsInVaidVin3 = null,
                    NoPlateType = (inspectionData.TypeofLicensePlate == null ? "" : inspectionData.TypeofLicensePlate),
                    CataLogIPAD_TH = "",
                    CataLogIPAD_EN = "",
                    CatalyticOption = 0,//inspectionData.CatalyticConverter == "มี" ? 1 : 0,//not sure
                    CabTypeID = "",// (inspectionData.PickupTrayType == null ? "" : inspectionData.PickupTrayType),//not sure
                    LevelCabID = ""
                },
                ExternalType = new External//no fields in inno
                {
                    ExternalId = 0,
                    GradeOverallId = null,
                    ColorOverallId = null,
                    IsSpoiler = null,
                    MagWheel = null,
                    NormalWheel = null,
                    IsTyre = null,
                    TyreQuality = null,
                    DamageDesc = "",
                    BookinNumber = "",
                    TyreBrand = "",
                    RoofTypeId = null
                },
                SpareType = new Spare
                {
                    SpareId = 0,
                    SpareOverAllId = null,
                    SpareNote = "",
                    IsSpareType = null,
                    IsHandTool = null,
                    IsMaxliner = null,
                    IsRoofRack = null,
                    IsJackCar = null,
                    IsCableChargeEV = null,
                    AccessoriesNote = "",
                    BookinNumber = ""
                },
                CabinType = new Cabin
                {
                    CabinId = 0,
                    CabinOverAllId = 0,
                    Mileage = decimal.TryParse(inspectionData.Mileage, out var mile) ? mile : (decimal?)null,
                    MileageTypeId = null,
                    FuelVolumn = null,
                    GearSystemId = null,
                    IsAirback = null,
                    IsHeadGear = null,
                    IsPowerAmp = null,
                    IsLockGear = null,
                    IsPreAmp = null,
                    IsBookService = null,
                    IsSpeaker = null,
                    IsManual = null,
                    IsCigaretteLiter = null,
                    IsTaxPlate = null,
                    IsPlateExpireDate = "",
                    IsNavigator = null,
                    IsNavigatorBuiltin = null,
                    IsNavigatorCD = null,
                    IsNavigatorSDCard = null,
                    IsNavigatorNoCD = null,
                    IsNavigatorNoSDCard = null,
                    PlayerBrand = "",
                    IsPlayerRadio = null,
                    IsPlayerTape = null,
                    IsPlayerCD = null,
                    IsPlayerUSB = null,
                    KeyOptionId = null,
                    CabinNote = "",
                    BookInNumber = "",
                    IsInvalidMileage = null,
                    InvalidMileageReason = ""
                },
                KeyOptionType = new KeyOption
                {
                    KeyOptionId = 0,
                    NumberOfKey = null,
                    NumberOfRemote = null,
                    NumberOfKeyRemote = null,
                    NumberOfImmobilizer = null,
                    NumberOfKeyless = null,
                    BookinNumber = ""
                },
                EngineType = new Engine
                {
                    EngineId = 0,
                    EngineRoomOverAllId = null,
                    BatteryBrand = "",
                    BatteryIndicatorColor = "",
                    IsEcu = null,
                    IsCompressorAir = null,
                    DriverSystemId = null,
                    FuelSystemId = null,
                    IsFuelGas = null,
                    GasTypeId = null,
                    InsideAssetNote = "",
                    BookinNumber = ""
                }
            };
        }

        private CarInspection MapToSVGInspection(DataRow row)
        {
            string inspectionJson = row["InspectionData"]?.ToString();
            var inspectionData = JsonConvert.DeserializeObject<InspectionDataModel>(inspectionJson);
            INS_DataFeed objDataFeed = new INS_DataFeed();
            return new CarInspection
            {
                InspectionId = 0,
                BookInNumber = objDataFeed.GetBookInNoByVehicleID(int.Parse(inspectionData.IMATNumber == null ? "0" : inspectionData.IMATNumber).ToString("D18")),
                VehicleId = int.Parse(inspectionData.IMATNumber == null ? "0" : inspectionData.IMATNumber).ToString("D18"),
                Inspector = row["Inspector"]?.ToString(),
                InspectionDate = DateTime.Now,
                InspectorName = row["Sendername"]?.ToString(),// not sure
                Chassis = row["ChasisNumber"]?.ToString(),
                Front = inspectionData.FrontBodyCondition,
                Back = inspectionData.BackBodyCondition,
                RightSide = inspectionData.RightBodyCondition,
                LeftSide = inspectionData.BodyLCondition,
                Roof = inspectionData.RoofCondition,
                IsFlood = null,
                BodySummary = inspectionData.StructureAndBodyRemarks,
                IsEngineWorks = null,
                FuelSystemId = null,
                IsLubricatorLow = null,
                EngineSystemId = null,
                GearTypeId = null,
                IsUseableGeneral = null,
                IsSoundAbnormal = null,
                IsLeakFuel = null,
                IsStainWater = null,
                IsMachineLightShow = null,
                IsEngineAbnomal = null,
                IsNeedRepair = null,
                EngineSummary = "",
                DriveShaftConditionId = null,
                DriveShaftConditionNote = "",
                SuspensionConditionId = null,
                SuspensionConditionNote = "",
                SuspensionSummary = "",
                GearSystemId = null,
                GearConditionId = null,
                DriveShaftId = null,
                Is4WD = null,
                GearSystemSummary = "",
                IsUseableSteerWheel = null,
                IsPowerSteering = null,
                SteeringSummary = "",
                IsUseableBrake = null,
                BreakSystemSumary = "",
                IsAirCool = null,
                IsCompressorAir = null,
                AirSystemSummary = "",
                IsUseableGuage = null,
                WarningLightNote = "",
                GaugeSummary = "",
                IsFrontLightWorking = null,
                IsTurnLightWorking = null,
                IsBackLightWorking = null,
                IsBrakeLightWoring = null,
                IsBetteryWorking = null,
                IsHooterWorking = null,
                IsRoundGaugeWorking = null,
                IsNavigator = null,
                IsNavigatorBuiltIn = null,
                IsNavigatorCD = null,
                IsNavigatorSdcard = null,
                IsNavigatorNoCD = null,
                IsNavigatorNoSdcard = null,
                ElectronicNote = "",
                ElectronicSummary = "",
                LatestUpdatedDate = null,
                Regisration = row["RegistrationNumber"]?.ToString(),
                RegistrationProvince = "",
                IsSunroof = null,
                isSideMirror_1_Working = null,
                isSideMirror_2_Working = null,
                isSideMirror_3_Working = null,
                isSideMirror_4_Working = null
            };
        }

        #region GetContractTypeCode
        public string GetContractTypeCode(string contractType)
        {
            if (contractType == "อื่นๆ เช่น รถเช่า รถฟลีท")
                return "OT";
            else if (contractType == "รถยึด")
                return "RE";
            else if (contractType == "รถคืน")
                return "VO";
            else return "OT";
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
    }
}