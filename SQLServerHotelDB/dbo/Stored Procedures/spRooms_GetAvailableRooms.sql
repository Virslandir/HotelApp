CREATE PROCEDURE [dbo].[spRooms_GetAvailableRooms]
	    @ArrivalDate date,
		@DepartureDate date,
		@RoomTypeId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT r.Id, r.RoomNumber, r.RoomTypeId
	FROM ((dbo.Rooms r
	LEFT JOIN dbo.Bookings b
	ON b.RoomId = r.Id)
	INNER JOIN dbo.RoomTypes rt
	ON rt.Id = r.RoomTypeId)
	WHERE r.RoomTypeId = @RoomTypeId
	AND
	(@ArrivalDate>=b.DepartureDate OR @DepartureDate<=b.ArrivalDate OR b.ArrivalDate IS NULL);


END
