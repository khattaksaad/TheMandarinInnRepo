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
    public partial class fAddServiceType : Form
    {
        public fAddServiceType()
        {
            InitializeComponent();
        }
        private ServiceType GetServiceTypeNow()
        {
            ServiceType serviceType = new ServiceType();
            serviceType.Name = txbName.Text.Trim();
            return serviceType;
        }
        private void InsertServiceType()
        {
            if (fCustomer.CheckFillInText(new Control[] { txbName }))
            {
                try
                {
                    ServiceType serviceTypeNow = GetServiceTypeNow();
                    if (ServiceTypeDAO.Instance.InsertServiceType(serviceTypeNow))
                    {
                        MessageBox.Show("Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txbName.Text = string.Empty;
                    }
                    else
                        MessageBox.Show("Error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Exception occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Enter all details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to add new service type?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                InsertServiceType();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
