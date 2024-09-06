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
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HotelManager
{   
    public partial class fReceiveRoom : Form
    {
        public class BookedForCustomersUI
        {
            string customerName;
            string customerId;
            int bookingId;
            int roomId;
            string roomName;
            string roomTypeName;
            int price;
            int bookingType;
            DateTime bookingDate;
            DateTime checkInDate;
            DateTime checkOutDate;
            Boolean isChecked;
            public void InitFromDataRow(DataRow row)
            {
                customerName = row["CustomerName"].ToString();
                customerId = row["CustomerID"].ToString();
                roomTypeName = row["RoomTypeName"].ToString();
                roomName = row["RoomName"].ToString();
                RoomId = (int)row["RoomId"];
                BookingId = (int)row["BookingId"];
                price = (int)row["Price"];
                bookingType = (int)row["BookingType"];
                bookingDate = (DateTime)row["Booking Date"];
                checkInDate = (DateTime)row["Check-in Date"];
                checkOutDate = (DateTime)row["Check out Date"];
                isChecked = false;
            }
            public string CustomerName { get => customerName; set => customerName = value; }
            public string CustomerId { get => customerId; set => customerId = value; }
            public string RoomName { get => roomName; set => roomName = value; }
            public int Price { get => price; set => price = value; }
            public int BookingType { get => bookingType; set => bookingType = value; }
            public string RoomTypeName { get => roomTypeName; set => roomTypeName = value; }
            public DateTime BookingDate { get => bookingDate; set => bookingDate = value; }
            public DateTime CheckInDate { get => checkInDate; set => checkInDate = value; }
            public DateTime CheckOutDate1 { get => checkOutDate; set => checkOutDate = value; }
            public bool IsChecked { get => isChecked; set => isChecked = value; }
            public int RoomId { get => roomId; set => roomId = value; }
            public int BookingId { get => bookingId; set => bookingId = value; }
        }
        List<int> ListIDCustomer=new List<int>();
        int IDBookRoom=-1;
        DateTime dateCheckIn;
        string userName;
        public fReceiveRoom(int idBookRoom)
        {
            IDBookRoom = idBookRoom;
            InitializeComponent();
            LoadData();
            ShowBookRoomInfo(IDBookRoom);
        }
        public fReceiveRoom(string userName)
        {
            this.userName = userName;
            InitializeComponent();
            LoadData();
            AppLogger.Instance.LogError($"fReceiveRoom Loaded");

        }
        public void LoadData()
        {
            LoadListRoomType();
            LoadReceiveRoomInfo();
        }
        public void LoadListRoomType()
        {
            List<RoomType> rooms = RoomTypeDAO.Instance.LoadListRoomType();
            cbRoomType.DataSource = rooms;
            cbRoomType.DisplayMember = "Name";
        }
        public void LoadFullRooms(int idRoomType)
        {
            List<Room> rooms = RoomDAO.Instance.LoadListFullRoom();
            rooms = rooms.Where(p=>p.IdRoomType == idRoomType).ToList();
            cbRoom.DataSource = rooms;
            cbRoom.DisplayMember = "Name";
        }
        public void LoadEmptyRoom(int idRoomType)
        {
            List<Room> rooms = RoomDAO.Instance.LoadEmptyRoomsInCategory(idRoomType);
            cbRoom.DataSource = rooms;
            cbRoom.DisplayMember = "Name";
        }
        public bool IsIDBookRoomExists(int idBookRoom)
        {
            return BookRoomDAO.Instance.IsIDBookRoomExists(idBookRoom);
        }
        public void ShowBookRoomInfo(int idBookRoom)
        {
            System.Data.DataTable dataTable = BookRoomDAO.Instance.ShowBookRoomInfo(idBookRoom);
            LoadRooms(dataTable);
        }
        public bool InsertReceiveRoom(int idBookRoom, int idRoom, DateTime checkOutDate)
        {
            return ReceiveRoomDAO.Instance.InsertReceiveRoom(idBookRoom, idRoom, checkOutDate, this.userName);
        }
        public bool InsertReceiveRoomDetails(int idReceiveRoom, int idCustomerOther)
        {
            return ReceiveRoomDetailsDAO.Instance.InsertReceiveRoomDetails(idReceiveRoom, idCustomerOther);
        }
        public void LoadReceiveRoomInfo()
        {
            //dataGridViewReceiveRoom.DataSource = ReceiveRoomDAO.Instance.LoadReceiveRoomInfo();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFullRooms((cbRoomType.SelectedItem as RoomType).Id);
        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txbIDBookRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                btnSearch_Click(sender, null);
        }
        private void LoadRooms(System.Data.DataTable dataTable)
        {
            List<BookedForCustomersUI> bookedForCustomersUIs = new List<BookedForCustomersUI>();
            foreach (DataRow dr in dataTable.Rows)
            {
                BookedForCustomersUI uI = new BookedForCustomersUI();
                uI.InitFromDataRow(dr);
                bookedForCustomersUIs.Add(uI);
            }
            //BindingSource source = new BindingSource();
            //source.DataSource = bookedForCustomersUIs;
            bookedForCustomersUIBindingSource.DataSource = bookedForCustomersUIs;
            bookedForCustomersUIBindingSource.ResetBindings(false);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txbIDBookRoom.Text!=string.Empty)
            {
                if (IsIDBookRoomExists(int.Parse(txbIDBookRoom.Text)))
                {
                    btnSearch.Tag = txbIDBookRoom.Text;
                    ShowBookRoomInfo(int.Parse(txbIDBookRoom.Text));
                }
                else
                   MessageBox.Show("Reservation code does not exist.\nPlease re-enter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbIDBookRoom.Text = string.Empty;
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if ( txbFullName.Text != string.Empty && txbIDCard.Text != string.Empty)
            {
                fAddCustomerInfo fAddCustomerInfo = new fAddCustomerInfo();
                fAddCustomerInfo.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Please re-enter complete information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private int TotalSum4Room(DateTime checkInDate, DateTime checkOutDate, int pricePerNight)
        {
            TimeSpan difference = checkOutDate - checkInDate;
            // Get the number of days
            int numberOfDays = difference.Days;
            return pricePerNight * numberOfDays;
        }
        private void btnReceiveRoom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to check out?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if ( dataGridView1.Rows.Count > 0)
                {
                    if (dataGridView1.IsCurrentCellDirty)
                    {
                        dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }

                    bookedForCustomersUIBindingSource.EndEdit();
                    List< BookedForCustomersUI> items = bookedForCustomersUIBindingSource.DataSource as List<BookedForCustomersUI>;
                    items = items.FindAll(p => p.IsChecked);
                    if (items.Count > 0)
                    {
                        foreach(BookedForCustomersUI item in items)
                        {
                            if (InsertReceiveRoom(item.BookingId, item.RoomId, item.CheckOutDate1))
                            {
                                int roomPrice = TotalSum4Room(item.CheckInDate, item.CheckOutDate1, item.Price);

                                //add bill for the room
                                InsertBillForCheckedOutRoom(item.BookingId, roomPrice);
                                MessageBox.Show("Check out successful.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadEmptyRoom((cbRoomType.SelectedItem as RoomType).Id);
                            }
                            else
                                MessageBox.Show("Check out failed.\nPlease re-enter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Check out date is invalid.\nPlease re-enter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearData();
                    LoadReceiveRoomInfo();
                }
                else
                    MessageBox.Show("Please check atleast one room to be checked out", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool InsertBillForCheckedOutRoom(int bookingId, int roomPrice)
        {
            return BillDAO.Instance.InsertBill(bookingId, this.userName, roomPrice);
        }

        public void ClearData()
        {
            txbFullName.Text = txbIDCard.Text = string.Empty;

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            //fReceiveRoomDetails f = new fReceiveRoomDetails((int)dataGridViewReceiveRoom.SelectedRows[0].Cells[0].Value);
            //f.ShowDialog();
            //Show();
            //LoadReceiveRoomInfo();
        }

        private void btnSearchForCustomer_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dataTable = ReceiveRoomDAO.Instance.LoadBookedRoomsByCustomer(txbFullName.Text.Trim(), txbIDCard.Text.Trim());
            LoadRooms(dataTable);
        }

        private void btnSearch4RoomBooking_Click(object sender, EventArgs e)
        {
            //LoadBookedRoomsByRoomNameAndType
            System.Data.DataTable dataTable = ReceiveRoomDAO.Instance.LoadBookedRoomsByRoomNameAndType(cbRoom.Text.Trim(), cbRoomType.Text.Trim());
            LoadRooms(dataTable);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void fReceiveRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppLogger.Instance.LogError($"fReceiveRoom Closing");
        }
    }
}
