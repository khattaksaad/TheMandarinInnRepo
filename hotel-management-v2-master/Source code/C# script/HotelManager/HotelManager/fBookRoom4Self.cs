using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fBookRoom4Self : Form
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
        public fBookRoom4Self(string userName)
        {
            this.userName = userName;
            InitializeComponent();
            LoadData();
            cbNationality.Items.AddRange(Utils.CountryHelper.GetCountriesList().ToArray());
            labelCustomerId.Text = "CNIC/Id Number:";
            labelVisaNumber.Visible = false;
            txbVisaNumber.Visible = false;

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
            dpkDateOfBirth.Value = new DateTime(1998, 4, 6);
            dpkDateCheckIn.Value = DateTime.Now;
            dpkDateCheckOut.Value = DateTime.Now.AddDays(1);
        }
        public void LoadDays()
        {
            txbDays.Text = (dpkDateCheckOut.Value.Date - dpkDateCheckIn.Value.Date).Days.ToString();
        }
        public void LoadCustomerType()
        {
            cbCustomerType.DataSource = CustomerTypeDAO.Instance.LoadListCustomerType();
            cbCustomerType.DisplayMember = "Name";
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
            dpkDateOfBirth.Value = customer.DateOfBirth;
            cbSex.Text = customer.Sex;
            txbPhoneNumber.Text = customer.PhoneNumber.ToString();
            cbNationality.Text = customer.Nationality;
            cbCustomerType.Text = CustomerTypeDAO.Instance.GetNameByIdCard(idCard);
        }
        public void InsertBookRoom(int roomId, int idCustomer, int idRoomType, int bookingType, string roomName, DateTime datecheckin, DateTime datecheckout, DateTime datebookroom, string userId)
        {
            BookRoomDAO.Instance.InsertBookRoom(roomId, idCustomer, idRoomType, bookingType, roomName, datecheckin, datecheckout, datebookroom, this.userName);
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
            txbIDCard.Text = txbFullName.Text = txbAddress.Text = txbPhoneNumber.Text = cbRoomType.Text = cbSex.Text = txbCity.Text = txbEmail.Text = txbVisaNumber.Text = cbNationality.Text = String.Empty;
            roomBooking4GridBindingSource.Clear();
            roomBooking4GridBindingSource.ResetBindings(false);
            dataGridView4Bookings.Refresh();
            LoadDate();
        }
        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to make a reservation?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txbIDCard.Text != String.Empty && txbFullName.Text != String.Empty && txbAddress.Text != String.Empty && txbPhoneNumber.Text != String.Empty && cbNationality.Text != String.Empty)
                {
                    if (!IsIdCardExists(txbIDCard.Text))
                    {
                        int idCustomerType = (cbCustomerType.SelectedItem as CustomerType).Id;
                        InsertCustomer(txbIDCard.Text, txbFullName.Text, idCustomerType, dpkDateOfBirth.Value, txbAddress.Text, txbPhoneNumber.Text, txbCity.Text, txbEmail.Text, cbSex.Text, cbNationality.Text);
                    }
                    //now add all bookings

                    foreach (var item in roomBooking4GridBindingSource.List)
                    {
                        RoomBooking4Grid room = item as RoomBooking4Grid;
                        InsertBookRoom(Convert.ToInt32(room.RoomId), CustomerDAO.Instance.GetInfoByIdCard(txbIDCard.Text).Id, room.RoomTypeId, bookingType:0, room.RoomName, dpkDateCheckIn.Value, dpkDateCheckOut.Value, DateTime.Now, this.userName);
                    }
                    MessageBox.Show("Booking successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    //LoadListBookRoom();
                    //if (bunifuCheckbox1.Checked)
                    //{
                    //    this.Hide();
                    //    fReceiveRoom fReceiveRoom = new fReceiveRoom(GetCurrentIDBookRoom(DateTime.Now.Date));
                    //    fReceiveRoom.ShowDialog();
                    //}
                }
                else
                    MessageBox.Show("Please enter complete information.", "Incomplete information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
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
            if (cbNationality.Text != string.Empty &&
                cbNationality.Text != "Pakistan")
            {
                labelCustomerId.Text = "Passport Number:";
                labelVisaNumber.Visible = true;
                txbVisaNumber.Visible = true;
            }
            else
            {
                labelCustomerId.Text = "CNIC/ID Number:";
                labelVisaNumber.Visible = false;
                txbVisaNumber.Visible = false;
            }
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

        private void bunifuThinButtonCompanyBooking_Click(object sender, EventArgs e)
        {
            this.Hide();
            fBookRoom4Company fBookRoomDetails = new fBookRoom4Company(this.userName);
            fBookRoomDetails.ShowDialog();
            this.Close();
        }
    }
}