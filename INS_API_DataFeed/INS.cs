using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using INS_API_DataFeed.DAO;

namespace INS_API_DataFeed
{
    public class INS_DataFeed
    {
        #region GetBody
        public DataTable GetBody()
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
                        command.CommandText = INS_Query.get_Body;

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

        #region GetContractType
        public DataTable GetContractType()
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
                        command.CommandText = INS_Query.get_ContractType;

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

        #region GetSellingCategory
        public DataTable GetSellingCategory()
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
                        command.CommandText = INS_Query.get_SellingCategory;

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

        #region GetDrive
        public DataTable GetDrive()
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
                        command.CommandText = INS_Query.get_Drive;

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

        #region GetFuelDelivery
        public DataTable GetFuelDelivery()
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
                        command.CommandText = INS_Query.get_FuelDelivery;

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

        #region GetFuelType
        public DataTable GetFuelType()
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
                        command.CommandText = INS_Query.get_FuelType;

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

        #region GetMake
        public DataTable GetMake()
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
                        command.CommandText = INS_Query.get_Make;

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

        #region GetMatVariant
        public DataTable GetMatVariant()
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
                        command.CommandText = INS_Query.get_MatVariant;

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

        #region GetMatVariantByModel
        public DataTable GetMatVariantByModel(string model)
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
                        command.CommandText = INS_Query.get_MatVariant_ByModel;

                        command.Parameters.Add(new SqlParameter("@Model", model));

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

        #region GetSeller
        public DataTable GetSeller()
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
                        command.CommandText = INS_Query.get_Seller;

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

        #region GetRoofType
        public DataTable GetRoofType()
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
                        command.CommandText = INS_Query.get_RoofType;

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

        #region GetGasType
        public DataTable GetGasType()
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
                        command.CommandText = INS_Query.get_GasType;

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

        #region GetCatalyticOption
        public DataTable GetCatalyticOption()
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
                        command.CommandText = INS_Query.get_CatalyticOption;

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

        #region GetWindowOption
        public DataTable GetWindowOption()
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
                        command.CommandText = INS_Query.get_WindowOption;

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

        #region GetSteeringWheelType
        public DataTable GetSteeringWheelType()
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
                        command.CommandText = INS_Query.get_SteeringWheelType;

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

        #region GetPlateType
        public DataTable GetPlateType()
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
                        command.CommandText = INS_Query.get_PlateType;

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

        #region GetCabinOverall
        public DataTable GetCabinOverall()
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
                        command.CommandText = INS_Query.get_CabinOverall;

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

        #region GetCabinOverallById
        public DataTable GetCabinOverallById(int id)
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
                        command.CommandText = INS_Query.get_CabinOverallById;

                        command.Parameters.Add(new SqlParameter("@id", id));

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

        #region GetMakeByCode
        public DataTable GetMakeByCode(string code)
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
                        command.CommandText = INS_Query.get_MakeByCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetColour
        public DataTable GetColour()
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
                        command.CommandText = INS_Query.get_Colour;

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

        #region GetColourByCode
        public DataTable GetColourByCode(string code)
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
                        command.CommandText = INS_Query.get_ColourByCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetColourSet
        public DataTable GetColourSet()
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
                        command.CommandText = INS_Query.get_ColourSet;

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

        #region GetColourSetByCode
        public DataTable GetColourSetByCode(string code)
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
                        command.CommandText = INS_Query.get_ColourSetByCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetBodyByCode
        public DataTable GetBodyByCode(string code)
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
                        command.CommandText = INS_Query.get_BodyByCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetState
        public DataTable GetState()
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
                        command.CommandText = INS_Query.get_State;

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

        #region GetStateByCode
        public DataTable GetStateByCode(string code)
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
                        command.CommandText = INS_Query.get_StateByCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetStorage
        public DataTable GetStorage()
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
                        command.CommandText = INS_Query.get_Storage;

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

        #region GetStorageById
        public DataTable GetStorageById(int id)
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
                        command.CommandText = INS_Query.get_StorageById;

                        command.Parameters.Add(new SqlParameter("@id", id));

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

        #region GetPlant
        public DataTable GetPlant()
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
                        command.CommandText = INS_Query.get_Plant;

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

        #region GetPlantByCode
        public DataTable GetPlantByCode(string code)
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
                        command.CommandText = INS_Query.get_PlantByCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetSellingCategoryByCode
        public DataTable GetSellingCategoryByCode(string code)
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
                        command.CommandText = INS_Query.get_SellingCategoryByCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetDriveByCode
        public DataTable GetDriveByCode(string code)
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
                        command.CommandText = INS_Query.get_DriveByCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetEngineCapacityUnit
        public DataTable GetEngineCapacityUnit()
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
                        command.CommandText = INS_Query.get_EngineCapacityUnit;

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

        #region GetEngineCapacityUnitByCode
        public DataTable GetEngineCapacityUnitByCode(string code)
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
                        command.CommandText = INS_Query.get_EngineCapacityUnitByCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetGearBox
        public DataTable GetGearBox()
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
                        command.CommandText = INS_Query.get_GearBox;

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

        #region GetGearBoxByCode
        public DataTable GetGearBoxByCode(string code)
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
                        command.CommandText = INS_Query.get_GearBoxByCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetGear
        public DataTable GetGear()
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
                        command.CommandText = INS_Query.get_Gear;

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

        #region GetGearByCode
        public DataTable GetGearByCode(string code)
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
                        command.CommandText = INS_Query.get_GearByCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetFuelDeliveryByCode
        public DataTable GetFuelDeliveryByCode(string code)
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
                        command.CommandText = INS_Query.get_FuelDeliveryByCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetFuelTypeByCode
        public DataTable GetFuelTypeByCode(string code)
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
                        command.CommandText = INS_Query.get_FuelTypeByCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetModelTemplate
        public DataTable GetModelTemplate()
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
                        command.CommandText = INS_Query.get_ModelTemplate;

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

        #region GetModelTemplateByModelCode
        public DataTable GetModelTemplateByModelCode(string code)
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
                        command.CommandText = INS_Query.get_ModelTemplateByCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetMakeByModelCode
        public DataTable GetMakeByModelCode(string code)
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
                        command.CommandText = INS_Query.get_MakeByModelCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetModelTemplateByMake
        public DataTable GetModelTemplateByMake(string code)
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
                        command.CommandText = INS_Query.get_ModelTemplateByMake;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetVariantByModelCode
        public DataTable GetVariantByModelCode(string code)
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
                        command.CommandText = INS_Query.get_VariantByModelCode;

                        command.Parameters.Add(new SqlParameter("@code", code));

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

        #region GetEngineCapacityByVarId
        public DataTable GetEngineCapacityByVarId(int id)
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
                        command.CommandText = INS_Query.get_EngineCapacityByVarID;

                        command.Parameters.Add(new SqlParameter("@id", id));

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

        #region GetEngineCapacityUnitByVarId
        public DataTable GetEngineCapacityUnitByVarId(int id)
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
                        command.CommandText = INS_Query.get_EngineCapacityUnitByVarID;

                        command.Parameters.Add(new SqlParameter("@id", id));

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

        #region GetFuelDeliveryByVarId
        public DataTable GetFuelDeliveryByVarId(int id)
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
                        command.CommandText = INS_Query.get_FuelDeliveryByVarID;

                        command.Parameters.Add(new SqlParameter("@id", id));

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

        #region GetFuelTypeByVarId
        public DataTable GetFuelTypeByVarId(int id)
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
                        command.CommandText = INS_Query.get_FuelTypeByVarID;

                        command.Parameters.Add(new SqlParameter("@id", id));

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

        #region GetGearBoxByVarId
        public DataTable GetGearBoxByVarId(int id)
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
                        command.CommandText = INS_Query.get_GearBoxByVarID;

                        command.Parameters.Add(new SqlParameter("@id", id));

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

        #region GetGearByVarId
        public DataTable GetGearByVarId(int id)
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
                        command.CommandText = INS_Query.get_GearByVarID;

                        command.Parameters.Add(new SqlParameter("@id", id));

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

        #region GetBodyByVarId
        public DataTable GetBodyByVarId(int id)
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
                        command.CommandText = INS_Query.get_BodyByVarID;

                        command.Parameters.Add(new SqlParameter("@id", id));

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

        #region GetMatModel
        public DataTable GetMatModel()
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
                        command.CommandText = INS_Query.get_MatModel;

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

        #region GetCabType
        public DataTable GetCabType()
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
                        command.CommandText = INS_Query.get_CabType;

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

        #region GetLevelCab
        public DataTable GetLevelCab()
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
                        command.CommandText = INS_Query.get_LevelCab;

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

        #region GetVehicleColoursSet
        public DataTable GetVehicleColoursSet()
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
                        command.CommandText = INS_Query.get_VehicleColoursSet;

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

        #region SaveRiceHarvester
        public string SaveRiceHarvester(RiceHarvesterData data)
        {
            string errorMessage = "";
            try
            {
                DateTime actionTime = UnixTimeStampToDateTime(data.ActionUnixTime);

                    var context = new INS_WEB_dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    try
                    {
                        if (context.Database.Connection.State == ConnectionState.Closed)
                        {
                            context.Database.Connection.Open();
                        }

                        #region Parameter
                        var Param = new List<SqlParameter> {
                        new SqlParameter("@Tracks",data.Tracks),
                        new SqlParameter("@Rollers",data.Rollers),
                        new SqlParameter("@Blade",data.Blade),
                        new SqlParameter("@ConveyorChain",data.ConveyorChain),
                        new SqlParameter("@IdlerWheel",data.IdlerWheel),
                        new SqlParameter("@ThreshingChamber",data.ThreshingChamber),
                        new SqlParameter("@GrainStorageTank",data.GrainStorageTank),
                        new SqlParameter("@Battery",data.Battery),
                        new SqlParameter("@Covers",data.Covers),
                        new SqlParameter("@DriversSeat",data.DriversSeat),
                        new SqlParameter("@DustExtractionFan",data.DustExtractionFan),
                        new SqlParameter("@Roof",data.Roof),
                        new SqlParameter("@WorkerPlatform",data.WorkerPlatform),
                        new SqlParameter("@WorkerRearSupport",data.WorkerRearSupport),
                        new SqlParameter("@Toolbox",data.Toolbox),
                        new SqlParameter("@Key",data.Key),
                        new SqlParameter("@FuelLevel",data.FuelLevel),
                        new SqlParameter("@Lights",data.Lights),
                        new SqlParameter("@SeparatorGrateintheThreshingChamber",data.SeparatorGrateintheThreshingChamber),
                        new SqlParameter("@RotaryPickerUnit",data.RotaryPickerUnit),
                        new SqlParameter("@CutterHead",data.CutterHead),
                        new SqlParameter("@RiceThreshingSystem",data.RiceThreshingSystem),
                        new SqlParameter("@SteelWheels",data.SteelWheels),
                        new SqlParameter("@Rake",data.Rake),
                        new SqlParameter("@MoreDetails",data.MoreDetails),
                        new SqlParameter("@EngineCondition",data.EngineCondition),
                        new SqlParameter("@EngineCondition_text",data.EngineCondition_text),
                        new SqlParameter("@BodyCondition",data.BodyCondition),
                        new SqlParameter("@ColorCondition",data.ColorCondition),
                        new SqlParameter("@DriveSystem",data.DriveSystem),
                        new SqlParameter("@DriveSystem_text",data.DriveSystem_text),
                        new SqlParameter("@TransmissionSystem",data.TransmissionSystem),
                        new SqlParameter("@TransmissionSystem_text",data.TransmissionSystem_text),
                        new SqlParameter("@BrakeSystem",data.BrakeSystem),
                        new SqlParameter("@BrakeSystem_text",data.BrakeSystem_text),
                        new SqlParameter("@ClutchSystem",data.ClutchSystem),
                        new SqlParameter("@ClutchSystem_text",data.ClutchSystem_text),
                        new SqlParameter("@SteeringSystem",data.SteeringSystem),
                        new SqlParameter("@SteeringSystem_text",data.SteeringSystem_text),
                        new SqlParameter("@HydraulicSystem",data.HydraulicSystem),
                        new SqlParameter("@HydraulicSystem_text",data.HydraulicSystem_text),
                        new SqlParameter("@Others",data.Others),
                        new SqlParameter("@Others_text",data.Others_text),
                        new SqlParameter("@TotalCondition",data.TotalCondition),
                        new SqlParameter("@EstimatePrice",data.EstimatePrice),
                        new SqlParameter("@Remark",data.Remark),
                        new SqlParameter("@IMATNumber",data.IMATNumber),
                        new SqlParameter("@ActionLocation",data.ActionLocation),
                        new SqlParameter("@ActionBy",data.ActionBy),
                        new SqlParameter("@ActionTime",actionTime),
                        };
                        #endregion Parameter

                        int Id=context.Database.SqlQuery<int>(INS_Query.Save_RiceHarvester, Param.ToArray()).SingleOrDefault();
                        SaveInspectionImages(data.FrontImage, Id, data.IMATNumber, "FrontImage", "RiceHarvester");
                        SaveInspectionImages(data.LeftImage, Id, data.IMATNumber, "LeftImage", "RiceHarvester");
                        SaveInspectionImages(data.RearImage, Id, data.IMATNumber, "RearImage","RiceHarvester");
                        SaveInspectionImages(data.RightImage, Id, data.IMATNumber, "RightImage", "RiceHarvester");
                        SaveInspectionImages(data.MileageImage, Id, data.IMATNumber, "MileageImage", "RiceHarvester");
                        SaveInspectionImages(data.LicensePlateImage, Id, data.IMATNumber, "LicensePlateImage", "RiceHarvester");
                        SaveInspectionImages(data.ChassisImage, Id, data.IMATNumber, "ChassisImage", "RiceHarvester");
                        SaveInspectionImages(data.SeatImage, Id, data.IMATNumber, "SeatImage", "RiceHarvester");
                        SaveInspectionImages(data.EngineImage, Id, data.IMATNumber, "EngineImage", "RiceHarvester");
                        SaveInspectionImages(data.KeyImage, Id, data.IMATNumber, "KeyImage", "RiceHarvester");
                        SaveInspectionImages(data.ToolboxImage, Id, data.IMATNumber, "ToolboxImage", "RiceHarvester");
                        SaveInspectionImages(data.AttachedEquimentImage, Id, data.IMATNumber, "AttachedEquimentImage", "RiceHarvester");
                        SaveInspectionImages(data.DamageImage, Id, data.IMATNumber, "DamageImage", "RiceHarvester");
                    }
                    finally
                    {
                        if (context.Database.Connection.State == ConnectionState.Open)
                        {
                            context.Database.Connection.Close();
                        }
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
                errorMessage = ex.Message;
            }
            return errorMessage;
        }
        #endregion

        #region SaveExcavator
        public string SaveExcavator(ExcavatorData data)
        {
            string errorMessage = "";
            try
            {
                DateTime actionTime = UnixTimeStampToDateTime(data.ActionUnixTime);

                var context = new INS_WEB_dataFeedContext();
                context.Database.CommandTimeout = 300000;
                try
                {
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter
                    var Param = new List<SqlParameter> {
                        new SqlParameter("@Tracks",data.Tracks),
                        new SqlParameter("@Rollers",data.Rollers),
                        new SqlParameter("@DozerBlade",data.DozerBlade),
                        new SqlParameter("@HydraulicHoses",data.HydraulicHoses),
                        new SqlParameter("@ControlLevers",data.ControlLevers),
                        new SqlParameter("@DigitalDashboard",data.DigitalDashboard),
                        new SqlParameter("@Battery",data.Battery),
                        new SqlParameter("@CoverPanels",data.CoverPanels),
                        new SqlParameter("@DriversSeat",data.DriversSeat),
                        new SqlParameter("@SafetyLock",data.SafetyLock),
                        new SqlParameter("@Lights",data.Lights),
                        new SqlParameter("@FloorRubberMat",data.FloorRubberMat),
                        new SqlParameter("@Key",data.Key),
                        new SqlParameter("@FuelLevel",data.FuelLevel),
                        new SqlParameter("@SteelWheels",data.SteelWheels),
                        new SqlParameter("@Rake",data.Rake),
                        new SqlParameter("@MoreDetails",data.MoreDetails),
                        new SqlParameter("@EngineCondition",data.EngineCondition),
                        new SqlParameter("@EngineCondition_text",data.EngineCondition_text),
                        new SqlParameter("@BodyCondition",data.BodyCondition),
                        new SqlParameter("@ColorCondition",data.ColorCondition),
                        new SqlParameter("@DriveSystem",data.DriveSystem),
                        new SqlParameter("@DriveSystem_text",data.DriveSystem_text),
                        new SqlParameter("@TransmissionSystem",data.TransmissionSystem),
                        new SqlParameter("@TransmissionSystem_text",data.TransmissionSystem_text),
                        new SqlParameter("@BrakeSystem",data.BrakeSystem),
                        new SqlParameter("@BrakeSystem_text",data.BrakeSystem_text),
                        new SqlParameter("@ClutchSystem",data.ClutchSystem),
                        new SqlParameter("@ClutchSystem_text",data.ClutchSystem_text),
                        new SqlParameter("@SteeringSystem",data.SteeringSystem),
                        new SqlParameter("@SteeringSystem_text",data.SteeringSystem_text),
                        new SqlParameter("@HydraulicSystem",data.HydraulicSystem),
                        new SqlParameter("@HydraulicSystem_text",data.HydraulicSystem_text),
                        new SqlParameter("@Others",data.Others),
                        new SqlParameter("@Others_text",data.Others_text),
                        new SqlParameter("@TotalCondition",data.TotalCondition),
                        new SqlParameter("@EstimatePrice",data.EstimatePrice),
                        new SqlParameter("@Remark",data.Remark),
                        new SqlParameter("@IMATNumber",data.IMATNumber),
                        new SqlParameter("@ActionLocation",data.ActionLocation),
                        new SqlParameter("@ActionBy",data.ActionBy),
                        new SqlParameter("@ActionTime",actionTime),
                        };
                    #endregion Parameter

                    int Id = context.Database.SqlQuery<int>(INS_Query.Save_Excavator, Param.ToArray()).SingleOrDefault();
                    SaveInspectionImages(data.FrontImage, Id, data.IMATNumber, "FrontImage", "Excavator");
                    SaveInspectionImages(data.LeftImage, Id, data.IMATNumber, "LeftImage", "Excavator");
                    SaveInspectionImages(data.RearImage, Id, data.IMATNumber, "RearImage", "Excavator");
                    SaveInspectionImages(data.RightImage, Id, data.IMATNumber, "RightImage", "Excavator");
                    SaveInspectionImages(data.MileageImage, Id, data.IMATNumber, "MileageImage", "Excavator");
                    SaveInspectionImages(data.LicensePlateImage, Id, data.IMATNumber, "LicensePlateImage", "Excavator");
                    SaveInspectionImages(data.ChassisImage, Id, data.IMATNumber, "ChassisImage", "Excavator");
                    SaveInspectionImages(data.SeatImage, Id, data.IMATNumber, "SeatImage", "Excavator");
                    SaveInspectionImages(data.EngineImage, Id, data.IMATNumber, "EngineImage", "Excavator");
                    SaveInspectionImages(data.KeyImage, Id, data.IMATNumber, "KeyImage", "Excavator");
                    SaveInspectionImages(data.ToolboxImage, Id, data.IMATNumber, "ToolboxImage", "Excavator");
                    SaveInspectionImages(data.AttachedEquimentImage, Id, data.IMATNumber, "AttachedEquimentImage", "Excavator");
                    SaveInspectionImages(data.DamageImage, Id, data.IMATNumber, "DamageImage", "Excavator");
                }
                finally
                {
                    if (context.Database.Connection.State == ConnectionState.Open)
                    {
                        context.Database.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
                errorMessage = ex.Message;
            }
            return errorMessage;
        }
        #endregion

        #region SaveRicePlantingVehicle
        public string SaveRicePlantingVehicle(RicePlantingVehicleData data)
        {
            string errorMessage = "";
            try
            {
                DateTime actionTime = UnixTimeStampToDateTime(data.ActionUnixTime);

                var context = new INS_WEB_dataFeedContext();
                context.Database.CommandTimeout = 300000;
                try
                {
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter
                    var Param = new List<SqlParameter> {
                        new SqlParameter("@Battery",data.Battery),
                        new SqlParameter("@EngineCover",data.EngineCover),
                        new SqlParameter("@Wheels",data.Wheels),
                        new SqlParameter("@SteelWheels",data.SteelWheels),
                        new SqlParameter("@PlantingSpacingSystem",data.PlantingSpacingSystem),
                        new SqlParameter("@SeedlingTrayHolder",data.SeedlingTrayHolder),
                        new SqlParameter("@SeedlingTraySliderRails",data.SeedlingTraySliderRails),
                        new SqlParameter("@LineGuidanceRod",data.LineGuidanceRod),
                        new SqlParameter("@PlantingHead",data.PlantingHead),
                        new SqlParameter("@SeedlingSizeSelectorSystem",data.SeedlingSizeSelectorSystem),
                        new SqlParameter("@SeedlingPerClusterAdjustmentSystem",data.SeedlingPerClusterAdjustmentSystem),
                        new SqlParameter("@RicePlantingMechanism",data.RicePlantingMechanism),
                        new SqlParameter("@FloorRubberMat",data.FloorRubberMat),
                        new SqlParameter("@FuelLevel",data.FuelLevel),
                        new SqlParameter("@Headlights",data.Headlights),
                        new SqlParameter("@SeedlingTray",data.SeedlingTray),
                        new SqlParameter("@SeedlingDispenser",data.SeedlingDispenser),
                        new SqlParameter("@Key",data.Key),
                        new SqlParameter("@Rake",data.Rake),
                        new SqlParameter("@MoreDetails",data.MoreDetails),
                        new SqlParameter("@EngineCondition",data.EngineCondition),
                        new SqlParameter("@EngineCondition_text",data.EngineCondition_text),
                        new SqlParameter("@BodyCondition",data.BodyCondition),
                        new SqlParameter("@ColorCondition",data.ColorCondition),
                        new SqlParameter("@DriveSystem",data.DriveSystem),
                        new SqlParameter("@DriveSystem_text",data.DriveSystem_text),
                        new SqlParameter("@TransmissionSystem",data.TransmissionSystem),
                        new SqlParameter("@TransmissionSystem_text",data.TransmissionSystem_text),
                        new SqlParameter("@BrakeSystem",data.BrakeSystem),
                        new SqlParameter("@BrakeSystem_text",data.BrakeSystem_text),
                        new SqlParameter("@ClutchSystem",data.ClutchSystem),
                        new SqlParameter("@ClutchSystem_text",data.ClutchSystem_text),
                        new SqlParameter("@SteeringSystem",data.SteeringSystem),
                        new SqlParameter("@SteeringSystem_text",data.SteeringSystem_text),
                        new SqlParameter("@HydraulicSystem",data.HydraulicSystem),
                        new SqlParameter("@HydraulicSystem_text",data.HydraulicSystem_text),
                        new SqlParameter("@Others",data.Others),
                        new SqlParameter("@Others_text",data.Others_text),
                        new SqlParameter("@TotalCondition",data.TotalCondition),
                        new SqlParameter("@EstimatePrice",data.EstimatePrice),
                        new SqlParameter("@Remark",data.Remark),
                        new SqlParameter("@IMATNumber",data.IMATNumber),
                        new SqlParameter("@ActionLocation",data.ActionLocation),
                        new SqlParameter("@ActionBy",data.ActionBy),
                        new SqlParameter("@ActionTime",actionTime),
                        };
                    #endregion Parameter

                    int Id = context.Database.SqlQuery<int>(INS_Query.Save_RicePlantingVehicle, Param.ToArray()).SingleOrDefault();
                    SaveInspectionImages(data.FrontImage, Id, data.IMATNumber, "FrontImage", "RicePlantingVehicle");
                    SaveInspectionImages(data.LeftImage, Id, data.IMATNumber, "LeftImage", "RicePlantingVehicle");
                    SaveInspectionImages(data.RearImage, Id, data.IMATNumber, "RearImage", "RicePlantingVehicle");
                    SaveInspectionImages(data.RightImage, Id, data.IMATNumber, "RightImage", "RicePlantingVehicle");
                    SaveInspectionImages(data.MileageImage, Id, data.IMATNumber, "MileageImage", "RicePlantingVehicle");
                    SaveInspectionImages(data.LicensePlateImage, Id, data.IMATNumber, "LicensePlateImage", "RicePlantingVehicle");
                    SaveInspectionImages(data.ChassisImage, Id, data.IMATNumber, "ChassisImage", "RicePlantingVehicle");
                    SaveInspectionImages(data.SeatImage, Id, data.IMATNumber, "SeatImage", "RicePlantingVehicle");
                    SaveInspectionImages(data.EngineImage, Id, data.IMATNumber, "EngineImage", "RicePlantingVehicle");
                    SaveInspectionImages(data.KeyImage, Id, data.IMATNumber, "KeyImage", "RicePlantingVehicle");
                    SaveInspectionImages(data.ToolboxImage, Id, data.IMATNumber, "ToolboxImage", "RicePlantingVehicle");
                    SaveInspectionImages(data.AttachedEquimentImage, Id, data.IMATNumber, "AttachedEquimentImage", "RicePlantingVehicle");
                    SaveInspectionImages(data.DamageImage, Id, data.IMATNumber, "DamageImage", "RicePlantingVehicle");
                }
                finally
                {
                    if (context.Database.Connection.State == ConnectionState.Open)
                    {
                        context.Database.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
                errorMessage = ex.Message;
            }
            return errorMessage;
        }
        #endregion

        #region SaveStrawBaler
        public string SaveStrawBaler(StrawBalerData data)
        {
            string errorMessage = "";
            try
            {
                DateTime actionTime = UnixTimeStampToDateTime(data.ActionUnixTime);

                var context = new INS_WEB_dataFeedContext();
                context.Database.CommandTimeout = 300000;
                try
                {
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter
                    var Param = new List<SqlParameter> {
                        new SqlParameter("@FlywheelCover",data.FlywheelCover),
                        new SqlParameter("@StrawCuttingBlade",data.StrawCuttingBlade),
                        new SqlParameter("@Stand",data.Stand),
                        new SqlParameter("@Wheels",data.Wheels),
                        new SqlParameter("@Drawbar",data.Drawbar),
                        new SqlParameter("@StrawReceivingChannel",data.StrawReceivingChannel),
                        new SqlParameter("@UniversalJoint",data.UniversalJoint),
                        new SqlParameter("@UniversalJointSleeve",data.UniversalJointSleeve),
                        new SqlParameter("@StrawPickupFingers",data.StrawPickupFingers),
                        new SqlParameter("@FuelLevel",data.FuelLevel),
                        new SqlParameter("@SteelWheels",data.SteelWheels),
                        new SqlParameter("@Rake",data.Rake),
                        new SqlParameter("@MoreDetails",data.MoreDetails),
                        new SqlParameter("@EngineCondition",data.EngineCondition),
                        new SqlParameter("@EngineCondition_text",data.EngineCondition_text),
                        new SqlParameter("@BodyCondition",data.BodyCondition),
                        new SqlParameter("@ColorCondition",data.ColorCondition),
                        new SqlParameter("@DriveSystem",data.DriveSystem),
                        new SqlParameter("@DriveSystem_text",data.DriveSystem_text),
                        new SqlParameter("@TransmissionSystem",data.TransmissionSystem),
                        new SqlParameter("@TransmissionSystem_text",data.TransmissionSystem_text),
                        new SqlParameter("@BrakeSystem",data.BrakeSystem),
                        new SqlParameter("@BrakeSystem_text",data.BrakeSystem_text),
                        new SqlParameter("@ClutchSystem",data.ClutchSystem),
                        new SqlParameter("@ClutchSystem_text",data.ClutchSystem_text),
                        new SqlParameter("@SteeringSystem",data.SteeringSystem),
                        new SqlParameter("@SteeringSystem_text",data.SteeringSystem_text),
                        new SqlParameter("@HydraulicSystem",data.HydraulicSystem),
                        new SqlParameter("@HydraulicSystem_text",data.HydraulicSystem_text),
                        new SqlParameter("@Others",data.Others),
                        new SqlParameter("@Others_text",data.Others_text),
                        new SqlParameter("@TotalCondition",data.TotalCondition),
                        new SqlParameter("@EstimatePrice",data.EstimatePrice),
                        new SqlParameter("@Remark",data.Remark),
                        new SqlParameter("@IMATNumber",data.IMATNumber),
                        new SqlParameter("@ActionLocation",data.ActionLocation),
                        new SqlParameter("@ActionBy",data.ActionBy),
                        new SqlParameter("@ActionTime",actionTime),
                        };
                    #endregion Parameter

                    int Id = context.Database.SqlQuery<int>(INS_Query.Save_StrawBaler, Param.ToArray()).SingleOrDefault();
                    SaveInspectionImages(data.FrontImage, Id, data.IMATNumber, "FrontImage", "StrawBaler");
                    SaveInspectionImages(data.LeftImage, Id, data.IMATNumber, "LeftImage", "StrawBaler");
                    SaveInspectionImages(data.RearImage, Id, data.IMATNumber, "RearImage", "StrawBaler");
                    SaveInspectionImages(data.RightImage, Id, data.IMATNumber, "RightImage", "StrawBaler");
                    SaveInspectionImages(data.MileageImage, Id, data.IMATNumber, "MileageImage", "StrawBaler");
                    SaveInspectionImages(data.LicensePlateImage, Id, data.IMATNumber, "LicensePlateImage", "StrawBaler");
                    SaveInspectionImages(data.ChassisImage, Id, data.IMATNumber, "ChassisImage", "StrawBaler");
                    SaveInspectionImages(data.SeatImage, Id, data.IMATNumber, "SeatImage", "StrawBaler");
                    SaveInspectionImages(data.EngineImage, Id, data.IMATNumber, "EngineImage", "StrawBaler");
                    SaveInspectionImages(data.KeyImage, Id, data.IMATNumber, "KeyImage", "StrawBaler");
                    SaveInspectionImages(data.ToolboxImage, Id, data.IMATNumber, "ToolboxImage", "StrawBaler");
                    SaveInspectionImages(data.AttachedEquimentImage, Id, data.IMATNumber, "AttachedEquimentImage", "StrawBaler");
                    SaveInspectionImages(data.DamageImage, Id, data.IMATNumber, "DamageImage", "StrawBaler");
                }
                finally
                {
                    if (context.Database.Connection.State == ConnectionState.Open)
                    {
                        context.Database.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
                errorMessage = ex.Message;
            }
            return errorMessage;
        }
        #endregion

        #region SaveDieselEngine
        public string SaveDieselEngine(DieselEngineData data)
        {
            string errorMessage = "";
            try
            {
                DateTime actionTime = UnixTimeStampToDateTime(data.ActionUnixTime);

                var context = new INS_WEB_dataFeedContext();
                context.Database.CommandTimeout = 300000;
                try
                {
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter
                    var Param = new List<SqlParameter> {
                        new SqlParameter("@Toolbox",data.Toolbox),
                        new SqlParameter("@Battery",data.Battery),
                        new SqlParameter("@FuelLevel",data.FuelLevel),
                        new SqlParameter("@StarterMotor",data.StarterMotor),
                        new SqlParameter("@AirFilterHousing",data.AirFilterHousing),
                        new SqlParameter("@StarterCrankArm",data.StarterCrankArm),
                        new SqlParameter("@SteelWheels",data.SteelWheels),
                        new SqlParameter("@Rake",data.Rake),
                        new SqlParameter("@MoreDetails",data.MoreDetails),
                        new SqlParameter("@TotalCondition",data.TotalCondition),
                        new SqlParameter("@EstimatePrice",data.EstimatePrice),
                        new SqlParameter("@Remark",data.Remark),
                        new SqlParameter("@IMATNumber",data.IMATNumber),
                        new SqlParameter("@ActionLocation",data.ActionLocation),
                        new SqlParameter("@ActionBy",data.ActionBy),
                        new SqlParameter("@ActionTime",actionTime),
                        };
                    #endregion Parameter

                    int Id = context.Database.SqlQuery<int>(INS_Query.Save_DieselEngine, Param.ToArray()).SingleOrDefault();
                    SaveInspectionImages(data.FrontImage, Id, data.IMATNumber, "FrontImage", "DieselEngine");
                    SaveInspectionImages(data.LeftImage, Id, data.IMATNumber, "LeftImage", "DieselEngine");
                    SaveInspectionImages(data.RearImage, Id, data.IMATNumber, "RearImage", "DieselEngine");
                    SaveInspectionImages(data.RightImage, Id, data.IMATNumber, "RightImage", "DieselEngine");
                    SaveInspectionImages(data.MileageImage, Id, data.IMATNumber, "MileageImage", "DieselEngine");
                    SaveInspectionImages(data.LicensePlateImage, Id, data.IMATNumber, "LicensePlateImage", "DieselEngine");
                    SaveInspectionImages(data.ChassisImage, Id, data.IMATNumber, "ChassisImage", "DieselEngine");
                    SaveInspectionImages(data.SeatImage, Id, data.IMATNumber, "SeatImage", "DieselEngine");
                    SaveInspectionImages(data.EngineImage, Id, data.IMATNumber, "EngineImage", "DieselEngine");
                    SaveInspectionImages(data.KeyImage, Id, data.IMATNumber, "KeyImage", "DieselEngine");
                    SaveInspectionImages(data.ToolboxImage, Id, data.IMATNumber, "ToolboxImage", "DieselEngine");
                    SaveInspectionImages(data.AttachedEquimentImage, Id, data.IMATNumber, "AttachedEquimentImage", "DieselEngine");
                    SaveInspectionImages(data.DamageImage, Id, data.IMATNumber, "DamageImage", "DieselEngine");
                }
                finally
                {
                    if (context.Database.Connection.State == ConnectionState.Open)
                    {
                        context.Database.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
                errorMessage = ex.Message;
            }
            return errorMessage;
        }
        #endregion

        #region SaveDrone
        public string SaveDrone(DroneData data)
        {
            string errorMessage = "";
            try
            {
                DateTime actionTime = UnixTimeStampToDateTime(data.ActionUnixTime);

                var context = new INS_WEB_dataFeedContext();
                context.Database.CommandTimeout = 300000;
                try
                {
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter
                    var Param = new List<SqlParameter> {
                        new SqlParameter("@Fan",data.Fan),
                        new SqlParameter("@Battery",data.Battery),
                        new SqlParameter("@Charger",data.Charger),
                        new SqlParameter("@RemoteController",data.RemoteController),
                        new SqlParameter("@Cable",data.Cable),
                        new SqlParameter("@ControlLevers",data.ControlLevers),
                        new SqlParameter("@DigitalDashboard",data.DigitalDashboard),
                        new SqlParameter("@Covers",data.Covers),
                        new SqlParameter("@BatteryCondition",data.BatteryCondition),
                        new SqlParameter("@BatteryCondition_text",data.BatteryCondition_text),
                        new SqlParameter("@BodyCondition",data.BodyCondition),
                        new SqlParameter("@ColorCondition",data.ColorCondition),
                        new SqlParameter("@DriveSystem",data.DriveSystem),
                        new SqlParameter("@DriveSystem_text",data.DriveSystem_text),
                        new SqlParameter("@RemoteControllerSystem",data.RemoteControllerSystem),
                        new SqlParameter("@RemoteControllerSystem_text",data.RemoteControllerSystem_text),
                        new SqlParameter("@ChargingSystem",data.ChargingSystem),
                        new SqlParameter("@ChargingSystem_text",data.ChargingSystem_text),
                        new SqlParameter("@MoreDetails",data.MoreDetails),
                        new SqlParameter("@TotalCondition",data.TotalCondition),
                        new SqlParameter("@EstimatePrice",data.EstimatePrice),
                        new SqlParameter("@Remark",data.Remark),
                        new SqlParameter("@IMATNumber",data.IMATNumber),
                        new SqlParameter("@ActionLocation",data.ActionLocation),
                        new SqlParameter("@ActionBy",data.ActionBy),
                        new SqlParameter("@ActionTime",actionTime),
                        };
                    #endregion Parameter

                    int Id = context.Database.SqlQuery<int>(INS_Query.Save_Drone, Param.ToArray()).SingleOrDefault();
                    SaveInspectionImages(data.FrontImage, Id, data.IMATNumber, "FrontImage", "Drone");
                    SaveInspectionImages(data.LeftImage, Id, data.IMATNumber, "LeftImage", "Drone");
                    SaveInspectionImages(data.RearImage, Id, data.IMATNumber, "RearImage", "Drone");
                    SaveInspectionImages(data.RightImage, Id, data.IMATNumber, "RightImage", "Drone");
                    SaveInspectionImages(data.LicensePlateImage, Id, data.IMATNumber, "LicensePlateImage", "Drone");
                    SaveInspectionImages(data.AttachedEquimentImage, Id, data.IMATNumber, "AttachedEquimentImage", "Drone");
                    SaveInspectionImages(data.DamageImage, Id, data.IMATNumber, "DamageImage", "Drone");
                }
                finally
                {
                    if (context.Database.Connection.State == ConnectionState.Open)
                    {
                        context.Database.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
                errorMessage = ex.Message;
            }
            return errorMessage;
        }
        #endregion

        #region SaveBookIn
        public string SaveBookIn(BookInData data)
        {
            string errorMessage = "";
            try
            {
                DateTime actionTime = UnixTimeStampToDateTime(data.ActionUnixTime);
                DateTime regTime = UnixTimeStampToDateTime(data.RegistrationDate);
                string bookInNo = GetBookInCode(data.SellerNumber);

                var context = new INS_WEB_dataFeedContext();
                context.Database.CommandTimeout = 300000;
                try
                {
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter
                    var Param = new List<SqlParameter> {
                        new SqlParameter("@ContractNumber",data.ContractNumber),
                        new SqlParameter("@SellerName",data.SellerName),
                        new SqlParameter("@SellerRef",data.SellerRef),
                        new SqlParameter("@SellingCategory",data.SellingCategory),
                        new SqlParameter("@ClientName",data.ClientName),
                        new SqlParameter("@TenantName",data.TenantName),
                        new SqlParameter("@Body",data.Body),
                        new SqlParameter("@Model",data.Model),
                        new SqlParameter("@Variant",data.Variant),
                        new SqlParameter("@BuildYear",data.BuildYear),
                        new SqlParameter("@Color",data.Color),
                        new SqlParameter("@RegistrationDate",regTime),
                        new SqlParameter("@WorkHours",data.WorkHours),
                        new SqlParameter("@LicensePlateNumber",data.LicensePlateNumber),
                        new SqlParameter("@LicensePlateNumberCondition",data.LicensePlateNumberCondition),
                        new SqlParameter("@LicensePlateNumberCondition_text",data.LicensePlateNumberCondition_text),
                        new SqlParameter("@EngineNumber",data.EngineNumber),
                        new SqlParameter("@EngineNumberCondition",data.EngineNumberCondition),
                        new SqlParameter("@EngineNumberCondition_text",data.EngineNumberCondition_text),
                        new SqlParameter("@ChassisNumber",data.ChassisNumber),
                        new SqlParameter("@ChassisNumberCondition",data.ChassisNumberCondition),
                        new SqlParameter("@ChassisNumberCondition_text",data.ChassisNumberCondition_text),
                        new SqlParameter("@DroneNumber",data.DroneNumber),
                        new SqlParameter("@DroneNumberCondition",data.DroneNumberCondition),
                        new SqlParameter("@DroneNumberCondition_text",data.DroneNumberCondition_text),
                        new SqlParameter("@DroneRemoteNumber",data.DroneRemoteNumber),
                        new SqlParameter("@DroneRemoteNumberCondition",data.DroneRemoteNumberCondition),
                        new SqlParameter("@DroneRemoteNumberCondition_text",data.DroneRemoteNumberCondition_text),
                        new SqlParameter("@BookInNumber",bookInNo),
                        new SqlParameter("@IMATNumber",data.IMATNumber),
                        new SqlParameter("@ActionLocation",data.ActionLocation),
                        new SqlParameter("@ActionBy",data.ActionBy),
                        new SqlParameter("@ActionTime",actionTime),
                        };
                    #endregion Parameter

                    int Id = context.Database.SqlQuery<int>(INS_Query.Save_BookIn, Param.ToArray()).SingleOrDefault();
                    SaveInspectionImages(data.FrontImage, Id, bookInNo, "FrontImage", "BookIn");
                    SaveInspectionImages(data.LeftImage, Id, bookInNo, "LeftImage", "BookIn");
                    SaveInspectionImages(data.RearImage, Id, bookInNo, "RearImage", "BookIn");
                    SaveInspectionImages(data.RightImage, Id, bookInNo, "RightImage", "BookIn");
                }
                finally
                {
                    if (context.Database.Connection.State == ConnectionState.Open)
                    {
                        context.Database.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
                errorMessage = ex.Message;
            }
            return errorMessage;
        }

        protected string GetBookInCode(string sellerNo)
        {
            DataTable result = new DataTable();
            string BookInNo = "0001";
            string BookInDate = "";
            string BookInCode = "";
            string systemDate = DateTime.Now.ToString("yyyyMMdd");
            using (var context = new INS_WEB_dataFeedContext())
            {
                context.Database.CommandTimeout = 300000;
                if (context.Database.Connection.State == ConnectionState.Closed)
                {
                    context.Database.Connection.Open();
                }

                using (var command = context.Database.Connection.CreateCommand())
                {
                    command.CommandText = INS_Query.Get_LastestCreateBookInDate
                        .Replace("@ActionTime", systemDate);

                    using (var reader = command.ExecuteReader())
                    {
                        result.Load(reader);
                    }
                }
                if (result.Rows.Count > 0)
                {
                    BookInDate = result.Rows[0]["ActionTime"].ToString();
                }
                if ((systemDate.Trim()) == (BookInDate.Trim()))
                {
                    DataTable dtBatch = new DataTable();

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = INS_Query.Get_LastestBookInNo
                             .Replace("@ActionTime", systemDate);

                        using (var reader = command.ExecuteReader())
                        {
                            dtBatch.Load(reader);
                        }
                    }

                    if (dtBatch.Rows.Count > 0)
                    {
                        BookInNo = dtBatch.Rows[0]["BookInNumber"].ToString();

                        int aa = int.Parse(BookInNo) + 1;
                        BookInCode = BookInDate + sellerNo + aa.ToString("D4");
                    }
                    else
                    {
                        BookInCode = systemDate + sellerNo + BookInNo;
                    }
                }
                else
                {
                    BookInCode = systemDate + sellerNo + BookInNo;
                }
            }
            return BookInCode;
        }
        #endregion

        #region SaveInspectionImages
        public void SaveInspectionImages(string[] data, int inspectionId,string folderName, string imageType, string inspecType)
        {
            try
            {
                for (int i = 0; i < data.Length; i++)
                {
                    var context = new INS_WEB_dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    #region Parameter

                    string imageName = $"{imageType}_{i + 1}";
                    string imagePath = UploadImage(data[i], folderName, imageName, inspecType);

                    var detailParam = new List<SqlParameter> {
                            new SqlParameter("@InspectionType", inspecType),
                            new SqlParameter("@InspectionId", inspectionId),
                            new SqlParameter("@ImageName", imageName),
                            new SqlParameter("@ImagePath", imagePath),
                            new SqlParameter("@ImageType", imageType),
                        };

                    #endregion Parameter
                    context.Database.SqlQuery<int>(INS_Query.Save_InspectionImage, detailParam.ToArray()).SingleOrDefault();
                    if (context.Database.Connection.State == ConnectionState.Open)
                    {
                        context.Database.Connection.Close();
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

        #region UnixTimeStampToDateTime
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
        #endregion

        #region UploadImage
        private string UploadImage(string Photo, string newFolder, string imageName, string inspecType)
        {
            try
            {
                if (string.IsNullOrEmpty(Photo))
                {
                    return "";
                }
                else
                {
                    string base64Data = Photo.Substring(Photo.IndexOf(",") + 1);

                    byte[] imageBytes = Convert.FromBase64String(base64Data);

                    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string directoryPath = Path.Combine(baseDirectory, "Images", inspecType, newFolder);

                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    string fileName = $"{imageName}.jpg";

                    string filePath = Path.Combine(directoryPath, fileName);

                    System.IO.File.WriteAllBytes(filePath, imageBytes);

                    return $"/Images/{inspecType}/{newFolder}/{fileName}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving image: " + ex.Message);
                return "";
            }
        }
        #endregion

        #region GetBookInSheet
        public DataTable GetBookInSheet(string RefNumber)
        {
            DataTable result = new DataTable();
            try
            {
                using (var context = new INS_WEB_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = INS_Query.get_BookInSheet;
                        command.Parameters.Add(new SqlParameter("@RefKey", RefNumber));
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

        #region GetInspectionSheet
        public DataTable GetInspectionSheet(string RefNumber)
        {
            DataTable result = new DataTable();
            try
            {
                using (var context = new INS_WEB_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = INS_Query.get_InspectionSheet;
                        command.Parameters.Add(new SqlParameter("@RefKey", RefNumber));

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

        #region GenerateDataSheet
        public DataTable GenerateDataSheet(string RefNumber)
        {
            DataTable result = new DataTable();
            try
            {
                using (var context = new INS_WEB_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = INS_Query.get_GenerateDataSheet;
                        command.Parameters.Add(new SqlParameter("@RefKey", RefNumber));

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

        #region GetInspectionList
        public DataTable GetInspectionDataList()
        {
            DataTable result = new DataTable();
            try
            {
                using (var context = new INS_WEB_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = INS_Query.get_InspectionDataList;

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

    #region INS_Query
    public class INS_Query
    {
        public static string get_Body = "select Body,Desc_BU,Desc_LO from IMAP_Bodies";

        public static string get_BodyByCode = "select Body,Desc_BU,Desc_LO from IMAP_Bodies where Body=@code";

        public static string get_ContractType = "SELECT * FROM IMAP_ContractType";

        public static string get_SellingCategory = "select * from IMAP_SellingCategories";

        public static string get_SellingCategoryByCode = "select * from IMAP_SellingCategories where SellingCategory=@code";

        public static string get_Drive = "select * from ZILO.IMAP.dbo.Drives";

        public static string get_DriveByCode = "select * from ZILO.IMAP.dbo.Drives where Drive=@code";

        public static string get_FuelDelivery = "select * from ZILO.IMAP.dbo.FuelDeliveries";

        public static string get_FuelDeliveryByCode = "select * from ZILO.IMAP.dbo.FuelDeliveries where FuelDelivery=@code";

        public static string get_FuelType = "select * from ZILO.IMAP.dbo.FuelTypes";

        public static string get_FuelTypeByCode = "select * from ZILO.IMAP.dbo.FuelTypes where FuelType=@code";

        public static string get_Make = "select * from IMAP_Makes";

        public static string get_MakeByCode = "select * from IMAP_Makes where Make=@code";

        public static string get_MatVariant = "SELECT * FROM IMAP_View_Mat_Variant";

        public static string get_MatVariant_ByModel = "SELECT * FROM IMAP_View_Mat_Variant where Model_BU=@Model";

        public static string get_Seller = "SELECT Customer SellerCode,CompanyName_LO SellerNameTh,CompanyName_BU SellerNameEn FROM IMAP.dbo.Customers WHERE CustomerType = 'S'";

        public static string Save_RiceHarvester = @"INSERT INTO Inspection_RiceHarverster VALUES (@Tracks,@Rollers,@Blade,@ConveyorChain,@IdlerWheel,@ThreshingChamber,
                                                    @GrainStorageTank,@Battery,@Covers,@DriversSeat,@DustExtractionFan,
                                                    @Roof,@WorkerPlatform,@WorkerRearSupport,@Toolbox,@Key,@FuelLevel,
                                                    @Lights,@SeparatorGrateintheThreshingChamber,@RotaryPickerUnit,@CutterHead,@RiceThreshingSystem,@SteelWheels,
                                                    @Rake,@MoreDetails,@EngineCondition,@EngineCondition_text,@BodyCondition,@ColorCondition,@DriveSystem,@DriveSystem_text,
                                                    @TransmissionSystem,@TransmissionSystem_text,@BrakeSystem,@BrakeSystem_text,@ClutchSystem,@ClutchSystem_text,
                                                    @SteeringSystem,@SteeringSystem_text,@HydraulicSystem,@HydraulicSystem_text,@Others,@Others_text,
                                                    @TotalCondition,@EstimatePrice,@Remark,@IMATNumber,@ActionLocation,@ActionBy,@ActionTime); SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Save_Excavator = @"INSERT INTO Inspection_Excavator VALUES (@Tracks,@Rollers,@DozerBlade,@HydraulicHoses,@ControlLevers,@DigitalDashboard,
                                                    @Battery,@CoverPanels,@DriversSeat,@SafetyLock,
                                                    @Lights,@FloorRubberMat,@Key,@FuelLevel,@SteelWheels,
                                                    @Rake,@MoreDetails,@EngineCondition,@EngineCondition_text,@BodyCondition,@ColorCondition,@DriveSystem,@DriveSystem_text,
                                                    @TransmissionSystem,@TransmissionSystem_text,@BrakeSystem,@BrakeSystem_text,@ClutchSystem,@ClutchSystem_text,
                                                    @SteeringSystem,@SteeringSystem_text,@HydraulicSystem,@HydraulicSystem_text,@Others,@Others_text,
                                                    @TotalCondition,@EstimatePrice,@Remark,@IMATNumber,@ActionLocation,@ActionBy,@ActionTime); SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Save_RicePlantingVehicle = @"INSERT INTO Inspection_RicePlantingVehicle VALUES (@Battery,@EngineCover,@Wheels,@SteelWheels,@PlantingSpacingSystem,@SeedlingTrayHolder,
                                                    @SeedlingTraySliderRails,@LineGuidanceRod,@PlantingHead,@SeedlingSizeSelectorSystem,@SeedlingPerClusterAdjustmentSystem,
                                                    @RicePlantingMechanism,@FloorRubberMat,@FuelLevel,@Headlights,@SeedlingTray,@SeedlingDispenser,@Key,
                                                    @Rake,@MoreDetails,@EngineCondition,@EngineCondition_text,@BodyCondition,@ColorCondition,@DriveSystem,@DriveSystem_text,
                                                    @TransmissionSystem,@TransmissionSystem_text,@BrakeSystem,@BrakeSystem_text,@ClutchSystem,@ClutchSystem_text,
                                                    @SteeringSystem,@SteeringSystem_text,@HydraulicSystem,@HydraulicSystem_text,@Others,@Others_text,
                                                    @TotalCondition,@EstimatePrice,@Remark,@IMATNumber,@ActionLocation,@ActionBy,@ActionTime); SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Save_StrawBaler = @"INSERT INTO Inspection_StrawBaler VALUES (@FlywheelCover,@StrawCuttingBlade,@Stand,@Wheels,@Drawbar,@StrawReceivingChannel,
                                                    @UniversalJoint,@UniversalJointSleeve,@StrawPickupFingers,@FuelLevel,@SteelWheels,
                                                    @Rake,@MoreDetails,@EngineCondition,@EngineCondition_text,@BodyCondition,@ColorCondition,@DriveSystem,@DriveSystem_text,
                                                    @TransmissionSystem,@TransmissionSystem_text,@BrakeSystem,@BrakeSystem_text,@ClutchSystem,@ClutchSystem_text,
                                                    @SteeringSystem,@SteeringSystem_text,@HydraulicSystem,@HydraulicSystem_text,@Others,@Others_text,
                                                    @TotalCondition,@EstimatePrice,@Remark,@IMATNumber,@ActionLocation,@ActionBy,@ActionTime); SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Save_DieselEngine = @"INSERT INTO Inspection_DieselEngine VALUES (@Toolbox,@Battery,@FuelLevel,@StarterMotor,@AirFilterHousing,@StarterCrankArm,
                                                    @SteelWheels,@Rake,@MoreDetails,
                                                    @TotalCondition,@EstimatePrice,@Remark,@IMATNumber,@ActionLocation,@ActionBy,@ActionTime); SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Save_Drone = @"INSERT INTO Inspection_Drone VALUES (@Fan,@Battery,@Charger,@RemoteController,@Cable,@ControlLevers,@DigitalDashboard,
                                                    @Covers,@BatteryCondition,@BatteryCondition_text,@BodyCondition,@ColorCondition,@DriveSystem,@DriveSystem_text,
                                                    @RemoteControllerSystem,@RemoteControllerSystem_text,@ChargingSystem,@ChargingSystem_text,@MoreDetails,
                                                    @TotalCondition,@EstimatePrice,@Remark,@IMATNumber,@ActionLocation,@ActionBy,@ActionTime); SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Save_BookIn = @"INSERT INTO BookIn VALUES (@ContractNumber,@SellerName,@SellerRef,@SellingCategory,@ClientName,@TenantName,@Body,
                                                    @Model,@Variant,@BuildYear,@Color,@RegistrationDate,@WorkHours,@LicensePlateNumber,
                                                    @LicensePlateNumberCondition,@LicensePlateNumberCondition_text,@EngineNumber,@EngineNumberCondition,@EngineNumberCondition_text,
                                                    @ChassisNumber,@ChassisNumberCondition,@ChassisNumberCondition_text,
                                                    @DroneNumber,@DroneNumberCondition,@DroneNumberCondition_text,
                                                    @DroneRemoteNumber,@DroneRemoteNumberCondition,@DroneRemoteNumberCondition_text,@BookInNumber,@IMATNumber,@ActionLocation,
                                                    @ActionBy,@ActionTime); SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Save_InspectionImage = @"INSERT INTO InspectionImages VALUES (@InspectionType,@InspectionId,@ImageName,@ImagePath,@ImageType);
                                                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Get_LastestCreateBookInDate = @"select Top(1) FORMAT(ActionTime, 'yyyyMMdd') ActionTime from BookIn
                                                              where FORMAT(ActionTime, 'yyyyMMdd')=@ActionTime order by ActionTime desc";

        public static string Get_LastestBookInNo = @"select Top(1) substring(BookInNumber,19,4)BookInNumber from BookIn 
                                   where FORMAT(ActionTime, 'yyyyMMdd')=ActionTime
                                   order by BookInNumber desc";

        public static string get_RoofType = @"SELECT RoofTypeId,RTRIM(DescEn) AS DescEn,RTRIM(DescTh) AS DescTh FROM ZILO.Inspection.dbo.RoofType";

        public static string get_GasType = @"SELECT GasTypeId,RTRIM(DescEn) AS DescEn,RTRIM(DescTh) AS DescTh FROM ZILO.Inspection.dbo.GasType";

        public static string get_CatalyticOption = @"SELECT CatalyticOptionId,RTRIM(DescEn) AS DescEn,RTRIM(DescTh) AS DescTh FROM ZILO.Inspection.dbo.CatalyticOption";

        public static string get_WindowOption = @"SELECT WindowOptionId,RTRIM(DescEn) AS DescEn,RTRIM(DescTh) AS DescTh FROM ZILO.Inspection.dbo.WindowOption";

        public static string get_SteeringWheelType = @"SELECT Id,SteeringCode,RTRIM(DescEn) AS DescEn,RTRIM(DescTh) AS DescTh FROM ZILO.Inspection.dbo.SteeringWheelType";

        public static string get_PlateType = @"SELECT Id,PlateCode,RTRIM(DescEn) AS DescEn,RTRIM(DescTh) AS DescTh FROM ZILO.Inspection.dbo.PlateType";

        public static string get_CabinOverall = @"SELECT CabinOverAllId,RTRIM(DescEn) AS DescEn,RTRIM(DescTh) AS DescTh FROM ZILO.Inspection.dbo.CabinOverall";

        public static string get_CabinOverallById = @"SELECT CabinOverAllId,RTRIM(DescEn) AS DescEn,RTRIM(DescTh) AS DescTh FROM ZILO.Inspection.dbo.CabinOverall where CabinOverAllId=@id";

        public static string get_Colour = @"SELECT Colour,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO FROM ZILO.IMAP.dbo.Colours";

        public static string get_ColourByCode = @"SELECT Colour,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO FROM ZILO.IMAP.dbo.Colours where Colour=@code";

        public static string get_ColourSet = @"SELECT Cid,RTRIM(Colour_BU) AS Colour_BU,RTRIM(Colour_LO) AS Colour_LO FROM ZILO.IMAP.dbo.VehicleColoursSet";

        public static string get_ColourSetByCode = @"SELECT Cid,RTRIM(Colour_BU) AS Colour_BU,RTRIM(Colour_LO) AS Colour_LO FROM ZILO.IMAP.dbo.VehicleColoursSet where Cid=@code";

        public static string get_State = @"SELECT State,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO FROM ZILO.IMAP.dbo.States";

        public static string get_StateByCode = @"SELECT State,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO FROM ZILO.IMAP.dbo.States where State=@code";

        public static string get_Storage = @"SELECT * FROM ZILO.IMAP.dbo.StorageLocation";

        public static string get_StorageById = @"SELECT * FROM ZILO.IMAP.dbo.StorageLocation where LocationId=@id";

        public static string get_Plant = @"SELECT Plant,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO,msrepl_tran_version FROM ZILO.IMAP.dbo.Plants";

        public static string get_PlantByCode = @"SELECT Plant,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO,msrepl_tran_version FROM ZILO.IMAP.dbo.Plants where Plant=@code";

        public static string get_EngineCapacityUnit = @"SELECT EngineCapacityUnit,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO FROM ZILO.IMAP.dbo.EngineCapacityUnits";

        public static string get_EngineCapacityUnitByCode = @"SELECT EngineCapacityUnit,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO FROM ZILO.IMAP.dbo.EngineCapacityUnits where EngineCapacityUnit=@code";

        public static string get_GearBox = @"SELECT GearBox,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO FROM ZILO.IMAP.dbo.GearBoxes";

        public static string get_GearBoxByCode = @"SELECT GearBox,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO FROM ZILO.IMAP.dbo.GearBoxes where GearBox=@code";

        public static string get_Gear = @"SELECT Gears,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO FROM ZILO.IMAP.dbo.Gears";

        public static string get_GearByCode = @"SELECT Gears,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO FROM ZILO.IMAP.dbo.Gears where Gears=@code";

        public static string get_ModelTemplate = @"select ID, 
                                                    ModelCode, ModelCode + '-' + ModelDisplay + '-' + Variants ModelDisplay,
                                                    BuildYear,Model_BU,Model_LO,Variants,Description_BU,Description_LO, EngineCapacity,EngineCapacityUnit, FuelDelivery, FuelType,
                                                    GearBox,Gears,Drive,Make,Body,ChassisPreCode,CreateDate,CreateUser,CabTypeID,LevelCabID
                                                    from  ZILO.IMAP.dbo.ModelTemplates";

        public static string get_ModelTemplateByCode = @"select ID, 
                                                    ModelCode, ModelCode + '-' + ModelDisplay + '-' + Variants ModelDisplay,
                                                    BuildYear,Model_BU,Model_LO,Variants,Description_BU,Description_LO, EngineCapacity,EngineCapacityUnit, FuelDelivery, FuelType,
                                                    GearBox,Gears,Drive,Make,Body,ChassisPreCode,CreateDate,CreateUser,CabTypeID,LevelCabID
                                                    from  ZILO.IMAP.dbo.ModelTemplates where ModelCode=@code";

        public static string get_MakeByModelCode = @"SELECT Makes.Make,Desc_BU,Desc_LO
                                                            FROM
                                                            (SELECT DISTINCT Make FROM ZILO.IMAP.dbo.ModelTemplates WHERE ModelCode = @code) MC
                                                            LEFT JOIN ZILO.IMAP.dbo.Makes ON Makes.Make = MC.Make";

        public static string get_ModelTemplateByMake = @"SELECT DISTINCT ModelCode,Model_BU,Model_LO FROM ZILO.IMAP.dbo.ModelTemplates where Make=@code";

        public static string get_VariantByModelCode = @"select DISTINCT ID VarID,Variants from  ZILO.IMAP.dbo.ModelTemplates where ModelCode=@code";

        public static string get_EngineCapacityUnitByVarID = @"select DISTINCT ID VarID,EngineCapacity,EngineCapacityUnit from  ZILO.IMAP.dbo.ModelTemplates where ID=@id";

        public static string get_EngineCapacityByVarID = @"select DISTINCT ID VarID,EngineCapacity from  ZILO.IMAP.dbo.ModelTemplates where ID=@id";

        public static string get_FuelDeliveryByVarID = @"SELECT Data.ID VarID,FD.Desc_BU FuelDelivery_BU,FD.Desc_LO FuelDelivery_LO
                                                                FROM
                                                                (SELECT DISTINCT ID,FuelDelivery FROM ZILO.IMAP.dbo.ModelTemplates WHERE ID = @id) Data
                                                                LEFT JOIN ZILO.IMAP.dbo.FuelDeliveries FD ON Data.FuelDelivery = FD.FuelDelivery";

        public static string get_FuelTypeByVarID = @"SELECT Data.ID VarID,FT.Desc_BU Fuel_BU,FT.Desc_LO Fuel_LO
                                                                FROM
                                                                (SELECT DISTINCT ID,FuelType FROM ZILO.IMAP.dbo.ModelTemplates WHERE ID = @id) Data
                                                                LEFT JOIN ZILO.IMAP.dbo.FuelTypes FT ON Data.FuelType = FT.FuelType";

        public static string get_GearBoxByVarID = @"SELECT Data.ID VarID,GB.Desc_BU GearBox_BU,GB.Desc_LO GearBox_LO
                                                        FROM
                                                        (SELECT DISTINCT ID,Gearbox FROM ZILO.IMAP.dbo.ModelTemplates WHERE ID = @id) Data
                                                        LEFT JOIN ZILO.IMAP.dbo.GearBoxes GB ON Data.Gearbox = GB.GearBox";

        public static string get_GearByVarID = @"SELECT Data.ID VarID,G.Desc_BU Gears_BU,G.Desc_LO Gears_LO
                                                        FROM
                                                        (SELECT DISTINCT ID,Gears FROM ZILO.IMAP.dbo.ModelTemplates WHERE ID = @id) Data
                                                        LEFT JOIN ZILO.IMAP.dbo.Gears G ON Data.Gears = G.Gears";

        public static string get_BodyByVarID = @"SELECT Data.ID VarID,B.Desc_BU Body_BU,B.Desc_LO Body_LO
                                                        FROM
                                                        (SELECT DISTINCT ID,Body FROM ZILO.IMAP.dbo.ModelTemplates WHERE ID = @id) Data
                                                        LEFT JOIN ZILO.IMAP.dbo.Bodies B ON Data.Body = B.Body";

        public static string get_MatModel = @"select * from  ZILO.IMAP.dbo.View_Mat_Model";

        public static string get_CabType = @"SELECT RTRIM(CabTypeID) AS CabTypeID,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO FROM ZILO.IMAP.dbo.CabType";

        public static string get_LevelCab = @"SELECT RTRIM(levelCabID) AS levelCabID,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO FROM ZILO.IMAP.dbo.levelCabs";

        public static string get_VehicleColoursSet = @"SELECT Cid,Colour_BU,Colour_LO FROM ZILO.IMAP.dbo.VehicleColoursSet ";

        public static string get_BookInSheet = @"SELECT TOP 1 ID,RefKey,TxnDate,SchemaName,SchemaInfo,InspectionData,SenderName,Receivername,MobileNumber,SellerCode,InspectorID,Inspector, 
                                                VehicleId,ChasisNumber,VIN,RegistrationNumber,CreatedBy,CreatedDate
                                                FROM [dbo].[INNO_SYNC] WHERE SchemaName LIKE '%bookin%' AND RefKey = @RefKey ORDER BY ID DESC";

        public static string get_InspectionSheet = @"SELECT TOP 1 ID,RefKey,TxnDate,SchemaName,SchemaInfo,InspectionData,SenderName,Receivername,MobileNumber,SellerCode,InspectorID,Inspector, 
                                                VehicleId,ChasisNumber,VIN,RegistrationNumber,CreatedBy,CreatedDate
                                                FROM [dbo].[INNO_SYNC] WHERE SchemaName LIKE '%inspection%' AND RefKey = @RefKey ORDER BY ID DESC";

        public static string get_InspectionDataList = "SELECT ID,RefKey,TxnDate,Schemaname,Sendername,ReceiverName,MobileNumber,SellerCode,Inspector,VehicleId,ChasisNumber,VIN,RegistrationNumber,CreatedBy,CreatedDate, " +
                                                    "(CASE WHEN SCHEMANAME LIKE  '%inspection%' THEN 'Inspection' WHEN SCHEMANAME LIKE  '%bookin%' THEN 'Book In' ELSE '' END) SchemaType " +
                                                    "FROM InspectionWeb.dbo.INNO_SYNC";
        public static string get_GenerateDataSheet = @"SELECT TOP 1 ID,RefKey,TxnDate,SchemaName,SchemaInfo,InspectionData,SenderName,Receivername,MobileNumber,SellerCode,InspectorID,Inspector, 
                                                        VehicleId,ChasisNumber,VIN,RegistrationNumber,CreatedBy,CreatedDate,
                                                        (CASE WHEN SCHEMANAME LIKE  '%inspection%' THEN 'Inspection' WHEN SCHEMANAME LIKE  '%bookin%' THEN 'Book In' ELSE '' END) SchemaType,
                                                        (CASE WHEN SCHEMANAME LIKE  '%Motor%' THEN 'Motorbike' WHEN SCHEMANAME LIKE  '%car%' THEN 'Car' ELSE '' END) SchemaVehicle
                                                        FROM [dbo].[INNO_SYNC] WHERE RefKey = @RefKey ORDER BY ID DESC";
    }
    #endregion
}
