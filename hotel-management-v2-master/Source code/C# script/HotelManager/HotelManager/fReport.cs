using HotelManager.DAO;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace HotelManager
{
    public partial class fReport : Form
    {
        private class Payment
        {
            int billId;
            string paymentMode;
            DateTime paymentDate;
            int amountPaid;

            public int BillId { get => billId; set => billId = value; }
            public string PaymentMode { get => paymentMode; set => paymentMode = value; }
            public DateTime PaymentDate { get => paymentDate; set => paymentDate = value; }
            public int AmountPaid { get => amountPaid; set => amountPaid = value; }
            public Payment(DataRow dataRow)
            {
                billId = Convert.ToInt32(dataRow["billId"]);
                paymentMode = dataRow["paymentMode"].ToString();
                paymentDate = Convert.ToDateTime(dataRow["paymentDate"]);
                amountPaid = Convert.ToInt32(dataRow["amountPaid"]);

            }
        }
        private int month = 1;
        private int year = 1990;
        DataTable data;
        public fReport()
        {
            InitializeComponent();
            data = PaymentsDAO.Instance.GetAllPayments();
        }

        #region Load
        private void LoadFullReport(int month, int year)
        {
            this.month = month;
            this.year = year;
            DataTable table = GetFulReport(month, year);
            BindingSource source = new BindingSource();
            ChangePrice(table);
            source.DataSource = table;
            dataGridReport.DataSource = source;
            bindingReport.BindingSource = source;
            DrawChart(source);
            GC.Collect();
        }
        #endregion

        #region Click
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //LoadFullReport(int.Parse(comboBoxMonth.Text), (int)(numericYear.Value));
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            saveReport.FileName = "Monthly Revenue " + month + '-' + year;
            if (saveReport.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                bool check;
                try
                {
                    switch (saveReport.FilterIndex)
                    {
                        case 2:
                            check = ExportToExcel.Instance.Export(dataGridReport, saveReport.FileName, ModeExportToExcel.XLSX);
                            break;
                        case 3:
                            check = ExportToExcel.Instance.Export(dataGridReport, saveReport.FileName, ModeExportToExcel.PDF);
                            break;
                        default:
                            check = ExportToExcel.Instance.Export(dataGridReport, saveReport.FileName, ModeExportToExcel.XLS);
                            break;
                    }
                    if (check)
                        MessageBox.Show("Exported successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Export failed error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show( "Please make sure MS Office is installed", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Data
        private DataTable GetFulReport(int month, int year)
        {
            return ReportDAO.Instance.LoadFullReport(month, year);
        }

        #endregion

        #region Chart
        private void DrawChart(BindingSource source)
        {   
            //chartReport.DataSource = source;
            //chartReport.DataBind();
            //foreach (DataPoint item in chartReport.Series[0].Points)
            //{
            //    if(item.YValues[0] == 0)
            //    {
            //        item.Label = " ";
            //    }
            //}
        }
        #endregion

        #region Change Price
        private void ChangePrice(DataTable table)
        {
            table.Columns.Add("value_New", typeof(string));
            table.Columns.Add("rate_New", typeof(string));
            int sum = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int node = ((int)table.Rows[i]["value"]);
                table.Rows[i]["value_New"] = node.ToString();
                table.Rows[i]["rate_New"] = (((double)table.Rows[i]["rate"]) / 100).ToString("#0.##%");
                sum += node;
            }
            table.Columns.Remove("value");
            DataRow row = table.NewRow();
            table.Columns["value_new"].ColumnName = "value";
            row["value"] = sum.ToString();
            table.Rows.Add(row);
        }

        #endregion

        #region Form
        private void FReport_Load(object sender, EventArgs e)
        {
            //LoadFullReport(DateTime.Now.Month, DateTime.Now.Year);
           // comboBoxMonth.Text = DateTime.Now.Month.ToString();
            //numericYear.Value = DateTime.Now.Year;
        }
        #endregion

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            BindingSource source = new BindingSource();
            DateTime from = dateTimePickerFrom.Value;
            DateTime till = dateTimePickerTill.Value;
            string filterExpression = $"PaymentDate >= #{from:yyyy-MM-dd}# AND PaymentDate <= #{till:yyyy-MM-dd}#";
            DataRow[] filteredRows = data.Select(filterExpression);

            // Create a new DataTable to store the filtered rows
            DataTable filteredTable = data.Clone(); // Clone the structure of the original table

            // Import the filtered rows into the new DataTable
            foreach (DataRow row in filteredRows)
            {
                filteredTable.ImportRow(row);
            }
            source.DataSource = filteredTable;
            dataGridReport.DataSource = source;
            dataGridReport.Refresh();

        }
    }
}
