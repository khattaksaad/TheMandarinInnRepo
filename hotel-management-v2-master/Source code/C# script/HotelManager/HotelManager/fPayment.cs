using HotelManager.DAO;
using HotelManager.DTO;
using HotelManager.Utils;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using static HotelManager.fMethodOfPayment;
using static HotelManager.fUseService;

namespace HotelManager
{
    public partial class fPayment : Form
    {
        public class Room4GUI
        {
            Room room;
            int bookingId;
            int total4Room;
            int customerId;
            DateTime checkInDate;
            DateTime checkOutDate;
            int pricePerNight;
            int bookingType;
            public Room4GUI()
            {

            }
            public Room Room { get => room; set => room = value; }
            public int BookingId { get => bookingId; set => bookingId = value; }
            public int Total4Room { get => total4Room; set => total4Room = value; }
            public int CustomerId { get => customerId; set => customerId = value; }
            public DateTime CheckInDate { get => checkInDate; set => checkInDate = value; }
            public DateTime CheckOutDate { get => checkOutDate; set => checkOutDate = value; }
            public int PricePerNight { get => pricePerNight; set => pricePerNight = value; }
            public int BookingType { get => bookingType; set => bookingType = value; }
        }

        public class PaymentTotal
        {
            int totalAmount;
            int dueAmount;
            int paidAmount;
            int discount;
            int surcharge;

            public int TotalAmount { get => totalAmount; set => totalAmount = value; }
            public int DueAmount { get => dueAmount; set => dueAmount = value; }
            public int PaidAmount { get => paidAmount; set => paidAmount = value; }
            public int Discount { get => discount; set => discount = value; }
            public int Surcharge { get => surcharge; set => surcharge = value; }
        }
        string staffSetUp;
        List<Company> companyList;
        List<Customer> customers;
        List<Room4GUI> roomsDisplayed;
        public fPayment(string userName)
        {
            staffSetUp = userName;         
            InitializeComponent();
            System.Data.DataTable dtCustomers = CustomerDAO.Instance.LoadFullCustomer();
            System.Data.DataTable dtCompany = CompanyDAO.Instance.LoadFullCompany();
            customers = new List<Customer>();
            companyList = new List<Company>();
            foreach (DataRow dr in dtCustomers.Rows)
            {
                Customer customer = new Customer(dr);
                customers.Add(customer);
            }
            foreach(DataRow dr in dtCompany.Rows)
            {
                Company company = new Company(dr);
                companyList.Add(company);
            }
            LoadData();

            cbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCustomers.DataSource = companyList;
            cbCustomers.ValueMember = "Id";
            cbCustomers.DisplayMember = "CompanyName";
            cbCustomers.SelectedValue = companyList.FirstOrDefault();
            AppLogger.Instance.LogError($"fPayment Loaded");

        }
        private void LoadData()
        {
            LoadCheckedOutOpenBillRooms();
        }
        public void Pay(int idBill, int discount)
        {
            BillDAO.Instance.UpdateRoomPrice(idBill);
            BillDAO.Instance.UpdateServicePrice(idBill);
            BillDAO.Instance.UpdateOther(idBill, discount);

        }
        public void LoadListRoomType()
        {
            List<RoomType> roomTypes = RoomTypeDAO.Instance.LoadListRoomType();
            switch(roomTypes.Count)
            {
                case 0:
                    {
                        color1.Visible = color3.Visible = color4.Visible =  false;
                        lblRoomType1.Visible = lblRoomType3.Visible = lblRoomType4.Visible =  false;
                        break;
                    }
                case 1:
                    {
                        lblRoomType1.Text = roomTypes[0].Name;
                          color3.Visible = color4.Visible = false;
                         lblRoomType3.Visible = lblRoomType4.Visible =  false;
                        break;
                    }
                case 2:
                    {
                        lblRoomType1.Text = roomTypes[0].Name;
                        
                        color3.Visible = color4.Visible = false;
                        lblRoomType3.Visible = lblRoomType4.Visible  = false;
                        break;
                    }
                case 3:
                    {
                        lblRoomType1.Text = roomTypes[0].Name;
                        lblRoomType3.Text = roomTypes[2].Name;
                        color4.Visible = false;
                        lblRoomType4.Visible = false;
                        break;
                    }
                case 4:
                    {
                        lblRoomType1.Text = roomTypes[0].Name;
                        lblRoomType3.Text = roomTypes[2].Name;
                        lblRoomType4.Text = roomTypes[3].Name;
                        break;
                    }
            }
        }
        //public void LoadListServiceType()
        //{
        //    List<ServiceType> serviceTypes = ServiceTypeDAO.Instance.GetServiceTypes();
        //    cbServiceType.DataSource = serviceTypes;
        //    cbServiceType.DisplayMember = "Name";
        //    cbServiceType.ValueMember = "Id";
        //    cbServiceType.SelectedItem = serviceTypes.FirstOrDefault();
        //}
        //public void LoadListService(int idServiceType)
        //{
        //    services = ServiceDAO.Instance.GetServices(idServiceType);
        //    cbService.DataSource = services;
        //    cbService.DisplayMember = "Name";
        //    cbService.ValueMember = "Id";
        //}
        public void DrawControl(Room room, Bunifu.Framework.UI.BunifuTileButton button)
        {
            int idRoomTypeName = RoomTypeDAO.Instance.GetRoomTypeByIdRoom(room.Id).Id;
            switch (idRoomTypeName)
            {
                case 1:
                    {
                        button.BackColor = System.Drawing.Color.Tomato;
                        button.color = System.Drawing.Color.Tomato;
                        button.colorActive = System.Drawing.Color.LightSalmon;
                        break;
                    }
                case 4:
                    {
                        button.BackColor = System.Drawing.Color.Violet;
                        button.color = System.Drawing.Color.Violet;
                        button.colorActive = System.Drawing.Color.Thistle;
                        break;
                    }
                case 3:
                    {
                        button.BackColor = System.Drawing.Color.DeepSkyBlue;
                        button.color = System.Drawing.Color.DeepSkyBlue;
                        button.colorActive = System.Drawing.Color.LightSkyBlue;
                        break;
                    }
                case 2:
                    {
                        button.BackColor = System.Drawing.Color.LimeGreen;
                        button.color = System.Drawing.Color.LimeGreen;
                        button.colorActive = System.Drawing.Color.LightGreen;
                        break;
                    }
                default:
                    {
                        button.BackColor = System.Drawing.Color.Gray;
                        button.color = System.Drawing.Color.Gray;
                        button.colorActive = System.Drawing.Color.Silver;
                        break;
                    }
            }
        }
        public void LoadCheckedOutOpenBillRooms()
        {
            flowLayoutRooms.Controls.Clear();
            bindingSourceRoomBill.DataSource = null;
            listViewUseService.Items.Clear();
            System.Data.DataTable dataTable = BillDAO.Instance.GetCheckedOutRoomsOpenForBilling();
            //            Select r.Name, br.ID as [BookingId], cr.CheckOutDate as CheckedOutDate, br.IDCustomer as CustomerId, b.RoomPrice as [RoomTotal]
            roomsDisplayed = GetRoom4GUIs(dataTable);

            foreach (Room4GUI item in roomsDisplayed)
            {
                Bunifu.Framework.UI.BunifuTileButton button = new Bunifu.Framework.UI.BunifuTileButton();
                button.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                button.ForeColor = System.Drawing.Color.White;
                button.Image = global::HotelManager.Properties.Resources.Room;
                button.ImagePosition = 14;
                button.ImageZoom =36;
                button.LabelPosition = 38;
                button.Size = new System.Drawing.Size(110,110);
                button.Margin= new System.Windows.Forms.Padding(1,1,1,1);
                string customerName = customers.FirstOrDefault(f => f.Id == item.CustomerId).Name ?? string.Empty;
                button.Tag = item;
                button.LabelText =item.Room.Name + "\r\n"+customerName;
                button.Click += Button_Click;

                DrawControl(item.Room, button);
                
                flowLayoutRooms.Controls.Add(button);

                //BillDAO.Instance.UpdateRoomPrice(item.Id);
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            bindingSourceRoomBill.DataSource = null;
            totalPrice = 0;
            totalPaid = 0;
            Bunifu.Framework.UI.BunifuTileButton button = sender as Bunifu.Framework.UI.BunifuTileButton;
            flowLayoutRooms.Tag = button.Tag;
            button.BackColor = System.Drawing.Color.SeaGreen;
            button.color = System.Drawing.Color.SeaGreen;
            button.colorActive = System.Drawing.Color.MediumSeaGreen;
            foreach (var item in flowLayoutRooms.Controls)
            {
                if (item != button)
                    DrawControl(((item as Bunifu.Framework.UI.BunifuTileButton).Tag as Room4GUI).Room, item as Bunifu.Framework.UI.BunifuTileButton);
            }
            Room4GUI room = button.Tag as Room4GUI;
            roomsDisplayed = new List<Room4GUI>() { room };
            ShowBill(room.BookingId);
            ShowBillRoom(room.Room.Id);
            System.Data.DataTable data = BillDAO.Instance.GetBillsByBookingRoomId(room.BookingId);
            if (data == null || data.Rows.Count == 0)
            {
                //didnt find a bill?
                totalPaid = 0;
            }

            else
                totalPaid = Convert.ToInt32(data.Rows[0]["AmountPaid"]);
            txbPaid.Text = totalPaid.ToString();
            txbTotalPrice.Text = (Convert.ToInt32(data.Rows[0]["TotalPrice"]) - totalPaid).ToString();

            PaymentTotal payment = new PaymentTotal();
            payment.PaidAmount = totalPaid;
            payment.TotalAmount = Convert.ToInt32(data.Rows[0]["TotalPrice"]);
            payment.Discount = Convert.ToInt32(data.Rows[0]["Discount"]);
            payment.Surcharge = Convert.ToInt32(data.Rows[0]["Surcharge"]);
            tbDiscount.Text = payment.Discount.ToString();
            tbExtra.Text =  payment.Surcharge.ToString();
            payment.DueAmount = (payment.TotalAmount + payment.Surcharge) - (payment.PaidAmount + payment.Discount);
            bindingSourceTotal.DataSource = payment;
            bindingSourceTotal.ResetBindings(false);
            dataGridViewTotal.Refresh();
        }

        public bool IsExistsBill(int idRoom)
        {
            return BillDAO.Instance.IsExistsBill(idRoom);
        }
        public bool IsExistsBillDetails(int idRoom, int idService)
        {
            return BillDetailsDAO.Instance.IsExistsBillDetails(idRoom, idService);
        }
        //public bool InsertBill(int idReceiveRoom, string staffSetUp, int roomPrice)
        //{
        //    return BillDAO.Instance.InsertBill(idReceiveRoom, staffSetUp, roomPrice);
        //}
        public bool InsertBillDetails(int idBill, int idService, int count)
        {
            return BillDetailsDAO.Instance.InsertBillDetails(idBill, idService, count);
        }
        public bool UpdateBillDetails(int idBill, int idService, int _count)
        {
            return BillDetailsDAO.Instance.UpdateBillDetails(idBill, idService, _count);
        }
        public void AddBill(int idRoom,int idService,int count)
        {
            //if(IsExistsBill(idRoom))
            //{
            //    if(!IsExistsBillDetails(idRoom,idService))
            //    {
            //        if (count > 0)
            //        {
            //            int idBill = BillDAO.Instance.GetIdBillFromIdRoom(idRoom);
            //            InsertBillDetails(idBill, idService, count);
            //        }
            //        else
            //            MetroFramework.MetroMessageBox.Show(this, "Số lượng không hợp lệ.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        int idBill = BillDAO.Instance.GetIdBillFromIdRoom(idRoom);
            //        UpdateBillDetails(idBill, idService, count);
            //    }
            //}
            //else
            //{
            //    if (count > 0)
            //    {
            //        int idReceiveRoom = ReceiveRoomDAO.Instance.GetIdReceiveRoomFromIdRoom(idRoom);
            //        InsertBill(idReceiveRoom, staffSetUp);
            //        int idBill = BillDAO.Instance.GetIdBillMax();
            //        InsertBillDetails(idBill, idService, count);
            //    }
            //    else
            //        MetroFramework.MetroMessageBox.Show(this, "Số lượng không hợp lệ.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        int id = 1;
        int totalPrice = 0;
        int totalPaid = 0;
        public void ShowSurcharge()
        {
            string query = "select * from Parameter";
            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(id.ToString());
                id++;

                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, item["Name"].ToString());
                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, ((double)item["Value"]).ToString());
                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, (item["Describe"]).ToString());

                listViewItem.SubItems.Add(subItem1);
                listViewItem.SubItems.Add(subItem2);
                listViewItem.SubItems.Add(subItem3);

                //listViewSurcharge.Items.Add(listViewItem);
            }
            id = 0;
        }
        public void ShowBill(int bookingId)
        {
            listViewUseService.Items.Clear();
            System.Data.DataTable dataTable = ChargeService2RoomDAO.Instance.GetAllServiceChargesForARoom(bookingId);
            int _totalPrice = 0;
            foreach (DataRow item in dataTable.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(id.ToString());
                id++;

                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, item["Service Name"].ToString());
                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Price"]).ToString());
                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Quantity"]).ToString());


                _totalPrice += (int)item["Price"] * (int)item["Quantity"];

                listViewItem.SubItems.Add(subItem1);
                listViewItem.SubItems.Add(subItem2);
                listViewItem.SubItems.Add(subItem3);

                listViewUseService.Items.Add(listViewItem);
            }
            totalPrice += _totalPrice;

            ListViewItem listViewItemTotalPrice = new ListViewItem();
            ListViewItem.ListViewSubItem subItemTotalPrice = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, _totalPrice.ToString());
            ListViewItem.ListViewSubItem _subItem1 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
            ListViewItem.ListViewSubItem _subItem2 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
            ListViewItem.ListViewSubItem _subItem3 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
            listViewItemTotalPrice.SubItems.Add(_subItem1);
            listViewItemTotalPrice.SubItems.Add(_subItem2);
            listViewItemTotalPrice.SubItems.Add(_subItem3);
            listViewItemTotalPrice.SubItems.Add(subItemTotalPrice);
            listViewUseService.Items.Add(listViewItemTotalPrice);

            id = 1;
        }
        public void ShowBillRoom(int idRoom)
        {
            bindingSourceRoomBill.DataSource = null;
            Room4GUI room = flowLayoutRooms.Tag as Room4GUI;
            if (room == null || room.BookingId <= 0) return;
            //DataRow data = BillDAO.Instance.ShowBillRoom(idRoom);
            //	select A.Name RoomName,D.Price [Price Per Night] ,C.DateCheckIn [Check-in Date],B.CheckOutDate as [Check-out Date]  ,E.RoomPrice [Bill Room price],E.Surcharge [Surcharge]


            ShowBillRoonInView showBillRoonInView = new ShowBillRoonInView()
            {
                RoomName = room.Room.Name.ToString(),
                //ActualPricePerNight = (int)data["Actual Price Per Night"],
                CheckInDate1 = room.CheckInDate,
                CheckOutDate1 = room.CheckOutDate,
                PriceChargedPerNight = room.PricePerNight
            };

            showBillRoonInView.TotalStayCharges4Room = room.Total4Room;
            totalPrice += room.Total4Room;
            bindingSourceRoomBill.DataSource = showBillRoonInView;
            bindingSourceRoomBill.ResetBindings(false);
            dataGridView1.Refresh();

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbIDRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnAddService2Room_Click(object sender, EventArgs e)
        {
            Room4GUI roomSelected = flowLayoutRooms.Tag as Room4GUI;
            if (roomSelected == null)
            {
                MessageBox.Show("Please select a room first", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            this.Hide();
            int totalDue = 0;
            string bookingId = "";
            string customerName = string.Empty;
            string contactNumber = string.Empty;
            foreach (var item in roomsDisplayed)
            {
                //totalDue += item.Total4Room;
                bookingId += "," + item.BookingId;
                if (string.IsNullOrEmpty(contactNumber))
                {
                    if (item.BookingType == 0)
                    {
                        customerName = customers.FirstOrDefault(f => f.Id == item.CustomerId)?.Name ?? string.Empty;
                        contactNumber = customers.FirstOrDefault(f => f.Id == item.CustomerId)?.PhoneNumber ?? string.Empty;
                    }
                    else
                    {
                        customerName = companyList.FirstOrDefault(f => f.Id == item.CustomerId)?.CompanyName ?? string.Empty;
                        contactNumber = companyList.FirstOrDefault(f => f.Id == item.CustomerId)?.PhoneNumber ?? string.Empty;

                    }
                }
            }
            int discount = Convert.ToInt32(tbDiscount.Text);
            int surcharge = Convert.ToInt32(tbExtra.Text);
            fMethodOfPayment fMethodOfPayment = new fMethodOfPayment(new fMethodOfPayment.Payment()            
            { 
                DueAmount = Convert.ToInt32(txbTotalPrice.Text), 
                TotalAmount = totalPrice,
                CustomerName = customerName,
                PhoneNumber = contactNumber, 
                BookingId = bookingId.TrimStart(','), 
                Discount = discount,
                Surcharge = surcharge        
            }, new List<Room4GUI>() { roomSelected }, staffSetUp);
            fMethodOfPayment.ShowDialog();
            LoadData();
            bindingSourceTotal.DataSource = null;
            tbDiscount.Text = string.Empty;
            tbExtra.Text = string.Empty;
            this.Show();
        }

        private void listViewBillRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbService_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //if (cbService.SelectedItem != null)
            //    txbPrice.Text = (cbService.SelectedItem as Service).Price.ToString();
        }


        private List<Room4GUI> GetRoom4GUIs(System.Data.DataTable dataTable)
        {
            List<Room4GUI> rooms = new List<Room4GUI>();
            foreach (DataRow item in dataTable.Rows)
            {
                Room4GUI room4GUI = new Room4GUI();
                room4GUI.Room = new Room(item);

                room4GUI.BookingId = Convert.ToInt32(item["BookingId"]);
                room4GUI.CustomerId = Convert.ToInt32(item["CustomerId"]);
                //
                room4GUI.Total4Room = Convert.ToInt32(item["RoomTotal"]);
                room4GUI.CheckInDate = Convert.ToDateTime(item["Check-in Date"]);
                room4GUI.CheckOutDate = Convert.ToDateTime(item["Checked out Date"]);
                room4GUI.PricePerNight = Convert.ToInt32(item["PriceChargedPerNight"]);
                room4GUI.BookingType = Convert.ToInt32(item["BookingType"]);
                rooms.Add(room4GUI);
            }
            return rooms;
        }
        private void LoadRoomData()
        {
            bindingSourceRoomBill.DataSource = null;
            totalPrice = totalPaid = 0;
            txbTotalPrice.Text = totalPrice.ToString();

        }
        private void btnSearch4Customers_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbCustomers.Text)) return;
            bindingSourceRoomBill.DataSource = null;

            //is a company selected
            roomsDisplayed =   GetRoom4GUIs(BillDAO.Instance.GetCheckedOutRoomByCompanyOpenForBilling((int)cbCustomers.SelectedValue));
            
            foreach(Room4GUI room in roomsDisplayed)
            {

                if (room == null || room.BookingId <= 0) return;
                //DataRow data = BillDAO.Instance.ShowBillRoom(idRoom);
                //	select A.Name RoomName,D.Price [Price Per Night] ,C.DateCheckIn [Check-in Date],B.CheckOutDate as [Check-out Date]  ,E.RoomPrice [Bill Room price],E.Surcharge [Surcharge]

                ListViewItem listViewItem = new ListViewItem(room.Room.Name);
                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, (room.CheckInDate).ToString().Split(' ')[0]);
                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, (room.CheckOutDate).ToString().Split(' ')[0]);
                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, (room.PricePerNight).ToString());

                ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem(listViewItem, (room.Total4Room).ToString());
                //ListViewItem.ListViewSubItem subItem5 = new ListViewItem.ListViewSubItem(listViewItem, room.Total4Room.ToString());
                totalPrice += room.Total4Room;

                listViewItem.SubItems.Add(subItem1);
                listViewItem.SubItems.Add(subItem2);
                listViewItem.SubItems.Add(subItem3);
                listViewItem.SubItems.Add(subItem4);
                //listViewItem.SubItems.Add(subItem5);
                txbTotalPrice.Text = totalPrice.ToString();
                bindingSourceRoomBill.DataSource = null;
            }
            int i = 0;
        }

        private void checkBoxPayment4Company_CheckedChanged(object sender, EventArgs e)
        {
            cbCustomers.Enabled = checkBoxPayment4Company.Checked;           
        }

        private void fPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppLogger.Instance.LogError($"fPayment Closing");

        }

        private void tbDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbExtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbDiscount_OnValueChanged(object sender, EventArgs e)
        {
            if (dataGridViewTotal.Rows.Count <= 0) return;
            PaymentTotal payment = dataGridViewTotal.Rows[0].DataBoundItem as PaymentTotal;

            if (string.IsNullOrEmpty(tbDiscount.Text) || tbDiscount.Text.Count() == 0) {
                payment.Discount = 0;
            }
            else
            {
                payment.Discount = Convert.ToInt32(tbDiscount.Text);
            }
            payment.DueAmount = (payment.TotalAmount + payment.Surcharge) - (payment.PaidAmount + payment.Discount);
            bindingSourceTotal.DataSource = payment;
            bindingSourceTotal.ResetBindings(false);
            dataGridViewTotal.Refresh();

        }

        private void tbExtra_OnValueChanged(object sender, EventArgs e)
        {
            if (dataGridViewTotal.Rows.Count <= 0) return;
            PaymentTotal payment = dataGridViewTotal.Rows[0].DataBoundItem as PaymentTotal;
            if (string.IsNullOrEmpty(tbExtra.Text) || tbExtra.Text.Count() == 0)
            {
                payment.Surcharge = 0;
            }
            else
            {
                payment.Surcharge = Convert.ToInt32(tbExtra.Text);
            }

            payment.DueAmount = (payment.TotalAmount + payment.Surcharge) - (payment.PaidAmount + payment.Discount);
            bindingSourceTotal.DataSource = payment;
            bindingSourceTotal.ResetBindings(false);
            dataGridViewTotal.Refresh();

        }
    }
}
