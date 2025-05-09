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

namespace INS_API.Controllers
{
    public class INSController : Controller
    {
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

        #region GetLevelCab
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