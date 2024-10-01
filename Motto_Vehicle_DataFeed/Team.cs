using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOTTO_DATAFEED.DAO;
using Newtonsoft.Json;
using System.Net.Http;
using Motto_Vehicle_DataFeed.DAO;
using System.Xml.Linq;

namespace Motto_Vehicle_DataFeed
{
    public class Team_DATAFEED
    {
        public Team_DATAFEED() { }

        #region DevSprintDetail
        #region SaveDevSprintDetail
        public int SaveDevSprintDetail(DataTable dtData)
        {
            int Id = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DevSprintDetail objDevSprintDetail = new DevSprintDetail();
                    objDevSprintDetail.SprintCode = (dtData.Rows[i]["sprintCode"] == null ? "" : dtData.Rows[i]["sprintCode"].ToString());
                    objDevSprintDetail.ProjectCode = (dtData.Rows[i]["projectCode"] == null ? "" : dtData.Rows[i]["projectCode"].ToString());
                    objDevSprintDetail.JiraLink = (dtData.Rows[i]["jiraLink"] == null ? "" : dtData.Rows[i]["jiraLink"].ToString());
                    objDevSprintDetail.SprintFrom = DateTime.Parse(dtData.Rows[i]["sprintFrom"] == null ? new DateTime(1970, 01, 01).ToString() : dtData.Rows[i]["sprintFrom"].ToString());
                    objDevSprintDetail.SprintTo = DateTime.Parse(dtData.Rows[i]["sprintTo"] == null ? new DateTime(1970, 01, 01).ToString() : dtData.Rows[i]["sprintTo"].ToString());
                    objDevSprintDetail.EpicName =(dtData.Rows[i]["epicName"] == null ? "" : dtData.Rows[i]["epicName"].ToString());
                    objDevSprintDetail.UserStoryName = (dtData.Rows[i]["userStoryName"] == null ? "" : dtData.Rows[i]["userStoryName"].ToString());
                    objDevSprintDetail.PerformedBy = (dtData.Rows[i]["performedBy"] == null ? "" : dtData.Rows[i]["performedBy"].ToString());
                    objDevSprintDetail.Status = int.Parse(dtData.Rows[i]["status"] == null ? "0" : dtData.Rows[i]["status"].ToString());

                    var context = new MAMS_dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var DevSprintDetailParam = new List<SqlParameter> {
                    new SqlParameter("@SprintCode",objDevSprintDetail.SprintCode),
                    new SqlParameter("@ProjectCode",objDevSprintDetail.ProjectCode),
                    new SqlParameter("@JiraLink",objDevSprintDetail.JiraLink),
                    new SqlParameter("@SprintFrom",objDevSprintDetail.SprintFrom),
                    new SqlParameter("@SprintTo",objDevSprintDetail.SprintTo),
                    new SqlParameter("@EpicName",objDevSprintDetail.EpicName),
                    new SqlParameter("@UserStoryName",objDevSprintDetail.UserStoryName),
                    new SqlParameter("@PerformedBy",objDevSprintDetail.PerformedBy),
                    new SqlParameter("@Status",objDevSprintDetail.Status)
                    };

                    #endregion Parameter

                    Id = context.Database.SqlQuery<int>(Team_Query.Save_DevSprintDetail, DevSprintDetailParam.ToArray()).SingleOrDefault();
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

        #region UpdateDevSprintDetail
        public int UpdateDevSprintDetail(DataTable dtData)
        {
            int Id = 0;
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DevSprintDetail objDevSprintDetail = new DevSprintDetail();
                    objDevSprintDetail.SprintID = int.Parse(dtData.Rows[i]["sprintId"] == null ? "0" : dtData.Rows[i]["sprintId"].ToString());
                    objDevSprintDetail.SprintCode = (dtData.Rows[i]["sprintCode"] == null ? "" : dtData.Rows[i]["sprintCode"].ToString());
                    objDevSprintDetail.ProjectCode = (dtData.Rows[i]["projectCode"] == null ? "" : dtData.Rows[i]["projectCode"].ToString());
                    objDevSprintDetail.JiraLink = (dtData.Rows[i]["jiraLink"] == null ? "" : dtData.Rows[i]["jiraLink"].ToString());
                    objDevSprintDetail.SprintFrom = DateTime.Parse(dtData.Rows[i]["sprintFrom"] == null ? new DateTime(1970, 01, 01).ToString() : dtData.Rows[i]["sprintFrom"].ToString());
                    objDevSprintDetail.SprintTo = DateTime.Parse(dtData.Rows[i]["sprintTo"] == null ? new DateTime(1970, 01, 01).ToString() : dtData.Rows[i]["sprintTo"].ToString());
                    objDevSprintDetail.EpicName = (dtData.Rows[i]["epicName"] == null ? "" : dtData.Rows[i]["epicName"].ToString());
                    objDevSprintDetail.UserStoryName = (dtData.Rows[i]["userStoryName"] == null ? "" : dtData.Rows[i]["userStoryName"].ToString());
                    objDevSprintDetail.PerformedBy = (dtData.Rows[i]["performedBy"] == null ? "" : dtData.Rows[i]["performedBy"].ToString());
                    objDevSprintDetail.Status = int.Parse(dtData.Rows[i]["status"] == null ? "0" : dtData.Rows[i]["status"].ToString());

                    var context = new MAMS_dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var DevSprintDetailParam = new List<SqlParameter> {
                    new SqlParameter("@SprintID",objDevSprintDetail.SprintID),
                    new SqlParameter("@SprintCode",objDevSprintDetail.SprintCode),
                    new SqlParameter("@ProjectCode",objDevSprintDetail.ProjectCode),
                    new SqlParameter("@JiraLink",objDevSprintDetail.JiraLink),
                    new SqlParameter("@SprintFrom",objDevSprintDetail.SprintFrom),
                    new SqlParameter("@SprintTo",objDevSprintDetail.SprintTo),
                    new SqlParameter("@EpicName",objDevSprintDetail.EpicName),
                    new SqlParameter("@UserStoryName",objDevSprintDetail.UserStoryName),
                    new SqlParameter("@PerformedBy",objDevSprintDetail.PerformedBy),
                    new SqlParameter("@Status",objDevSprintDetail.Status)
                    };

                    #endregion Parameter
                    context.Database.ExecuteSqlCommand(Team_Query.Update_DevSprintDetail, DevSprintDetailParam.ToArray());
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

        #region DeleteDevSprintDetail
        public void DeleteDevSprintDetail(DataTable dtData)
        {
            try
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DevSprintDetail objDevSprintDetail = new DevSprintDetail();
                    objDevSprintDetail.SprintID = int.Parse(dtData.Rows[i]["sprintId"] == null ? "0" : dtData.Rows[i]["sprintId"].ToString());

                    var context = new MAMS_dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    var DevSprintDetailParam = new List<SqlParameter> {
                    new SqlParameter("@SprintID",objDevSprintDetail.SprintID)
                    };

                    #endregion Parameter

                    context.Database.ExecuteSqlCommand(Team_Query.Delete_DevSprintDetail, DevSprintDetailParam.ToArray());
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region GetDevSprintDetailById
        public DataTable GetDevSprintDetailById(DataTable dtData)
        {
            DataTable result = new DataTable();
            try
            {
                int Id = int.Parse(dtData.Rows[0]["sprintId"] == null ? "0" : dtData.Rows[0]["sprintId"].ToString());
                using (var context = new MAMS_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = Team_Query.Get_DevSprintDetail_ById;

                        command.Parameters.Add(new SqlParameter("@SprintID", Id));

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

        #region GetDevSprintDetailList
        public DataTable GetDevSprintDetailList()
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
                        command.CommandText = Team_Query.Get_DevSprintDetail_List;

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
    }

    #region Team_Query
    public class Team_Query
    {

        #region DevSprintDetail
        public static string Save_DevSprintDetail = $@"INSERT INTO DevSprintDetail (SprintCode,ProjectCode,JiraLink,SprintFrom,SprintTo,EpicName,UserStoryName,PerformedBy,Status)
                                        VALUES(@SprintCode,@ProjectCode,@JiraLink,@SprintFrom,@SprintTo,@EpicName,@UserStoryName,@PerformedBy,@Status);SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Update_DevSprintDetail = $@"UPDATE DevSprintDetail set [SprintCode]=@SprintCode,
                                                                                [ProjectCode]=@ProjectCode,
                                                                                [JiraLink]=@JiraLink,
                                                                                [SprintFrom]=@SprintFrom,
                                                                                [SprintTo]=@SprintTo,
                                                                                [EpicName]=@EpicName,
                                                                                [UserStoryName]=@UserStoryName,
                                                                                [PerformedBy]=@PerformedBy,
                                                                                [Status]=@Status where SprintID=@SprintID"; 

        public static string Delete_DevSprintDetail = $@"Delete DevSprintDetail where SprintID=@SprintID ";

        public static string Get_DevSprintDetail_List = $@"Select SprintID,SprintCode,ProjectCode,JiraLink,CONVERT(varchar(10),SprintFrom,105)SprintFrom,
                                                           CONVERT(varchar(10),SprintTo,105)SprintTo,EpicName,UserStoryName,PerformedBy,Status from DevSprintDetail";

        public static string Get_DevSprintDetail_ById = $@"Select SprintID,SprintCode,ProjectCode,JiraLink,CONVERT(varchar(10),SprintFrom,105)SprintFrom,
                                                        CONVERT(varchar(10),SprintTo,105)SprintTo,EpicName,UserStoryName,PerformedBy,Status from DevSprintDetail  where SprintID=@SprintID";
        #endregion

    }
    #endregion
}
