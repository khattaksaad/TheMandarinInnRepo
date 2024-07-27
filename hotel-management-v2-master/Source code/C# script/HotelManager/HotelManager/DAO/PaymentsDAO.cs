using HotelManager.DTO;
using System;
using System.Data;

namespace HotelManager.DAO
{
    public class PaymentsDAO
    {
        #region Properties && constructor
        private PaymentsDAO() { }

        private static PaymentsDAO instance;
        internal static PaymentsDAO Instance { get { if (instance == null) instance = new PaymentsDAO(); return instance; } }
        #endregion

        #region Method        
        internal DataTable GetAllPayments()
        {
            string query = "GetAllPayments";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        #endregion

    }
}
