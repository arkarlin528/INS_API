using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motto_Vehicle_DataFeed.DAO
{
    public class Status_Type
    {
        public int StatusTypeID { get; set; }
        public string StatusName { get; set; }
        public string StatusName_TH { get; set; }
        public string StatusType { get; set; }
    }

    public class Transport_ATS_Log
    {
        public int id { get; set; }
        public int TxnType { get; set; }
        public DateTime TxnDate { get; set; }
        public string TxnTime{ get; set; }
        public string VehicleNumber { get; set; }
        public string TxnLocation { get; set; }
        public string StatusUpdateBy { get; set; }
        public int ResponseStatus { get; set; }
        public string ResponseData { get; set; }
        public string OtherResponses { get; set; }
    }

    public class Check_Stock
    {
        public int ID { get; set; }
        public DateTime TxnDate { get; set; }
        public string TxnTime { get; set; }
        public string VehicleNumber { get; set; }
        public string CurrentLocation { get; set; }
        public string ActualLocation { get; set; }
        public string Lattitude { get; set; }
        public string Longitude { get; set; }
        public string CheckBy { get; set; }
    }

    #region OperationDashboard
    public class BindOprDashboardData
    {
        public string AuctionDateCode { get; set; }
        public DateTime? AuctionDate { get; set; }
        public int AuctionDay { get { return AuctionDate.Value.Day; } }
        public string AuctionMonth
        {
            get
            {
                string strRtnValue = "";
                switch (AuctionDate.Value.Month)
                {
                    case 1: strRtnValue = "Jan"; break;
                    case 2: strRtnValue = "Feb"; break;
                    case 3: strRtnValue = "Mar"; break;
                    case 4: strRtnValue = "Apr"; break;
                    case 5: strRtnValue = "May"; break;
                    case 6: strRtnValue = "June"; break;
                    case 7: strRtnValue = "July"; break;
                    case 8: strRtnValue = "Aug"; break;
                    case 9: strRtnValue = "Sept"; break;
                    case 10: strRtnValue = "Oct"; break;
                    case 11: strRtnValue = "Nov"; break;
                    case 12: strRtnValue = "Dec"; break;
                    default: strRtnValue = ""; break;
                }

                return strRtnValue;
            }
        }
        public string AuctionCode { get; set; }
        public string Location { get; set; }
        public string Office { get; set; }

        public List<OperationSellerInfo> SellerInfos { get; set; }

        public List<OperationIconInfo> IconInfos { get; set; }
    }

    public class OperationSellerInfo
    {
        public string Seller { get; set; }
        public string CompanyName { get; set; }
        public string SellingCategory { get; set; }
        public int TotalOffer { get; set; }
        public int Reinspection { get; set; }
        public string SellingCode { get; set; }
        public decimal CompletePercentage { get; set; }
    }

    public class OperationIconInfo
    {
        public string SellingCategory { get; set; }
        public int Count { get; set; }
        public string Icon { get; set; }
    }

    public class OprDashboardData
    {
        public string AuctionDateCode { get; set; }
        public DateTime AuctionDate { get; set; }
        public string AuctionCode { get; set; }
        public string Seller { get; set; }
        public string CompanyName { get; set; }
        public string SellingCategory { get; set; }
        public int TotalOffer { get; set; }
        public int Reinspection { get; set; }
        public string SellingCode { get; set; }
        public decimal CompletePercentage { get; set; }
        public string AuctionLocation_BU { get; set; }
        public string OfficeEn { get; set; }
    }

    public class SellingCategory
    {
        public string Code { get; set; }

        public string Icon { get; set; }
    }

    public class SellingCategory_Code_Name
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }

    public class AuctionDate_Combo
    {
        public string DateStr { get; set; }

        public DateTime Date { get; set; }
        public string Value
        {
            get
            {
                return Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));
            }
        }
    }

    public class AuctionDate
    {
        public string DateStr
        {
            get
            {
                return Date.ToString("dd MMM yyyy");
            }
        }

        public DateTime Date { get; set; }

        public string Value
        {
            get
            {
                return Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));
            }
        }
    }

    public class FilterSeller
    {
        public string SellerCode { get; set; }
        public string SellerName { get; set; }
    }
    public class FilterSellingCategory
    {
        public string SellingCategory { get; set; }
        public string Category { get; set; }
    }

    #region InspectorDashboard

    public class OverallLocationPerformance
    {
        public string Location { get; set; }
        public int Month_1 { get; set; }
        public int Month_2 { get; set; }
        public int Month_3 { get; set; }
        public int Month_4 { get; set; }
        public int Month_5 { get; set; }
        public int Month_6 { get; set; }
        public int All_Month_Total
        {
            get
            {
                return Month_1 + Month_2 + Month_3 + Month_4 + Month_5 + Month_6;
            }
        }
    }

    public class InspectorDataResult
    {
        public string InspectorName { get; set; }
        public string Location { get; set; }
        public string InspectionCategory { get; set; }
        public string VehicleType { get; set; }
        public int Month_1 { get; set; }
        public int Month_2 { get; set; }
        public int Month_3 { get; set; }
        public int Month_4 { get; set; }
        public int Month_5 { get; set; }
        public int Month_6 { get; set; }
        public int Month_Total { get; set; }
    }
    public class InspectorPerformance
    {
        public string InspectorName { get; set; }
        public string Location { get; set; }
        public List<InspectionDetail> Detail { get; set; }

        public InspectorPerformance(string inspectorName, string location, List<InspectionDetail> detail)
        {
            InspectorName = inspectorName;
            Location = location;
            Detail = detail;
        }
    }

    public class InspectionDetail
    {
        public string InspectionType { get; set; }
        public string InspectionTypeDisplay { get; set; }
        public List<InspectionPivot> inspectionPivots { get; set; }
        public InspectionDetail(string inspectionType, string inspectionTypeDisplay, List<InspectionPivot> inspectionPivots)
        {
            InspectionType = inspectionType;
            InspectionTypeDisplay = inspectionTypeDisplay;
            this.inspectionPivots = inspectionPivots;
        }
    }
    public class InspectionPivot
    {
        public string VehicleType { get; set; }
        public int Month_1 { get; set; }
        public int Month_2 { get; set; }
        public int Month_3 { get; set; }
        public int Month_4 { get; set; }
        public int Month_5 { get; set; }
        public int Month_6 { get; set; }
        public int All_Month_Total
        {
            get
            {
                return Month_1 + Month_2 + Month_3 + Month_4 + Month_5 + Month_6;
            }
        }
        public InspectionPivot(string vehicleType, int month_1, int month_2, int month_3, int month_4, int month_5, int month_6)
        {
            VehicleType = vehicleType;
            Month_1 = month_1;
            Month_2 = month_2;
            Month_3 = month_3;
            Month_4 = month_4;
            Month_5 = month_5;
            Month_6 = month_6;
        }
    }
    public class Inspector { public string InspectorName { get; set; } }
    public class Inspection_Month { public string DataValue { get; set; } public string DisplayValue { get; set; } }
    public class Inspection_StorageLocation { public string StorageLocation { get; set; } }
    public class MonthHeader { public string MonthName { get; set; } }
    #endregion

    #endregion
}
