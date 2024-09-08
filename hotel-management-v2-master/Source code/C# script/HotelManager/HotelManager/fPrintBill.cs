using HotelManager.DAO;
using HotelManager.DTO;
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
using static HotelManager.fUseService;

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
            lblIDBill.Text = idBill.ToString();
            lblDateCreate.Text = dateOfCreate;
            lblStaffSetUp.Text = AccountDAO.Instance.GetStaffSetUp(idBill).DisplayName;
        }
        public fPrintBill(int idBooking, string customerName, string phoneNumber)
        {
            InitializeComponent();

            //ShowBillPreView(idBill);
            ShowBill(idBooking);
            this.lblCustomerName.Text = customerName;
           this.lblPhoneNumber.Text = phoneNumber.ToString();
            //lblIDBill.Text = idBill.ToString();
            lblDateCreate.Text = DateTime.Now.ToString();
            //lblStaffSetUp.Text = AccountDAO.Instance.GetStaffSetUp(idBill).DisplayName;
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
        public void ShowBillRoom(int idRoom)
        {
            //bindingSourceRoomBill.DataSource = null;
            //Room4GUI room = flowLayoutRooms.Tag as Room4GUI;
            //if (room == null || room.BookingId <= 0) return;
            ////DataRow data = BillDAO.Instance.ShowBillRoom(idRoom);
            ////	select A.Name RoomName,D.Price [Price Per Night] ,C.DateCheckIn [Check-in Date],B.CheckOutDate as [Check-out Date]  ,E.RoomPrice [Bill Room price],E.Surcharge [Surcharge]


            //ShowBillRoonInView showBillRoonInView = new ShowBillRoonInView()
            //{
            //    RoomName = room.Room.Name.ToString(),
            //    //ActualPricePerNight = (int)data["Actual Price Per Night"],
            //    CheckInDate1 = room.CheckInDate,
            //    CheckOutDate1 = room.CheckOutDate,
            //    PriceChargedPerNight = room.PricePerNight
            //};

            //showBillRoonInView.TotalStayCharges4Room = room.Total4Room;
            //totalPrice += room.Total4Room;
            //bindingSourceRoomBill.DataSource = showBillRoonInView;
            //bindingSourceRoomBill.ResetBindings(false);
            //dataGridView1.Refresh();

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
            _graphics.CopyFromScreen(this.Location.X, this.Location.Y+28,0,0,new Size(708, 647));
            bitmap.Save(Application.StartupPath+ @"\Bill.Png", ImageFormat.Png);
            bitmap = new Bitmap(Application.StartupPath + @"\Bill.Png");
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }
    }
}
