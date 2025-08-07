using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;

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

    #region BookInModel
    public class BookinModel
    {
        public BookinReceiver BookInType { get; set; }
        public Vehicle VehicleType { get; set; }
        public External ExternalType { get; set; }
        public Spare SpareType { get; set; }
        public Cabin CabinType { get; set; }
        public KeyOption KeyOptionType { get; set; }
        public Engine EngineType { get; set; }

    }

    public class BookinReceiver
    {
        public string BookInNumber { get; set; }
        public Nullable<System.DateTime> BookInDate { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string ContractNumber { get; set; }
        public string MobileNumber { get; set; }
        public Nullable<int> Status { get; set; }
        public string SellerCode { get; set; }
        public string Inspector { get; set; }
        public string SenderSignature { get; set; }
        public string ReceiverSignature { get; set; }
        public string VehicleId { get; set; }
        public Nullable<System.DateTime> LatestUpdatedDate { get; set; }
        public string BookinType { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ContractTypeCode { get; set; }
        public string StickVin { get; set; }

    }
    public class Vehicle
    {
        public int VID { get; set; }
        public string VehicleId { get; set; }
        public string BookinNumber { get; set; }
        public string Seller { get; set; }
        public string SellingCategory { get; set; }
        public string LogisticsStatus { get; set; }
        public Nullable<System.DateTime> InspectionDate { get; set; }
        public string SalesStatus { get; set; }
        public string Plant { get; set; }
        public string StorageLocation { get; set; }
        public string ReceiverLocation { get; set; }
        public Nullable<System.DateTime> BookedDate { get; set; }
        public string Make { get; set; }
        public string Make_BU { get; set; }
        public string Make_LO { get; set; }
        public Nullable<int> ModelCodeId { get; set; }
        public string ModelCode { get; set; }
        public string Model_BU { get; set; }
        public string Model_LO { get; set; }
        public string Body { get; set; }
        public string BodyDesc_BU { get; set; }
        public string BodyDesc_LO { get; set; }
        public string Variants { get; set; }
        public string BuildYear { get; set; }
        public string VIN { get; set; }
        public string ChasisNumber { get; set; }
        public string Colour { get; set; }
        public string ColourDesc { get; set; }
        public string FuelDelivery { get; set; }
        public string FuelType { get; set; }
        public string Gearbox { get; set; }
        public string Gears { get; set; }
        public string Drive { get; set; }
        public string EngineNumber { get; set; }
        public Nullable<decimal> EngineCapacity { get; set; }
        public string EngineCapacityUnit { get; set; }
        public string Regisration { get; set; }
        public string RegistrationYear { get; set; }
        public string RegistrationProvince { get; set; }
        public string RegistrationPlate { get; set; }
        public string RegistrationNote { get; set; }
        public Nullable<bool> IsRegistrationMismatch { get; set; }
        public string RedBookCondition { get; set; }
        public Nullable<bool> IsGasTank { get; set; }
        public string GasTankNumber { get; set; }
        public int GasType { get; set; }
        public string GasNote { get; set; }
        public Nullable<bool> IsInValidEngineNumber { get; set; }
        public string ReasonInValidEngineNumber { get; set; }
        public Nullable<bool> IsInValidVinNumber { get; set; }
        public string ReasonInValidVinNumber { get; set; }
        public Nullable<bool> IsInValidGasNumber { get; set; }
        public string ReasonInValidGasNumber { get; set; }
        public Nullable<bool> VehicleDeleted { get; set; }
        public Nullable<System.DateTime> VehicleDeletedDate { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string ModifiedUser { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsNohaveBuildYear { get; set; }
        public Nullable<bool> IsNohaveRegis { get; set; }
        public Nullable<int>  briefCarConditionId { get; set; }
        public string DetallBriefCarCondition { get; set; }
        public string MotorNumber { get; set; }
        public Nullable<bool> IsInValidMotorNumber { get; set; }
        public string ReasonInValidMotorNumber { get; set; }
        public Nullable<bool> IsInVaidEngine1 { get; set; }
        public Nullable<bool> IsInVaidEngine2 { get; set; }
        public Nullable<bool> IsInVaidEngine3 { get; set; }
        public Nullable<bool> IsInVaidVin1 { get; set; }
        public Nullable<bool> IsInVaidVin2 { get; set; }
        public Nullable<bool> IsInVaidVin3 { get; set; }
        public string NoPlateType { get; set; }
        public string CataLogIPAD_TH { get; set; }
        public string CataLogIPAD_EN { get; set; }
        public int CatalyticOption { get; set; }
        public string CabTypeID { get; set; }
        public string LevelCabID { get; set; }
    }
    public class External
    {
        public int ExternalId { get; set; }
        public Nullable<int> GradeOverallId { get; set; }
        public Nullable<int> ColorOverallId { get; set; }
        public Nullable<bool> IsSpoiler { get; set; }
        public Nullable<int> MagWheel { get; set; }
        public Nullable<int> NormalWheel { get; set; }
        public Nullable<bool> IsTyre { get; set; }
        public Nullable<int> TyreQuality { get; set; }
        public string DamageDesc { get; set; }
        public string BookinNumber { get; set; }
        public string TyreBrand { get; set; }
        public Nullable<int> RoofTypeId { get; set; }
    }
    public class Spare
    {
        public int SpareId { get; set; }
        public Nullable<int> SpareOverAllId { get; set; }
        public string SpareNote { get; set; }
        public Nullable<bool> IsSpareType { get; set; }
        public Nullable<bool> IsHandTool { get; set; }
        public Nullable<bool> IsMaxliner { get; set; }
        public Nullable<bool> IsRoofRack { get; set; }
        public Nullable<bool> IsJackCar { get; set; }
        public Nullable<bool> IsCableChargeEV { get; set; }
        public string AccessoriesNote { get; set; }
        public string BookinNumber { get; set; }
    }
    public class Cabin
    {
        public int CabinId { get; set; }
        public int CabinOverAllId { get; set; }
        public Nullable<decimal> Mileage { get; set; }
        public Nullable<int> MileageTypeId { get; set; }
        public Nullable<int> FuelVolumn { get; set; }
        public Nullable<int> GearSystemId { get; set; }
        public Nullable<bool> IsAirback { get; set; }
        public Nullable<bool> IsHeadGear { get; set; }
        public Nullable<bool> IsPowerAmp { get; set; }
        public Nullable<bool> IsLockGear { get; set; }
        public Nullable<bool> IsPreAmp { get; set; }
        public Nullable<bool> IsBookService { get; set; }
        public Nullable<bool> IsSpeaker { get; set; }
        public Nullable<bool> IsManual { get; set; }
        public Nullable<bool> IsCigaretteLiter { get; set; }
        public Nullable<bool> IsTaxPlate { get; set; }
        public string IsPlateExpireDate { get; set; }
        public Nullable<bool> IsNavigator { get; set; }
        public Nullable<bool> IsNavigatorBuiltin { get; set; }
        public Nullable<bool> IsNavigatorCD { get; set; }
        public Nullable<bool> IsNavigatorSDCard { get; set; }
        public Nullable<bool> IsNavigatorNoCD { get; set; }
        public Nullable<bool> IsNavigatorNoSDCard { get; set; }
        public string PlayerBrand { get; set; }
        public Nullable<bool> IsPlayerRadio { get; set; }
        public Nullable<bool> IsPlayerTape { get; set; }
        public Nullable<bool> IsPlayerCD { get; set; }
        public Nullable<bool> IsPlayerUSB { get; set; }
        public Nullable<int> KeyOptionId { get; set; }
        public string CabinNote { get; set; }
        public string BookInNumber { get; set; }
        public Nullable<bool> IsInvalidMileage { get; set; }
        public string InvalidMileageReason { get; set; }
    }
    public class KeyOption
    {
        public int KeyOptionId { get; set; }
        public Nullable<int> NumberOfKey { get; set; }
        public Nullable<int> NumberOfRemote { get; set; }
        public Nullable<int> NumberOfKeyRemote { get; set; }
        public Nullable<int> NumberOfImmobilizer { get; set; }
        public Nullable<int> NumberOfKeyless { get; set; }
        public string BookinNumber { get; set; }
    }
    public class Engine
    {
        public int EngineId { get; set; }
        public Nullable<int> EngineRoomOverAllId { get; set; }
        public string BatteryBrand { get; set; }
        public string BatteryIndicatorColor { get; set; }
        public Nullable<bool> IsEcu { get; set; }
        public Nullable<bool> IsCompressorAir { get; set; }
        public Nullable<int> DriverSystemId { get; set; }
        public Nullable<int> FuelSystemId { get; set; }
        public Nullable<bool> IsFuelGas { get; set; }
        public Nullable<int> GasTypeId { get; set; }
        public string InsideAssetNote { get; set; }
        public string BookinNumber { get; set; }
    }
    #endregion

    public partial class BookIn
    {
        public int BookInId { get; set; }
        public string BookInNumber { get; set; }
        public Nullable<System.DateTime> BookInDate { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string ContractNumber { get; set; }
        public string MobileNumber { get; set; }
        public byte[] SenderSignature { get; set; }
        public byte[] ReceiverSignature { get; set; }
        public Nullable<int> Status { get; set; }
        public string VehicleId { get; set; }
        public string SellerCode { get; set; }
        public string Inspector { get; set; }
        public Nullable<System.DateTime> LatestUpdatedDate { get; set; }
        public string BookinType { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ContractTypeCode { get; set; }
        public byte[] StickVin { get; set; }
    }

    public partial class CarInspection
    {
        public int InspectionId { get; set; }
        public string BookInNumber { get; set; }
        public string VehicleId { get; set; }
        public string Inspector { get; set; }
        public Nullable<System.DateTime> InspectionDate { get; set; }
        public string InspectorName { get; set; }
        public string Chassis { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
        public string RightSide { get; set; }
        public string LeftSide { get; set; }
        public string Roof { get; set; }
        public Nullable<bool> IsFlood { get; set; }
        public string BodySummary { get; set; }
        public Nullable<bool> IsEngineWorks { get; set; }
        public Nullable<int> FuelSystemId { get; set; }
        public Nullable<bool> IsLubricatorLow { get; set; }
        public Nullable<int> EngineSystemId { get; set; }
        public Nullable<int> GearTypeId { get; set; }
        public Nullable<bool> IsUseableGeneral { get; set; }
        public Nullable<bool> IsSoundAbnormal { get; set; }
        public Nullable<bool> IsLeakFuel { get; set; }
        public Nullable<bool> IsStainWater { get; set; }
        public Nullable<bool> IsMachineLightShow { get; set; }
        public Nullable<bool> IsEngineAbnomal { get; set; }
        public Nullable<bool> IsNeedRepair { get; set; }
        public string EngineSummary { get; set; }
        public Nullable<int> DriveShaftConditionId { get; set; }
        public string DriveShaftConditionNote { get; set; }
        public Nullable<int> SuspensionConditionId { get; set; }
        public string SuspensionConditionNote { get; set; }
        public string SuspensionSummary { get; set; }
        public Nullable<int> GearSystemId { get; set; }
        public Nullable<int> GearConditionId { get; set; }
        public Nullable<int> DriveShaftId { get; set; }
        public Nullable<bool> Is4WD { get; set; }
        public string GearSystemSummary { get; set; }
        public Nullable<bool> IsUseableSteerWheel { get; set; }
        public Nullable<bool> IsPowerSteering { get; set; }
        public string SteeringSummary { get; set; }
        public Nullable<bool> IsUseableBrake { get; set; }
        public string BreakSystemSumary { get; set; }
        public Nullable<bool> IsAirCool { get; set; }
        public Nullable<bool> IsCompressorAir { get; set; }
        public string AirSystemSummary { get; set; }
        public Nullable<bool> IsUseableGuage { get; set; }
        public string WarningLightNote { get; set; }
        public string GaugeSummary { get; set; }
        public Nullable<bool> IsFrontLightWorking { get; set; }
        public Nullable<bool> IsTurnLightWorking { get; set; }
        public Nullable<bool> IsBackLightWorking { get; set; }
        public Nullable<bool> IsBrakeLightWoring { get; set; }
        public Nullable<bool> IsBetteryWorking { get; set; }
        public Nullable<bool> IsHooterWorking { get; set; }
        public Nullable<bool> IsRoundGaugeWorking { get; set; }
        public Nullable<bool> IsNavigator { get; set; }
        public Nullable<bool> IsNavigatorBuiltIn { get; set; }
        public Nullable<bool> IsNavigatorCD { get; set; }
        public Nullable<bool> IsNavigatorSdcard { get; set; }
        public Nullable<bool> IsNavigatorNoCD { get; set; }
        public Nullable<bool> IsNavigatorNoSdcard { get; set; }
        public string ElectronicNote { get; set; }
        public string ElectronicSummary { get; set; }
        public Nullable<System.DateTime> LatestUpdatedDate { get; set; }
        public string Regisration { get; set; }
        public string RegistrationProvince { get; set; }
        public Nullable<bool> IsSunroof { get; set; }
        public Nullable<bool> isSideMirror_1_Working { get; set; }
        public Nullable<bool> isSideMirror_2_Working { get; set; }
        public Nullable<bool> isSideMirror_3_Working { get; set; }
        public Nullable<bool> isSideMirror_4_Working { get; set; }
    }

    public class VehicleModel
    {
        public string BookInNumber { get; set; }
      
        public string VehicleId { get; set; }
      
        public string Seller { get; set; }
      
        public string SellingCategory { get; set; }
      
        public string LogisticsStatus { get; set; }
      
        public string SalesStatus { get; set; }
      
        public string Plant { get; set; }
      
        public string Make { get; set; }
      
        public System.DateTime BookedDate { get; set; }
      
        public string EngineCapacityUnit { get; set; }
      
        public string Body { get; set; }
      
        public string Gearbox { get; set; }
      
        public string Gears { get; set; }
      
        public string FuelType { get; set; }
      
        public string FuelDelivery { get; set; }
      
        public string Colour_BU { get; set; }
      
        public string Colour_LO { get; set; }
      
        public Nullable<decimal> EngineCapacity { get; set; }
      
        public string CreateUser { get; set; }
    }

    public class InspectionImageType
    {
        public CarInspectionImage InspectionImage { get; set; }
        public string Base64String { get; set; }

    }

    public partial class CarInspectionImage
    {
        public int ImageId { get; set; }
        public string BookInNumber { get; set; }
        public string VehicleId { get; set; }
        public Nullable<int> ImageTypeId { get; set; }
        public string ImageDescTh { get; set; }
        public string ImageDescEn { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string DamageDesc { get; set; }
        public string DamageSize { get; set; }
        public string DamageType { get; set; }
    }

    public class BookInDataModel
    {
        public Nullable<int> countdown_time { get; set; }
        public string PlantLocation { get; set; }
        public string ContractNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string SellerName { get; set; }
        public string[] PlateImage { get; set; }
        public string DelivererName { get; set; }
        public string StorageLocation { get; set; }
        public string SalesCategory { get; set; }
        public string ReceiveType { get; set; }
        public string ReceiveLocation { get; set; }
        public string ModelCode { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string ChassisNumber { get; set; }
        public string FuelType { get; set; }
        public string EngineSizeUnit { get; set; }
        public string EngineSize { get; set; }
        public string EngineNumber { get; set; }
        public string BodyType { get; set; }
        public string[] TracingPaperImage { get; set; }
        public string EVMotorNumber { get; set; }
        public string EVMotorNumber2 { get; set; }
        public string DrivableCondition { get; set; }
        public string ManufacturingYear { get; set; }
        public string RegistrationYear { get; set; }
        public string Color { get; set; }
        public string LicensePlateNumber { get; set; }
        public string LicenseProvince { get; set; }
        public string TypeofLicensePlate { get; set; }
        public string LicenePlateMatchWithCar { get; set; }
        public string GasInstall { get; set; }
        public string PickupTrayType { get; set; }
        public string Maxliner { get; set; }
        public string V2LEVCable { get; set; }
        public string VehicleRemarks { get; set; }
        public string LicensePlateFBCheck { get; set; }
        public string SpareTire { get; set; }
        public string CarTools { get; set; }
        public string[] CatalyticConverter_image { get; set; }
        public string[] CatalyticConverter_text { get; set; }
        public string CatalyticConverter { get; set; }
        public string EVCharger { get; set; }
        public string TaxSign { get; set; }
        public Nullable<DateTime> TaxExpireDate { get; set; }
        public string[] Dashboard_image { get; set; }
        public string[] Dashboard_text { get; set; }
        public string Dashboard { get; set; }
        public string Mileage { get; set; }
        public string GearType { get; set; }
        public string FuelAmount { get; set; }
        public string DriveSystem { get; set; }
        public string Key { get; set; }
        public string CarManual { get; set; }
        public string ServiceBook { get; set; }
        public string Asset { get; set; }
        public string[] Deliverersign { get; set; }
        public string[] FrontImage { get; set; }
        public string[] FrontLeftImage { get; set; }
        public string[] FrontRightImage { get; set; }
        public string[] BackImage { get; set; }
        public string[] BackLeftImage { get; set; }
        public string[] BackRightImage { get; set; }
    }

    public class InspectionDataModel
    {
        public Nullable<int> countdown_time { get; set; }
        public string DelivererName { get; set; }
        public string IMATNumber { get; set; }
        public string ContractNumber { get; set; }
        public string SalesCategory { get; set; }
        public string ReceiveType { get; set; }
        public string ReceiveLocation { get; set; }
        public string PlantLocation { get; set; }
        public string ModelCode { get; set; }
        public string PhoneNumber { get; set; }
        public string SellerName { get; set; }
        public string[] Deliverersign { get; set; }
        public string[] PlateImage { get; set; }
        public string EngineSizeUnit { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string BodyType { get; set; }
        public string FuelType { get; set; }
        public string EVMotorNumber { get; set; }
        public string EVMotorNumber2 { get; set; }
        public string EngineNumber { get; set; }
        public string ChassisNumber { get; set; }
        public string[] RegistrationYear_image { get; set; }
        public string RegistrationYear { get; set; }
        public string StorageLocation { get; set; }
        public string EngineSize { get; set; }
        public string DrivableCondition { get; set; }
        public string ManufacturingYear { get; set; }
        public string LicenePlateMatchWithCar { get; set; }
        public string Color { get; set; }
        public string LicensePlateNumber { get; set; }
        public string LicenseProvince { get; set; }
        public string[] EngineCompartment { get; set; }
        public string FrontHood { get; set; }
        public string LicensePlateFBCheck { get; set; }
        public string[] CatalyticConverter_image { get; set; }
        public string[] CatalyticConverter_text { get; set; }
        public string CatalyticConverter { get; set; }
        public string FrontPanel { get; set; }
        public string TypeofLicensePlate { get; set; }
        public string[] TracingPaperImage { get; set; }
        public string FrontAbsorbtionBeam_text { get; set; }
        public string FrontAbsorbtionBeam { get; set; }
        public string[] Dipstick_image { get; set; }
        public string[] Dipstick_text { get; set; }
        public string Dipstick { get; set; }
        public string[] FrontDamageImage { get; set; }
        public string FrontInnerPanelR { get; set; }
        public string ABS { get; set; }
        public string FrontPanelL { get; set; }
        public string[] PlateCondition_image { get; set; }
        public string[] PlateCondition_text { get; set; }
        public string PlateCondition { get; set; }
        public string FrontBodyCondition_text { get; set; }
        public string FrontBodyCondition { get; set; }
        public string[] FrontRWheelImage { get; set; }
        public string[] OpenDoorFrontRImage { get; set; }
        public string[] OpenDoorBackRImage { get; set; }
        public string FrontPanelR { get; set; }
        public string[] ChassisNumberCondition_image { get; set; }
        public string[] ChassisNumberCondition_text { get; set; }
        public string ChassisNumberCondition { get; set; }
        public string AirCompressor { get; set; }
        public string FrontInnerPanelL { get; set; }
        public string[] RightDamageImage { get; set; }
        public string[] BackRWheelImage { get; set; }
        public string[] RoofImage { get; set; }
        public string RoofCondition_text { get; set; }
        public string RoofCondition { get; set; }
        public string RoofRacks { get; set; }
        public string[] Dashboard_image { get; set; }
        public string[] Dashboard_text { get; set; }
        public string Dashboard { get; set; }
        public string DoorFrontR { get; set; }
        public string DoorBackRight { get; set; }
        public string RPillars { get; set; }
        public string RightBodyCondition_text { get; set; }
        public string RightBodyCondition { get; set; }
        public string[] EngineNumberCondition_image { get; set; }
        public string[] EngineNumberCondition_text { get; set; }
        public string EngineNumberCondition { get; set; }
        public string Mileage { get; set; }
        public string DriveSystem { get; set; }
        public string SteeringSystem { get; set; }
        public string Hornworking { get; set; }
        public string[] GearType_image { get; set; }
        public string GearType { get; set; }
        public string GearCondition { get; set; }
        public string FuelAmount { get; set; }
        public string Brake { get; set; }
        public string Airbag { get; set; }
        public string Navigator_text { get; set; }
        public string Navigator { get; set; }
        public string SunRoof { get; set; }
        public string Speaker { get; set; }
        public string[] BackSeatsImage { get; set; }
        public string[] ThirdRowSeatsImage { get; set; }
        public string WaterDamage { get; set; }
        public string[] InteriorDamage { get; set; }
        public string[] ConsoleWideImage { get; set; }
        public string WindowFrontR { get; set; }
        public string WindowFrontL { get; set; }
        public string ServiceBook { get; set; }
        public string WindowBackL { get; set; }
        public string[] TaxSign_image { get; set; }
        public string TaxSign { get; set; }
        public string[] Key_image { get; set; }
        public string[] Key_text { get; set; }
        public string Key { get; set; }
        public string[] TrunkTray { get; set; }
        public string WindowBackR { get; set; }
        public string CarManual { get; set; }
        public string InteriorConditionSummary { get; set; }
        public Nullable<DateTime> TaxExpireDate { get; set; }
        public string[] SpareTire_image { get; set; }
        public string[] SpareTire_text { get; set; }
        public string SpareTire { get; set; }
        public string PickupTrayType { get; set; }
        public string[] GasInstall_image { get; set; }
        public string[] GasInstall_text { get; set; }
        public string GasInstall { get; set; }
        public string[] V2LEVCable_image { get; set; }
        public string V2LEVCable { get; set; }
        public string TailLightsWorking { get; set; }
        public string KeyCardNFC { get; set; }
        public string[] CarTools_image { get; set; }
        public string CarTools { get; set; }
        public string[] EVCharger_image { get; set; }
        public string EVCharger { get; set; }
        public string BackPanel { get; set; }
        public string Maxliner { get; set; }
        public string Brakelightsworking { get; set; }
        public string[] BackDamageImage { get; set; }
        public string BackAbsorbtionBeam { get; set; }
        public string TrunkFloor { get; set; }
        public string BackPanelR { get; set; }
        public string BackPanelL { get; set; }
        public string BackInnerPanelR { get; set; }
        public string DoorFrontL { get; set; }
        public string LPillars { get; set; }
        public string[] LeftDamageImage { get; set; }
        public string[] OpenDoorBackLImage { get; set; }
        public string[] OpenDoorFrontLImage { get; set; }
        public string BackInnerPanelL { get; set; }
        public string BackBodyCondition_text { get; set; }
        public string BackBodyCondition { get; set; }
        public string DoorBackL { get; set; }
        public string BodyLCondition_text { get; set; }
        public string BodyLCondition { get; set; }
        public string[] FogLights { get; set; }
        public string[] DayTimeRunningLights { get; set; }
        public string Turnlights { get; set; }
        public string EngineCondition_text { get; set; }
        public string EngineCondition { get; set; }
        public string EngineConditionSummary { get; set; }
        public string[] Aircondition_image { get; set; }
        public string[] Aircondition_text { get; set; }
        public string Aircondition { get; set; }
        public string HeadlightsWorking { get; set; }
        public string StructureAndBodyRemarks { get; set; }
        public string DriveShaft { get; set; }
        public string SuspensionModification_text { get; set; }
        public string SuspensionModification { get; set; }
        public string VehicleRemarks { get; set; }
        public string ChassisCondition_text { get; set; }
        public string ChassisCondition { get; set; }
        public string DriveShaftGear { get; set; }
        public string[] OtherDamageImage { get; set; }
        public string[] OtherAccessories { get; set; }
        public string Suspension { get; set; }
        public string gradeCalculation { get; set; }
        public string Make { get; set; }
        public string[] FrontImage { get; set; }
        public string[] FrontLeftImage { get; set; }
        public string[] FrontRightImage { get; set; }
        public string[] BackImage { get; set; }
        public string[] BackLeftImage { get; set; }
        public string[] BackRightImage { get; set; }
    }

    public class CarBookInDataModel
    {
        public string DelivererName { get; set; }
        public string[] Deliverersign { get; set; }
        public string PhoneNumber { get; set; }
        public string ReceiveLocation { get; set; }
        public string SellerName { get; set; }
        public string SalesCategory { get; set; }
        public string ContractType { get; set; }
        public string[] ReceiverSign { get; set; }
        public string FuelType { get; set; }
        public string EngineSizeUnit { get; set; }
        public string ModelCode { get; set; }
        public string EngineNumber { get; set; }
        public string ChassisNumber { get; set; }
        public string Variant { get; set; }
        public string BodyType { get; set; }
        public string ContractNumber { get; set; }
        public string ManufacturingYear { get; set; }
        public string EngineSize { get; set; }
        public string RegistrationYear { get; set; }
        public string Model { get; set; }
        public string EVMotorNumber { get; set; }
        public string EVMotorNumber2 { get; set; }
        public string TypeofLicensePlate { get; set; }
        public string LicenePlateMatchWithCar { get; set; }
        public string[] RegistrationYearCheck_image { get; set; }
        public string RegistrationYearCheck { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
        public string PickupRideLevel { get; set; }
        public string LicenseProvince { get; set; }
        public string[] CatalyticConverter_image { get; set; }
        public string[] CatalyticConverter_text { get; set; }
        public string CatalyticConverter { get; set; }
        public string[] PlateImage { get; set; }
        public string LicensePlateFBCheck { get; set; }
        public string PickupTrayType { get; set; }
        public string PickupCabType { get; set; }
        public string LicensePlateNumber { get; set; }
        public string EVCharger { get; set; }
        public string DrivableCondition { get; set; }
        public string VehicleBookinRemarks { get; set; }
        public string[] Dashboard_image { get; set; }
        public string[] Dashboard_text { get; set; }
        public string Dashboard { get; set; }
        public string FuelAmount { get; set; }
        public string Mileage { get; set; }
        public string V2LEVCable { get; set; }
        public string Maxliner { get; set; }
        public string[] TaxSign_image { get; set; }
        public string TaxSign { get; set; }
        public Nullable<DateTime> TaxExpireDate { get; set; }
        public string[] GasInstall_image { get; set; }
        public string[] GasInstall_text { get; set; }
        public string GasInstall { get; set; }
        public string SpareTire { get; set; }
        public string Asset { get; set; }
        public string[] GearType_image { get; set; }
        public string GearType { get; set; }
        public string DriveSystem { get; set; }
        public string[] Key_image { get; set; }
        public string[] Key_text { get; set; }
        public string Key { get; set; }
        public string KeyCardNFC { get; set; }
        public string CarManual { get; set; }
        public string ServiceBook { get; set; }
        public string CarTools { get; set; }
        public string[] TracingPaperImage { get; set; }
        public Nullable<int> countdown_time { get; set; }
        public string[] FrontImage { get; set; }
        public string[] FrontLeftImage { get; set; }
        public string[] FrontRightImage { get; set; }
        public string[] BackImage { get; set; }
        public string[] BackLeftImage { get; set; }
        public string[] BackRightImage { get; set; }
    }

    public class CarInspectionDataModel
    {
        public string DelivererName { get; set; }
        public string IMATNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string SellerName { get; set; }
        public string ReceiveLocation { get; set; }
        public string SalesCategory { get; set; }
        public string Variant { get; set; }
        public string[] Deliverersign { get; set; }
        public string ContractNumber { get; set; }
        public string EngineSizeUnit { get; set; }
        public string ModelCode { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ReceiveType { get; set; }
        public string BodyType { get; set; }
        public string EVMotorNumber2 { get; set; }
        public string[] PlateImage { get; set; }
        public string ManufacturingYear { get; set; }
        public string EngineNumber { get; set; }
        public string Color { get; set; }
        public string LicensePlateNumber { get; set; }
        public string EVMotorNumber { get; set; }
        public string FuelType { get; set; }
        public string DrivableCondition { get; set; }
        public string LicensePlateFBCheck { get; set; }
        public string[] CatalyticConverter_image { get; set; }
        public string[] CatalyticConverter_text { get; set; }
        public string CatalyticConverter { get; set; }
        public string ChassisNumber { get; set; }
        public string[] FrontDamageImage { get; set; }
        public string LicenseProvince { get; set; }
        public string[] Dipstick_image { get; set; }
        public string[] Dipstick_text { get; set; }
        public string Dipstick { get; set; }
        public string FrontBodyCondition_text { get; set; }
        public string FrontBodyCondition { get; set; }
        public string EngineSize { get; set; }
        public Nullable<int> RegistrationYear { get; set; }
        public string Asset { get; set; }
        public string[] TracingPaperImage { get; set; }
        public string[] ChassisNumberCondition_image { get; set; }
        public string[] ChassisNumberCondition_text { get; set; }
        public string ChassisNumberCondition { get; set; }
        public string FrontBodyRemarks { get; set; }
        public string LicenePlateMatchWithCar { get; set; }
        public string[] OpenDoorFrontRImage { get; set; }
        public string ABS { get; set; }
        public string[] EngineNumberCondition_image { get; set; }
        public string[] EngineNumberCondition_text { get; set; }
        public string EngineNumberCondition { get; set; }
        public string[] PlateCondition_image { get; set; }
        public string[] PlateCondition_text { get; set; }
        public string PlateCondition { get; set; }
        public string[] EngineCompartment { get; set; }
        public string TypeofLicensePlate { get; set; }
        public string[] FrontRWheelImage { get; set; }
        public string RightBodyCondition_text { get; set; }
        public string RightBodyCondition { get; set; }
        public string[] OpenDoorBackRImage { get; set; }
        public string[] BackRWheelImage { get; set; }
        public string[] Dashboard_image { get; set; }
        public string[] Dashboard_text { get; set; }
        public string Dashboard { get; set; }
        public string WarningLight { get; set; }
        public string RoofRacks { get; set; }
        public string FuelAmount { get; set; }
        public string AirCompressor { get; set; }
        public string RightBodyRemarks { get; set; }
        public string[] GearType_image { get; set; }
        public string GearType { get; set; }
        public string[] RoofImage { get; set; }
        public string RoofCondition_text { get; set; }
        public string RoofCondition { get; set; }
        public Nullable<int> Mileage { get; set; }
        public string[] RightDamageImage { get; set; }
        public string SteeringSystem_text { get; set; }
        public string SteeringSystem { get; set; }
        public string Hornworking { get; set; }
        public string RoofBodyRemarks { get; set; }
        public string WindowFrontR { get; set; }
        public string DriveSystem { get; set; }
        public string Brake_text { get; set; }
        public string Brake { get; set; }
        public string Airbag { get; set; }
        public string Navigator { get; set; }
        public string SunRoof { get; set; }
        public string[] BackSeatsImage { get; set; }
        public string[] ThirdRowSeatsImage { get; set; }
        public string WaterDamage { get; set; }
        public string WindowBackR { get; set; }
        public string InteriorConditionRemarks { get; set; }
        public string[] ConsoleWideImage { get; set; }
        public string[] CarRadioMultimediaImage { get; set; }
        public string Speaker { get; set; }
        public string GearCondition { get; set; }
        public string ServiceBook { get; set; }
        public string CarManual { get; set; }
        public string WindowBackL { get; set; }
        public string SteeringSystemRemarks { get; set; }
        public string InteriorGrade { get; set; }
        public string[] Key_image { get; set; }
        public string[] Key_text { get; set; }
        public string Key { get; set; }
        public string[] GasInstall_image { get; set; }
        public string[] GasInstall_text { get; set; }
        public string GasInstall { get; set; }
        public string WindowFrontL { get; set; }
        public string SpareTire { get; set; }
        public string CarTools { get; set; }
        public string TaxExpireDate { get; set; }
        public string V2LEVCable { get; set; }
        public string PickupTrayType { get; set; }
        public string KeyCardNFC { get; set; }
        public string Maxliner { get; set; }
        public string[] InteriorDamage { get; set; }
        public string[] TaxSign_image { get; set; }
        public string TaxSign { get; set; }
        public string EVCharger { get; set; }
        public string[] BackLWheelImage { get; set; }
        public string TailLightsWorking { get; set; }
        public string[] OpenDoorFrontLImage { get; set; }
        public string[] BackDamageImage { get; set; }
        public string[] FrontLWheelImage { get; set; }
        public string LeftBodyRemarks { get; set; }
        public string[] LeftDamageImage { get; set; }
        public string[] TrunkTray { get; set; }
        public string Turnlights { get; set; }
        public string[] EngineCondition_image { get; set; }
        public string EngineCondition { get; set; }
        public string LeftBodyCondition_text { get; set; }
        public string LeftBodyCondition { get; set; }
        public string[] Aircondition_image { get; set; }
        public string[] Aircondition_text { get; set; }
        public string Aircondition { get; set; }
        public string BackBodyRemarks { get; set; }
        public string HeadlightsWorking { get; set; }
        public string[] DayTimeRunningLights { get; set; }
        public string[] OpenDoorBackLImage { get; set; }
        public string Brakelightsworking { get; set; }
        public string EngineConditionRemarks { get; set; }
        public string BackBodyCondition_text { get; set; }
        public string BackBodyCondition { get; set; }
        public string ChassisCondition { get; set; }
        public string StructureAndBodyRemarks { get; set; }
        public string DriveShaftGear { get; set; }
        public string DriveShaft { get; set; }
        public string SuspensionModification { get; set; }
        public string[] Suspension_image { get; set; }
        public string[] Suspension_text { get; set; }
        public string Suspension { get; set; }
        public string[] ChassisDamageImage { get; set; }
        public string AirConditionRemarks { get; set; }
        public string[] FogLights { get; set; }
        public string[] OtherDamageImage { get; set; }
        public string[] OtherAccessories { get; set; }
        public string StructureGrade { get; set; }
        public string EngineGrade { get; set; }
        public string OverallGrading { get; set; }
        public string ContractType { get; set; }
        public string[] ReceiverSign { get; set; }
        public string[] RegistrationYearCheck_image { get; set; }
        public string RegistrationYearCheck { get; set; }
        public string PickupRideLevel { get; set; }
        public string PickupCabType { get; set; }
        public string VehicleBookinRemarks { get; set; }
        public int countdown_time { get; set; }
        public string[] FrontImage { get; set; }
        public string[] FrontLeftImage { get; set; }
        public string[] FrontRightImage { get; set; }
        public string[] BackImage { get; set; }
        public string[] BackLeftImage { get; set; }
        public string[] BackRightImage { get; set; }
    }

    public class MBBookInDataModel
    {
        public string DelivererName { get; set; }
        public string Make { get; set; }
        public string SellerName { get; set; }
        public string Variant { get; set; }
        public string BodyType { get; set; }
        public string[] ReceiverSign { get; set; }
        public string ModelCode { get; set; }
        public string ContractNumber { get; set; }
        public string EngineNumber { get; set; }
        public string ChassisNumber { get; set; }
        public string ReceiveLocation { get; set; }
        public string DrivableCondition { get; set; }
        public string FuelType { get; set; }
        public Nullable<int> ManufacturingYear { get; set; }
        public string EngineSize { get; set; }
        public string RegistrationYear { get; set; }
        public string TypeofLicensePlate { get; set; }
        public string EVMotorNumber { get; set; }
        public string[] GearType_image { get; set; }
        public string GearType { get; set; }
        public string ManufacturingYearCheck { get; set; }
        public string EngineSizeUnit { get; set; }
        public string[] RegistrationYearCheck_image { get; set; }
        public string RegistrationYearCheck { get; set; }
        public string LicensePlateCheck { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string SalesCategory { get; set; }
        public string[] Dashboard_image { get; set; }
        public string[] Dashboard_text { get; set; }
        public string Dashboard { get; set; }
        public Nullable<DateTime> TaxExpireDate { get; set; }
        public string FuelAmount { get; set; }
        public string[] Key_image { get; set; }
        public string[] Key_text { get; set; }
        public string Key { get; set; }
        public string RegistrationNumber { get; set; }
        public string LicenseProvince { get; set; }
        public string LicenePlateMatchWithCar { get; set; }
        public string[] TaxSign_image { get; set; }
        public string TaxSign { get; set; }
        public string Mileage { get; set; }
        public string VehicleRemarks { get; set; }
        public string PhoneNumber { get; set; }
        public string CarManual { get; set; }
        public string ServiceBook { get; set; }
        public string CarTools { get; set; }
        public string EVCharger { get; set; }
        public Nullable<int> countdown_time { get; set; }
    }


    public class MBInspectionDataModel
    {
        public string DelivererName { get; set; }
        public string ModelCode { get; set; }
        public string SellerName { get; set; }
        public string Model { get; set; }
        public string ReceiveLocation { get; set; }
        public string SalesCategory { get; set; }
        public string FuelType { get; set; }
        public string IMATNumber { get; set; }
        public string EngineSize { get; set; }
        public string Make { get; set; }
        public string ContractNumber { get; set; }
        public string Variant { get; set; }
        public string BodyType { get; set; }
        public string[] ReceiverSign { get; set; }
        public string EngineSizeUnit { get; set; }
        public string RegistrationYearCheck { get; set; }
        public string EngineNumber { get; set; }
        public string ChassisNumber { get; set; }
        public string EVMotorNumber { get; set; }
        public string Color { get; set; }
        public string DrivableCondition { get; set; }
        public string ManufacturingYear { get; set; }
        public string TypeofLicensePlate { get; set; }
        public string RegistrationYear { get; set; }
        public string[] GearType_image { get; set; }
        public string GearType { get; set; }
        public string[] Dashboard_image { get; set; }
        public string[] Dashboard_text { get; set; }
        public string Dashboard { get; set; }
        public string Mileage { get; set; }
        public string VehicleRemarks { get; set; }
        public string LicensePlateCheck { get; set; }
        public string CarManual { get; set; }
        public string RegistrationNumber { get; set; }
        public string CarTools { get; set; }
        public string[] TaxSign_image { get; set; }
        public string TaxSign { get; set; }
        public string TaxExpireDate { get; set; }
        public string FuelAmount { get; set; }
        public string[] HeadLightRemarks_image { get; set; }
        public string[] HeadLightRemarks_text { get; set; }
        public string HeadLightRemarks { get; set; }
        public string TurnLightFrontL { get; set; }
        public string TurnLightFrontR_text { get; set; }
        public string TurnLightFrontR { get; set; }
        public string DiskBrakeOilCanister_text { get; set; }
        public string DiskBrakeOilCanister { get; set; }
        public string EVCharger { get; set; }
        public string Mask { get; set; }
        public string HeadLight { get; set; }
        public string[] Key_image { get; set; }
        public string[] Key_text { get; set; }
        public string Key { get; set; }
        public string PhoneNumber { get; set; }
        public string ServiceBook { get; set; }
        public string FrontTire_text { get; set; }
        public string FrontTire { get; set; }
        public string FrontBrake_text { get; set; }
        public string FrontBrake { get; set; }
        public string HandClutchL_text { get; set; }
        public string HandClutchL { get; set; }
        public string ShockAbsorber_text { get; set; }
        public string ShockAbsorber { get; set; }
        public string Cub_text { get; set; }
        public string Cub { get; set; }
        public string HandBrakeR_text { get; set; }
        public string HandBrakeR { get; set; }
        public string[] FrontDamageImage { get; set; }
        public string LicenseProvince { get; set; }
        public string HandBrakeL_text { get; set; }
        public string HandBrakeL { get; set; }
        public string FrontDiskBrakePump { get; set; }
        public string FrontRFootRest_text { get; set; }
        public string FrontRFootRest { get; set; }
        public string RearRFootRest_text { get; set; }
        public string RearRFootRest { get; set; }
        public string FrontFender_text { get; set; }
        public string FrontFender { get; set; }
        public string[] FrontWheel_image { get; set; }
        public string[] FrontWheel_text { get; set; }
        public string FrontWheel { get; set; }
        public string SideRight_text { get; set; }
        public string SideRight { get; set; }
        public string[] RightDamageImage { get; set; }
        public string StartPedal { get; set; }
        public string[] GasTank_image { get; set; }
        public string[] GasTank_text { get; set; }
        public string GasTank { get; set; }
        public string UBox_text { get; set; }
        public string UBox { get; set; }
        public string PipeCover_text { get; set; }
        public string PipeCover { get; set; }
        public string ExhaustPipe_text { get; set; }
        public string ExhaustPipe { get; set; }
        public string WindshieldR_text { get; set; }
        public string WindshieldR { get; set; }
        public string UtilityCompartmentR { get; set; }
        public string[] Seat_image { get; set; }
        public string[] Seat_text { get; set; }
        public string Seat { get; set; }
        public string SideMirrorL_text { get; set; }
        public string SideMirrorL { get; set; }
        public string SeatIronFrame_text { get; set; }
        public string SeatIronFrame { get; set; }
        public string TailLight_text { get; set; }
        public string TailLight { get; set; }
        public string Tools { get; set; }
        public string Battery { get; set; }
        public string CDIBox { get; set; }
        public string DoubleStand { get; set; }
        public string RearShockAbsorber { get; set; }
        public string[] MiddleDamageImage { get; set; }
        public string[] EngineNumberImageAndCondition_image { get; set; }
        public string EngineNumberImageAndCondition { get; set; }
        public string[] ChassisNumberImageAndCondition_image { get; set; }
        public string ChassisNumberImageAndCondition { get; set; }
        public string RearWheel { get; set; }
        public string RearBrake { get; set; }
        public string RearFender_text { get; set; }
        public string RearFender { get; set; }
        public string SideLeft { get; set; }
        public string BackDiskBrakePumpCondition_text { get; set; }
        public string BackDiskBrakePumpCondition { get; set; }
        public string SideMirrorR { get; set; }
        public string TurnLightRearR_text { get; set; }
        public string TurnLightRearR { get; set; }
        public string FrontLFootRest { get; set; }
        public string RearTire_text { get; set; }
        public string RearTire { get; set; }
        public string[] BackDamageImage { get; set; }
        public string RearBrakeCanister_text { get; set; }
        public string RearBrakeCanister { get; set; }
        public string ConditionRemarks { get; set; }
        public string ChainGuard_text { get; set; }
        public string ChainGuard { get; set; }
        public string OverallGrading { get; set; }
        public string ManufacturingYearCheck { get; set; }
        public string LicenePlateMatchWithCar { get; set; }
        public Nullable<int> countdown_time { get; set; }
        public string[] FrontImage { get; set; }
        public string[] FrontLImage { get; set; }
        public string[] FrontRImage { get; set; }
        public string[] BackImage { get; set; }
        public string[] BackLImage { get; set; }
        public string[] BackRImage { get; set; }
        public string SingleStand_text { get; set; }
        public string SingleStand { get; set; }
        public string WindShieldL { get; set; }
        public string[] LeftDamageImage { get; set; }
        public string UtilityCompartmentL_text { get; set; }
        public string UtilityCompartmentL { get; set; }
        public string[] OtherDamageImage { get; set; }
        public string RearLFootRest_text { get; set; }
        public string RearLFootRest { get; set; }
        public string TurnLightRearL_text { get; set; }
        public string TurnLightRearL { get; set; }
    }

    public class MotorbikeInspectionCatalogModel
    {
        public string[] ChassisNumberImageAndCondition_image { get; set; }
        public string[] EngineNumberImageAndCondition_image { get; set; }
        public string RearBrake { get; set; }
        public string FrontBrake { get; set; }
        public string GasTank { get; set; }
        public string[] HeadLightRemarks_image { get; set; }
        public string HandBrakeR { get; set; }
        public string SideMirrorR { get; set; }
        public string SideMirrorL { get; set; }
        public string HandBrakeL { get; set; }
        public string SingleStand { get; set; }
        public string Mask { get; set; }
        public string RearFender { get; set; }
        public string ExhaustPipe { get; set; }
        public string ChainGuard { get; set; }
        public string RearShockAbsorber { get; set; }
        public string RearBrakeCanister { get; set; }
        public string DiskBrakeOilCanister { get; set; }
        public string SeatIronFrame { get; set; }
        public string WindShieldL { get; set; }
        public string HandClutchL { get; set; }
        public string FrontFender { get; set; }
        public string StartPedal { get; set; }
        public string ShockAbsorber { get; set; }
        public string DoubleStand { get; set; }
        public string PipeCover { get; set; }
        public string Cub { get; set; }
        public string WindshieldR { get; set; }
        public string RearTire { get; set; }
        public string FrontTire { get; set; }
        public string TailLight { get; set; }
        public string UBox { get; set; }
        public string UtilityCompartmentR { get; set; }
        public string UtilityCompartmentL { get; set; }
        public string Color { get; set; }
        public string TypeofLicensePlate { get; set; }
        public string LicensePlateCheck { get; set; }
        public string EngineNumberImageAndCondition { get; set; }
        public string ChassisNumberImageAndCondition { get; set; }
        public string EVCharger { get; set; }
        public string Mileage { get; set; }
        public string LicenePlateMatchWithCar { get; set; }
        public string LicensePlateNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string Dashboard { get; set; }
        public string FrontWheel { get; set; }
        public string RearWheel { get; set; }
        public string FrontDiskBrakePump { get; set; }
        public string FrontDiskBrakePumpCondition { get; set; }
        public string BackDiskBrakePump { get; set; }
        public string BackDiskBrakePumpCondition { get; set; }
        public string TurnLightFrontR { get; set; }
        public string TurnLightRearL { get; set; }
        public string TurnLightRearR { get; set; }
        public string TurnLightFrontL { get; set; }
        public string RearLFootRest { get; set; }
        public string RearRFootRest { get; set; }
        public string FrontLFootRest { get; set; }
        public string FrontRFootRest { get; set; }
        public string SideLeft { get; set; }
        public string SideRight { get; set; }
        public string GearType { get; set; }
        public string StartSystem { get; set; }
        public string Key { get; set; }
    }

    public class CarInspectionCatalogModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string ChassisNumber { get; set; }
        public string DrivableCondition { get; set; }
        public string RegistrationYear { get; set; }
        public string LicensePlateNumber { get; set; }
        public string LicensePlateFBCheck { get; set; }
        public string LicenePlateMatchWithCar { get; set; }
        public string TypeofLicensePlate { get; set; }
        public string Color { get; set; }
        public string TaxExpireDate { get; set; }
        public string Mileage { get; set; }
        public string PlateCondition { get; set; }
        public string EngineNumberCondition { get; set; }
        public string Key { get; set; }
        public string WarningLight { get; set; }
        public string GearType { get; set; }
        public string Airbag { get; set; }
        public string WaterDamage { get; set; }
        public string ChassisNumberCondition { get; set; }
        public string GasInstall { get; set; }
        public string EngineCondition { get; set; }
        public string EngineConditionRemarks { get; set; }
        public string ChassisCondition { get; set; }
        public string VehicleGroup { get; set; }
        public string StructureGrade { get; set; }
        public string EngineGrade { get; set; }
        public string IntreiorGrade { get; set; }
    }

    public class SalvageInspectionCatalogModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string LicensePlateFBCheck { get; set; }
        public string LicenePlateMatchWithCar { get; set; }
        public string TypeofLicensePlate { get; set; }
        public string TaxExpireDate { get; set; }
        public string PlateCondition { get; set; }
        public string EngineNumberCondition { get; set; }
        public string GearType { get; set; }
        public string WaterDamage { get; set; }
        public string ChassisNumberCondition { get; set; }
        public string GasInstall { get; set; }
        public string FuelType { get; set; }
     
    }
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
