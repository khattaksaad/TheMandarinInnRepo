using HotelManager.DAO;
using HotelManager.DTO;
using HotelManager.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HotelManager.fPayment;
using static HotelManager.fUseService;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HotelManager
{
    public partial class fPrintBill : Form
    {
        class printBillHelper
        {
            Room room;
            int bookingId;

            public Room Room { get => room; set => room = value; }
            public int BookingId { get => bookingId; set => bookingId = value; }
        }

        int total = 0;
        List<printBillHelper> roomsBooked;
        public fPrintBill()
        {
            InitializeComponent();
        }
        public fPrintBill(int idBooking, string customerName, string phoneNumber, List<Room4GUI> rooms4GUI, string userName, int discount, int surcharge)
        {
            InitializeComponent();

            //ShowBillPreView(idBill);
            ShowBillRoom(rooms4GUI);
            ShowBill(idBooking);
            this.lblCustomerName.Text = customerName;
            this.lblPhoneNumber.Text = phoneNumber.ToString();
            this.lblDateCheckIn.Text = rooms4GUI.First().CheckInDate.ToShortDateString();
            this.lblDateCheckOut.Text = rooms4GUI.First().CheckOutDate.ToShortDateString();
            this.labelSurcharge.Text = surcharge.ToString();
            total = (total  + surcharge)  - discount;
            this.labelGTotalText.Text = total.ToString();
            labelDiscount.Text = discount.ToString();
            labelStaffName.Text = AccountDAO.Instance.LoadStaffInforByUserName(userName).DisplayName;
        }

        public void ShowBill(int bookingId)
        {
            AppLogger.Instance.LogInformation($"fPrintBill - ShowBill({bookingId}) is called");
            try
            {
                listViewServices.Items.Clear();
                System.Data.DataTable dataTable = ChargeService2RoomDAO.Instance.GetAllServiceChargesForARoom(bookingId);
                int _totalPrice = 0;
                foreach (DataRow item in dataTable.Rows)
                {
                    string roomName = roomsBooked.First(p => p.BookingId == bookingId)?.Room.Name ?? string.Empty;
                    ListViewItem listViewItem = new ListViewItem(roomName.ToString());

                    ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, item["Service Name"].ToString());
                    ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Quantity"]).ToString());


                    _totalPrice = (int)item["Price"] * (int)item["Quantity"];
                    total += _totalPrice;
                    ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, _totalPrice.ToString());

                    listViewItem.SubItems.Add(subItem1);
                    listViewItem.SubItems.Add(subItem2);
                    listViewItem.SubItems.Add(subItem3);

                    listViewServices.Items.Add(listViewItem);
                }
            }
            catch (Exception ex)
            {
                AppLogger.Instance.LogError($"fPrintBill - ShowBill, following exception occurred ", ex);

            }

        }
        public void ShowBillRoom(List<Room4GUI> rooms)
        {
            try
            {
                AppLogger.Instance.LogInformation($"fPrintBill - ShowBillRoom() is called");

                listViewRooms.Items.Clear();
                if (rooms == null || rooms.Count == 0) return;
                DataTable dataTable = RoomTypeDAO.Instance.LoadFullRoomType();
                List<RoomType> roomTypes = new List<RoomType>();
                roomsBooked = new List<printBillHelper>();
                foreach (DataRow row in dataTable.Rows)

                {
                    RoomType roomType = new RoomType(row);
                    roomTypes.Add(roomType);
                }
                //DataRow data = BillDAO.Instance.ShowBillRoom(idRoom);
                //	select A.Name RoomName,D.Price [Price Per Night] ,C.DateCheckIn [Check-in Date],B.CheckOutDate as [Check-out Date]  ,E.RoomPrice [Bill Room price],E.Surcharge [Surcharge]

                foreach (Room4GUI room in rooms)
                {
                    
                    ListViewItem listViewItem = new ListViewItem(room.Room.Name.ToString());
                    string roomTypeName = roomTypes.FirstOrDefault(p => p.Id == room.Room.IdRoomType)?.Name ?? string.Empty;
                    int actualPricePerNight = roomTypes.FirstOrDefault(p => p.Id == room.Room.IdRoomType)?.Price ?? 0;
                    ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, roomTypeName.ToString());

                    ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, actualPricePerNight.ToString());

                    ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, room.PricePerNight.ToString());
                    ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem(listViewItem, room.Total4Room.ToString());
                    total += room.Total4Room;
                    listViewItem.SubItems.Add(subItem1);
                    listViewItem.SubItems.Add(subItem2);
                    listViewItem.SubItems.Add(subItem3);
                    listViewItem.SubItems.Add(subItem4);

                    roomsBooked.Add(new printBillHelper() { Room = room.Room, BookingId = room.BookingId });
                    listViewRooms.Items.Add(listViewItem);

                }
            }
            catch (Exception ex)
            {
                AppLogger.Instance.LogError($"fPrintBill - ShowBillRoom, following exception occurred ", ex);

            }
        }


        public bool IsExistsBill(int idRoom)
        {
            return BillDAO.Instance.IsExistsBill(idRoom);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap,58,70);
            bitmap.Dispose();
        }
        Bitmap bitmap;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                AppLogger.Instance.LogInformation($"fPrintBill - btnPrint_Click is called");
                //printDocument1.PrintPage += new PrintPageEventHandler(PrintPage);
                Graphics graphics = this.CreateGraphics();
                bitmap = new Bitmap(708, 695, graphics);
                Graphics _graphics = Graphics.FromImage(bitmap);
                _graphics.CopyFromScreen(this.Location.X, this.Location.Y + 28, 0, 0, new Size(708, 695));
                AppLogger.Instance.LogInformation($"fPrintBill - btnPrint_Click saving bitmap");

                bitmap.Save(Application.StartupPath + @"\Bill.Png", ImageFormat.Png);
                AppLogger.Instance.LogInformation($"fPrintBill - btnPrint_Click bitmap saved");

                bitmap = new Bitmap(Application.StartupPath + @"\Bill.Png");
                if (printDialog1.ShowDialog() == DialogResult.OK)
                    printDocument1.Print();
                AppLogger.Instance.LogInformation($"fPrintBill - btnPrint_Click printDocument1.Print() has been printed");
                DialogResult = MessageBox.Show("Receipt has been printed", "Print Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(DialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex) {
                AppLogger.Instance.LogError($"fPrintBill - btnPrint_Click, following exception occurred ", ex);

            }
        }
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set high-quality rendering options
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            // Get the printer's DPI
            float printerDpiX = e.Graphics.DpiX;
            float printerDpiY = e.Graphics.DpiY;

            // Calculate the scale factor
            float scaleX = printerDpiX / bitmap.HorizontalResolution;
            float scaleY = printerDpiY / bitmap.VerticalResolution;

            // Scale the bitmap
            int scaledWidth = (int)(bitmap.Width * scaleX);
            int scaledHeight = (int)(bitmap.Height * scaleY);

            // Print the bitmap
            e.Graphics.DrawImage(bitmap, 0, 0, scaledWidth, scaledHeight);
        }

    }
}
