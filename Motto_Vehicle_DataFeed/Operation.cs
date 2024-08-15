using MOTTO_DATAFEED.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Motto_Vehicle_DataFeed.DAO;

namespace Motto_Vehicle_DataFeed
{
    public class Operation_DATAFEED
    {
        public Operation_DATAFEED() { }

        #region StatusType
        #region SaveStatusType
        public int SaveStatusType(DataTable dtData)
        {
            int Id = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Status_Type oStatusType = new Status_Type();
                    oStatusType.StatusName = (dtData.Rows[i]["statusName"] == null ? "" : dtData.Rows[i]["statusName"].ToString());
                    oStatusType.StatusName_TH = (dtData.Rows[i]["statusName_TH"] == null ? "" : dtData.Rows[i]["statusName_TH"].ToString());
                    oStatusType.StatusType = (dtData.Rows[i]["statusType"] == null ? "" : dtData.Rows[i]["statusType"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var Param = new List<SqlParameter> {
                    new SqlParameter("@StatusName",oStatusType.StatusName),
                    new SqlParameter("@StatusName_TH",oStatusType.StatusName_TH),
                    new SqlParameter("@StatusType",oStatusType.StatusType),
                    };

                    #endregion Parameter
                    Id = context.Database.SqlQuery<int>(Operation_Query.Save_StatusType, Param.ToArray()).SingleOrDefault();
                    
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

        #region UpdateStatusType
        public int UpdateStatusType(DataTable dtData)
        {
            int Id = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Status_Type oStatusType = new Status_Type();
                    oStatusType.StatusName = (dtData.Rows[i]["statusName"] == null ? "" : dtData.Rows[i]["statusName"].ToString());
                    oStatusType.StatusName_TH = (dtData.Rows[i]["statusName_TH"] == null ? "" : dtData.Rows[i]["statusName_TH"].ToString());
                    oStatusType.StatusType = (dtData.Rows[i]["statusType"] == null ? "" : dtData.Rows[i]["statusType"].ToString());
                    oStatusType.StatusTypeID = int.Parse(dtData.Rows[i]["statusTypeID"] == null ? "0" : dtData.Rows[i]["statusTypeID"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var Param = new List<SqlParameter> {
                    new SqlParameter("@StatusName",oStatusType.StatusName),
                    new SqlParameter("@StatusName_TH",oStatusType.StatusName_TH),
                    new SqlParameter("@StatusType",oStatusType.StatusType),
                    new SqlParameter("@StatusTypeID",oStatusType.StatusTypeID)
                    };

                    #endregion Parameter
                    context.Database.ExecuteSqlCommand(Operation_Query.Update_StatusType, Param.ToArray());
                    Id++;
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

        #region DeleteStatusType
        public void DeleteStatusType(DataTable dtData)
        {

            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Status_Type oStatusType = new Status_Type();
                    oStatusType.StatusTypeID = int.Parse(dtData.Rows[i]["statusTypeID"] == null ? "0" : dtData.Rows[i]["statusTypeID"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var Param = new List<SqlParameter> {
                    new SqlParameter("@StatusTypeID",oStatusType.StatusTypeID)
                    };

                    #endregion Parameter

                    context.Database.ExecuteSqlCommand(Operation_Query.Delete_StatusType, Param.ToArray());
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region GetStatusTypeList
        public DataTable GetStatusTypeList()
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
                        command.CommandText = Operation_Query.Get_StatusType_List;

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

        #region Create_Transport_ATS_Log
        public int Create_Transport_ATS_Log(DataTable dtData)
        {
            int Id = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Transport_ATS_Log oATSlog = new Transport_ATS_Log();
                    oATSlog.TxnType = int.Parse(dtData.Rows[i]["txnType"] == null ? "" : dtData.Rows[i]["txnType"].ToString());
                    double dFromDate = Convert.ToDouble(dtData.Rows[0]["txnDate"] == null ? 0 : dtData.Rows[0]["txnDate"]);
                    oATSlog.TxnDate = (dFromDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dFromDate));
                    oATSlog.TxnTime = (dtData.Rows[i]["txnTime"] == null ? "" : dtData.Rows[i]["txnTime"].ToString());
                    oATSlog.VehicleNumber = dtData.Rows[i]["vehicleNumber"] == null ? "0" : dtData.Rows[i]["vehicleNumber"].ToString();
                    oATSlog.TxnLocation = (dtData.Rows[i]["txnLocation"] == null ? "" : dtData.Rows[i]["txnLocation"].ToString());
                    oATSlog.StatusUpdateBy = int.Parse(dtData.Rows[i]["statusUpdateBy"] == null ? "0" : dtData.Rows[i]["statusUpdateBy"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var Param = new List<SqlParameter> {
                    new SqlParameter("@TxnType",oATSlog.TxnType),
                    new SqlParameter("@TxnDate",oATSlog.TxnDate),
                    new SqlParameter("@TxnTime",oATSlog.TxnTime),
                    new SqlParameter("@VehicleNumber",oATSlog.VehicleNumber),
                    new SqlParameter("@TxnLocation",oATSlog.TxnLocation),
                    new SqlParameter("@StatusUpdateBy",oATSlog.StatusUpdateBy),
                    };

                    #endregion Parameter
                    Id = context.Database.SqlQuery<int>(Operation_Query.Create_Transport_ATS_Log, Param.ToArray()).SingleOrDefault();

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
                    string Locationid = (dtData.Rows[i]["locationID"] == null ? "0" : dtData.Rows[i]["locationID"].ToString());

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
                        command.CommandText = Operation_Query.Check_Duplicate_User;

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
                        Id = context.Database.SqlQuery<int>(Operation_Query.Save_Transport_User, UserParam.ToArray()).SingleOrDefault();
                        
                        #region OperationUserLocationParameters
                        var OperationUserLocationParam = new List<SqlParameter> {
                        new SqlParameter("@LocationID",Locationid),
                        new SqlParameter("@UserID",Id)
                        };
                        #endregion Parameters

                        context.Database.ExecuteSqlCommand(Operation_Query.Save_OperationUserLocation, OperationUserLocationParam.ToArray());
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
                    string Locationid = (dtData.Rows[i]["locationID"] == null ? "0" : dtData.Rows[i]["locationID"].ToString());

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
                        command.CommandText = Operation_Query.Check_Duplicate_User;

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
                        context.Database.ExecuteSqlCommand(Operation_Query.Update_Transport_User, UserParam.ToArray());


                        #region OperationUserLocationParameters
                        var deleteOperationUserLocationParam = new List<SqlParameter> {
                        new SqlParameter("@UserID",User.UserID)
                        };

                        var OperationUserLocationParam = new List<SqlParameter> {
                        new SqlParameter("@LocationID",Locationid),
                        new SqlParameter("@UserID",User.UserID)
                        };
                        #endregion Parameters

                        context.Database.ExecuteSqlCommand(Operation_Query.Delete_OperationUserLocation, deleteOperationUserLocationParam.ToArray());

                        context.Database.ExecuteSqlCommand(Operation_Query.Save_OperationUserLocation, OperationUserLocationParam.ToArray());

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

                    context.Database.ExecuteSqlCommand(Operation_Query.Delete_Transport_User, UserParam.ToArray());

                    context.Database.ExecuteSqlCommand(Operation_Query.Delete_OperationUserLocation, UserParam.ToArray());
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
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
                        command.CommandText = Operation_Query.Get_User_List;

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
                        command.CommandText = Operation_Query.Login_Transport_User;

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


        #endregion

        #region GetLocations
        public DataTable GetLocations()
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
                        command.CommandText = Operation_Query.Get_OperationLocation;

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

        #region GetLocationsByUser
        public DataTable GetLocationsByUser(string userid)
        {
            DataTable result = new DataTable();
            int UserID = int.Parse(userid == null ? "0" : userid);

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
                        command.CommandText = Operation_Query.Get_Locations_ByUser;

                        command.Parameters.Add(new SqlParameter("@UserID", UserID));

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

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }

    #region Operation_Query
    public class Operation_Query
    {
        #region StatusType
        public static string Save_StatusType = $@"INSERT INTO Status_Type (StatusName,StatusName_TH,StatusType)
                                        VALUES(@StatusName,@StatusName_TH,@StatusType);SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Update_StatusType = $@"UPDATE Status_Type set [StatusName]=@StatusName,
                                                                                [StatusName_TH]=@StatusName_TH,
                                                                                [StatusType]=@StatusType where StatusTypeID=@StatusTypeID";

        public static string Delete_StatusType = $@"Delete Status_Type where StatusTypeID=@StatusTypeID";

        public static string Get_StatusType_List = $@"Select * from Status_Type";
        #endregion

        public static string Create_Transport_ATS_Log = $@"INSERT INTO Transport_ATS_Log (TxnType,TxnDate,TxnTime,VehicleNumber,TxnLocation,StatusUpdateBy)
                        VALUES(@TxnType,@TxnDate,@TxnTime,@VehicleNumber,@TxnLocation,@StatusUpdateBy);SELECT CAST(SCOPE_IDENTITY() AS INT);";

        #region User
        public static string Save_Transport_User = $@"INSERT INTO Transport_User (UserName,UserEmail,LoginName,Password,DepartmentID,UserType)
                                        VALUES(@UserName,@UserEmail,@LoginName,@Password,@DepartmentID,@UserType);SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Update_Transport_User = $@"UPDATE Transport_User set [UserName]=@UserName,
                                                                                [UserEmail]=@UserEmail,
                                                                                [LoginName]=@LoginName,
                                                                                [DepartmentID]=@DepartmentID,
                                                                                [UserType]=@UserType where UserID=@UserID"; //[Password]=@Password,

        public static string Delete_Transport_User = $@"Delete Transport_User where UserID=@UserID ";

        public static string Check_Duplicate_User = $@"Select * from Transport_User where LoginName=@LoginName and UserEmail=@UserEmail and UserID<>@UserID";

        public static string Get_User_List = $@"Select * from Transport_User";

        public static string Login_Transport_User = $@"Select * from Transport_User where LoginName=@LoginName and Password=@Password";
        #endregion

        public static string Save_OperationUserLocation = $@"INSERT INTO OperationUserLocation(UserID,LocationID) VALUES(@UserID,@LocationID)";

        public static string Delete_OperationUserLocation = $@"Delete OperationUserLocation where UserID=@UserID";

        public static string Get_OperationLocation = $@"SELECT * FROM fn_GetATSLocation() where latitude is not null or longitude is not null";

        public static string Get_Locations_ByUser = $@"select userID,locationID from User_Location where UserID = @UserID";
    }
    #endregion
}
