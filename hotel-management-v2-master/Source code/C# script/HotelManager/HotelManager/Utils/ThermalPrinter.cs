using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Utils
{
    public class ThermalReceiptPrinter
    {
        public string RoomNumber { get; set; }
        public int Quantity { get; set; }
        public string ServiceName { get; set; }
        public ThermalReceiptPrinter(string roomNumber, string serviceName, int quantity)
        {
            RoomNumber = roomNumber;
            ServiceName = serviceName;
            Quantity = quantity;
        }
        public void Print2Doc()
        {
            AppLogger.Instance.LogInformation("Print2Doc is called");
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF"; // or "Microsoft XPS Document Writer"
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);

            try
            {
                printDocument.Print();
                AppLogger.Instance.LogInformation("printDocument.Print() successful");

            }
            catch (Exception ex)
            {
                AppLogger.Instance.LogError("An error occurred while printing the receipt: ", ex);
            }
        }
        public void PrintReceipt()
        {
            AppLogger.Instance.LogInformation("PrintReceipt is called");

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);

            try
            {
                printDocument.Print();
                AppLogger.Instance.LogInformation("PrintReceipt().printDocument.Print() successful");

            }
            catch (Exception ex)
            {
                AppLogger.Instance.LogError("An error occurred while printing the receipt: ",ex);
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Courier New", 10); // Adjust font size for 80mm paper width
            float lineHeight = font.GetHeight(e.Graphics);
            float x = 5; // Margins from the left side of the paper
            float y = 10;

            // Define the maximum width for the text (approximately 75mm for 80mm paper with some margin)
            float maxWidth = 75 * 100 / 25.4f; // Convert mm to points (1 inch = 25.4 mm, 1 point = 1/72 inch)


            // Draw each line on the receipt
            e.Graphics.DrawString("Room Number: " + RoomNumber, font, Brushes.Black, new RectangleF(x, y, maxWidth, lineHeight));
            y += lineHeight;
            e.Graphics.DrawString("Item: "+ ServiceName, font, Brushes.Black, new RectangleF(x, y, maxWidth, lineHeight)); // Print Service Name
            y += lineHeight;
            e.Graphics.DrawString("Quantity: " + Quantity, font, Brushes.Black, new RectangleF(x, y, maxWidth, lineHeight));
            y += lineHeight;
            e.Graphics.DrawString("Time: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), font, Brushes.Black, new RectangleF(x, y, maxWidth, lineHeight));
        }
    }
}
