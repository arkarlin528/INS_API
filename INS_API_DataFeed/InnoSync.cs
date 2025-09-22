using INS_API_DataFeed.DAO;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;

namespace INS_API_DataFeed
{
    public class InnoSync
    {
        public int ID { get; set; }
        public string RefKey { get; set; }
        public DateTime TxnDate { get; set; }
        public string SchemaName { get; set; }
        public string SchemaInfo { get; set; }
        public string InspectionData { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string MobileNumber { get; set; }
        public string SellerCode { get; set; }
        public string InspectorID { get; set; }
        public string Inspector { get; set; }
        public string VehicleId { get; set; }
        public string ChasisNumber { get; set; }
        public string VIN { get; set; }
        public string RegistrationNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Query_CreateInspection = @"INSERT INTO [dbo].[INNO_SYNC] " +
                                               "VALUES (@RefKey,@TxnDate,@SchemaName,@SchemaInfo,@InspectionData,@SenderName,@ReceiverName,@MobileNumber,@SellerCode,@InspectorID,@Inspector,@VehicleId," +
                                                "@ChasisNumber,@VIN,@Reg,@CreatedBy,@CreatedDate,0,0,@ErrorMsg);SELECT SCOPE_IDENTITY();";

        public string Query_UpdateVehicleId = @"UPDATE [dbo].[INNO_SYNC] SET VehicleId = @VehicleId WHERE ID = @ID;";

        public string Query_InsertInnoSyncOBSImage = @"INSERT INTO [dbo].[INNO_SYNC_OBSImages] VALUES (@INNO_SYNC_ID,@RefKey,@SchemaName,@VehicleId,@OBSImagePath,@ImageType,@CreateURLDate);";

        public string Query_CheckDuplicateCarBookIn = @"SELECT * FROM [dbo].[INNO_SYNC] WHERE SellerCode = @SellerCode AND RegistrationNumber = @Reg And SchemaName like '%bookin%';";
        public string strSyncError = "";

        public InnoSync()
        {
            this.ID = 0;
            this.RefKey = "";
            this.TxnDate = new DateTime();
            this.SchemaName = "";
            this.SchemaInfo = "";
            this.InspectionData = "";
            this.SenderName = "";
            this.ReceiverName = "";
            this.MobileNumber = "";
            this.SellerCode = "";
            this.InspectorID = "";
            this.Inspector = "";
            this.VehicleId = "";
            this.ChasisNumber = "";
            this.VIN = "";
            this.RegistrationNumber = "";
            this.CreatedBy = "";
            this.CreatedDate = new DateTime();
        }

        #region CreateInnoSyncRecord
        public bool CreateInnoSyncRecord()
        {
            bool blRtn = false;
            try
            {
                var context = new INS_WEB_dataFeedContext();
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }

                #region Parameter

                this.SenderName = (this.SenderName == null ? "" : this.SenderName);
                this.ReceiverName = (this.ReceiverName == null ? "" : this.ReceiverName);
                this.MobileNumber = (this.MobileNumber == null ? "" : this.MobileNumber);
                this.SellerCode = (this.SellerCode == null ? "" : this.SellerCode);
                this.Inspector = (this.Inspector == null ? "" : this.Inspector);
                this.InspectorID = (this.InspectorID == null ? "" : this.InspectorID);
                this.VehicleId = (this.VehicleId == null ? "" : this.VehicleId);
                this.ChasisNumber = (this.ChasisNumber == null ? "" : this.ChasisNumber);
                this.VIN = (this.VIN == null ? "" : this.VIN);
                this.RegistrationNumber = (this.RegistrationNumber == null ? "" : this.RegistrationNumber);
                this.CreatedBy = (this.CreatedBy == null ? "" : this.CreatedBy);

                DataTable chkDuplicate = new DataTable();
                if (this.SchemaName.Contains("bookin"))
                {
                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Query_CheckDuplicateCarBookIn;

                        #region Parameters

                        command.Parameters.Add(new SqlParameter("@SellerCode", this.SellerCode));
                        command.Parameters.Add(new SqlParameter("@Reg", this.RegistrationNumber));
                        #endregion Parameters

                        using (var reader = command.ExecuteReader())
                        {
                            chkDuplicate.Load(reader);
                        }
                    }
                    if (chkDuplicate.Rows.Count > 0)
                    {

                        strSyncError = "Duplicate Car BookIn Record";
                    }
                }
                #endregion Parameter
                using (SqlCommand command = new SqlCommand(Query_CreateInspection, (SqlConnection)context.Database.Connection))
                {
                    command.Parameters.AddWithValue("@RefKey", this.RefKey);
                    command.Parameters.AddWithValue("@TxnDate", this.TxnDate);
                    command.Parameters.AddWithValue("@SchemaName", this.SchemaName);
                    command.Parameters.AddWithValue("@SchemaInfo", this.SchemaInfo);
                    command.Parameters.AddWithValue("@InspectionData", this.InspectionData);
                    command.Parameters.AddWithValue("@SenderName", this.SenderName);
                    command.Parameters.AddWithValue("@ReceiverName", this.ReceiverName);
                    command.Parameters.AddWithValue("@MobileNumber", this.MobileNumber);
                    command.Parameters.AddWithValue("@SellerCode", this.SellerCode);
                    command.Parameters.AddWithValue("@InspectorID", this.InspectorID);
                    command.Parameters.AddWithValue("@Inspector", this.Inspector);
                    command.Parameters.AddWithValue("@VehicleId", this.VehicleId); 
                    command.Parameters.AddWithValue("@ChasisNumber", this.ChasisNumber);
                    command.Parameters.AddWithValue("@VIN", this.VIN);
                    command.Parameters.AddWithValue("@Reg", this.RegistrationNumber);
                    command.Parameters.AddWithValue("@CreatedBy", this.CreatedBy);
                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Today);
                    command.Parameters.AddWithValue("@ErrorMsg", strSyncError);
                    object result = command.ExecuteScalar();

                    this.ID = Convert.ToInt32(result);
                }
                if (context.Database.Connection.State == ConnectionState.Open)
                {
                    context.Database.Connection.Close();
                }

                if (chkDuplicate.Rows.Count == 0)
                {
                    blRtn = true;
                }

            }
            catch (Exception ex)
            {
                strSyncError = ex.ToString();
            }
            return blRtn;
        }
        #endregion

        #region UpdateVehicleID
        public void UpdateVehicleID()
        {
            try
            {
                var context = new INS_WEB_dataFeedContext();
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }

                #region Parameter

                this.VehicleId = (this.VehicleId == null ? "" : this.VehicleId);

                #endregion Parameter
                using (SqlCommand command = new SqlCommand(Query_UpdateVehicleId, (SqlConnection)context.Database.Connection))
                {
                    command.Parameters.AddWithValue("@VehicleId", this.VehicleId);
                    command.Parameters.AddWithValue("@ID", this.ID);
                    object result = command.ExecuteScalar();
                }
                if (context.Database.Connection.State == ConnectionState.Open)
                {
                    context.Database.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                strSyncError = ex.ToString();
            }
        }
        #endregion

        #region InsertInnoSyncOBSImage
        public void InsertInnoSyncOBSImage(string tempUrl,string imageType)
        {
            try
            {
                var context = new INS_WEB_dataFeedContext();
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }

                #region Parameter

                this.RefKey = (this.RefKey == null ? "" : this.RefKey);
                this.SchemaName = (this.SchemaName == null ? "" : this.SchemaName);
                this.VehicleId = (this.VehicleId == null ? "" : this.VehicleId);

                #endregion Parameter
                using (SqlCommand command = new SqlCommand(Query_InsertInnoSyncOBSImage, (SqlConnection)context.Database.Connection))
                {
                    command.Parameters.AddWithValue("@INNO_SYNC_ID", this.ID);
                    command.Parameters.AddWithValue("@RefKey", this.RefKey);
                    command.Parameters.AddWithValue("@SchemaName", this.SchemaName);
                    command.Parameters.AddWithValue("@VehicleId", this.VehicleId);
                    command.Parameters.AddWithValue("@OBSImagePath", tempUrl);
                    command.Parameters.AddWithValue("@ImageType", imageType);
                    command.Parameters.AddWithValue("@CreateURLDate", DateTime.Now);
                    object result = command.ExecuteScalar();
                }
                if (context.Database.Connection.State == ConnectionState.Open)
                {
                    context.Database.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                strSyncError = ex.ToString();
            }
        }
        #endregion

        #region SyncOnIMAPInspectionDocument
        public void SyncOnIMAPInspectionDocument(string tempUrl, string imageType)
        {
            try
            {
                #region Parameter

                this.VehicleId = (this.VehicleId == null ? "" : this.VehicleId);

                #endregion Parameter

                using (var context = new Inspection_dataFeedContext())
                {
                    var connection = context.Database.Connection;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "dbo.CreateVehicleDocument_INNO";
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        var param1 = command.CreateParameter();
                        param1.ParameterName = "@vehicleId";
                        param1.DbType = DbType.String;
                        param1.Size = 18;
                        param1.Value = this.VehicleId;
                        command.Parameters.Add(param1);

                        var param2 = command.CreateParameter();
                        param2.ParameterName = "@documentDescription_BU";
                        param2.DbType = DbType.String;
                        param2.Size = 100;
                        param2.Value = imageType;
                        command.Parameters.Add(param2);

                        var param3 = command.CreateParameter();
                        param3.ParameterName = "@documentDescription_LO";
                        param3.DbType = DbType.String;
                        param3.Size = 100;
                        param3.Value = imageType;
                        command.Parameters.Add(param3);

                        var param4 = command.CreateParameter();
                        param4.ParameterName = "@documentTypeID";
                        param4.DbType = DbType.Int16;
                        param4.Value = 2;
                        command.Parameters.Add(param4);


                        var param5 = command.CreateParameter();
                        param5.ParameterName = "@documentPath";
                        param5.DbType = DbType.String;
                        param5.Size = 400;
                        param5.Value = tempUrl;
                        command.Parameters.Add(param5);

                        //var param6 = command.CreateParameter();
                        //param6.ParameterName = "@document";
                        //param6.DbType = DbType.Byte;
                        //param6.Size = 400;
                        //param6.Value = null;
                        //command.Parameters.Add(param6);

                        command.ExecuteNonQuery(); // Execute the stored procedure
                    }
                }
            }
            catch (Exception ex)
            {
                strSyncError = ex.ToString();
            }
        }
        #endregion

        #region UpdateVehicleDocument
        public void UpdateVehicleDocument()
        {
            try
            {
                this.VehicleId = (this.VehicleId == null ? "" : this.VehicleId);
                using (var context = new Inspection_dataFeedContext())
                {
                    var connection = context.Database.Connection;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "dbo.UpdateVehicleDocumentDeleted_INNO";
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        var param1 = command.CreateParameter();
                        param1.ParameterName = "@vehicleId";
                        param1.DbType = DbType.String;
                        param1.Size = 18;
                        param1.Value = this.VehicleId;
                        command.Parameters.Add(param1);

                        var param2 = command.CreateParameter();
                        param2.ParameterName = "@documentTypeID";
                        param2.DbType = DbType.Int16;
                        param2.Value = 2;
                        command.Parameters.Add(param2);

                        command.ExecuteNonQuery(); // Execute the stored procedure
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
    }
}
