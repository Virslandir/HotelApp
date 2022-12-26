using DataAccessLibrary.Data;
using DataAccessLibrary.Databases;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace TestConsoleUI
{
    class Program
    {
        static void Main()
        {
            SqlServerDataAccess db = ConfigureDbConnection();
            SqlCrud sql = new SqlCrud(db);

            //string firstName = "Stefan";
            string lastName = "Spiric";

            DateTime arrivalDate = new DateTime(2022, 12, 15);
            DateTime departureDate = new DateTime(2022, 12, 17);

            //List<RoomTypeModel> availableRoomTypes = sql.GetAvailableRoomTypes(arrivalDate, departureDate);

            //int roomTypeId = 2;

            //sql.BookARoom(firstName, lastName, arrivalDate, departureDate, roomTypeId);

            List<FullBookingModel> bookings = sql.GetBookings(lastName);

            foreach (var booking in bookings)
            {
                sql.CheckInGuest(booking.Id);
            }

            Console.ReadLine();
        }

        private static SqlServerDataAccess ConfigureDbConnection()
        {
            var builder = new ConfigurationBuilder()
                                          .SetBasePath(Directory.GetCurrentDirectory())
                                          .AddJsonFile("appsettings.json");

            var config = builder.Build();

            SqlServerDataAccess db = new SqlServerDataAccess(config);

            return db;
        }
    }
}
