using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Utils
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Printing;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using iTextSharp.text;
    using iTextSharp.text.pdf;

    public class DocumentPrinter
    {
        private Bitmap bitmap;
        private PrintDocument printDocument;

        public DocumentPrinter()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
        }

        // Method to capture the form's image and save it as a PDF
        public void SaveAsPdf(Form form, string outputPath)
        {
            CaptureFormImage(form);

            // Save as PNG temporarily
            string tempPath = Path.Combine(Application.StartupPath, "Bill.png");
            bitmap.Save(tempPath, ImageFormat.Png);

            // Convert PNG to PDF
            using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Document document = new Document(PageSize.A4, 25, 25, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                using (var imageStream = new FileStream(tempPath, FileMode.Open, FileAccess.Read))
                {
                    iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(imageStream);
                    pdfImage.ScaleToFit(document.PageSize.Width - 50, document.PageSize.Height - 50);
                    pdfImage.Alignment = Element.ALIGN_CENTER;
                    document.Add(pdfImage);
                }

                document.Close();
            }

            // Clean up temporary image file
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
        }

        // Method to print the form directly to the printer
        public void PrintForm(Form form)
        {
            CaptureFormImage(form);

            using (PrintDialog printDialog = new PrintDialog())
            {
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.PrinterSettings = printDialog.PrinterSettings;
                    printDocument.Print();
                }
            }
        }

        // Capture the form's image as a bitmap
        private void CaptureFormImage(Form form)
        {
            using (Graphics graphics = form.CreateGraphics())
            {
                bitmap = new Bitmap(form.Width, form.Height, graphics);
                using (Graphics _graphics = Graphics.FromImage(bitmap))
                {
                    _graphics.CopyFromScreen(form.Location.X, form.Location.Y + 28, 0, 0, new Size(form.Width, form.Height));
                }
            }
        }

        // PrintPage event handler
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }

}
