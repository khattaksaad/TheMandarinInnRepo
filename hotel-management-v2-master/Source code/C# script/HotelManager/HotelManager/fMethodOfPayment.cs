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
using static HotelManager.fPayment;

namespace HotelManager
{
    public partial class fMethodOfPayment : Form
    {
        List<Room4GUI> room4GUIs;
        string userName;
        public class Payment
        {
            int totalAmount;
            int dueAmount;
            int paidAmount;
            int discount;
            int surcharge;
            string customerName;
            string phoneNumber;
            string bookingId;

            public int TotalAmount { get => totalAmount; set => totalAmount = value; }
            public int DueAmount { get => dueAmount; set => dueAmount = value; }
            public int PaidAmount { get => paidAmount; set => paidAmount = value; }
            public int Discount { get => discount; set => discount = value; }
            public int Surcharge { get => surcharge; set => surcharge = value; }
            public string BookingId { get => bookingId; set => bookingId = value; }
            public string CustomerName { get => customerName; set => customerName = value; }
            public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        }
        private Payment payment;
        public fMethodOfPayment(Payment payment, List<Room4GUI> rooms4GUI, string username)
        {

            InitializeComponent();
            LoadFullRoomType();
            this.payment = payment;
            txbBookingID.Text = payment.BookingId.ToString();
            txbCustomerName.Text = payment.CustomerName.ToString();
            txbTotalDueAmount.Text =  ((payment.DueAmount + payment.Surcharge) - payment.Discount).ToString();
            tbExtra.Text = payment.Surcharge.ToString();
            tbDiscount.Text = payment.Discount.ToString();
            room4GUIs = rooms4GUI;
            userName = username;
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
                int paymentPaid = Convert.ToInt32(txtAmountPaid.Text);
                int discount = Convert.ToInt32(tbDiscount.Text);
                int surcharge = Convert.ToInt32(tbExtra.Text);
                int paymentDue = Convert.ToInt32(txbTotalDueAmount.Text);

                //its a partial payment // statusBill:id = 3
                int[] bookingIds = txbBookingID.Text.Trim().Split(',')
                            .Select(int.Parse)
                            .ToArray();

                if (paymentDue > paymentPaid)
                {
                    foreach(int bookingId in bookingIds)
                    {

                        BillDAO.Instance.UpdateBillAsPayment(bookingId, paymentPaid, discount, surcharge,statusBill:3);
                        BillDAO.Instance.InsertPayment(bookingId, paymentPaid, cbModeOfPayment.Text);
                    }
                }
                else
                {
                    //paid full// statusBill:id = 2
                    foreach (int bookingId in bookingIds)
                    {

                        BillDAO.Instance.UpdateBillAsPayment(bookingId, paymentPaid, discount, surcharge, statusBill: 2);
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

        private void txbBookingID_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txbCustomerName_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txbTotalDueAmount_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            fPrintBill fPrint = new fPrintBill(Convert.ToInt32(txbBookingID.Text.Trim()), payment.CustomerName, payment.PhoneNumber, room4GUIs, userName);
            this.Hide();
            fPrint.ShowDialog();
            this.Show();
        }
    }
}
