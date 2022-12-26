using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Data
{
    public interface IDatabaseCrud
    {
        void BookARoom(string firstName, string lastName, DateTime arrivalDate, DateTime departureDate, int roomTypeId);
        void CheckInGuest(int bookingId);
        List<RoomTypeModel> GetAvailableRoomTypes(DateTime arrivalDate, DateTime departureDate);
        List<FullBookingModel> GetBookings(string lastName);
    }
}