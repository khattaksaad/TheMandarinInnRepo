using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HotelManager.Utils
{
    internal static class StaticValues
    {
        public static string GetPath4User(string userName)
        {
            Account staff = AccountDAO.Instance.LoadStaffInforByUserName(userName);
            return staff.Path;
        }
    }
}
