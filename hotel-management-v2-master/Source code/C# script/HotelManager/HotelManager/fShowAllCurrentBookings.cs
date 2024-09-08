using HotelManager.DAO;
using HotelManager.DTO;
using HotelManager.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HotelManager.fShowAllCurrentBookings;
using static HotelManager.fUseService;

namespace HotelManager
{
    public partial class fShowAllCurrentBookings : Form
    {
        public class AdvanceBooking4View
        {
            private string roomType;
            private string customerName;
            private DateTime dateIn;
            private DateTime dateOut;
            private DateTime dateBookRoom;
            private int advanceBookingId;
            public string RoomType { get => roomType; set => roomType = value; }
            public string CustomerName { get => customerName; set => customerName = value; }
            public DateTime DateIn { get => dateIn; set => dateIn = value; }
            public DateTime DateOut { get => dateOut; set => dateOut = value; }
            public DateTime DateBookRoom { get => dateBookRoom; set => dateBookRoom = value; }
            public int AdvanceBookingId { get => advanceBookingId; set => advanceBookingId = value; }
        }
        public class RoomBooking4View
        {
            private DateTime dateCheckIn;
            private DateTime dateCheckOut;
            private DateTime dateBookRoom;
            private int reservationId;
            private string customerName;
            private string roomTypeName;
            private Room room;

            public DateTime DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
            public DateTime DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
            public DateTime DateBookRoom { get => dateBookRoom; set => dateBookRoom = value; }
            public int ReservationId { get => reservationId; set => reservationId = value; }
            public string CustomerName { get => customerName; set => customerName = value; }
            public Room Room { get => room; set => room = value; }
            public string RoomTypeName { get => roomTypeName; set => roomTypeName = value; }
        }
        private int idStaffType = -1;
        List<Room> rooms = new List<Room>();
        List<Customer> customers = new List<Customer>();
        List<Company> companies = new List<Company>();
        string userName;
        public fShowAllCurrentBookings(string userName)
        {
            this.userName = userName;
            InitializeComponent();
            InitData();
        }



        #region Load
        public void InitData()
        {
            DataTable dtCustomers = CustomerDAO.Instance.LoadFullCustomer();
            DataTable dtCompanies = CompanyDAO.Instance.LoadFullCompany();
            foreach (DataRow dr in dtCustomers.Rows)
            {
                Customer customer = new Customer(dr);
                customers.Add(customer);
            }
            foreach (DataRow dr in dtCompanies.Rows)
            {
                companies.Add(new Company(dr));
            }
            RefreshCurrentBookingsView();

            RefreshAdvanceBookingView();

        }
        void RefreshCurrentBookingsView()
        {
            DataTable dtRoomsBooked = BookRoomDAO.Instance.LoadListAllBookedRooms();
            List<RoomBooking4View> roomBookings = new List<RoomBooking4View>();
            foreach (DataRow dataRow in dtRoomsBooked.Rows)
            {
                RoomBooking4View roomBooking = new RoomBooking4View();
                roomBooking.DateCheckIn = (DateTime)dataRow["Check-In date"];
                roomBooking.DateCheckOut = (DateTime)dataRow["Check out date"];
                roomBooking.DateBookRoom = (DateTime)dataRow["DateBookRoom"];

                if (Convert.ToInt32(dataRow["Booking Type"]) == 0)
                {
                    //load customer else company
                    roomBooking.CustomerName = customers.FirstOrDefault(p => p.Id == Convert.ToInt32(dataRow["CustomerID"])).Name ?? string.Empty;
                }
                else
                {
                    roomBooking.CustomerName = companies.FirstOrDefault(p => p.Id == Convert.ToInt32(dataRow["CustomerID"])).CompanyName ?? string.Empty;

                }

                roomBooking.ReservationId = (int)dataRow["Id"];
                roomBooking.RoomTypeName = dataRow["Room Type Name"].ToString();
                roomBooking.Room = new Room()
                {
                    Id = (int)dataRow["RoomNo"],
                    IdRoomType = (int)dataRow["RoomType"],
                    Name = dataRow["RoomName"].ToString()
                };

                roomBookings.Add(roomBooking);
            }
            roomBooking4ViewBindingSource.DataSource = roomBookings;
            roomBooking4ViewBindingSource.ResetBindings(false);
            dataGridViewRoom.Refresh();
        }

        private void RefreshAdvanceBookingView()
        {
            DataTable dtAdvanceBookings = AdvanceBookingDAO.Instance.LoadListAllAdvanceBookings();

            List<AdvanceBooking4View> aBookings = new List<AdvanceBooking4View>();
            foreach (DataRow dataRow in dtAdvanceBookings.Rows)
            {
                AdvanceBooking4View advanceBooking4View = new AdvanceBooking4View();
                if (Convert.ToInt32(dataRow["BookingType"]) == 0)
                {
                    //load customer else company
                    advanceBooking4View.CustomerName = customers.FirstOrDefault(p => p.Id == Convert.ToInt32(dataRow["CustomerID"])).Name ?? string.Empty;
                }
                else
                {
                    advanceBooking4View.CustomerName = companies.FirstOrDefault(p => p.Id == Convert.ToInt32(dataRow["CustomerID"])).CompanyName ?? string.Empty;

                }
                advanceBooking4View.DateIn = (DateTime)dataRow["Check-in Date"];
                advanceBooking4View.DateOut = (DateTime)dataRow["Check out date"];
                advanceBooking4View.DateBookRoom = (DateTime)dataRow["DateBookRoom"];
                advanceBooking4View.RoomType = dataRow["Room Type"].ToString();
                advanceBooking4View.AdvanceBookingId = (int)dataRow["Id"];
                aBookings.Add(advanceBooking4View);
            }
            advanceBookingsBindingSource.DataSource = aBookings;
            advanceBookingsBindingSource.ResetBindings(false);
            dataGridViewAdvanceBookings.Refresh();
        }


        #endregion

        private void dataGridViewRoom_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            List<RoomBooking4View>  list = roomBooking4ViewBindingSource.DataSource as List<RoomBooking4View>;
            if (dataGridViewRoom.Columns[e.ColumnIndex].Name == "roomDataGridViewTextBoxColumn")
            {
                e.Value = list[e.RowIndex].Room.Name;
            }
            else
            if(dataGridViewRoom.Columns[e.ColumnIndex].Name == "RoomType")
            {
                e.Value = list[e.RowIndex].RoomTypeName;
            }
            else
            if(dataGridViewRoom.Columns[e.ColumnIndex].Name == "RoomNumber")
            {
                e.Value = list[e.RowIndex].Room.Id;
            }
            foreach (DataGridViewRow Myrow in dataGridViewRoom.Rows)
            {
                Myrow.DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewRoom.Columns["colDelete"].Index && !dataGridViewRoom.Rows[e.RowIndex].IsNewRow)
            {
                DialogResult dr = MessageBox.Show("Do you really want to delete this booking?", "Stop", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;
                RoomBooking4View selectedRow = dataGridViewRoom.Rows[e.RowIndex].DataBoundItem as RoomBooking4View;
                AppLogger.Instance.LogInformation($"Delete of booking <{selectedRow.ReservationId}> was initiated by <{userName}>");

                if (selectedRow == null || selectedRow.ReservationId <= 0) return;
                BookRoomDAO.Instance.DeleteBookRoom(selectedRow.ReservationId);
                MessageBox.Show("Booking deleted");
                dataGridViewRoom.Rows.RemoveAt(e.RowIndex);
            }

        }

        private void dataGridViewAdvanceBookings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewAdvanceBookings.Columns["colDeleteAB"].Index && !dataGridViewAdvanceBookings.Rows[e.RowIndex].IsNewRow)
            {
                DialogResult dr = MessageBox.Show("Do you really want to delete this advance booking?", "Stop", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;
                AdvanceBooking4View selectedRow = dataGridViewAdvanceBookings.Rows[e.RowIndex].DataBoundItem as AdvanceBooking4View;
                AppLogger.Instance.LogInformation($"Delete of Advance booking <{selectedRow.AdvanceBookingId}> was initiated by <{userName}>");

                if (selectedRow == null || selectedRow.AdvanceBookingId <= 0) return;
                AdvanceBookingDAO.Instance.DeleteAdvanceBooking(selectedRow.AdvanceBookingId);
                MessageBox.Show("Advance Booking deleted");
                dataGridViewAdvanceBookings.Rows.RemoveAt(e.RowIndex);
            }

        }
    }
}
