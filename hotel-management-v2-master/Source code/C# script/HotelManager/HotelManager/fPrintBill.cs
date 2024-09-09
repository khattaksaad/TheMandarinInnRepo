using HotelManager.DAO;
using HotelManager.DTO;
using HotelManager.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
        public fPrintBill()
        {
            InitializeComponent();
        }
        public void SetPrintBill(int idBill, string dateOfCreate)
        {
            ShowBillPreView(idBill);
            ShowInfo(idBill);
        }
        public fPrintBill(int idBooking, string customerName, string phoneNumber, List<Room4GUI> rooms4GUI, string userName)
        {
            InitializeComponent();

            //ShowBillPreView(idBill);
            ShowBill(idBooking);
            ShowBillRoom(rooms4GUI);
            this.lblCustomerName.Text = customerName;
            this.lblPhoneNumber.Text = phoneNumber.ToString();
            this.lblDateCheckIn.Text = rooms4GUI.First().CheckInDate.ToShortDateString();
            this.lblDateCheckOut.Text = rooms4GUI.First().CheckOutDate.ToShortDateString();
            labelStaffName.Text = AccountDAO.Instance.LoadStaffInforByUserName(userName).DisplayName;
        }

        public void ShowBill(int bookingId)
        {
            listViewServices.Items.Clear();
            System.Data.DataTable dataTable = ChargeService2RoomDAO.Instance.GetAllServiceChargesForARoom(bookingId);
            int _totalPrice = 0;
            foreach (DataRow item in dataTable.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(bookingId.ToString());
                id++;

                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, item["Service Name"].ToString());
                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Quantity"]).ToString());


                _totalPrice = (int)item["Price"] * (int)item["Quantity"];
                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, _totalPrice.ToString());

                listViewItem.SubItems.Add(subItem1);
                listViewItem.SubItems.Add(subItem2);
                listViewItem.SubItems.Add(subItem3);

                listViewServices.Items.Add(listViewItem);
            }

        }
        public void ShowBillRoom(List<Room4GUI> rooms)
        {
            listViewRooms.Items.Clear();
            if (rooms == null || rooms.Count == 0) return;
            DataTable dataTable = RoomTypeDAO.Instance.LoadFullRoomType();
            List<RoomType> roomTypes = new List<RoomType>();
            foreach (DataRow row in dataTable.Rows)

            {
                RoomType roomType = new RoomType(row);
                roomTypes.Add(roomType);
            }
            //DataRow data = BillDAO.Instance.ShowBillRoom(idRoom);
            //	select A.Name RoomName,D.Price [Price Per Night] ,C.DateCheckIn [Check-in Date],B.CheckOutDate as [Check-out Date]  ,E.RoomPrice [Bill Room price],E.Surcharge [Surcharge]

            foreach(Room4GUI room in rooms)
            {
                ListViewItem listViewItem = new ListViewItem(room.Room.Name.ToString());
                id++;
                string roomTypeName = roomTypes.FirstOrDefault(p => p.Id == room.Room.IdRoomType)?.Name??string.Empty;
                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, roomTypeName.ToString());
                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, room.PricePerNight.ToString());
                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, room.Total4Room.ToString());

                listViewItem.SubItems.Add(subItem1);
                listViewItem.SubItems.Add(subItem2);
                listViewItem.SubItems.Add(subItem3);

                listViewRooms.Items.Add(listViewItem);

            }
        }




        int id = 0;
        public void ShowBillPreView(int idBill)
        {
        //    listViewUseService.Items.Clear();
        //    DataTable dataTable = BillDAO.Instance.ShowBillPreView(idBill);
        //    int _totalPrice = 0;
        //    foreach (DataRow item in dataTable.Rows)
        //    {
        //        ListViewItem listViewItem = new ListViewItem(id.ToString());
        //        id++;

        //        ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, item["Tên dịch vụ"].ToString());
        //        ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Đơn giá"]).ToString());
        //        ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Số lượng"]).ToString());
        //        ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Thành tiền"]).ToString());


        //        _totalPrice += (int)item["Thành tiền"];

        //        listViewItem.SubItems.Add(subItem1);
        //        listViewItem.SubItems.Add(subItem2);
        //        listViewItem.SubItems.Add(subItem3);
        //        listViewItem.SubItems.Add(subItem4);

        //        listViewUseService.Items.Add(listViewItem);
        //    }

        //    ListViewItem listViewItemTotalPrice = new ListViewItem();
        //    ListViewItem.ListViewSubItem subItemTotalPrice = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, _totalPrice.ToString());
        //    ListViewItem.ListViewSubItem _subItem1 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
        //    ListViewItem.ListViewSubItem _subItem2 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
        //    ListViewItem.ListViewSubItem _subItem3 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
        //    listViewItemTotalPrice.SubItems.Add(_subItem1);
        //    listViewItemTotalPrice.SubItems.Add(_subItem2);
        //    listViewItemTotalPrice.SubItems.Add(_subItem3);
        //    listViewItemTotalPrice.SubItems.Add(subItemTotalPrice);
        //    listViewUseService.Items.Add(listViewItemTotalPrice);

            id = 1;
        }
        public bool IsExistsBill(int idRoom)
        {
            return BillDAO.Instance.IsExistsBill(idRoom);
        }
        public void ShowInfo(int idBill)
        {
        //    string query = "USP_ShowBillInfo @idBill";
        //    DataRow data = DataProvider.Instance.ExecuteQuery(query, new object[] { idBill }).Rows[0];
        //    lblCustomerName.Text = data["HoTen"].ToString();
        //    lblIDCard.Text = data["CMND"].ToString();
        //    lblPhoneNumber.Text = ((int)data["SDT"]).ToString();
        //    lblCustomerTypeName.Text = data["LoaiKH"].ToString();
        //    lblAddress.Text = data["DiaChi"].ToString();
        //    lblNationality.Text= data["QuocTich"].ToString();
        //    lblRoomName.Text= data["TenPhong"].ToString();
        //    lblRoomTypeName.Text= data["LoaiPhong"].ToString();
        //    lblRoomPrice_.Text=((int)data["DonGia"]).ToString();
        //    lblDateCheckIn.Text=((DateTime)data["NgayDen"]).ToString().Split(' ')[0];
        //    DateTime dateCheckIn= (DateTime)data["NgayDen"];
        //    DateTime dateCheckOut = (DateTime)data["NgayDi"];
        //    int days = dateCheckOut.Subtract(dateCheckIn).Days;
        //    lblDays.Text = days.ToString();
        //    lblPeoples.Text = RoomDAO.Instance.GetPeople(idBill).ToString();
        //    lblSurcharge.Text= ((int)data["PhuThu"]).ToString();
        //    lblServicePrice.Text= ((int)data["TienDichVu"]).ToString();
        //    lblRoomPrice.Text= ((int)data["TienPhong"]).ToString();
        //    lblTotalPrice.Text= ((int)data["ThanhTien"]).ToString();
        //    lblFinalPrice.Text= ((int)data["ThanhTien"]*((100-(int)data["GiamGia"])/100.0)).ToString();
        //    lblDiscount.Text= ((int)data["GiamGia"]).ToString()+" %";
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
            Graphics graphics = this.CreateGraphics();
            bitmap = new Bitmap(708, 647, graphics);
            Graphics _graphics = Graphics.FromImage(bitmap);
            _graphics.CopyFromScreen(this.Location.X, this.Location.Y + 28, 0, 0, new Size(708, 647));
            bitmap.Save(Application.StartupPath + @"\Bill.Png", ImageFormat.Png);
            bitmap = new Bitmap(Application.StartupPath + @"\Bill.Png");
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();


            //DocumentPrinter printer = new DocumentPrinter();

            //// To save the form as a PDF
            //printer.SaveAsPdf(this, @"C:\data\Bill.pdf");

        }
    }
}
