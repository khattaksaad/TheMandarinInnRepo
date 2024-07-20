using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class ReceiveRoomDAO
    {
        private static ReceiveRoomDAO instance;
        private ReceiveRoomDAO() { }
        public bool InsertReceiveRoom(int idBookRoom, int idRoom, DateTime checkOutDate, string userName)
        {
            string query = "InsertReceiveRoom @idBookRoom , @idRoom , @checkOutDate , @userName";
            int count = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBookRoom, idRoom, checkOutDate, userName });
            return count > 0;
        }
        public int GetIDCurrent()
        {
            string query = "GetIDReceiveRoomCurrent";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }
        public DataTable LoadReceiveRoomInfo()
        {
            string query = "USP_LoadReceiveRoomsByDate @date";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { DateTime.Now.Date });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">name of the customer</param>
        /// <param name="identfication">Identification is cnic for pakistani and passport number for foreigners</param>
        /// <returns></returns>
        public DataTable LoadBookedRoomsByCustomer(string name, string identification)
        {
            string query = "LoadBookedRoomsForCustomerByNameAndID @name , @cnic";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { name, identification });
        }
        public DataTable LoadBookedRoomsByRoomNameAndType(string roomName, string roomType)
        {
            string query = "[ShowBookRoomInfoByRoomNameAndType] @roomName , @roomType";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { roomName, roomType });
        }
        public int GetIdReceiveRoomFromIdRoom(int idRoom)
        {
            string query = "[USP_GetIdReceiveRoomFromIdRoom] @idRoom";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom });
            
            ReceiveRoom receiveRoom = new ReceiveRoom(dataTable.Rows[0]);
            return receiveRoom.Id;
        }
        public List<ReceiveRoom> GetReceiveRoomsOpen()
        {
            string query = "[USP_GetReceiveRoomsOpen]";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            List<ReceiveRoom> receiveRooms = new List<ReceiveRoom>();
            foreach(DataRow dr in dataTable.Rows)
            {
                ReceiveRoom receiveRoom = new ReceiveRoom(dr);
                receiveRooms.Add(receiveRoom);
            }
            return receiveRooms;
        }

        public DataTable ShowReceiveRoom(int id)
        {
            string query = "USP_ShowReceiveRoom @idReceiveRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }
        public DataTable ShowCustomers(int id)
        {
            string query = "USP_ShowCustomerFromReceiveRoom @idReceiveRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }
        public bool UpdateReceiveRoom(int id, int idRoom)
        {
            string query = "USP_UpdateReceiveRoom @id , @idRoom";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[]{ id, idRoom }) > 0;
        }
        public static ReceiveRoomDAO Instance { get { if (instance == null) instance = new ReceiveRoomDAO(); return instance; }
            private set => instance = value; }
    }
}
