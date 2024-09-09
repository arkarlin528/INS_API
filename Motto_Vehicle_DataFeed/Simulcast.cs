using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motto_Vehicle_DataFeed
{
    public class Simulcast_DATAFEED
    {
        public Simulcast_DATAFEED() { }

        #region GetTodayAuctionEnquiry
        public DataTable GetTodayAuctionEnquiry()
        {
            DataTable result = new DataTable();
            try
            {
                using (var context = new MAMS_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Simulcast_Query.Get_TodayAuctionEnquiry;

                        command.Parameters.Add(new SqlParameter("@AuctionDate", DateTime.Now.ToString("yyyy-MM-dd")));

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
    }

    #region Simulcast_Query
    public class Simulcast_Query
    {

        public static string Get_TodayAuctionEnquiry = $@"exec SIMULCAST_TodayAuctionEnquiry @AuctionDate";
       
    }
    #endregion
}
