using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MOTTO_DATAFEED.DAO
{

    #region ATS_MOTTO_Vehicle
    public class ATS_MOTTO_Vehicle
    {
        [JsonProperty("id")]        
        public int id { get; set; }

        [JsonProperty("business_type")]
        public string business_type { get; set; }

        [JsonProperty("current_location_id")]
        public int current_location_id { get; set; }

        [JsonProperty("country_id")]
        public int country_id { get; set;}

        [JsonProperty("qr_code")]
        public string qr_code { get; set; }

        [JsonProperty("inventory")]
        public List<ATS_MOTTO_Vehicle_Detail> inventory { get; set; }

        public ATS_MOTTO_Vehicle() { }
    }
    #endregion

    #region ATS_MOTTO_Vehicle_Detail
    public class ATS_MOTTO_Vehicle_Detail
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("make")]
        public string make { get; set; }

        [JsonProperty("model")]
        public string model { get; set; }

        [JsonProperty("submodel")]
        public string submodel { get; set; }

        [JsonProperty("licence_plate_number")]
        public string licence_plate_number { get; set; }

        [JsonProperty("engine_number")]
        public string engine_number { get; set; }

        [JsonProperty("chassis_number")]
        public string chassis_number { get; set; }

        [JsonProperty("engine_capacity")]
        public string engine_capacity { get; set; }

        [JsonProperty("country_id")]
        public int country_id { get; set; }

        [JsonProperty("manufacture_year")]
        public int manufacture_year { get; set; }

        public ATS_MOTTO_Vehicle_Detail() { }
    }
    #endregion

    #region ATS_MOTTO_Location
    public class ATS_MOTTO_Location
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("display_name")]
        public string display_name { get; set; }

        [JsonProperty("address")]
        public string address { get; set; }

        [JsonProperty("latitude")]
        public string latitude { get; set; }

        [JsonProperty("longitude")]
        public string longitude { get; set; }

        public ATS_MOTTO_Location() { }
    }
    #endregion

    #region ATS_Log_Data

    public class ATS_Log_Data
    { 
        public int ID { get; set; }
        public DateTime LogDate { get; set; }
        public string TypeOfData { get; set; }
        public string DataJson { get; set; }
        public string RequestBy { get; set; }
        public ATS_Log_Data() { }
    }
    #endregion

    public class Transport_User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public int DepartmentID { get; set; }
        public int UserType { get; set; }
    }

    public class Transport_Request
    {
        public int RequestID { get; set; }
        public int TotalRecords { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadBy { get; set; }
    }

    public class Transport_Order
    {
        public int OrderID { get; set; }
        public string OrderCode { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class Transport_Schedule
    {
        public int ScheduleID { get; set; }
        public DateTime EstimateDepartureDate { get; set; }
        public DateTime EstimateArrivalDate { get; set; }
        public int FromYard { get; set; }
        public int ToYard { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Vehicle {  get; set; }
        public int VendorId { get; set; }
    }

    public class Transport_ScheduleDetail
    {
        public int DetailID { get; set; }
        public int ScheduleID { get; set; }
        public string Vehicle { get; set; }
        public int Status { get; set; }
        public string CheckOutLocation { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string CheckOutTime { get; set; }
        public string CheckInLocation { get; set; }
        public DateTime CheckInDate { get; set; }
        public string CheckInTime { get; set; }
    }

    public class Transport_OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderID { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string IMAPNumber { get; set; }
        public string Registration { get; set; }
        public string SellerName { get; set; }
        public string VendorName { get; set; }
        public string StorageLocation { get; set; }
        public string Destination { get; set; }
        public string MakeDesc { get; set; }
        public string ModelDesc { get; set; }
        public string Variants { get; set; }
        public string ChassisNo { get; set; }
        public string PickupRoofType { get; set; }
        public decimal Cost { get; set; }
        public decimal FeeCharged { get; set; }
    }

    public class Vendor
    {
        public int VendorID { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string Email { get; set; }
        public string SecondaryEmails { get; set; }
        public string Remark { get; set; }
    }

    public class Location
    {
        public int LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string Email { get; set; }
    }

    public class StatusDetailEntry
    {
        public int Status { get; set; }
        public string IMAPNumber { get; set; }
        public string Registration { get; set; }
        public string SellerName { get; set; }
        public string VendorName { get; set; }
        public string StorageLocation { get; set; }
        public string Destination { get; set; }
    }

    public class StatusDetailJson
    {
        public List<StatusDetailEntry> Overall { get; set; }
        public List<StatusDetailEntry> PendingPickup { get; set; }
        public List<StatusDetailEntry> Transporting { get; set; }
        public List<StatusDetailEntry> Arrived { get; set; }
    }

    //public class StatusEntry
    //{
    //    public string name { get; set; }
    //    public int count { get; set; }
    //}

    //public class StatusCategory
    //{
    //    public decimal percentage {  get; set; }
    //    public List<StatusEntry> category { get; set; }
    //}

    //public class StatusCategoryJson
    //{
    //    public StatusCategory Total { get; set; }
    //    public StatusCategory Pending { get; set; }
    //    public StatusCategory Checkout { get; set; }
    //    public StatusCategory Checkin { get; set; }
    //}

}
