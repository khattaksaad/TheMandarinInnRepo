using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using static HotelManager.fUseService;

namespace HotelManager
{
    public partial class fService : Form

    { 
        public class Service4GUI
        {
            //Service.ID, Service.Name, Price, ServiceType.Name AS nameServiceType, IDServiceType
            int id;
            string name;
            int price;
            string serviceName;
            int idServiceType;

            public int IdServiceType { get => idServiceType; set => idServiceType = value; }
            public string NameServiceType { get => serviceName; set => serviceName = value; }
            public int Price { get => price; set => price = value; }
            public string Name { get => name; set => name = value; }
            public int Id { get => id; set => id = value; }
            public Service4GUI(DataRow dataRow)
            {
                this.id = (int)dataRow["Id"];
                this.name = (string)dataRow["Name"];
                this.price = (int)dataRow["Price"];
                this.serviceName = (string)dataRow["nameServiceType"];
                this.idServiceType = (int)dataRow["IDServiceType"];
            }
        }
        #region Properties
        fServiceType _fServiceType;
        #endregion

        #region Constructor
        public fService()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            LoadFullServiceType();
            LoadFullService(GetFullService());
            comboboxID.DisplayMember = "id";
            txbSearch.KeyPress += TxbSearch_KeyPress;
            btnCancel.Click += BtnCancel_Click;
            KeyPreview = true;
            KeyPress += FService_KeyPress;
            dataGridViewService.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }


        #endregion

        #region Load
        private void LoadFullService(DataTable table)
        {
            ChangePrice(table);
            List<Service4GUI> services = new List<Service4GUI>();
            foreach (DataRow dataRow in table.Rows)
            {
                services.Add(new Service4GUI(dataRow));
            }
            bindingSourceService.DataSource = services;
            bindingSourceService.ResetBindings(false);
            dataGridViewService.Refresh();
        }
        private void LoadFullServiceType()
        {
            DataTable table = GetFullServiceType();
            comboBoxServiceType.DataSource = table;
            comboBoxServiceType.DisplayMember = "name";
            ;
            if (table.Rows.Count > 0)
                comboBoxServiceType.SelectedIndex = 0;
            _fServiceType = new fServiceType(table);
        }
        #endregion

        #region Click
        private void BtnInsertService_Click(object sender, EventArgs e)
        {
            new fAddService().ShowDialog();
            if (btnCancel.Visible == false)
                LoadFullService(GetFullService());
            else
                BtnCancel_Click(null, null);
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to update the service again?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateService();
            comboboxID.Focus();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnServiceType_Click(object sender, EventArgs e)
        {
            this.Hide();
            _fServiceType.ShowDialog();
            this.LoadFullService(GetFullService());
            comboBoxServiceType.DataSource = _fServiceType.TableSerViceType;
            this.Show();
        }
        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txbName.Text = string.Empty;
            txbPrice.Text = string.Empty;
        }
        private void BtnCLose1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            if (saveService.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                bool check;
                try
                {
                    switch (saveService.FilterIndex)
                    {
                        case 2:
                            check = ExportToExcel.Instance.Export(dataGridViewService, saveService.FileName, ModeExportToExcel.XLSX);
                            break;
                        case 3:
                            check = ExportToExcel.Instance.Export(dataGridViewService, saveService.FileName, ModeExportToExcel.PDF);
                            break;
                        default:
                            check = ExportToExcel.Instance.Export(dataGridViewService, saveService.FileName, ModeExportToExcel.XLS);
                            break;
                    }
                    if (check)
                        MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Export Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Export error (Install office)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbName.Text = string.Empty;
                txbPrice.Text = string.Empty;
                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            LoadFullService(GetFullService());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }
        #endregion

        #region Method
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
                txbName.Text = string.Empty;
                txbPrice.Text = string.Empty;
            }
            else
            {
                txbName.Text = row.Cells["colName"].Value.ToString();
                comboBoxServiceType.SelectedIndex = (int)row.Cells["IdServiceType"].Value - 1;
                int price = (int)row.Cells["colPrice"].Value;
                txbPrice.Text = price.ToString();
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }

        private void UpdateService()
        {
            if (comboboxID.Text == string.Empty)
                MessageBox.Show("Service does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            if (!fCustomer.CheckFillInText(new Control[] { txbName, comboBoxServiceType, txbPrice }))
            {
                MessageBox.Show("Cannot be left blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    Service serviceNow = GetServiceNow();
                        bool check = ServiceDAO.Instance.UpdateService(serviceNow.Id, serviceNow.Name, serviceNow.IdServiceType,serviceNow.Price);
                        if (check)
                        {
                            MessageBox.Show("Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupService.Tag = serviceNow;
                            if (btnCancel.Visible == false)
                            {
                                int index = dataGridViewService.SelectedRows[0].Index;
                                LoadFullService(GetFullService());
                                comboboxID.SelectedIndex = index;
                            }
                            else
                                BtnCancel_Click(null, null);
                        }
                        else
                            MessageBox.Show("Service does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Search()
        {
            LoadFullService(GetSearchService());
        }
        #endregion

        #region Get Data
        private DataTable GetFullService()
        {
            return ServiceDAO.Instance.LoadFullService();
        }
        private DataTable GetFullServiceType()
        {
            return ServiceTypeDAO.Instance.LoadFullServiceType();
        }
        private Service GetServiceNow()
        {
            Service service = new Service();
            if (comboboxID.Text == string.Empty)
                service.Id = 0;
            else
                service.Id = int.Parse(comboboxID.Text);
            txbName.Text = txbName.Text.Trim();
            service.Name = txbName.Text;
            service.Price = int.Parse(StringToInt(txbPrice.Text));
            int index = comboBoxServiceType.SelectedIndex;
            service.IdServiceType = (int)((DataTable)comboBoxServiceType.DataSource).Rows[index]["id"];
            return service;
        }
        private DataTable GetSearchService()
        {
            if (int.TryParse(txbSearch.Text, out int id))
                return ServiceDAO.Instance.Search(txbSearch.Text, id);
            else
                return ServiceDAO.Instance.Search(txbSearch.Text, 0);
        }
        #endregion

        #region Change
        private void DataGridViewService_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewService.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewService.SelectedRows[0];
                ChangeText(row);
            }
        }
        private void ChangePrice(DataTable table)
        {
            //table.Columns.Add("price_New", typeof(string));
            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    table.Rows[i]["price_New"] = ((int)table.Rows[i]["price"]).ToString();
            //}
        }
        private string StringToInt(string text)
        {
            if (text.Contains(".") || text.Contains(" "))
            {
                string[] vs = text.Split(new char[] { '.', ' ' });
                StringBuilder textNow = new StringBuilder();
                for (int i = 0; i < vs.Length - 1; i++)
                {
                    textNow.Append(vs[i]);
                }
                return textNow.ToString();
            }
            else return text;
        }
        private string IntToString(string text)
        {
            if (text == string.Empty)
                return 0.ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            if (text.Contains(".") || text.Contains(" "))
                return text;
            else
                return (int.Parse(text).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN")));
        }
        #endregion

        #region Key
        private void TxbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void TxbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                BtnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        private void FService_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        #endregion

        #region Enter
        private void TxbPrice_Enter(object sender, EventArgs e)
        {
            txbPrice.Tag = txbPrice.Text;
            txbPrice.Text = StringToInt(txbPrice.Text);
        }
        private void TxbName_Enter(object sender, EventArgs e)
        {
            txbName.Tag = txbName.Text;
        }

        #endregion

        #region Leave
        private void TxbPrice_Leave(object sender, EventArgs e)
        {
            if (txbPrice.Text == string.Empty)
                txbPrice.Text = txbPrice.Tag as string;
            else
                txbPrice.Text = IntToString(txbPrice.Text);
        }
        private void TxbName_Leave(object sender, EventArgs e)
        {
            if (txbName.Text == string.Empty)
                txbName.Text = txbName.Tag as string;
        }
        #endregion

        #region Close
        private void FService_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnCancel_Click(sender, null);
        }
        #endregion

        private void dataGridViewService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewService.Columns["colDelete"].Index && !dataGridViewService.Rows[e.RowIndex].IsNewRow)
            {
                Service4GUI service4GUI = dataGridViewService.Rows[e.RowIndex].DataBoundItem as Service4GUI;

                if (service4GUI == null || service4GUI.Id <= 0) return;
                ServiceDAO.Instance.DeleteService(service4GUI.Id);
                dataGridViewService.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
