using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace INS_API_DataFeed.DAO
{
    #region RiceHarvesterRequest
    public class RiceHarvesterData
    {
        [JsonProperty("Tracks")]
        public string Tracks { get; set; }

        [JsonProperty("Rollers")]
        public string Rollers { get; set; }

        [JsonProperty("Blade")]
        public string Blade { get; set; }

        [JsonProperty("ConveyorChain")]
        public string ConveyorChain { get; set; }

        [JsonProperty("IdlerWheel")]
        public string IdlerWheel { get; set; }

        [JsonProperty("ThreshingChamber")]
        public string ThreshingChamber { get; set; }

        [JsonProperty("GrainStorageTank")]
        public string GrainStorageTank { get; set; }

        [JsonProperty("Battery")]
        public string Battery { get; set; }

        [JsonProperty("Covers")]
        public string Covers { get; set; }

        [JsonProperty("DriversSeat")]
        public string DriversSeat { get; set; }

        [JsonProperty("DustExtractionFan")]
        public string DustExtractionFan { get; set; }

        [JsonProperty("Roof")]
        public string Roof { get; set; }

        [JsonProperty("WorkerPlatform")]
        public string WorkerPlatform { get; set; }

        [JsonProperty("WorkerRearSupport")]
        public string WorkerRearSupport { get; set; }

        [JsonProperty("Toolbox")]
        public string Toolbox { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("FuelLevel")]
        public string FuelLevel { get; set; }

        [JsonProperty("Lights")]
        public string Lights { get; set; }

        [JsonProperty("SeparatorGrateintheThreshingChamber")]
        public string SeparatorGrateintheThreshingChamber { get; set; }

        [JsonProperty("RotaryPickerUnit")]
        public string RotaryPickerUnit { get; set; }

        [JsonProperty("CutterHead")]
        public string CutterHead { get; set; }

        [JsonProperty("RiceThreshingSystem")]
        public string RiceThreshingSystem { get; set; }

        [JsonProperty("SteelWheels")]
        public string SteelWheels { get; set; }

        [JsonProperty("Rake")]
        public string Rake { get; set; }

        [JsonProperty("MoreDetails")]
        public string MoreDetails { get; set; }

        [JsonProperty("EngineCondition")]
        public string EngineCondition { get; set; }

        [JsonProperty("EngineCondition_text")]
        public string EngineCondition_text { get; set; }

        [JsonProperty("BodyCondition")]
        public string BodyCondition { get; set; }

        [JsonProperty("ColorCondition")]
        public string ColorCondition { get; set; }

        [JsonProperty("DriveSystem")]
        public string DriveSystem { get; set; }

        [JsonProperty("DriveSystem_text")]
        public string DriveSystem_text { get; set; }

        [JsonProperty("TransmissionSystem")]
        public string TransmissionSystem { get; set; }

        [JsonProperty("TransmissionSystem_text")]
        public string TransmissionSystem_text { get; set; }

        [JsonProperty("BrakeSystem")]
        public string BrakeSystem { get; set; }

        [JsonProperty("BrakeSystem_text")]
        public string BrakeSystem_text { get; set; }

        [JsonProperty("ClutchSystem")]
        public string ClutchSystem { get; set; }

        [JsonProperty("ClutchSystem_text")]
        public string ClutchSystem_text { get; set; }

        [JsonProperty("SteeringSystem")]
        public string SteeringSystem { get; set; }

        [JsonProperty("SteeringSystem_text")]
        public string SteeringSystem_text { get; set; }

        [JsonProperty("HydraulicSystem")]
        public string HydraulicSystem { get; set; }

        [JsonProperty("HydraulicSystem_text")]
        public string HydraulicSystem_text { get; set; }

        [JsonProperty("Others")]
        public string Others { get; set; }

        [JsonProperty("Others_text")]
        public string Others_text { get; set; }

        [JsonProperty("TotalCondition")]
        public string TotalCondition { get; set; }

        [JsonProperty("EstimatePrice")]
        public string EstimatePrice { get; set; }

        [JsonProperty("Remark")]
        public string Remark { get; set; }

        [JsonProperty("IMATNumber")]
        public string IMATNumber { get; set; }

        [JsonProperty("ActionLocation")]
        public string ActionLocation { get; set; }

        [JsonProperty("ActionBy")]
        public string ActionBy { get; set; }

        [JsonProperty("ActionUnixTime")]
        public int ActionUnixTime { get; set; }

        [JsonProperty("FrontImage")]
        public string[] FrontImage { get; set; }

        [JsonProperty("LeftImage")]
        public string[] LeftImage { get; set; }

        [JsonProperty("RearImage")]
        public string[] RearImage { get; set; }

        [JsonProperty("RightImage")]
        public string[] RightImage { get; set; }

        [JsonProperty("MileageImage")]
        public string[] MileageImage { get; set; }

        [JsonProperty("LicensePlateImage")]
        public string[] LicensePlateImage { get; set; }

        [JsonProperty("ChassisImage")]
        public string[] ChassisImage { get; set; }

        [JsonProperty("SeatImage")]
        public string[] SeatImage { get; set; }

        [JsonProperty("EngineImage")]
        public string[] EngineImage { get; set; }

        [JsonProperty("KeyImage")]
        public string[] KeyImage { get; set; }

        [JsonProperty("ToolboxImage")]
        public string[] ToolboxImage { get; set; }

        [JsonProperty("AttachedEquimentImage")]
        public string[] AttachedEquimentImage { get; set; }

        [JsonProperty("DamageImage")]
        public string[] DamageImage { get; set; }
    }
    #endregion

    #region BookInRequest
    public class BookInData
    {
        [JsonProperty("ContractNumber")]
        public string ContractNumber { get; set; }

        [JsonProperty("SellerName")]
        public string SellerName { get; set; }

        [JsonProperty("SellerRef")]
        public string SellerRef { get; set; }

        [JsonProperty("SellingCategory")]
        public string SellingCategory { get; set; }

        [JsonProperty("ClientName")]
        public string ClientName { get; set; }

        [JsonProperty("TenantName")]
        public string TenantName { get; set; }

        [JsonProperty("Body")]
        public string Body { get; set; }

        [JsonProperty("Model")]
        public string Model { get; set; }

        [JsonProperty("Variant")]
        public string Variant { get; set; }

        [JsonProperty("BuildYear")]
        public int BuildYear { get; set; }

        [JsonProperty("Color")]
        public string Color { get; set; }

        [JsonProperty("RegistrationDate")]
        public int RegistrationDate { get; set; }

        [JsonProperty("WorkHours")]
        public int WorkHours { get; set; }

        [JsonProperty("LicensePlateNumber")]
        public string LicensePlateNumber { get; set; }

        [JsonProperty("LicensePlateNumberCondition")]
        public string LicensePlateNumberCondition { get; set; }

        [JsonProperty("LicensePlateNumberCondition_text")]
        public string LicensePlateNumberCondition_text { get; set; }

        [JsonProperty("EngineNumber")]
        public string EngineNumber { get; set; }

        [JsonProperty("EngineNumberCondition")]
        public string EngineNumberCondition { get; set; }

        [JsonProperty("EngineNumberCondition_text")]
        public string EngineNumberCondition_text { get; set; }

        [JsonProperty("ChassisNumber")]
        public string ChassisNumber { get; set; }

        [JsonProperty("ChassisNumberCondition")]
        public string ChassisNumberCondition { get; set; }

        [JsonProperty("ChassisNumberCondition_text")]
        public string ChassisNumberCondition_text { get; set; }

        [JsonProperty("DroneNumber")]
        public string DroneNumber { get; set; }

        [JsonProperty("DroneNumberCondition")]
        public string DroneNumberCondition { get; set; }

        [JsonProperty("DroneNumberCondition_text")]
        public string DroneNumberCondition_text { get; set; }

        [JsonProperty("DroneRemoteNumber")]
        public string DroneRemoteNumber { get; set; }

        [JsonProperty("DroneRemoteNumberCondition")]
        public string DroneRemoteNumberCondition { get; set; }

        [JsonProperty("DroneRemoteNumberCondition_text")]
        public string DroneRemoteNumberCondition_text { get; set; }

        [JsonProperty("SellerNumber")]
        public string SellerNumber { get; set; }

        [JsonProperty("IMATNumber")]
        public string IMATNumber { get; set; }

        [JsonProperty("ActionLocation")]
        public string ActionLocation { get; set; }

        [JsonProperty("ActionBy")]
        public string ActionBy { get; set; }

        [JsonProperty("ActionUnixTime")]
        public int ActionUnixTime { get; set; }

        [JsonProperty("FrontImage")]
        public string[] FrontImage { get; set; }

        [JsonProperty("LeftImage")]
        public string[] LeftImage { get; set; }

        [JsonProperty("RearImage")]
        public string[] RearImage { get; set; }

        [JsonProperty("RightImage")]
        public string[] RightImage { get; set; }

    }
    #endregion

    #region ExcavatorRequest
    public class ExcavatorData
    {
        [JsonProperty("Tracks")]
        public string Tracks { get; set; }

        [JsonProperty("Rollers")]
        public string Rollers { get; set; }

        [JsonProperty("DozerBlade")]
        public string DozerBlade { get; set; }

        [JsonProperty("HydraulicHoses")]
        public string HydraulicHoses { get; set; }

        [JsonProperty("ControlLevers")]
        public string ControlLevers { get; set; }

        [JsonProperty("DigitalDashboard")]
        public string DigitalDashboard { get; set; }

        [JsonProperty("Battery")]
        public string Battery { get; set; }

        [JsonProperty("CoverPanels")]
        public string CoverPanels { get; set; }

        [JsonProperty("DriversSeat")]
        public string DriversSeat { get; set; }

        [JsonProperty("SafetyLock")]
        public string SafetyLock { get; set; }

        [JsonProperty("Lights")]
        public string Lights { get; set; }

        [JsonProperty("FloorRubberMat")]
        public string FloorRubberMat { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("FuelLevel")]
        public string FuelLevel { get; set; }

        [JsonProperty("SteelWheels")]
        public string SteelWheels { get; set; }

        [JsonProperty("Rake")]
        public string Rake { get; set; }

        [JsonProperty("MoreDetails")]
        public string MoreDetails { get; set; }

        [JsonProperty("EngineCondition")]
        public string EngineCondition { get; set; }

        [JsonProperty("EngineCondition_text")]
        public string EngineCondition_text { get; set; }

        [JsonProperty("BodyCondition")]
        public string BodyCondition { get; set; }

        [JsonProperty("ColorCondition")]
        public string ColorCondition { get; set; }

        [JsonProperty("DriveSystem")]
        public string DriveSystem { get; set; }

        [JsonProperty("DriveSystem_text")]
        public string DriveSystem_text { get; set; }

        [JsonProperty("TransmissionSystem")]
        public string TransmissionSystem { get; set; }

        [JsonProperty("TransmissionSystem_text")]
        public string TransmissionSystem_text { get; set; }

        [JsonProperty("BrakeSystem")]
        public string BrakeSystem { get; set; }

        [JsonProperty("BrakeSystem_text")]
        public string BrakeSystem_text { get; set; }

        [JsonProperty("ClutchSystem")]
        public string ClutchSystem { get; set; }

        [JsonProperty("ClutchSystem_text")]
        public string ClutchSystem_text { get; set; }

        [JsonProperty("SteeringSystem")]
        public string SteeringSystem { get; set; }

        [JsonProperty("SteeringSystem_text")]
        public string SteeringSystem_text { get; set; }

        [JsonProperty("HydraulicSystem")]
        public string HydraulicSystem { get; set; }

        [JsonProperty("HydraulicSystem_text")]
        public string HydraulicSystem_text { get; set; }

        [JsonProperty("Others")]
        public string Others { get; set; }

        [JsonProperty("Others_text")]
        public string Others_text { get; set; }

        [JsonProperty("TotalCondition")]
        public string TotalCondition { get; set; }

        [JsonProperty("EstimatePrice")]
        public string EstimatePrice { get; set; }

        [JsonProperty("Remark")]
        public string Remark { get; set; }

        [JsonProperty("IMATNumber")]
        public string IMATNumber { get; set; }

        [JsonProperty("ActionLocation")]
        public string ActionLocation { get; set; }

        [JsonProperty("ActionBy")]
        public string ActionBy { get; set; }

        [JsonProperty("ActionUnixTime")]
        public int ActionUnixTime { get; set; }

        [JsonProperty("FrontImage")]
        public string[] FrontImage { get; set; }

        [JsonProperty("LeftImage")]
        public string[] LeftImage { get; set; }

        [JsonProperty("RearImage")]
        public string[] RearImage { get; set; }

        [JsonProperty("RightImage")]
        public string[] RightImage { get; set; }

        [JsonProperty("MileageImage")]
        public string[] MileageImage { get; set; }

        [JsonProperty("LicensePlateImage")]
        public string[] LicensePlateImage { get; set; }

        [JsonProperty("ChassisImage")]
        public string[] ChassisImage { get; set; }

        [JsonProperty("SeatImage")]
        public string[] SeatImage { get; set; }

        [JsonProperty("EngineImage")]
        public string[] EngineImage { get; set; }

        [JsonProperty("KeyImage")]
        public string[] KeyImage { get; set; }

        [JsonProperty("ToolboxImage")]
        public string[] ToolboxImage { get; set; }

        [JsonProperty("AttachedEquimentImage")]
        public string[] AttachedEquimentImage { get; set; }

        [JsonProperty("DamageImage")]
        public string[] DamageImage { get; set; }
    }
    #endregion

    #region RicePlantingVehicleRequest
    public class RicePlantingVehicleData
    {

        [JsonProperty("Battery")]
        public string Battery { get; set; }

        [JsonProperty("EngineCover")]
        public string EngineCover { get; set; }

        [JsonProperty("Wheels")]
        public string Wheels { get; set; }

        [JsonProperty("SteelWheels")]
        public string SteelWheels { get; set; }

        [JsonProperty("PlantingSpacingSystem")]
        public string PlantingSpacingSystem { get; set; }

        [JsonProperty("SeedlingTrayHolder")]
        public string SeedlingTrayHolder { get; set; }

        [JsonProperty("SeedlingTraySliderRails")]
        public string SeedlingTraySliderRails { get; set; }

        [JsonProperty("LineGuidanceRod")]
        public string LineGuidanceRod { get; set; }

        [JsonProperty("PlantingHead")]
        public string PlantingHead { get; set; }

        [JsonProperty("SeedlingSizeSelectorSystem")]
        public string SeedlingSizeSelectorSystem { get; set; }

        [JsonProperty("SeedlingPerClusterAdjustmentSystem")]
        public string SeedlingPerClusterAdjustmentSystem { get; set; }

        [JsonProperty("RicePlantingMechanism")]
        public string RicePlantingMechanism { get; set; }

        [JsonProperty("FloorRubberMat")]
        public string FloorRubberMat { get; set; }

        [JsonProperty("FuelLevel")]
        public string FuelLevel { get; set; }

        [JsonProperty("Headlights")]
        public string Headlights { get; set; }

        [JsonProperty("SeedlingTray")]
        public string SeedlingTray { get; set; }

        [JsonProperty("SeedlingDispenser")]
        public string SeedlingDispenser { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Rake")]
        public string Rake { get; set; }

        [JsonProperty("MoreDetails")]
        public string MoreDetails { get; set; }

        [JsonProperty("EngineCondition")]
        public string EngineCondition { get; set; }

        [JsonProperty("EngineCondition_text")]
        public string EngineCondition_text { get; set; }

        [JsonProperty("BodyCondition")]
        public string BodyCondition { get; set; }

        [JsonProperty("ColorCondition")]
        public string ColorCondition { get; set; }

        [JsonProperty("DriveSystem")]
        public string DriveSystem { get; set; }

        [JsonProperty("DriveSystem_text")]
        public string DriveSystem_text { get; set; }

        [JsonProperty("TransmissionSystem")]
        public string TransmissionSystem { get; set; }

        [JsonProperty("TransmissionSystem_text")]
        public string TransmissionSystem_text { get; set; }

        [JsonProperty("BrakeSystem")]
        public string BrakeSystem { get; set; }

        [JsonProperty("BrakeSystem_text")]
        public string BrakeSystem_text { get; set; }

        [JsonProperty("ClutchSystem")]
        public string ClutchSystem { get; set; }

        [JsonProperty("ClutchSystem_text")]
        public string ClutchSystem_text { get; set; }

        [JsonProperty("SteeringSystem")]
        public string SteeringSystem { get; set; }

        [JsonProperty("SteeringSystem_text")]
        public string SteeringSystem_text { get; set; }

        [JsonProperty("HydraulicSystem")]
        public string HydraulicSystem { get; set; }

        [JsonProperty("HydraulicSystem_text")]
        public string HydraulicSystem_text { get; set; }

        [JsonProperty("Others")]
        public string Others { get; set; }

        [JsonProperty("Others_text")]
        public string Others_text { get; set; }

        [JsonProperty("TotalCondition")]
        public string TotalCondition { get; set; }

        [JsonProperty("EstimatePrice")]
        public string EstimatePrice { get; set; }

        [JsonProperty("Remark")]
        public string Remark { get; set; }

        [JsonProperty("IMATNumber")]
        public string IMATNumber { get; set; }

        [JsonProperty("ActionLocation")]
        public string ActionLocation { get; set; }

        [JsonProperty("ActionBy")]
        public string ActionBy { get; set; }

        [JsonProperty("ActionUnixTime")]
        public int ActionUnixTime { get; set; }

        [JsonProperty("FrontImage")]
        public string[] FrontImage { get; set; }

        [JsonProperty("LeftImage")]
        public string[] LeftImage { get; set; }

        [JsonProperty("RearImage")]
        public string[] RearImage { get; set; }

        [JsonProperty("RightImage")]
        public string[] RightImage { get; set; }

        [JsonProperty("MileageImage")]
        public string[] MileageImage { get; set; }

        [JsonProperty("LicensePlateImage")]
        public string[] LicensePlateImage { get; set; }

        [JsonProperty("ChassisImage")]
        public string[] ChassisImage { get; set; }

        [JsonProperty("SeatImage")]
        public string[] SeatImage { get; set; }

        [JsonProperty("EngineImage")]
        public string[] EngineImage { get; set; }

        [JsonProperty("KeyImage")]
        public string[] KeyImage { get; set; }

        [JsonProperty("ToolboxImage")]
        public string[] ToolboxImage { get; set; }

        [JsonProperty("AttachedEquimentImage")]
        public string[] AttachedEquimentImage { get; set; }

        [JsonProperty("DamageImage")]
        public string[] DamageImage { get; set; }
    }
    #endregion

    #region StrawBalerRequest
    public class StrawBalerData
    {

        [JsonProperty("FlywheelCover")]
        public string FlywheelCover { get; set; }

        [JsonProperty("StrawCuttingBlade")]
        public string StrawCuttingBlade { get; set; }

        [JsonProperty("Stand")]
        public string Stand { get; set; }

        [JsonProperty("Wheels")]
        public string Wheels { get; set; }

        [JsonProperty("Drawbar")]
        public string Drawbar { get; set; }

        [JsonProperty("StrawReceivingChannel")]
        public string StrawReceivingChannel { get; set; }

        [JsonProperty("UniversalJoint")]
        public string UniversalJoint { get; set; }

        [JsonProperty("UniversalJointSleeve")]
        public string UniversalJointSleeve { get; set; }

        [JsonProperty("StrawPickupFingers")]
        public string StrawPickupFingers { get; set; }

        [JsonProperty("FuelLevel")]
        public string FuelLevel { get; set; }

        [JsonProperty("SteelWheels")]
        public string SteelWheels { get; set; }

        [JsonProperty("Rake")]
        public string Rake { get; set; }

        [JsonProperty("MoreDetails")]
        public string MoreDetails { get; set; }

        [JsonProperty("EngineCondition")]
        public string EngineCondition { get; set; }

        [JsonProperty("EngineCondition_text")]
        public string EngineCondition_text { get; set; }

        [JsonProperty("BodyCondition")]
        public string BodyCondition { get; set; }

        [JsonProperty("ColorCondition")]
        public string ColorCondition { get; set; }

        [JsonProperty("DriveSystem")]
        public string DriveSystem { get; set; }

        [JsonProperty("DriveSystem_text")]
        public string DriveSystem_text { get; set; }

        [JsonProperty("TransmissionSystem")]
        public string TransmissionSystem { get; set; }

        [JsonProperty("TransmissionSystem_text")]
        public string TransmissionSystem_text { get; set; }

        [JsonProperty("BrakeSystem")]
        public string BrakeSystem { get; set; }

        [JsonProperty("BrakeSystem_text")]
        public string BrakeSystem_text { get; set; }

        [JsonProperty("ClutchSystem")]
        public string ClutchSystem { get; set; }

        [JsonProperty("ClutchSystem_text")]
        public string ClutchSystem_text { get; set; }

        [JsonProperty("SteeringSystem")]
        public string SteeringSystem { get; set; }

        [JsonProperty("SteeringSystem_text")]
        public string SteeringSystem_text { get; set; }

        [JsonProperty("HydraulicSystem")]
        public string HydraulicSystem { get; set; }

        [JsonProperty("HydraulicSystem_text")]
        public string HydraulicSystem_text { get; set; }

        [JsonProperty("Others")]
        public string Others { get; set; }

        [JsonProperty("Others_text")]
        public string Others_text { get; set; }

        [JsonProperty("TotalCondition")]
        public string TotalCondition { get; set; }

        [JsonProperty("EstimatePrice")]
        public string EstimatePrice { get; set; }

        [JsonProperty("Remark")]
        public string Remark { get; set; }

        [JsonProperty("IMATNumber")]
        public string IMATNumber { get; set; }

        [JsonProperty("ActionLocation")]
        public string ActionLocation { get; set; }

        [JsonProperty("ActionBy")]
        public string ActionBy { get; set; }

        [JsonProperty("ActionUnixTime")]
        public int ActionUnixTime { get; set; }

        [JsonProperty("FrontImage")]
        public string[] FrontImage { get; set; }

        [JsonProperty("LeftImage")]
        public string[] LeftImage { get; set; }

        [JsonProperty("RearImage")]
        public string[] RearImage { get; set; }

        [JsonProperty("RightImage")]
        public string[] RightImage { get; set; }

        [JsonProperty("MileageImage")]
        public string[] MileageImage { get; set; }

        [JsonProperty("LicensePlateImage")]
        public string[] LicensePlateImage { get; set; }

        [JsonProperty("ChassisImage")]
        public string[] ChassisImage { get; set; }

        [JsonProperty("SeatImage")]
        public string[] SeatImage { get; set; }

        [JsonProperty("EngineImage")]
        public string[] EngineImage { get; set; }

        [JsonProperty("KeyImage")]
        public string[] KeyImage { get; set; }

        [JsonProperty("ToolboxImage")]
        public string[] ToolboxImage { get; set; }

        [JsonProperty("AttachedEquimentImage")]
        public string[] AttachedEquimentImage { get; set; }

        [JsonProperty("DamageImage")]
        public string[] DamageImage { get; set; }
    }
    #endregion

    #region DieselEngineRequest
    public class DieselEngineData
    {

        [JsonProperty("Toolbox")]
        public string Toolbox { get; set; }

        [JsonProperty("Battery")]
        public string Battery { get; set; }

        [JsonProperty("FuelLevel")]
        public string FuelLevel { get; set; }

        [JsonProperty("StarterMotor")]
        public string StarterMotor { get; set; }

        [JsonProperty("AirFilterHousing")]
        public string AirFilterHousing { get; set; }

        [JsonProperty("StarterCrankArm")]
        public string StarterCrankArm { get; set; }

        [JsonProperty("SteelWheels")]
        public string SteelWheels { get; set; }

        [JsonProperty("Rake")]
        public string Rake { get; set; }

        [JsonProperty("MoreDetails")]
        public string MoreDetails { get; set; }

        [JsonProperty("TotalCondition")]
        public string TotalCondition { get; set; }

        [JsonProperty("EstimatePrice")]
        public string EstimatePrice { get; set; }

        [JsonProperty("Remark")]
        public string Remark { get; set; }

        [JsonProperty("IMATNumber")]
        public string IMATNumber { get; set; }

        [JsonProperty("ActionLocation")]
        public string ActionLocation { get; set; }

        [JsonProperty("ActionBy")]
        public string ActionBy { get; set; }

        [JsonProperty("ActionUnixTime")]
        public int ActionUnixTime { get; set; }

        [JsonProperty("FrontImage")]
        public string[] FrontImage { get; set; }

        [JsonProperty("LeftImage")]
        public string[] LeftImage { get; set; }

        [JsonProperty("RearImage")]
        public string[] RearImage { get; set; }

        [JsonProperty("RightImage")]
        public string[] RightImage { get; set; }

        [JsonProperty("MileageImage")]
        public string[] MileageImage { get; set; }

        [JsonProperty("LicensePlateImage")]
        public string[] LicensePlateImage { get; set; }

        [JsonProperty("ChassisImage")]
        public string[] ChassisImage { get; set; }

        [JsonProperty("SeatImage")]
        public string[] SeatImage { get; set; }

        [JsonProperty("EngineImage")]
        public string[] EngineImage { get; set; }

        [JsonProperty("KeyImage")]
        public string[] KeyImage { get; set; }

        [JsonProperty("ToolboxImage")]
        public string[] ToolboxImage { get; set; }

        [JsonProperty("AttachedEquimentImage")]
        public string[] AttachedEquimentImage { get; set; }

        [JsonProperty("DamageImage")]
        public string[] DamageImage { get; set; }
    }
    #endregion

    #region DroneRequest

    public class DroneData
    {

        [JsonProperty("Fan")]
        public string Fan { get; set; }

        [JsonProperty("Battery")]
        public string Battery { get; set; }

        [JsonProperty("Charger")]
        public string Charger { get; set; }

        [JsonProperty("RemoteController")]
        public string RemoteController { get; set; }

        [JsonProperty("Cable")]
        public string Cable { get; set; }

        [JsonProperty("ControlLevers")]
        public string ControlLevers { get; set; }

        [JsonProperty("DigitalDashboard")]
        public string DigitalDashboard { get; set; }

        [JsonProperty("Covers")]
        public string Covers { get; set; }

        [JsonProperty("BatteryCondition")]
        public string BatteryCondition { get; set; }

        [JsonProperty("BatteryCondition_text")]
        public string BatteryCondition_text { get; set; }

        [JsonProperty("BodyCondition")]
        public string BodyCondition { get; set; }

        [JsonProperty("ColorCondition")]
        public string ColorCondition { get; set; }

        [JsonProperty("DriveSystem")]
        public string DriveSystem { get; set; }

        [JsonProperty("DriveSystem_text")]
        public string DriveSystem_text { get; set; }

        [JsonProperty("RemoteControllerSystem")]
        public string RemoteControllerSystem { get; set; }

        [JsonProperty("RemoteControllerSystem_text")]
        public string RemoteControllerSystem_text { get; set; }

        [JsonProperty("ChargingSystem")]
        public string ChargingSystem { get; set; }

        [JsonProperty("ChargingSystem_text")]
        public string ChargingSystem_text { get; set; }

        [JsonProperty("MoreDetails")]
        public string MoreDetails { get; set; }

        [JsonProperty("TotalCondition")]
        public string TotalCondition { get; set; }

        [JsonProperty("EstimatePrice")]
        public string EstimatePrice { get; set; }

        [JsonProperty("Remark")]
        public string Remark { get; set; }

        [JsonProperty("IMATNumber")]
        public string IMATNumber { get; set; }

        [JsonProperty("ActionLocation")]
        public string ActionLocation { get; set; }

        [JsonProperty("ActionBy")]
        public string ActionBy { get; set; }

        [JsonProperty("ActionUnixTime")]
        public int ActionUnixTime { get; set; }

        [JsonProperty("FrontImage")]
        public string[] FrontImage { get; set; }

        [JsonProperty("LeftImage")]
        public string[] LeftImage { get; set; }

        [JsonProperty("RearImage")]
        public string[] RearImage { get; set; }

        [JsonProperty("RightImage")]
        public string[] RightImage { get; set; }

        [JsonProperty("LicensePlateImage")]
        public string[] LicensePlateImage { get; set; }

        [JsonProperty("AttachedEquimentImage")]
        public string[] AttachedEquimentImage { get; set; }

        [JsonProperty("DamageImage")]
        public string[] DamageImage { get; set; }
    }
    #endregion

    //#region Schema
    //public class Schema
    //{
    //    [JsonProperty("id")]
    //    public int id { get; set; }

    //    [JsonProperty("name")]
    //    public string name { get; set; }

    //    [JsonProperty("origin")]
    //    public string origin { get; set; }

    //    [JsonProperty("created_at")]
    //    public string created_at { get; set; }

    //    [JsonProperty("created_by")]
    //    public string created_by { get; set; }

    //    [JsonProperty("key")]
    //    public string key { get; set; }

    //    [JsonProperty("is_deleted")]
    //    public string is_deleted { get; set; }
    //}
    //#endregion

    //#region Template
    //public class Template
    //{
    //    [JsonProperty("id")]
    //    public int id { get; set; }

    //    [JsonProperty("version")]
    //    public string version { get; set; }

    //    [JsonProperty("xml")]
    //    public string xml { get; set; }

    //    [JsonProperty("schema")]
    //    public string schema { get; set; }

    //    [JsonProperty("origin")]
    //    public string origin { get; set; }

    //    [JsonProperty("created_at")]
    //    public string created_at { get; set; }

    //    [JsonProperty("created_by")]
    //    public string created_by { get; set; }

    //    [JsonProperty("key")]
    //    public string key { get; set; }

    //    [JsonProperty("is_deleted")]
    //    public string is_deleted { get; set; }

    //    [JsonProperty("schema_snapshot")]
    //    public string schema_snapshot { get; set; }
    //}
    //#endregion

    //#region SchemaSnapshot
    //public class SchemaSnapshot
    //{
    //    [JsonProperty("id")]
    //    public int id { get; set; }

    //    [JsonProperty("name")]
    //    public string name { get; set; }

    //    [JsonProperty("schema_id")]
    //    public string schema_id { get; set; }

    //    [JsonProperty("created_at")]
    //    public string created_at { get; set; }
    //}
    //#endregion

    //#region InnoMeta
    //public class InnoMeta
    //{
    //    [JsonProperty("schema")]
    //    public Schema schema { get; set; }

    //    [JsonProperty("template")]
    //    public Template template { get; set; }

    //    [JsonProperty("schemaSnapshot")]
    //    public SchemaSnapshot schemaSnapshot { get; set; }
    //}
    //#endregion
}
