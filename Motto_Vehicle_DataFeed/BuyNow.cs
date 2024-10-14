using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOTTO_DATAFEED.DAO;
using Motto_Vehicle_DataFeed.DAO;
using System.Globalization;
using System.Runtime.Remoting.Contexts;
using System.IO;

namespace Motto_Vehicle_DataFeed
{
    public class BuyNow_DATAFEED
    {
        public BuyNow_DATAFEED() { }

        #region SaveBuyNowUser
        public int SaveBuyNowUser(DataTable dtData)
        {
            int Id = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    BuyNowUser User = new BuyNowUser();
                    User.Name = (dtData.Rows[i]["name"] == null ? "" : dtData.Rows[i]["name"].ToString());
                    User.Email = (dtData.Rows[i]["email"] == null ? "" : dtData.Rows[i]["email"].ToString());
                    User.PhoneNumber = (dtData.Rows[i]["phoneNumber"] == null ? "" : dtData.Rows[i]["phoneNumber"].ToString());
                    User.Password = (dtData.Rows[i]["password"] == null ? "" : dtData.Rows[i]["password"].ToString());

                    var context = new MATWEB_dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var UserParam = new List<SqlParameter> {
                    new SqlParameter("@Name",User.Name),
                    new SqlParameter("@Email",User.Email),
                    new SqlParameter("@PhoneNumber",User.PhoneNumber),
                    new SqlParameter("@Password",User.Password)
                    };

                    #endregion Parameter

                    DataTable chkDuplicate = new DataTable();
                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = BuyNow_Query.Check_Duplicate_User;

                        #region Parameters

                        command.Parameters.Add(new SqlParameter("@Email", User.Email));
                        command.Parameters.Add(new SqlParameter("@id", Id));
                        #endregion Parameters

                        using (var reader = command.ExecuteReader())
                        {
                            chkDuplicate.Load(reader);
                        }
                    }
                    if (chkDuplicate.Rows.Count == 0)
                    {
                        Id = context.Database.SqlQuery<int>(BuyNow_Query.Save_RegisterUser, UserParam.ToArray()).SingleOrDefault();
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

        #region LoginBuyNowUser
        public DataTable LoginBuyNowUser(DataTable dtData)
        {
            DataTable resultTable = new DataTable();
            try
            {
                BuyNowUser User = new BuyNowUser();
                User.Email = (dtData.Rows[0]["email"] == null ? "" : dtData.Rows[0]["email"].ToString());
                User.Password = (dtData.Rows[0]["password"] == null ? "" : dtData.Rows[0]["password"].ToString());

                using (var context = new MATWEB_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = BuyNow_Query.Login_BuyNow_User;

                        #region Parameters

                        command.Parameters.Add(new SqlParameter("@Email", User.Email));
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

        #region GetBnBDataList
        public List<BnBData> GetBnBDataList(DataTable dtData)
        {
                string Make = dtData.Rows[0]["make"].ToString() == "All" ? "" : dtData.Rows[0]["make"].ToString();
                string Model = dtData.Rows[0]["model"].ToString() == "All" ? "" : dtData.Rows[0]["model"].ToString();
                string GearBox = dtData.Rows[0]["gear"].ToString() == "All" ? "" : dtData.Rows[0]["gear"].ToString();

                using (var context = new MATWEB_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }
                    var data = context.Database.SqlQuery<BnBData>($"[BNB_GetVehicleCatalog] '{Make}', '{Model}', '{GearBox}','',''")
                    .ToList();

                    var gregorianCalendar = new GregorianCalendar();
                    var cultureInfo = new CultureInfo("en-US")
                    {
                        DateTimeFormat = { Calendar = gregorianCalendar }
                    };
                    data = data.Where(d => DateTime.Parse(d.ToSchedule, cultureInfo) > DateTime.Now).ToList();
                    return data;
                }
        }
        #endregion

        #region GetMakes
        public List<AMake> GetMakes()
        {
            using (var context = new MATWEB_dataFeedContext())
            {
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }
                return context.Database.SqlQuery<AMake>("SELECT * FROM vw_Makes").ToList();
            }
        }
        #endregion

        #region GetModels
        public List<AModel> GetModels(string make)
        {
            using (var context = new MATWEB_dataFeedContext())
            {
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }
                var datastore = context.Database.SqlQuery<AModel>("SELECT * FROM vw_Models")
                .ToList();

                return datastore.Where(_ => _.MakeCode == make)
                    .ToList();
            }
        }
        #endregion

        #region GetGear
        public List<AGear> GetGear()
        {
            using (var context = new MATWEB_dataFeedContext())
            {
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }
                var datastore = context.Database.SqlQuery<AGear>("SELECT * FROM vw_Gears WHERE ISNULL(GearCode,'') <> ''")
                 .ToList();

                return datastore;
            }
        }
        #endregion

        #region GetBnBData
        public BnBData GetBnBData(string vehicleNumber)
        {
            using (var context = new MATWEB_dataFeedContext())
            {
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }
                var allVehicleList = context.Database.SqlQuery<BnBData>($"[BNB_GetVehicleCatalog_Detail] '', '', '','{vehicleNumber}',''")
                 .ToList();

                var vehicleData = allVehicleList.Where(row => row.Vehicle == vehicleNumber).ToList().FirstOrDefault();
                return vehicleData;
            }
        }
        public void AddViewerCount(string vehicle)
        {
            using (var context = new MATWEB_dataFeedContext())
            {
                context.Database.CommandTimeout = 300000;
                var updatebnbScheduleDetailQuery = $@"update BnBScheduleDetail set ViewerCount=(ISNULL(ViewerCount,0)+1) where VehicleNumber=@VehicleNumber";
                var updatebnbScheduleDetailParam = new List<SqlParameter> {
                    new SqlParameter("@VehicleNumber",vehicle)
                };
                context.Database.ExecuteSqlCommand(updatebnbScheduleDetailQuery, updatebnbScheduleDetailParam.ToArray());
            }
        }
        #endregion



        #region SaveBnBBidLog
        public int SaveBnBBidLog(DataTable dtData)
        {
            int Id = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    BnBBidLog _bidLog = new BnBBidLog();
                    _bidLog.VehicleNumber = (dtData.Rows[i]["vehicleNumber"] == null ? "" : dtData.Rows[i]["vehicleNumber"].ToString());
                    _bidLog.CustomerNumber = (dtData.Rows[i]["customerNumber"] == null ? "" : dtData.Rows[i]["customerNumber"].ToString());
                    _bidLog.Email = (dtData.Rows[i]["email"] == null ? "" : dtData.Rows[i]["email"].ToString());
                    _bidLog.BidAmount = decimal.Parse(dtData.Rows[i]["bidAmount"] == null ? "" : dtData.Rows[i]["bidAmount"].ToString());
                     BnBScheduleDetail scheduleDetails = GetScheduleDetailByVehicle(_bidLog.VehicleNumber);
                    _bidLog.BnBScheduleDetailID = scheduleDetails.DetailID;
                    _bidLog.CreateDate = DateTime.Now.Date;
                    _bidLog.CreateTime = DateTime.Now.ToString("hh:mm tt");
                    _bidLog.Status = 1;

                    var context = new MATWEB_dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var BidLogParam = new List<SqlParameter> {
                    new SqlParameter("@VehicleNumber",_bidLog.VehicleNumber),
                    new SqlParameter("@CustomerNumber",_bidLog.CustomerNumber),
                    new SqlParameter("@Email",_bidLog.Email),
                    new SqlParameter("@BidAmount",_bidLog.BidAmount),
                    new SqlParameter("@BnBScheduleDetailID",_bidLog.BnBScheduleDetailID),
                    new SqlParameter("@CreateDate",_bidLog.CreateDate),
                    new SqlParameter("@CreateTime",_bidLog.CreateTime),
                    new SqlParameter("@Status",_bidLog.Status)
                    };

                    #endregion Parameter
                    Id = context.Database.SqlQuery<int>(BuyNow_Query.Save_BidLog, BidLogParam.ToArray()).SingleOrDefault();
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

        public BnBScheduleDetail GetScheduleDetailByVehicle(string vehicle)
        {
            using (var context = new MATWEB_dataFeedContext())
            {
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }
                context.Database.CommandTimeout = 300000;
                var data = context.Database.SqlQuery<BnBScheduleDetail>($"Select * from BnBScheduleDetail where VehicleNumber = '{vehicle}'")
                    .FirstOrDefault();
                return data;
            }
        }
        #endregion

        #region GetAllImages
        public List<VIMImageGallery> GetAllImages(string vehicleNumber)
        {
            using (var context = new MATWEB_dataFeedContext())
            {
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }
                var data = context.Database.SqlQuery<VIMImageGallery_Raw>($"SELECT * FROM fn_GetVehicleDocument('{vehicleNumber}')").ToList();
                var dataRtn = ConvertToVIMImageGallery(data);
                return dataRtn;
            }
        }

        public List<VIMImageGallery> ConvertToVIMImageGallery(List<VIMImageGallery_Raw> rawData)
        {
            List<VIMImageGallery> lstGallery = new List<VIMImageGallery>();
            List<string> vehicles = rawData.Select(p => p.Vehicle).Distinct().ToList();
            foreach (var vehicle in vehicles)
            {
                List<VIMImageGallery_Raw> typeTwo = rawData.Where(
                    vData => vData.Vehicle == vehicle && vData.DocumentTypeID == 2
                    ).ToList();
                List<VIMImageGallery_Raw> typeThree = rawData.Where(
                    vData => vData.Vehicle == vehicle && vData.DocumentTypeID == 3
                    ).ToList();
                List<VIMImageGallery_Raw> typeFour = rawData.Where(
                    vData => vData.Vehicle == vehicle && vData.DocumentTypeID == 4
                    ).ToList();
                List<VIMImageGallery_Raw> typeSix = rawData.Where(
                   vData => vData.Vehicle == vehicle && vData.DocumentTypeID == 6
                   ).ToList();
                List<VIMImageGallery_Raw> typeOne = rawData.Where(
                   vData => vData.Vehicle == vehicle && vData.DocumentTypeID == 1
                   ).ToList();
                List<VIMImageGallery_Raw> typeEleven = rawData.Where(
                  vData => vData.Vehicle == vehicle && vData.DocumentTypeID == 11
                  ).ToList();

                VIMImageGallery galleryData = new VIMImageGallery();
                galleryData.Vehicle = vehicle;
                galleryData.SourcePath = "https://shared.mottoauction.com/" + vehicle + "/";

                //fillDataWithDifferentTypeV2(typeThree, typeTwo, galleryData);
                if (typeThree.Any() || typeTwo.Any())
                {
                    if (vehicle.Contains("1546627"))
                    {
                        fillDataWithDifferentTypeV2(typeThree, typeTwo, galleryData);
                        string strTempValue = galleryData.FirstFrontImage;
                    }
                    else
                    {
                        fillDataWithDifferentTypeV2(typeThree, typeTwo, galleryData);
                    }

                    //fillDataWithDifferentType(typeThree, galleryData);
                }
                else
                {
                    galleryData.Front = "";
                    galleryData.Back = "";
                    galleryData.Chassis = "";
                    galleryData.Engine = "";
                    galleryData.Plate = "";
                    galleryData.Mileage = "";
                    galleryData.VehicleKey = "";
                    galleryData.Interior = "";
                    galleryData.Side = "";
                    galleryData.Wheel = "";
                    galleryData.Tray = "";
                    galleryData.Other = "";
                    galleryData.TitleBook = "";
                    galleryData.BnWPhoto = "";
                }

                if (typeFour.Any())
                {
                    var inspection = typeFour
                                   .Select(p => p.ImageURL)
                                   .ToList();
                    galleryData.Inspection = string.Join("; ", inspection);
                }
                else
                {
                    galleryData.Inspection = "";
                }

                if (typeSix.Any())
                {
                    var inspection = typeSix
                                   .Select(p => p.ImageURL)
                                   .ToList();
                    galleryData.TitleBook = string.Join("; ", inspection);
                }
                else
                {
                    galleryData.TitleBook = "";
                }
                if (typeOne.Any())
                {
                    var inspection = typeOne
                                   .Select(p => p.ImageURL)
                                   .ToList();
                    galleryData.BnWPhoto = string.Join("; ", inspection);
                }
                else
                {
                    galleryData.BnWPhoto = "";
                }
                if (typeEleven.Any())
                {
                    var oAData = typeEleven
                                   .Select(p => p.ImageURL)
                                   .ToList();
                    galleryData.OAImages = string.Join("; ", oAData);
                }
                else
                {
                    galleryData.OAImages = "";
                }
                lstGallery.Add(galleryData);
            }
            return lstGallery;
        }

        public VIMImageGallery fillDataWithDifferentTypeV2(List<VIMImageGallery_Raw> rawDataTypeThree, List<VIMImageGallery_Raw> rawDataTypeTwo, VIMImageGallery galleryData)
        {
            List<string> frontImages = new List<string>();
            frontImages = rawDataTypeThree
                                .Where(file => file.DocumentDescription_BU.ToLower().Contains("front"))
                                .Select(p => p.ImageURL)
                                .ToList();
            if (!frontImages.Any())
            {
                frontImages = rawDataTypeTwo
                    .Where(file => file.DocumentDescription_BU.ToLower().Contains("front"))
                    .Select(p => p.ImageURL)
                    .ToList();
            }

            List<string> backImages = new List<string>();
            backImages = rawDataTypeThree
                .Where(file => file.DocumentDescription_BU.ToLower().Contains("back"))
                .Select(p => p.ImageURL)
                .ToList();
            if (!backImages.Any())
            {
                backImages = rawDataTypeTwo
                    .Where(file => file.DocumentDescription_BU.ToLower().Contains("back"))
                    .Select(p => p.ImageURL)
                    .ToList();
            }

            List<string> chassisImages = new List<string>();
            chassisImages = rawDataTypeThree
                .Where(file => file.DocumentDescription_BU.ToLower().Contains("chassis"))
                .Select(p => p.ImageURL)
                .ToList();
            if (!chassisImages.Any())
            {
                chassisImages = rawDataTypeTwo
                    .Where(file => file.DocumentDescription_BU.ToLower().Contains("chassis"))
                    .Select(p => p.ImageURL)
                    .ToList();
            }

            List<string> engineImages = new List<string>();
            engineImages = rawDataTypeThree
                .Where(file => file.DocumentDescription_BU.ToLower().Contains("engine"))
                .Select(p => p.ImageURL)
                .ToList();
            if (!engineImages.Any())
            {
                engineImages = rawDataTypeTwo
                    .Where(file => file.DocumentDescription_BU.ToLower().Contains("engine"))
                    .Select(p => p.ImageURL)
                    .ToList();
            }

            List<string> plateImages = new List<string>();
            plateImages = rawDataTypeThree
                .Where(file => file.DocumentDescription_BU.ToLower().Contains("plate"))
                .Select(p => p.ImageURL)
                .ToList();
            if (!plateImages.Any())
            {
                plateImages = rawDataTypeTwo
                    .Where(file => file.DocumentDescription_BU.ToLower().Contains("plate"))
                    .Select(p => p.ImageURL)
                    .ToList();
            }

            List<string> mileageImages = new List<string>();
            mileageImages = rawDataTypeThree
                .Where(file => file.DocumentDescription_BU.ToLower().Contains("mileage"))
                .Select(p => p.ImageURL)
                .ToList();
            if (!mileageImages.Any())
            {
                mileageImages = rawDataTypeTwo
                    .Where(file => file.DocumentDescription_BU.ToLower().Contains("mileage"))
                    .Select(p => p.ImageURL)
                    .ToList();
            }

            List<string> keyImages = new List<string>();
            keyImages = rawDataTypeThree
                .Where(file => file.DocumentDescription_BU.ToLower().Contains("key"))
                .Select(p => p.ImageURL)
                .ToList();
            if (!keyImages.Any())
            {
                keyImages = rawDataTypeTwo
                    .Where(file => file.DocumentDescription_BU.ToLower().Contains("key"))
                    .Select(p => p.ImageURL)
                    .ToList();
            }

            List<string> interiorImages = new List<string>();
            interiorImages = rawDataTypeThree
                .Where(file => file.DocumentDescription_BU.ToLower().Contains("interior"))
                .Select(p => p.ImageURL)
                .ToList();
            if (!interiorImages.Any())
            {
                interiorImages = rawDataTypeTwo
                    .Where(file => file.DocumentDescription_BU.ToLower().Contains("interior"))
                    .Select(p => p.ImageURL)
                    .ToList();
            }

            List<string> sideImages = new List<string>();
            sideImages = rawDataTypeThree
                .Where(file => file.DocumentDescription_BU.ToLower().Contains("side"))
                .Select(p => p.ImageURL)
                .ToList();
            if (!sideImages.Any())
            {
                sideImages = rawDataTypeTwo
                    .Where(file => file.DocumentDescription_BU.ToLower().Contains("side"))
                    .Select(p => p.ImageURL)
                    .ToList();
            }

            List<string> wheelImages = new List<string>();
            wheelImages = rawDataTypeThree
                .Where(file => file.DocumentDescription_BU.ToLower().Contains("wheel"))
                .Select(p => p.ImageURL)
                .ToList();
            if (!wheelImages.Any())
            {
                wheelImages = rawDataTypeTwo
                    .Where(file => file.DocumentDescription_BU.ToLower().Contains("wheel"))
                    .Select(p => p.ImageURL)
                    .ToList();
            }

            List<string> damageImages = new List<string>();
            damageImages = rawDataTypeThree
                .Where(file => file.DocumentDescription_BU.ToLower().Contains("damage"))
                .Select(p => p.ImageURL)
                .ToList();
            if (!damageImages.Any())
            {
                damageImages = rawDataTypeTwo
                    .Where(file => file.DocumentDescription_BU.ToLower().Contains("damage"))
                    .Select(p => p.ImageURL)
                    .ToList();
            }

            List<string> trayImages = new List<string>();
            trayImages = rawDataTypeThree
                .Where(file => (file.DocumentDescription_BU.ToLower().EndsWith(".png") || file.DocumentDescription_BU.ToLower().EndsWith(".jpeg")) && Path.GetFileNameWithoutExtension(file.DocumentDescription_BU).ToLower().Contains("tray"))
                .Select(p => p.ImageURL)
                .ToList();
            if (!trayImages.Any())
            {
                trayImages = rawDataTypeTwo
                     .Where(file => (file.DocumentDescription_BU.ToLower().EndsWith(".png") || file.DocumentDescription_BU.ToLower().EndsWith(".jpeg")) && Path.GetFileNameWithoutExtension(file.DocumentDescription_BU).ToLower().Contains("tray"))
                    .Select(p => p.ImageURL)
                    .ToList();
            }

            List<string> otherImages = new List<string>();
            otherImages = rawDataTypeThree
                .Where(file => (!file.DocumentDescription_BU.ToLower().Contains("front")
                && !file.DocumentDescription_BU.ToLower().Contains("back")
                && !file.DocumentDescription_BU.ToLower().Contains("chassis")
                && !file.DocumentDescription_BU.ToLower().Contains("engine")
                && !file.DocumentDescription_BU.ToLower().Contains("plate")
                && !file.DocumentDescription_BU.ToLower().Contains("mileage")
                && !file.DocumentDescription_BU.ToLower().Contains("key")
                && !file.DocumentDescription_BU.ToLower().Contains("interior")
                && !file.DocumentDescription_BU.ToLower().Contains("side")
                && !file.DocumentDescription_BU.ToLower().Contains("wheel")
                && !file.DocumentDescription_BU.ToLower().Contains("tray")
                && !file.DocumentDescription_BU.ToLower().Contains("damage")))
                .Select(p => p.ImageURL)
                .ToList();
            if (!otherImages.Any())
            {
                otherImages = rawDataTypeTwo
                    .Where(file => (!file.DocumentDescription_BU.ToLower().Contains("front")
                && !file.DocumentDescription_BU.ToLower().Contains("back")
                && !file.DocumentDescription_BU.ToLower().Contains("chassis")
                && !file.DocumentDescription_BU.ToLower().Contains("engine")
                && !file.DocumentDescription_BU.ToLower().Contains("plate")
                && !file.DocumentDescription_BU.ToLower().Contains("mileage")
                && !file.DocumentDescription_BU.ToLower().Contains("key")
                && !file.DocumentDescription_BU.ToLower().Contains("interior")
                && !file.DocumentDescription_BU.ToLower().Contains("side")
                && !file.DocumentDescription_BU.ToLower().Contains("wheel")
                && !file.DocumentDescription_BU.ToLower().Contains("tray")
                && !file.DocumentDescription_BU.ToLower().Contains("damage")))
                .Select(p => p.ImageURL)
                .ToList();
            }

            galleryData.Front = string.Join("; ", frontImages);
            galleryData.Back = string.Join("; ", backImages);
            galleryData.Chassis = string.Join("; ", chassisImages);
            galleryData.Engine = string.Join("; ", engineImages);
            galleryData.Plate = string.Join("; ", plateImages);
            galleryData.Mileage = string.Join("; ", mileageImages);
            galleryData.VehicleKey = string.Join("; ", keyImages);
            galleryData.Interior = string.Join("; ", interiorImages);
            galleryData.Side = string.Join("; ", sideImages);
            galleryData.Wheel = string.Join("; ", wheelImages);
            galleryData.Damage = string.Join("; ", damageImages);
            galleryData.Tray = string.Join("; ", trayImages);
            galleryData.Other = string.Join("; ", otherImages);


            return galleryData;
        }

        #endregion
    }

    #region BuyNow_Query
    public class BuyNow_Query
    {

        public static string Save_RegisterUser = $@"INSERT INTO BuyNowUser (Name,Email,PhoneNumber,Password) 
                                                Values (@Name,@Email,@PhoneNumber,@Password) ;SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Check_Duplicate_User = $@"Select * from BuyNowUser where Email=@Email and id<>@id";

        public static string Login_BuyNow_User = $@"Select * from BuyNowUser where Email=@Email and Password=@Password";

        public static string Save_BidLog = $@"INSERT INTO BnBBidLog (BnBScheduleDetailID,VehicleNumber,CustomerNumber,Email,BidAmount,CreateDate,CreateTime,Status)
                                        VALUES(@BnBScheduleDetailID,@VehicleNumber,@CustomerNumber,@Email,@BidAmount,@CreateDate,@CreateTime,@Status);SELECT CAST(SCOPE_IDENTITY() AS INT);";

    }
    #endregion
}
