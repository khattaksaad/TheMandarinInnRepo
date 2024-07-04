using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class BookRoom
    {
        private int id;
        private int idCustomer;
        private int idRoomType;
        private DateTime dateCheckIn;
        private DateTime dateCheckOut;
        private DateTime dateBookRoom;
        //for a self customer, set to 0, for company set to 1
        private int bookingType;
        public BookRoom(int id, int idCustomer, int idRoomType,int bookingType, DateTime dateCheckIn, DateTime dateCheckOut,DateTime dateBookRoom)
        {
            Id = id;
            IdCustomer = idCustomer;
            IdRoomType = idRoomType;
            DateCheckIn = dateCheckIn;
            BookingType = bookingType;
            DateCheckOut = dateCheckOut;
            DateBookRoom = dateBookRoom;
        }
        public BookRoom(DataRow row)
        {
            Id = (int)row["id"];
            IdCustomer = (int)row["idCustomer"];
            IdRoomType = (int)row["IdRoomType"];
            BookingType = (int)row["bookingType"];
            DateCheckIn = (DateTime)row["DateCheckIn"];
            DateCheckOut = (DateTime)row["DateCheckOut"];
            DateBookRoom = (DateTime)row["DateBookRoom"];
        }

        public int Id { get => id; set => id = value; }
        public int IdCustomer { get => idCustomer; set => idCustomer = value; }
        public int IdRoomType { get => idRoomType; set => idRoomType = value; }
        public int BookingType { get => bookingType; set => bookingType = value; }
        public DateTime DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public DateTime DateBookRoom { get => dateBookRoom; set => dateBookRoom = value; }
    }
}
