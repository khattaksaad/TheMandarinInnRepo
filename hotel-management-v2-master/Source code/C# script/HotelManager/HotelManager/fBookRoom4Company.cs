using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fBookRoom4Company : Form
    {
        public class RoomBooking4Grid
        {
            string roomId;
            string roomTypeTitle;
            int roomTypeId;
            decimal price4Booking;
            string roomName;
            public string RoomId { get => roomId; set => roomId = value; }
            public string RoomType { get => roomTypeTitle; set => roomTypeTitle = value; }
            public decimal Price4Booking { get => price4Booking; set => price4Booking = value; }
            public string RoomName { get => roomName; set => roomName = value; }
            public int RoomTypeId { get => roomTypeId; set => roomTypeId = value; }
        }
        string userName;
        List<Room> availableRooms = new List<Room>();
        public fBookRoom4Company(string userName)
        {
            this.userName = userName;
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            LoadRoomType();
            LoadCustomerType();
            LoadDate();
            LoadDays();
            LoadListBookRoom();
        }
        public void LoadRoomType()
        {
            cbRoomType.DataSource = RoomTypeDAO.Instance.LoadListRoomType();
            cbRoomType.DisplayMember = "Name";
            cbRoomType.ValueMember = "Id";
        }
        public void LoadRoomTypeInfo(int id)
        {
            RoomType roomType = RoomTypeDAO.Instance.LoadRoomTypeInfo(id);
            //txbRoomID.Text = roomType.Id.ToString();
            //txbRoomTypeName.Text = roomType.Name;
            txbPrice.Text = roomType.Price.ToString();
            txbAmountPeople.Text = roomType.LimitPerson.ToString();
        }
        public void LoadEmptyRooms(int id)
        {
            availableRooms = RoomDAO.Instance.LoadEmptyRoomsInCategory(id);
            mcbRoomNumbers.Items.Clear();
            foreach (Room room in availableRooms)
            {
                mcbRoomNumbers.Items.Add(room.Name);
            }
        }
        public void LoadDate()
        {
            dpkDateCheckIn.Value = DateTime.Now;
            dpkDateCheckOut.Value = DateTime.Now.AddDays(1);
        }
        public void LoadDays()
        {
            txbDays.Text = (dpkDateCheckOut.Value.Date - dpkDateCheckIn.Value.Date).Days.ToString();
        }
        public void LoadCustomerType()
        {
        }
        public bool IsIdCardExists(string idCard)
        {
            return CustomerDAO.Instance.IsIdCardExists(idCard);
        }
        public void InsertCustomer(string idCard, string name, int idCustomerType, DateTime dateofBirth, string address, string phonenumber, string email, string city, string sex, string nationality)
        {
            CustomerDAO.Instance.InsertCustomer(idCard, name, idCustomerType, dateofBirth, address, phonenumber,email , city, sex, nationality);
        }
        public void GetInfoByIdCard(string idCard)
        {
            Customer customer = CustomerDAO.Instance.GetInfoByIdCard(idCard);
            txbIDCard.Text = customer.IdCard.ToString();
            txbFullName.Text = customer.Name;
            txbAddress.Text = customer.Address;
            txbPhoneNumber.Text = customer.PhoneNumber.ToString();
        }
        public void InsertBookRoom(int roomId, int idCustomer, int idRoomType, int bookingType, string roomName, DateTime datecheckin, DateTime datecheckout, DateTime datebookroom, int pricePerNight, string userId)
        {
            BookRoomDAO.Instance.InsertBookRoom(roomId, idCustomer, idRoomType, bookingType, roomName, datecheckin, datecheckout, datebookroom, pricePerNight, this.userName);
        }
        public int GetCurrentIDBookRoom(DateTime dateTime)
        {
            return BookRoomDAO.Instance.GetCurrentIDBookRoom(dateTime);
        }
        public void LoadListBookRoom()
        {
            //dataGridViewBookRoom.DataSource = BookRoomDAO.Instance.LoadListBookRoom(DateTime.Now.Date);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear room id 
            txbRoomID.Text = string.Empty;
            LoadRoomTypeInfo((cbRoomType.SelectedItem as RoomType).Id);
            //Load room numbers (only available rooms, of the selected type)
            LoadEmptyRooms((cbRoomType.SelectedItem as RoomType).Id);
        }

        private void dpkDateCheckOut_onValueChanged(object sender, EventArgs e)
        {
            if (dpkDateCheckOut.Value < DateTime.Now)
                LoadDate();
            if (dpkDateCheckOut.Value <= dpkDateCheckIn.Value)
                LoadDate();
            LoadDays();
        }

        private void dpkDateCheckIn_onValueChanged(object sender, EventArgs e)
        {
            if (dpkDateCheckIn.Value <= DateTime.Now)
                LoadDate();
            if (dpkDateCheckOut.Value <= dpkDateCheckIn.Value)
                LoadDate();
            LoadDays();
        }

        private void txbIDCardSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                btnSearch_Click(sender, null);
        }

        private void txbIDCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (txbIDCardSearch.Text != String.Empty)
            //{
            //    if (IsIdCardExists(txbIDCardSearch.Text))
            //        GetInfoByIdCard(txbIDCardSearch.Text);
            //    else
            //        MessageBox.Show("The CNIC number does not exist, please enter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void ClearRoomBookingInformation()
        {
            mcbRoomNumbers.Text = txbRoomID.Text = txbAmountPeople.Text = txbPrice.Text = string.Empty;
        }
        public void ClearData()
        {
            txbIDCard.Text = txbFullName.Text = txbAddress.Text = txbPhoneNumber.Text = cbRoomType.Text =  txbEmail.Text  = String.Empty;
            roomBooking4GridBindingSource.Clear();
            roomBooking4GridBindingSource.ResetBindings(false);
            dataGridView4Bookings.Refresh();
            LoadDate();
        }
        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to make a reservation?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txbIDCard.Text != String.Empty && txbFullName.Text != String.Empty && txbAddress.Text != String.Empty && txbPhoneNumber.Text != String.Empty )
                {
                    //if its a new company, save it first; else just used the loaded id
                    DataRow row = GetCompanyByName(txbFullName.Text.Trim());
                    int companyId = -1;
                    if (row == null)
                    {
                        companyId = CompanyDAO.Instance.InsertCompany(txbFullName.Text, txbPhoneNumber.Text, txbAddress.Text, txbEmail.Text, txBrepName.Text, txbIDCard.Text, txbRepPhoneNumber.Text);
                    }
                    else
                    {
                        companyId = Convert.ToInt32(row["id"]);
                    }
                    //now add all bookings
                    foreach (var item in roomBooking4GridBindingSource.List)
                    {
                        RoomBooking4Grid room = item as RoomBooking4Grid;
                        if (room == null || room.RoomId == null) continue;
                        InsertBookRoom(Convert.ToInt32(room.RoomId), companyId, room.RoomTypeId, bookingType:1, room.RoomName, dpkDateCheckIn.Value, dpkDateCheckOut.Value, DateTime.Now, (int)room.Price4Booking, this.userName);
                    }
                    MessageBox.Show("Booking Successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                    MessageBox.Show("Please enter complete information.", "Incomplete information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            //int idBookRoom = (int)dataGridViewBookRoom.SelectedRows[0].Cells[0].Value;
            //string idCard = dataGridViewBookRoom.SelectedRows[0].Cells[2].Value.ToString();
            //fBookRoomDetails f = new fBookRoomDetails(idBookRoom, idCard);
            //f.ShowDialog();
            //Show();
            //LoadListBookRoom();
        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void mcbRoomNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoomTypeInfo((cbRoomType.SelectedItem as RoomType).Id);
            //Load room numbers (only available rooms, of the selected type)
            //LoadEmptyRooms((cbRoomType.SelectedItem as RoomType).Id);
            txbRoomID.Text = availableRooms.FirstOrDefault(p => p.Name.Equals(mcbRoomNumbers.Text))?.Id.ToString() ?? string.Empty;        
        }

        private void cbNationality_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView4Bookings_DataMemberChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView4Bookings_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateSum();
        }
        private void UpdateSum()
        {
            decimal totalSum = 0;
            foreach (var item in roomBooking4GridBindingSource.List)
            {
                // Use reflection to get the value of the 'Price' property
                var priceProperty = item.GetType().GetProperty("Price4Booking");
                if (priceProperty != null)
                {
                    var priceValue = priceProperty.GetValue(item);
                    if (priceValue != null && priceValue is decimal price)
                    {
                        totalSum += price * Convert.ToInt32(txbDays.Text);
                    }
                }
            }
            textBoxTotal.Text = totalSum.ToString();

        }

        private void dataGridView4Bookings_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateSum();
        }

        private void txbDays_OnValueChanged(object sender, EventArgs e)
        {
            UpdateSum();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private DataRow GetCompanyByName(string name)
        {
            return CompanyDAO.Instance.Search(name);            
        }
        private void LoadFullCompany(DataRow company)
        {
            if (company == null) { return; }
            txbFullName.Text = company["name"].ToString();
            txbEmail.Text = company["email"].ToString();
            txbAddress.Text = company["address"].ToString();
            txbPhoneNumber.Text = company["phone"].ToString();

            txbIDCard.Text = company["repId"].ToString();
            txBrepName.Text = company["repName"].ToString();

        }
        private void btnSearchCompany_Click(object sender, EventArgs e)
        {
            LoadFullCompany(GetCompanyByName(txbCompanyName4Searching.Text));
        }

        private void txbRepPhoneNumber_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txBrepName_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txbAddress_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAddAnotherRoom_Click(object sender, EventArgs e)
        {
            //ClearData();
            RoomBooking4Grid room = new RoomBooking4Grid()
            {
                RoomName = mcbRoomNumbers.Text,
                RoomId = txbRoomID.Text,
                RoomType = cbRoomType.Text,
                RoomTypeId = (int)cbRoomType.SelectedValue,
                Price4Booking = Convert.ToDecimal(txbPrice.Text)
            };
            roomBooking4GridBindingSource.Add(room);
            roomBooking4GridBindingSource.ResetBindings(false);
            dataGridView4Bookings.Refresh();
            ClearRoomBookingInformation();
        }

        private void btnAddGuests2Company_Click(object sender, EventArgs e)
        {
            DataRow row = GetCompanyByName(txbFullName.Text.Trim());
            fAddGuests4Company fAddGuests4Company = new fAddGuests4Company((int)row["id"]);
            fAddGuests4Company.ShowDialog();
        }
    }
}