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
    public partial class fAddCustomer : Form
    {
        public fAddCustomer()
        {
            InitializeComponent();
            LoadFullCustomerType();
            cbNationality.Items.AddRange(Utils.CountryHelper.GetCountriesList().ToArray());
        }
        private void LoadFullCustomerType()
        {
            DataTable table = GetFullCustomerType();
            comboBoxCustomerType.DataSource = table;
            comboBoxCustomerType.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                comboBoxCustomerType.SelectedIndex = 0;
        }
        private DataTable GetFullCustomerType()
        {
            return CustomerTypeDAO.Instance.LoadFullCustomerType();
        }
        private void Clean()
        {
            txbFullName.Text = string.Empty;
            txbAddress.Text = string.Empty;
            txbID.Text = string.Empty;
            cbNationality.Text = string.Empty;
            txbPhoneNumber.Text = string.Empty;
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to add customer?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                if (CheckDate())
                {
                    InsertCustomer();
                }
                else
                    MessageBox.Show("Cannot add at the moment", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool CheckDate()
        {
            if (DateTime.Now.Subtract(datepickerDateOfBirth.Value).Days <= 0)
                return false;
            else return true;
        }
        private void InsertCustomer()
        {
            if (!CheckFillInText(new Control[] { txbPhoneNumber, txbFullName, txbID, cbNationality, txbAddress, comboBoxCustomerType }))
            {
                MessageBox.Show("Please provide all details first", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Customer customer = GetCustomerNow();
                if (CustomerDAO.Instance.InsertCustomer(customer))
                {
                    MessageBox.Show("Customer added successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();
                }
                else
                    MessageBox.Show("Unknown issue occurred", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch
            {
                MessageBox.Show("Unknown issue occurred", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static bool CheckFillInText(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == string.Empty)
                    return false;
            }
            return true;
        }
        private Customer GetCustomerNow()
        {
            fStaff.Trim(new Bunifu.Framework.UI.BunifuMetroTextbox[] { txbAddress, txbFullName, txbID });
            Customer customer = new Customer();
            customer.IdCard = txbID.Text;
            int id = comboBoxCustomerType.SelectedIndex;
            customer.IdCustomerType = (int)((DataTable)comboBoxCustomerType.DataSource).Rows[id]["id"];
            customer.Name = txbFullName.Text;
            customer.Sex = comboBoxSex.Text;
            customer.PhoneNumber = txbPhoneNumber.Text;
            customer.DateOfBirth = datepickerDateOfBirth.Value;
            customer.Nationality = cbNationality.Text;
            customer.Address = txbAddress.Text;
            return customer;
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }
        private void TxbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txbNationality_SelectedIndexChanged(object sender, EventArgs e)
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
