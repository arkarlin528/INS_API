using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using Motto_Vehicle_DataFeed.DAO;

namespace Motto_Vehicle_DataFeed
{
    public class AuctionData_DataFeed
    {
        #region getUpcomingAuctionDataStatus
        public List<AuctionHeader_DAO> getUpcomingAuctionDataStatus()
        {
            List<AuctionHeader_DAO> rtnValue = new List<AuctionHeader_DAO>(); 
            using (var context = new MAMS_dataFeedContext())
            {
                List<AuctionData_DAO> allDataDetail = new List<AuctionData_DAO>();
                context.Database.CommandTimeout = 300000;

                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }
                allDataDetail = context.Database.SqlQuery<AuctionData_DAO>(Auction_Query.upcomingAuction).OrderBy(p => p.AuctionDate).ThenBy(p=>p.AuctionCode).ToList();

                var distinctAuction = allDataDetail.Select(p => p.AuctionCode).Distinct().ToList();
                if(distinctAuction.Any())
                {
                    for (int i = 0; i < distinctAuction.Count(); i++)
                    {
                        AuctionHeader_DAO oHeader = new AuctionHeader_DAO();
                       

                        List<AuctionData_DAO> lstDetail = allDataDetail.Where(row=> row.AuctionCode == distinctAuction[i]).ToList();
                        List<AuctionData_DAO> lstDataComplete = lstDetail.Where(row => row.DataStatus == 1).ToList();
                        
                        oHeader.AuctionCode = distinctAuction[i];
                        oHeader.TotalVehicle = lstDetail.Count;
                        oHeader.AuctionDetail = lstDetail;
                        oHeader.AuctionDate = lstDetail[0].AuctionDate;
                        oHeader.AuctionLane = lstDetail[0].LaneNumber;
                        oHeader.TotalDataComplete = lstDataComplete.Count;
                        oHeader.TotatDataInComplete = lstDetail.Count - lstDataComplete.Count;
                        oHeader.PercentageDataComplete = Math.Round((Convert.ToDecimal(lstDataComplete.Count) / (lstDetail.Count == 0 ? 1 : Convert.ToDecimal(lstDetail.Count))) * 100,2);
                        oHeader.AuctionTime = "";

                        var sellingCategoryGroup = lstDetail
                                                    .GroupBy(p => new { p.SellingCategoryCode, p.SellingCategory })
                                                    .Select(g => new VehicleCategory_DAO()
                                                    {
                                                        SellingCatgoryCode = g.Key.SellingCategoryCode,
                                                        SellingCategory = g.Key.SellingCategory,
                                                        TotalVehicle = g.Count(),
                                                        Icon = GetIcon(g.Key.SellingCategoryCode)
                                                    }).ToList();


                        oHeader.AuctionDetail = lstDetail;
                        oHeader.VehicleCategory = sellingCategoryGroup;
                        rtnValue.Add(oHeader);
                    }
                }
                
            }
            return rtnValue;
        }
        #endregion

        #region GetIcon
        private string GetIcon(string code)
        {
            if (string.IsNullOrEmpty(code))
                return "icon-ot";

            var item = SellingCategory.FirstOrDefault(i => i.Code.Trim() == code.ToUpper().Trim());
            if (item == null)
                return "icon-ot";

            return item.Icon;
        }
        #endregion

        #region SellingCategory
        private SellingCategory[] SellingCategory = new SellingCategory[]
        {
            new SellingCategory { Code = "CA",      Icon = "icon-ca"},
            new SellingCategory { Code = "PU",      Icon = "icon-pu"},
            new SellingCategory { Code = "SA",      Icon = "icon-sa"},
            new SellingCategory { Code = "TRK",     Icon = "icon-trk"},
            new SellingCategory { Code = "KBT",     Icon = "icon-kbt"},
            new SellingCategory { Code = "YAN",     Icon = "icon-yan"},
            new SellingCategory { Code = "SOL",     Icon = "icon-yan"},
            new SellingCategory { Code = "OT",      Icon = "icon-ot"},
            new SellingCategory { Code = "4WD",     Icon = "icon-4wd"},
            new SellingCategory { Code = "MB",      Icon = "icon-mb"},
            new SellingCategory { Code = "BO",      Icon = "icon-bo"},
            new SellingCategory { Code = "FD1",     Icon = "icon-fd1"},
            new SellingCategory { Code = "MCE",     Icon = "icon-mce"},
            new SellingCategory { Code = "TRK",     Icon = "icon-trk"},
            new SellingCategory { Code = "FD2",     Icon = "icon-fd2"},
            new SellingCategory { Code = "20K",     Icon = "icon-20k"},
            new SellingCategory { Code = "MB",      Icon = "icon-mb"},
            new SellingCategory { Code = "AE",      Icon = "icon-ae"},
            new SellingCategory { Code = "T10",     Icon = "icon-t10"},
            new SellingCategory { Code = "YAN",     Icon = "icon-yan"},
            new SellingCategory { Code = "ISE",     Icon = "icon-kbt"},
            new SellingCategory { Code = "KIO",     Icon = "icon-kbt"},
        };
        #endregion
    }

    #region Auction_Query
    public class Auction_Query
    {
        public static string upcomingAuction = "SELECT * FROM MAMS_DataDashboard_Detail('') ORDER BY AuctionCode,AuctionDate";
    }
    #endregion

    #region AuctionHeader_DAO
    public class AuctionHeader_DAO
    {
        public string AuctionCode { get; set; }
        public DateTime AuctionDate { get; set; }
        public int TotalVehicle { get; set; }
        public string AuctionTime { get; set; }
        public string AuctionLane { get; set; }
        public int TotalDataComplete { get; set; }
        public int TotatDataInComplete { get; set; }
        public decimal PercentageDataComplete { get; set; }
        public List<AuctionData_DAO> AuctionDetail { get; set; }
        public List<VehicleCategory_DAO> VehicleCategory { get; set; }

        public AuctionHeader_DAO()
        {
            AuctionCode = "";
            AuctionDate = new DateTime(1970, 1, 1);
            TotalVehicle = 0;
            AuctionTime = "";
            AuctionLane = "";
            AuctionDetail = new List<AuctionData_DAO>();
            VehicleCategory = new List<VehicleCategory_DAO>();
        }
    }
    #endregion

    #region VehicleCategory_DAO
    public class VehicleCategory_DAO
    {
        public string SellingCatgoryCode { get; set; }
        public string SellingCategory { get; set; }
        public string Icon { get; set; }
        public int TotalVehicle { get; set; }

        public VehicleCategory_DAO()
        {
            SellingCategory = "";
            SellingCategory = "";
            Icon = "";
            TotalVehicle = 0;
        }
    }
    #endregion

    #region AuctionData_DAO
    public class AuctionData_DAO
    {
        public string AuctionCode { get; set; }
        public DateTime AuctionDate { get; set; }
        public string Vehicle { get; set; }
        public string Registration { get; set; }
        public string Make { get; set; }
        public string Model_BU { get; set; }
        public string Variants { get; set; }
        public string Colour_BU { get; set; }
        public string Body { get; set; }
        public string SellingCategory { get; set; }
        public string BuildYear { get; set; }
        public string Mileage { get; set; }
        public string CatalogueDesc_LO { get; set; }
        public string CatalogueDesc_BU { get; set; }
        public decimal ReservePrice { get; set; }
        public int BookInDoc { get; set; }
        public int BookInPhoto { get; set; }
        public int OnlinePhoto { get; set; }
        public int Inspection { get; set; }
        public int TitleBook { get; set; }
        public int DataStatus { get; set; }
        public string SellingCategoryCode { get; set; }
        public string BodyCode { get; set; }
        public string LaneNumber { get; set; }
        public string AuctionLocation { get; set; }
    }
    #endregion
}
