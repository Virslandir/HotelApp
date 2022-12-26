using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Databases;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Data
{
    public class SqlCrud : IDatabaseCrud
    {
        private readonly ISqlServerDataAccess _db;
        private const string connectionStringName = "Default";


        public SqlCrud(ISqlServerDataAccess db)
        {
            _db = db;
        }

        public List<RoomTypeModel> GetAvailableRoomTypes(DateTime arrivalDate, DateTime departureDate)
        {
            List<RoomTypeModel> availableRoomTypes = _db.ReadData<RoomTypeModel, dynamic>("spRoomTypes_GetAvailbaleRoomTypes",
                                                                                        new
                                                                                        {
                                                                                            arrivalDate,
                                                                                            departureDate
                                                                                        },
                                                                                        connectionStringName,
                                                                                        true);

            return availableRoomTypes;
        }

        //public List<RoomModel> GetAvailableRooms(DateTime arrivalDate, DateTime departureDate)
        //{
        //    string sql = @"SELECT r.Id, r.RoomNumber, r.RoomTypeId
        //                    FROM ((dbo.Rooms r
        //                    LEFT JOIN dbo.Bookings b
        //                    ON b.RoomId = r.Id)
        //                    INNER JOIN dbo.RoomTypes rt
        //                    ON rt.Id = r.RoomTypeId)
        //                    WHERE 
        //                    (@ArrivalDate>=b.DepartureDate OR @DepartureDate<=b.ArrivalDate OR b.ArrivalDate IS NULL);";

        //    List<RoomModel> availableRooms = _db.ReadData<RoomModel, dynamic>(sql,
        //                                                                              new
        //                                                                              {
        //                                                                                  arrivalDate,
        //                                                                                  departureDate
        //                                                                              },
        //                                                                              "Default");

        //    return availableRooms;
        //}

        // obrisi FullBookingModel argument
        public void BookARoom(string firstName, string lastName, DateTime arrivalDate, DateTime departureDate, int roomTypeId)
        {
            GuestModel guest = _db.ReadData<GuestModel, dynamic>("spGuests_Insert",
                                                                 new { firstName, lastName },
                                                                 "Default",
                                                                 true).First();

            string sqlRoomType = @"SELECT r.Id, r.Title, r.Description, r.PricePerNight
                                   FROM dbo.RoomTypes r
                                   WHERE r.Id = @Id";

            RoomTypeModel roomType = _db.ReadData<RoomTypeModel, dynamic>(sqlRoomType,
                                                                          new { Id = roomTypeId },
                                                                          connectionStringName).First();

            int durationOfStay = (departureDate - arrivalDate).Days;


            RoomModel availableRoom = _db.ReadData<RoomModel, dynamic>("spRooms_GetAvailableRooms",
                                                                              new { arrivalDate, departureDate, roomTypeId },
                                                                              connectionStringName,
                                                                              true).First();

            _db.SaveData<dynamic>("spBookings_Insert",
                                  new
                                  {
                                      RoomId = availableRoom.Id,
                                      guestId = guest.Id,
                                      arrivalDate,
                                      departureDate,
                                      TotalCost = roomType.PricePerNight * durationOfStay
                                  },
                                  connectionStringName,
                                  true);
        }

        public List<FullBookingModel> GetBookings(string lastName)
        {
            return _db.ReadData<FullBookingModel, dynamic>("spBookings_GetBooking",
                                                       new { lastName },
                                                       connectionStringName,
                                                       true);
        }

        public void CheckInGuest(int bookingId)
        {
            _db.SaveData("spBookings_CheckIn",
                                       new { Id = bookingId },
                                       connectionStringName,
                                       true);
        }
    }
}
