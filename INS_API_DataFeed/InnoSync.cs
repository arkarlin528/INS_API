using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using Newtonsoft.Json;
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
                                                "@ChasisNumber,@VIN,@Reg,@CreatedBy,@CreatedDate);SELECT SCOPE_IDENTITY();";

        public string Query_UpdateVehicleId = @"UPDATE [dbo].[INNO_SYNC] SET VehicleId = @VehicleId WHERE ID = @ID;";
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
                this.VehicleId = (this.VehicleId == null ? "" : this.VehicleId);
                this.ChasisNumber = (this.ChasisNumber == null ? "" : this.ChasisNumber);
                this.VIN = (this.VIN == null ? "" : this.VIN);
                this.RegistrationNumber = (this.RegistrationNumber == null ? "" : this.RegistrationNumber);
                this.CreatedBy = (this.CreatedBy == null ? "" : this.CreatedBy);              

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
                    object result = command.ExecuteScalar();

                    this.ID = Convert.ToInt32(result);
                }
                if (context.Database.Connection.State == ConnectionState.Open)
                {
                    context.Database.Connection.Close();
                }
                blRtn = true;
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
    }
}
