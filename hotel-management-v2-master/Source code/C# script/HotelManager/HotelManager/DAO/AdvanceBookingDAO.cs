using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static log4net.Appender.RollingFileAppender;

namespace HotelManager.DAO
{
    public class AdvanceBookingDAO
    {
        private static AdvanceBookingDAO instance;
        private AdvanceBookingDAO() { }
        public bool InsertAdvanceBooking(int idCustomer, int idRoomType, int bookingType,DateTime datecheckin,DateTime datecheckout, DateTime datebookroom, int pricePerNight, string userName)
        {
            string query = "InsertAdvanceBooking @idCustomer , @idRoomType , @bookingType , @datecheckin , @datecheckout , @datebookroom , @pricePerNight , @userName";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idCustomer, idRoomType, bookingType, datecheckin, datecheckout, datebookroom, pricePerNight, userName }) > 0;
        }
        public DataTable LoadAdvanceBooking(DateTime dateTime)
        {
            string query = "USP_LoadBookRoomsByDate @date";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { dateTime });

        }
        public DataTable LoadListAllAdvanceBookings()
        {
            string query = "USP_LoadListAllAdvanceBookings";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public int GetCurrentIDBookRoom(DateTime dateTime)
        {
            string query = "USP_LoadBookRoomsByDate @date";
            DataRow dataRow= DataProvider.Instance.ExecuteQuery(query, new object[] { dateTime }).Rows[0];
            return (int)dataRow["Id"];
        }
        public bool IsIDBookRoomExists(int idBookRoom)
        {
            string query = "USP_IsIDBookRoomExists @idBookRoom";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { idBookRoom});
            return dataTable.Rows.Count > 0;
        }
        public DataTable ShowBookRoomInfo(int idBookRoom)
        {
            string query = "ShowBookRoomInfo @idBookRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idBookRoom });
        }
        public bool UpdateAdvanceBooking(int id,int idRoomType,DateTime datecheckin,DateTime datecheckout)
        {
            string query = "USP_UpdateBookRoom @id , @idRoomType , @dateCheckIn , @datecheckOut";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id, idRoomType, datecheckin, datecheckout }) > 0;
        }
        public bool DeleteAdvanceBooking(int id)
        {
            string query = "USP_DeleteAdvanceBooking @id";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id }) > 0;
        }
        public static AdvanceBookingDAO Instance { get { if (instance == null) instance = new AdvanceBookingDAO();return instance; }
            private set => instance = value; }
    }
}
