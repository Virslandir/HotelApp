CREATE PROCEDURE [dbo].[spRoomTypes_GetAvailbaleRoomTypes]
	@ArrivalDate date,
	@DepartureDate date
AS
BEGIN
	SET NOCOUNT ON;

	SELECT DISTINCT rt.Id, rt.Title, rt.Description, rt.PricePerNight
	FROM ((dbo.Rooms r
	LEFT JOIN dbo.Bookings b
	ON b.RoomId = r.Id)
	INNER JOIN dbo.RoomTypes rt
	ON rt.Id = r.RoomTypeId)
	WHERE (@ArrivalDate>=b.DepartureDate OR @DepartureDate<=b.ArrivalDate OR b.ArrivalDate IS NULL);
END
