using MOTTO_DATAFEED.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Motto_Vehicle_DataFeed.DAO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Web.Http.Results;
using System.Runtime.Remoting.Contexts;
using System.Xml.Linq;
using System.Globalization;
using static Motto_Vehicle_DataFeed.Operation_DATAFEED;
using System.Web.Http;

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
        public async Task<int> Create_Transport_ATS_Log(DataTable dtData)
        {
            int Id = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    string exitedDate = $"{UnixTimeStampToDateTimeForIMAT(Convert.ToDouble(dtData.Rows[i]["txnDate"])):yyyy-MM-dd}T{dtData.Rows[i]["txnTime"]}";
                    HttpResponseMessage apiResponse = null;
                    string imagesReponse = "";
                    if (dtData.Rows[i]["txnType"].ToString() == "2") // Check In
                    {
                        apiResponse = await SetStorageLocationIMATAsync(
                            dtData.Rows[i]["vehicleNumber"].ToString(),
                            dtData.Rows[i]["txnLocation"].ToString(),
                            dtData.Rows[i]["statusUpdateBy"].ToString()
                        );
                    }
                    else if (dtData.Rows[i]["txnType"].ToString() == "3") // Exit
                    {
                        apiResponse = await SetExitStatusToIMATAsync(
                            dtData.Rows[i]["vehicleNumber"].ToString(),
                            dtData.Rows[i]["txnLocation"].ToString(),
                            exitedDate,
                            dtData.Rows[i]["statusUpdateBy"].ToString()
                        );

                        imagesReponse = await SetExitedImagesToJsonString(
                            dtData.Rows[i]["idcardPhoto"].ToString(),
                            dtData.Rows[i]["vehiclePhoto"].ToString(),
                            dtData.Rows[i]["documentPhoto"].ToString()
                        );
                    }

                    Transport_ATS_Log oATSlog = new Transport_ATS_Log();
                    oATSlog.TxnType = int.Parse(dtData.Rows[i]["txnType"] == null ? "" : dtData.Rows[i]["txnType"].ToString());
                    double dFromDate = Convert.ToDouble(dtData.Rows[0]["txnDate"] == null ? 0 : dtData.Rows[0]["txnDate"]);
                    oATSlog.TxnDate = (dFromDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dFromDate));
                    oATSlog.TxnTime = (dtData.Rows[i]["txnTime"] == null ? "" : dtData.Rows[i]["txnTime"].ToString());
                    oATSlog.VehicleNumber = dtData.Rows[i]["vehicleNumber"] == null ? "" : dtData.Rows[i]["vehicleNumber"].ToString();
                    oATSlog.TxnLocation = (dtData.Rows[i]["txnLocationId"] == null ? "" : dtData.Rows[i]["txnLocationId"].ToString());
                    oATSlog.StatusUpdateBy = (dtData.Rows[i]["statusUpdateBy"] == null ? "" : dtData.Rows[i]["statusUpdateBy"].ToString());
                    oATSlog.OtherResponses = imagesReponse;
                    if (apiResponse != null)
                    {
                        oATSlog.ResponseStatus = (int?)apiResponse.StatusCode ?? 0;
                        oATSlog.ResponseData = await apiResponse.Content.ReadAsStringAsync() ?? "";
                    }
                    else
                    {
                        oATSlog.ResponseStatus = 0;
                        oATSlog.ResponseData = ""; 
                    }
                   

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
                    new SqlParameter("@ResponseStatus",oATSlog.ResponseStatus),
                    new SqlParameter("@ResponseData",oATSlog.ResponseData),
                    new SqlParameter("@OtherResponses",oATSlog.OtherResponses),
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


        // Function to call the API for setting the vehicle's exit status
        private async Task<HttpResponseMessage> SetExitStatusToIMATAsync(string vehicle, string storageLocation, string exitedDate, string staffName)
        {
            System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)(768 | 3072);
            var url = "https://mapapi-uat.mottoauction.com/connectors/api/mats/setVehicleExit";
            var requestBody = new
            {
                vehicle,
                storageLocation,
                exitedDate,
                staffName
            };
            var json = JsonConvert.SerializeObject(requestBody);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.TryAddWithoutValidation("x-api-key", "e9ab5c97-019e-4a83-ad6f-b1d571b24d5d");
                request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
                request.Content = data;

                return await client.SendAsync(request);
            }
        }

        // Function to call the API for changing the storage location
        private async Task<HttpResponseMessage> SetStorageLocationIMATAsync(string vehicle, string storageTo, string userName)
        {
            System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)(768 | 3072);
            var url = "https://mapapi-uat.mottoauction.com/connectors/api/mats/setStorageLocation";
            var requestBody = new
            {
                vehicle,
                storageTo,
                userName
            };
            var json = JsonConvert.SerializeObject(requestBody);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.TryAddWithoutValidation("x-api-key", "e9ab5c97-019e-4a83-ad6f-b1d571b24d5d");
                request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
                request.Content = data;

                return await client.SendAsync(request);
            }
        }

        private async Task<string> SetExitedImagesToJsonString(string idphoto, string vehiclephoto, string docphoto)
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
                    command.CommandText = Operation_Query.Get_ATS_Log_Exited;

                    using (var reader = command.ExecuteReader())
                    {
                        result.Load(reader);
                    }
                }
            }

            int imageCount = result.Rows.Count + 1;

            // Create a list to hold the response data
            var responses = new List<ImageResponse>();

            // Process each image
            async Task ProcessImage(string photo, string type)
            {
                HttpResponseMessage response = await UploadExitedImageToIMATAsync(photo, imageCount , type);
                var responseData = new ImageResponse
                {
                    ImageName = $"ExitedImage_{imageCount}_{type}.jpg",
                    ResponseStatus = (int)response.StatusCode,
                    ResponseData = await response.Content.ReadAsStringAsync()
                };
                responses.Add(responseData);
            }

            await ProcessImage(idphoto, "IdCard");
            await ProcessImage(vehiclephoto, "VehiclePhoto");
            await ProcessImage(docphoto, "DocumentPhoto");

            // Serialize the list to JSON
            string jsonResponse = JsonConvert.SerializeObject(responses, Formatting.Indented);

            return jsonResponse;
        }
        private async Task<HttpResponseMessage> UploadExitedImageToIMATAsync(string photo,int imageNo,string type)
        {
            string ImageNo = imageNo.ToString("D18");
            string ImageName = $"ExitedImage_{imageNo}_{type}.jpg";
            string base64Data = photo.Contains(",") ? photo.Substring(photo.IndexOf(',') + 1) : photo;
            byte[] imageBytes = Convert.FromBase64String(base64Data);
            long ImageSize = imageBytes.Length;

            string File = null;
            System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)(768 | 3072);
            var url = "https://mapapi-uat.mottoauction.com/connectors/api/mats/exitImage";
            var requestBody = new
            {
                ImageNo,
                ImageName,
                ImageSize,
                ImageType="image/jpeg",
                File,
                Image64String=photo.Replace("data:image/jpeg;base64,",""),
            };
            var json = JsonConvert.SerializeObject(requestBody);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.TryAddWithoutValidation("x-api-key", "e9ab5c97-019e-4a83-ad6f-b1d571b24d5d");
                request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
                request.Content = data;

                return await client.SendAsync(request);
            }
        }

        // Utility function to convert Unix timestamp to DateTime
        private DateTime UnixTimeStampToDateTimeForIMAT(double unixTimeStamp)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds((long)unixTimeStamp);
            return dateTimeOffset.UtcDateTime;
        }

        public class ImageResponse
        {
            public string ImageName { get; set; }
            public int ResponseStatus { get; set; }
            public string ResponseData { get; set; }
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
        public LoginIMAPDto LoginTransportUser(DataTable dtData)
        {
            System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)(768 | 3072);
            var url = "https://mapapi-uat.mottoauction.com/inspection/api/userlogin/value";
            var requestBody = new
            {
                Username = dtData.Rows[0]["Username"]?.ToString(),
                Password = dtData.Rows[0]["Password"]?.ToString()
            };
            var json = JsonConvert.SerializeObject(requestBody);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.TryAddWithoutValidation("x-api-key", "e9ab5c97-019e-4a83-ad6f-b1d571b24d5d");
                request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
                request.Content = data;
                var apiResponse = client.SendAsync(request).Result;

                string responseContent = apiResponse.Content.ReadAsStringAsync().Result;
                LoginIMAPDto responseData = JsonConvert.DeserializeObject<LoginIMAPDto>(responseContent);
                // Validate username and password against AdminUser entities
                //var user = _adminUserService.Authenticate(model.UserName, model.Password, out string token);
                return responseData;
            }


            //DataTable resultTable = new DataTable();
            //try
            //{
            //    Transport_User User = new Transport_User();
            //    User.LoginName = (dtData.Rows[0]["login"] == null ? "" : dtData.Rows[0]["login"].ToString());
            //    User.Password = (dtData.Rows[0]["password"] == null ? "" : dtData.Rows[0]["password"].ToString());

            //    using (var context = new dataFeedContext())
            //    {
            //        context.Database.CommandTimeout = 300000;
            //        if (context.Database.Connection.State == ConnectionState.Closed)
            //        {
            //            context.Database.Connection.Open();
            //        }

            //        using (var command = context.Database.Connection.CreateCommand())
            //        {
            //            command.CommandText = Operation_Query.Login_Transport_User;

            //            #region Parameters

            //            command.Parameters.Add(new SqlParameter("@LoginName", User.LoginName));
            //            command.Parameters.Add(new SqlParameter("@Password", User.Password));

            //            #endregion Parameters

            //            using (var reader = command.ExecuteReader())
            //            {
            //                resultTable.Load(reader);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("===================================================================");
            //    Console.WriteLine(ex.Message);
            //}
            //return resultTable;
        }
        #endregion


        #endregion

        #region QuickCheckOutVehicles
        public int QuickCheckOutVehicles(DataTable dtData)
        {
            int isFound = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Transport_ScheduleDetail odetail = new Transport_ScheduleDetail();
                    odetail.Vehicle = dtData.Rows[i]["vehicleNumber"] == null ? "" : dtData.Rows[i]["vehicleNumber"].ToString();
                    odetail.CheckOutLocation = dtData.Rows[i]["txnLocationId"] == null ? "" : dtData.Rows[i]["txnLocationId"].ToString();
                    odetail.CheckInLocation = dtData.Rows[i]["checkInLocationId"] == null ? "" : dtData.Rows[i]["checkInLocationId"].ToString();
                    double dFromDate = Convert.ToDouble(dtData.Rows[0]["txnDate"] == null ? 0 : dtData.Rows[0]["txnDate"]);
                    odetail.CheckOutDate = (dFromDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dFromDate));
                    odetail.CheckOutTime = (dtData.Rows[i]["txnTime"] == null ? "" : dtData.Rows[i]["txnTime"].ToString());
                    string updateduser = (dtData.Rows[i]["statusUpdateBy"] == null ? "" : dtData.Rows[i]["statusUpdateBy"].ToString());
                    int txnType = 1;//CheckOut

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    DataTable notCompleteQuickTransport = new DataTable();
                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Operation_Query.Get_NotComplete_QuickTransport;

                        #region Parameters
                        command.Parameters.Add(new SqlParameter("@Vehicle", odetail.Vehicle));
                        #endregion Parameters

                        using (var reader = command.ExecuteReader())
                        {
                            notCompleteQuickTransport.Load(reader);
                        }
                    }
                    if (notCompleteQuickTransport.Rows.Count == 0)
                    {
                        #region Parameter

                        var quickTransportParam = new List<SqlParameter> {
                        new SqlParameter("@Vehicle",odetail.Vehicle),
                        new SqlParameter("@CheckOutLocation",odetail.CheckOutLocation),
                        new SqlParameter("@CheckInLocation",odetail.CheckInLocation),
                        new SqlParameter("@CheckOutDate",odetail.CheckOutDate),
                        new SqlParameter("@CheckOutTime",odetail.CheckOutTime),
                        };

                        var LogParam = new List<SqlParameter> {
                        new SqlParameter("@VehicleNumber",odetail.Vehicle),
                        new SqlParameter("@TxnType",txnType),
                        new SqlParameter("@TxnLocation",odetail.CheckOutLocation),
                        new SqlParameter("@TxnDate",odetail.CheckOutDate),
                        new SqlParameter("@TxnTime",odetail.CheckOutTime),
                        new SqlParameter("@StatusUpdateBy",updateduser),
                        };
                        #endregion Parameter

                        context.Database.ExecuteSqlCommand(Operation_Query.QuickCheckOut_Vehicles, quickTransportParam.ToArray());

                        context.Database.ExecuteSqlCommand(Operation_Query.Save_Transport_ATS_Log, LogParam.ToArray());

                        isFound = 1;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
            return isFound;
        }
        #endregion

        #region QuickCheckInVehicles
        public int QuickCheckInVehicles(DataTable dtData)
        {
            int isFound = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    Transport_ScheduleDetail odetail = new Transport_ScheduleDetail();
                    odetail.Vehicle = dtData.Rows[i]["vehicleNumber"] == null ? "" : dtData.Rows[i]["vehicleNumber"].ToString();
                    odetail.CheckInLocation = dtData.Rows[i]["txnLocationId"] == null ? "" : dtData.Rows[i]["txnLocationId"].ToString();
                    double dFromDate = Convert.ToDouble(dtData.Rows[0]["txnDate"] == null ? 0 : dtData.Rows[0]["txnDate"]);
                    odetail.CheckInDate = (dFromDate == 0 ? new DateTime(1970, 01, 01) : UnixTimeStampToDateTime(dFromDate));
                    odetail.CheckInTime = (dtData.Rows[i]["txnTime"] == null ? "" : dtData.Rows[i]["txnTime"].ToString());
                    int txnType = 2;//CheckIn
                    string updateduser = (dtData.Rows[i]["statusUpdateBy"] == null ? "" : dtData.Rows[i]["statusUpdateBy"].ToString());

                    var context = new dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    

                    DataTable lastQuickTransport = new DataTable();
                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Operation_Query.Get_Last_QuickTransport;

                        #region Parameters
                        command.Parameters.Add(new SqlParameter("@Vehicle", odetail.Vehicle));
                        command.Parameters.Add(new SqlParameter("@CheckInLocation", odetail.CheckInLocation));
                        #endregion Parameters

                        using (var reader = command.ExecuteReader())
                        {
                            lastQuickTransport.Load(reader);
                        }
                    }
                    if (lastQuickTransport.Rows.Count > 0)
                    {
                        int id= int.Parse(lastQuickTransport.Rows[0]["id"].ToString());

                        #region Parameter

                        var quickTransportParam = new List<SqlParameter> {
                        new SqlParameter("@id",id),
                        new SqlParameter("@Vehicle",odetail.Vehicle),
                        new SqlParameter("@CheckInLocation",odetail.CheckInLocation),
                        new SqlParameter("@CheckInDate",odetail.CheckInDate),
                        new SqlParameter("@CheckInTime",odetail.CheckInTime)
                        };

                        var LogParam = new List<SqlParameter> {
                        new SqlParameter("@VehicleNumber",odetail.Vehicle),
                        new SqlParameter("@TxnType",txnType),
                        new SqlParameter("@TxnLocation",odetail.CheckInLocation),
                        new SqlParameter("@TxnDate",odetail.CheckInDate),
                        new SqlParameter("@TxnTime",odetail.CheckInTime),
                        new SqlParameter("@StatusUpdateBy",updateduser),
                        };

                        #endregion Parameter

                        context.Database.ExecuteSqlCommand(Operation_Query.QuickCheckIn_Vehicles, quickTransportParam.ToArray());
                        context.Database.ExecuteSqlCommand(Operation_Query.Save_Transport_ATS_Log, LogParam.ToArray());
                        isFound = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
            return isFound;
        }
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

                        command.Parameters.Add(new SqlParameter("@UserID", userid));

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
        #region SearchOprDashboard
        public List<BindOprDashboardData> SearchOprDashboard(DataTable dtData)
        {
            string strAuctionDate = dtData.Rows[0]["auctionDate"] == null ? "1900-01-01" : dtData.Rows[0]["auctionDate"].ToString();
            string strSeller = dtData.Rows[0]["seller"] == null ? "All" : dtData.Rows[0]["seller"].ToString();
            string strSellingCategory = dtData.Rows[0]["sellingCategory"] == null ? "All" : dtData.Rows[0]["sellingCategory"].ToString();
            List<BindOprDashboardData> result = new List<BindOprDashboardData>();
            try
            {
                strAuctionDate = strAuctionDate == "1900-01-01" ? DateTime.Now.ToString("yyyy-MM-dd") : strAuctionDate;
                strSeller = strSeller == "All" ? "" : strSeller;
                strSellingCategory = strSellingCategory == "All" ? "" : strSellingCategory;
                List<OprDashboardData> dashboardData= new List<OprDashboardData>();
                using (var context = new MAMS_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }
                    dashboardData = context.Database.SqlQuery<OprDashboardData>($@"SELECT CONVERT(varchar, AuctionDate, 23) + '(' + AuctionCode+')' AS AuctionDateCode,AuctionDate,AuctionCode,
                                                                            Seller,CompanyName_BU CompanyName,SellingCategory,TotalOffer,Reinspection,SellingCode,CompletePercentage,AuctionLocation_BU,OfficeEN
                                                                            FROM [fn_getUpcomingAuctionBySellerReinspection]('{strAuctionDate}','{strSellingCategory}') 
                                                                            WHERE Seller = CASE WHEN ISNULL('{strSeller}','') = '' THEN Seller ELSE '{strSeller}' END  
                                                                            ORDER BY AuctionDate, AuctionCode").ToList();
                }
                // Group the dashboardData by AuctionDateCode
                var groupedData = dashboardData.GroupBy(d => d.AuctionDateCode);

                // Iterate through each group
                foreach (var group in groupedData)
                {
                    var primaryData = group.FirstOrDefault();
                    BindOprDashboardData bindData = new BindOprDashboardData
                    {
                        AuctionDateCode = group.Key, // Key is the AuctionDateCode
                        AuctionDate = primaryData.AuctionDate,
                        AuctionCode = primaryData.AuctionCode,
                        Location = primaryData.AuctionLocation_BU,
                        Office = primaryData.OfficeEn,
                        SellerInfos = new List<OperationSellerInfo>(),
                        IconInfos = new List<OperationIconInfo>()
                    };

                    bindData.IconInfos = group
                                .GroupBy(t => t.SellingCode)
                                .Select(g => new OperationIconInfo
                                {
                                    SellingCategory = GetSCName(g.Key),
                                    Count = g.Sum(x => x.TotalOffer),
                                    Icon = GetIcon(g.Key),
                                }).ToList();

                    // Iterate through each item in the group and add to SellerInfos
                    foreach (var item in group.OrderBy(x => x.CompanyName).ThenBy(x => x.SellingCategory).ToList())
                    {
                        OperationSellerInfo sellerInfo = new OperationSellerInfo
                        {
                            Seller = item.Seller,
                            CompanyName = item.CompanyName,
                            SellingCategory = item.SellingCategory,
                            TotalOffer = item.TotalOffer,
                            Reinspection = item.Reinspection,
                            SellingCode = item.SellingCode,
                            CompletePercentage = item.CompletePercentage
                        };
                        bindData.SellerInfos.Add(sellerInfo);
                    }

                    // Add the constructed BindOprDashboardData to the result list
                    result.Add(bindData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

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

        #region GetSCName
        private string GetSCName(string code)
        {
            if (string.IsNullOrEmpty(code))
                return "Other";

            var item = SC_Code_Name.FirstOrDefault(i => i.Code.Trim() == code.ToUpper().Trim());
            if (item == null)
                return "Other";

            return item.Name;
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

        private SellingCategory_Code_Name[] SC_Code_Name = new SellingCategory_Code_Name[]
        {
            new SellingCategory_Code_Name { Code = "CA",      Name = "Car"},
            new SellingCategory_Code_Name { Code = "PU",      Name = "Pickup"},
            new SellingCategory_Code_Name { Code = "SA",      Name = "Salvage"},
            new SellingCategory_Code_Name { Code = "TRK",     Name = "Truck"},
            new SellingCategory_Code_Name { Code = "KBT",     Name = "Kubota"},
            new SellingCategory_Code_Name { Code = "YAN",     Name = "Yanmar"},
            new SellingCategory_Code_Name { Code = "SOL",     Name = "Solis"},
            new SellingCategory_Code_Name { Code = "OT",      Name = "Other"},
            new SellingCategory_Code_Name { Code = "4WD",     Name = "4WD"},
            new SellingCategory_Code_Name { Code = "MB",      Name = "Motorbike"},
            new SellingCategory_Code_Name { Code = "BO",      Name = "Burn Out"},
            new SellingCategory_Code_Name { Code = "FD1",     Name = "100% Flood"},
            new SellingCategory_Code_Name { Code = "MCE",     Name = "Machinery/ Equipment"},
            new SellingCategory_Code_Name { Code = "TRK",     Name = "Truck"},
            new SellingCategory_Code_Name { Code = "FD2",     Name = "60% Flood"},
            new SellingCategory_Code_Name { Code = "20K",     Name = "Less 20K"},
            new SellingCategory_Code_Name { Code = "MB",      Name = "Motorbike"},
            new SellingCategory_Code_Name { Code = "AE",      Name = "Agri Equipment"},
            new SellingCategory_Code_Name { Code = "T10",     Name = "Truck 10 wheel"},
            new SellingCategory_Code_Name { Code = "YAN",     Name = "Yanmar"},
            new SellingCategory_Code_Name { Code = "ISE",     Name = "Iseki"},
            new SellingCategory_Code_Name { Code = "KIO",     Name = "Kioti"},
        };
        #endregion

        #region FiltersForOprDashboard
        public List<FilterSellingCategory> GetFilterSellingCategory()
        {
            List<FilterSellingCategory> dashboard = new List<FilterSellingCategory>();
            try
            {
                using (var context = new MAMS_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }
                    dashboard = context.Database.SqlQuery<FilterSellingCategory>($@"SELECT DISTINCT SC.SellingCategory,sc.Desc_BU Category
                                                                                FROM
                                                                                (SELECT * FROM IMAP.dbo.Auctions WHERE AuctionDate >= GETDATE()) AU
                                                                                LEFT JOIN IMAP.dbo.AuctionVehicles av ON av.AuctionCode = au.AuctionCode
                                                                                LEFT JOIN IMAP.dbo.Vehicles v on CONVERT(int,av.Vehicle) = CONVERT(int,v.Vehicle)
                                                                                LEFT JOIN ZILO.IMAP.dbo.SellingCategories SC on SC.SellingCategory = v.SellingCategory
                                                                                WHERE ISNULL(SC.SellingCategory,'') <> '' ORDER BY SC.SellingCategory")
                    .ToList();
                    dashboard.Insert(0, new FilterSellingCategory
                    {
                        SellingCategory = "All",
                        Category = "All Selling Category"
                    });
                }
                return dashboard;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dashboard;
        }
        public List<AuctionDate_Combo> GetFilterUpcomingAuction()
        {
                var context = new MAMS_dataFeedContext();
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }
                var data = context.Database.SqlQuery<AuctionDate>($"SELECT DISTINCT AuctionDate Date FROM IMAP.dbo.Auctions WHERE AuctionDate >= GETDATE() ORDER BY Date").ToList();
         
            List<AuctionDate_Combo> combo = new List<AuctionDate_Combo>();
            for (int i = 0; i < data.Count; i++)
            {
                combo.Add(new AuctionDate_Combo { DateStr = data[i].DateStr, Date = data[i].Date });
            }
            //combo.Insert(0, new AuctionDate_Combo
            //{
            //    Date = new DateTime(1900, 1, 1),
            //    DateStr = "All Upcoming Auction"
            //});
            return combo;
        }
        public List<FilterSeller> GetFilterSeller()
        {
            List<FilterSeller> dashboard = new List<FilterSeller>();
            try
            {
                using (var context = new MAMS_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }
                    dashboard = context.Database.SqlQuery<FilterSeller>($@"SELECT DISTINCT v.Seller SellerCode,seller.CompanyName_BU SellerName
                                                                        FROM
                                                                        (SELECT * 
                                                                        FROM IMAP.dbo.Auctions WHERE AuctionDate >= GETDATE() 
                                                                        ) AU
                                                                        LEFT JOIN IMAP.dbo.AuctionVehicles av ON av.AuctionCode = au.AuctionCode
                                                                        LEFT JOIN IMAP.dbo.Vehicles v on CONVERT(int,av.Vehicle) = CONVERT(int,v.Vehicle)
                                                                        LEFT JOIN IMAP.dbo.Customers seller on Seller.Customer = v.Seller
                                                                        WHERE ISNULL(v.Seller,'') <> ''")
                   .ToList();
                    dashboard.Insert(0, new FilterSeller
                    {
                        SellerCode = "All",
                        SellerName = "All Seller"
                    });
                }
                return dashboard;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dashboard;
        }
        #endregion

        #endregion

        #region OverallLocationDashboard
        public List<OverallLocationPerformance> OverallLocationDashboard(DataTable dtData)
        {
            string strDate = dtData.Rows[0]["date"] == null ? "1900-01-01" : dtData.Rows[0]["date"].ToString();
            string InspectorName = dtData.Rows[0]["inspectorName"] == null ? "All" : dtData.Rows[0]["inspectorName"].ToString();
            string Location = dtData.Rows[0]["location"] == null ? "All" : dtData.Rows[0]["location"].ToString();
            List<InspectorDataResult> RawData = getInspectorDataResult(strDate, InspectorName, Location);
            List<OverallLocationPerformance> locPerformance = new List<OverallLocationPerformance>();
            List<InspectorPerformance> parentData = RawData
               .GroupBy(p => new { p.Location })
              .Select(p => new InspectorPerformance("", p.First().Location, new List<InspectionDetail>()))
             .ToList();
            List<InspectorPerformance> distinctData = parentData.Distinct().ToList();
            for (int i = 0; i < distinctData.Count; i++)
            {
                List<InspectionPivot> allVehicle = RawData
               .Where(raw => raw.Location == distinctData[i].Location)
              .Select(p => new InspectionPivot(p.VehicleType, p.Month_1, p.Month_2, p.Month_3, p.Month_4, p.Month_5, p.Month_6)).ToList();
                if (allVehicle.Any())
                {
                    OverallLocationPerformance performance = new OverallLocationPerformance();
                    performance.Location = distinctData[i].Location;
                    performance.Month_1 = allVehicle.Sum(p => p.Month_1);
                    performance.Month_2 = allVehicle.Sum(p => p.Month_2);
                    performance.Month_3 = allVehicle.Sum(p => p.Month_3);
                    performance.Month_4 = allVehicle.Sum(p => p.Month_4);
                    performance.Month_5 = allVehicle.Sum(p => p.Month_5);
                    performance.Month_6 = allVehicle.Sum(p => p.Month_6);
                    locPerformance.Add(performance);
                }
            }
            if (locPerformance.Any())
            {
                locPerformance = locPerformance.OrderByDescending(p => p.All_Month_Total).ToList();
            }
            if (locPerformance.Any())
            {
                OverallLocationPerformance performance = new OverallLocationPerformance();
                performance.Location = "Grand Total";
                performance.Month_1 = locPerformance.Sum(p => p.Month_1);
                performance.Month_2 = locPerformance.Sum(p => p.Month_2);
                performance.Month_3 = locPerformance.Sum(p => p.Month_3);
                performance.Month_4 = locPerformance.Sum(p => p.Month_4);
                performance.Month_5 = locPerformance.Sum(p => p.Month_5);
                performance.Month_6 = locPerformance.Sum(p => p.Month_6);
                locPerformance.Add(performance);
            }

            return locPerformance;
        }
        #endregion

        #region Inspector Performance
        public List<InspectorPerformance> InspectorPerformanceDashboard(DataTable dtData)
        {
            string strDate = dtData.Rows[0]["date"] == null ? "1900-01-01" : dtData.Rows[0]["date"].ToString();
            string InspectorName = dtData.Rows[0]["inspectorName"] == null ? "All" : dtData.Rows[0]["inspectorName"].ToString();
            string Location = dtData.Rows[0]["location"] == null ? "All" : dtData.Rows[0]["location"].ToString();
            List<InspectorDataResult> RawData = getInspectorDataResult(strDate, InspectorName, Location);


            List<InspectorPerformance> parentData = RawData
                .GroupBy(p => new { p.InspectorName, p.Location })
               .Select(p => new InspectorPerformance(p.First().InspectorName, p.First().Location, new List<InspectionDetail>()))
              .ToList();
            List<InspectorPerformance> distinctData = parentData.Distinct().ToList();
            for (int i = 0; i < distinctData.Count; i++)
            {
                distinctData[i] = GetInspectionDetail(distinctData[i], RawData);
            }
            return distinctData;
        }

        public InspectorPerformance GetInspectionDetail(InspectorPerformance performance, List<InspectorDataResult> RawData)
        {
            List<InspectionPivot> bookInDetail = RawData
                .Where(raw => raw.InspectorName == performance.InspectorName && raw.Location == performance.Location && raw.InspectionCategory == "BookIn")
               .Select(p => new InspectionPivot(p.VehicleType, p.Month_1, p.Month_2, p.Month_3, p.Month_4, p.Month_5, p.Month_6)).ToList();

            if (bookInDetail.Any())
            {
                InspectionDetail bookIn = new InspectionDetail("BookIn", "Book In", new List<InspectionPivot>());
                InspectionPivot total = new InspectionPivot("Total", bookInDetail.Sum(p => p.Month_1),
                                                                    bookInDetail.Sum(p => p.Month_2),
                                                                    bookInDetail.Sum(p => p.Month_3),
                                                                    bookInDetail.Sum(p => p.Month_4),
                                                                    bookInDetail.Sum(p => p.Month_5),
                                                                    bookInDetail.Sum(p => p.Month_6));
                bookInDetail.Add(total);
                bookIn.inspectionPivots = bookInDetail;
                performance.Detail.Add(bookIn);
            }

            List<InspectionPivot> ReinspectionDetail = RawData
               .Where(raw => raw.InspectorName == performance.InspectorName && raw.Location == performance.Location && raw.InspectionCategory == "Reinspection")
              .Select(p => new InspectionPivot(p.VehicleType, p.Month_1, p.Month_2, p.Month_3, p.Month_4, p.Month_5, p.Month_6)).ToList();

            if (ReinspectionDetail.Any())
            {
                InspectionDetail reInspection = new InspectionDetail("Reinspection", "Re-inspection", new List<InspectionPivot>());
                InspectionPivot total = new InspectionPivot("Total", ReinspectionDetail.Sum(p => p.Month_1),
                                                                     ReinspectionDetail.Sum(p => p.Month_2),
                                                                     ReinspectionDetail.Sum(p => p.Month_3),
                                                                     ReinspectionDetail.Sum(p => p.Month_4),
                                                                     ReinspectionDetail.Sum(p => p.Month_5),
                                                                     ReinspectionDetail.Sum(p => p.Month_6));
                ReinspectionDetail.Add(total);
                reInspection.inspectionPivots = ReinspectionDetail;
                performance.Detail.Add(reInspection);
            }


            List<InspectionPivot> allVehicle = RawData
                .Where(raw => raw.InspectorName == performance.InspectorName && raw.Location == performance.Location)
               .Select(p => new InspectionPivot(p.VehicleType, p.Month_1, p.Month_2, p.Month_3, p.Month_4, p.Month_5, p.Month_6)).ToList();
            if (allVehicle.Any())
            {
                InspectionDetail header = new InspectionDetail("GrandTotal", "Grand Total", new List<InspectionPivot>());
                InspectionPivot total = new InspectionPivot("", allVehicle.Sum(p => p.Month_1),
                                                                     allVehicle.Sum(p => p.Month_2),
                                                                     allVehicle.Sum(p => p.Month_3),
                                                                     allVehicle.Sum(p => p.Month_4),
                                                                     allVehicle.Sum(p => p.Month_5),
                                                                     allVehicle.Sum(p => p.Month_6));
                List<InspectionPivot> grandTotal = new List<InspectionPivot>();
                grandTotal.Add(total);
                header.inspectionPivots = grandTotal;
                performance.Detail.Add(header);
            }

            return performance;
        }
        #endregion

        #region Location Performance
        public List<InspectorPerformance> LocationDashboard(DataTable dtData)
        {
            string strDate = dtData.Rows[0]["date"] == null ? "1900-01-01" : dtData.Rows[0]["date"].ToString();
            string InspectorName = dtData.Rows[0]["inspectorName"] == null ? "All" : dtData.Rows[0]["inspectorName"].ToString();
            string Location = dtData.Rows[0]["location"] == null ? "All" : dtData.Rows[0]["location"].ToString();
            List<InspectorDataResult> RawData = getInspectorDataResult(strDate, InspectorName, Location);


            List<InspectorPerformance> parentData = RawData
                .GroupBy(p => new { p.Location })
               .Select(p => new InspectorPerformance("", p.First().Location, new List<InspectionDetail>()))
              .ToList();
            List<InspectorPerformance> distinctData = parentData.Distinct().ToList();
            for (int i = 0; i < distinctData.Count; i++)
            {
                distinctData[i] = GetLocationDetail(distinctData[i], RawData);
            }
            return distinctData;
        }

        public InspectorPerformance GetLocationDetail(InspectorPerformance performance, List<InspectorDataResult> RawData)
        {
            List<InspectionPivot> bookInDetail = RawData
                .Where(raw => raw.Location == performance.Location && raw.InspectionCategory == "BookIn")

               .Select(p => new InspectionPivot(p.VehicleType,
                                                p.Month_1,
                                                p.Month_2,
                                                p.Month_3,
                                                p.Month_4,
                                                p.Month_5,
                                                p.Month_6)).ToList();


            if (bookInDetail.Any())
            {
                List<InspectionPivot> summarize_BookIn = bookInDetail.GroupBy(raw => new { raw.VehicleType })
                                        .Select(group => new InspectionPivot
                                        (
                                            group.Key.VehicleType,
                                            group.Sum(p => p.Month_1),
                                            group.Sum(p => p.Month_2),
                                            group.Sum(p => p.Month_3),
                                            group.Sum(p => p.Month_4),
                                            group.Sum(p => p.Month_5),
                                            group.Sum(p => p.Month_6)
                                        )).ToList();

                InspectionDetail bookIn = new InspectionDetail("BookIn", "Book In", new List<InspectionPivot>());
                InspectionPivot total = new InspectionPivot("Total", summarize_BookIn.Sum(p => p.Month_1),
                                                                    summarize_BookIn.Sum(p => p.Month_2),
                                                                    summarize_BookIn.Sum(p => p.Month_3),
                                                                    summarize_BookIn.Sum(p => p.Month_4),
                                                                    summarize_BookIn.Sum(p => p.Month_5),
                                                                    summarize_BookIn.Sum(p => p.Month_6));
                summarize_BookIn.Add(total);
                bookIn.inspectionPivots = summarize_BookIn;
                performance.Detail.Add(bookIn);
            }

            List<InspectionPivot> ReinspectionDetail = RawData
               .Where(raw => raw.Location == performance.Location && raw.InspectionCategory == "Reinspection")
              .Select(p => new InspectionPivot(p.VehicleType, p.Month_1, p.Month_2, p.Month_3, p.Month_4, p.Month_5, p.Month_6)).ToList();

            if (ReinspectionDetail.Any())
            {
                List<InspectionPivot> summarize_Reinspection = ReinspectionDetail.GroupBy(raw => new { raw.VehicleType })
                                        .Select(group => new InspectionPivot
                                        (
                                            group.Key.VehicleType,
                                            group.Sum(p => p.Month_1),
                                            group.Sum(p => p.Month_2),
                                            group.Sum(p => p.Month_3),
                                            group.Sum(p => p.Month_4),
                                            group.Sum(p => p.Month_5),
                                            group.Sum(p => p.Month_6)
                                        )).ToList();
                InspectionDetail reInspection = new InspectionDetail("Reinspection", "Re-inspection", new List<InspectionPivot>());
                InspectionPivot total = new InspectionPivot("Total", ReinspectionDetail.Sum(p => p.Month_1),
                                                                     ReinspectionDetail.Sum(p => p.Month_2),
                                                                     ReinspectionDetail.Sum(p => p.Month_3),
                                                                     ReinspectionDetail.Sum(p => p.Month_4),
                                                                     ReinspectionDetail.Sum(p => p.Month_5),
                                                                     ReinspectionDetail.Sum(p => p.Month_6));
                summarize_Reinspection.Add(total);
                reInspection.inspectionPivots = summarize_Reinspection;
                performance.Detail.Add(reInspection);
            }


            List<InspectionPivot> allVehicle = RawData
                .Where(raw => raw.Location == performance.Location)
               .Select(p => new InspectionPivot(p.VehicleType, p.Month_1, p.Month_2, p.Month_3, p.Month_4, p.Month_5, p.Month_6)).ToList();
            if (allVehicle.Any())
            {
                InspectionDetail header = new InspectionDetail("GrandTotal", "Grand Total", new List<InspectionPivot>());
                InspectionPivot total = new InspectionPivot("", allVehicle.Sum(p => p.Month_1),
                                                                     allVehicle.Sum(p => p.Month_2),
                                                                     allVehicle.Sum(p => p.Month_3),
                                                                     allVehicle.Sum(p => p.Month_4),
                                                                     allVehicle.Sum(p => p.Month_5),
                                                                     allVehicle.Sum(p => p.Month_6));
                List<InspectionPivot> grandTotal = new List<InspectionPivot>();
                grandTotal.Add(total);
                header.inspectionPivots = grandTotal;
                performance.Detail.Add(header);
            }

            return performance;
        }
        #endregion

        public List<InspectorDataResult> getInspectorDataResult(string strDate, string InspectorName, string Location)
        {
            List<InspectorDataResult> dashboard = new List<InspectorDataResult>();
            try
            {
                strDate = strDate == "1900-01-01" ? DateTime.Now.ToString("yyyy-MM-dd") : strDate;
                InspectorName = InspectorName == "All" ? "" : InspectorName;
                Location = Location == "All" ? "" : Location;
                using (var context = new MAMS_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }
                    dashboard = context.Database.SqlQuery<InspectorDataResult>($@"EXEC [OPRDASHBOARD_InspectorPerformance] '{strDate}','{InspectorName}','{Location}'")
                   .ToList();
                }
                return dashboard;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dashboard;
        }

        #region FiltersForInspection
        #region Inspection_Filter_StorageLocation
        public List<Inspection_StorageLocation> Inspection_Filter_StorageLocation()
        {
            List<Inspection_StorageLocation> storageLocations = new List<Inspection_StorageLocation>();
            try
            {
                using (var context = new MAMS_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }
                    storageLocations = context.Database.SqlQuery<Inspection_StorageLocation>($@"SELECT DISTINCT StorageLocation FROM ZILO.IMAP.dbo.View_OperationDashboard WHERE ISNULL(InspectorName,'') <> '' AND ISNULL(StorageLocation,'') <> ''
                                                                                            UNION 
                                                                                            SELECT DISTINCT StorageLocation FROM ZILO.IMAP.dbo.View_OperationDashboard_BookIn WHERE ISNULL(InspectorName,'') <> '' AND ISNULL(StorageLocation,'') <> ''")
                    .ToList();
                    storageLocations.Insert(0, new Inspection_StorageLocation { StorageLocation = "All" });
                }
                return storageLocations;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return storageLocations;
        }
        #endregion

        #region Inspection_Filter_Inspector
        public List<Inspector> Inspection_Filter_Inspector()
        {
            List<Inspector> inspectors = new List<Inspector>();
            try
            {
                using (var context = new MAMS_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }
                    inspectors = context.Database.SqlQuery<Inspector>($@"SELECT DISTINCT InspectorName FROM ZILO.IMAP.dbo.View_OperationDashboard WHERE ISNULL(InspectorName,'') <> ''
                                                                    UNION 
                                                                    SELECT DISTINCT InspectorName FROM ZILO.IMAP.dbo.View_OperationDashboard_BookIn WHERE ISNULL(InspectorName,'') <> ''")
                    .ToList();
                    inspectors.Insert(0, new Inspector { InspectorName = "All" });
                }
                
                return inspectors;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return inspectors;
        }
        #endregion

        #region Inspection_Filter_MonthData
        public List<Inspection_Month> Inspection_Filter_MonthData()
        {
            List<Inspection_Month> months = new List<Inspection_Month>();
            try
            {
                using (var context = new MAMS_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }
                    months = context.Database.SqlQuery<Inspection_Month>($@"SELECT DISTINCT CONVERT(VARCHAR(10),DATEADD(DAY, -1, DATEADD(MONTH, DATEDIFF(MONTH, 0, RecordDate) + 1, 0)), 120) DataValue,
                                                                        RIGHT(CONVERT(VARCHAR(100), RecordDate, 106),LEN(CONVERT(VARCHAR(100), RecordDate, 106))-3) DisplayValue
                                                                        FROM ZILO.IMAP.dbo.View_OperationDashboard_BookIn ORDER BY CONVERT(VARCHAR(10),DATEADD(DAY, -1, DATEADD(MONTH, DATEDIFF(MONTH, 0, RecordDate) + 1, 0)), 120) DESC")
                    .ToList();
                }
               
                return months;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return months;
        }
        #endregion
        #endregion

        #region Operation Monitor
        public DataTable GetKanbanAllStatus(DataTable dtData)
        {

            DataTable resultTable = new DataTable();
            try
            {
                string strDate = dtData.Rows[0]["date"] == null ? "1900-01-01" : dtData.Rows[0]["date"].ToString();
                string Seller = dtData.Rows[0]["seller"] == null ? "" : dtData.Rows[0]["seller"].ToString();
                string Location = dtData.Rows[0]["location"] == null ? "" : dtData.Rows[0]["location"].ToString();

                using (var context = new MAMS_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Operation_Query.Get_Kanban_AllStatus;

                        #region Parameters

                        command.Parameters.Add(new SqlParameter("@Location", Location));
                        command.Parameters.Add(new SqlParameter("@Date", strDate));
                        command.Parameters.Add(new SqlParameter("@Seller", Seller));

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

        public DataTable GetStockAging(DataTable dtData)
        {

            DataTable resultTable = new DataTable();
            try
            {
                DateTime strDate = DateTime.Parse(dtData.Rows[0]["date"] == null ? "1900-01-01" : dtData.Rows[0]["date"].ToString());
                string Seller = dtData.Rows[0]["seller"] == null ? "" : dtData.Rows[0]["seller"].ToString();
                string Location = dtData.Rows[0]["location"] == null ? "" : dtData.Rows[0]["location"].ToString();

                using (var context = new MAMS_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Operation_Query.Get_Kanban_AllStatus;

                        #region Parameters

                        command.Parameters.Add(new SqlParameter("@Location", Location));
                        command.Parameters.Add(new SqlParameter("@Date", strDate));
                        command.Parameters.Add(new SqlParameter("@Seller", Seller));

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

        #region GetSellers
        public DataTable GetSellers()
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
                        command.CommandText = Operation_Query.Get_Sellers;

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

        public static string Create_Transport_ATS_Log = $@"INSERT INTO Transport_ATS_Log (TxnType,TxnDate,TxnTime,VehicleNumber,TxnLocation,StatusUpdateBy,ResponseStatus,ResponseData,OtherResponses)
                        VALUES(@TxnType,@TxnDate,@TxnTime,@VehicleNumber,@TxnLocation,@StatusUpdateBy,@ResponseStatus,@ResponseData,@OtherResponses);SELECT CAST(SCOPE_IDENTITY() AS INT);";

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

        public static string Save_Transport_ATS_Log = $@"INSERT INTO Transport_ATS_Log (TxnType,TxnDate,TxnTime,VehicleNumber,TxnLocation,StatusUpdateBy)
                                                         VALUES(@TxnType,@TxnDate,@TxnTime,@VehicleNumber,@TxnLocation,@StatusUpdateBy)";

        public static string QuickCheckOut_Vehicles = $@"INSERT INTO Quick_Transport(CheckOutDate,CheckOutTime,IMAPNumber,CheckOutLocation,CheckInLocation)
                                                          VALUES(@CheckOutDate,@CheckOutTime,@Vehicle,@CheckOutLocation,@CheckInLocation)";

        public static string Get_Last_QuickTransport = $@"select * from Quick_Transport where IMAPNumber=@Vehicle and CheckInLocation=@CheckInLocation order by id desc";

        public static string Get_NotComplete_QuickTransport = $@"select * from Quick_Transport where IMAPNumber=@Vehicle and CheckInDate is null";

        public static string QuickCheckIn_Vehicles = $@"Update Quick_Transport set CheckInDate=@CheckInDate,CheckInTime=@CheckInTime
										                    where id=@id and IMAPNumber=@Vehicle and CheckInLocation=@CheckInLocation";

        public static string Save_OperationUserLocation = $@"INSERT INTO OperationUserLocation(UserID,LocationID) VALUES(@UserID,@LocationID)";

        public static string Delete_OperationUserLocation = $@"Delete OperationUserLocation where UserID=@UserID";

        public static string Get_OperationLocation = $@"SELECT * FROM fn_GetATSLocation() where latitude is not null or longitude is not null";

        public static string Get_Locations_ByUser = $@"select userID,locationID from User_Location where UserID = @UserID";

        public static string Get_ATS_Log_Exited = $@"select * from Transport_ATS_Log where TxnType = 3 and OtherResponses is not null and OtherResponses <> ''";

        public static string Get_Kanban_AllStatus = $@"exec [MAMS_Operation_Kanban_AllStatus] @Location,@Date,@Seller";

        public static string Get_StockAging = $@"SELECT * FROM [dbo].[MAMS_Operation_StockAging]( @Location, @Date, @Seller)";

        public static string Get_Sellers = $@"SELECT Seller, CompanyName_BU SellerName
                                                FROM
                                                (
                                                    SELECT Seller, Count(VehicleNumber) TotalV FROM fn_getVehicleWithStatus(GETDATE()) 
                                                    WHERE ProcessStatus IN ('1','2','3','4')
                                                    GROUP BY Seller
                                                ) Stock
                                                LEFT JOIN IMAP.dbo.Customers c ON Stock.Seller = c.Customer COLLATE SQL_Latin1_General_CP850_BIN
                                                ORDER BY TotalV DESC";
    }
    #endregion
}
