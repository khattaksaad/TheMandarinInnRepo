using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace HotelManager
{
    public partial class fCustomer : Form
    {

        #region Constructor
        internal fCustomer()
        {
            InitializeComponent();
            cbCustomerSearch.SelectedIndex = 3;
            txbNationality.Items.AddRange(Utils.CountryHelper.GetCountriesList().ToArray());
            LoadFullCustomerType();
            LoadFullCustomer(GetFullCustomer());
            comboBoxSex.SelectedIndex = 0;
            SaveCustomer.OverwritePrompt = true;
            FormClosing += FCustomer_FormClosing;
            txbSearch.KeyPress += TxbSearch_KeyPress;
            dataGridViewCustomer.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }

        #endregion

        #region Load
        private void LoadFullCustomer(DataTable table)
        {
            bindingSourceCust.DataSource = table;
            bindingSourceCust.ResetBindings(false);
            dataGridViewCustomer.DataSource = bindingSourceCust;
            dataGridViewCustomer.Refresh();
        }
        private void LoadFullCustomerType()
        {
            DataTable table = GetFullCustomerType();
            comboBoxCustomerType.DataSource = table;
            comboBoxCustomerType.DisplayMember = "Name";
            if(table.Rows.Count > 0)
                comboBoxCustomerType.SelectedIndex = 0;
        }
        #endregion

        #region Click

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            bool check;
            if (SaveCustomer.ShowDialog() == DialogResult.Cancel)
                return;
            switch (SaveCustomer.FilterIndex)
            {
                case 2:
                    check = ExportToExcel.Instance.Export(dataGridViewCustomer, SaveCustomer.FileName, ModeExportToExcel.XLSX);
                    break;
                case 3:
                    check = ExportToExcel.Instance.Export(dataGridViewCustomer, SaveCustomer.FileName, ModeExportToExcel.PDF);
                    break;
                default:
                    check = ExportToExcel.Instance.Export(dataGridViewCustomer, SaveCustomer.FileName, ModeExportToExcel.XLS);
                    break;
            }
            if (check)
                MessageBox.Show("Export file successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Please make sure MS Office is installed on the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            new fAddCustomer().ShowDialog();
            if (btnCancel.Visible == false)
                LoadFullCustomer(GetFullCustomer());
            else
                BtnCancel_Click(null, null);
        }
        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txbFullName.Text = string.Empty;
            txbAddress.Text = string.Empty;
            txbIDCard.Text = string.Empty;
            txbNationality.Text = string.Empty;
            txbPhoneNumber.Text = string.Empty;
        }
        private void BtnClose1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result =MessageBox.Show( "Do you want to update information?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)

                    UpdateCustomer();

        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbAddress.Text = string.Empty;
                txbFullName.Text = string.Empty;
                txbIDCard.Text = string.Empty;
                txbPhoneNumber.Text = string.Empty;
                txbNationality.Text = string.Empty;

                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            LoadFullCustomer(GetFullCustomer());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }
        #endregion

        #region Method
        public static bool CheckFillInText(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == string.Empty)
                    return false;
            }
            return true;
        }
        private void InsertCustomer()
        {
            if (!CheckFillInText(new Control[] { txbPhoneNumber, txbFullName, txbIDCard, txbNationality, txbAddress, comboBoxCustomerType}))
            {
                MessageBox.Show( "Please fill in all details first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Customer customer = GetCustomerNow();
                if (CustomerDAO.Instance.InsertCustomer(customer))
                {
                    MessageBox.Show( "Added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (btnCancel.Visible == false)
                        LoadFullCustomer(GetFullCustomer());
                    else
                        BtnCancel_Click(null, null);
                }
                else
                    MessageBox.Show( "Cannot add right now, please try later", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch
            {
                MessageBox.Show( "Stop, unknown error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateCustomer()
        {
            //if(comboboxID.Text == string.Empty)
            //{
            //    MessageBox.Show( "Please provide all details first", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
            //else
            if (!CheckFillInText(new Control[] { txbPhoneNumber, txbFullName, txbIDCard, txbNationality, txbAddress, comboBoxCustomerType }))
            {
                MessageBox.Show("Please provide all details first", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Customer customerPre = groupCustomer.Tag as Customer;
                try
                {
                    Customer customerNow = GetCustomerNow();
                    if (customerNow.Equals(customerPre))
                        MessageBox.Show( "Similar customer already exists", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool check = CustomerDAO.Instance.UpdateCustomer(customerNow, customerPre);
                        if (check)
                        {
                            MessageBox.Show( "Customer updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupCustomer.Tag = customerNow;
                            int index = dataGridViewCustomer.SelectedRows[0].Index;
                            LoadFullCustomer(GetFullCustomer());
                        }
                        else
                            MessageBox.Show( "Something happened in the background, please try later", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    MessageBox.Show("Something happened in the background, please try later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txbFullName.Text = string.Empty;
                txbAddress.Text = string.Empty;
                txbIDCard.Text = string.Empty;
                txbNationality.Text = string.Empty;
                txbPhoneNumber.Text = string.Empty;
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
            }
            else
            {
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
                txbFullName.Text = row.Cells[colName.Name].Value.ToString();
                txbAddress.Text = row.Cells[colAddress.Name].Value.ToString();
                txbIDCard.Text = row.Cells[colCNIC.Name].Value.ToString();
                txbNationality.Text = row.Cells[colNationality.Name].Value.ToString();
                txbPhoneNumber.Text = row.Cells[colPhone.Name].Value.ToString();
                comboBoxCustomerType.SelectedIndex =(int) row.Cells[colIdCustomerType.Name].Value - 1;
                comboBoxSex.SelectedItem = row.Cells[colGender.Name].Value;
                Customer customer = new Customer(((DataRowView) row.DataBoundItem).Row);
                groupCustomer.Tag = customer;              
            }
        }
        private void Search()
        {
            string @string = txbSearch.Text;
            int mode = cbCustomerSearch.SelectedIndex;
            LoadFullCustomer(GetSearchCustomer(@string, mode));
        }

        #endregion

        #region GetData
        private Customer GetCustomerNow()
        {
            fStaff.Trim(new Bunifu.Framework.UI.BunifuMetroTextbox[] { txbAddress, txbFullName, txbIDCard });
            Customer customer = new Customer();
            customer.IdCard = txbIDCard.Text;
            int id = comboBoxCustomerType.SelectedIndex;
            customer.IdCustomerType = (int)((DataTable) comboBoxCustomerType.DataSource).Rows[id]["id"];
            customer.Name = txbFullName.Text;
            customer.Sex = comboBoxSex.Text;
            customer.PhoneNumber = txbPhoneNumber.Text;
            customer.Nationality = txbNationality.Text;
            customer.Address = txbAddress.Text;
            return customer;
        }
        private DataTable GetFullCustomer()
        {
            return CustomerDAO.Instance.LoadFullCustomer();
        }
        private DataTable GetFullCustomerType()
        {
            return CustomerTypeDAO.Instance.LoadFullCustomerType();
        }
        /// <summary>
        /// --Mode is
        //--- 0 --- find along id
        //--- 1 --- find along name
        //--- 2 --- find along idCard
        //--- 3 --- find along NumberPhone
        /// </summary>
        /// <param name="string"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        private DataTable GetSearchCustomer(string @string, int mode)
        {
            return CustomerDAO.Instance.Search(@string, mode);
        }

        #endregion

        #region Seclection Change
        private void DataGridViewCustomer_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCustomer.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewCustomer.SelectedRows[0];
                ChangeText(row);
            }
        }
        #endregion

        #region Check isDigit

        private void TxbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
                e.Handled = true;
        }

        #endregion

        #region Enter
        private void Txb_Enter(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuMetroTextbox text = sender as Bunifu.Framework.UI.BunifuMetroTextbox;
            text.Tag = text.Text;
        }
        #endregion

        #region Leave
        private void Txb_Leave(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuMetroTextbox text = sender as Bunifu.Framework.UI.BunifuMetroTextbox;
            if (text.Text == string.Empty)
                text.Text = text.Tag as string;
        }
        #endregion

        #region Key
        private void TxbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                BtnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        private void FCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        #endregion

        #region Close
        private void FCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadFullCustomer(GetFullCustomer());
        }
        #endregion
    }
}
