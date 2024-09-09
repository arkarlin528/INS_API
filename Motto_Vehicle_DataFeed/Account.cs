using MOTTO_DATAFEED.DAO;
using Motto_Vehicle_DataFeed.DAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Globalization;

namespace Motto_Vehicle_DataFeed
{
    public class Account_DATAFEED
    {
        public Account_DATAFEED() { }

        #region GetAccountReconcilationReport
        public DataTable GetAccountReconcilationReport(string AuctionDate, string AuctionCode, string Seller,string SalvageType)
        {
            DataTable result = new DataTable();
            try
            {
                //string AuctionDate = (dtData.Rows[0]["auctionDate"] == null ? "" : dtData.Rows[0]["auctionDate"].ToString());
                //string AuctionCode = (dtData.Rows[0]["auctionCode"] == null ? "" : dtData.Rows[0]["auctionCode"].ToString());
                //string Seller = (dtData.Rows[0]["seller"] == null ? "" : dtData.Rows[0]["seller"].ToString());

                using (var context = new MAMS_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Account_Query.Get_AccountReconcilation_Report;

                        command.Parameters.Add(new SqlParameter("@AuctionDate", AuctionDate));
                        command.Parameters.Add(new SqlParameter("@AuctionCode", AuctionCode));
                        command.Parameters.Add(new SqlParameter("@Seller", Seller));
                        command.Parameters.Add(new SqlParameter("@SalvageType", SalvageType));

                        using (var reader = command.ExecuteReader())
                        {
                            result.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        #endregion

        #region GetAuctionDate
        public DataTable GetAuctionDate()
        {
            DataTable result = new DataTable();
            try
            {
                using (var context = new dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Account_Query.Get_AuctionDate;

                        using (var reader = command.ExecuteReader())
                        {
                            result.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        #endregion

        #region GetAuctionCodeByDate
        public DataTable GetAuctionCodeByDate(string date)
        {
            DataTable result = new DataTable();
            try
            {
                DateTime auctionDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                using (var context = new dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Account_Query.Get_AuctionCodeByDate;

                        command.Parameters.Add(new SqlParameter("@ParaDate", auctionDate));

                        using (var reader = command.ExecuteReader())
                        {
                            result.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        #endregion

        #region GetSellerByCode
        public DataTable GetSellerByCode(string code)
        {
            DataTable result = new DataTable();
            try
            {
                using (var context = new dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Account_Query.Get_SellerByCode;

                        command.Parameters.Add(new SqlParameter("@AuctionCode", code));

                        using (var reader = command.ExecuteReader())
                        {
                            result.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        #endregion

        #region ConvertDataToRaw
        public List<Account_Reconciliation_Raw> ConvertDataToRaw(DataTable dt)
        {
            List<Account_Reconciliation_Raw> tmpData = new List<Account_Reconciliation_Raw>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Account_Reconciliation_Raw raw = new Account_Reconciliation_Raw();
                raw.ID = int.Parse(dt.Rows[i]["ID"] == null ? "0" : dt.Rows[i]["ID"].ToString());
                raw.IMAP = (dt.Rows[i]["IMAP"] == null ? "" : dt.Rows[i]["IMAP"].ToString());
                raw.Seller = (dt.Rows[i]["Seller"] == null ? "" : dt.Rows[i]["Seller"].ToString());
                raw.NoOfBuyer = (dt.Rows[i]["NoOfBuyer"] == null ? "" : dt.Rows[i]["NoOfBuyer"].ToString());
                raw.BidNo = (dt.Rows[i]["BidNo"] == null ? "" : dt.Rows[i]["BidNo"].ToString());
                raw.Lot = int.Parse(dt.Rows[i]["Lot"] == null ? "" : dt.Rows[i]["Lot"].ToString());
                raw.SellerRef = (dt.Rows[i]["SellerRef"] == null ? "" : dt.Rows[i]["SellerRef"].ToString());
                raw.Regist = (dt.Rows[i]["Regist"] == null ? "" : dt.Rows[i]["Regist"].ToString());
                raw.BuildYear = (dt.Rows[i]["BuildYear"] == null ? "" : dt.Rows[i]["BuildYear"].ToString());
                raw.Make = (dt.Rows[i]["Make"] == null ? "" : dt.Rows[i]["Make"].ToString());
                raw.ModelDesc = (dt.Rows[i]["ModelDesc"] == null ? "" : dt.Rows[i]["ModelDesc"].ToString());
                raw.Variants = (dt.Rows[i]["Variants"] == null ? "" : dt.Rows[i]["Variants"].ToString());
                raw.ReservePrice = decimal.Parse(dt.Rows[i]["ReservePrice"] == null ? "0" : dt.Rows[i]["ReservePrice"].ToString());
                raw.SoldPrice = decimal.Parse(dt.Rows[i]["SoldPrice"] == null ? "0" : dt.Rows[i]["SoldPrice"].ToString());
                raw.Variance = decimal.Parse(dt.Rows[i]["Variance"] == null ? "0" : dt.Rows[i]["Variance"].ToString());
                raw.PercentageForSold = decimal.Parse(dt.Rows[i]["PercentageForSold"] == null ? "0" : dt.Rows[i]["PercentageForSold"].ToString());
                raw.SoldPriceExclTax = decimal.Parse(dt.Rows[i]["SoldPriceExclTax"] == null ? "0" : dt.Rows[i]["SoldPriceExclTax"].ToString());
                raw.VAT = decimal.Parse(dt.Rows[i]["VAT"] == null ? "0" : dt.Rows[i]["VAT"].ToString());
                raw.SellingFee = decimal.Parse(dt.Rows[i]["SellingFee"] == null ? "0" : dt.Rows[i]["SellingFee"].ToString());
                raw.Detailing = decimal.Parse(dt.Rows[i]["Detailing"] == null ? "0" : dt.Rows[i]["Detailing"].ToString());
                raw.inspection = decimal.Parse(dt.Rows[i]["inspection"] == null ? "0" : dt.Rows[i]["inspection"].ToString());
                raw.SubTotal = decimal.Parse(dt.Rows[i]["SubTotal"] == null ? "0" : dt.Rows[i]["SubTotal"].ToString());
                raw.ServicesVAT = decimal.Parse(dt.Rows[i]["ServicesVAT"] == null ? "0" : dt.Rows[i]["ServicesVAT"].ToString());
                raw.WHTax = decimal.Parse(dt.Rows[i]["WHTax"] == null ? "0" : dt.Rows[i]["WHTax"].ToString());
                raw.Total = decimal.Parse(dt.Rows[i]["Total"] == null ? "0" : dt.Rows[i]["Total"].ToString());
                raw.AuctionCode = (dt.Rows[i]["AuctionCode"] == null ? "" : dt.Rows[i]["AuctionCode"].ToString());
                raw.AuctionTime = (dt.Rows[i]["AuctionTime"] == null ? "" : dt.Rows[i]["AuctionTime"].ToString());
                raw.AuctionDate = DateTime.Parse(dt.Rows[i]["AuctionDate"] == null ? DateTime.Now.ToString("yyyy-MM-dd") : dt.Rows[i]["AuctionDate"].ToString());
                raw.PaymentStatus = (dt.Rows[i]["PaymentStatus"] == null ? "" : dt.Rows[i]["PaymentStatus"].ToString());
                raw.SellerNo = (dt.Rows[i]["SellerNo"] == null ? "" : dt.Rows[i]["SellerNo"].ToString());
                raw.SellerCode = (dt.Rows[i]["SellerCode"] == null ? "" : dt.Rows[i]["SellerCode"].ToString());
                tmpData.Add(raw);
            }
            return tmpData;
        }
        #endregion
    }

    #region Account_Query
    public class Account_Query
    {
        public static string Get_AccountReconcilation_Report = $@"exec Account_ReconcilationReport @AuctionDate,@Seller,@AuctionCode,@SalvageType";

        public static string Get_AuctionDate = $@"SELECT distinct CONVERT(char(10), AuctionDate,126) as auctionDate FROM IMAP.dbo.Auctions WHERE AuctionDate < GETDATE() ORDER BY AuctionDate DESC";
        public static string Get_AuctionCodeByDate = $@"SELECT AuctionCode FROM IMAP.dbo.Auctions WHERE CONVERT(varchar(10),AuctionDate,112) = CONVERT(varchar(10),@ParaDate,112) ORDER BY AuctionCode";
        public static string Get_SellerByCode = $@"SELECT DISTINCT c.CompanyName_BU seller,c.Customer sellerCode
                                                    FROM
                                                    (SELECT * FROM IMAP.dbo.AuctionVehicles WHERE AuctionCode = @AuctionCode) AV
                                                    LEFT JOIN IMAP.dbo.Vehicles v ON v.Vehicle = AV.Vehicle
                                                    LEFT JOIN IMAP.dbo.Customers c ON c.Customer = v.Seller
                                                    WHERE ISNULL(c.Customer,'') <> ''
                                                    ORDER BY c.CompanyName_BU";

        public static string Get_FilterSellers = $@"SELECT DISTINCT c.CompanyName_BU seller,c.Customer sellerCode
                                                    FROM
                                                    (SELECT * FROM IMAP.dbo.AuctionVehicles ) AV
                                                    LEFT JOIN IMAP.dbo.Vehicles v ON v.Vehicle = AV.Vehicle
                                                    LEFT JOIN IMAP.dbo.Customers c ON c.Customer = v.Seller
                                                    WHERE ISNULL(c.Customer,'') <> ''
                                                    ORDER BY c.CompanyName_BU";
    }
    #endregion

    #region Account_Reconciliation_Raw
    public class Account_Reconciliation_Raw
    {
        public int ID { get; set; }
        public string IMAP { get; set; }
        public string Seller { get; set; }
        public string NoOfBuyer { get; set; }
        public string BidNo { get; set; }
        public int Lot { get; set; }
        public string SellerRef { get; set; }
        public string Regist { get; set; }
        public string BuildYear { get; set; }
        public string Make { get; set; }
        public string ModelDesc { get; set; }
        public string Variants { get; set; }
        public decimal ReservePrice { get; set; }
        public decimal SoldPrice { get; set; }
        public decimal Variance { get; set; }
        public decimal PercentageForSold { get; set; }
        public decimal SoldPriceExclTax { get; set; }
        public decimal VAT { get; set; }
        public decimal SellingFee { get; set; }
        public decimal Detailing { get; set; }
        public decimal inspection { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ServicesVAT { get; set; }
        public decimal WHTax { get; set; }
        public decimal Total { get; set; }
        public string AuctionCode { get; set; }
        public string AuctionTime { get; set; }
        public DateTime AuctionDate { get; set; }
        public string PaymentStatus { get; set; }
        public string SellerNo { get; set; }
        public string SellerCode { get; set; }
    }
    #endregion
}
