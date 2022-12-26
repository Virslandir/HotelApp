CREATE PROCEDURE [dbo].[spBookings_GetBooking]
	@lastName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [b].[Id], [b].[RoomId], [b].[GuestId], [b].[ArrivalDate], [b].[DepartureDate], 
	[b].[CheckedIn], [b].[TotalCost],
	[g].[FirstName], [g].[LastName],
	[r].[RoomNumber], [r].[RoomTypeId],
	[rt].[Title], [rt].[Description], [rt].[PricePerNight]
	FROM dbo.Bookings b
	INNER JOIN dbo.Guests g ON g.Id = b.GuestId
	INNER JOIN dbo.Rooms r ON r.Id = b.RoomId
	INNER JOIN dbo.RoomTypes rt ON r.RoomTypeId = rt.Id
	WHERE g.LastName = @lastName AND b.ArrivalDate = CONVERT(DATE, GETDATE());
END
