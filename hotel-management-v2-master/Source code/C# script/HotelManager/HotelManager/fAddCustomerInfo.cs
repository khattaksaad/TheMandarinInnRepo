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
    public partial class fAddCustomerInfo : Form
    {
        private static List<int> listIdCustomer;

        public static List<int> ListIdCustomer { get => listIdCustomer; set => listIdCustomer = value; }

        public fAddCustomerInfo()
        {
            InitializeComponent();
            LoadCustomerType();
            ListIdCustomer = new List<int>();
            cbNationality.Items.AddRange(Utils.CountryHelper.GetCountriesList().ToArray());
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
        public void InsertCustomer(string idCard, string name, int idCustomerType, DateTime dateofBirth, string address, string phonenumber, string city, string email, string sex, string nationality)
        {
            CustomerDAO.Instance.InsertCustomer(idCard, name, idCustomerType, dateofBirth, address, phonenumber, city ,email, sex, nationality);
        }
        public void GetInfoByIdCard(string idCard)
        {
            Customer customer = CustomerDAO.Instance.GetInfoByIdCard(idCard);
            txbID.Text = customer.IdCard.ToString();
            txbFullName.Text = customer.Name;
            txbAddress.Text = customer.Address;
            dpkDateOfBirth.Value = customer.DateOfBirth;
            cbSex.Text = customer.Sex;
            txbPhoneNumber.Text = customer.PhoneNumber.ToString();
            cbNationality.Text = customer.Nationality;
            cbCustomerType.Text = CustomerTypeDAO.Instance.GetNameByIdCard(idCard);
        }
        public void ClearData()
        {
            txbIDCardSearch.Text = txbID.Text = txbFullName.Text = txbAddress.Text = txbPhoneNumber.Text = cbNationality.Text = String.Empty;
        }
        public void AddIdCustomer(int idCustomer)
        {
            if(ListIdCustomer.Count!=0)
            {
                bool check = false;
                foreach (int item in ListIdCustomer)
                {
                    if (item == idCustomer)
                    {
                        check = true;
                        break;
                    }
                }
                if(!check) ListIdCustomer.Add(idCustomer);
            }
            else
            ListIdCustomer.Add(idCustomer);
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if(txbFullName.Text!=string.Empty&&txbID.Text!=string.Empty&&txbAddress.Text!=string.Empty&&cbNationality.Text!=string.Empty&&txbPhoneNumber.Text!=string.Empty)
            {
                if (!IsIdCardExists(txbID.Text))
                {
                    int idCustomerType = (cbCustomerType.SelectedItem as CustomerType).Id;
                    InsertCustomer(txbID.Text, txbFullName.Text, idCustomerType, dpkDateOfBirth.Value, txbAddress.Text, txbPhoneNumber.Text, txbCity.Text, txbEmail.Text, cbSex.Text, cbNationality.Text);
                }
                MessageBox.Show("Successfully added customers.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AddIdCustomer(CustomerDAO.Instance.GetInfoByIdCard(txbID.Text).Id);
                ClearData();
            }
            else
                MessageBox.Show("Please fill out all details first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txbIDCardSearch.Text != String.Empty)
            {
                if (IsIdCardExists(txbIDCardSearch.Text))
                    GetInfoByIdCard(txbIDCardSearch.Text);
                else
                    MessageBox.Show("ID card/ID card does not exist.\nPlease re-enter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txbIDCardSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txbIDCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            ClearData();
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
    }
}
