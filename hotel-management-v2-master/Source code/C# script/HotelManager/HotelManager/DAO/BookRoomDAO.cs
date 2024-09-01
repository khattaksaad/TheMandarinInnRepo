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
    public class BookRoomDAO
    {
        private static BookRoomDAO instance;
        private BookRoomDAO() { }
        public bool InsertBookRoom(int roomId, int idCustomer, int idRoomType, int bookingType, string roomName,DateTime datecheckin,DateTime datecheckout, DateTime datebookroom, int pricePerNight, string userName)
        {
            //@roomId int, @idCustomer int,@idRoomType int, @roomName nvarchar(100),@datecheckin date,@datecheckout date,@datebookroom smalldatetime, @userName nvarchar(20)

            string query = "USP_InsertBookRoom @roomId , @idCustomer , @idRoomType , @bookingType , @roomName , @datecheckin , @datecheckout , @datebookroom , @pricePerNight , @userName";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { roomId, idCustomer, idRoomType, bookingType, roomName, datecheckin, datecheckout, datebookroom, pricePerNight, userName }) > 0;
        }
        public DataTable LoadListBookRoom(DateTime dateTime)
        {
            string query = "USP_LoadBookRoomsByDate @date";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { dateTime });

        }
        public DataTable LoadListAllBookedRooms()
        {
            string query = "USP_LoadAllBookedRooms";
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
        public bool UpdateBookRoom(int id,int idRoomType,DateTime datecheckin,DateTime datecheckout)
        {
            string query = "USP_UpdateBookRoom @id , @idRoomType , @dateCheckIn , @datecheckOut";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id, idRoomType, datecheckin, datecheckout }) > 0;
        }
        public bool DeleteBookRoom(int id)
        {
            string query = "USP_DeleteBookRoom @id";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id }) > 0;
        }
        public static BookRoomDAO Instance { get { if (instance == null) instance = new BookRoomDAO();return instance; }
            private set => instance = value; }
    }
}
