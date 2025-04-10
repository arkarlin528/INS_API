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
        public DateTime TxnDate { get; set; }
        public string SchemaName { get; set; }
        public string SchemaInfo { get; set; }
        public string InspectionData { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string MobileNumber { get; set; }
        public string SellerCode { get; set; }
        public string Inspector { get; set; }
        public string VehicleId { get; set; }
        public string ChasisNumber { get; set; }
        public string VIN { get; set; }
        public string RegistrationNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Query_CreateInspection = @"INSERT INTO [dbo].[INNO_SYNC] (TxnDate,SchemaName,SchemaInfo,InspectionData,SenderName,ReceiverName,MobileNumber,SellerCode,Inspector,VehicleId,ChasisNumber,VIN,RegistrationNumber,CreatedBy,CreatedDate)" +
                                               "VALUES (@TxnDate,@SchemaName,@SchemaInfo,@InspectionData,@SenderName,@ReceiverName,@MobileNumber,@SellerCode,@Inspector,@VehicleId," +
                                                "@ChasisNumber,@VIN,@RegistrationNumber,@CreatedBy,@CreatedDate);SELECT SCOPE_IDENTITY();";
        public string strSyncError = "";

        public InnoSync()
        {
            this.ID = 0;
            this.TxnDate = new DateTime();
            this.SchemaName = "";
            this.SchemaInfo = "";
            this.InspectionData = "";
            this.SenderName = "";
            this.ReceiverName = "";
            this.MobileNumber = "";
            this.SellerCode = "";
            this.Inspector = "";
            this.VehicleId = "";
            this.ChasisNumber = "";
            this.VIN = "";
            this.RegistrationNumber = "";
            this.CreatedBy = "";
            this.CreatedDate = new DateTime();
        }

        public bool SyncData(DataTable dt)
        {
            bool blRtn = false;
            if (dt.Rows.Count > 0)
            {
                this.ID = 0;
                this.TxnDate = DateTime.Parse(dt.Rows[0]["TxnDate"] != null ? dt.Rows[0]["TxnDate"].ToString() : new DateTime(1900, 1, 1).ToString("yyyy-MM-dd"));
                this.SchemaName = (dt.Rows[0]["SchemaName"] != null ? dt.Rows[0]["SchemaName"].ToString() : "");
                this.InspectionData = (dt.Rows[0]["InspectionData"] != null ? dt.Rows[0]["InspectionData"].ToString() : ""); ;
                this.SenderName = (dt.Rows[0]["SenderName"] != null ? dt.Rows[0]["SenderName"].ToString() : ""); ;
                this.ReceiverName = (dt.Rows[0]["ReceiverName"] != null ? dt.Rows[0]["ReceiverName"].ToString() : ""); ;
                this.MobileNumber = (dt.Rows[0]["MobileNumber"] != null ? dt.Rows[0]["MobileNumber"].ToString() : ""); ;
                this.SellerCode = (dt.Rows[0]["SellerCode"] != null ? dt.Rows[0]["SellerCode"].ToString() : ""); ;
                this.Inspector = (dt.Rows[0]["Inspector"] != null ? dt.Rows[0]["Inspector"].ToString() : ""); ;
                this.VehicleId = (dt.Rows[0]["VehicleId"] != null ? dt.Rows[0]["VehicleId"].ToString() : ""); ;
                this.ChasisNumber = (dt.Rows[0]["ChasisNumber"] != null ? dt.Rows[0]["ChasisNumber"].ToString() : ""); ;
                this.VIN = (dt.Rows[0]["VIN"] != null ? dt.Rows[0]["VIN"].ToString() : ""); ;
                this.RegistrationNumber = (dt.Rows[0]["RegistrationNumber"] != null ? dt.Rows[0]["RegistrationNumber"].ToString() : ""); ;
                this.CreatedBy = (dt.Rows[0]["CreatedBy"] != null ? dt.Rows[0]["CreatedBy"].ToString() : ""); ;
                this.CreatedDate = DateTime.Parse(dt.Rows[0][""] != null ? dt.Rows[0][""].ToString() : new DateTime(1900, 1, 1).ToString("yyyy-MM-dd"));
                blRtn = CreateInnoSyncRecord();
            }
            return blRtn;
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

                var detailParam = new List<SqlParameter> {
                            new SqlParameter("@TxnDate", this.TxnDate),
                            new SqlParameter("@SchemaName", this.SchemaName),
                            new SqlParameter("@SchemaInfo", this.SchemaInfo),
                            new SqlParameter("@InspectionData", this.InspectionData),
                            new SqlParameter("@SenderName", this.SenderName),
                            new SqlParameter("@ReceiverName", this.ReceiverName),
                             new SqlParameter("@MobileNumber", this.MobileNumber),
                            new SqlParameter("@SellerCode", this.SellerCode),
                            new SqlParameter("@Inspector", this.Inspector),
                            new SqlParameter("@VehicleId", this.VehicleId),
                            new SqlParameter("@ChasisNumber", this.ChasisNumber),
                             new SqlParameter("@VIN", this.VIN),
                            new SqlParameter("@RegistrationNumber", this.RegistrationNumber),
                            new SqlParameter("@CreatedBy", this.CreatedBy),
                            new SqlParameter("@CreatedDate", DateTime.Today),
                        };

                #endregion Parameter
                context.Database.SqlQuery<decimal>(Query_CreateInspection, detailParam.ToArray()).SingleOrDefault();
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

        public class InnoPostData
        {
            [JsonProperty("inspector_user_id")]
            public int InspectorUserId { get; set; } // Changed to int based on JSON structure

            [JsonProperty("end_time")]
            public string EndTime { get; set; }

            [JsonProperty("countdown_time")]
            public string CountdownTime { get; set; }

            [JsonProperty("data")]
            public string Data { get; set; } // Keeping data as a string

            [JsonProperty("schema")]
            public string Schema { get; set; } // Updated to PascalCase for C# convention
        }

        public class PostDataSchema
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("origin")]
            public string Origin { get; set; }

            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }

            [JsonProperty("created_by")]
            public int CreatedBy { get; set; } // Changed to int based on JSON structure

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("is_deleted")]
            public string IsDeleted { get; set; }
        }
    }
}
