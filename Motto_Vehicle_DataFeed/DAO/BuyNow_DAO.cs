using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motto_Vehicle_DataFeed.DAO
{
    public class BuyNowUser
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }

    public class BnBData
    {
        public string ModelActually { get; set; }
        public string StorageLocation { get; set; }
        public DateTime AuctionDate { get; set; }
        public string AuctionResult { get; set; }
        public string Owner { get; set; }
        public bool HasInspect { get; set; }
        public bool HasTitle { get; set; }
        public string SellerId { get; set; }
        public string LocationTH { get; set; }
        public string LocationEN { get; set; }
        public string SellerTH { get; set; }
        public string SellerEN { get; set; }
        public string SellerAddressEN { get; set; }
        public string SellerAddressTH { get; set; }
        public string AuctionLocationEN { get; set; }
        public string AuctionLocationTH { get; set; }
        public string BuyerTH { get; set; }
        public string BuyerEN { get; set; }
        public string BuyerAddressEN { get; set; }
        public string BuyerAddressTH { get; set; }
        public string SellerMobileNumber { get; set; }
        public string Vehicle { get; set; }
        public string SellerRefNo { get; set; }
        public string Registration { get; set; }
        public string DescriptionTH { get; set; }
        public string DescriptionEN { get; set; }
        public string BodyTH { get; set; }
        public string BodyEN { get; set; }
        public string ColourTH { get; set; }
        public string ColourEN { get; set; }
        public string MakeDescTH { get; set; }
        public string MakeDescEN { get; set; }
        public int? DaysInStock { get; set; }
        public string ChasisNumber { get; set; }

        public DateTime? BookedDate { get; set; }
        public DateTime? InspectionDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? RepairedDate { get; set; }

        public string Plant { get; set; }
        public string Year { get; set; }
        public string ModelEN { get; set; }
        public string ModelTH { get; set; }
        public string Variants { get; set; }

        public string VehicleDescTH
        {
            get
            {
                return $"{this.Year} {this.MakeDescTH}";
            }
        }

        public string VehicleDescEN
        {
            get
            {
                return $"{this.Year} {this.MakeDescEN}";
            }
        }

        public DateTime? DateFirstReg { get; set; }

        public string TitleEN
        {
            get
            {
                return string.Format("{0} {1} {2} {3}", this.DateFirstReg.HasValue ? this.DateFirstReg.Value.ToString("yyyy", new System.Globalization.CultureInfo("en-US")) : string.Empty, this.MakeDescEN, this.ModelEN, this.Variants);
            }
        }

        public string TitleTH
        {
            get
            {
                return string.Format("{0} {1} {2} {3}", this.DateFirstReg.HasValue ? this.DateFirstReg.Value.ToString("yyyy", new System.Globalization.CultureInfo("en-US")) : string.Empty, this.MakeDescTH, this.ModelTH, this.Variants);
            }
        }

        public string CatalogueDesc_BU { get; set; }
        public string CatalogueDesc_LO { get; set; }
        public decimal? ManheimPrice { get; set; }
        public decimal? ReBookPrice { get; set; }
        public decimal? PayoutValue { get; set; }
        public decimal? ReservePrice { get; set; }
        public decimal? SoldPrice { get; set; }

        public decimal? Km { get; set; }

        public decimal? VRB { get; set; }
        public decimal? VRP { get; set; }
        public decimal? VP { get; set; }
        public decimal? VMP { get; set; }
        public decimal? VRBP { get; set; }
        public decimal? VPP { get; set; }

        public decimal VR
        {
            get
            {
                if (SoldPrice.HasValue && this.ReservePrice.HasValue)
                {
                    return SoldPrice.Value - this.ReservePrice.Value;
                }

                return 0;
            }
        }

        public decimal VMap
        {
            get
            {
                if (SoldPrice.HasValue)
                {
                    return SoldPrice.Value - this.ManheimPrice.Value;
                }

                return 0;
            }
        }

        public string StateCode { get; set; }
        public string MakeCode { get; set; }
        public string GearEN { get; set; }
        public string DriveCode { get; set; }
        public string FirstFront { get; set; }
        public bool HasVimDoc { get; set; }
        public int ImageCount { get; set; }
        public string SellingCategory { get; set; }
        public string SellingCategoryEN { get; set; }
        public string SellingCategoryTH { get; set; }
        public DateTime? RegExpiry { get; set; }

        public string RegExpire_str { get { return (this.RegExpiry.HasValue ? this.RegExpiry.Value.ToString("dd MMM yyyy") : ""); } }
        public string GearTH { get; set; }
        public string DriveEN { get; set; }
        public string DriveTH { get; set; }
        public string DescriptionEN_Sale { get; set; }
        public string DescriptionTH_Sale { get; set; }
        public string NumberofOwners { get; set; }

        public string Engine { get; set; }
        public string Grade { get; set; }
        public string VehicleNo { get { return int.Parse(Vehicle).ToString(); } }
        public string FuelType { get; set; }
        public decimal? BuyPrice { get; set; }
        public decimal? BidPrice { get; set; }
        public string ToSchedule { get; set; }
        public int? Status { get; set; }
        public string Charges { get; set; }
        public string VehicleDesc_LO { get; set; }
        public int? ViewerCount { get; set; }
    }

    public class AMake
    {
        public string MakeCode { get; set; }
        public string MakeTH { get; set; }
        public string MakeEN { get; set; }
    }
    public class AGear
    {
        public string GearCode { get; set; }
        public string GearTH { get; set; }
        public string GearEN { get; set; }
    }

    public class AModel
    {
        public string Model { get; set; }
        public string MakeCode { get; set; }
    }

    public class BnBBidLog
    {
        public int BidNumber { get; set; }
        public int BnBScheduleDetailID { get; set; }
        public string VehicleNumber { get; set; }
        public string CustomerNumber { get; set; }
        public string Email { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateTime { get; set; }
        public int Status { get; set; }

    }

    public class BnBScheduleDetail
    {
        public int DetailID { get; set; }
        public int ScheduleID { get; set; }
        public string AuctionCode { get; set; }
        public DateTime AuctionDate { get; set; }
        public string VehicleNumber { get; set; }
        public decimal BidPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int Status { get; set; }
    }

    #region VIMImageGallery
    public class VIMImageGallery
    {
        public string Vehicle { get; set; }
        public string SourcePath { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
        public string Chassis { get; set; }
        public string Engine { get; set; }
        public string Plate { get; set; }
        public string Mileage { get; set; }
        public string VehicleKey { get; set; }
        public string Interior { get; set; }
        public string Side { get; set; }
        public string Wheel { get; set; }
        public string Tray { get; set; }
        public string Other { get; set; }
        public string Inspection { get; set; }
        public string TitleBook { get; set; }
        public string BnWPhoto { get; set; }
        public string Damage { get; set; }
        public string OAImages { get; set; }

        public string FirstFrontImage
        {
            get
            {
                string[] strValue = Front.Split(';');
                string strRtn = Front;
                if (strValue.Length > 0)
                {
                    strRtn = strValue[0];
                }
                if (strRtn == "")
                {
                    strRtn = "/App/main/images/default.jpg";
                }
                else
                {
                    strRtn = SourcePath + strRtn;
                }
                return strRtn;
            }
        }

        public List<string> AllImageList
        {
            get
            {
                string strAllValue = (Front != "" ? Front + ";" : "")
                                     + (Back != "" ? Back + ";" : "")
                                     + (Chassis != "" ? Chassis + ";" : "")
                                     + (Engine != "" ? Engine + ";" : "")
                                     + (Plate != "" ? Plate + ";" : "")
                                     + (Mileage != "" ? Mileage + ";" : "")
                                     + (VehicleKey != "" ? VehicleKey + ";" : "")
                                     + (Interior != "" ? Interior + ";" : "")
                                     + (Side != "" ? Side + ";" : "")
                                     + (Wheel != "" ? Wheel + ";" : "")
                                     + (Tray != "" ? Tray + ";" : "")
                                     + (Other != "" ? Other + ";" : "").Trim();
                //+ (TitleBook != "" ? TitleBook + ";" : "")
                List<string> list = strAllValue.Replace(" ", "").Split(';').ToList();
                list.RemoveAll(string.IsNullOrWhiteSpace);

                return list;
            }
        }
    }
    #endregion

    #region VIMImageGallery_Raw
    public class VIMImageGallery_Raw
    {
        public string Vehicle { get; set; }
        public int DocumentID { get; set; }
        public string DocumentDescription_BU { get; set; }
        public string ImagePath { get; set; }
        public int DocumentTypeID { get; set; }
        public string ImageURL { get; set; }
    }
    #endregion
}
