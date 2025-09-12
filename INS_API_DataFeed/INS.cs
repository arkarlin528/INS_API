using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
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

        #region GetSellerByCode
        public DataTable GetSellerByCode(string code)
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
                        command.CommandText = INS_Query.get_SellerByCode;

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

        #region GetPlantByStorageLocation
        public DataTable GetPlantByStorageLocation(string location)
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
                        command.CommandText = INS_Query.get_PlantByStorageLocation;

                        command.Parameters.Add(new SqlParameter("@Location", location));

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

        #region GetModelTemplateById
        public DataTable GetModelTemplateById(int id)
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
                        command.CommandText = INS_Query.get_ModelTemplateById;

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

        #region GetModelTemplateForDataEntryByVarId
        public DataTable GetModelTemplateForDataEntryByVarId(int id)
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
                        command.CommandText = INS_Query.get_ModelTemplate_ForDataEntry_ByVarId;

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

        #region GetInspectionCatalog
        public DataTable GetInspectionCatalog(string imapNo)
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
                    if (long.TryParse(imapNo, out long number))
                    {
                        imapNo = number.ToString("D18"); 
                    }
                    else
                    {
                        imapNo = imapNo.PadLeft(18, '0'); 
                    }
                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = INS_Query.get_InspectionCatalog;

                        command.Parameters.Add(new SqlParameter("@imapNo", imapNo));

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

        #region SaveInspectionCatlog_Log
        public string SaveInspectionCatlog_Log(string message, string imapNo)
        {
            string errorMessage = "";

            try
            {
                using (var context = new INS_WEB_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;

                    if (context.Database.Connection.State == ConnectionState.Closed)
                        context.Database.Connection.Open();

                    var param = new List<SqlParameter>
            {
                new SqlParameter("@ResponseMessage", message),
                new SqlParameter("@ImapNo", imapNo),
                new SqlParameter("@LogDateTime", DateTime.Now),
            };

                  context.Database.ExecuteSqlCommand(INS_Query.Save_InspectionCatlog_Log, param.ToArray());
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

        #region CreateBookinNumber
        public List<string> CreateBookinNumber()
        {
            var result = new List<string>();

            try
            {
                using (var context = new Inspection_dataFeedContext())
                {
                    var connection = context.Database.Connection;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "CreateBookinNumber";
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(reader[0].ToString());
                            }
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

        #region GetNextVehicleNumber
        public string GetNextVehicleNumber()
        {
            string result = "";

            try
            {
                using (var context = new IMAT_dataFeedContext())
                {
                    var connection = context.Database.Connection;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "NextVehicle";
                        command.CommandType = CommandType.StoredProcedure;

                        var outputParam = new SqlParameter("@NextNumber", SqlDbType.Char, 18)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(outputParam);

                        command.ExecuteNonQuery();

                        result = outputParam.Value?.ToString();
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

        #region UpdateVehicleOnCreate
        public string UpdateVehicleOnCreate(string bookinNo, string vehicleId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Inspection_dataFeedContext())
                {
                    var connection = context.Database.Connection;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "dbo.UpdateVehicleOnCreate";
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        var param1 = command.CreateParameter();
                        param1.ParameterName = "@bookinNumber";
                        param1.DbType = DbType.String;
                        param1.Size = 10;
                        param1.Value = bookinNo;
                        command.Parameters.Add(param1);

                        var param2 = command.CreateParameter();
                        param2.ParameterName = "@vehicleId";
                        param2.DbType = DbType.String;
                        param2.Size = 18;
                        param2.Value = vehicleId;
                        command.Parameters.Add(param2);

                        command.ExecuteNonQuery(); // Execute the stored procedure
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
                errorMessage= ex.Message;
            }
            return errorMessage;
        }
        #endregion

        #region UpdateVehicleOnUpdate
        public string UpdateVehicleOnUpdate(string bookinNo, string vehicleId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Inspection_dataFeedContext())
                {
                    var connection = context.Database.Connection;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "dbo.UpdateVehicleOnUpdate";
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        var param1 = command.CreateParameter();
                        param1.ParameterName = "@bookinNumber";
                        param1.Value = bookinNo;
                        param1.DbType = DbType.StringFixedLength;
                        param1.Size = 10;
                        command.Parameters.Add(param1);

                        var param2 = command.CreateParameter();
                        param2.ParameterName = "@vehicleId";
                        param2.Value = vehicleId;
                        param2.DbType = DbType.StringFixedLength;
                        param2.Size = 18;
                        command.Parameters.Add(param2);

                        // Execute the procedure
                        command.ExecuteNonQuery();
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

        #region AddBookIn
        public string AddBookIn(BookIn bookIn)
        {
            string errorMessage = "";

            try
            {
                using (var context = new Inspection_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;

                    if (context.Database.Connection.State == ConnectionState.Closed)
                        context.Database.Connection.Open();

                    var param = new List<SqlParameter>
            {
                new SqlParameter("@BookInNumber", bookIn.BookInNumber),
                new SqlParameter("@BookInDate", bookIn.BookInDate),
                new SqlParameter("@SenderName", bookIn.SenderName),
                new SqlParameter("@ReceiverName", bookIn.ReceiverName),
                new SqlParameter("@ContractNumber", bookIn.ContractNumber),
                new SqlParameter("@MobileNumber", bookIn.MobileNumber),
                new SqlParameter("@Status", bookIn.Status),
                new SqlParameter("@SellerCode", bookIn.SellerCode),
                new SqlParameter("@Inspector", bookIn.Inspector),
                new SqlParameter("@VehicleId", bookIn.VehicleId),
                new SqlParameter("@SenderSignature", bookIn.SenderSignature),
                new SqlParameter("@ReceiverSignature", bookIn.ReceiverSignature),
                new SqlParameter("@LatestUpdatedDate", bookIn.LatestUpdatedDate),
                new SqlParameter("@BookinType", bookIn.BookinType),
                new SqlParameter("@CreateBy", bookIn.CreateBy),
                new SqlParameter("@CreateDate", bookIn.CreateDate),
                new SqlParameter("@ContractTypeCode", bookIn.ContractTypeCode),
                new SqlParameter("@StickVin", bookIn.StickVin),
                new SqlParameter("@TenantName", bookIn.TenantName),
                new SqlParameter("@TimeStartApp", bookIn.TimeStartApp)
                , 
            };

                    int insertedId = context.Database.SqlQuery<int>(INS_Query.Add_BookIn, param.ToArray()).SingleOrDefault();
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

        #region AddVehicle
        public string AddVehicle(Vehicle vehicle)
        {
            string errorMessage = "";

            try
            {
                using (var context = new Inspection_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;

                    if (context.Database.Connection.State == ConnectionState.Closed)
                        context.Database.Connection.Open();

                    var param = new List<SqlParameter>
            {
                new SqlParameter("@BookinNumber", vehicle.BookinNumber),
                new SqlParameter("@Seller", vehicle.Seller),
                new SqlParameter("@SellingCategory", vehicle.SellingCategory),
                new SqlParameter("@LogisticsStatus", vehicle.LogisticsStatus),
                new SqlParameter("@InspectionDate", vehicle.InspectionDate),
                new SqlParameter("@SalesStatus", vehicle.SalesStatus),
                new SqlParameter("@Plant", vehicle.Plant),
                new SqlParameter("@StorageLocation", vehicle.StorageLocation),
                new SqlParameter("@ReceiverLocation", vehicle.ReceiverLocation),
                new SqlParameter("@BookedDate", vehicle.BookedDate),
                new SqlParameter("@Make", vehicle.Make),
                new SqlParameter("@Make_BU", vehicle.Make_BU),
                new SqlParameter("@Make_LO", vehicle.Make_LO),
                new SqlParameter("@ModelCode", vehicle.ModelCode),
                new SqlParameter("@ModelCodeId", vehicle.ModelCodeId),
                new SqlParameter("@Model_BU", vehicle.Model_BU),
                new SqlParameter("@Model_LO", vehicle.Model_LO),
                new SqlParameter("@Body", vehicle.Body),
                new SqlParameter("@BodyDesc_BU", vehicle.BodyDesc_BU),
                new SqlParameter("@BodyDesc_LO", vehicle.BodyDesc_LO),
                new SqlParameter("@Variants", vehicle.Variants),
                new SqlParameter("@BuildYear", vehicle.BuildYear),
                new SqlParameter("@VIN", vehicle.VIN),
                new SqlParameter("@ChasisNumber", vehicle.ChasisNumber),
                new SqlParameter("@Colour", vehicle.Colour),
                new SqlParameter("@ColourDesc", vehicle.ColourDesc),
                new SqlParameter("@FuelDelivery", vehicle.FuelDelivery),
                new SqlParameter("@FuelType", vehicle.FuelType),
                new SqlParameter("@Gearbox", vehicle.Gearbox),
                new SqlParameter("@Gears", vehicle.Gears),
                new SqlParameter("@Drive", vehicle.Drive),
                new SqlParameter("@EngineNumber", vehicle.EngineNumber),
                new SqlParameter("@EngineCapacity", vehicle.EngineCapacity),
                new SqlParameter("@EngineCapacityUnit", vehicle.EngineCapacityUnit),
                new SqlParameter("@Regisration", vehicle.Regisration),
                new SqlParameter("@RegistrationYear", vehicle.RegistrationYear),
                new SqlParameter("@RegistrationProvince", vehicle.RegistrationProvince),
                new SqlParameter("@RegistrationPlate", vehicle.RegistrationPlate),
                new SqlParameter("@RegistrationNote", vehicle.RegistrationNote),
                new SqlParameter("@IsRegistrationMismatch", vehicle.IsRegistrationMismatch),
                new SqlParameter("@RedBookCondition", vehicle.RedBookCondition),
                new SqlParameter("@IsGasTank", vehicle.IsGasTank),
                new SqlParameter("@GasType", vehicle.GasType),
                new SqlParameter("@GasTankNumber", vehicle.GasTankNumber),
                new SqlParameter("@GasNote", vehicle.GasNote),
                new SqlParameter("@IsInValidEngineNumber", vehicle.IsInValidEngineNumber),
                new SqlParameter("@ReasonInValidEngineNumber", vehicle.ReasonInValidEngineNumber),
                new SqlParameter("@IsInValidGasNumber", vehicle.IsInValidGasNumber),
                new SqlParameter("@ReasonInValidGasNumber", vehicle.ReasonInValidGasNumber),
                new SqlParameter("@IsInValidVinNumber", vehicle.IsInValidVinNumber),
                new SqlParameter("@ReasonInValidVinNumber", vehicle.ReasonInValidVinNumber),
                new SqlParameter("@IsNohaveBuildYear", vehicle.IsNohaveBuildYear),
                new SqlParameter("@IsNohaveRegis", vehicle.IsNohaveRegis),
                new SqlParameter("@briefCarConditionId", vehicle.briefCarConditionId),
                new SqlParameter("@DetallBriefCarCondition", vehicle.DetallBriefCarCondition),
                new SqlParameter("@MotorNumber", vehicle.MotorNumber),
                new SqlParameter("@IsInValidMotorNumber", vehicle.IsInValidMotorNumber),
                new SqlParameter("@ReasonInValidMotorNumber", vehicle.ReasonInValidMotorNumber),
                new SqlParameter("@IsInVaidEngine1", vehicle.IsInVaidEngine1),
                new SqlParameter("@IsInVaidEngine2", vehicle.IsInVaidEngine2),
                new SqlParameter("@IsInVaidEngine3", vehicle.IsInVaidEngine3),
                new SqlParameter("@IsInVaidVin1", vehicle.IsInVaidVin1),
                new SqlParameter("@IsInVaidVin2", vehicle.IsInVaidVin2),
                new SqlParameter("@IsInVaidVin3", vehicle.IsInVaidVin3),
                new SqlParameter("@NoPlateType", vehicle.NoPlateType),
                new SqlParameter("@CatalyticOption", vehicle.CatalyticOption),
                new SqlParameter("@CabTypeID", vehicle.CabTypeID),
                new SqlParameter("@LevelCabID", vehicle.LevelCabID)
            };

                    int insertedId = context.Database.SqlQuery<int>(INS_Query.Add_Vehicle, param.ToArray()).SingleOrDefault();
                  
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

        #region AddExternal
        public string AddExternal(External external)
        {
            string errorMessage = "";

            try
            {
                using (var context = new Inspection_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;

                    if (context.Database.Connection.State == ConnectionState.Closed)
                        context.Database.Connection.Open();

                    var param = new List<SqlParameter>
                    {
                        new SqlParameter("@GradeOverallId", (object)external.GradeOverallId ?? DBNull.Value),
                        new SqlParameter("@ColorOverallId", (object)external.ColorOverallId ?? DBNull.Value),
                        new SqlParameter("@IsSpoiler", (object)external.IsSpoiler ?? DBNull.Value),
                        new SqlParameter("@MagWheel", (object)external.MagWheel ?? DBNull.Value),
                        new SqlParameter("@NormalWheel", (object)external.NormalWheel ?? DBNull.Value),
                        new SqlParameter("@IsTyre", (object)external.IsTyre ?? DBNull.Value),
                        new SqlParameter("@TyreQuality", (object)external.TyreQuality ?? DBNull.Value),
                        new SqlParameter("@DamageDesc", (object)(external.DamageDesc ?? string.Empty)),
                        new SqlParameter("@BookinNumber", external.BookinNumber ?? string.Empty),
                        new SqlParameter("@TyreBrand", (object)(external.TyreBrand ?? string.Empty)),
                        new SqlParameter("@RoofTypeId", (object)external.RoofTypeId ?? DBNull.Value),
                    };

                    int insertedId = context.Database.SqlQuery<int>(INS_Query.Add_External, param.ToArray()).SingleOrDefault();
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

        #region AddSpare
        public string AddSpare(Spare spare)
        {
            string errorMessage = "";

            try
            {
                using (var context = new Inspection_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;

                    if (context.Database.Connection.State == ConnectionState.Closed)
                        context.Database.Connection.Open();

                    var param = new List<SqlParameter>
            {
                new SqlParameter("@SpareOverAllId", (object)spare.SpareOverAllId ?? DBNull.Value),
                new SqlParameter("@SpareNote", (object)(spare.SpareNote ?? string.Empty)),
                new SqlParameter("@IsSpareType", (object)spare.IsSpareType ?? DBNull.Value),
                new SqlParameter("@IsHandTool", (object)spare.IsHandTool ?? DBNull.Value),
                new SqlParameter("@IsMaxliner", (object)spare.IsMaxliner ?? DBNull.Value),
                new SqlParameter("@IsRoofRack", (object)spare.IsRoofRack ?? DBNull.Value),
                new SqlParameter("@IsJackCar", (object)spare.IsJackCar ?? DBNull.Value),
                new SqlParameter("@IsCableChargeEV", (object)spare.IsCableChargeEV ?? DBNull.Value),
                new SqlParameter("@AccessoriesNote", (object)(spare.AccessoriesNote ?? string.Empty)),
                new SqlParameter("@BookinNumber", spare.BookinNumber ?? string.Empty)
            };

                    int insertedId = context.Database.SqlQuery<int>(INS_Query.Add_Spare, param.ToArray()).SingleOrDefault();
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

        #region AddCabin
        public string AddCabin(Cabin cabin)
        {
            string errorMessage = "";

            try
            {
                using (var context = new Inspection_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;

                    if (context.Database.Connection.State == ConnectionState.Closed)
                        context.Database.Connection.Open();

                    var param = new List<SqlParameter>
            {
                new SqlParameter("@CabinOverAllId", cabin.CabinOverAllId),
                new SqlParameter("@Mileage", (object)cabin.Mileage ?? DBNull.Value),
                new SqlParameter("@MileageTypeId", (object)cabin.MileageTypeId ?? DBNull.Value),
                new SqlParameter("@FuelVolumn", (object)cabin.FuelVolumn ?? DBNull.Value),
                new SqlParameter("@GearSystemId", (object)cabin.GearSystemId ?? DBNull.Value),
                new SqlParameter("@IsAirback", (object)cabin.IsAirback ?? DBNull.Value),
                new SqlParameter("@IsHeadGear", (object)cabin.IsHeadGear ?? DBNull.Value),
                new SqlParameter("@IsPowerAmp", (object)cabin.IsPowerAmp ?? DBNull.Value),
                new SqlParameter("@IsLockGear", (object)cabin.IsLockGear ?? DBNull.Value),
                new SqlParameter("@IsPreAmp", (object)cabin.IsPreAmp ?? DBNull.Value),
                new SqlParameter("@IsBookService", (object)cabin.IsBookService ?? DBNull.Value),
                new SqlParameter("@IsSpeaker", (object)cabin.IsSpeaker ?? DBNull.Value),
                new SqlParameter("@IsManual", (object)cabin.IsManual ?? DBNull.Value),
                new SqlParameter("@IsCigaretteLiter", (object)cabin.IsCigaretteLiter ?? DBNull.Value),
                new SqlParameter("@IsTaxPlate", (object)cabin.IsTaxPlate ?? DBNull.Value),
                new SqlParameter("@IsPlateExpireDate", (object)(cabin.IsPlateExpireDate ?? string.Empty)),
                new SqlParameter("@IsNavigator", (object)cabin.IsNavigator ?? DBNull.Value),
                new SqlParameter("@IsNavigatorBuiltin", (object)cabin.IsNavigatorBuiltin ?? DBNull.Value),
                new SqlParameter("@IsNavigatorCD", (object)cabin.IsNavigatorCD ?? DBNull.Value),
                new SqlParameter("@IsNavigatorSDCard", (object)cabin.IsNavigatorSDCard ?? DBNull.Value),
                new SqlParameter("@IsNavigatorNoCD", (object)cabin.IsNavigatorNoCD ?? DBNull.Value),
                new SqlParameter("@IsNavigatorNoSDCard", (object)cabin.IsNavigatorNoSDCard ?? DBNull.Value),
                new SqlParameter("@PlayerBrand", (object)(cabin.PlayerBrand ?? string.Empty)),
                new SqlParameter("@IsPlayerRadio", (object)cabin.IsPlayerRadio ?? DBNull.Value),
                new SqlParameter("@IsPlayerTape", (object)cabin.IsPlayerTape ?? DBNull.Value),
                new SqlParameter("@IsPlayerCD", (object)cabin.IsPlayerCD ?? DBNull.Value),
                new SqlParameter("@IsPlayerUSB", (object)cabin.IsPlayerUSB ?? DBNull.Value),
                new SqlParameter("@KeyOptionId", (object)cabin.KeyOptionId ?? DBNull.Value),
                new SqlParameter("@CabinNote", (object)(cabin.CabinNote ?? string.Empty)),
                new SqlParameter("@BookInNumber", cabin.BookInNumber ?? string.Empty),
                new SqlParameter("@IsInvalidMileage", (object)cabin.IsInvalidMileage ?? DBNull.Value),
                new SqlParameter("@InvalidMileageReason", (object)(cabin.InvalidMileageReason ?? string.Empty))
            };

                    int insertedId = context.Database.SqlQuery<int>(INS_Query.Add_Cabin, param.ToArray()).SingleOrDefault();
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

        #region AddKeyOption
        public string AddKeyOption(KeyOption keyOption)
        {
            string errorMessage = "";

            try
            {
                using (var context = new Inspection_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;

                    if (context.Database.Connection.State == ConnectionState.Closed)
                        context.Database.Connection.Open();

                    var param = new List<SqlParameter>
            {
                new SqlParameter("@NumberOfKey", (object)keyOption.NumberOfKey ?? DBNull.Value),
                new SqlParameter("@NumberOfRemote", (object)keyOption.NumberOfRemote ?? DBNull.Value),
                new SqlParameter("@NumberOfKeyRemote", (object)keyOption.NumberOfKeyRemote ?? DBNull.Value),
                new SqlParameter("@NumberOfImmobilizer", (object)keyOption.NumberOfImmobilizer ?? DBNull.Value),
                new SqlParameter("@NumberOfKeyless", (object)keyOption.NumberOfKeyless ?? DBNull.Value),
                new SqlParameter("@BookinNumber", keyOption.BookinNumber ?? string.Empty)
            };

                    int insertedId = context.Database.SqlQuery<int>(INS_Query.Add_KeyOption, param.ToArray()).SingleOrDefault();
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

        #region AddEngine
        public string AddEngine(Engine engine)
        {
            string errorMessage = "";

            try
            {
                using (var context = new Inspection_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;

                    if (context.Database.Connection.State == ConnectionState.Closed)
                        context.Database.Connection.Open();

                    var param = new List<SqlParameter>
            {
                new SqlParameter("@EngineRoomOverAllId", (object)engine.EngineRoomOverAllId ?? DBNull.Value),
                new SqlParameter("@BatteryBrand", engine.BatteryBrand ?? string.Empty),
                new SqlParameter("@BatteryIndicatorColor", engine.BatteryIndicatorColor ?? string.Empty),
                new SqlParameter("@IsEcu", (object)engine.IsEcu ?? DBNull.Value),
                new SqlParameter("@IsCompressorAir", (object)engine.IsCompressorAir ?? DBNull.Value),
                new SqlParameter("@DriverSystemId", (object)engine.DriverSystemId ?? DBNull.Value),
                new SqlParameter("@FuelSystemId", (object)engine.FuelSystemId ?? DBNull.Value),
                new SqlParameter("@IsFuelGas", (object)engine.IsFuelGas ?? DBNull.Value),
                new SqlParameter("@GasTypeId", (object)engine.GasTypeId ?? DBNull.Value),
                new SqlParameter("@InsideAssetNote", engine.InsideAssetNote ?? string.Empty),
                new SqlParameter("@BookinNumber", engine.BookinNumber ?? string.Empty),
                //new SqlParameter("@CatalyticOption", (object)engine.CatalyticOption ?? DBNull.Value)
            };

                    int insertedId = context.Database.SqlQuery<int>(INS_Query.Add_Engine, param.ToArray()).SingleOrDefault();
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

        #region AddCarInspection
        public string AddCarInspection(CarInspection carInspection)
        {
            string errorMessage = "";

            try
            {
                using (var context = new Inspection_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                        context.Database.Connection.Open();
                    var param = new List<SqlParameter>
            {
                //new SqlParameter("@InspectionId",carInspection.InspectionId),
                new SqlParameter("@BookInNumber", carInspection.BookInNumber),
                new SqlParameter("@VehicleId",carInspection.VehicleId),
                new SqlParameter("@Inspector", carInspection.Inspector),
                new SqlParameter("@InspectionDate",carInspection.InspectionDate),
                new SqlParameter("@InspectorName", carInspection.InspectorName),
                new SqlParameter("@Chassis", carInspection.Chassis),
                new SqlParameter("@Front", carInspection.Front),
                new SqlParameter("@Back", carInspection.Back),
                new SqlParameter("@RightSide", carInspection.RightSide),
                new SqlParameter("@LeftSide", carInspection.LeftSide),
                new SqlParameter("@Roof", carInspection.Roof),
                new SqlParameter("@IsFlood",carInspection.IsFlood),
                new SqlParameter("@BodySummary", carInspection.BodySummary),
                new SqlParameter("@IsEngineWorks",carInspection.IsEngineWorks),
                new SqlParameter("@FuelSystemId",carInspection.FuelSystemId),
                new SqlParameter("@IsLubricatorLow",carInspection.IsLubricatorLow),
                new SqlParameter("@EngineSystemId",carInspection.EngineSystemId),
                new SqlParameter("@GearTypeId",carInspection.GearTypeId),
                new SqlParameter("@IsUseableGeneral",carInspection.IsUseableGeneral),
                new SqlParameter("@IsSoundAbnormal",carInspection.IsSoundAbnormal),
                new SqlParameter("@IsLeakFuel",carInspection.IsLeakFuel),
                new SqlParameter("@IsStainWater",carInspection.IsStainWater),
                new SqlParameter("@IsMachineLightShow",carInspection.IsMachineLightShow),
                new SqlParameter("@IsEngineAbnomal",carInspection.IsEngineAbnomal),
                new SqlParameter("@IsNeedRepair",carInspection.IsNeedRepair),
                new SqlParameter("@EngineSummary", carInspection.EngineSummary),
                new SqlParameter("@DriveShaftConditionId",carInspection.DriveShaftConditionId),
                new SqlParameter("@DriveShaftConditionNote", carInspection.DriveShaftConditionNote),
                new SqlParameter("@SuspensionConditionId",carInspection.SuspensionConditionId),
                new SqlParameter("@SuspensionConditionNote", carInspection.SuspensionConditionNote),
                new SqlParameter("@SuspensionSummary", carInspection.SuspensionSummary),
                new SqlParameter("@GearSystemId",carInspection.GearSystemId),
                new SqlParameter("@GearConditionId",carInspection.GearConditionId),
                new SqlParameter("@DriveShaftId",carInspection.DriveShaftId),
                new SqlParameter("@Is4WD",carInspection.Is4WD),
                new SqlParameter("@GearSystemSummary", carInspection.GearSystemSummary),
                new SqlParameter("@IsUseableSteerWheel",carInspection.IsUseableSteerWheel),
                new SqlParameter("@IsPowerSteering",carInspection.IsPowerSteering),
                new SqlParameter("@SteeringSummary", carInspection.SteeringSummary),
                new SqlParameter("@IsUseableBrake",carInspection.IsUseableBrake),
                new SqlParameter("@BrakeSystemSummary", carInspection.BreakSystemSumary),
                new SqlParameter("@IsAirCool",carInspection.IsAirCool),
                new SqlParameter("@IsCompressorAir",carInspection.IsCompressorAir),
                new SqlParameter("@AirSystemSummary", carInspection.AirSystemSummary),
                new SqlParameter("@IsUseableGuage",carInspection.IsUseableGuage),
                new SqlParameter("@WarningLightNote", carInspection.WarningLightNote),
                new SqlParameter("@GaugeSummary", carInspection.GaugeSummary),
                new SqlParameter("@IsFrontLightWorking",carInspection.IsFrontLightWorking),
                new SqlParameter("@IsTurnLightWorking",carInspection.IsTurnLightWorking),
                new SqlParameter("@IsBackLightWorking",carInspection.IsBackLightWorking),
                new SqlParameter("@IsBrakeLightWorking",carInspection.IsBrakeLightWoring),
                new SqlParameter("@IsBetteryWorking",carInspection.IsBetteryWorking),
                new SqlParameter("@IsHooterWorking",carInspection.IsHooterWorking),
                new SqlParameter("@IsRoundGaugeWorking",carInspection.IsRoundGaugeWorking),
                new SqlParameter("@IsNavigator",carInspection.IsNavigator),
                new SqlParameter("@IsNavigatorBuiltIn",carInspection.IsNavigatorBuiltIn),
                new SqlParameter("@IsNavigatorCD",carInspection.IsNavigatorCD),
                new SqlParameter("@IsNavigatorSdcard",carInspection.IsNavigatorSdcard),
                new SqlParameter("@IsNavigatorNoCD",carInspection.IsNavigatorNoCD),
                new SqlParameter("@IsNavigatorNoSdcard",carInspection.IsNavigatorNoSdcard),
                new SqlParameter("@ElectronicNote", carInspection.ElectronicNote),
                new SqlParameter("@ElectronicSummary", carInspection.ElectronicSummary),
                new SqlParameter("@LatestUpdatedDate",carInspection.LatestUpdatedDate),
                new SqlParameter("@Registration", carInspection.Regisration),
                new SqlParameter("@RegistrationProvince", carInspection.RegistrationProvince)
            };

                    int insertedId = context.Database.SqlQuery<int>(INS_Query.Add_CarInspection, param.ToArray()).SingleOrDefault();
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

        //#region AddCarInspectionImage
        //public string AddCarInspectionImage(CarInspectionImage carInspectionImage)
        //{
        //    string errorMessage = "";

        //    try
        //    {
        //        using (var context = new Inspection_dataFeedContext())
        //        {
        //            context.Database.CommandTimeout = 300000;
        //            if (context.Database.Connection.State == ConnectionState.Closed)
        //                context.Database.Connection.Open();
        //            var param = new List<SqlParameter>
        //    {
        //        //new SqlParameter("@InspectionId",carInspection.InspectionId),
        //        new SqlParameter("@BookInNumber", carInspection.BookInNumber),
        //        new SqlParameter("@VehicleId",carInspection.VehicleId),
        //        new SqlParameter("@Inspector", carInspection.Inspector),
        //        new SqlParameter("@InspectionDate",carInspection.InspectionDate),
        //        new SqlParameter("@InspectorName", carInspection.InspectorName),
        //        new SqlParameter("@Chassis", carInspection.Chassis),
        //        new SqlParameter("@Front", carInspection.Front),
        //        new SqlParameter("@Back", carInspection.Back),
        //        new SqlParameter("@RightSide", carInspection.RightSide),
        //        new SqlParameter("@LeftSide", carInspection.LeftSide),
        //        new SqlParameter("@Roof", carInspection.Roof),
        //        new SqlParameter("@IsFlood",carInspection.IsFlood),
        //        new SqlParameter("@BodySummary", carInspection.BodySummary),
        //        new SqlParameter("@IsEngineWorks",carInspection.IsEngineWorks),
        //        new SqlParameter("@FuelSystemId",carInspection.FuelSystemId),
        //        new SqlParameter("@IsLubricatorLow",carInspection.IsLubricatorLow),
        //        new SqlParameter("@EngineSystemId",carInspection.EngineSystemId),
        //        new SqlParameter("@GearTypeId",carInspection.GearTypeId),
        //        new SqlParameter("@IsUseableGeneral",carInspection.IsUseableGeneral),
        //        new SqlParameter("@IsSoundAbnormal",carInspection.IsSoundAbnormal),
        //        new SqlParameter("@IsLeakFuel",carInspection.IsLeakFuel),
        //        new SqlParameter("@IsStainWater",carInspection.IsStainWater),
        //        new SqlParameter("@IsMachineLightShow",carInspection.IsMachineLightShow),
        //        new SqlParameter("@IsEngineAbnomal",carInspection.IsEngineAbnomal),
        //        new SqlParameter("@IsNeedRepair",carInspection.IsNeedRepair),
        //        new SqlParameter("@EngineSummary", carInspection.EngineSummary),
        //        new SqlParameter("@DriveShaftConditionId",carInspection.DriveShaftConditionId),
        //        new SqlParameter("@DriveShaftConditionNote", carInspection.DriveShaftConditionNote),
        //        new SqlParameter("@SuspensionConditionId",carInspection.SuspensionConditionId),
        //        new SqlParameter("@SuspensionConditionNote", carInspection.SuspensionConditionNote),
        //        new SqlParameter("@SuspensionSummary", carInspection.SuspensionSummary),
        //        new SqlParameter("@GearSystemId",carInspection.GearSystemId),
        //        new SqlParameter("@GearConditionId",carInspection.GearConditionId),
        //        new SqlParameter("@DriveShaftId",carInspection.DriveShaftId),
        //        new SqlParameter("@Is4WD",carInspection.Is4WD),
        //        new SqlParameter("@GearSystemSummary", carInspection.GearSystemSummary),
        //        new SqlParameter("@IsUseableSteerWheel",carInspection.IsUseableSteerWheel),
        //        new SqlParameter("@IsPowerSteering",carInspection.IsPowerSteering),
        //        new SqlParameter("@SteeringSummary", carInspection.SteeringSummary),
        //        new SqlParameter("@IsUseableBrake",carInspection.IsUseableBrake),
        //        new SqlParameter("@BrakeSystemSummary", carInspection.BreakSystemSumary),
        //        new SqlParameter("@IsAirCool",carInspection.IsAirCool),
        //        new SqlParameter("@IsCompressorAir",carInspection.IsCompressorAir),
        //        new SqlParameter("@AirSystemSummary", carInspection.AirSystemSummary),
        //        new SqlParameter("@IsUseableGuage",carInspection.IsUseableGuage),
        //        new SqlParameter("@WarningLightNote", carInspection.WarningLightNote),
        //        new SqlParameter("@GaugeSummary", carInspection.GaugeSummary),
        //        new SqlParameter("@IsFrontLightWorking",carInspection.IsFrontLightWorking),
        //        new SqlParameter("@IsTurnLightWorking",carInspection.IsTurnLightWorking),
        //        new SqlParameter("@IsBackLightWorking",carInspection.IsBackLightWorking),
        //        new SqlParameter("@IsBrakeLightWorking",carInspection.IsBrakeLightWoring),
        //        new SqlParameter("@IsBetteryWorking",carInspection.IsBetteryWorking),
        //        new SqlParameter("@IsHooterWorking",carInspection.IsHooterWorking),
        //        new SqlParameter("@IsRoundGaugeWorking",carInspection.IsRoundGaugeWorking),
        //        new SqlParameter("@IsNavigator",carInspection.IsNavigator),
        //        new SqlParameter("@IsNavigatorBuiltIn",carInspection.IsNavigatorBuiltIn),
        //        new SqlParameter("@IsNavigatorCD",carInspection.IsNavigatorCD),
        //        new SqlParameter("@IsNavigatorSdcard",carInspection.IsNavigatorSdcard),
        //        new SqlParameter("@IsNavigatorNoCD",carInspection.IsNavigatorNoCD),
        //        new SqlParameter("@IsNavigatorNoSdcard",carInspection.IsNavigatorNoSdcard),
        //        new SqlParameter("@ElectronicNote", carInspection.ElectronicNote),
        //        new SqlParameter("@ElectronicSummary", carInspection.ElectronicSummary),
        //        new SqlParameter("@LatestUpdatedDate",carInspection.LatestUpdatedDate),
        //        new SqlParameter("@Registration", carInspection.Regisration),
        //        new SqlParameter("@RegistrationProvince", carInspection.RegistrationProvince)
        //    };

        //            int insertedId = context.Database.SqlQuery<int>(INS_Query.Add_CarInspection, param.ToArray()).SingleOrDefault();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("===================================================================");
        //        Console.WriteLine(ex.Message);
        //        errorMessage = ex.Message;
        //    }

        //    return errorMessage;
        //}
        //#endregion

        #region GetCarInspectionByBookIn
        public DataTable GetCarInspectionByBookIn(string bookinNo)
        {
            DataTable result = new DataTable();
            try
            {
                using (var context = new Inspection_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = INS_Query.get_CarInspectionByBookIn;

                        command.Parameters.Add(new SqlParameter("@bookinNo", bookinNo));

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

        #region UpdateInspectionCountINNOSYNC
        public void UpdateInspectionCountINNOSYNC(string vehicleId, int syncId)
        {
            try
            {

                    var context = new INS_WEB_dataFeedContext();
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    int count = 0;
                    DataTable result = new DataTable();
                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = INS_Query.get_inspectionCountByVehicleId;

                        command.Parameters.Add(new SqlParameter("@vehicleId", vehicleId));

                        using (var reader = command.ExecuteReader())
                        {
                            result.Load(reader);
                        }
                    }
                    if (result.Rows.Count > 0)
                    {
                        count = int.Parse(result.Rows[0]["InspectionCount"].ToString());
                    }

                    #region Parameter

                    var UserParam = new List<SqlParameter> {
                        new SqlParameter("@syncId",syncId),
                        new SqlParameter("@count",count),
                        };

                    #endregion Parameter

                    context.Database.ExecuteSqlCommand(INS_Query.Update_InspectionCountINNOSYNC, UserParam.ToArray());


                    if (context.Database.Connection.State == ConnectionState.Open)
                    {
                        context.Database.Connection.Close();
                    }


            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region UpdateErrorINNOSYNC
        public void UpdateErrorINNOSYNC(string error,int syncId)
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

                var UserParam = new List<SqlParameter> {
                        new SqlParameter("@syncId",syncId),
                        new SqlParameter("@error",error),
                        };

                #endregion Parameter

                context.Database.ExecuteSqlCommand(INS_Query.Update_ErrorINNOSYNC, UserParam.ToArray());


                if (context.Database.Connection.State == ConnectionState.Open)
                {
                    context.Database.Connection.Close();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region UpdateVehicleDocument
        public void UpdateVehicleDocument(string vehicleId, int documentTypeId)
        {
            try
            {
                using (var context = new Inspection_dataFeedContext())
                {
                    var connection = context.Database.Connection;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "dbo.UpdateVehicleDocumentDeleted";
                        command.CommandType = CommandType.StoredProcedure;

                        var paramVehicleId = command.CreateParameter();
                        paramVehicleId.ParameterName = "@vehicleId";
                        paramVehicleId.DbType = DbType.String;
                        paramVehicleId.Value = vehicleId;
                        command.Parameters.Add(paramVehicleId);

                        var paramDocumentTypeId = command.CreateParameter();
                        paramDocumentTypeId.ParameterName = "@documentTypeID";
                        paramDocumentTypeId.DbType = DbType.Int32;
                        paramDocumentTypeId.Value = documentTypeId;
                        command.Parameters.Add(paramDocumentTypeId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine($"Error in UpdateVehicleDocument: {ex.Message}");
            }
        }
        #endregion

        #region CreateVehicleDocument
        public void CreateVehicleDocument(string vehicleId, string documentDescBU, string documentDescLO, int documentTypeId, string documentPath, byte[] carImage)
        {
            try
            {
                using (var context = new Inspection_dataFeedContext())
                {
                    var connection = context.Database.Connection;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "dbo.CreateVehicleDocument";
                        command.CommandType = CommandType.StoredProcedure;

                        // VehicleId
                        var paramVehicleId = command.CreateParameter();
                        paramVehicleId.ParameterName = "@vehicleId";
                        paramVehicleId.DbType = DbType.String;
                        paramVehicleId.Value = vehicleId;
                        command.Parameters.Add(paramVehicleId);

                        // DocumentDescription_BU
                        var paramDescBU = command.CreateParameter();
                        paramDescBU.ParameterName = "@documentDescription_BU";
                        paramDescBU.DbType = DbType.String;
                        paramDescBU.Value = documentDescBU;
                        command.Parameters.Add(paramDescBU);

                        // DocumentDescription_LO
                        var paramDescLO = command.CreateParameter();
                        paramDescLO.ParameterName = "@documentDescription_LO";
                        paramDescLO.DbType = DbType.String;
                        paramDescLO.Value = documentDescLO;
                        command.Parameters.Add(paramDescLO);

                        // DocumentTypeID
                        var paramTypeId = command.CreateParameter();
                        paramTypeId.ParameterName = "@documentTypeID";
                        paramTypeId.DbType = DbType.Int32;
                        paramTypeId.Value = documentTypeId;
                        command.Parameters.Add(paramTypeId);

                        // DocumentPath
                        var paramPath = command.CreateParameter();
                        paramPath.ParameterName = "@documentPath";
                        paramPath.DbType = DbType.String;
                        paramPath.Value = documentPath;
                        command.Parameters.Add(paramPath);

                        // Image document as varbinary
                        var paramImage = command.CreateParameter();
                        paramImage.ParameterName = "@document";
                        paramImage.DbType = DbType.Binary;
                        paramImage.Value = carImage;
                        command.Parameters.Add(paramImage);

                        // Execute
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine($"Error in CreateVehicleDocument: {ex.Message}");
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

        #region GetINNOSyncByID
        public DataTable GetINNOSyncByID(int id)
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
                        command.CommandText = INS_Query.get_INNOSyncByID;

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

        #region GetBookInNoByVehicleID
        public string GetBookInNoByVehicleID(string id)
        {
            string bookInNo = "";
            DataTable result = new DataTable();
            try
            {
                using (var context = new Inspection_dataFeedContext())
                {
                    context.Database.CommandTimeout = 300000;
                    if (context.Database.Connection.State == ConnectionState.Closed)
                    {
                        context.Database.Connection.Open();
                    }

                    using (var command = context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = INS_Query.get_BookInNoByVehicleID;

                        command.Parameters.Add(new SqlParameter("@id", id));

                        using (var reader = command.ExecuteReader())
                        {
                            result.Load(reader);
                        }
                    }
                    if (result.Rows.Count > 0)
                    {
                        bookInNo = result.Rows[0]["BookInNumber"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(ex.Message);
            }
            return bookInNo;
        }
        #endregion

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

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
    }

    #region INS_Query
    public class INS_Query
    {
        public static string get_Body = "select Body,Desc_BU,Desc_LO from ZILO.IMAP.dbo.Bodies";

        public static string get_BodyByCode = "select Body,Desc_BU,Desc_LO from ZILO.IMAP.dbo.Bodies where Body=@code";

        public static string get_ContractType = "SELECT Id,CAST(ContractTypeCode AS NVARCHAR(50)) AS ContractTypeCode,CAST(DescEn AS NVARCHAR(100)) AS DescEn,CAST(DescTh AS NVARCHAR(100)) AS DescTh FROM ZILO.IMAP.dbo.ContractType";

        public static string get_SellingCategory = "select REPLACE(CONVERT(varchar(10),SellingCategory),' ','') SellingCategory,Desc_BU,Desc_LO,BodyRef from ZILO.IMAP.dbo.SellingCategories";

        public static string get_SellingCategoryByCode = "select REPLACE(CONVERT(varchar(10),SellingCategory),' ','') SellingCategory,Desc_BU,Desc_LO,BodyRef from ZILO.IMAP.dbo.SellingCategories where SellingCategory=@code";

        public static string get_Drive = "select * from ZILO.IMAP.dbo.Drives";

        public static string get_DriveByCode = "select * from ZILO.IMAP.dbo.Drives where Drive=@code";

        public static string get_FuelDelivery = "select * from ZILO.IMAP.dbo.FuelDeliveries";

        public static string get_FuelDeliveryByCode = "select * from ZILO.IMAP.dbo.FuelDeliveries where FuelDelivery=@code";

        public static string get_FuelType = "select * from ZILO.IMAP.dbo.FuelTypes";

        public static string get_FuelTypeByCode = "select * from ZILO.IMAP.dbo.FuelTypes where FuelType=@code";

        public static string get_Make = "select * from ZILO.IMAP.dbo.Makes";

        public static string get_MakeByCode = "select * from ZILO.IMAP.dbo.Makes where Make=@code";

        public static string get_MatVariant = "SELECT Id,Model_BU,Variants,BuildYear,Make,Make_BU,Make_LO FROM ZILO.IMAP.dbo.View_Mat_Variant";

        public static string get_MatVariant_ByModel = "SELECT Id,Model_BU,Variants,BuildYear,Make,Make_BU,Make_LO FROM ZILO.IMAP.dbo.View_Mat_Variant where Lower(Model_BU)=Lower(@Model)";

        public static string get_Seller = "SELECT Customer SellerCode,CompanyName_LO SellerNameTh,CompanyName_BU SellerNameEn FROM IMAP.dbo.Customers WHERE CustomerType = 'S'";

        public static string get_SellerByCode = "SELECT Customer SellerCode,CompanyName_LO SellerNameTh,CompanyName_BU SellerNameEn FROM IMAP.dbo.Customers WHERE CustomerType = 'S' AND Customer=@code";

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

        public static string get_PlantByStorageLocation = @"SELECT Plant FROM ZILO.IMAP.dbo.StorageLocation where Location=@Location";

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

        public static string get_ModelTemplateById = @"select ID, 
                                                    ModelCode, ModelCode + '-' + ModelDisplay + '-' + Variants ModelDisplay,
                                                    BuildYear,Model_BU,Model_LO,Variants,Description_BU,Description_LO, EngineCapacity,EngineCapacityUnit, FuelDelivery, FuelType,
                                                    GearBox,Gears,Drive,Make,Body,ChassisPreCode,CreateDate,CreateUser,CabTypeID,LevelCabID
                                                    from  ZILO.IMAP.dbo.ModelTemplates where ID=@id";

        public static string get_ModelTemplate_ForDataEntry_ByVarId = @"SELECT MT.ID,MT.Description_BU,MT.ModelCode,MT.ModelDisplay,
                                                    MK.Desc_BU Make_ENG,MK.Desc_LO Make_TH,Model_BU,Model_LO,
                                                    GB.Desc_BU GearBox_ENG,GB.Desc_LO GearBox_TH,
                                                    FD.Desc_BU FuelDelivery_ENG,FD.Desc_LO FuelDelivery_TH,
                                                    FT.Desc_BU FuelType_ENG,FT.Desc_LO FuelType_TH,
                                                    DV.Desc_BU Drive_ENG,DV.Desc_LO Drive_TH,
                                                    BD.Desc_BU Body_ENG,BD.Desc_LO Body_TH,Gears
                                                    FROM
                                                    (SELECT *
                                                    FROM ZILO.IMAP.dbo.ModelTemplates
                                                    WHERE ID = @id)MT
                                                    LEFT JOIN ZILO.IMAP.dbo.Makes MK
                                                    ON MK.Make = MT.Make
                                                    LEFT JOIN ZILO.IMAP.dbo.FuelDeliveries FD
                                                    ON FD.FuelDelivery = MT.FuelDelivery
                                                    LEFT JOIN ZILO.IMAP.dbo.FuelTypes FT
                                                    ON FT.FuelType = MT.FuelType
                                                    LEFT JOIN ZILO.IMAP.dbo.GearBoxes GB
                                                    ON GB.GearBox = MT.Gearbox
                                                    LEFT JOIN ZILO.IMAP.dbo.Drives DV
                                                    ON DV.Drive = MT.Drive
                                                    LEFT JOIN ZILO.IMAP.dbo.Bodies BD
                                                    ON BD.Body = MT.Body";

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

        public static string get_FuelTypeByVarID = @"SELECT Data.ID VarID,FT.FuelType FuelType,FT.Desc_BU Fuel_BU,FT.Desc_LO Fuel_LO
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

        public static string get_BodyByVarID = @"SELECT Data.ID VarID,B.Body BodyType,B.Desc_BU Body_BU,B.Desc_LO Body_LO
                                                        FROM
                                                        (SELECT DISTINCT ID,Body FROM ZILO.IMAP.dbo.ModelTemplates WHERE ID = @id) Data
                                                        LEFT JOIN ZILO.IMAP.dbo.Bodies B ON Data.Body = B.Body";

        public static string get_MatModel = @"select * from  ZILO.IMAP.dbo.View_Mat_Model";

        public static string get_InspectionCatalog = @"select * from [dbo].[INNO_SYNC] where VehicleId=@imapNo order by InspectionCount desc";

        public static string Save_InspectionCatlog_Log = @"insert into GetCatalogAPI_Log (ImapNo,ResponseMessage,LogDateTime) Values (@ImapNo,@ResponseMessage,@LogDateTime);";

        public static string get_CabType = @"SELECT RTRIM(CabTypeID) AS CabTypeID,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO FROM ZILO.IMAP.dbo.CabType";

        public static string get_LevelCab = @"SELECT RTRIM(levelCabID) AS levelCabID,RTRIM(Desc_BU) AS Desc_BU,RTRIM(Desc_LO) AS Desc_LO FROM ZILO.IMAP.dbo.levelCabs";

        public static string Add_BookIn = @"INSERT INTO BookIn (
                                        BookInNumber, BookInDate, SenderName, ReceiverName, ContractNumber,
                                        MobileNumber, Status, SellerCode, Inspector, VehicleId,
                                        SenderSignature, ReceiverSignature, LatestUpdatedDate, BookinType,
                                        CreateBy, CreateDate, ContractTypeCode, StickVin, TenantName, TimeStartApp
                                    )
                                    VALUES (
                                        @BookInNumber, @BookInDate, @SenderName, @ReceiverName, @ContractNumber,
                                        @MobileNumber, @Status, @SellerCode, @Inspector, @VehicleId,
                                        @SenderSignature, @ReceiverSignature, @LatestUpdatedDate, @BookinType,
                                        @CreateBy, @CreateDate, @ContractTypeCode, @StickVin , @TenantName, @TimeStartApp
                                    );
                                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Add_Vehicle = @"INSERT INTO Vehicle (
                                            BookinNumber, Seller, SellingCategory, LogisticsStatus, InspectionDate,
                                            SalesStatus, Plant, StorageLocation, ReceiverLocation, BookedDate,
                                            Make, Make_BU, Make_LO, ModelCode, ModelCodeId,
                                            Model_BU, Model_LO, Body, BodyDesc_BU, BodyDesc_LO,
                                            Variants, BuildYear, VIN, ChasisNumber, Colour,
                                            ColourDesc, FuelDelivery, FuelType, Gearbox, Gears,
                                            Drive, EngineNumber, EngineCapacity, EngineCapacityUnit, Regisration,
                                            RegistrationYear, RegistrationProvince, RegistrationPlate, RegistrationNote, IsRegistrationMismatch,
                                            RedBookCondition, IsGasTank, GasType, GasTankNumber, GasNote,
                                            IsInValidEngineNumber, ReasonInValidEngineNumber, IsInValidGasNumber, ReasonInValidGasNumber, IsInValidVinNumber,
                                            ReasonInValidVinNumber, IsNohaveBuildYear, IsNohaveRegis, briefCarConditionId, DetallBriefCarCondition,
                                            MotorNumber, IsInValidMotorNumber, ReasonInValidMotorNumber,
                                            IsInVaidEngine1, IsInVaidEngine2, IsInVaidEngine3,
                                            IsInVaidVin1, IsInVaidVin2, IsInVaidVin3,
                                            NoPlateType, CatalyticOption, CabTypeID, LevelCabID
                                        )
                                        VALUES (
                                            @BookinNumber, @Seller, @SellingCategory, @LogisticsStatus, @InspectionDate,
                                            @SalesStatus, @Plant, @StorageLocation, @ReceiverLocation, @BookedDate,
                                            @Make, @Make_BU, @Make_LO, @ModelCode, @ModelCodeId,
                                            @Model_BU, @Model_LO, @Body, @BodyDesc_BU, @BodyDesc_LO,
                                            @Variants, @BuildYear, @VIN, @ChasisNumber, @Colour,
                                            @ColourDesc, @FuelDelivery, @FuelType, @Gearbox, @Gears,
                                            @Drive, @EngineNumber, @EngineCapacity, @EngineCapacityUnit, @Regisration,
                                            @RegistrationYear, @RegistrationProvince, @RegistrationPlate, @RegistrationNote, @IsRegistrationMismatch,
                                            @RedBookCondition, @IsGasTank, @GasType, @GasTankNumber, @GasNote,
                                            @IsInValidEngineNumber, @ReasonInValidEngineNumber, @IsInValidGasNumber, @ReasonInValidGasNumber, @IsInValidVinNumber,
                                            @ReasonInValidVinNumber, @IsNohaveBuildYear, @IsNohaveRegis, @briefCarConditionId, @DetallBriefCarCondition,
                                            @MotorNumber, @IsInValidMotorNumber, @ReasonInValidMotorNumber,
                                            @IsInVaidEngine1, @IsInVaidEngine2, @IsInVaidEngine3,
                                            @IsInVaidVin1, @IsInVaidVin2, @IsInVaidVin3,
                                            @NoPlateType, @CatalyticOption, @CabTypeID, @LevelCabID
                                        );
                                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Add_External = @"INSERT INTO [dbo].[External] (
                                            GradeOverallId, ColorOverallId, IsSpoiler, MagWheel, NormalWheel, 
                                            IsTyre, TyreQuality, DamageDesc, BookinNumber, TyreBrand, RoofTypeId
                                        )
                                        VALUES (
                                            @GradeOverallId, @ColorOverallId, @IsSpoiler, @MagWheel, @NormalWheel, 
                                            @IsTyre, @TyreQuality, @DamageDesc, @BookinNumber, @TyreBrand, @RoofTypeId
                                        ); 
                                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Add_Spare = @"INSERT INTO Spare (
                                            SpareOverAllId, SpareNote, IsSpareType, IsHandTool, IsMaxliner, 
                                            IsRoofRack, IsJackCar, IsCableChargeEV, AccessoriesNote, BookinNumber
                                        )
                                        VALUES (
                                            @SpareOverAllId, @SpareNote, @IsSpareType, @IsHandTool, @IsMaxliner, 
                                            @IsRoofRack, @IsJackCar, @IsCableChargeEV, @AccessoriesNote, @BookinNumber
                                        ); 
                                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Add_Cabin = @"INSERT INTO Cabin (
                                            CabinOverAllId, Mileage, MileageTypeId, FuelVolumn, GearSystemId,
                                            IsAirback, IsHeadGear, IsPowerAmp, IsLockGear, IsPreAmp,
                                            IsBookService, IsSpeaker, IsManual, IsCigaretteLiter, IsTaxPlate,
                                            IsPlateExpireDate, IsNavigator, IsNavigatorBuiltin, IsNavigatorCD, IsNavigatorSDCard,
                                            IsNavigatorNoCD, IsNavigatorNoSDCard, PlayerBrand, IsPlayerRadio, IsPlayerTape,
                                            IsPlayerCD, IsPlayerUSB, KeyOptionId, CabinNote, BookInNumber,
                                            IsInvalidMileage, InvalidMileageReason
                                        )
                                        VALUES (
                                            @CabinOverAllId, @Mileage, @MileageTypeId, @FuelVolumn, @GearSystemId,
                                            @IsAirback, @IsHeadGear, @IsPowerAmp, @IsLockGear, @IsPreAmp,
                                            @IsBookService, @IsSpeaker, @IsManual, @IsCigaretteLiter, @IsTaxPlate,
                                            @IsPlateExpireDate, @IsNavigator, @IsNavigatorBuiltin, @IsNavigatorCD, @IsNavigatorSDCard,
                                            @IsNavigatorNoCD, @IsNavigatorNoSDCard, @PlayerBrand, @IsPlayerRadio, @IsPlayerTape,
                                            @IsPlayerCD, @IsPlayerUSB, @KeyOptionId, @CabinNote, @BookInNumber,
                                            @IsInvalidMileage, @InvalidMileageReason
                                        );
                                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Add_KeyOption = @"INSERT INTO KeyOption (
                                            NumberOfKey, NumberOfRemote, NumberOfKeyRemote, NumberOfImmobilizer, 
                                            NumberOfKeyless, BookinNumber
                                        )
                                        VALUES (
                                            @NumberOfKey, @NumberOfRemote, @NumberOfKeyRemote, @NumberOfImmobilizer, 
                                            @NumberOfKeyless, @BookinNumber
                                        );
                                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Add_Engine = @"INSERT INTO Engine (
                                            EngineRoomOverAllId,
                                            BatteryBrand,
                                            BatteryIndicatorColor,
                                            IsEcu,
                                            IsCompressorAir,
                                            DriverSystemId,
                                            FuelSystemId,
                                            IsFuelGas,
                                            GasTypeId,
                                            InsideAssetNote,
                                            BookinNumber
                                        )
                                        VALUES (
                                            @EngineRoomOverAllId,
                                            @BatteryBrand,
                                            @BatteryIndicatorColor,
                                            @IsEcu,
                                            @IsCompressorAir,
                                            @DriverSystemId,
                                            @FuelSystemId,
                                            @IsFuelGas,
                                            @GasTypeId,
                                            @InsideAssetNote,
                                            @BookinNumber
                                        );
                                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string Add_CarInspection = @"INSERT INTO CarInspection (
                                        BookInNumber,
                                        VehicleId,
                                        Inspector,
                                        InspectionDate,
                                        InspectorName,
                                        Chassis,
                                        Front,
                                        Back,
                                        RightSide,
                                        LeftSide,
                                        Roof,
                                        IsFlood,
                                        BodySummary,
                                        IsEngineWorks,
                                        FuelSystemId,
                                        IsLubricatorLow,
                                        EngineSystemId,
                                        GearTypeId,
                                        IsUseableGeneral,
                                        IsSoundAbnormal,
                                        IsLeakFuel,
                                        IsStainWater,
                                        IsMachineLightShow,
                                        IsEngineAbnomal,
                                        IsNeedRepair,
                                        EngineSummary,
                                        DriveShaftConditionId,
                                        DriveShaftConditionNote,
                                        SuspensionConditionId,
                                        SuspensionConditionNote,
                                        SuspensionSummary,
                                        GearSystemId,
                                        GearConditionId,
                                        DriveShaftId,
                                        Is4WD,
                                        GearSystemSummary,
                                        IsUseableSteerWheel,
                                        IsPowerSteering,
                                        SteeringSummary,
                                        IsUseableBrake,
                                        BreakSystemSumary,
                                        IsAirCool,
                                        IsCompressorAir,
                                        AirSystemSummary,
                                        IsUseableGuage,
                                        WarningLightNote,
                                        GaugeSummary,
                                        IsFrontLightWorking,
                                        IsTurnLightWorking,
                                        IsBackLightWorking,
                                        IsBrakeLightWoring,
                                        IsBetteryWorking,
                                        IsHooterWorking,
                                        IsRoundGaugeWorking,
                                        IsNavigator,
                                        IsNavigatorBuiltIn,
                                        IsNavigatorCD,
                                        IsNavigatorSdcard,
                                        IsNavigatorNoCD,
                                        IsNavigatorNoSdcard,
                                        ElectronicNote,
                                        ElectronicSummary,
                                        LatestUpdatedDate,
                                        Regisration,
                                        RegistrationProvince
                                    )
                                    VALUES (
                                        @BookInNumber,
                                        @VehicleId,
                                        @Inspector,
                                        @InspectionDate,
                                        @InspectorName,
                                        @Chassis,
                                        @Front,
                                        @Back,
                                        @RightSide,
                                        @LeftSide,
                                        @Roof,
                                        @IsFlood,
                                        @BodySummary,
                                        @IsEngineWorks,
                                        @FuelSystemId,
                                        @IsLubricatorLow,
                                        @EngineSystemId,
                                        @GearTypeId,
                                        @IsUseableGeneral,
                                        @IsSoundAbnormal,
                                        @IsLeakFuel,
                                        @IsStainWater,
                                        @IsMachineLightShow,
                                        @IsEngineAbnomal,
                                        @IsNeedRepair,
                                        @EngineSummary,
                                        @DriveShaftConditionId,
                                        @DriveShaftConditionNote,
                                        @SuspensionConditionId,
                                        @SuspensionConditionNote,
                                        @SuspensionSummary,
                                        @GearSystemId,
                                        @GearConditionId,
                                        @DriveShaftId,
                                        @Is4WD,
                                        @GearSystemSummary,
                                        @IsUseableSteerWheel,
                                        @IsPowerSteering,
                                        @SteeringSummary,
                                        @IsUseableBrake,
                                        @BrakeSystemSummary,
                                        @IsAirCool,
                                        @IsCompressorAir,
                                        @AirSystemSummary,
                                        @IsUseableGuage,
                                        @WarningLightNote,
                                        @GaugeSummary,
                                        @IsFrontLightWorking,
                                        @IsTurnLightWorking,
                                        @IsBackLightWorking,
                                        @IsBrakeLightWorking,
                                        @IsBetteryWorking,
                                        @IsHooterWorking,
                                        @IsRoundGaugeWorking,
                                        @IsNavigator,
                                        @IsNavigatorBuiltIn,
                                        @IsNavigatorCD,
                                        @IsNavigatorSdcard,
                                        @IsNavigatorNoCD,
                                        @IsNavigatorNoSdcard,
                                        @ElectronicNote,
                                        @ElectronicSummary,
                                        @LatestUpdatedDate,
                                        @Registration,
                                        @RegistrationProvince
                                    );
                                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public static string get_CarInspectionByBookIn = @"SELECT * FROM CarInspection WHERE BookInNumber = @bookinNo";

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
                                                        (CASE WHEN SCHEMANAME LIKE  '%Motor%' THEN 'Motorbike' WHEN SCHEMANAME LIKE  '%car%' THEN 'Car' WHEN SCHEMANAME LIKE  '%salvage%' THEN 'SVG' ELSE '' END) SchemaVehicle
                                                        FROM [dbo].[INNO_SYNC] WHERE RefKey = @RefKey ORDER BY ID DESC";

        public static string get_VehicleColoursSet = @"SELECT Cid,Colour_BU,Colour_LO FROM ZILO.IMAP.dbo.VehicleColoursSet ";

        public static string get_INNOSyncByID = @"SELECT ID,RefKey,TxnDate,Schemaname,SchemaInfo,InspectionData,Sendername,ReceiverName,MobileNumber,SellerCode,Inspector,VehicleId,ChasisNumber,VIN,RegistrationNumber,CreatedBy,CreatedDate,
                                                    (CASE WHEN SCHEMANAME LIKE  '%inspection%' THEN 'Inspection' WHEN SCHEMANAME LIKE  '%bookin%' THEN 'Book In' ELSE '' END) SchemaType ,
													(CASE WHEN SCHEMANAME LIKE  '%car%' THEN 'Car' WHEN SCHEMANAME LIKE  '%motorbike%' THEN 'MB' WHEN SCHEMANAME LIKE  '%salvage%' THEN 'SVG' ELSE '' END)  VehicleType
                                                    FROM InspectionWeb.dbo.INNO_SYNC where ID=@id";

        public static string get_BookInNoByVehicleID = $@"select BookInNumber from BookIn where VehicleId=@id";

        public static string Update_ErrorINNOSYNC=$@"UPDATE INNO_SYNC SET ErrorMsg = @error WHERE ID=@syncId";

        public static string Update_InspectionCountINNOSYNC = $@"UPDATE INNO_SYNC SET InspectionCount = @count + 1 WHERE ID=@syncId";

        public static string get_inspectionCountByVehicleId = $@"SELECT COUNT(*) AS InspectionCount FROM INNO_SYNC WHERE VehicleId = @vehicleId AND SchemaName LIKE '%inspection%'";

    }
    #endregion
}
