using HotelManager.DAO;
using HotelManager.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fBill : Form
    {
        #region Constructor & Properties
        private readonly fPrintBill fPrintBill = new fPrintBill();

        public fBill()
        {
            InitializeComponent();
            dataGridViewBill.Font = new Font("Segoe UI", 9.75F);
            LoadFullBill(GetFullBill());
            comboboxID.DisplayMember = "ID";
            cbBillSearch.SelectedIndex = 0;
        }

        #endregion

        #region Load
        private void LoadFullBill(DataTable table)
        {
            BindingSource source = new BindingSource();
            table.Columns.Add("customerName");
            source.DataSource = table;
            dataGridViewBill.DataSource = source;
            bindingBill.BindingSource = source;
            comboboxID.DataSource = source;
            dataGridViewBill.Columns["BookingType"].Visible = false;
            dataGridViewBill.Columns["CustomerName"].Visible = false;
            dataGridViewBill.Columns["customerID"].Visible = false;

            txbDateCreate.DataBindings.Clear();
            txbName.DataBindings.Clear();
            txbPrice.DataBindings.Clear();
            txbStatusRoom.DataBindings.Clear();
            txbUser.DataBindings.Clear();
            txbDiscount.DataBindings.Clear();
            txbFinalPrice.DataBindings.Clear();

            foreach (DataRow row in table.Rows) {

                row["customerName"] = Helper.GetCustomerName((int)row["CustomerID"], (int)row["BookingType"]);
            
            }

            txbDateCreate.DataBindings.Add("Text", source, "DateOfCreate");
            txbName.DataBindings.Add("Text", source, "roomName");
            txbPrice.DataBindings.Add("Text", source, "totalPrice");
            txbStatusRoom.DataBindings.Add("Text", source, "Name");
            txbUser.DataBindings.Add("Text", source, "StaffSetUp");
            txbDiscount.DataBindings.Add("Text", source, "AmountPaid");
        }

        #endregion

        #region Change Text
        private void BtnSeenBill_Click(object sender, EventArgs e)
        {
            //if (comboboxID.Text != string.Empty)
            //{
            //    if (!txbStatusRoom.Text.Contains("Ch"))
            //    {
            //        fPrintBill.SetPrintBill(int.Parse(comboboxID.Text), txbDateCreate.Text);
            //        fPrintBill.ShowDialog();
            //    }
            //    else
            //        MessageBox.Show("Unpaid invoice\nYou do not have access rights", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
        #endregion

        #region Click
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbDateCreate.Text = string.Empty;
                txbName.Text = string.Empty;
                txbPrice.Text = string.Empty;
                txbStatusRoom.Text = string.Empty;
                txbUser.Text = string.Empty;

                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            LoadFullBill(GetFullBill());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }
        #endregion

        #region Method

        private void Search()
        {
            //LoadFullBill(GetSearchBill(txbSearch.Text, cbBillSearch.SelectedIndex));
        }
        #endregion

        #region Get Data
        private DataTable GetFullBill()
        {
            return BillDAO.Instance.LoaddFullBill();
        }
        private DataTable GetSearchBill(string text, int mode)
        {
            return BillDAO.Instance.SearchBill(text, mode);
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
        private void FBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        #endregion

    }
}
