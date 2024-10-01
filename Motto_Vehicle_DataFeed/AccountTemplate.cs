using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Motto_Vehicle_DataFeed
{
    public class Account_RECONCILIATION
    {
        #region Account_RECONCILIATION
        public Account_RECONCILIATION()
        { 

        }
        #endregion

        #region getExcelComponent
        public ExcelPackage getExcelComponent(List<Account_Reconciliation_Template> dataTemplate)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage();
            
            for (int i = 0; i < dataTemplate.Count; i++)
            {
                string strSheetName = (dataTemplate[i].SellerCode == "" ? dataTemplate[i].SellerName : dataTemplate[i].SellerCode);
                // Add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(strSheetName);
                // Select the entire sheet
                var cells = worksheet.Cells;

                // Define the font settings
                var font = cells.Style.Font;
                font.Name = "Arial";            // Set font name
                font.Size = 10;

                worksheet.Cells[2, 3].Value = "Motto Auction (Thailand) Company Limited.";
                worksheet.Cells["C2:D2"].Merge = true;
                worksheet.Cells["C2:D2"].Style.Font.Bold = true;
                worksheet.Cells["C2:D2"].Style.Font.Size = 10;
                worksheet.Cells["C2:D2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["C2:D2"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                // Header
                worksheet.Cells[2, 11].Value = "Date";
                worksheet.Cells[3, 11].Value = "Place";
                worksheet.Cells[4, 11].Value = "Auction Code";
                worksheet.Cells[5, 11].Value = "Time";

                worksheet.Cells["K2:K5"].Style.Font.Bold = true;
                worksheet.Cells["K2:K5"].Style.Font.Size = 10;
                worksheet.Cells["K2:K5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                worksheet.Cells["K2:K5"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;                

                worksheet.Cells[2, 12].Value = dataTemplate[i].AuctionDate;
                worksheet.Cells[3, 12].Value = dataTemplate[i].Place;
                worksheet.Cells[4, 12].Value = (dataTemplate[i].AuctionCode.Length > 2 ? dataTemplate[i].AuctionCode.Substring(2) : dataTemplate[i].AuctionCode);
                worksheet.Cells[5, 12].Value = dataTemplate[i].Time;

                worksheet.Cells[4, 25].Value = "RECONCILIATION";
                worksheet.Cells[5, 25].Value = dataTemplate[i].SellerName;


                // Detail
                // Detail Header
                worksheet.Cells[8, 1].Value = "No";
                worksheet.Cells[8, 2].Value = "IMAT";
                worksheet.Cells[8, 3].Value = "Seller";
                worksheet.Cells[8, 4].Value = "No. Buyer";
                worksheet.Cells[8, 5].Value = "Bid No.";

                worksheet.Cells[8, 6].Value = "Lot";
                worksheet.Cells[8, 7].Value = "Seller Ref";
                worksheet.Cells[8, 8].Value = "Reg No.";
                worksheet.Cells[8, 9].Value = "Year";
                worksheet.Cells[8, 10].Value = "Make";

                worksheet.Cells[8, 11].Value = "ModelDesc";
                worksheet.Cells[8, 12].Value = "Variants";
                worksheet.Cells[8, 13].Value = "Reserve Price";
                worksheet.Cells[8, 14].Value = "SoldPrice (Include.vat)";
                worksheet.Cells[8, 15].Value = "Variance";

                worksheet.Cells[8, 16].Value = "% to reserve";
                worksheet.Cells[8, 17].Value = "SoldPrice (EXclude.vat)";
                worksheet.Cells[8, 18].Value = "Vehicle VAT";

                worksheet.Cells[8, 19].Value = "Selling Fee";
                worksheet.Cells[8, 20].Value = "Detailing";
                worksheet.Cells[8, 21].Value = "inspection";
                worksheet.Cells[8, 22].Value = "Sub Total";
                worksheet.Cells[8, 23].Value = "Services VAT";
                worksheet.Cells[8, 24].Value = "WH Tax 3%";
                worksheet.Cells[8, 25].Value = "Total";

                worksheet.Row(8).Height = 34;

                int pointerForData = 9;
                string customFormat = "_-* #,##0.00_-;-* #,##0.00_-;_-* \"-\"??_-;_-@_-";
                int rowIndex = 1;
                string PreviousBidNo = "";
                int buyerIndex = 1;
                // Detail Data
                for (int j = 0; j < dataTemplate[i].details.Count; j++)
                {
                    int currentRow = pointerForData + j;
                    worksheet.Cells[currentRow, 1].Value = (rowIndex + j).ToString();//dataTemplate[i].details[j].ID.ToString();
                    worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[currentRow, 2].Value = dataTemplate[i].details[j].IMAP.ToString();
                    worksheet.Cells[currentRow, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[currentRow, 3].Value = dataTemplate[i].details[j].Seller;
                    worksheet.Cells[currentRow, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    if (dataTemplate[i].details[j].BidNo == PreviousBidNo)
                    {
                        dataTemplate[i].details[j].NoOfBuyer = "";
                    }
                    else
                    {
                        dataTemplate[i].details[j].NoOfBuyer = buyerIndex.ToString();
                        PreviousBidNo = dataTemplate[i].details[j].BidNo;
                        buyerIndex++;
                    }
                    worksheet.Cells[currentRow, 4].Value = dataTemplate[i].details[j].NoOfBuyer;
                    worksheet.Cells[currentRow, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[currentRow, 5].Value = dataTemplate[i].details[j].BidNo;
                    worksheet.Cells[currentRow, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[currentRow, 6].Value = dataTemplate[i].details[j].Lot;
                    worksheet.Cells[currentRow, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[currentRow, 7].Value = dataTemplate[i].details[j].SellerRef;
                    worksheet.Cells[currentRow, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[currentRow, 8].Value = dataTemplate[i].details[j].Regist;
                    worksheet.Cells[currentRow, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[currentRow, 9].Value = dataTemplate[i].details[j].BuildYear;
                    worksheet.Cells[currentRow, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[currentRow, 10].Value = dataTemplate[i].details[j].Make;
                    worksheet.Cells[currentRow, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[currentRow, 11].Value = dataTemplate[i].details[j].ModelDesc;
                    worksheet.Cells[currentRow, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[currentRow, 12].Value = dataTemplate[i].details[j].Variants;
                    worksheet.Cells[currentRow, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    worksheet.Cells[currentRow, 13].Value = dataTemplate[i].details[j].ReservePrice;
                    worksheet.Cells[currentRow, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[currentRow, 14].Value = dataTemplate[i].details[j].SoldPrice;
                    worksheet.Cells[currentRow, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[currentRow, 15].Value = dataTemplate[i].details[j].Variance;
                    worksheet.Cells[currentRow, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    worksheet.Cells[currentRow, 16].Value = dataTemplate[i].details[j].PercentageForSold / 100;
                    worksheet.Cells[currentRow, 16].Style.Numberformat.Format = "0.00%";
                    worksheet.Cells[currentRow, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    worksheet.Cells[currentRow, 17].Value = dataTemplate[i].details[j].SoldPriceExclTax;
                    worksheet.Cells[currentRow, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[currentRow, 18].Value = dataTemplate[i].details[j].VAT;
                    worksheet.Cells[currentRow, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    worksheet.Cells[currentRow, 19].Value = dataTemplate[i].details[j].SellingFee;
                    worksheet.Cells[currentRow, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[currentRow, 20].Value = dataTemplate[i].details[j].Detailing;
                    worksheet.Cells[currentRow, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[currentRow, 21].Value = dataTemplate[i].details[j].inspection;
                    worksheet.Cells[currentRow, 21].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[currentRow, 22].Value = dataTemplate[i].details[j].SubTotal;
                    worksheet.Cells[currentRow, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[currentRow, 23].Value = dataTemplate[i].details[j].ServicesVAT;
                    worksheet.Cells[currentRow, 23].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[currentRow, 24].Value = dataTemplate[i].details[j].WHTax;
                    worksheet.Cells[currentRow, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[currentRow, 25].Value = dataTemplate[i].details[j].Total;
                    worksheet.Cells[currentRow, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    worksheet.Row(currentRow).Height = 21;
                }
                int intTotalRecord = pointerForData + dataTemplate[i].details.Count;
                worksheet.Cells["M9:" + "M" + (intTotalRecord-1).ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["M9:" + "M" + (intTotalRecord - 1).ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["N9:" + "N" + (intTotalRecord - 1).ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["N9:" + "N" + (intTotalRecord - 1).ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["O9:" + "O" + (intTotalRecord - 1).ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["O9:" + "O" + (intTotalRecord - 1).ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["Q9:" + "Q" + (intTotalRecord - 1).ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["Q9:" + "Q" + (intTotalRecord - 1).ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["R9:" + "R" + (intTotalRecord - 1).ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["R9:" + "R" + (intTotalRecord - 1).ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["S9:" + "S" + (intTotalRecord - 1).ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["S9:" + "S" + (intTotalRecord - 1).ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["T9:" + "T" + (intTotalRecord - 1).ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["T9:" + "T" + (intTotalRecord - 1).ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["U9:" + "U" + (intTotalRecord - 1).ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["U9:" + "U" + (intTotalRecord - 1).ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["V9:" + "V" + (intTotalRecord - 1).ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["V9:" + "V" + (intTotalRecord - 1).ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["W9:" + "W" + (intTotalRecord - 1).ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["W9:" + "W" + (intTotalRecord - 1).ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["X9:" + "X" + (intTotalRecord - 1).ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["X9:" + "X" + (intTotalRecord - 1).ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["Y9:" + "Y" + (intTotalRecord - 1).ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["Y9:" + "Y" + (intTotalRecord - 1).ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;




                decimal total_ReservcePrice = dataTemplate[i].details.Sum(p => p.ReservePrice);
                decimal tota_SoldPrice = dataTemplate[i].details.Sum(p => p.SoldPrice);
                decimal total_Variance = dataTemplate[i].details.Sum(p => p.Variance);
                decimal total_SoldPriceExclTax = dataTemplate[i].details.Sum(p => p.SoldPriceExclTax);
                decimal total_VAT = dataTemplate[i].details.Sum(p => p.VAT);
                decimal total_SellingFee = dataTemplate[i].details.Sum(p => p.SellingFee);
                decimal total_Detailing = dataTemplate[i].details.Sum(p => p.Detailing);
                decimal total_Inspection = dataTemplate[i].details.Sum(p => p.inspection);
                decimal total_SubTotal = dataTemplate[i].details.Sum(p => p.SubTotal);
                decimal total_ServicesVAT = dataTemplate[i].details.Sum(p => p.ServicesVAT);
                decimal total_WHTax = dataTemplate[i].details.Sum(p => p.WHTax);
                decimal total_Total = dataTemplate[i].details.Sum(p => p.Total);

                worksheet.Cells[7, 19].Value = "MAP SERVICE";
                // Merge cells A1 through C1
                worksheet.Cells["S7:Y7"].Merge = true;
                worksheet.Row(7).Height = 21;
                worksheet.Cells["S7:Y7"].Style.Font.Bold = true;
                worksheet.Cells["S7:Y7"].Style.Font.Size = 10;
                worksheet.Cells["S7:Y7"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["S7:Y7"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["S7:Y7"].Style.WrapText = true;
                worksheet.Cells["S7:Y7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["S7:Y7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#C0C0C0"));
                worksheet.Cells["S7:Y7"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["S7:Y7"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["S7:Y7"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["S7:Y7"].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                worksheet.Cells["S7:Y7"].Style.Border.Top.Color.SetColor(Color.Black);
                worksheet.Cells["S7:Y7"].Style.Border.Bottom.Color.SetColor(Color.Black);
                worksheet.Cells["S7:Y7"].Style.Border.Left.Color.SetColor(Color.Black);
                worksheet.Cells["S7:Y7"].Style.Border.Right.Color.SetColor(Color.Black);

                worksheet.Cells[intTotalRecord, 13].Value = total_ReservcePrice;
                worksheet.Cells[intTotalRecord, 14].Value = tota_SoldPrice;
                worksheet.Cells[intTotalRecord, 15].Value = total_Variance;

                
                worksheet.Cells[intTotalRecord, 17].Value = total_SoldPriceExclTax;
                worksheet.Cells[intTotalRecord, 18].Value = total_VAT;

                worksheet.Cells[intTotalRecord, 19].Value = total_SellingFee;
                worksheet.Cells[intTotalRecord, 20].Value = total_Detailing;
                worksheet.Cells[intTotalRecord, 21].Value = total_Inspection;
                worksheet.Cells[intTotalRecord, 22].Value = total_SubTotal;
                worksheet.Cells[intTotalRecord, 23].Value = total_ServicesVAT;
                worksheet.Cells[intTotalRecord, 24].Value = total_WHTax;
                worksheet.Cells[intTotalRecord, 25].Value = total_Total;                

                
                var headerRange = worksheet.Cells["A8:Y8"];
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Font.Size = 10;
                headerRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                headerRange.Style.WrapText = true;
                headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                headerRange.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#C0C0C0"));
                

                // Set border style and color
                var AllDataRange = worksheet.Cells["A8:Y" + (intTotalRecord - 1).ToString()];
                AllDataRange.Style.Font.Size = 10;
                var border = AllDataRange.Style.Border;
                border.Top.Style = ExcelBorderStyle.Thin;
                border.Bottom.Style = ExcelBorderStyle.Thin;
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.Thin;

                border.Top.Color.SetColor(Color.Black);
                border.Bottom.Color.SetColor(Color.Black);
                border.Left.Color.SetColor(Color.Black);
                border.Right.Color.SetColor(Color.Black);
                AllDataRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                worksheet.Cells["M" + intTotalRecord.ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["M" + intTotalRecord.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["M" + intTotalRecord.ToString()].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["M" + intTotalRecord.ToString()].Style.Font.UnderLineType = ExcelUnderLineType.DoubleAccounting;
                worksheet.Cells["M" + intTotalRecord.ToString()].Style.Font.Name = "Arial";
                worksheet.Cells["M" + intTotalRecord.ToString()].Style.Font.Size = 14;

                worksheet.Cells["N" + intTotalRecord.ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["N" + intTotalRecord.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["N" + intTotalRecord.ToString()].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["N" + intTotalRecord.ToString()].Style.Font.UnderLineType = ExcelUnderLineType.DoubleAccounting;
                worksheet.Cells["N" + intTotalRecord.ToString()].Style.Font.Name = "Arial";
                worksheet.Cells["N" + intTotalRecord.ToString()].Style.Font.Size = 14;

                worksheet.Cells["O" + intTotalRecord.ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["O" + intTotalRecord.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["O" + intTotalRecord.ToString()].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["O" + intTotalRecord.ToString()].Style.Font.UnderLineType = ExcelUnderLineType.DoubleAccounting;
                worksheet.Cells["O" + intTotalRecord.ToString()].Style.Font.Name = "Arial";
                worksheet.Cells["O" + intTotalRecord.ToString()].Style.Font.Size = 14;

                worksheet.Cells["Q" + intTotalRecord.ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["Q" + intTotalRecord.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["Q" + intTotalRecord.ToString()].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["Q" + intTotalRecord.ToString()].Style.Font.UnderLineType = ExcelUnderLineType.DoubleAccounting;
                worksheet.Cells["Q" + intTotalRecord.ToString()].Style.Font.Name = "Arial";
                worksheet.Cells["Q" + intTotalRecord.ToString()].Style.Font.Size = 14;

                worksheet.Cells["R" + intTotalRecord.ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["R" + intTotalRecord.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["R" + intTotalRecord.ToString()].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["R" + intTotalRecord.ToString()].Style.Font.UnderLineType = ExcelUnderLineType.DoubleAccounting;
                worksheet.Cells["R" + intTotalRecord.ToString()].Style.Font.Name = "Arial";
                worksheet.Cells["R" + intTotalRecord.ToString()].Style.Font.Size = 14;

                worksheet.Cells["S" + intTotalRecord.ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["S" + intTotalRecord.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["S" + intTotalRecord.ToString()].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["S" + intTotalRecord.ToString()].Style.Font.UnderLineType = ExcelUnderLineType.DoubleAccounting;
                worksheet.Cells["S" + intTotalRecord.ToString()].Style.Font.Name = "Arial";
                worksheet.Cells["S" + intTotalRecord.ToString()].Style.Font.Size = 14;

                worksheet.Cells["T" + intTotalRecord.ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["T" + intTotalRecord.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["T" + intTotalRecord.ToString()].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["T" + intTotalRecord.ToString()].Style.Font.UnderLineType = ExcelUnderLineType.DoubleAccounting;
                worksheet.Cells["T" + intTotalRecord.ToString()].Style.Font.Name = "Arial";
                worksheet.Cells["T" + intTotalRecord.ToString()].Style.Font.Size = 14;

                worksheet.Cells["U" + intTotalRecord.ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["U" + intTotalRecord.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["U" + intTotalRecord.ToString()].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["U" + intTotalRecord.ToString()].Style.Font.UnderLineType = ExcelUnderLineType.DoubleAccounting;
                worksheet.Cells["U" + intTotalRecord.ToString()].Style.Font.Name = "Arial";
                worksheet.Cells["U" + intTotalRecord.ToString()].Style.Font.Size = 14;

                worksheet.Cells["V" + intTotalRecord.ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["V" + intTotalRecord.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["V" + intTotalRecord.ToString()].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["V" + intTotalRecord.ToString()].Style.Font.UnderLineType = ExcelUnderLineType.DoubleAccounting;
                worksheet.Cells["V" + intTotalRecord.ToString()].Style.Font.Name = "Arial";
                worksheet.Cells["V" + intTotalRecord.ToString()].Style.Font.Size = 14;

                worksheet.Cells["W" + intTotalRecord.ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["W" + intTotalRecord.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["W" + intTotalRecord.ToString()].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["W" + intTotalRecord.ToString()].Style.Font.UnderLineType = ExcelUnderLineType.DoubleAccounting;
                worksheet.Cells["W" + intTotalRecord.ToString()].Style.Font.Name = "Arial";
                worksheet.Cells["W" + intTotalRecord.ToString()].Style.Font.Size = 14;

                worksheet.Cells["X" + intTotalRecord.ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["X" + intTotalRecord.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["X" + intTotalRecord.ToString()].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["X" + intTotalRecord.ToString()].Style.Font.UnderLineType = ExcelUnderLineType.DoubleAccounting;
                worksheet.Cells["X" + intTotalRecord.ToString()].Style.Font.Name = "Arial";
                worksheet.Cells["X" + intTotalRecord.ToString()].Style.Font.Size = 14;

                worksheet.Cells["Y" + intTotalRecord.ToString()].Style.Numberformat.Format = customFormat;
                worksheet.Cells["Y" + intTotalRecord.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells["Y" + intTotalRecord.ToString()].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["Y" + intTotalRecord.ToString()].Style.Font.UnderLineType = ExcelUnderLineType.DoubleAccounting;
                worksheet.Cells["Y" + intTotalRecord.ToString()].Style.Font.Name = "Arial";
                worksheet.Cells["Y" + intTotalRecord.ToString()].Style.Font.Size = 14;

                worksheet.Row(intTotalRecord).Height = 25;                

                // Footer
                // Footer Label
                worksheet.Cells[intTotalRecord + 2, 20].Value = "Auction Payout";
                worksheet.Cells[intTotalRecord + 4, 20].Value = "VAT Due to Revenue Department";
                worksheet.Cells[intTotalRecord + 5, 20].Value = "Motto Auction (Thailand) Fees";

                worksheet.Cells[intTotalRecord + 6, 20].Value = "Fees to Motto Auction (Thailand)";
                worksheet.Cells[intTotalRecord + 7, 20].Value = "VAT";
                worksheet.Cells[intTotalRecord + 8, 20].Value = "Total";
                worksheet.Cells[intTotalRecord + 9, 20].Value = "Less With-Holding Tax";
                worksheet.Cells[intTotalRecord + 10, 20].Value = "Total Offset";

                worksheet.Cells["T" + (intTotalRecord + 2).ToString() + ":T" + (intTotalRecord + 10).ToString()].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["T" + (intTotalRecord + 2).ToString() + ":T" + (intTotalRecord + 10).ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                // Footer Value
                worksheet.Cells[intTotalRecord + 2, 25].Value = ((total_SoldPriceExclTax
                                                                - total_SubTotal
                                                                - total_ServicesVAT)
                                                                + total_WHTax);
                worksheet.Cells[intTotalRecord + 2, 25].Style.Numberformat.Format = customFormat;
                worksheet.Cells[intTotalRecord + 2, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[intTotalRecord + 2, 25].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                worksheet.Cells[intTotalRecord + 2, 25].Style.Font.Bold = true;
                worksheet.Cells[intTotalRecord + 2, 25].Style.Font.Size = 16;


                worksheet.Cells[intTotalRecord + 4, 25].Value = total_VAT;
                worksheet.Cells[intTotalRecord + 4, 25].Style.Numberformat.Format = customFormat;
                worksheet.Cells[intTotalRecord + 4, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[intTotalRecord + 4, 25].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                worksheet.Cells[intTotalRecord + 4, 25].Style.Font.Bold = true;

                worksheet.Cells[intTotalRecord + 6, 25].Value = total_SubTotal;
                worksheet.Cells[intTotalRecord + 6, 25].Style.Numberformat.Format = customFormat;
                worksheet.Cells[intTotalRecord + 6, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[intTotalRecord + 6, 25].Style.VerticalAlignment = ExcelVerticalAlignment.Top;

                worksheet.Cells[intTotalRecord + 7, 25].Value = total_ServicesVAT;
                worksheet.Cells[intTotalRecord + 7, 25].Style.Numberformat.Format = customFormat;
                worksheet.Cells[intTotalRecord + 7, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[intTotalRecord + 7, 25].Style.VerticalAlignment = ExcelVerticalAlignment.Top;

                worksheet.Cells[intTotalRecord + 8, 25].Value = total_SubTotal + total_ServicesVAT;
                worksheet.Cells[intTotalRecord + 8, 25].Style.Numberformat.Format = customFormat;
                worksheet.Cells[intTotalRecord + 8, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[intTotalRecord + 8, 25].Style.Font.UnderLineType = ExcelUnderLineType.SingleAccounting;
                worksheet.Cells[intTotalRecord + 8, 25].Style.VerticalAlignment = ExcelVerticalAlignment.Top;

                worksheet.Cells[intTotalRecord + 9, 25].Value = total_WHTax;
                worksheet.Cells[intTotalRecord + 9, 25].Style.Numberformat.Format = customFormat;
                worksheet.Cells[intTotalRecord + 9, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[intTotalRecord + 9, 25].Style.VerticalAlignment = ExcelVerticalAlignment.Top;

                worksheet.Cells[intTotalRecord + 10, 25].Value = (total_SubTotal + total_ServicesVAT) - total_WHTax;
                worksheet.Cells[intTotalRecord + 10, 25].Style.Numberformat.Format = customFormat;
                worksheet.Cells[intTotalRecord + 10, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[intTotalRecord + 10, 25].Style.Font.UnderLineType = ExcelUnderLineType.DoubleAccounting;
                worksheet.Cells[intTotalRecord + 10, 25].Style.VerticalAlignment = ExcelVerticalAlignment.Top;


                worksheet.Cells[intTotalRecord + 2, 20].Style.Font.Bold = true;
                worksheet.Cells[intTotalRecord + 2, 20].Style.Font.Size = 9;
                worksheet.Cells[intTotalRecord + 4, 20].Style.Font.Bold = true;
                worksheet.Cells[intTotalRecord + 4, 20].Style.Font.Size = 9;
                worksheet.Cells[intTotalRecord + 5, 20].Style.Font.Bold = true;
                worksheet.Cells[intTotalRecord + 5, 20].Style.Font.Size = 9;

                worksheet.Cells[intTotalRecord + 6, 20].Style.Font.Bold = true;
                worksheet.Cells[intTotalRecord + 6, 20].Style.Font.Size = 9;
                worksheet.Cells[intTotalRecord + 7, 20].Style.Font.Bold = true;
                worksheet.Cells[intTotalRecord + 7, 20].Style.Font.Size = 9;
                worksheet.Cells[intTotalRecord + 8, 20].Style.Font.Bold = true;
                worksheet.Cells[intTotalRecord + 8, 20].Style.Font.Size = 9;
                worksheet.Cells[intTotalRecord + 9, 20].Style.Font.Bold = true;
                worksheet.Cells[intTotalRecord + 9, 20].Style.Font.Size = 9;
                worksheet.Cells[intTotalRecord + 10, 20].Style.Font.Bold = true;
                worksheet.Cells[intTotalRecord + 10, 20].Style.Font.Size = 9;

                worksheet.Row(intTotalRecord + 2).Height = 21;
                worksheet.Row(intTotalRecord + 4).Height = 21;
                worksheet.Row(intTotalRecord + 6).Height = 21;
                worksheet.Row(intTotalRecord + 7).Height = 21;
                worksheet.Row(intTotalRecord + 8).Height = 21;
                worksheet.Row(intTotalRecord + 9).Height = 21;
                worksheet.Row(intTotalRecord + 10).Height = 21;

                var footerRange = worksheet.Cells["T" + (intTotalRecord + 6).ToString() + ":Y" + (intTotalRecord + 10).ToString()];

                footerRange.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            }
            return package;
        }
        #endregion

        private string[] SeparateSellerList = new string[]
       {
            "0000101916",
            "0000102858"
       };

        #region ConvertToTemplateLayout
        public List<Account_Reconciliation_Template> ConvertToTemplateLayout(List<Account_Reconciliation_Raw> rawData)
        {
            List<Account_Reconciliation_Template> lstRtn = new List<Account_Reconciliation_Template>();
            if (rawData.Any())
            {
                List<string> sellerList = rawData
                                       .GroupBy(row => row.Seller)
                                       .Select(group => group.Key)
                                       .ToList();                

               
                if (sellerList.Any())
                {
                    if (sellerList.Count > 1)
                    {
                        //Summary
                        Account_Reconciliation_Template summaryTemplate = new Account_Reconciliation_Template();
                        summaryTemplate.AuctionDate = rawData[0].AuctionDate.ToString("dd MMM yyyy");
                        string input = rawData[0].AuctionTime;

                        // Find the position of " at " which indicates the start of the time
                        int atIndex = input.IndexOf(" at ");
                        string AuctionTime = "";
                        if (atIndex != -1)
                        {
                            // Add the length of " at " to get the start index of the time
                            AuctionTime = input.Substring(atIndex + " at ".Length).Trim();
                            
                        }

                        string[] parts = input.Split(' ');

                        // The first word will be "Bangkok"
                        string AuctionLocation = parts[0];

                        summaryTemplate.Place = AuctionLocation;
                        summaryTemplate.Time = AuctionTime;

                        summaryTemplate.SellerName = "All Seller";
                        summaryTemplate.SellerCode = "All Seller";
                        List<string> auctionList = rawData
                                                    .GroupBy(row => row.AuctionCode)
                                                    .Select(group => group.Key)
                                                    .ToList();
                        summaryTemplate.AuctionCode = String.Join(", ", auctionList);

                        //List<string> auctionTime = rawData
                        //                            .GroupBy(row => row.AuctionTime)
                        //                            .Select(group => group.Key)
                        //                            .ToList();
                        //summaryTemplate.Time = String.Join(", ", auctionList);
                        int buyerIndex = 1;
                        string PreviousBidNo = "";
                        summaryTemplate.details = new List<Account_Reconciliation_Raw>();
                        //for (int j = 0; j < rawData.Count; j++)
                        //{
                        //    rawData[j].ID = j + 1;
                        //    if (rawData[j].BidNo == PreviousBidNo)
                        //    {
                        //        rawData[j].NoOfBuyer = "";
                        //    }
                        //    else
                        //    {
                        //        rawData[j].NoOfBuyer = buyerIndex.ToString();
                        //        PreviousBidNo = rawData[j].BidNo;
                        //        buyerIndex++;
                        //    }
                        //    summaryTemplate.details.Add(rawData[j]);
                        //}
                        summaryTemplate.details = rawData;
                        lstRtn.Add(summaryTemplate);
                    }                  

                    for (int i = 0; i < sellerList.Count; i++)
                    {
                        List<Account_Reconciliation_Raw> sellerDetail = rawData
                                              .Where(row => row.Seller == sellerList[i])
                                              .ToList();
                       
                        Account_Reconciliation_Template sellerDetailTemplate = new Account_Reconciliation_Template();

                        if (sellerDetail.Any())
                        {
                            if (SeparateSellerList.Contains(sellerDetail[0].SellerNo))
                            {
                                List<Account_Reconciliation_Raw> sellerDetailTemplate_SameDayPayment = sellerDetail
                                             .Where(row => row.PaymentStatus == "SD")
                                             .ToList();

                                List<Account_Reconciliation_Raw> sellerDetailTemplate_NotSameDayPayment = sellerDetail
                                             .Where(row => row.PaymentStatus == "NS")
                                             .OrderBy(row => row.ID)
                                             .ToList();

                                if (sellerDetailTemplate_SameDayPayment.Any())
                                {
                                    sellerDetailTemplate.AuctionDate = sellerDetailTemplate_SameDayPayment[0].AuctionDate.ToString("dd MMM yyyy");                                    
                                    sellerDetailTemplate.SellerName = sellerDetailTemplate_SameDayPayment[0].Seller;
                                    sellerDetailTemplate.SellerCode = sellerDetailTemplate_SameDayPayment[0].SellerCode + " (1st)";
                                    List<string> sellerAuctionList = sellerDetailTemplate_SameDayPayment
                                                                   .GroupBy(row => row.AuctionCode)
                                                                   .Select(group => group.Key)
                                                                   .ToList();
                                    sellerDetailTemplate.AuctionCode = String.Join(", ", sellerAuctionList);
                                    List<string> sellerAuctionTime = sellerDetailTemplate_SameDayPayment
                                                                   .GroupBy(row => row.AuctionTime)
                                                                   .Select(group => group.Key)
                                                                   .ToList();
                                    sellerDetailTemplate.Time = String.Join(", ", sellerAuctionTime);

                                    string input = sellerDetailTemplate_SameDayPayment[0].AuctionTime;
                                    // Find the position of " at " which indicates the start of the time
                                    int atIndex = input.IndexOf(" at ");
                                    string AuctionTime = "";
                                    if (atIndex != -1)
                                    {
                                        // Add the length of " at " to get the start index of the time
                                        AuctionTime = input.Substring(atIndex + " at ".Length).Trim();

                                    }

                                    string[] parts = input.Split(' ');

                                    // The first word will be "Bangkok"
                                    string AuctionLocation = parts[0];

                                    sellerDetailTemplate.Place = AuctionLocation;
                                    sellerDetailTemplate.Time = AuctionTime;

                                    int buyerIndex = 1;
                                    string PreviousBidNo = "";
                                    sellerDetailTemplate.details = new List<Account_Reconciliation_Raw>();
                                    for (int j = 0; j < sellerDetailTemplate_SameDayPayment.Count; j++)
                                    {
                                        sellerDetailTemplate_SameDayPayment[j].ID = j + 1;
                                        if (sellerDetailTemplate_SameDayPayment[j].BidNo == PreviousBidNo)
                                        {
                                            sellerDetailTemplate_SameDayPayment[j].NoOfBuyer = "";
                                        }
                                        else
                                        {
                                            sellerDetailTemplate_SameDayPayment[j].NoOfBuyer = buyerIndex.ToString();
                                            PreviousBidNo = sellerDetailTemplate_SameDayPayment[j].BidNo;
                                            buyerIndex++;
                                        }
                                        sellerDetailTemplate_SameDayPayment[j].SubTotal = sellerDetailTemplate_SameDayPayment[j].SellingFee 
                                                                                        + sellerDetailTemplate_SameDayPayment[j].Detailing 
                                                                                        + sellerDetailTemplate_SameDayPayment[j].inspection;

                                        sellerDetailTemplate_SameDayPayment[j].ServicesVAT = (sellerDetailTemplate_SameDayPayment[j].SellingFee
                                                                                        + sellerDetailTemplate_SameDayPayment[j].Detailing
                                                                                        + sellerDetailTemplate_SameDayPayment[j].inspection) * (decimal)0.07;

                                        sellerDetailTemplate_SameDayPayment[j].WHTax = (sellerDetailTemplate_SameDayPayment[j].SellingFee
                                                                                        + sellerDetailTemplate_SameDayPayment[j].Detailing
                                                                                        + sellerDetailTemplate_SameDayPayment[j].inspection) * (decimal)0.03;
                                        sellerDetailTemplate_SameDayPayment[j].Total = sellerDetailTemplate_SameDayPayment[j].SubTotal
                                                                                       + sellerDetailTemplate_SameDayPayment[j].WHTax
                                                                                       - sellerDetailTemplate_SameDayPayment[j].ServicesVAT;

                                        sellerDetailTemplate.details.Add(sellerDetailTemplate_SameDayPayment[j]);
                                    }
                                    lstRtn.Add(sellerDetailTemplate);
                                }

                                if (sellerDetailTemplate_NotSameDayPayment.Any())
                                {
                                    sellerDetailTemplate = new Account_Reconciliation_Template();
                                    sellerDetailTemplate.AuctionDate = sellerDetailTemplate_NotSameDayPayment[0].AuctionDate.ToString("dd MMM yyyy");
                                    sellerDetailTemplate.Place = "";
                                    sellerDetailTemplate.SellerName = sellerDetailTemplate_NotSameDayPayment[0].Seller;
                                    sellerDetailTemplate.SellerCode = sellerDetailTemplate_NotSameDayPayment[0].SellerCode + " (2nd)";
                                    List<string> sellerAuctionList = sellerDetailTemplate_NotSameDayPayment
                                                                   .GroupBy(row => row.AuctionCode)
                                                                   .Select(group => group.Key)
                                                                   .ToList();
                                    sellerDetailTemplate.AuctionCode = String.Join(", ", sellerAuctionList);
                                    List<string> sellerAuctionTime = sellerDetailTemplate_NotSameDayPayment
                                                                   .GroupBy(row => row.AuctionTime)
                                                                   .Select(group => group.Key)
                                                                   .ToList();
                                    sellerDetailTemplate.Time = String.Join(", ", sellerAuctionTime);

                                    string input = sellerDetailTemplate_NotSameDayPayment[0].AuctionTime;
                                    // Find the position of " at " which indicates the start of the time
                                    int atIndex = input.IndexOf(" at ");
                                    string AuctionTime = "";
                                    if (atIndex != -1)
                                    {
                                        // Add the length of " at " to get the start index of the time
                                        AuctionTime = input.Substring(atIndex + " at ".Length).Trim();

                                    }

                                    string[] parts = input.Split(' ');

                                    // The first word will be "Bangkok"
                                    string AuctionLocation = parts[0];

                                    sellerDetailTemplate.Place = AuctionLocation;
                                    sellerDetailTemplate.Time = AuctionTime;

                                    int buyerIndex = 1;
                                    string PreviousBidNo = "";
                                    sellerDetailTemplate.details = new List<Account_Reconciliation_Raw>();
                                    for (int j = 0; j < sellerDetailTemplate_NotSameDayPayment.Count; j++)
                                    {
                                        sellerDetailTemplate_NotSameDayPayment[j].ID = j + 1;
                                        if (sellerDetailTemplate_NotSameDayPayment[j].BidNo == PreviousBidNo)
                                        {
                                            sellerDetailTemplate_NotSameDayPayment[j].NoOfBuyer = "";
                                        }
                                        else
                                        {
                                            sellerDetailTemplate_NotSameDayPayment[j].NoOfBuyer = buyerIndex.ToString();
                                            PreviousBidNo = sellerDetailTemplate_NotSameDayPayment[j].BidNo;
                                            buyerIndex++;
                                        }
                                        sellerDetailTemplate_NotSameDayPayment[j].SubTotal = sellerDetailTemplate_NotSameDayPayment[j].SellingFee
                                                                                        + sellerDetailTemplate_NotSameDayPayment[j].Detailing
                                                                                        + sellerDetailTemplate_NotSameDayPayment[j].inspection;

                                        sellerDetailTemplate_NotSameDayPayment[j].ServicesVAT = (sellerDetailTemplate_NotSameDayPayment[j].SellingFee
                                                                                        + sellerDetailTemplate_NotSameDayPayment[j].Detailing
                                                                                        + sellerDetailTemplate_NotSameDayPayment[j].inspection) * (decimal)0.07;

                                        sellerDetailTemplate_NotSameDayPayment[j].WHTax = (sellerDetailTemplate_NotSameDayPayment[j].SellingFee
                                                                                        + sellerDetailTemplate_NotSameDayPayment[j].Detailing
                                                                                        + sellerDetailTemplate_NotSameDayPayment[j].inspection) * (decimal)0.03;
                                        sellerDetailTemplate_NotSameDayPayment[j].Total = sellerDetailTemplate_NotSameDayPayment[j].SubTotal
                                                                                       + sellerDetailTemplate_NotSameDayPayment[j].WHTax
                                                                                       - sellerDetailTemplate_NotSameDayPayment[j].ServicesVAT;

                                        sellerDetailTemplate.details.Add(sellerDetailTemplate_NotSameDayPayment[j]);
                                    }
                                    lstRtn.Add(sellerDetailTemplate);
                                }
                                
                            }
                            else
                            {
                                sellerDetailTemplate.AuctionDate = sellerDetail[0].AuctionDate.ToString("dd MMM yyyy");
                                sellerDetailTemplate.Place = "";
                                sellerDetailTemplate.SellerName = sellerDetail[0].Seller;
                                sellerDetailTemplate.SellerCode = sellerDetail[0].SellerCode;

                                List<string> sellerAuctionList = sellerDetail
                                                               .GroupBy(row => row.AuctionCode)
                                                               .Select(group => group.Key)
                                                               .ToList();
                                sellerDetailTemplate.AuctionCode = String.Join(", ", sellerAuctionList);
                                List<string> sellerAuctionTime = sellerDetail
                                                               .GroupBy(row => row.AuctionTime)
                                                               .Select(group => group.Key)
                                                               .ToList();
                                sellerDetailTemplate.Time = String.Join(", ", sellerAuctionTime);

                                string input = sellerDetail[0].AuctionTime;
                                // Find the position of " at " which indicates the start of the time
                                int atIndex = input.IndexOf(" at ");
                                string AuctionTime = "";
                                if (atIndex != -1)
                                {
                                    // Add the length of " at " to get the start index of the time
                                    AuctionTime = input.Substring(atIndex + " at ".Length).Trim();

                                }

                                string[] parts = input.Split(' ');

                                // The first word will be "Bangkok"
                                string AuctionLocation = parts[0];

                                sellerDetailTemplate.Place = AuctionLocation;
                                sellerDetailTemplate.Time = AuctionTime;

                                int buyerIndex = 1;
                                string PreviousBidNo = "";
                                sellerDetailTemplate.details = new List<Account_Reconciliation_Raw>();
                                for (int j = 0; j < sellerDetail.Count; j++)
                                {
                                    sellerDetail[j].ID = i + 1;
                                    if (sellerDetail[j].BidNo == PreviousBidNo)
                                    {
                                        sellerDetail[j].NoOfBuyer = "";
                                    }
                                    else
                                    {
                                        sellerDetail[j].NoOfBuyer = buyerIndex.ToString();
                                        PreviousBidNo = sellerDetail[j].BidNo;
                                        buyerIndex++;
                                    }
                                    sellerDetail[j].SubTotal = sellerDetail[j].SellingFee
                                                            + sellerDetail[j].Detailing
                                                            + sellerDetail[j].inspection;

                                    sellerDetail[j].ServicesVAT = (sellerDetail[j].SellingFee
                                                                    + sellerDetail[j].Detailing
                                                                    + sellerDetail[j].inspection) * (decimal)0.07;

                                    sellerDetail[j].WHTax = (sellerDetail[j].SellingFee
                                                            + sellerDetail[j].Detailing
                                                            + sellerDetail[j].inspection) * (decimal)0.03;
                                    sellerDetail[j].Total = sellerDetail[j].SubTotal
                                                            + sellerDetail[j].WHTax
                                                            - sellerDetail[j].ServicesVAT;

                                    sellerDetailTemplate.details.Add(sellerDetail[j]);
                                }
                                lstRtn.Add(sellerDetailTemplate);
                            }
                            
                        }
                        
                    }
                }
                
            }
            return lstRtn;
        }
        #endregion
        
    }

    #region Model
    public class Account_Reconciliation_Template
    {
        public string AuctionDate { get; set; }
        public string Place { get; set; }
        public string AuctionCode { get; set; }
        public string Time { get; set; }
        public string SellerName { get; set; }
        public string SellerCode { get; set; }
        public List<Account_Reconciliation_Raw> details { get; set; }
    }
    #endregion
}
