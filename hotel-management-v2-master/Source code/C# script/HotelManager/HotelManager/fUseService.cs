using HotelManager.DAO;
using HotelManager.DTO;
using HotelManager.Utils;
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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelManager
{
    public partial class fUseService : Form
    {
        string staffSetUp;
        List<Service> services;
        public class ServicesUsed4GUI
        {
            private int serviceID;
            private int price;
            private string serviceName;
            private int quantity;
            private int chargeServiceId;
            public int Quantity { get => quantity; set => quantity = value; }
            public string ServiceName { get => serviceName; set => serviceName = value; }
            public int Price { get => price; set => price = value; }
            public int ServiceID { get => serviceID; set => serviceID = value; }
            public int ChargeServiceId { get => chargeServiceId; set => chargeServiceId = value; }
        }
        public class ShowBillRoonInView
        {
            string roomName;
            int actualPricePerNight;
            DateTime CheckInDate;
            DateTime CheckOutDate;
            int priceChargedPerNight;
            int totalStayCharges4Room;

            public string RoomName { get => roomName; set => roomName = value; }
            public int ActualPricePerNight { get => actualPricePerNight; set => actualPricePerNight = value; }
            public DateTime CheckInDate1 { get => CheckInDate; set => CheckInDate = value; }
            public DateTime CheckOutDate1 { get => CheckOutDate; set => CheckOutDate = value; }
            public int PriceChargedPerNight { get => priceChargedPerNight; set => priceChargedPerNight = value; }
            public int TotalStayCharges4Room { get => totalStayCharges4Room; set => totalStayCharges4Room = value; }
        }

        private class Room4GUI
        {
            Room room;
            int bookingId;
            public Room4GUI()
            {

            }
            public Room Room { get => room; set => room = value; }
            public int BookingId { get => bookingId; set => bookingId = value; }
        }
        public fUseService(string userName)
        {
            staffSetUp = userName;
            InitializeComponent();
            LoadData();
            cbService.SelectedIndexChanged += cbService_SelectedIndexChanged;
            cbService.DropDownStyle = ComboBoxStyle.DropDown;
        }
        private void LoadData()
        {
            LoadListServiceType();
            LoadListRoomType();
            LoadListFullRoom();
            //ShowSurcharge();
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
            switch (roomTypes.Count)
            {
                case 0:
                    {
                        color1.Visible = color3.Visible = color4.Visible = false;
                        lblRoomType1.Visible = lblRoomType3.Visible = lblRoomType4.Visible = false;
                        break;
                    }
                case 1:
                    {
                        lblRoomType1.Text = roomTypes[0].Name;
                        color3.Visible = color4.Visible = false;
                        lblRoomType3.Visible = lblRoomType4.Visible = false;
                        break;
                    }
                case 2:
                    {
                        lblRoomType1.Text = roomTypes[0].Name;

                        color3.Visible = color4.Visible = false;
                        lblRoomType3.Visible = lblRoomType4.Visible = false;
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
        public void LoadListServiceType()
        {
            List<ServiceType> serviceTypes = ServiceTypeDAO.Instance.GetServiceTypes();
            cbServiceType.DataSource = serviceTypes;
            cbServiceType.DisplayMember = "Name";
            cbServiceType.ValueMember = "Id";
            cbServiceType.SelectedItem = serviceTypes.FirstOrDefault();
        }
        public void LoadListService(int idServiceType)
        {
            services = ServiceDAO.Instance.GetServices(idServiceType);
            cbService.DataSource = services;
            cbService.DisplayMember = "Name";
            cbService.ValueMember = "Id";
        }
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
        public void LoadListFullRoom()
        {
            flowLayoutRooms.Controls.Clear();
            //listViewBillRoom.Items.Clear();
            bindingSourceServicesUsed.Clear();
            DataTable dataTable = RoomDAO.Instance.LoadListFullRoomsNotCheckedOutYetAsDataTable();
            List<Room4GUI> rooms = new List<Room4GUI>();
            foreach (DataRow item in dataTable.Rows)
            {
                Room4GUI room4GUI = new Room4GUI();
                room4GUI.Room = new Room(item);

                room4GUI.BookingId = Convert.ToInt32(item["BookingId"]);
                rooms.Add(room4GUI);
            }

            foreach (Room4GUI item in rooms)
            {
                Bunifu.Framework.UI.BunifuTileButton button = new Bunifu.Framework.UI.BunifuTileButton();
                button.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                button.ForeColor = System.Drawing.Color.White;
                button.Image = global::HotelManager.Properties.Resources.Room;
                button.ImagePosition = 14;
                button.ImageZoom = 36;
                button.LabelPosition = 29;
                button.Size = new System.Drawing.Size(110, 95);
                button.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);

                button.Tag = item;
                button.LabelText = item.Room.Name;
                button.Click += Button_Click;

                DrawControl(item.Room, button);

                flowLayoutRooms.Controls.Add(button);

                //BillDAO.Instance.UpdateRoomPrice(item.Id);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            //slistViewBillRoom.Items.Clear();
            totalPrice = 0;
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
            ShowBill(room.BookingId);
            //if (!BillDAO.Instance.IsExistsBill(room.Room.Id))
            //{
            //    int idReceiveRoom = ReceiveRoomDAO.Instance.GetIdReceiveRoomFromIdRoom(room.Room.Id);
            //    InsertBill(idReceiveRoom, staffSetUp);
            //}
            //BillDAO.Instance.UpdateRoomPrice(BillDAO.Instance.GetIdBillFromIdRoom(room.Room.Id));
            ShowBillRoom(room.Room.Id);

            txbTotalPrice.Text = totalPrice.ToString();
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
        public void AddBill(int idRoom, int idService, int count)
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
        public void ShowSurcharge()
        {
            string query = "select * from Parameter";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
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
            bindingSourceServicesUsed.Clear();
            DataTable dataTable = ChargeService2RoomDAO.Instance.GetAllServiceChargesForARoom(bookingId);
            int _totalPrice = 0;
            List<ServicesUsed4GUI> servicesUsed = new List<ServicesUsed4GUI>();
            int total4Services = 0;
            foreach (DataRow item in dataTable.Rows)
            {
                ServicesUsed4GUI servicesUsed4GUI = new ServicesUsed4GUI();
                servicesUsed4GUI.ServiceName = item["Service Name"].ToString();
                servicesUsed4GUI.ServiceID = (int)item["ServiceId"];
                servicesUsed4GUI.Price = (int)item["Price"];
                servicesUsed4GUI.Quantity = (int)item["Quantity"];
                servicesUsed4GUI.ChargeServiceId = (int)item["ChargeId"];
                servicesUsed.Add(servicesUsed4GUI);

                total4Services += servicesUsed4GUI.Price * servicesUsed4GUI.Quantity;
                _totalPrice += servicesUsed4GUI.Price * servicesUsed4GUI.Quantity;
            }
            bindingSourceServicesUsed.DataSource = servicesUsed;
            bindingSourceServicesUsed.ResetBindings(false);
            dataGridViewServicesUsed.Refresh();
            txtbTotalServices.Text = total4Services.ToString();
            totalPrice += _totalPrice;
        }
        public void ShowBillRoom(int idRoom)
        {
            DataRow data = BillDAO.Instance.ShowBillRoom(idRoom);
            if (data != null)
            {
                ShowBillRoonInView showBillRoonInView = new ShowBillRoonInView()
                {
                    RoomName = data["RoomName"].ToString(),
                    ActualPricePerNight = (int)data["Actual Price Per Night"],
                    CheckInDate1 = (DateTime)data["Check-in Date"],
                    CheckOutDate1 = (DateTime)data["Check-out Date"],
                    PriceChargedPerNight = (int)data["Price charged per night"]
                };
                TimeSpan difference = (DateTime)data["Check-out Date"] - ((DateTime)data["Check-in Date"]);

                // Get the number of days
                int numberOfDays = difference.Days;
                int roomPrice = (int)data["Price charged per night"] * numberOfDays;
                showBillRoonInView.TotalStayCharges4Room = roomPrice;
                totalPrice += roomPrice;
                bindingSourceRoomBill.DataSource = showBillRoonInView;
                bindingSourceRoomBill.ResetBindings(false);
                dataGridView1.Refresh();
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadListService((cbServiceType.SelectedItem as ServiceType).Id);
        }
        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbService.SelectedItem != null)
                txbPrice.Text = (cbService.SelectedItem as Service).Price.ToString();
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
            try
            {
                Room4GUI room = flowLayoutRooms.Tag as Room4GUI;
                if (room == null || room.BookingId <= 0) return;
                //int service = services.FirstOrDefault(f => f.Name.Equals(cbService.Text))?.Id ?? 0;
                //its a new service; save the service first.
                int o = Convert.ToInt32(cbServiceType.SelectedValue);
                object ok = cbService.SelectedValue;
                if (ok == null && cbService.Text.Trim().Length > 0)
                {
                    ServiceDAO.Instance.InsertService(cbService.Text.Trim(), o, int.Parse(txbPrice.Text));
                    string st = cbService.Text.Trim();
                    services = ServiceDAO.Instance.GetServices(o);
                    cbService.DataSource = services;
                    cbService.SelectedItem = services.First(p => p.Name.Equals(st));
                }

                ChargeService2RoomDAO.Instance.Insert(room.BookingId, (int)cbService.SelectedValue, staffSetUp, int.Parse(txbPrice.Text), (int)numericUpDownCount.Value);
                //refresh the list
                ShowBill(room.BookingId);
                txbTotalPrice.Text = totalPrice.ToString();
                ThermalReceiptPrinter thermalReceiptPrinter = new ThermalReceiptPrinter(room.Room.Name, cbService.Text.ToString(), (int)numericUpDownCount.Value);
                thermalReceiptPrinter.PrintReceipt();
            }
            catch (Exception ex)
            {
                AppLogger.Instance.LogError("Following exception occurred while trying to add service to room", ex);
                MessageBox.Show("An error occurred, please try again later or contact support");
            }
        }

        private void listViewBillRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRemoveServices_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewServicesUsed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewServicesUsed.Columns["colDelete"].Index && !dataGridViewServicesUsed.Rows[e.RowIndex].IsNewRow)
            {
                ServicesUsed4GUI selectedRow = dataGridViewServicesUsed.Rows[e.RowIndex].DataBoundItem as ServicesUsed4GUI;
                Room4GUI room = flowLayoutRooms.Tag as Room4GUI;
                if (room == null || room.BookingId <= 0) return;
                ChargeService2RoomDAO.Instance.Delete(room.BookingId, selectedRow.ChargeServiceId);
                dataGridViewServicesUsed.Rows.RemoveAt(e.RowIndex);
                ShowBill(room.BookingId);
            }
        }

        private void txbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
