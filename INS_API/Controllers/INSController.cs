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
    }
}