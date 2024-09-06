using HotelManager.DAO;
using HotelManager.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        public bool Login()
        {
            bool ret = false;
            try
            {
                ret = AccountDAO.Instance.Login(txbUserName.Text, txbPassWord.Text);
            }
            catch (Exception ex)
            {
                AppLogger.Instance.LogError($"The following error occurred while trying to Login, error <{ex.Message}>");
            }
            return ret; 
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

       
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (Login())
            {
                this.Hide();
                AppLogger.Instance.LogError($"Login Successful");

                fManagement f = new fManagement(txbUserName.Text);
                f.ShowDialog();

            }
            else
            {
                AppLogger.Instance.LogError($"Incorrect credentials given, cant give access");

                MessageBox.Show( "Incorrect credentials, cannot grant access!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txbPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnLogin_Click_1(sender, null);
        }
    }
}
