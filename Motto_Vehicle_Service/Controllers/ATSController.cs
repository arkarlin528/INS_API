using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOTTO_DATAFEED.DAO;
using Motto_Vehicle_DataFeed;

namespace Motto_Vehicle_Service.Controllers
{
    public class ATSController : Controller
    {
        // GET: ATS
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("loadmottovehicles")]
        public ActionResult LoadMottoVehicles(string LoadType)
        {
            ATS_DATAFEED objDataFeed = new ATS_DATAFEED();
            List<ATS_MOTTO_Vehicle> lstData = objDataFeed.LoadVehicleData(LoadType);
            
            var jsonDictionary = new Dictionary<string, int>
            {
                { "recordCount", (lstData.Any() ? lstData.Count : 0)}
            };
            objDataFeed.Logger(JsonConvert.SerializeObject(jsonDictionary), "vehicle", lstData.Count);
            return Json(jsonDictionary, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("mottovehicles")]
        public ActionResult MottoVehicles(int pageNumber, int pageSize)
        {
            ATS_DATAFEED objDataFeed = new ATS_DATAFEED();
            List<ATS_MOTTO_Vehicle> lstData = objDataFeed.getVehicleData();
            var jsonDictionary = new Dictionary<string, List<ATS_MOTTO_Vehicle>>
            {
                { "data", (lstData.Any() ?
                            lstData.Skip((pageNumber - 1) * pageSize) // Skip records based on page number and page size
                            .Take(pageSize) // Take only the specified number of records for the current page
                            .ToList()
                            :lstData)
                }
            };
            objDataFeed.Logger(JsonConvert.SerializeObject(jsonDictionary), "vehicle", lstData.Count);
            return Json(jsonDictionary, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("loadmottoLocation")]
        public ActionResult LoadMottoLocation(string LoadType)
        {
            ATS_DATAFEED objDataFeed = new ATS_DATAFEED();
            List<ATS_MOTTO_Location> lstData = objDataFeed.LoadLocationData(LoadType);
            var jsonDictionary = new Dictionary<string, int>
            {
                { "recordCount", (lstData.Any() ? lstData.Count : 0)}
            };
            objDataFeed.Logger(JsonConvert.SerializeObject(jsonDictionary), "location", lstData.Count);
            return Json(jsonDictionary, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("mottolocations")]
        public ActionResult MottoLocations(int pageNumber, int pageSize)
        {
            ATS_DATAFEED objDataFeed = new ATS_DATAFEED();
            List<ATS_MOTTO_Location> lstData = objDataFeed.getLocationData();
            var jsonDictionary = new Dictionary<string, List<ATS_MOTTO_Location>>
            {
                { "data", (lstData.Any() ?
                            lstData.Skip((pageNumber - 1) * pageSize) // Skip records based on page number and page size
                            .Take(pageSize) // Take only the specified number of records for the current page
                            .ToList()
                            :lstData)
                }
            };
            objDataFeed.Logger(JsonConvert.SerializeObject(jsonDictionary), "location", lstData.Count);
            return Json(jsonDictionary, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("mottovehicledetails")]
        public ActionResult MottoVehicleDetails()
        {
            string id = Request.QueryString["id"];
            ATS_DATAFEED objDataFeed = new ATS_DATAFEED();
            List<ATS_MOTTO_SearchVehicle_Detail> lstData = objDataFeed.getVehicleDetails(id);
            var jsonDictionary = new Dictionary<string, List<ATS_MOTTO_SearchVehicle_Detail>>
            {
                {
                    "data", (lstData.Any() ? lstData.ToList() :lstData)
                }
            };
            objDataFeed.Logger(JsonConvert.SerializeObject(jsonDictionary), "vehicledetails", lstData.Count);
            return Json(jsonDictionary, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("clearcache")]
        public ActionResult ClearCache()
        {
            ATS_DATAFEED objDataFeed = new ATS_DATAFEED();
            objDataFeed.ClearCache();
            var returnMsg = new { Code = "000", Message = "Success" };
            return Json(returnMsg, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}