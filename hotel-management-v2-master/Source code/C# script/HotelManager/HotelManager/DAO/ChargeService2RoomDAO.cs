using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    class ChargeService2RoomDAO
    {
        #region Properties
        private static ChargeService2RoomDAO instance = new ChargeService2RoomDAO();
        internal static ChargeService2RoomDAO Instance { get => instance; }
        private ChargeService2RoomDAO() { }
        #endregion

        public DataTable GetAllServiceChargesForARoom(int reservationId)
        {
            string query = "[USP_GetCharges2Room] @@idBookRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { reservationId });
        }


        internal void Insert(int reservationId, int serviceId, string staff, int totalPrice, int quantity)
        {
            string query = "USP_InsertServiceCharge2Room @idBookRoom , @serviceId , @staff , @totalPrice , @quantity";
            DataProvider.Instance.ExecuteNoneQuery(query, new object[] { reservationId, serviceId, staff, totalPrice, quantity });
        }

        internal void Delete(int reservationId, int serviceId)
        {
            if (reservationId == -1 || serviceId == -1) return;
            string query = "USP_DeleteServiceCharge2Room @idBookRoom , @serviceId";
            DataProvider.Instance.ExecuteNoneQuery(query, new object[] { reservationId, serviceId });
        }

    }
}
