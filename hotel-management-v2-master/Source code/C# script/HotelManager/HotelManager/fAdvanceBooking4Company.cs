using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fAdvanceBooking4Company : Form
    {
        public class AdvanceRoomBooking4Grid
        {
            string roomTypeTitle;
            int roomTypeId;
            public string RoomType { get => roomTypeTitle; set => roomTypeTitle = value; }
            public int RoomTypeId { get => roomTypeId; set => roomTypeId = value; }
        }
        string userName;
        List<Room> availableRooms = new List<Room>();
        public fAdvanceBooking4Company(string userName)
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
        }
        public void LoadEmptyRooms(int id)
        {
            availableRooms = RoomDAO.Instance.LoadEmptyRoomsInCategory(id);
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
        public void InsertCompany(string name, string address, string companyEmail, string companyPhone, string repName, string repId, string repPhoneNumber)
        {
            CompanyDAO.Instance.InsertCompany(name, companyPhone, address, companyEmail, repName, repId, repPhoneNumber);
        }
        public void GetInfoByIdCard(string idCard)
        {
        }
        public void InsertAdvanceBooking(int idCustomer, int idRoomType, int bookingType, DateTime datecheckin, DateTime datecheckout, DateTime datebookroom, int priceChargedPerNight, string userId)
        {
            AdvanceBookingDAO.Instance.InsertAdvanceBooking(idCustomer, idRoomType, bookingType, datecheckin, datecheckout, datebookroom, priceChargedPerNight, this.userName);
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
            LoadRoomTypeInfo((cbRoomType.SelectedItem as RoomType).Id);
            //Load room numbers (only available rooms, of the selected type)
            LoadEmptyRooms((cbRoomType.SelectedItem as RoomType).Id);
        }

        private void dpkDateCheckOut_onValueChanged(object sender, EventArgs e)
        {
            //if (dpkDateCheckOut.Value < DateTime.Now)
            //    LoadDate();
            if (dpkDateCheckOut.Value <= dpkDateCheckIn.Value)
                LoadDate();
            LoadDays();
        }

        private void dpkDateCheckIn_onValueChanged(object sender, EventArgs e)
        {
            //if (dpkDateCheckIn.Value <= DateTime.Now)
            //    LoadDate();
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
           // mcbRoomNumbers.Text = txbRoomID.Text = txbAmountPeople.Text = txbPrice.Text = string.Empty;
        }
        public void ClearData()
        {
            txbFullName.Text = txbPhoneNumber.Text = cbRoomType.Text = txbAddress.Text = txbCompanyName4Searching.Text = txbDays.Text = txbEmail.Text = txbFullName.Text = txbIDCard.Text = txbPhoneNumber.Text = txBrepName.Text = txbRepPhoneNumber.Text = String.Empty;
            roomBooking4GridBindingSource.Clear();
            roomBooking4GridBindingSource.ResetBindings(false);
            dataGridView4Bookings.Refresh();
            LoadDate();
        }
        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to make an advance booking?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txbFullName.Text != String.Empty && txbPhoneNumber.Text != String.Empty && txBrepName.Text != string.Empty && txbRepPhoneNumber.Text != string.Empty)
                {
                    DataRow dataRow = CompanyDAO.Instance.Search(txbFullName.Text);
                    if (dataRow == null)
                    {
                        InsertCompany(txbFullName.Text.Trim(), txbAddress.Text.Trim(), txbEmail.Text.Trim(), txbPhoneNumber.Text.Trim(), txBrepName.Text.Trim(), txbIDCard.Text.Trim(), txbRepPhoneNumber.Text.Trim());
                    }
                    //now add all bookings

                    foreach (var item in roomBooking4GridBindingSource.List)
                    {
                        AdvanceRoomBooking4Grid room = item as AdvanceRoomBooking4Grid;
                        if(room == null ) continue;
                        InsertAdvanceBooking(CompanyDAO.Instance.GetInfoByFullName(txbFullName.Text.Trim()).Id, room.RoomTypeId, bookingType:1,dpkDateCheckIn.Value, dpkDateCheckOut.Value, DateTime.Now, 0 , this.userName);
                    }
                    MessageBox.Show("Advance Booking successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                    MessageBox.Show("Please enter complete information.", "Incomplete information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //ClearData();            
            AdvanceRoomBooking4Grid room = new AdvanceRoomBooking4Grid()
            {
                RoomType = cbRoomType.Text,
                RoomTypeId = (int)cbRoomType.SelectedValue,

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
            //textBoxTotal.Text = totalSum.ToString();

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

        private void dataGridView4Bookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView4Bookings.Columns["colDelete"].Index && !dataGridView4Bookings.Rows[e.RowIndex].IsNewRow)
            {
                dataGridView4Bookings.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnSearchCompany_Click(object sender, EventArgs e)
        {
            LoadFullCompany(GetCompanyByName(txbCompanyName4Searching.Text));

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

    }
}