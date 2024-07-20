using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fBookRoomDetails : Form
    {
        int idBookRoom;
        string idCard;
        public fBookRoomDetails(int _idBookRoom,string _idCard)
        {
            idBookRoom = _idBookRoom;
            idCard = _idCard;
            InitializeComponent();
            LoadRoomType();
            LoadCustomerType();
            LoadData();
            LoadDays();
            txbIDBookRoom.Text = _idBookRoom.ToString();
            cbNationality.Items.AddRange(Utils.CountryHelper.GetCountriesList().ToArray());
        }
        public void LoadRoomType()
        {
            cbRoomType.DataSource = RoomTypeDAO.Instance.LoadListRoomType();
            cbRoomType.DisplayMember = "Name";
        }
        public void LoadData()
        {
            //DataRow data = BookRoomDAO.Instance.ShowBookRoomInfo(idBookRoom);
            //dpkDateCheckIn.Value = (DateTime)data["DateCheckIn"];
            //dpkDateCheckOut.Value = (DateTime)data["DateCheckOut"];

            //cbRoomType.Text = RoomTypeDAO.Instance.GetRoomTypeByIdBookRoom(idBookRoom).Name;

            //GetInfoByIdCard(idCard);
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
        public void LoadCustomerType()
        {
            cbCustomerType.DataSource = CustomerTypeDAO.Instance.LoadListCustomerType();
            cbCustomerType.DisplayMember = "Name";
        }
        public bool IsIdCardExists(string idCard)
        {
            return CustomerDAO.Instance.IsIdCardExists(idCard);
        }
        public void LoadDays()
        {
            txbDays.Text = (dpkDateCheckOut.Value.Date - dpkDateCheckIn.Value.Date).Days.ToString();
        }
        public void UpdateCustomer()
        {
            int idCustomerType = (cbCustomerType.SelectedItem as CustomerType).Id;
            //CustomerDAO.Instance.UpdateCustomer(CustomerDAO.Instance.GetInfoByIdCard(idCard).Id, txbFullName.Text, txbIDCard.Text, idCustomerType, txbPhoneNumber.Text, , dpkDateOfBirth.Value, txbAddress.Text, cbSex.Text, cbNationality.Text);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dpkDateCheckIn_onValueChanged(object sender, EventArgs e)
        {
            if (dpkDateCheckIn.Value <= DateTime.Now)
                LoadData();
            if (dpkDateCheckOut.Value <= dpkDateCheckIn.Value)
                LoadData();
            LoadDays();
        }

        private void dpkDateCheckOut_onValueChanged(object sender, EventArgs e)
        {
            if (dpkDateCheckOut.Value < DateTime.Now)
                LoadData();
            if (dpkDateCheckOut.Value <= dpkDateCheckIn.Value)
                LoadData();
            LoadDays();
        }
        public void ClearData()
        {
            txbIDCard.Text = txbFullName.Text = txbAddress.Text = txbPhoneNumber.Text = cbNationality.Text = String.Empty;
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (txbFullName.Text != string.Empty && txbIDCard.Text != string.Empty && txbAddress.Text != string.Empty && cbNationality.Text != string.Empty && txbPhoneNumber.Text != string.Empty)
            {
                //Kiểm tra IDCard có trùng không
                if (!IsIdCardExists(txbIDCard.Text) || txbIDCard.Text == idCard)
                {
                    UpdateCustomer();

                }
                else
                    MessageBox.Show("CNIC card/ID card is invalid.\nPlease re-enter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Please enter complete information.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
            }
            MessageBox.Show("Successfully updated customer information!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            
        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            BookRoomDAO.Instance.UpdateBookRoom(idBookRoom, (cbRoomType.SelectedItem as RoomType).Id, dpkDateCheckIn.Value, dpkDateCheckOut.Value);
            MessageBox.Show("Successfully updated booking information!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deleting a customer will result in the booking being also deleted!\nDo you want to continue?", "Question",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                if (BookRoomDAO.Instance.IsIDBookRoomExists(idBookRoom))
                {
                    BookRoomDAO.Instance.DeleteBookRoom(idBookRoom);
                    MessageBox.Show("Successfully deleted customer information!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Unknown issue occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
