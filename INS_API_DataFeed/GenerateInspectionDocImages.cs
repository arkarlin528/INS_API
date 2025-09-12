using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using INS_API_DataFeed.DAO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace INS_API_DataFeed
{

    public class ReportImageGenerator
    {
        private const int Dpi = 200;
        private const int A4WidthMm = 210;
        private const int A4HeightMm = 297;
        private const double MmPerInch = 25.4;

        private readonly int A4WidthPx = (int)(A4WidthMm / MmPerInch * Dpi);
        private readonly int A4HeightPx = (int)(A4HeightMm / MmPerInch * Dpi);
        private readonly int MarginPx = (int)((10.0 / MmPerInch) * Dpi);
        public byte[] GenerateImage(SheetResponse data)
        {
            byte[] result = null;
            result = GenerateCarBookInSheet(data);
            return result;
        }

        public byte[] GenerateCarBookInSheet(SheetResponse data)
        {
            var InspectionData = JsonConvert.DeserializeObject<JObject>(data.InspectionData);
            var SchemaInfo = JsonConvert.DeserializeObject<JObject>(data.SchemaInfo);
            using (var bitmap = new Bitmap(A4WidthPx, A4HeightPx))
            {
                bitmap.SetResolution(Dpi, Dpi);

                using (var g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.Clear(Color.White);

                    float currentY = MarginPx;

                    using (var blackPen = new Pen(Color.Black, 2))
                    using (var fontHeader = new Font("Arial", 18, FontStyle.Bold))
                    using (var fontMain = new Font("Arial", 12))
                    using (var fontBold = new Font("Arial", 12, FontStyle.Bold))
                    {
                        // Draw border
                        g.DrawRectangle(blackPen, MarginPx, MarginPx, A4WidthPx - 2 * MarginPx, A4HeightPx - 2 * MarginPx);

                        // Header
                        g.DrawString("Motto AUCTION", fontHeader, Brushes.Black, MarginPx + 10, currentY);

                        float headerRightX = A4WidthPx - MarginPx - 300;
                        g.DrawString("Car Book In", fontMain, Brushes.Black, headerRightX, currentY);
                        currentY += 20;
                        g.DrawString($"IMAT NUMBER: {data.VehicleId}", fontMain, Brushes.Black, headerRightX, currentY);
                        currentY += 20;
                        g.DrawString($"วันรับรถ: {data.CreatedDate}", fontMain, Brushes.Black, headerRightX, currentY);

                        // Draw QR code
                        string qrBase64 = GenerateQrCodeAsBase64Png(data.VehicleId, 150);

                        // Convert Base64 to Bitmap
                        byte[] qrBytes = Convert.FromBase64String(qrBase64.Split(',')[1]); // remove "data:image/png;base64,"
                        using (var ms = new MemoryStream(qrBytes))
                        using (var qrBitmap = new Bitmap(ms))
                        {
                            g.DrawImage(qrBitmap, A4WidthPx - MarginPx - 150 - 10, MarginPx + 10, 150, 150);
                        }

                        currentY += 40;
                        g.DrawLine(Pens.Black, MarginPx, currentY, A4WidthPx - MarginPx, currentY);
                        currentY += 10;

                        // Participant Info
                        float col1X = MarginPx + 10;
                        float col2X = A4WidthPx / 2 + 10;
                        g.DrawString($"ผู้เข้ามอบ: ", fontMain, Brushes.Black, col1X, currentY);
                        currentY += 20;
                        g.DrawString($"ผู้ตรวจสอบ:", fontMain, Brushes.Black, col1X, currentY);
                        currentY += 20;
                        g.DrawString($"ผู้รับมอบ: {data.Inspector}", fontMain, Brushes.Black, col1X, currentY);

                        float tempY = currentY - 40;
                        g.DrawString($"วันรับรถ: ", fontMain, Brushes.Black, col2X, tempY);
                        tempY += 20;
                        g.DrawString($"เวลา: {data.CreatedDate}", fontMain, Brushes.Black, col2X, tempY);
                        tempY += 20;
                        g.DrawString($"ผู้มอบรถ: ", fontMain, Brushes.Black, col2X, tempY);
                        currentY += 20;

                        // Greeting Section
                        currentY += 20;
                        g.DrawString("เรียน ผู้จัดการประมูลรถยนต์ บริษัท โมโต ออคชั่น (ประเทศไทย) จํากัด", fontMain, Brushes.Black, col1X, currentY);
                        currentY += 20;
                        g.DrawString($"เรียน ท่านผู้จัดการ: ", fontMain, Brushes.Black, col1X, currentY);
                        currentY += 20;
                        g.DrawString($"ที่อยู่: ", fontMain, Brushes.Black, col1X, currentY);
                        currentY += 20;

                        // Vehicle Table Header
                        float tableStartX = MarginPx + 10;
                        float tableWidth = A4WidthPx - 2 * MarginPx - 20;
                        float rowHeight = 40;

                        g.FillRectangle(Brushes.LightGray, tableStartX, currentY, tableWidth, rowHeight);
                        g.DrawRectangle(blackPen, tableStartX, currentY, tableWidth, rowHeight);
                        g.DrawString("ประเภทรถ", fontBold, Brushes.Black, tableStartX + 5, currentY + 10);
                        g.DrawString("PICK UP", fontBold, Brushes.Black, tableStartX + tableWidth / 4 + 5, currentY + 10);
                        g.DrawString("ปีที่ผลิต", fontBold, Brushes.Black, tableStartX + tableWidth / 2 + 5, currentY + 10);
                        g.DrawString("รุ่นรถ", fontBold, Brushes.Black, tableStartX + tableWidth * 3 / 4 + 5, currentY + 10);
                        currentY += rowHeight;

                        // Row 1
                        g.DrawRectangle(blackPen, tableStartX, currentY, tableWidth, rowHeight);
                        g.DrawString("ยี่ห้อ: " + InspectionData["Make"].ToString(), fontMain, Brushes.Black, tableStartX + 5, currentY + 10);
                        g.DrawString("รุ่น: " + InspectionData["Model"].ToString(), fontMain, Brushes.Black, tableStartX + tableWidth / 4 + 5, currentY + 10);
                        g.DrawString("สี: " + InspectionData["Color"].ToString(), fontMain, Brushes.Black, tableStartX + tableWidth / 2 + 5, currentY + 10);
                        currentY += rowHeight;

                        // Row 2
                        g.DrawRectangle(blackPen, tableStartX, currentY, tableWidth, rowHeight);
                        g.DrawString("ทะเบียนรถ: " + InspectionData["LicenseProvince"].ToString(), fontMain, Brushes.Black, tableStartX + 5, currentY + 10);
                        g.DrawString("เลขเครื่อง: " + InspectionData["LicensePlateNumber"].ToString(), fontMain, Brushes.Black, tableStartX + tableWidth / 4 + 5, currentY + 10);
                        currentY += rowHeight;

                        // Add more rows as needed...
                    }
                }

                using (var ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }

        public static string GenerateQrCodeAsBase64Png(string data, int pixelSize = 20)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator(); // no using
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);

            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                using (Bitmap qrBitmap = qrCode.GetGraphic(pixelSize, Color.Black, Color.White, true))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        qrBitmap.Save(ms, ImageFormat.Png);
                        byte[] qrCodeBytes = ms.ToArray();
                        return $"data:image/png;base64,{Convert.ToBase64String(qrCodeBytes)}";
                    }
                }
            }
        }
    }
}
