using MOTTO_DATAFEED.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using  System.Drawing;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using System.Data.Entity.Core.Objects;
using System.Configuration;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Drawing.Drawing2D;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Reflection.Emit;
using System.Globalization;
using System.Web.Http.Results;
using static Motto_Vehicle_DataFeed.Transport_DATAFEED;

namespace Motto_Vehicle_DataFeed
{
    #region ATS
    public class ATS_DATAFEED
    {
        public ATS_DATAFEED() { }

        #region LoadVehicleData
        public List<ATS_MOTTO_Vehicle> LoadVehicleData(string LoadType)
        {
            try
            {
                var context = new dataFeedContext();
                context.Database.CommandTimeout = 300000;
                
                var conn = context.Database.Connection;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }
                //If LoadType is all, clear snapshot
                if (LoadType.ToLower() == "all")
                {
                    context.Database.ExecuteSqlCommand(ATS_Query.Clear_Vehicle_Snapshot);
                }

                //LoadData
                DataTable dtVehicle = new DataTable();
                var query = ATS_Query.Vehicle_Load_Data;
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    using (var reader = cmd.ExecuteReader())
                    {
                        dtVehicle.Load(reader);
                    }
                }
                List<ATS_MOTTO_Vehicle> vehicleList = ATS_Utility.convertToVehicleList(dtVehicle);
                return vehicleList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        #endregion

        #region getVehicleData
        public List<ATS_MOTTO_Vehicle> getVehicleData()
        {
            try
            {
                var context = new dataFeedContext();
                context.Database.CommandTimeout = 300000;

                var conn = context.Database.Connection;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }
                

                //LoadData
                DataTable dtVehicle = new DataTable();
                var query = ATS_Query.Vehicle_Get;
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    using (var reader = cmd.ExecuteReader())
                    {
                        dtVehicle.Load(reader);
                    }
                }
                List<ATS_MOTTO_Vehicle> vehicleList = ATS_Utility.convertToVehicleList(dtVehicle);
                return vehicleList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        #endregion

        #region LoadLocationData
        public List<ATS_MOTTO_Location> LoadLocationData(string LoadType)
        {
            try
            {
                var context = new dataFeedContext();
                context.Database.CommandTimeout = 300000;

                var conn = context.Database.Connection;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }
                //If LoadType is all, clear snapshot
                if (LoadType.ToLower() == "all")
                {
                    context.Database.ExecuteSqlCommand(ATS_Query.Clear_Location_Snapshot);
                }

                //LoadData
                DataTable dtLocatiopnResult = new DataTable();
                var query = ATS_Query.Location_Load_Data;
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    using (var reader = cmd.ExecuteReader())
                    {
                        dtLocatiopnResult.Load(reader);
                    }
                }
                List<ATS_MOTTO_Location> locationList = ATS_Utility.convertToLocationList(dtLocatiopnResult);
                return locationList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        #endregion

        #region getLocationData
        public List<ATS_MOTTO_Location> getLocationData()
        {
            try
            {
                var context = new dataFeedContext();
                context.Database.CommandTimeout = 300000;

                var conn = context.Database.Connection;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }


                //LoadData
                DataTable dtLocatiopnResult = new DataTable();
                var query = ATS_Query.Location_Get;
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    using (var reader = cmd.ExecuteReader())
                    {
                        dtLocatiopnResult.Load(reader);
                    }
                }
                List<ATS_MOTTO_Location> locationList = ATS_Utility.convertToLocationList(dtLocatiopnResult);
                return locationList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        #endregion

        #region getLogData
        public List<ATS_MOTTO_Vehicle> getLogData(DateTime dtm,string strSource)
        {
            try
            {
                var context = new dataFeedContext();
                context.Database.CommandTimeout = 300000;
                var query = ATS_Query.Vehicle_Get;
                var conn = context.Database.Connection;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }
                DataTable dtVehicle = new DataTable();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@LogDate", dtm));
                    cmd.Parameters.Add(new SqlParameter("@TypeOfData", strSource));
                    cmd.Parameters.Add(new SqlParameter("@RequestBy", "ATS"));
                    using (var reader = cmd.ExecuteReader())
                    {
                        dtVehicle.Load(reader);
                    }
                }
                List<ATS_MOTTO_Vehicle> locationList = ATS_Utility.convertToVehicleList(dtVehicle);
                return locationList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        #endregion

        #region Logger
        public void Logger(string strData, string strSource,int totalRecordCount)
        {
            try
            {
                var context = new dataFeedContext();
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }               
                var insertParameter = new List<SqlParameter> {
                        new SqlParameter("@LogDate",DateTime.Now),
                        new SqlParameter("@TypeOfData",strSource),
                        new SqlParameter("@DataJson",strData),
                        new SqlParameter("@TotalRecordCount",totalRecordCount),
                        new SqlParameter("@RequestBy","ATS")
                     };
                context.Database.ExecuteSqlCommand(ATS_Query.Logger_Insert, insertParameter.ToArray());
            }
            catch
            {
            }
        }
        #endregion

        #region ClearCache
        public void ClearCache()
        {
            try
            {
                var context = new dataFeedContext();
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }
               
                context.Database.ExecuteSqlCommand(ATS_Query.Clear_Cache);
            }
            catch
            {
            }
        }
        #endregion
    }
    #endregion

    #region Transport
    public class Transport_DATAFEED
    {
        public Transport_DATAFEED() { }

        #region User
        #region SaveTransportUser
        public int SaveTransportUser(DataTable dtData)
        {
            int Id = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Transport_User User = new Transport_User();
                    User.UserName = (dtData.Rows[i]["userName"] == null ? "" : dtData.Rows[i]["userName"].ToString());
                    User.UserEmail = (dtData.Rows[i]["userEmail"] == null ? "" : dtData.Rows[i]["userEmail"].ToString());
                    User.LoginName = (dtData.Rows[i]["login"] == null ? "" : dtData.Rows[i]["login"].ToString());
                    User.Password = (dtData.Rows[i]["password"] == null ? "" : dtData.Rows[i]["password"].ToString());
                    User.DepartmentID = int.Parse(dtData.Rows[i]["department"] == null ? "0" : dtData.Rows[i]["department"].ToString());
                    User.UserType = int.Parse(dtData.Rows[i]["userType"] == null ? "0" : dtData.Rows[i]["userType"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var UserParam = new List<SqlParameter> {
                    new SqlParameter("@UserName",User.UserName),
                    new SqlParameter("@LoginName",User.LoginName),
                    new SqlParameter("@UserEmail",User.UserEmail),
                    new SqlParameter("@Password",User.Password),
                    new SqlParameter("@DepartmentID",User.DepartmentID),
                    new SqlParameter("@UserType",User.UserType)
                    };

                    #endregion Parameter

                    DataTable chkDuplicate = new DataTable();
                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Transport_Query.Check_Duplicate_User;

                        #region Parameters

                        command.Parameters.Add(new SqlParameter("@LoginName", User.LoginName));
                        command.Parameters.Add(new SqlParameter("@UserEmail", User.UserEmail));
                        command.Parameters.Add(new SqlParameter("@UserID", Id));
                        #endregion Parameters

                        using (var reader = command.ExecuteReader())
                        {
                            chkDuplicate.Load(reader);
                        }
                    }
                    if (chkDuplicate.Rows.Count == 0)
                    {
                        Id = context.Database.SqlQuery<int>(Transport_Query.Save_Transport_User, UserParam.ToArray()).SingleOrDefault();
                    }
                    return Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
            return Id;
        }
        #endregion

        #region UpdateTransportUser
        public int UpdateTransportUser(DataTable dtData)
        {
            int Id = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Transport_User User = new Transport_User();
                    User.UserID = int.Parse(dtData.Rows[i]["userid"] == null ? "0" : dtData.Rows[i]["userid"].ToString());
                    User.UserName = (dtData.Rows[i]["userName"] == null ? "" : dtData.Rows[i]["userName"].ToString());
                    User.UserEmail = (dtData.Rows[i]["userEmail"] == null ? "" : dtData.Rows[i]["userEmail"].ToString());
                    User.LoginName = (dtData.Rows[i]["login"] == null ? "" : dtData.Rows[i]["login"].ToString());
                    //User.Password = (dtData.Rows[i]["password"] == null ? "" : dtData.Rows[i]["password"].ToString());
                    User.DepartmentID = int.Parse(dtData.Rows[i]["department"] == null ? "0" : dtData.Rows[i]["department"].ToString());
                    User.UserType = int.Parse(dtData.Rows[i]["userType"] == null ? "0" : dtData.Rows[i]["userType"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var UserParam = new List<SqlParameter> {
                    new SqlParameter("@UserID",User.UserID),
                    new SqlParameter("@UserName",User.UserName),
                    new SqlParameter("@LoginName",User.LoginName),
                    new SqlParameter("@UserEmail",User.UserEmail),
                    //new SqlParameter("@Password",User.Password),
                    new SqlParameter("@DepartmentID",User.DepartmentID),
                    new SqlParameter("@UserType",User.UserType)
                    };

                    #endregion Parameter
                    DataTable chkDuplicate = new DataTable();
                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Transport_Query.Check_Duplicate_User;

                        #region Parameters

                        command.Parameters.Add(new SqlParameter("@LoginName", User.LoginName));
                        command.Parameters.Add(new SqlParameter("@UserEmail", User.UserEmail));
                        command.Parameters.Add(new SqlParameter("@UserID", User.UserID));
                        #endregion Parameters

                        using (var reader = command.ExecuteReader())
                        {
                            chkDuplicate.Load(reader);
                        }
                    }
                    if (chkDuplicate.Rows.Count == 0)
                    {
                        context.Database.ExecuteSqlCommand(Transport_Query.Update_Transport_User, UserParam.ToArray());
                        Id++;
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
            return Id;
        }
        #endregion

        #region UpdatePassword
        public void UpdatePassword(DataTable dtData)
        {
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Transport_User User = new Transport_User();
                    User.UserID = int.Parse(dtData.Rows[i]["userid"] == null ? "0" : dtData.Rows[i]["userid"].ToString());
                    User.Password = (dtData.Rows[i]["password"] == null ? "" : dtData.Rows[i]["password"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var UserParam = new List<SqlParameter> {
                    new SqlParameter("@UserID",User.UserID),
                    new SqlParameter("@Password",User.Password),
                    };

                    #endregion Parameter

                    context.Database.ExecuteSqlCommand(Transport_Query.Update_Password, UserParam.ToArray());
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region DeleteTransportUser
        public void DeleteTransportUser(DataTable dtData)
        {
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Transport_User User = new Transport_User();
                    User.UserID = int.Parse(dtData.Rows[i]["userid"] == null ? "0" : dtData.Rows[i]["userid"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var UserParam = new List<SqlParameter> {
                    new SqlParameter("@UserID",User.UserID)
                    };

                    #endregion Parameter

                    context.Database.ExecuteSqlCommand(Transport_Query.Delete_Transport_User, UserParam.ToArray());
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region LoginTransportUser
        public DataTable LoginTransportUser(DataTable dtData)
        {
            DataTable resultTable = new DataTable();
            try
            {
                Transport_User User = new Transport_User();
                User.LoginName = (dtData.Rows[0]["login"] == null ? "" : dtData.Rows[0]["login"].ToString());
                User.Password = (dtData.Rows[0]["password"] == null ? "" : dtData.Rows[0]["password"].ToString());

                using (var context = new dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Transport_Query.Login_Transport_User;

                        #region Parameters

                        command.Parameters.Add(new SqlParameter("@LoginName", User.LoginName));
                        command.Parameters.Add(new SqlParameter("@Password", User.Password));

                        #endregion Parameters

                        using (var reader = command.ExecuteReader())
                        {
                            resultTable.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
            return resultTable;
        }
        #endregion

        #region GetUserList
        public DataTable GetUserList()
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
                        command.CommandText = Transport_Query.Get_User_List;

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
        #endregion

        #region Dashboard
        #region GetTransportStatusForCategorydb
        public string GetTransportStatusForCategorydb(DataTable dtData)
        {
            string result = "";
            double dFromDate = Convert.ToDouble(dtData.Rows[0]["fromDate"] == null ? 0 : dtData.Rows[0]["fromDate"]);
            string strFromDate = (dFromDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dFromDate)).ToString("yyyy-MM-dd");
            double dToDate = Convert.ToDouble(dtData.Rows[0]["toDate"] == null ? 0 : dtData.Rows[0]["toDate"]);
            string strToDate = (dToDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dToDate)).ToString("yyyy-MM-dd");
            int vendorId = int.Parse(dtData.Rows[0]["vendorId"] == null ? "0" : dtData.Rows[0]["vendorId"].ToString());

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
                        command.CommandText = Transport_Query.get_TransportStatusCategory;

                        command.Parameters.Add(new SqlParameter("@FromDate", strFromDate));
                        command.Parameters.Add(new SqlParameter("@ToDate", strToDate));
                        command.Parameters.Add(new SqlParameter("@VendorID", vendorId));

                        using (var reader = command.ExecuteReader())
                        {
                            DataTable tempResult = new DataTable();
                            tempResult.Load(reader);
                            result = ConvertToDesiredJsonFormat(tempResult);
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

        private string ConvertToDesiredJsonFormat(DataTable tempResult)
        {
            var totalVehicles = tempResult.AsEnumerable().Sum(row => row.Field<int>("TotalVehicle"));
            var pendingVehicles = tempResult.AsEnumerable().Sum(row => row.Field<int>("Pending"));
            var checkoutVehicles = tempResult.AsEnumerable().Sum(row => row.Field<int>("CheckOut"));
            var checkinVehicles = tempResult.AsEnumerable().Sum(row => row.Field<int>("CheckIn"));

            var result = new
            {
                total = new
                {
                    percentage = totalVehicles == 0 ? 0 : 100,
                    category = tempResult.AsEnumerable().Select(row => new
                    {
                        name = row.Field<string>("CategoryTypeName"),
                        count = row.Field<int>("TotalVehicle")
                    }).ToList()
                },
                pending = new
                {
                    percentage = totalVehicles == 0 ? 0 : (int)((pendingVehicles / (double)totalVehicles) * 100),
                    category = tempResult.AsEnumerable().Select(row => new
                    {
                        name = row.Field<string>("CategoryTypeName"),
                        count = row.Field<int>("Pending")
                    }).ToList()
                },
                checkout = new
                {
                    percentage = totalVehicles == 0 ? 0 : (int)((checkoutVehicles / (double)totalVehicles) * 100),
                    category = tempResult.AsEnumerable().Select(row => new
                    {
                        name = row.Field<string>("CategoryTypeName"),
                        count = row.Field<int>("CheckOut")
                    }).ToList()
                },
                checkin = new
                {
                    percentage = totalVehicles == 0 ? 0 : (int)((checkinVehicles / (double)totalVehicles) * 100),
                    category = tempResult.AsEnumerable().Select(row => new
                    {
                        name = row.Field<string>("CategoryTypeName"),
                        count = row.Field<int>("CheckIn")
                    }).ToList()
                }
            };

            string jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);

            // Here you can return jsonResult or you might want to return DataTable itself if you want to use it further.
            return jsonResult;
        }

        //public StatusCategoryJson GetTransportStatusForCategorydb(DataTable dtData)
        //{
        //    StatusCategoryJson result = new StatusCategoryJson();

        //    double dFromDate = Convert.ToDouble(dtData.Rows[0]["fromDate"] == null ? 0 : dtData.Rows[0]["fromDate"]);
        //    string strFromDate = (dFromDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dFromDate)).ToString("yyyy-MM-dd");
        //    double dToDate = Convert.ToDouble(dtData.Rows[0]["toDate"] == null ? 0 : dtData.Rows[0]["toDate"]);
        //    string strToDate = (dToDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dToDate)).ToString("yyyy-MM-dd");
        //    int vendorId = int.Parse(dtData.Rows[0]["vendorId"] == null ? "0" : dtData.Rows[0]["vendorId"].ToString());

        //    try
        //    {
        //        using (var context = new dataFeedContext())
        //        {
        //            context.Database.CommandTimeout = 300000;
        //            if (context.Database.Connection.State == ConnectionState.Closed)
        //            {
        //                context.Database.Connection.Open();
        //            }

        //            using (var command = context.Database.Connection.CreateCommand())
        //            {
        //                command.CommandText = Transport_Query.get_TransportStatusfordb;

        //                command.Parameters.Add(new SqlParameter("@FromDate", strFromDate));
        //                command.Parameters.Add(new SqlParameter("@ToDate", strToDate));
        //                command.Parameters.Add(new SqlParameter("@VendorID", vendorId));

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    DataTable tempResult = new DataTable();
        //                    tempResult.Load(reader);

        //                    var totalResultTable = GetTotalResultTable(tempResult);
        //                    int totalCount = totalResultTable.Sum(entry => entry.count);

        //                    result.Total = CreateStatusCategory(totalResultTable, totalCount);
        //                    result.Pending = CreateStatusCategory(GetResultTableByStatus(tempResult, "Pending"), totalCount);
        //                    result.Checkout = CreateStatusCategory(GetResultTableByStatus(tempResult, "Check Out"), totalCount);
        //                    result.Checkin = CreateStatusCategory(GetResultTableByStatus(tempResult, "Check In"), totalCount);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("===================================================================");
        //        Console.WriteLine(ex.Message);
        //    }
        //    return result;
        //}

        //private StatusCategory CreateStatusCategory(List<StatusEntry> statusEntries, int totalCount)
        //{
        //    StatusCategory statusCategory = new StatusCategory
        //    {
        //        category = statusEntries,
        //        percentage = totalCount == 0 ? 0 : Math.Round((decimal)statusEntries.Sum(entry => entry.count) / totalCount * 100, 2)
        //    };

        //    return statusCategory;
        //}

        //private List<StatusEntry> GetTotalResultTable(DataTable result)
        //{
        //    var groupedData = result.AsEnumerable()
        //                         .GroupBy(row => new { CategoryTypeName = row.Field<string>("CategoryTypeName"), CategoryTypeOrder = row.Field<int>("CategoryTypeOrder") })
        //                         .Select(g => new
        //                         {
        //                             CategoryTypeName = g.Key.CategoryTypeName,
        //                             CategoryTypeOrder = g.Key.CategoryTypeOrder,
        //                             Count = g.Count()
        //                         });

        //    var statusEntries = new List<StatusEntry>();

        //    foreach (var item in groupedData)
        //    {
        //        var entry = new StatusEntry
        //        {
        //            name = item.CategoryTypeName,
        //            count = item.Count
        //        };

        //        statusEntries.Add(entry);
        //    }

        //    return statusEntries;
        //}

        //private List<StatusEntry> GetResultTableByStatus(DataTable result, string status)
        //{
        //    var filteredRows = result.AsEnumerable()
        //                          .Where(row => row.Field<string>("TransportStatus") == status);

        //    DataTable filteredDataTable;
        //    if (filteredRows.Any())
        //    {
        //        filteredDataTable = filteredRows.CopyToDataTable();
        //    }
        //    else
        //    {
        //        filteredDataTable = result.Clone(); // Create an empty table with the same schema
        //    }

        //    var groupedData = filteredDataTable.AsEnumerable()
        //                .GroupBy(row => new { CategoryTypeName = row.Field<string>("CategoryTypeName"), CategoryTypeOrder = row.Field<int>("CategoryTypeOrder") })
        //                .Select(g => new
        //                {
        //                    CategoryTypeName = g.Key.CategoryTypeName,
        //                    CategoryTypeOrder = g.Key.CategoryTypeOrder,
        //                    Count = g.Count()
        //                });
        //    var statusEntries = new List<StatusEntry>();

        //    if (groupedData != null)
        //    {
        //        foreach (var item in groupedData)
        //        {
        //            var entry = new StatusEntry
        //            {
        //                name = item.CategoryTypeName,
        //                count = item.Count
        //            };

        //            statusEntries.Add(entry);
        //        }
        //    }
        //    return statusEntries;
        //}
        #endregion

        #region GetTransportStatusForDetaildb
        public DataTable GetTransportStatusForDetaildb(DataTable dtData)
        {
            DataTable result = new DataTable();
            double dFromDate = Convert.ToDouble(dtData.Rows[0]["fromDate"] == null ? 0 : dtData.Rows[0]["fromDate"]);
            string strFromDate = (dFromDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dFromDate)).ToString("yyyy-MM-dd");
            double dToDate = Convert.ToDouble(dtData.Rows[0]["toDate"] == null ? 0 : dtData.Rows[0]["toDate"]);
            string strToDate = (dToDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dToDate)).ToString("yyyy-MM-dd");
            int vendorId = int.Parse(dtData.Rows[0]["vendorId"] == null ? "0" : dtData.Rows[0]["vendorId"].ToString());
            //string strStatus = dtData.Rows[0]["status"] == null ? "" : dtData.Rows[0]["status"].ToString();
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
                        command.CommandText = Transport_Query.get_TransportStatusfordb;

                        command.Parameters.Add(new SqlParameter("@FromDate", strFromDate));
                        command.Parameters.Add(new SqlParameter("@ToDate", strToDate));
                        command.Parameters.Add(new SqlParameter("@VendorID", vendorId));

                        using (var reader = command.ExecuteReader())
                        {
                            result.Load(reader);

                            //result.Overall = GetResultDetailOverall(tempResult);
                            //result.PendingPickup = GetResultDetailByStatus(tempResult, 1);
                            //result.Transporting = GetResultDetailByStatus(tempResult, 2);
                            //result.Arrived = GetResultDetailByStatus(tempResult, 3);
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

        //private List<StatusDetailEntry> GetResultDetailOverall(DataTable dt)
        //{
        //    string[] selectedColumns = { "Status", "IMAPNumber", "Registration", "SellerName", "VendorName", "StorageLocation", "Destination" };

        //    var result = GetSelectedColumns(dt, selectedColumns);
        //    return result;
        //}

        //private List<StatusDetailEntry> GetResultDetailByStatus(DataTable dt, int status)
        //{
        //    var filteredRows = dt.AsEnumerable()
        //                          .Where(row => row.Field<int>("Status") == status);

        //    DataTable filteredDataTable;
        //    if (filteredRows.Any())
        //    {
        //        filteredDataTable = filteredRows.CopyToDataTable();
        //    }
        //    else
        //    {
        //        filteredDataTable = dt.Clone(); // Create an empty table with the same schema
        //    }

        //   string[] selectedColumns = { "Status", "IMAPNumber", "Registration", "SellerName", "VendorName", "StorageLocation", "Destination" };

        //    var result = GetSelectedColumns(filteredDataTable, selectedColumns);
        //    return result; 
        //}

        //public DataTable GetSelectedColumns(DataTable sourceTable, string[] columnNames)
        //{
        //    var result = new DataTable();

        //    // Iterate through each row in the source DataTable
        //    foreach (DataRow row in sourceTable.Rows)
        //    {
        //        var entry = new StatusDetailEntry();
        //        foreach (string columnName in columnNames)
        //        {
        //            if (sourceTable.Columns.Contains(columnName))
        //            {
        //                // Use reflection to set the properties of StatusDetailEntry
        //                var property = typeof(StatusDetailEntry).GetProperty(columnName);
        //                if (property != null && row[columnName] != DBNull.Value)
        //                {
        //                    property.SetValue(entry, row[columnName]);
        //                }
        //            }
        //        }
        //        result.Add(entry);
        //    }

        //    return result;
        //}
        #endregion

        #region GetTransportLocation
        public DataTable GetTransportLocation(DataTable dtData)
        {
            DataTable result = new DataTable();
            double dFromDate = Convert.ToDouble(dtData.Rows[0]["fromDate"] == null ? 0 : dtData.Rows[0]["fromDate"]);
            string strFromDate = (dFromDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dFromDate)).ToString("yyyy-MM-dd");
            double dToDate = Convert.ToDouble(dtData.Rows[0]["toDate"] == null ? 0 : dtData.Rows[0]["toDate"]);
            string strToDate = (dToDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dToDate)).ToString("yyyy-MM-dd");
            int vendorId = int.Parse(dtData.Rows[0]["vendorId"] == null ? "0" : dtData.Rows[0]["vendorId"].ToString());
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
                        command.CommandText = Transport_Query.get_TransportLocfordb;

                        command.Parameters.Add(new SqlParameter("@FromDate", strFromDate));
                        command.Parameters.Add(new SqlParameter("@ToDate", strToDate));
                        command.Parameters.Add(new SqlParameter("@VendorID", vendorId));

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
        #endregion

        #region GetLocationByIMAPnumber
        public DataTable GetLocationByIMAPnumber(string strvehicleNo)
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
                        command.CommandText = Transport_Query.get_TransportLocByImapNo;

                        command.Parameters.Add(new SqlParameter("@IMAPNumber", strvehicleNo));

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

        #region Transport Order & Detail
        #region UploadTransportOrder
        public void UploadTransportOrder(DataTable dtData)
        {
            Transport_Order oOrder = new Transport_Order();
            oOrder.CreatedBy = dtData.Rows[0]["actionBy"] == null ? "" : dtData.Rows[0]["actionBy"].ToString();
            string userRole = getUserRole(oOrder.CreatedBy);
            oOrder.OrderCode = getOrderCode(userRole);
            oOrder.UploadDate = DateTime.Now;
            oOrder.CreateDate = DateTime.Now;

            using (var context = new dataFeedContext())
            {
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }

                #region Parameter
                var orderParam = new List<SqlParameter> {
                    new SqlParameter("@OrderCode",oOrder.OrderCode),
                    new SqlParameter("@UploadDate",oOrder.UploadDate),
                    new SqlParameter("@CreateDate",oOrder.CreateDate),
                    new SqlParameter("@CreatedBy",oOrder.CreatedBy)
                    };
                #endregion Parameter
                int Id = context.Database.SqlQuery<int>(Transport_Query.Save_Transport_Order, orderParam.ToArray()).SingleOrDefault();

                SaveTransportOrderDetail(dtData, Id);
                //string connectionString = ConfigurationManager.ConnectionStrings["ATS_DATA"]?.ConnectionString;

                //dtData.Columns["departureDate"].ColumnName = "DepartureDate";
                //dtData.Columns["arrivalDate"].ColumnName = "ArrivalDate";
                //dtData.Columns["iMAPnumber"].ColumnName = "IMAPnumber";
                //dtData.Columns["registration"].ColumnName = "Registration";
                //dtData.Columns["sellerName"].ColumnName = "SellerName";
                //dtData.Columns["vendorName"].ColumnName = "VendorName";
                //dtData.Columns["storageLocation"].ColumnName = "StorageLocation";
                //dtData.Columns["destination"].ColumnName = "Destination";
                //dtData.Columns["makeDesc"].ColumnName = "MakeDesc";
                //dtData.Columns["modelDesc"].ColumnName = "ModelDesc";
                //dtData.Columns["variants"].ColumnName = "Variants";
                //dtData.Columns["chassisNo"].ColumnName = "ChassisNo";
                //dtData.Columns["pickuprooftype"].ColumnName = "Pickuprooftype";
                //dtData.Columns["cost"].ColumnName = "Cost";
                //dtData.Columns["feeCharged"].ColumnName = "FeeCharged";
                //dtData.Columns.Add("OrderID", typeof(int));

                //foreach (DataRow row in dtData.Rows)
                //{
                //    row["OrderID"] = Id;
                //}

                //using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString))
                //{
                //    bulkCopy.DestinationTableName = "Transport_OrderDocDetail";

                //    foreach (DataColumn column in dtData.Columns)
                //    {
                //        bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                //    }
                //    // Write the DataTable to the database
                //    bulkCopy.WriteToServer(dtData);
                //}
            }
        }

        protected string getUserRole(string createduser)
        {
            DataTable result = new DataTable();
            using (var context = new dataFeedContext())
            {
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }

                using (var command = context.Database.Connection.CreateCommand())
                {
                    command.CommandText = Transport_Query.Get_UserByUserID
                         .Replace("@UserID", createduser);

                    using (var reader = command.ExecuteReader())
                    {
                        result.Load(reader);
                    }
                }
            }
            string userRole = result.Rows[0]["DepartmentID"] == null ? "0" : result.Rows[0]["DepartmentID"].ToString();
            return userRole;
        }

        protected string getOrderCode(string createduserRole)
        {
            DataTable result = new DataTable();
            string sign = "";
            if (createduserRole == "1")//Transport Department
            {
                sign = "TS";
            }
            else if (createduserRole == "2")//Operation
            {
                sign = "OP";
            }
            string orderNo = "00001";
            string orderDate = "";
            string OrderCode = "";
            string systemDate = DateTime.Now.ToString("yyyyMM");
            using (var context = new dataFeedContext())
            {
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }

                using (var command = context.Database.Connection.CreateCommand())
                {
                    command.CommandText = Transport_Query.Get_LastestCreateOrderDate
                        .Replace("@CreateDate", systemDate);

                    using (var reader = command.ExecuteReader())
                    {
                        result.Load(reader);
                    }
                }
                if (result.Rows.Count > 0)
                {
                    orderDate = result.Rows[0]["CreateDate"].ToString();
                }
                if ((systemDate.Trim()) == (orderDate.Trim()))
                {
                    DataTable dtorder = new DataTable();

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Transport_Query.Get_LastestOrderID
                             .Replace("@CreateDate", systemDate);

                        using (var reader = command.ExecuteReader())
                        {
                            dtorder.Load(reader);
                        }
                    }

                    if (dtorder.Rows.Count > 0)
                    {
                        orderNo = dtorder.Rows[0]["OrderCode"].ToString();

                        int aa = int.Parse(orderNo) + 1;
                        OrderCode = sign + '-' + orderDate + '-' + aa.ToString("D5");
                    }
                    else
                    {
                        string dd = systemDate;
                        OrderCode = sign + '-' + dd + '-' + orderNo;
                    }
                }
                else
                {
                    int dd = int.Parse(systemDate);
                    OrderCode = sign + '-' + dd.ToString("D6") + '-' + orderNo;
                }
            }
            return OrderCode;
        }
        #endregion

        #region UpdateTransportOrder
        public void UpdateTransportOrder(DataTable dtData)
        {
            Transport_Order oOrder = new Transport_Order();
            oOrder.OrderID = int.Parse(dtData.Rows[0]["orderID"] == null ? "0" : dtData.Rows[0]["orderID"].ToString());
            oOrder.UpdateDate = DateTime.Now;
            oOrder.UpdatedBy = dtData.Rows[0]["actionBy"] == null ? "" : dtData.Rows[0]["actionBy"].ToString();

            using (var context = new dataFeedContext())
            {
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }

                #region Parameter
                var orderParam = new List<SqlParameter> {
                    new SqlParameter("@OrderID",oOrder.OrderID),
                    new SqlParameter("@UpdateDate",oOrder.UpdateDate),
                    new SqlParameter("@UpdatedBy",oOrder.UpdatedBy)
                };

                var deleteOrderParam = new List<SqlParameter> {
                    new SqlParameter("@OrderID",oOrder.OrderID)
                    };
                #endregion Parameter
                context.Database.ExecuteSqlCommand(Transport_Query.Update_Transport_Order, orderParam.ToArray());

                context.Database.ExecuteSqlCommand(Transport_Query.Delete_Transport_OrderDetail, deleteOrderParam.ToArray());

                int Id = oOrder.OrderID;
                SaveTransportOrderDetail(dtData, Id);
            }
        }
        #endregion

        #region DeleteTransportOrder
        public void DeleteTransportOrder(DataTable dtData)
        {
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Transport_Order oOrder = new Transport_Order();
                    oOrder.OrderID = int.Parse(dtData.Rows[i]["orderID"] == null ? "0" : dtData.Rows[i]["orderID"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter
                    var orderParam = new List<SqlParameter> {
                    new SqlParameter("@OrderID",oOrder.OrderID)
                    };

                    #endregion Parameter

                    context.Database.ExecuteSqlCommand(Transport_Query.Delete_Transport_Order, orderParam.ToArray());

                    context.Database.ExecuteSqlCommand(Transport_Query.Delete_Transport_OrderDetail, orderParam.ToArray());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region SaveTransportOrderDetail
        public void SaveTransportOrderDetail(DataTable dtData, int orderId)
        {
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Transport_OrderDetail orderDetail = new Transport_OrderDetail();
                    orderDetail.OrderID = orderId;
                    double dDepartureDate = Convert.ToDouble(dtData.Rows[i]["departureDate"] == null ? 0 : dtData.Rows[i]["departureDate"]);
                    orderDetail.DepartureDate = dDepartureDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dDepartureDate);
                    double dArrivalDate = Convert.ToDouble(dtData.Rows[i]["arrivalDate"] == null ? 0 : dtData.Rows[i]["arrivalDate"]);
                    orderDetail.ArrivalDate = dArrivalDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dArrivalDate);
                    orderDetail.IMAPNumber = dtData.Rows[i]["iMAPnumber"] == null ? "" : dtData.Rows[i]["iMAPnumber"].ToString();
                    orderDetail.Registration = dtData.Rows[i]["registration"] == null ? "" : dtData.Rows[i]["registration"].ToString();
                    orderDetail.SellerName = dtData.Rows[i]["sellerName"] == null ? "" : dtData.Rows[i]["sellerName"].ToString();
                    orderDetail.VendorName = dtData.Rows[i]["vendorName"] == null ? "" : dtData.Rows[i]["vendorName"].ToString();
                    orderDetail.StorageLocation = dtData.Rows[i]["storageLocation"] == null ? "" : dtData.Rows[i]["storageLocation"].ToString();
                    orderDetail.Destination = dtData.Rows[i]["destination"] == null ? "" : dtData.Rows[i]["destination"].ToString();
                    orderDetail.MakeDesc = dtData.Rows[i]["makeDesc"] == null ? "" : dtData.Rows[i]["makeDesc"].ToString();
                    orderDetail.ModelDesc = dtData.Rows[i]["modelDesc"] == null ? "" : dtData.Rows[i]["modelDesc"].ToString();
                    orderDetail.Variants = dtData.Rows[i]["variants"] == null ? "" : dtData.Rows[i]["variants"].ToString();
                    orderDetail.ChassisNo = dtData.Rows[i]["chassisNo"] == null ? "" : dtData.Rows[i]["chassisNo"].ToString();
                    orderDetail.PickupRoofType = dtData.Rows[i]["pickupRoofType"] == null ? "" : dtData.Rows[i]["pickupRoofType"].ToString();
                    orderDetail.Cost = Convert.ToDecimal(dtData.Rows[i]["cost"] == null ? "0" : dtData.Rows[i]["cost"]);
                    orderDetail.FeeCharged = Convert.ToDecimal(dtData.Rows[i]["feeCharged"] == null ? "0" : dtData.Rows[i]["feeCharged"]);

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var detailParam = new List<SqlParameter> {
                            new SqlParameter("@OrderID", orderDetail.OrderID),
                            new SqlParameter("@DepartureDate", orderDetail.DepartureDate),
                            new SqlParameter("@ArrivalDate", orderDetail.ArrivalDate),
                            new SqlParameter("@IMAPNumber", orderDetail.IMAPNumber),
                            new SqlParameter("@Registration", orderDetail.Registration),
                            new SqlParameter("@SellerName", orderDetail.SellerName),
                            new SqlParameter("@VendorName", orderDetail.VendorName),
                            new SqlParameter("@StorageLocation", orderDetail.StorageLocation),
                            new SqlParameter("@Destination", orderDetail.Destination),
                            new SqlParameter("@MakeDesc", orderDetail.MakeDesc),
                            new SqlParameter("@ModelDesc", orderDetail.ModelDesc),
                            new SqlParameter("@Variants", orderDetail.Variants),
                            new SqlParameter("@ChassisNo", orderDetail.ChassisNo),
                            new SqlParameter("@PickupRoofType", orderDetail.PickupRoofType),
                            new SqlParameter("@Cost", orderDetail.Cost),
                            new SqlParameter("@FeeCharged", orderDetail.FeeCharged)
                        };

                    #endregion Parameter
                    context.Database.SqlQuery<int>(Transport_Query.Save_Transport_OrderDetail, detailParam.ToArray()).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region GetTransportOrderList
        public DataTable GetTransportOrderList()
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
                        command.CommandText = Transport_Query.Get_TransportOrder_List;

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

        #region GetTransportOrderDetailByOrderId
        public DataTable GetTransportOrderDetailByOrderId(DataTable dtData)
        {
            DataTable result = new DataTable();
            Transport_OrderDetail orderDetail = new Transport_OrderDetail();
            orderDetail.OrderID = int.Parse(dtData.Rows[0]["orderID"] == null ? "0" : dtData.Rows[0]["orderID"].ToString());
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
                        command.CommandText = Transport_Query.Get_OrderDetail_ByOrderId;

                        command.Parameters.Add(new SqlParameter("@OrderID", orderDetail.OrderID));

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
        #endregion

        #region Transport Request & Detail
        #region UploadTransportRequest
        public void UploadTransportRequest(DataTable dtData)
        {
            Transport_Request oRequest = new Transport_Request();
            oRequest.TotalRecords = dtData.Rows.Count;
            oRequest.UploadDate = DateTime.Now;
            oRequest.UploadBy = "";

            using (var context = new dataFeedContext())
            {
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }

                #region Parameter
                var requestParam = new List<SqlParameter> {
                    new SqlParameter("@TotalRecords",oRequest.TotalRecords),
                    new SqlParameter("@UploadDate",oRequest.UploadDate),
                    new SqlParameter("@UploadBy",oRequest.UploadBy)
                    };
                #endregion Parameter
                int Id = context.Database.SqlQuery<int>(Transport_Query.Save_Transport_Request, requestParam.ToArray()).SingleOrDefault();

                string connectionString = ConfigurationManager.ConnectionStrings["ATS_DATA"]?.ConnectionString;

                dtData.Columns["vehicle"].ColumnName = "VehicleNumber";
                dtData.Columns["storagelocation"].ColumnName = "StorageLocation";
                dtData.Columns["destinationlocation"].ColumnName = "DestinationLocation";
                dtData.Columns["buildyear"].ColumnName = "BuildYear";
                dtData.Columns["makedesc"].ColumnName = "MakeDesc";
                dtData.Columns["variants"].ColumnName = "Variants";
                dtData.Columns["auctionCode"].ColumnName = "AuctionCode";
                dtData.Columns["registration"].ColumnName = "Registration";
                dtData.Columns.Add("RequestID", typeof(int));
                foreach (DataRow row in dtData.Rows)
                {
                    row["RequestID"] = Id;
                }

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString))
                {
                    bulkCopy.DestinationTableName = "Transport_RequestDetail";

                    foreach (DataColumn column in dtData.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                    }
                    // Write the DataTable to the database
                    bulkCopy.WriteToServer(dtData);
                }
            }
        }
        #endregion
        #endregion

        #region Transport Schedule & Detail
        #region SaveTransportSchedule
        public int SaveTransportSchedule(JObject jsonData)
        {
            int Id = 0;
            // Extract data from the JSON and populate the DataTable
            foreach (var item in jsonData["data"])
            {
                Transport_Schedule oSchedule = new Transport_Schedule();
                // Convert the vehicle array to a JSON string
                oSchedule.Vehicle = item["vehicle"].ToString();

                double deDepartureDate = Convert.ToDouble(item["estimateDepartureDate"] == null ? 0 : item["estimateDepartureDate"]);
                oSchedule.EstimateDepartureDate = deDepartureDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(deDepartureDate);

                double deArrivalDate = Convert.ToDouble(item["estimateArrivalDate"] == null ? 0 : item["estimateArrivalDate"]);
                oSchedule.EstimateArrivalDate = deArrivalDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(deArrivalDate);

                oSchedule.CreatedBy = int.Parse(item["actionBy"].ToString());

                double dactionDate = Convert.ToDouble(item["actionDate"] == null ? 0 : item["actionDate"]);
                oSchedule.CreatedDate = dactionDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dactionDate);

                oSchedule.UpdatedBy = int.Parse(item["actionBy"].ToString());

                oSchedule.UpdatedDate = dactionDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dactionDate);

                oSchedule.FromYard = Convert.ToInt32(item["formYard"].ToString());
                oSchedule.ToYard = Convert.ToInt32(item["toYard"].ToString());
                oSchedule.VendorId = Convert.ToInt32(item["vendorId"].ToString());

                using (var context = new dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter
                    var scheduleParam = new List<SqlParameter> {
                    new SqlParameter("@EstimateDepartureDate",oSchedule.EstimateDepartureDate),
                    new SqlParameter("@EstimateArrivalDate",oSchedule.EstimateArrivalDate),
                    new SqlParameter("@FromYard",oSchedule.FromYard),
                    new SqlParameter("@ToYard",oSchedule.ToYard),
                    new SqlParameter("@CreatedBy",oSchedule.CreatedBy),
                    new SqlParameter("@CreatedDate",oSchedule.CreatedDate),
                    new SqlParameter("@UpdatedBy",oSchedule.UpdatedBy),
                    new SqlParameter("@UpdatedDate",oSchedule.UpdatedDate),
                    new SqlParameter("@VendorId",oSchedule.VendorId)
                    };
                    #endregion Parameter
                    Id = context.Database.SqlQuery<int>(Transport_Query.Save_Transport_Schedule, scheduleParam.ToArray()).SingleOrDefault();

                    SaveTransportScheduleDetail(oSchedule.Vehicle, Id);
                }
            }
            return Id;
        }
        #endregion

        #region SaveTransportScheduleDetail
        public void SaveTransportScheduleDetail(string strVehicles, int scheduleid)
        {
            try
            {
                string[] array = JsonConvert.DeserializeObject<string[]>(strVehicles);
                HashSet<string> seenNumbers = new HashSet<string>();

                // List to store the modified array
                List<string> newArray = new List<string>();

                foreach (string num in array)
                {
                    if (!seenNumbers.Contains(num))
                    {
                        newArray.Add(num);
                        seenNumbers.Add(num);
                    }
                }
                string[] resultArray = newArray.ToArray();

                foreach (var item in resultArray)
                {
                    Transport_ScheduleDetail odetail = new Transport_ScheduleDetail();
                    odetail.ScheduleID = scheduleid;
                    odetail.Vehicle = item;
                    odetail.Status = 1;// scheduled
                    //odetail.CheckOutDate = DateTime.Parse("1900-01-01");
                    //odetail.CheckOutTime = "";
                    //odetail.CheckInDate = DateTime.Parse("1900-01-01");
                    //odetail.CheckInTime = "";

                    using (var context = new dataFeedContext())
                    {
                        context.Database.CommandTimeout = 300000;
                        if (context.Database.Connection.State == ConnectionState.Closed)
                        {
                            context.Database.Connection.Open();
                        }

                        #region Parameter
                        var detailParam = new List<SqlParameter> {
                    new SqlParameter("@ScheduleID",odetail.ScheduleID),
                    new SqlParameter("@Vehicle",odetail.Vehicle),
                    new SqlParameter("@Status",odetail.Status)
                    //new SqlParameter("@CheckOutDate",odetail.CheckOutDate),
                    //new SqlParameter("@CheckOutTime",odetail.CheckOutTime),
                    //new SqlParameter("@CheckInDate",odetail.CheckInDate),
                    //new SqlParameter("@CheckInTime",odetail.CheckInTime)
                    };
                        #endregion Parameter

                        context.Database.ExecuteSqlCommand(Transport_Query.Save_Transport_ScheduleDetail, detailParam.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region GetScheduleList
        public DataTable GetScheduleList()
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
                        command.CommandText = Transport_Query.Get_Schedule_List;

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

        #region DeleteTransportSchedule
        public void DeleteTransportSchedule(DataTable dtData)
        {
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Transport_Schedule schedule = new Transport_Schedule();
                    schedule.ScheduleID = int.Parse(dtData.Rows[i]["scheduleID"] == null ? "0" : dtData.Rows[i]["scheduleID"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var scheduleParam = new List<SqlParameter> {
                    new SqlParameter("@ScheduleID",schedule.ScheduleID)
                    };

                    #endregion Parameter

                    context.Database.ExecuteSqlCommand(Transport_Query.Delete_Transport_Schedule, scheduleParam.ToArray());

                    context.Database.ExecuteSqlCommand(Transport_Query.Delete_Transport_ScheduleDetail, scheduleParam.ToArray());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region UpdateTransportSchedule
        public int UpdateTransportSchedule(JObject jsonData)
        {
            int Id = 0;
            try
            {
                foreach (var item in jsonData["data"])
                {
                    Transport_Schedule oSchedule = new Transport_Schedule();
                    // Convert the vehicle array to a JSON string
                    oSchedule.Vehicle = item["vehicle"].ToString();
                    oSchedule.ScheduleID = int.Parse(item["scheduleID"].ToString());
                    double deDepartureDate = Convert.ToDouble(item["estimateDepartureDate"] == null ? 0 : item["estimateDepartureDate"]);
                    oSchedule.EstimateDepartureDate = deDepartureDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(deDepartureDate);

                    double deArrivalDate = Convert.ToDouble(item["estimateArrivalDate"] == null ? 0 : item["estimateArrivalDate"]);
                    oSchedule.EstimateArrivalDate = deArrivalDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(deArrivalDate);

                    oSchedule.UpdatedBy = int.Parse(item["actionBy"].ToString());

                    double dactionDate = Convert.ToDouble(item["actionDate"] == null ? 0 : item["actionDate"]);
                    oSchedule.UpdatedDate = dactionDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dactionDate);

                    oSchedule.FromYard = Convert.ToInt32(item["formYard"].ToString());
                    oSchedule.ToYard = Convert.ToInt32(item["toYard"].ToString());
                    oSchedule.VendorId = Convert.ToInt32(item["vendorId"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter
                    var scheduleParam = new List<SqlParameter> {
                    new SqlParameter("@EstimateDepartureDate",oSchedule.EstimateDepartureDate),
                    new SqlParameter("@EstimateArrivalDate",oSchedule.EstimateArrivalDate),
                    new SqlParameter("@FromYard",oSchedule.FromYard),
                    new SqlParameter("@ToYard",oSchedule.ToYard),
                    new SqlParameter("@UpdatedBy",oSchedule.UpdatedBy),
                    new SqlParameter("@UpdatedDate",oSchedule.UpdatedDate),
                    new SqlParameter("@ScheduleID",oSchedule.ScheduleID),
                    new SqlParameter("@VendorId",oSchedule.VendorId)
                    };

                    var deletescheduleParam = new List<SqlParameter> {
                    new SqlParameter("@ScheduleID",oSchedule.ScheduleID)
                    };
                    #endregion Parameter

                    context.Database.ExecuteSqlCommand(Transport_Query.Update_Transport_Schedule, scheduleParam.ToArray());

                    context.Database.ExecuteSqlCommand(Transport_Query.Delete_Transport_ScheduleDetail, deletescheduleParam.ToArray());

                    Id = oSchedule.ScheduleID;
                    SaveTransportScheduleDetail(oSchedule.Vehicle, Id);

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
            return Id;
        }
        #endregion

        #region GetScheduleDetailByScheduleID
        public DataTable GetScheduleDetailByScheduleID(DataTable dtData)
        {
            DataTable result = new DataTable();
            Transport_Schedule oschedule = new Transport_Schedule();
            oschedule.ScheduleID = int.Parse(dtData.Rows[0]["scheduleID"] == null ? "0" : dtData.Rows[0]["scheduleID"].ToString());
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
                        command.CommandText = Transport_Query.Get_ScheduleDetail_ByScheduleID;

                        command.Parameters.Add(new SqlParameter("@ScheduleID", oschedule.ScheduleID));

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

        #region GetScheduleByScheduleID
        public DataTable GetScheduleByScheduleID(DataTable dtData)
        {
            DataTable result = new DataTable();
            Transport_Schedule oschedule = new Transport_Schedule();
            oschedule.ScheduleID = int.Parse(dtData.Rows[0]["scheduleID"] == null ? "0" : dtData.Rows[0]["scheduleID"].ToString());
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
                        command.CommandText = Transport_Query.Get_Schedule_ByScheduleID;

                        command.Parameters.Add(new SqlParameter("@ScheduleID", oschedule.ScheduleID));

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
        #endregion

        #region Vendor
        #region SaveVendor
        public int SaveVendor(DataTable dtData)
        {
            int Id = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Vendor oVendor = new Vendor();
                    oVendor.VendorName = (dtData.Rows[i]["vendorName"] == null ? "" : dtData.Rows[i]["vendorName"].ToString());
                    oVendor.VendorCode = (dtData.Rows[i]["vendorCode"] == null ? "" : dtData.Rows[i]["vendorCode"].ToString());
                    oVendor.ContactPhoneNumber = (dtData.Rows[i]["contactPhoneNumber"] == null ? "" : dtData.Rows[i]["contactPhoneNumber"].ToString());
                    oVendor.Email = (dtData.Rows[i]["email"] == null ? "" : dtData.Rows[i]["email"].ToString());
                    oVendor.SecondaryEmails = (dtData.Rows[i]["secondaryEmails"] == null ? "" : dtData.Rows[i]["secondaryEmails"].ToString());
                    oVendor.Remark = (dtData.Rows[i]["remark"] == null ? "" : dtData.Rows[i]["remark"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var VendorParam = new List<SqlParameter> {
                    new SqlParameter("@VendorName",oVendor.VendorName),
                    new SqlParameter("@VendorCode",oVendor.VendorCode),
                    new SqlParameter("@ContactPhoneNumber",oVendor.ContactPhoneNumber),
                    new SqlParameter("@Email",oVendor.Email),
                     new SqlParameter("@SecondaryEmails",oVendor.SecondaryEmails),
                    new SqlParameter("@Remark",oVendor.Remark)
                    };

                    #endregion Parameter

                    DataTable chkDuplicate = new DataTable();
                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Transport_Query.Check_Duplicate_Vendor;

                        #region Parameters

                        command.Parameters.Add(new SqlParameter("@ContactPhoneNumber", oVendor.ContactPhoneNumber));
                        command.Parameters.Add(new SqlParameter("@Email", oVendor.Email));
                        command.Parameters.Add(new SqlParameter("@VendorID", Id));

                        #endregion Parameters

                        using (var reader = command.ExecuteReader())
                        {
                            chkDuplicate.Load(reader);
                        }
                    }
                    if (chkDuplicate.Rows.Count == 0)
                    {
                        Id = context.Database.SqlQuery<int>(Transport_Query.Save_Vendor, VendorParam.ToArray()).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
            return Id;
        }
        #endregion

        #region UpdateVendor
        public int UpdateVendor(DataTable dtData)
        {
            int Id = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Vendor oVendor = new Vendor();
                    oVendor.VendorName = (dtData.Rows[i]["vendorName"] == null ? "" : dtData.Rows[i]["vendorName"].ToString());
                    oVendor.VendorCode = (dtData.Rows[i]["vendorCode"] == null ? "" : dtData.Rows[i]["vendorCode"].ToString());
                    oVendor.ContactPhoneNumber = (dtData.Rows[i]["contactPhoneNumber"] == null ? "" : dtData.Rows[i]["contactPhoneNumber"].ToString());
                    oVendor.Email = (dtData.Rows[i]["email"] == null ? "" : dtData.Rows[i]["email"].ToString());
                    oVendor.SecondaryEmails = (dtData.Rows[i]["secondaryEmails"] == null ? "" : dtData.Rows[i]["secondaryEmails"].ToString());
                    oVendor.Remark = (dtData.Rows[i]["remark"] == null ? "" : dtData.Rows[i]["remark"].ToString());
                    oVendor.VendorID = int.Parse(dtData.Rows[i]["vendorId"] == null ? "0" : dtData.Rows[i]["vendorId"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var VendorParam = new List<SqlParameter> {
                    new SqlParameter("@VendorName",oVendor.VendorName),
                         new SqlParameter("@VendorCode",oVendor.VendorCode),
                    new SqlParameter("@ContactPhoneNumber",oVendor.ContactPhoneNumber),
                    new SqlParameter("@Email",oVendor.Email),
                    new SqlParameter("@Remark",oVendor.Remark),
                         new SqlParameter("@SecondaryEmails",oVendor.SecondaryEmails),
                    new SqlParameter("@VendorID",oVendor.VendorID)
                    };

                    #endregion Parameter

                    DataTable chkDuplicate = new DataTable();
                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Transport_Query.Check_Duplicate_Vendor;

                        #region Parameters

                        command.Parameters.Add(new SqlParameter("@ContactPhoneNumber", oVendor.ContactPhoneNumber));
                        command.Parameters.Add(new SqlParameter("@Email", oVendor.Email));
                        command.Parameters.Add(new SqlParameter("@VendorID", oVendor.VendorID));
                        #endregion Parameters

                        using (var reader = command.ExecuteReader())
                        {
                            chkDuplicate.Load(reader);
                        }
                    }
                    if (chkDuplicate.Rows.Count == 0)
                    {
                        context.Database.ExecuteSqlCommand(Transport_Query.Update_Vendor, VendorParam.ToArray());
                        Id++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
            return Id;
        }
        #endregion

        #region DeleteVendor
        public void DeleteVendor(DataTable dtData)
        {

            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Vendor oVendor = new Vendor();
                    oVendor.VendorID = int.Parse(dtData.Rows[i]["vendorId"] == null ? "0" : dtData.Rows[i]["vendorId"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var VendorParam = new List<SqlParameter> {
                    new SqlParameter("@VendorID",oVendor.VendorID)
                    };

                    #endregion Parameter

                    context.Database.ExecuteSqlCommand(Transport_Query.Delete_Vendor, VendorParam.ToArray());
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region GetVendorForCombo
        public DataTable GetVendorForCombo()
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
                        command.CommandText = Transport_Query.Get_Vendor_ForCombo;

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

        #region GetVendorList
        public DataTable GetVendorList()
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
                        command.CommandText = Transport_Query.Get_Vendor_List;

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

        #region GetVendorEmailsByName
        public Vendor GetVendorEmailsByName(string vName)
        {
            Vendor result = new Vendor();
            try
            {
                using (var context = new dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    var Param = new List<SqlParameter> {
                        new SqlParameter("@VendorName",vName)
                    };

                    result = context.Database.SqlQuery<Vendor>(Transport_Query.Get_VendorEmails_ByName, Param.ToArray()).FirstOrDefault();
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
        #endregion

        #region Location
        #region SaveLocation
        public int SaveLocation(DataTable dtData)
        {
            int Id = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Location oLocation = new Location();
                    oLocation.LocationName = (dtData.Rows[i]["locationName"] == null ? "" : dtData.Rows[i]["locationName"].ToString());
                    oLocation.LocationCode = (dtData.Rows[i]["locationCode"] == null ? "" : dtData.Rows[i]["locationCode"].ToString());
                    oLocation.Email = (dtData.Rows[i]["email"] == null ? "" : dtData.Rows[i]["email"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var LocationParam = new List<SqlParameter> {
                    new SqlParameter("@LocationName",oLocation.LocationName),
                    new SqlParameter("@LocationCode",oLocation.LocationCode),
                    new SqlParameter("@Email",oLocation.Email)
                    };

                    #endregion Parameter

                    DataTable chkDuplicate = new DataTable();
                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Transport_Query.Check_Duplicate_Location;

                        #region Parameters

                        command.Parameters.Add(new SqlParameter("@LocationCode", oLocation.LocationCode));
                        command.Parameters.Add(new SqlParameter("@LocationName", oLocation.LocationName));
                        command.Parameters.Add(new SqlParameter("@LocationID", Id));

                        #endregion Parameters

                        using (var reader = command.ExecuteReader())
                        {
                            chkDuplicate.Load(reader);
                        }
                    }
                    if (chkDuplicate.Rows.Count == 0)
                    {
                        Id = context.Database.SqlQuery<int>(Transport_Query.Save_Location, LocationParam.ToArray()).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
            return Id;
        }
        #endregion

        #region UpdateLocation
        public int UpdateLocation(DataTable dtData)
        {
            int Id = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Location oLocation = new Location();
                    oLocation.LocationName = (dtData.Rows[i]["locationName"] == null ? "" : dtData.Rows[i]["locationName"].ToString());
                    oLocation.LocationCode = (dtData.Rows[i]["locationCode"] == null ? "" : dtData.Rows[i]["locationCode"].ToString());
                    oLocation.Email = (dtData.Rows[i]["email"] == null ? "" : dtData.Rows[i]["email"].ToString());
                    oLocation.LocationID = int.Parse(dtData.Rows[i]["locationId"] == null ? "0" : dtData.Rows[i]["locationId"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var LocationParam = new List<SqlParameter> {
                    new SqlParameter("@LocationName",oLocation.LocationName),
                    new SqlParameter("@LocationCode",oLocation.LocationCode),
                    new SqlParameter("@Email",oLocation.Email),
                    new SqlParameter("@LocationID",oLocation.LocationID)
                    };

                    #endregion Parameter

                    DataTable chkDuplicate = new DataTable();
                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Transport_Query.Check_Duplicate_Location;

                        #region Parameters

                        command.Parameters.Add(new SqlParameter("@LocationCode", oLocation.LocationCode));
                        command.Parameters.Add(new SqlParameter("@LocationName", oLocation.LocationName));
                        command.Parameters.Add(new SqlParameter("@LocationID", oLocation.LocationID));
                        #endregion Parameters

                        using (var reader = command.ExecuteReader())
                        {
                            chkDuplicate.Load(reader);
                        }
                    }
                    if (chkDuplicate.Rows.Count == 0)
                    {
                        context.Database.ExecuteSqlCommand(Transport_Query.Update_Location, LocationParam.ToArray());
                        Id++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
            return Id;
        }
        #endregion

        #region DeleteLocation
        public void DeleteLocation(DataTable dtData)
        {

            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Location oLocation = new Location();
                    oLocation.LocationID = int.Parse(dtData.Rows[i]["locationId"] == null ? "0" : dtData.Rows[i]["locationId"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var LocationParam = new List<SqlParameter> {
                    new SqlParameter("@LocationID",oLocation.LocationID)
                    };

                    #endregion Parameter

                    context.Database.ExecuteSqlCommand(Transport_Query.Delete_Location, LocationParam.ToArray());
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region GetLocationList
        public DataTable GetLocationList()
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
                        command.CommandText = Transport_Query.Get_Location_List;

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
        #endregion

        #region GetVehicleListByRegistration
        public DataTable GetVehicleListByRegistration(DataTable dtData)
        {
            DataTable result = new DataTable();
            string strStorageLoc = (dtData.Rows[0]["storagelocation"] == null ? "" : dtData.Rows[0]["storagelocation"].ToString());
            string strDestinationLoc = (dtData.Rows[0]["destinationlocation"] == null ? "" : dtData.Rows[0]["destinationlocation"].ToString());
            string strRegVec = (dtData.Rows[0]["registration"] == null ? "" : dtData.Rows[0]["registration"].ToString());
            string[] strTemp = strRegVec.Split(';');
            string strParaRegVec = "";
            for (int i = 0; i < strTemp.Length; i++)
            {
                strParaRegVec += strParaRegVec == "" ? "'" + strTemp[i] + "'" : ",'" + strTemp[i] + "'";
            }
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
                        command.CommandText = Transport_Query.Get_Vehicle_List_ByRegistration
                            .Replace("@Vehicle", strParaRegVec)
                            .Replace("@Storage", strStorageLoc)
                            .Replace("@Destination", strDestinationLoc);

                        

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

        #region CheckOutVehicles
        public void CheckOutVehicles(DataTable dtData)
        {
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Transport_ScheduleDetail odetail = new Transport_ScheduleDetail();
                    odetail.Vehicle = dtData.Rows[i]["vehicle"] == null ? "" : dtData.Rows[i]["vehicle"].ToString();
                    odetail.Status = 2;//CheckOut
                    odetail.CheckOutLocation = dtData.Rows[i]["checkOutLocation"] == null ? "" : dtData.Rows[i]["checkOutLocation"].ToString();
                    odetail.CheckOutDate = DateTime.Parse(dtData.Rows[i]["checkOutDate"] == null ? new DateTime(1970, 01, 01).ToString() : dtData.Rows[i]["checkOutDate"].ToString());
                    odetail.CheckOutTime = dtData.Rows[i]["checkOutTime"] == null ? "" : utcTimetoThaiTime(dtData.Rows[i]["checkOutTime"].ToString());

                    int txnType = 1;//CheckOut

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var detailParam = new List<SqlParameter> {
                     new SqlParameter("@Vehicle",odetail.Vehicle),
                    new SqlParameter("@Status",odetail.Status),
                     new SqlParameter("@CheckOutLocation",odetail.CheckOutLocation),
                    new SqlParameter("@CheckOutDate",odetail.CheckOutDate),
                    new SqlParameter("@CheckOutTime",odetail.CheckOutTime),
                    };

                    var LogParam = new List<SqlParameter> {
                    new SqlParameter("@VehicleNumber",odetail.Vehicle),
                    new SqlParameter("@TxnType",txnType),
                    new SqlParameter("@TxnLocation",odetail.CheckOutLocation),
                    new SqlParameter("@TxnDate",odetail.CheckOutDate),
                    new SqlParameter("@TxnTime",odetail.CheckOutTime)
                    };
                    #endregion Parameter

                    context.Database.ExecuteSqlCommand(Transport_Query.CheckOut_Vehicles, detailParam.ToArray());

                    context.Database.ExecuteSqlCommand(Transport_Query.Save_Transport_ATS_Log, LogParam.ToArray());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region CheckInVehicles
        public void CheckInVehicles(DataTable dtData)
        {
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Transport_ScheduleDetail odetail = new Transport_ScheduleDetail();
                    odetail.Vehicle = dtData.Rows[i]["vehicle"] == null ? "" : dtData.Rows[i]["vehicle"].ToString();
                    odetail.Status = 3;//CheckIn
                    odetail.CheckInLocation = dtData.Rows[i]["checkInLocation"] == null ? "" : dtData.Rows[i]["checkInLocation"].ToString();
                    odetail.CheckInDate = DateTime.Parse(dtData.Rows[i]["checkInDate"] == null ? new DateTime(1970, 01, 01).ToString() : dtData.Rows[i]["checkInDate"].ToString());
                    odetail.CheckInTime =  dtData.Rows[i]["checkInTime"] == null ? "" : utcTimetoThaiTime(dtData.Rows[i]["checkInTime"].ToString());
                    int txnType = 2;//CheckIn

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var detailParam = new List<SqlParameter> {
                     new SqlParameter("@Vehicle",odetail.Vehicle),
                    new SqlParameter("@Status",odetail.Status),
                    new SqlParameter("@CheckInLocation",odetail.CheckInLocation),
                    new SqlParameter("@CheckInDate",odetail.CheckInDate),
                    new SqlParameter("@CheckInTime",odetail.CheckInTime)
                    };

                    var LogParam = new List<SqlParameter> {
                    new SqlParameter("@VehicleNumber",odetail.Vehicle),
                    new SqlParameter("@TxnType",txnType),
                    new SqlParameter("@TxnLocation",odetail.CheckInLocation),
                    new SqlParameter("@TxnDate",odetail.CheckInDate),
                    new SqlParameter("@TxnTime",odetail.CheckInTime)
                    };

                    #endregion Parameter

                    context.Database.ExecuteSqlCommand(Transport_Query.CheckIn_Vehicles, detailParam.ToArray());

                    context.Database.ExecuteSqlCommand(Transport_Query.Save_Transport_ATS_Log, LogParam.ToArray());
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        private string utcTimetoThaiTime(string utcTime)
        {
            string inputFormat = "hh:mm:tt";
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime utcDateTime;
            DateTime.TryParseExact(utcTime, inputFormat, provider, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out utcDateTime);

            // Define the Bangkok time zone
            TimeZoneInfo bangkokTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            // Convert the UTC DateTime to Bangkok time
            DateTime bangkokDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, bangkokTimeZone);

            // Format the Bangkok DateTime back to a string
            string strThaiTime = bangkokDateTime.ToString("hh:mm:tt", provider);

            return strThaiTime;
        }

        //#region GetLocation
        //public DataTable GetLocation()
        //{
        //    DataTable result = new DataTable();
        //    try
        //    {
        //        using (var context = new dataFeedContext())
        //        {
        //            context.Database.CommandTimeout = 300000;
        //            if (context.Database.Connection.State == ConnectionState.Closed)
        //            {
        //                context.Database.Connection.Open();
        //            }

        //            using (var command = context.Database.Connection.CreateCommand())
        //            {
        //                command.CommandText = Transport_Query.Get_Location;

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    result.Load(reader);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("===================================================================");
        //        Console.WriteLine(ex.Message);
        //    }
        //    return result;
        //}
        //#endregion

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
    #endregion

    #region ATS_Query
    public class ATS_Query {
        public static string Clear_Location_Snapshot = @"TRUNCATE TABLE [dbo].[ATS_Locations_Prev];";
        public static string Location_Load_Data = @"EXEC ATS_Location_Migrate";
        public static string Location_Get = "SELECT * FROM ATS_Locations_ToTransfer ORDER BY id";

        public static string Clear_Vehicle_Snapshot = @"TRUNCATE TABLE [dbo].[ATS_Vehicles_Prev];";
        public static string Vehicle_Load_Data = @"EXEC ATS_Vehicle_Migrate";
        public static string Vehicle_Get = "SELECT * FROM ATS_Vehicles_ToTransfer ORDER BY id";
       
        public static string Logger_Insert = @"INSERT INTO [dbo].[Log_Txn] VALUES (@LogDate,@TypeOfData,@DataJson,@TotalRecordCount,@RequestBy)";
        public static string Logger_GetByDate = "SELECT * FROM [Log_Txn] WHERE CONVERT(varchar(10),LogDate,112) = @LogDate AND TypeOfData = @TypeOfData AND [RequestBy] = @RequestBy";
        public static string Clear_Cache = "TRUNCATE TABLE [dbo].[ATS_Vehicles_Prev];TRUNCATE TABLE [dbo].[ATS_Locations_Prev];"; //DELETE Log_Txn WHERE RequestBy = 'ATS'
    }
    #endregion

    #region Transport_Query
    public class Transport_Query
    {
        #region User
        public static string Save_Transport_User = $@"INSERT INTO Transport_User (UserName,UserEmail,LoginName,Password,DepartmentID,UserType)
                                        VALUES(@UserName,@UserEmail,@LoginName,@Password,@DepartmentID,@UserType);SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Update_Transport_User = $@"UPDATE Transport_User set [UserName]=@UserName,
                                                                                [UserEmail]=@UserEmail,
                                                                                [LoginName]=@LoginName,
                                                                                [DepartmentID]=@DepartmentID,
                                                                                [UserType]=@UserType where UserID=@UserID"; //[Password]=@Password,

        public static string Update_Password = $@"Update Transport_User set [Password]=@Password where UserID=@UserID";

        public static string Delete_Transport_User = $@"Delete Transport_User where UserID=@UserID ";

        public static string Login_Transport_User = $@"Select * from Transport_User where LoginName=@LoginName and Password=@Password";

        public static string Check_Duplicate_User = $@"Select * from Transport_User where LoginName=@LoginName and UserEmail=@UserEmail and UserID<>@UserID";

        public static string Get_User_List = $@"Select * from Transport_User";

        public static string Get_UserByUserID = $@"Select * from Transport_User where UserID=@UserID";
        #endregion

        #region Transport Order & Detail
        public static string Get_LastestOrderID = $@"select Top(1) substring(OrderCode,12,5)OrderCode from Transport_OrderDoc 
                                   where LEFT(CONVERT(varchar(10),CreateDate,112), 6)=LEFT(CONVERT(varchar(10),@CreateDate,112), 6)
                                   order by OrderCode desc";

        public static string Get_LastestCreateOrderDate = $@"select Top(1) LEFT(CONVERT(varchar(10),CreateDate,112), 6) CreateDate from Transport_OrderDoc 
                                       where LEFT(CONVERT(varchar(10),CreateDate,112), 6)=LEFT(CONVERT(varchar(10),@CreateDate,112), 6) order by CreateDate desc";

        public static string Save_Transport_Order = $@"INSERT INTO Transport_OrderDoc (OrderCode,UploadDate,CreateDate,CreatedBy)
                        VALUES(@OrderCode,@UploadDate,@CreateDate,@CreatedBy);SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Save_Transport_OrderDetail = $@"INSERT INTO Transport_OrderDocDetail (OrderID, DepartureDate, ArrivalDate, IMAPNumber, Registration, SellerName, 
                                       VendorName, StorageLocation, Destination, MakeDesc, ModelDesc, Variants, 
                                       ChassisNo, PickupRoofType, Cost, FeeCharged)
                                        VALUES (@OrderID, @DepartureDate, @ArrivalDate, @IMAPNumber, @Registration, @SellerName, @VendorName, 
                                                @StorageLocation, @Destination, @MakeDesc, @ModelDesc, @Variants, @ChassisNo, @PickupRoofType, 
                                                @Cost, @FeeCharged);
                                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Update_Transport_Order = $@"UPDATE Transport_OrderDoc set 
                                                                                [UpdateDate]=@UpdateDate,
                                                                                [UpdatedBy]=@UpdatedBy where OrderID=@OrderID";

        public static string Delete_Transport_OrderDetail = $@"Delete Transport_OrderDocDetail where OrderID=@OrderID";

        public static string Delete_Transport_Order = $@"Delete Transport_OrderDoc where OrderID=@OrderID";

        public static string Get_TransportOrder_List = $@"SELECT 
                                                            OrderID,
                                                            OrderCode,
                                                            DATEDIFF(SECOND, '1970-01-01 00:00:00', UploadDate) AS UploadDate,
                                                            DATEDIFF(SECOND, '1970-01-01 00:00:00', CreateDate) AS CreateDate
                                                        FROM 
                                                            Transport_OrderDoc";

        public static string Get_OrderDetail_ByOrderId = $@"select OrderID,DATEDIFF(SECOND, '1970-01-01 00:00:00', DepartureDate) AS DepartureDate,
                                                            DATEDIFF(SECOND, '1970-01-01 00:00:00', ArrivalDate) AS ArrivalDate,IMAPNumber,Registration,
                                                            SellerName,VendorName,StorageLocation,Destination,MakeDesc,ModelDesc,Variants,ChassisNo,PickupRoofType,Cost,FeeCharged
                                                             from Transport_OrderDocDetail where OrderID=@OrderID";
        #endregion

        #region Transport Request & Detail
        public static string Save_Transport_Request = $@"INSERT INTO Transport_Request (TotalRecords,UploadDate,UploadBy)
                        VALUES(@TotalRecords,@UploadDate,@UploadBy);SELECT CAST(SCOPE_IDENTITY() AS INT);";
        #endregion

        #region Transport Schedule & detail
        public static string Save_Transport_Schedule = $@"INSERT INTO TransportSchedule (EstimateDepartureDate,EstimateArrivalDate,FromYard,ToYard,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,VendorId)
                        VALUES(@EstimateDepartureDate,@EstimateArrivalDate,@FromYard,@ToYard,@CreatedBy,@CreatedDate,@UpdatedBy,@UpdatedDate,@VendorId);SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Save_Transport_ScheduleDetail = $@"INSERT INTO TransportScheduleDetail (ScheduleID,Vehicle,Status)
                                        VALUES(@ScheduleID,@Vehicle,@Status)";//,CheckOutDate,CheckOutTime,CheckInDate,CheckInTime,@CheckOutDate,@CheckOutTime,@CheckInDate,@CheckInTime

        public static string Get_Schedule_List = $@"select scheduleID,DATEDIFF(SECOND, '1970-01-01 00:00:00', EstimateDepartureDate) as estimateDepartureDate,
		                                                    DATEDIFF(SECOND, '1970-01-01 00:00:00', EstimateArrivalDate) as  estimateArrivalDate,fromYard,toYard,createdBy,
		                                                    DATEDIFF(SECOND, '1970-01-01 00:00:00', CreatedDate) as  createdDate,updatedBy,
		                                                    DATEDIFF(SECOND, '1970-01-01 00:00:00', UpdatedDate) as  updatedDate,vendorId
                                                     from TransportSchedule";

        public static string Get_Schedule_ByScheduleID = $@"select ScheduleID,CONVERT(varchar(10), EstimateDepartureDate, 120)EstimateDepartureDate,
		                                                CONVERT(varchar(10), EstimateArrivalDate, 120)EstimateArrivalDate,FromYard,ToYard 
                                                        from TransportSchedule where ScheduleID=@ScheduleID";

        public static string Get_ScheduleDetail_ByScheduleID = $@"SELECT Vehicle,BuildYear,MakeDesc,Variants,AuctionCode,Registration
                                                                        FROM
                                                                        (select * from TransportScheduleDetail
                                                                        where ScheduleID=@ScheduleID) Schedule
                                                                        LEFT JOIN
                                                                        (SELECT * FROM Transport_RequestDetail
                                                                        WHERE DetailID IN
                                                                        (SELECT Max(DetailID) DetailID FROM Transport_RequestDetail GROUP BY VehicleNumber))Request
                                                                        ON Request.VehicleNumber = Schedule.Vehicle";

        public static string CheckOut_Vehicles = $@"Update TransportScheduleDetail set [Status]=@Status,[CheckOutLocation]=@CheckOutLocation,[CheckOutDate]=@CheckOutDate,[CheckOutTime]=@CheckOutTime where Vehicle=@Vehicle";

        public static string CheckIn_Vehicles = $@"Update TransportScheduleDetail set [Status]=@Status,[CheckInLocation]=@CheckInLocation,[CheckInDate]=@CheckInDate,[CheckInTime]=@CheckInTime where Vehicle=@Vehicle";

        public static string Save_Transport_ATS_Log = $@"INSERT INTO Transport_ATS_Log (TxnType,TxnDate,TxnTime,VehicleNumber,TxnLocation)
                        VALUES(@TxnType,@TxnDate,@TxnTime,@VehicleNumber,@TxnLocation)";

        public static string Delete_Transport_Schedule = $@"Delete TransportSchedule where ScheduleID=@ScheduleID ";

        public static string Delete_Transport_ScheduleDetail = $@"Delete TransportScheduleDetail where ScheduleID=@ScheduleID ";

        public static string Update_Transport_Schedule = $@"UPDATE TransportSchedule set [EstimateDepartureDate]=@EstimateDepartureDate,
                                                                                [EstimateArrivalDate]=@EstimateArrivalDate,
                                                                                [FromYard]=@FromYard,
                                                                                [ToYard]=@ToYard,
                                                                                [UpdatedBy]=@UpdatedBy,
                                                                                [UpdatedDate]=@UpdatedDate,
                                                                                [VendorId]=@VendorId where ScheduleID=@ScheduleID";
        #endregion

        //public static string Get_Location = $@"SELECT LocationId , Location
        //                                    FROM IMAP.dbo.StorageLocation WHERE [IsActived] = 1";



        public static string Get_Vehicle_List_ByRegistration = $@"SELECT * FROM Transport_RequestDetail 
                                                                WHERE StorageLocation = '@Storage' And DestinationLocation = '@Destination'
                                                                AND (Registration IN (@Vehicle) OR VehicleNumber IN (@Vehicle))";

        #region Vendor
        public static string Save_Vendor = $@"INSERT INTO Vendor (VendorName,VendorCode,ContactPhoneNumber,Email,SecondaryEmails,Remark)
                                        VALUES(@VendorName,@VendorCode,@ContactPhoneNumber,@Email,@SecondaryEmails,@Remark);SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Update_Vendor = $@"UPDATE Vendor set [VendorName]=@VendorName,
                                                                                [VendorCode]=@VendorCode,
                                                                                [ContactPhoneNumber]=@ContactPhoneNumber,
                                                                                [Email]=@Email,
                                                                                [SecondaryEmails]=@SecondaryEmails,
                                                                                [Remark]=@Remark where VendorID=@VendorID";

        public static string Delete_Vendor = $@"Delete Vendor where VendorID=@VendorID";

        public static string Check_Duplicate_Vendor = $@"Select * from Vendor where (ContactPhoneNumber=@ContactPhoneNumber or Email=@Email) and VendorID<>@VendorID";

        public static string Get_Vendor_List = $@"Select * from Vendor";

        public static string Get_Vendor_ForCombo = $@"SELECT VendorId , VendorName
                                            FROM Vendor";


        public static string Get_VendorEmails_ByName = $@"SELECT * FROM Vendor where VendorName=@VendorName";
        #endregion

        #region Location
        public static string Save_Location = $@"INSERT INTO Transport_Location (LocationName,LocationCode,Email)
                                        VALUES(@LocationName,@LocationCode,@Email);SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Update_Location = $@"UPDATE Transport_Location set [LocationName]=@LocationName,
                                                                                [LocationCode]=@LocationCode,
                                                                                [Email]=@Email where LocationID=@LocationID";

        public static string Delete_Location = $@"Delete Transport_Location where LocationID=@LocationID";

        public static string Check_Duplicate_Location = $@"Select * from Transport_Location where (LocationName=@LocationName or LocationCode=@LocationCode) and LocationID<>@LocationID";

        public static string Get_Location_List = $@"Select * from Transport_Location";
        #endregion
        
        public static string get_TransportLocByImapNo = @"SELECT TOP 1 IMAPNumber,VendorName,[StorageLocation],Destination,COALESCE(NULLIF(PickupRoofType, ''), '-') AS RoofType FROM fn_getTransportStatus('',GETDATE()-30,GETDATE()) 
                                                            WHERE IMAPNumber = @IMAPNumber ORDER BY OrderDetailID DESC";

        #region dashboard
        public static string get_TransportStatusfordb = @"SELECT IMAPNumber,Registration,SellerName,VendorName,StorageLocation,Destination,1 Status FROM fn_getTransportStatus(@VendorID, @FromDate, @ToDate) Where TransportStatus = 'Pending'
                                                            UNION ALL
                                                            SELECT IMAPNumber,Registration,SellerName,VendorName,StorageLocation,Destination,2 Status FROM fn_getTransportStatus(@VendorID, @FromDate, @ToDate) WHERE TransportStatus = 'Check Out'
                                                            UNION ALL
                                                            SELECT IMAPNumber,Registration,SellerName,VendorName,StorageLocation,Destination,3 Status FROM fn_getTransportStatus(@VendorID, @FromDate, @ToDate) WHERE TransportStatus = 'Check In'";

        public static string get_TransportLocfordb = "SELECT * FROM fn_Transport_Location(@VendorID, @FromDate, @ToDate) ORDER BY TotalPending DESC,TotalCheckOut DESC,TotalCheckIn DESC";

        public static string get_TransportStatusCategory = @"SELECT sc.CategoryTypeName, sc.CategoryTypeOrder,
                                                            ISNULL(COUNT(StatusData.IMAPNumber),0) TotalVehicle,
                                                            SUM( CASE WHEN TransportStatus = 'Pending' THEN 1 ELSE 0 END) Pending,
                                                            SUM( CASE WHEN TransportStatus = 'Check Out' THEN 1 ELSE 0 END) CheckOut,
                                                            SUM( CASE WHEN TransportStatus = 'Check In' THEN 1 ELSE 0 END) CheckIn
                                                            FROM 
                                                            (SELECT DISTINCT CategoryType,CategoryTypeName,CategoryTypeOrder FROM MatWeb.dbo.VW_Selling_CategoryType) sc
                                                            LEFT JOIN fn_getTransportStatus(@VendorID, @FromDate, @ToDate) StatusData
                                                            ON StatusData.CategoryTypeName = sc.CategoryTypeName
                                                            GROUP BY sc.CategoryTypeName,sc.CategoryTypeOrder
                                                            ORDER BY sc.CategoryTypeOrder";
        #endregion
    }
    #endregion

    #region ATS_Utility
    public class ATS_Utility
    {
        #region convertToLocationList
        public static List<ATS_MOTTO_Location> convertToLocationList(DataTable dtData)
        {
            List<ATS_MOTTO_Location> lstRtn = new List<ATS_MOTTO_Location> ();
            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                lstRtn.Add(new ATS_MOTTO_Location { 
                    id = int.Parse(dtData.Rows[i]["id"] == null ? "0" : dtData.Rows[i]["id"].ToString()), 
                    display_name = (dtData.Rows[i]["display_name"] == null ? "" : dtData.Rows[i]["display_name"].ToString()), 
                    address = (dtData.Rows[i]["address"] == null ? "" : dtData.Rows[i]["address"].ToString()), 
                    latitude = (dtData.Rows[i]["latitude"] == null ? "" : dtData.Rows[i]["latitude"].ToString()), 
                    longitude = (dtData.Rows[i]["longitude"] == null ? "" : dtData.Rows[i]["longitude"].ToString())
                });
            }
            return lstRtn;
        }
        #endregion

        #region convertToVehicleList
        public static List<ATS_MOTTO_Vehicle> convertToVehicleList(DataTable dtData)
        {
            List<ATS_MOTTO_Vehicle> lstRtn = new List<ATS_MOTTO_Vehicle>();            
            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                lstRtn.Add(new ATS_MOTTO_Vehicle
                {
                    id = int.Parse(dtData.Rows[i]["id"] == null ? "" : dtData.Rows[i]["id"].ToString()),
                    business_type = (dtData.Rows[i]["business_type"] == null ? "" : dtData.Rows[i]["business_type"].ToString()),
                    current_location_id = int.Parse(dtData.Rows[i]["current_location_id"] == null ? "" : dtData.Rows[i]["current_location_id"].ToString()),
                    country_id = int.Parse(dtData.Rows[i]["country_id"] == null ? "" : dtData.Rows[i]["country_id"].ToString()),
                    qr_code = (dtData.Rows[i]["qr_code"] == null ? "" : dtData.Rows[i]["qr_code"].ToString()),
                    inventory = new List<ATS_MOTTO_Vehicle_Detail>{
                        new ATS_MOTTO_Vehicle_Detail{ 
                            id = int.Parse(dtData.Rows[i]["inv_id"] == null ? "" : dtData.Rows[i]["inv_id"].ToString()), 
                            make=(dtData.Rows[i]["make"] == null ? "" : dtData.Rows[i]["make"].ToString()), 
                            model= (dtData.Rows[i]["model"] == null ? "" : dtData.Rows[i]["model"].ToString()), 
                            submodel=(dtData.Rows[i]["submodel"] == null ? "" : dtData.Rows[i]["submodel"].ToString()), 
                            licence_plate_number=(dtData.Rows[i]["licence_plate_number"] == null ? "" : dtData.Rows[i]["licence_plate_number"].ToString()),
                            engine_number=(dtData.Rows[i]["engine_number"] == null ? "" : dtData.Rows[i]["engine_number"].ToString()),
                            chassis_number=(dtData.Rows[i]["chassis_number"] == null ? "" : dtData.Rows[i]["chassis_number"].ToString()),
                            engine_capacity=(dtData.Rows[i]["engine_capacity"] == null ? "" : dtData.Rows[i]["engine_capacity"].ToString()), 
                            country_id=int.Parse(dtData.Rows[i]["inv_country_id"] == null ? "" : dtData.Rows[i]["inv_country_id"].ToString()),
                            manufacture_year=int.Parse(dtData.Rows[i]["manufacture_year"] == null ? "" : dtData.Rows[i]["manufacture_year"].ToString())
                            
                        }
                    }
                });
            }
            return lstRtn;
        }
        #endregion

        #region ImageToBase64
        static string ImageToBase64(byte[] imageBytes)
        {
            return Convert.ToBase64String(imageBytes);
            //using (MemoryStream memoryStream = new MemoryStream())
            //{
            //    image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            //    byte[] bytes = memoryStream.ToArray();
            //    return Convert.ToBase64String(bytes);
            //}
        }
        #endregion
    }
    #endregion
}
