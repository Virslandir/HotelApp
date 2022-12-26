USE SQLServerHotelDB;

SELECT r.Id, r.RoomNumber, rt.Title AS RoomType, rt.Description, rt.PricePerNight
FROM ((dbo.Rooms r
LEFT JOIN dbo.Bookings b
ON b.RoomId = r.Id)
INNER JOIN dbo.RoomTypes rt
ON rt.Id = r.RoomTypeId)
WHERE 
('2022/12/01'>=b.DepartureDate OR '2023/01/07'<=b.ArrivalDate OR b.ArrivalDate IS NULL);