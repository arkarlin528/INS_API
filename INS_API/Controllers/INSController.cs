using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Data;
using INS_API_DataFeed;
using INS_API_DataFeed.DAO;
using Newtonsoft.Json.Linq;
using NLog;
using NLog.Fluent;
using WebGrease;
using Elasticsearch.Net;
using Nest;
using INS_API.Handler;

namespace INS_API.Controllers
{
    public class INSController : Controller
    {
        private Logger logger = NLog.LogManager.GetLogger("DbLogger");
        private Logger flLog = NLog.LogManager.GetLogger("FileLogger");
        private string SourceFolder { get; } = @"\\demoshared\images";

        // GET: INS
        public ActionResult Index()
        {
            return View();
        }

        #region GetBody
        [HttpGet]
        public ActionResult GetBody()
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
                DataTable dt = objDataFeed.GetBody();

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

        #region GetContractType
        [HttpGet]
        public ActionResult GetContractType()
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
                DataTable dt = objDataFeed.GetContractType();

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

        #region GetSellingCategory
        [HttpGet]
        public ActionResult GetSellingCategory()
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
                DataTable dt = objDataFeed.GetSellingCategory();

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

        #region GetDrive
        [HttpGet]
        public ActionResult GetDrive()
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
                DataTable dt = objDataFeed.GetDrive();

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

        #region GetFuelDelivery
        [HttpGet]
        public ActionResult GetFuelDelivery()
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
                DataTable dt = objDataFeed.GetFuelDelivery();

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

        #region GetFuelType
        [HttpGet]
        public ActionResult GetFuelType()
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
                DataTable dt = objDataFeed.GetFuelType();

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

        #region GetMake
        [HttpGet]
        public ActionResult GetMake()
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
                DataTable dt = objDataFeed.GetMake();

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

        #region GetMatVariant
        [HttpGet]
        public ActionResult GetMatVariant()
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
                DataTable dt = objDataFeed.GetMatVariant();

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

        #region GetMatVariantByModel
        [HttpGet]
        public ActionResult GetMatVariantByModel(string model)
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
                DataTable dt = objDataFeed.GetMatVariantByModel(model);

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

        #region SaveRiceHarvesterInspection
        [HttpPost]
        public ActionResult SaveRiceHarvesterInspection()
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }

            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            try
            {
                var jsonData = JsonConvert.DeserializeObject<RiceHarvesterData>(formData);

                //if (jsonData == null || IsRiceHarvesterPropertiesNullOrEmpty(jsonData))
                //{
                //    Response.StatusCode = 400;
                //    return Json(new { success = false, message = "Invalid parameters: data is missing or empty." }, JsonRequestBehavior.AllowGet);
                //}

                INS_DataFeed objDataFeed = new INS_DataFeed();
                string errorMessage = objDataFeed.SaveRiceHarvester(jsonData);

                if (errorMessage == "")
                {
                    return Json(new { success = true, message = " Inspection Saved Successfully." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Response.StatusCode = 409;
                    return Json(new { success = false, message = errorMessage }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (JsonException)
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

        private bool IsRiceHarvesterPropertiesNullOrEmpty(RiceHarvesterData data)
        {
            foreach (var property in typeof(RiceHarvesterData).GetProperties())
            {
                var value = property.GetValue(data);

                if (value != null)
                {
                    if (value is string strValue && !string.IsNullOrWhiteSpace(strValue))
                        return false;
                    else if (value is Array arrayValue && arrayValue.Length > 0)
                        return false; 
                }
            }
            return true; 
        }
        #endregion

        #region SaveExcavatorInspection
        [HttpPost]
        public ActionResult SaveExcavatorInspection()
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }

            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            try
            {
                var jsonData = JsonConvert.DeserializeObject<ExcavatorData>(formData);

                //if (jsonData == null || IsExcavatorPropertiesNullOrEmpty(jsonData))
                //{
                //    Response.StatusCode = 400;
                //    return Json(new { success = false, message = "Invalid parameters: data is missing or empty." }, JsonRequestBehavior.AllowGet);
                //}

                INS_DataFeed objDataFeed = new INS_DataFeed();
                string errorMessage = objDataFeed.SaveExcavator(jsonData);

                if (errorMessage == "")
                {
                    return Json(new { success = true, message = " Inspection Saved Successfully." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Response.StatusCode = 409;
                    return Json(new { success = false, message = errorMessage }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (JsonException)
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

        private bool IsExcavatorPropertiesNullOrEmpty(ExcavatorData data)
        {
            foreach (var property in typeof(ExcavatorData).GetProperties())
            {
                var value = property.GetValue(data);

                if (value != null)
                {
                    if (value is string strValue && !string.IsNullOrWhiteSpace(strValue))
                        return false;
                    else if (value is Array arrayValue && arrayValue.Length > 0)
                        return false;
                }
            }
            return true;
        }
        #endregion

        #region SaveRicePlantingVehicleInspection
        [HttpPost]
        public ActionResult SaveRicePlantingVehicleInspection()
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }

            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            try
            {
                var jsonData = JsonConvert.DeserializeObject<RicePlantingVehicleData>(formData);

                //if (jsonData == null || IsRicePlantingVehiclePropertiesNullOrEmpty(jsonData))
                //{
                //    Response.StatusCode = 400;
                //    return Json(new { success = false, message = "Invalid parameters: data is missing or empty." }, JsonRequestBehavior.AllowGet);
                //}

                INS_DataFeed objDataFeed = new INS_DataFeed();
                string errorMessage = objDataFeed.SaveRicePlantingVehicle(jsonData);

                if (errorMessage == "")
                {
                    return Json(new { success = true, message = " Inspection Saved Successfully." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Response.StatusCode = 409;
                    return Json(new { success = false, message = errorMessage }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (JsonException)
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

        private bool IsRicePlantingVehiclePropertiesNullOrEmpty(RicePlantingVehicleData data)
        {
            foreach (var property in typeof(RicePlantingVehicleData).GetProperties())
            {
                var value = property.GetValue(data);

                if (value != null)
                {
                    if (value is string strValue && !string.IsNullOrWhiteSpace(strValue))
                        return false;
                    else if (value is Array arrayValue && arrayValue.Length > 0)
                        return false;
                }
            }
            return true;
        }
        #endregion

        #region SaveStrawBalerInspection
        [HttpPost]
        public ActionResult SaveStrawBalerInspection()
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }

            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            try
            {
                var jsonData = JsonConvert.DeserializeObject<StrawBalerData>(formData);

                //if (jsonData == null || IsStrawBalerPropertiesNullOrEmpty(jsonData))
                //{
                //    Response.StatusCode = 400;
                //    return Json(new { success = false, message = "Invalid parameters: data is missing or empty." }, JsonRequestBehavior.AllowGet);
                //}

                INS_DataFeed objDataFeed = new INS_DataFeed();
                string errorMessage = objDataFeed.SaveStrawBaler(jsonData);

                if (errorMessage == "")
                {
                    return Json(new { success = true, message = " Inspection Saved Successfully." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Response.StatusCode = 409;
                    return Json(new { success = false, message = errorMessage }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (JsonException)
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

        private bool IsStrawBalerPropertiesNullOrEmpty(StrawBalerData data)
        {
            foreach (var property in typeof(StrawBalerData).GetProperties())
            {
                var value = property.GetValue(data);

                if (value != null)
                {
                    if (value is string strValue && !string.IsNullOrWhiteSpace(strValue))
                        return false;
                    else if (value is Array arrayValue && arrayValue.Length > 0)
                        return false;
                }
            }
            return true;
        }
        #endregion

        #region SaveDieselEngineInspection
        [HttpPost]
        public ActionResult SaveDieselEngineInspection()
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }

            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            try
            {
                var jsonData = JsonConvert.DeserializeObject<DieselEngineData>(formData);

                //if (jsonData == null || IsDieselEnginePropertiesNullOrEmpty(jsonData))
                //{
                //    Response.StatusCode = 400;
                //    return Json(new { success = false, message = "Invalid parameters: data is missing or empty." }, JsonRequestBehavior.AllowGet);
                //}

                INS_DataFeed objDataFeed = new INS_DataFeed();
                string errorMessage = objDataFeed.SaveDieselEngine(jsonData);

                if (errorMessage == "")
                {
                    return Json(new { success = true, message = " Inspection Saved Successfully." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Response.StatusCode = 409;
                    return Json(new { success = false, message = errorMessage }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (JsonException)
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

        private bool IsDieselEnginePropertiesNullOrEmpty(DieselEngineData data)
        {
            foreach (var property in typeof(DieselEngineData).GetProperties())
            {
                var value = property.GetValue(data);

                if (value != null)
                {
                    if (value is string strValue && !string.IsNullOrWhiteSpace(strValue))
                        return false;
                    else if (value is Array arrayValue && arrayValue.Length > 0)
                        return false;
                }
            }
            return true;
        }
        #endregion

        #region SaveDroneInspection
        [HttpPost]
        public ActionResult SaveDroneInspection()
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }

            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            try
            {
                var jsonData = JsonConvert.DeserializeObject<DroneData>(formData);

                //if (jsonData == null || IsDronePropertiesNullOrEmpty(jsonData))
                //{
                //    Response.StatusCode = 400;
                //    return Json(new { success = false, message = "Invalid parameters: data is missing or empty." }, JsonRequestBehavior.AllowGet);
                //}

                INS_DataFeed objDataFeed = new INS_DataFeed();
                string errorMessage = objDataFeed.SaveDrone(jsonData);

                if (errorMessage == "")
                {
                    return Json(new { success = true, message = " Inspection Saved Successfully." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Response.StatusCode = 409;
                    return Json(new { success = false, message = errorMessage }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (JsonException)
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

        private bool IsDronePropertiesNullOrEmpty(DroneData data)
        {
            foreach (var property in typeof(DroneData).GetProperties())
            {
                var value = property.GetValue(data);

                if (value != null)
                {
                    if (value is string strValue && !string.IsNullOrWhiteSpace(strValue))
                        return false;
                    else if (value is Array arrayValue && arrayValue.Length > 0)
                        return false;
                }
            }
            return true;
        }
        #endregion

        #region SaveBookIn
        [HttpPost]
        public ActionResult SaveBookIn()
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }

            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            try
            {
                var jsonData = JsonConvert.DeserializeObject<BookInData>(formData);

                //if (jsonData == null || IsBookInPropertiesNullOrEmpty(jsonData))
                //{
                //    Response.StatusCode = 400;
                //    return Json(new { success = false, message = "Invalid parameters: data is missing or empty." }, JsonRequestBehavior.AllowGet);
                //}

                INS_DataFeed objDataFeed = new INS_DataFeed();
                string errorMessage = objDataFeed.SaveBookIn(jsonData);

                if (errorMessage == "")
                {
                    return Json(new { success = true, message = " Inspection Saved Successfully." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Response.StatusCode = 409;
                    return Json(new { success = false, message = errorMessage }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (JsonException)
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

        private bool IsBookInPropertiesNullOrEmpty(BookInData data)
        {
            foreach (var property in typeof(BookInData).GetProperties())
            {
                var value = property.GetValue(data);

                if (value != null)
                {
                    if (value is string strValue && !string.IsNullOrWhiteSpace(strValue))
                        return false;
                    else if (value is Array arrayValue && arrayValue.Length > 0)
                        return false;
                }
            }
            return true;
        }
        #endregion

        #region GetSeller
        [HttpGet]
        public ActionResult GetSeller()
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
                DataTable dt = objDataFeed.GetSeller();

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

        #region GetRoofType
        [HttpGet]
        public ActionResult GetRoofType()
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
                DataTable dt = objDataFeed.GetRoofType();

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

        #region GetGasType
        [HttpGet]
        public ActionResult GetGasType()
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
                DataTable dt = objDataFeed.GetGasType();

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

        #region GetCatalyticOption
        [HttpGet]
        public ActionResult GetCatalyticOption()
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
                DataTable dt = objDataFeed.GetCatalyticOption();

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

        #region GetWindowOption
        [HttpGet]
        public ActionResult GetWindowOption()
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
                DataTable dt = objDataFeed.GetWindowOption();

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

        #region GetSteeringWheelType
        [HttpGet]
        public ActionResult GetSteeringWheelType()
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
                DataTable dt = objDataFeed.GetSteeringWheelType();

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

        #region GetPlateType
        [HttpGet]
        public ActionResult GetPlateType()
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
                DataTable dt = objDataFeed.GetPlateType();

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

        #region GetCabinOverall
        [HttpGet]
        public ActionResult GetCabinOverall()
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
                DataTable dt = objDataFeed.GetCabinOverall();

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

        #region GetCabinOverallById
        [HttpGet]
        public ActionResult GetCabinOverallById(int id)
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
                DataTable dt = objDataFeed.GetCabinOverallById(id);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetMakeByCode
        [HttpGet]
        public ActionResult GetMakeByCode(string code)
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
                DataTable dt = objDataFeed.GetMakeByCode(code);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetColour
        [HttpGet]
        public ActionResult GetColour()
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
                DataTable dt = objDataFeed.GetColour();

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

        #region GetColourByCode
        [HttpGet]
        public ActionResult GetColourByCode(string code)
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
                DataTable dt = objDataFeed.GetColourByCode(code);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetColourSet
        [HttpGet]
        public ActionResult GetColourSet()
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
                DataTable dt = objDataFeed.GetColourSet();

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

        #region GetColourSetByCode
        [HttpGet]
        public ActionResult GetColourSetByCode(string code)
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
                DataTable dt = objDataFeed.GetColourSetByCode(code);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetBodyByCode
        [HttpGet]
        public ActionResult GetBodyByCode(string code)
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
                DataTable dt = objDataFeed.GetBodyByCode(code);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetState
        [HttpGet]
        public ActionResult GetState()
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
                DataTable dt = objDataFeed.GetState();

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

        #region GetStateByCode
        [HttpGet]
        public ActionResult GetStateByCode(string code)
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
                DataTable dt = objDataFeed.GetStateByCode(code);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetStorage
        [HttpGet]
        public ActionResult GetStorage()
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
                DataTable dt = objDataFeed.GetStorage();

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

        #region GetStorageById
        [HttpGet]
        public ActionResult GetStorageById(int id)
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
                DataTable dt = objDataFeed.GetStorageById(id);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetPlant
        [HttpGet]
        public ActionResult GetPlant()
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
                DataTable dt = objDataFeed.GetPlant();

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

        #region GetPlantByCode
        [HttpGet]
        public ActionResult GetPlantByCode(string code)
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
                DataTable dt = objDataFeed.GetPlantByCode(code);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetSellingCategoryByCode
        [HttpGet]
        public ActionResult GetSellingCategoryByCode(string code)
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
                DataTable dt = objDataFeed.GetSellingCategoryByCode(code);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetDriveByCode
        [HttpGet]
        public ActionResult GetDriveByCode(string code)
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
                DataTable dt = objDataFeed.GetDriveByCode(code);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetEngineCapacityUnit
        [HttpGet]
        public ActionResult GetEngineCapacityUnit()
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
                DataTable dt = objDataFeed.GetEngineCapacityUnit();

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

        #region GetEngineCapacityUnitByCode
        [HttpGet]
        public ActionResult GetEngineCapacityUnitByCode(string code)
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
                DataTable dt = objDataFeed.GetEngineCapacityUnitByCode(code);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetGearBox
        [HttpGet]
        public ActionResult GetGearBox()
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
                DataTable dt = objDataFeed.GetGearBox();

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

        #region GetGearBoxByCode
        [HttpGet]
        public ActionResult GetGearBoxByCode(string code)
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
                DataTable dt = objDataFeed.GetGearBoxByCode(code);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetGear
        [HttpGet]
        public ActionResult GetGear()
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
                DataTable dt = objDataFeed.GetGear();

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

        #region GetGearByCode
        [HttpGet]
        public ActionResult GetGearByCode(string code)
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
                DataTable dt = objDataFeed.GetGearByCode(code);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetFuelDeliveryByCode
        [HttpGet]
        public ActionResult GetFuelDeliveryByCode(string code)
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
                DataTable dt = objDataFeed.GetFuelDeliveryByCode(code);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetFuelTypeByCode
        [HttpGet]
        public ActionResult GetFuelTypeByCode(string code)
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
                DataTable dt = objDataFeed.GetFuelTypeByCode(code);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetModelTemplate
        [HttpGet]
        public ActionResult GetModelTemplate()
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
                DataTable dt = objDataFeed.GetModelTemplate();

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

        #region GetModelTemplateByModelCode
        [HttpGet]
        public ActionResult GetModelTemplateByModelCode(string code)
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
                DataTable dt = objDataFeed.GetModelTemplateByModelCode(code);
                //var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                // .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

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

        #region GetMakeByModelCode
        [HttpGet]
        public ActionResult GetMakeByModelCode(string code)
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
                DataTable dt = objDataFeed.GetMakeByModelCode(code);
                //var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                // .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

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

        #region GetModelTemplateByMake
        [HttpGet]
        public ActionResult GetModelTemplateByMake(string code)
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
                DataTable dt = objDataFeed.GetModelTemplateByMake(code);
                //var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                // .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

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

        #region GetVariantByModelCode
        [HttpGet]
        public ActionResult GetVariantByModelCode(string code)
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
                DataTable dt = objDataFeed.GetVariantByModelCode(code);
                //var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                // .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

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

        #region GetEngineCapacityByVarId
        [HttpGet]
        public ActionResult GetEngineCapacityByVarId(int id)
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
                DataTable dt = objDataFeed.GetEngineCapacityByVarId(id);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetEngineCapacityUnitByVarId
        [HttpGet]
        public ActionResult GetEngineCapacityUnitByVarId(int id)
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
                DataTable dt = objDataFeed.GetEngineCapacityUnitByVarId(id);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetFuelDeliveryByVarId
        [HttpGet]
        public ActionResult GetFuelDeliveryByVarId(int id)
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
                DataTable dt = objDataFeed.GetFuelDeliveryByVarId(id);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetFuelTypeByVarId
        [HttpGet]
        public ActionResult GetFuelTypeByVarId(int id)
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
                DataTable dt = objDataFeed.GetFuelTypeByVarId(id);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetGearBoxByVarId
        [HttpGet]
        public ActionResult GetGearBoxByVarId(int id)
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
                DataTable dt = objDataFeed.GetGearBoxByVarId(id);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetGearByVarId
        [HttpGet]
        public ActionResult GetGearByVarId(int id)
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
                DataTable dt = objDataFeed.GetGearByVarId(id);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetInspecitonCatalog
        [HttpGet]
        public ActionResult GetInspecitonCatalog(string imapNo)
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
                DataTable dt = objDataFeed.GetInspecitonCatalog(imapNo);

                if (dt == null || dt.Rows.Count == 0)
                {
                    return Json(new { message = "There is no vehicle inspection by this imapNo." }, JsonRequestBehavior.AllowGet);
                }

                // Extract schema and JSON string
                string schemaName = dt.Rows[0]["schemaName"]?.ToString()?.ToLower() ?? "";
                string inspectionJson = dt.Rows[0]["InspectionData"]?.ToString() ?? "";

                if (string.IsNullOrEmpty(inspectionJson))
                {
                    return Json(new { message = "Inspection data is empty." }, JsonRequestBehavior.AllowGet);
                }

                object resultObj;

                if (schemaName.Contains("car"))
                {
                    var carModel = JsonConvert.DeserializeObject<CarInspectionCatalogModel>(inspectionJson);
                    resultObj = carModel;
                }
                else if (schemaName.Contains("motorbike"))
                {
                    var motorbikeModel = JsonConvert.DeserializeObject<MotorbikeInspectionCatalogModel>(inspectionJson);
                    resultObj = motorbikeModel;
                }
                else if (schemaName.Contains("salvage"))
                {
                    var salvageModel = JsonConvert.DeserializeObject<SalvageInspectionCatalogModel>(inspectionJson);
                    resultObj = salvageModel;
                }
                else
                {
                    return Json(new { message = "Unknown schema type." }, JsonRequestBehavior.AllowGet);
                }

                return Json(resultObj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetBodyByVarId
        [HttpGet]
        public ActionResult GetBodyByVarId(int id)
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
                DataTable dt = objDataFeed.GetBodyByVarId(id);
                var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                 .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                string jsString = JsonConvert.SerializeObject(rowDict);
                return Content(jsString, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region GetMatModel
        [HttpGet]
        public ActionResult GetMatModel()
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
                DataTable dt = objDataFeed.GetMatModel();

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

        #region GetCabType
        [HttpGet]
        public ActionResult GetCabType()
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
                DataTable dt = objDataFeed.GetCabType();

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

        #region GetLevelCab
        [HttpGet]
        public ActionResult GetLevelCab()
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
                DataTable dt = objDataFeed.GetLevelCab();

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

        #region GetVehicleColoursSet
        [HttpGet]
        public ActionResult GetVehicleColoursSet()
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
                DataTable dt = objDataFeed.GetVehicleColoursSet();

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

        #region BookInCreate
        [HttpPost]
        public ActionResult BookInCreate()
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }

            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            try
            {
                var jsonData = JsonConvert.DeserializeObject<BookinModel>(formData);
                //flLog.Info("BookIn-BookIn-Create: model={0}", jsonData);

                INS_DataFeed objDataFeed = new INS_DataFeed();
                var dn = objDataFeed.CreateBookinNumber();
                string bookinNumber = dn.FirstOrDefault();

                _ = new BookinReceiver();
                BookinReceiver bookinType = jsonData.BookInType;
                if (bookinType == null)
                {
                    //flLog.Error("BookIn-BookIn-Create: DbUpdateException={0}", "Book In Null");
                    Response.StatusCode = 409;
                    return Json(new { success = false, message = "Book In Null" }, JsonRequestBehavior.AllowGet);
                }

                byte[] senderSignature = null;
                byte[] receiverSignatyre = null;
                byte[] stickVin = null;
                if (bookinType.SenderSignature != null)
                {
                    senderSignature = Convert.FromBase64String(bookinType.SenderSignature);
                }
                if (bookinType.ReceiverSignature != null)
                {
                    receiverSignatyre = Convert.FromBase64String(bookinType.ReceiverSignature);
                }
                if (bookinType.StickVin != null)
                {
                    stickVin = Convert.FromBase64String(bookinType.StickVin);
                }
                BookIn bookIn = new BookIn()
                {
                    BookInNumber = bookinNumber,
                    BookInDate = bookinType.BookInDate,
                    SenderName = bookinType.SenderName,
                    ReceiverName = bookinType.ReceiverName,
                    ContractNumber = bookinType.ContractNumber ?? String.Empty,
                    MobileNumber = bookinType.MobileNumber,
                    Status = bookinType.Status,
                    SellerCode = bookinType.SellerCode,
                    Inspector = bookinType.Inspector,
                    VehicleId = bookinType.VehicleId,
                    SenderSignature = senderSignature,
                    ReceiverSignature = receiverSignatyre,
                    LatestUpdatedDate = bookinType.LatestUpdatedDate,
                    BookinType = bookinType.BookinType.ToUpper(),
                    CreateBy = bookinType.ReceiverName,
                    CreateDate = DateTime.Now,
                    ContractTypeCode = bookinType.ContractTypeCode,
                    StickVin = stickVin

                };
                string error = objDataFeed.AddBookIn(bookIn);
                if (!string.IsNullOrWhiteSpace(error)) {
                    //flLog.Error("BookIn-BookIn-Create: DbUpdateException={0}", error);
                    return Json(new { success = false, message = $"AddBookIn failed: {error}" }, JsonRequestBehavior.AllowGet);
                }

                _ = new Vehicle();
                Vehicle vehicle = new Vehicle()
                {
                    BookinNumber = bookinNumber.TrimEnd(),
                    Seller = jsonData.VehicleType.Seller.TrimEnd(),
                    SellingCategory = jsonData.VehicleType.SellingCategory,
                    LogisticsStatus = "BI",
                    InspectionDate = jsonData.VehicleType.InspectionDate,
                    SalesStatus = "NR",
                    Plant = jsonData.VehicleType.Plant.TrimEnd(),
                    StorageLocation = jsonData.VehicleType.StorageLocation.TrimEnd(),
                    ReceiverLocation = jsonData.VehicleType.ReceiverLocation.TrimEnd(),
                    BookedDate = jsonData.VehicleType.BookedDate,
                    Make = jsonData.VehicleType.Make.TrimEnd(),
                    Make_BU = jsonData.VehicleType.Make_BU.TrimEnd(),
                    Make_LO = jsonData.VehicleType.Make_LO.TrimEnd(),
                    ModelCode = jsonData.VehicleType.ModelCode.TrimEnd(), // Need to Revise...
                    ModelCodeId = jsonData.VehicleType.ModelCodeId,
                    Model_BU = jsonData.VehicleType.Model_BU.TrimEnd(),
                    Model_LO = jsonData.VehicleType.Model_LO.TrimEnd(),
                    Body = jsonData.VehicleType.Body.TrimEnd(),
                    BodyDesc_BU = jsonData.VehicleType.BodyDesc_BU.TrimEnd(),
                    BodyDesc_LO = jsonData.VehicleType.BodyDesc_LO.TrimEnd(),
                    Variants = jsonData.VehicleType.Variants.TrimEnd(),
                    BuildYear = jsonData.VehicleType.BuildYear,
                    VIN = jsonData.VehicleType.VIN.TrimEnd(),
                    ChasisNumber = jsonData.VehicleType.ChasisNumber.TrimEnd(),
                    Colour = jsonData.VehicleType.Colour.TrimEnd(),
                    ColourDesc = jsonData.VehicleType.ColourDesc.TrimEnd(),
                    FuelDelivery = jsonData.VehicleType.FuelDelivery.TrimEnd(),
                    FuelType = jsonData.VehicleType.FuelType.TrimEnd(),
                    Gearbox = jsonData.VehicleType.Gearbox.TrimEnd(),
                    Gears = "0",
                    Drive = jsonData.VehicleType.Drive.TrimEnd(),
                    EngineNumber = jsonData.VehicleType.EngineNumber.TrimEnd(),
                    EngineCapacity = jsonData.VehicleType.EngineCapacity,
                    EngineCapacityUnit = jsonData.VehicleType.EngineCapacityUnit.TrimEnd(),
                    Regisration = jsonData.VehicleType.Regisration.TrimEnd(),
                    RegistrationYear = jsonData.VehicleType.RegistrationYear.TrimEnd(),
                    RegistrationProvince = jsonData.VehicleType.RegistrationProvince.TrimEnd(),
                    RegistrationPlate = jsonData.VehicleType.RegistrationPlate ?? String.Empty,
                    RegistrationNote = jsonData.VehicleType.RegistrationNote ?? String.Empty,
                    IsRegistrationMismatch = jsonData.VehicleType.IsRegistrationMismatch ?? false,
                    RedBookCondition = jsonData.VehicleType.RedBookCondition.TrimEnd(),
                    IsGasTank = jsonData.VehicleType.IsGasTank,
                    GasType = jsonData.VehicleType.GasType,
                    GasTankNumber = jsonData.VehicleType.GasTankNumber,
                    // Check null -> Trim ...
                    GasNote = jsonData.VehicleType.GasNote,
                    IsInValidEngineNumber = jsonData.VehicleType.IsInValidEngineNumber ?? false,
                    ReasonInValidEngineNumber = jsonData.VehicleType.ReasonInValidEngineNumber ?? String.Empty,
                    IsInValidGasNumber = jsonData.VehicleType.IsInValidGasNumber ?? false,
                    ReasonInValidGasNumber = jsonData.VehicleType.ReasonInValidGasNumber ?? String.Empty,
                    IsInValidVinNumber = jsonData.VehicleType.IsInValidVinNumber ?? false,
                    ReasonInValidVinNumber = jsonData.VehicleType.ReasonInValidVinNumber ?? String.Empty,
                    // arsira 2024-02-02
                    IsNohaveBuildYear = jsonData.VehicleType.IsNohaveBuildYear ?? false,
                    IsNohaveRegis = jsonData.VehicleType.IsNohaveRegis ?? false,
                    // arsira 2024-02-05
                    briefCarConditionId = jsonData.VehicleType.briefCarConditionId ?? 1,
                    DetallBriefCarCondition = jsonData.VehicleType.DetallBriefCarCondition ?? String.Empty,
                    // arsira 2024-06-14 add motorNumber
                    MotorNumber = jsonData.VehicleType.MotorNumber ?? String.Empty,
                    IsInValidMotorNumber = jsonData.VehicleType.IsInValidMotorNumber ?? false,
                    ReasonInValidMotorNumber = jsonData.VehicleType.ReasonInValidMotorNumber ?? String.Empty,

                    IsInVaidEngine1 = jsonData.VehicleType.IsInVaidEngine1 ?? false,
                    IsInVaidEngine2 = jsonData.VehicleType.IsInVaidEngine2 ?? false,
                    IsInVaidEngine3 = jsonData.VehicleType.IsInVaidEngine3 ?? false,
                    IsInVaidVin1 = jsonData.VehicleType.IsInVaidVin1 ?? false,
                    IsInVaidVin2 = jsonData.VehicleType.IsInVaidVin2 ?? false,
                    IsInVaidVin3 = jsonData.VehicleType.IsInVaidVin3 ?? false,
                    NoPlateType = jsonData.VehicleType.NoPlateType ?? String.Empty,
                    CatalyticOption = jsonData.VehicleType.CatalyticOption,
                    CabTypeID = jsonData.VehicleType.CabTypeID ?? String.Empty,
                    LevelCabID = jsonData.VehicleType.LevelCabID ?? String.Empty
                };
                error = objDataFeed.AddVehicle(vehicle);
                if (!string.IsNullOrWhiteSpace(error)) {
                    //flLog.Error("BookIn-BookIn-Create: DbUpdateException={0}", error);
                    return Json(new { success = false, message = $"AddVehicle failed: {error}" }, JsonRequestBehavior.AllowGet);
                }

                _ = new External();
                External external = jsonData.ExternalType;
                external.BookinNumber = bookinNumber;
                error = objDataFeed.AddExternal(external);
                if (!string.IsNullOrWhiteSpace(error)) {
                    //flLog.Error("BookIn-BookIn-Create: DbUpdateException={0}", error);
                    return Json(new { success = false, message = $"AddExternal failed: {error}" }, JsonRequestBehavior.AllowGet);
                }

                _ = new Spare();
                Spare spare = jsonData.SpareType;
                spare.BookinNumber = bookinNumber;
                error = objDataFeed.AddSpare(spare);
                if (!string.IsNullOrWhiteSpace(error)) {
                    //flLog.Error("BookIn-BookIn-Create: DbUpdateException={0}", error);
                    return Json(new { success = false, message = $"AddSpare failed: {error}" }, JsonRequestBehavior.AllowGet);
                }

                _ = new Cabin();
                Cabin cabin = jsonData.CabinType;
                cabin.BookInNumber = bookinNumber;
                error = objDataFeed.AddCabin(cabin);
                if (!string.IsNullOrWhiteSpace(error)) {
                    //flLog.Error("BookIn-BookIn-Create: DbUpdateException={0}", error);
                    return Json(new { success = false, message = $"AddCabin failed: {error}" }, JsonRequestBehavior.AllowGet);
                }

                _ = new KeyOption();
                KeyOption keyOption = jsonData.KeyOptionType;
                keyOption.BookinNumber = bookinNumber;
                error = objDataFeed.AddKeyOption(keyOption);
                if (!string.IsNullOrWhiteSpace(error)) {
                    //flLog.Error("BookIn-BookIn-Create: DbUpdateException={0}", error);
                    return Json(new { success = false, message = $"AddKeyOption failed: {error}" }, JsonRequestBehavior.AllowGet);
                }

                _ = new Engine();
                Engine engine = jsonData.EngineType;
                engine.BookinNumber = bookinNumber;
                error = objDataFeed.AddEngine(engine);
                if (!string.IsNullOrWhiteSpace(error)) {
                    //flLog.Error("BookIn-BookIn-Create: DbUpdateException={0}", error);
                    return Json(new { success = false, message = $"AddEngine failed: {error}" }, JsonRequestBehavior.AllowGet);
                }

                #region createVehicle
                string vehicleId = objDataFeed.GetNextVehicleNumber();

                //flLog.Info("vehicle-UpdateVehicleOnCreate: bookInNumber={0} | vehicleId={1}", bookinNumber, vehicleId);
                objDataFeed.UpdateVehicleOnCreate(bookinNumber.TrimEnd(), vehicleId);
                #endregion

                return Json(new { success = true, message = "BookIn saved successfully.", vehicleId }, JsonRequestBehavior.AllowGet);
            }
            catch (JsonException)
            {
                //flLog.Error("BookIn-BookIn-Create: DbUpdateException={0}", "Invalid JSON format.");
                Response.StatusCode = 400;
                return Json(new { success = false, message = "Invalid JSON format." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region InspectionCreate
        [HttpPost]
        public ActionResult InspectionCreate()
        {
            string apiKey = Request.Headers["apiKey"];
            const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

            if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
            }

            string formData;
            using (var reader = new StreamReader(Request.InputStream))
            {
                formData = reader.ReadToEnd();
            }

            try
            {
                var jsonData = JsonConvert.DeserializeObject<CarInspection>(formData);
                //logger.Info("inspection-create: CarInspection={0}", jsonData);

                INS_DataFeed objDataFeed = new INS_DataFeed();
                DataTable dt = objDataFeed.GetCarInspectionByBookIn(jsonData.BookInNumber);
                if (dt.Rows.Count > 0)
                {
                    return Json(new { success = true, message = "Inspection saved successfully.", vehicleId = jsonData.VehicleId.TrimEnd() }, JsonRequestBehavior.AllowGet);
                }

                CarInspection carInspection = new CarInspection()
                {
                    //InspectionId = jsonData.InspectionId,
                    BookInNumber = jsonData.BookInNumber,
                    VehicleId = jsonData.VehicleId,
                    Inspector = jsonData.Inspector ?? "",
                    InspectionDate = jsonData.InspectionDate,
                    InspectorName = jsonData.InspectorName ?? "",
                    Chassis = jsonData.Chassis ?? "",
                    Front = jsonData.Front ?? "",
                    Back = jsonData.Back ?? "",
                    RightSide = jsonData.RightSide ?? "",
                    LeftSide = jsonData.LeftSide ?? "",
                    Roof = jsonData.Roof ?? "",
                    IsFlood = jsonData.IsFlood ?? false,
                    BodySummary = jsonData.BodySummary ?? "",
                    IsEngineWorks = jsonData.IsEngineWorks ?? false,
                    FuelSystemId = jsonData.FuelSystemId ?? 0,
                    IsLubricatorLow = jsonData.IsLubricatorLow ?? false,
                    EngineSystemId = jsonData.EngineSystemId ?? 0,
                    GearTypeId = jsonData.GearTypeId ?? 0,
                    IsUseableGeneral = jsonData.IsUseableGeneral ?? false,
                    IsSoundAbnormal = jsonData.IsSoundAbnormal ?? false,
                    IsLeakFuel = jsonData.IsLeakFuel ?? false,
                    IsStainWater = jsonData.IsStainWater ?? false,
                    IsMachineLightShow = jsonData.IsMachineLightShow ?? false,
                    IsEngineAbnomal = jsonData.IsEngineAbnomal ?? false,
                    IsNeedRepair = jsonData.IsNeedRepair ?? false,
                    EngineSummary = jsonData.EngineSummary ?? "",
                    DriveShaftConditionId = jsonData.DriveShaftConditionId ?? 0,
                    DriveShaftConditionNote = jsonData.DriveShaftConditionNote ?? "",
                    SuspensionConditionId = jsonData.SuspensionConditionId ?? 0,
                    SuspensionConditionNote = jsonData.SuspensionConditionNote ?? "",
                    SuspensionSummary = jsonData.SuspensionSummary ?? "",
                    GearSystemId = jsonData.GearSystemId ?? 0,
                    GearConditionId = jsonData.GearConditionId ?? 0,
                    DriveShaftId = jsonData.DriveShaftId ?? 0,
                    Is4WD = jsonData.Is4WD ?? false,
                    GearSystemSummary = jsonData.GearSystemSummary ?? "",
                    IsUseableSteerWheel = jsonData.IsUseableSteerWheel ?? false,
                    IsPowerSteering = jsonData.IsPowerSteering ?? false,
                    SteeringSummary = jsonData.SteeringSummary ?? "",
                    IsUseableBrake = jsonData.IsUseableBrake ?? false,
                    BreakSystemSumary = jsonData.BreakSystemSumary ?? "",
                    IsAirCool = jsonData.IsAirCool ?? false,
                    IsCompressorAir = jsonData.IsCompressorAir ?? false,
                    AirSystemSummary = jsonData.AirSystemSummary ?? "",
                    IsUseableGuage = jsonData.IsUseableGuage ?? false,
                    WarningLightNote = jsonData.WarningLightNote ?? "",
                    GaugeSummary = jsonData.GaugeSummary ?? "",
                    IsFrontLightWorking = jsonData.IsFrontLightWorking ?? false,
                    IsTurnLightWorking = jsonData.IsTurnLightWorking ?? false,
                    IsBackLightWorking = jsonData.IsBackLightWorking ?? false,
                    IsBrakeLightWoring = jsonData.IsBrakeLightWoring ?? false,
                    IsBetteryWorking = jsonData.IsBetteryWorking ?? false,
                    IsHooterWorking = jsonData.IsHooterWorking ?? false,
                    IsRoundGaugeWorking = jsonData.IsRoundGaugeWorking ?? false,
                    IsNavigator = jsonData.IsNavigator ?? false,
                    IsNavigatorBuiltIn = jsonData.IsNavigatorBuiltIn ?? false,
                    IsNavigatorCD = jsonData.IsNavigatorCD ?? false,
                    IsNavigatorSdcard = jsonData.IsNavigatorSdcard ?? false,
                    IsNavigatorNoCD = jsonData.IsNavigatorNoCD ?? false,
                    IsNavigatorNoSdcard = jsonData.IsNavigatorNoSdcard ?? false,
                    ElectronicNote = jsonData.ElectronicNote ?? "",
                    ElectronicSummary = jsonData.ElectronicSummary ?? "",
                    LatestUpdatedDate = jsonData.LatestUpdatedDate ?? DateTime.Now,
                    Regisration = jsonData.Regisration ?? String.Empty,
                    RegistrationProvince = jsonData.RegistrationProvince ?? String.Empty
                };
                string error = objDataFeed.AddCarInspection(carInspection);
                if (!string.IsNullOrWhiteSpace(error))
                {
                    //logger.Error("inspection-create :", error);
                    return Json(new { success = false, message = $"AddInspection failed: {error}" }, JsonRequestBehavior.AllowGet);
                }

                #region updateVehicle

                //flLog.Info("vehicle-UpdateVehicleOnUpdate: bookInNumber={0} | vehicleId={vehicleId}", jsonData.BookInNumber.TrimEnd(), jsonData.VehicleId.TrimEnd());
                objDataFeed.UpdateVehicleOnUpdate(jsonData.BookInNumber.TrimEnd(), jsonData.VehicleId.TrimEnd());
                #endregion
                return Json(new { success = true, message = "Inspection saved successfully.", vehicleId = jsonData.VehicleId.TrimEnd() }, JsonRequestBehavior.AllowGet);
            }
            catch (JsonException)
            {
                //logger.Error("inspection-create : Invalid JSON format.");
                Response.StatusCode = 400;
                return Json(new { success = false, message = "Invalid JSON format." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        #region CheckIMAPNumber
        [HttpGet]
        public ActionResult CheckIMAPNumber(string imapNo)
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
                string bookInNo = objDataFeed.GetBookInNoByVehicleID(int.Parse(imapNo == null ? "0" : imapNo).ToString("D18"));
                //var rowDict = dt.Rows[0].Table.Columns.Cast<DataColumn>()
                // .ToDictionary(col => col.ColumnName, col => dt.Rows[0][col]);

                if (bookInNo == "")
                {
                    return Json(new { success = false, message = "Invalid Imap Number." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = true, message = "Valid Imap Number." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }
        #endregion

        //#region InspectionImageCreate
        //[HttpPost]
        //public ActionResult InspectionImageCreate()
        //{
        //    string apiKey = Request.Headers["apiKey"];
        //    const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

        //    if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
        //    }

        //    string formData;
        //    using (var reader = new StreamReader(Request.InputStream))
        //    {
        //        formData = reader.ReadToEnd();
        //    }

        //    try
        //    {
        //        var jsonData = JsonConvert.DeserializeObject<InspectionImageType>(formData);
        //        flLog.Info("inspectionImage-create: InspectionImage={0}", jsonData);
        //        if (jsonData.InspectionImage.BookInNumber == null || jsonData.InspectionImage.BookInNumber.Length == 0) return Json(new { success = false, message = "Invalid parameter." }, JsonRequestBehavior.AllowGet);
        //        if (jsonData.InspectionImage.ImageTypeId == null) return Json(new { success = false, message = "Invalid parameter." }, JsonRequestBehavior.AllowGet);
        //        if (jsonData.InspectionImage.ImageName == null || jsonData.InspectionImage.ImageName.Length == 0) return Json(new { success = false, message = "Invalid parameter." }, JsonRequestBehavior.AllowGet);

        //        INS_DataFeed objDataFeed = new INS_DataFeed();
        //        if (jsonData.InspectionImage.ImageId == 0
        //        && (jsonData.InspectionImage.ImageTypeId == 1 || jsonData.InspectionImage.ImageTypeId == 4))
        //        {
        //            // Edit...
        //            flLog.Info("inspectionImage-create: Edit-Inspection, value={0}", jsonData.InspectionImage);

        //            // Delete Image from IMAT...
        //            objDataFeed.UpdateVehicleDocument(jsonData.InspectionImage.VehicleId, (int)jsonData.InspectionImage.ImageTypeId);
        //            flLog.Info("inspectionImage-create: Update vehicle document deleted, VehicleId={0}, ImageTypeId={1}", jsonData.InspectionImage.VehicleId, (int)jsonData.InspectionImage.ImageTypeId);
        //        }
        //        else
        //        {
        //            DataTable dt = objDataFeed.GetDuplicateCarInspectionImage(jsonData);
        //            if (dt.Rows.Count > 0)
        //            {
        //                flLog.Info("inspectionImage-create: File already exists!");
        //                Response.StatusCode = 409;
        //                return Json(new { success = false, message = "Conflict" }, JsonRequestBehavior.AllowGet);
        //            }
        //            //if (db.CarInspectionImages.Any(i => i.BookInNumber == model.InspectionImage.BookInNumber
        //            //   && i.ImageTypeId == model.InspectionImage.ImageTypeId
        //            //   && i.ImageName.Equals(model.InspectionImage.ImageName.TrimEnd())
        //            //   && i.IsDeleted == false))
        //            //{


        //            //    return BadRequest("Invalid parameter.");
        //            //}
        //        }

        //        CarInspectionImage inspectionImage = jsonData.InspectionImage;
        //        if (inspectionImage.BookInNumber == null)
        //        {
        //            flLog.Error("inspectionImage-create: File not found!");
        //            return Json(new { success = false, message = "Invalid parameter." }, JsonRequestBehavior.AllowGet);
        //        }

        //        string serverPath = Properties.Settings.Default.StockPhoto.ToString();
        //        //string documentPath = HttpContext.Current.Server.MapPath(String.Format(@"~/Uploads/{0}/{1}/{2}.jpg", model.InspectionImage.VehicleId, model.InspectionImage.ImageTypeId ?? 0, model.InspectionImage.ImageName));
        //        string documentPath = String.Format(@"{0}\{1}\{2}\{3}.jpg", SourceFolder, jsonData.InspectionImage.VehicleId, jsonData.InspectionImage.ImageTypeId ?? 0, jsonData.InspectionImage.ImageName);
        //        string credentialPath = string.Empty;
        //        // Convert Base64String to Bitmap...
        //        byte[] carImage = null;
        //        if (jsonData.Base64String != null)
        //        {
        //            flLog.Info("inspectionImage-create: CreateVehicleDocument, documentPath={0}", documentPath);
        //            carImage = Convert.FromBase64String(jsonData.Base64String);

        //            // Pararell insert image to imat...
        //            if (jsonData.InspectionImage.VehicleId != null)
        //            {
        //                // No resize image option...
        //                string documentDesc = jsonData.InspectionImage.ImageName.TrimEnd();
        //                objDataFeed.CreateVehicleDocument(
        //                    jsonData.InspectionImage.VehicleId
        //                    , jsonData.InspectionImage.ImageDescEn
        //                    , jsonData.InspectionImage.ImageDescTh
        //                    , (int)jsonData.InspectionImage.ImageTypeId
        //                    , documentPath
        //                    , carImage);
        //            }
        //        }

        //        try
        //        {
        //            //Create the Directory.
        //            //string path = HttpContext.Current.Server.MapPath(String.Format(@"~/Uploads/{0}/{1}/", model.InspectionImage.VehicleId, model.InspectionImage.ImageTypeId ?? 0));
        //            string folderPath = String.Format(@"{0}\{1}", SourceFolder, jsonData.InspectionImage.VehicleId);
        //            string subFolderPath = String.Format(@"{0}\{1}\{2}", SourceFolder, jsonData.InspectionImage.VehicleId, jsonData.InspectionImage.ImageTypeId ?? 0);
        //            credentialPath = String.Format(@"{0}\", SourceFolder);
        //            Uri uri = new Uri(credentialPath);
        //            NetworkCredential credential = new NetworkCredential("", "", "");
        //            credential.Domain = @"";
        //            credential.UserName = @"local\ds01";
        //            credential.Password = @"abcd@1234";
        //            CredentialCache credentialCache = new CredentialCache
        //        {
        //            { uri, "Basic", credential }
        //        };

        //            //// Acquire semaphore
        //            //await _uploadSemaphore.WaitAsync(); 

        //            using (new NetworkConnection(SourceFolder, credential))
        //            {
        //                if (!Directory.Exists(folderPath))
        //                {
        //                    Directory.CreateDirectory(folderPath);
        //                }
        //                if (!Directory.Exists(subFolderPath))
        //                {
        //                    Directory.CreateDirectory(subFolderPath);
        //                }

        //                // Save Image
        //                // Checkimg existing file first..
        //                if (System.IO.File.Exists(folderPath))
        //                {
        //                    // Deleted old file

        //                    System.IO.File.Delete(documentPath);
        //                    flLog.Info("inspectionImage-create: VehicleId={0}, Delete exists file={1}", jsonData.InspectionImage.VehicleId, documentPath);

        //                    System.IO.File.WriteAllBytes(documentPath, carImage);
        //                }
        //                else
        //                {
        //                    System.IO.File.WriteAllBytes(documentPath, carImage);

        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            flLog.Error(ex, "inspectionImage-create: bookinNumber={0}, Err={1}", jsonData.InspectionImage.BookInNumber, ex.Message);
        //            flLog.Info("inspectionImage-create: VehicleId={0}, SRC={1}", jsonData.InspectionImage.VehicleId, documentPath);
        //            Response.StatusCode = 500;
        //            return Json(new { success = false, message = "Internal Sever Error." }, JsonRequestBehavior.AllowGet);
        //        }
        //        finally
        //        {
        //            //// Release semaphore
        //            //_uploadSemaphore.Release(); 
        //        }

        //        inspectionImage.BookInNumber = jsonData.InspectionImage.BookInNumber;
        //        inspectionImage.VehicleId = jsonData.InspectionImage.VehicleId;
        //        inspectionImage.ImageTypeId = jsonData.InspectionImage.ImageTypeId;
        //        inspectionImage.ImageDescEn = jsonData.InspectionImage.ImageDescEn;
        //        inspectionImage.ImageDescTh = jsonData.InspectionImage.ImageDescTh;
        //        inspectionImage.ImageName = jsonData.InspectionImage.ImageName;
        //        inspectionImage.ImagePath = documentPath;
        //        inspectionImage.DamageDesc = jsonData.InspectionImage.DamageDesc ?? String.Empty;
        //        inspectionImage.DamageSize = jsonData.InspectionImage.DamageSize ?? String.Empty;
        //        inspectionImage.DamageType = jsonData.InspectionImage.DamageType ?? String.Empty;
        //        inspectionImage.IsDeleted = false;
        //        string error = objDataFeed.AddCarInspectionImage(inspectionImage);

        //        return Json(new { success = true, message = "Saved Image successfully." }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (JsonException)
        //    {
        //        //flLog.Error("inspectionImage-create : Invalid JSON format.");
        //        Response.StatusCode = 400;
        //        return Json(new { success = false, message = "Invalid JSON format." }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
        //    }
        //}
        //#endregion

        //#region VehicleCreate
        //[HttpPost]
        //public ActionResult VehicleCreate()
        //{
        //    string apiKey = Request.Headers["apiKey"];
        //    const string validApiKey = "0930939f-512f-4399-8d94-1eab8ec06c37";

        //    if (string.IsNullOrEmpty(apiKey) || apiKey != validApiKey)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid API Key");
        //    }

        //    string formData;
        //    using (var reader = new StreamReader(Request.InputStream))
        //    {
        //        formData = reader.ReadToEnd();
        //    }

        //    try
        //    {
        //        var jsonData = JsonConvert.DeserializeObject<VehicleModel>(formData);
        //        flLog.Info("vehicle-createVehicle: VehicleModel={0}", jsonData);

        //        INS_DataFeed objDataFeed = new INS_DataFeed();
        //        string vehicleId = objDataFeed.GetNextVehicleNumber();

        //        objDataFeed.UpdateVehicleOnCreate(jsonData.BookInNumber.TrimEnd(), vehicleId);

        //        VehicleModel vehicleModel = new VehicleModel()
        //        {
        //            VehicleId = vehicleId,
        //            Seller = jsonData.Seller,
        //            SellingCategory = "CA",
        //            LogisticsStatus = "",
        //            SalesStatus = "NA",
        //            Plant = jsonData.Plant,
        //            Make = jsonData.Make
        //        };
        //        return Json(new { success = true, message = "created Vehicle successfully.", model = vehicleModel }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (JsonException)
        //    {
        //        logger.Error("vehicle-createVehicle: Invalid JSON format.");
        //        Response.StatusCode = 400;
        //        return Json(new { success = false, message = "Invalid JSON format." }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
        //    }
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
    }
}