using HotelManager.DAO;
using HotelManager.DTO;
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
    public partial class fMethodOfPayment : Form
    {

        public fMethodOfPayment(int amountDue, string customerName, string bookingId)
        {

            InitializeComponent();
            LoadFullRoomType();
            txbBookingID.Text = bookingId.ToString();
            txbCustomerName.Text = customerName;
            txbTotalDueAmount.Text = amountDue.ToString();
        }

        private void LoadFullRoomType()
        {
            //DataTable table = GetFullRoomType();
            //ChangePrice(table);
            //comboBoxRoomType.DataSource = table;
            //comboBoxRoomType.DisplayMember = "Name";
            //if (table.Rows.Count > 0)
            //    comboBoxRoomType.SelectedIndex = 0;
            //txbPrice.DataBindings.Add("Text", comboBoxRoomType.DataSource, "price_New");
            //txbLimitPerson.DataBindings.Add(new Binding("Text", comboBoxRoomType.DataSource, "limitPerson"));
        }
        private DataTable GetFullRoomType()
        {
            return RoomTypeDAO.Instance.LoadFullRoomType();
        }
        //private Room GetRoomNow()
        //{
        //    //Room room = new Room();
        //    //fStaff.Trim(new Bunifu.Framework.UI.BunifuMetroTextbox[] { txbNameRoom });
        //    //room.Name = txbNameRoom.Text;
        //    //int index = comboBoxRoomType.SelectedIndex;
        //    //room.IdStatusRoom = 1;
        //    //room.IdRoomType = (int)((DataTable)comboBoxRoomType.DataSource).Rows[index]["id"];
        //    //return room;
        //}
        private void InsertRoom()
        {
            //if (!fCustomer.CheckFillInText(new Control[] { txbNameRoom, comboBoxRoomType }))
            //{
            //    MessageBox.Show("Cannot be left blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //try
            //{
            //    Room roomNow = GetRoomNow();
            //    if (RoomDAO.Instance.InsertRoom(roomNow))
            //    {
            //        txbNameRoom.Text = string.Empty;
            //        MessageBox.Show("Saved Successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //        MessageBox.Show("This room already exists (Duplicate room code)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
            //catch
            //{
            //    MessageBox.Show("Error occurred while trying to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void btnAddBill_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmountPaid.Text.Trim()) || string.IsNullOrEmpty(cbModeOfPayment.Text.Trim())) return;
            DialogResult result = MessageBox.Show("Do you want to mark the payment?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                int paymentDue = Convert.ToInt32(txbTotalDueAmount.Text);
                int paymentPaid = Convert.ToInt32(txtAmountPaid.Text);
                //its a partial payment // statusBill:id = 3
                int[] bookingIds = txbBookingID.Text.Trim().Split(',')
                            .Select(int.Parse)
                            .ToArray();

                if (paymentDue > paymentPaid)
                {
                    foreach(int bookingId in bookingIds)
                    {

                        BillDAO.Instance.UpdateBillAsPayment(bookingId, paymentPaid,statusBill:3);
                        BillDAO.Instance.InsertPayment(bookingId, paymentPaid, cbModeOfPayment.Text);
                    }
                }
                else
                {
                    //paid full// statusBill:id = 2
                    foreach (int bookingId in bookingIds)
                    {

                        BillDAO.Instance.UpdateBillAsPayment(bookingId, paymentPaid, statusBill: 2);
                        BillDAO.Instance.InsertPayment(bookingId, paymentPaid, cbModeOfPayment.Text);
                    }

                }
                MessageBox.Show("Payment marked successfully..!");
            }
        }
        private void ChangePrice(DataTable table)
        {
            table.Columns.Add("price_New", typeof(string));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["price_New"] = ((int)table.Rows[i]["price"]).ToString();
            }
            table.Columns.Remove("price");
        }
        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    e.Handled = true;
        }
    }
}
