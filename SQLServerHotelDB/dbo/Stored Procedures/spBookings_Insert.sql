CREATE PROCEDURE [dbo].[spBookings_Insert]
	@RoomId int,
	@GuestId int, 
	@ArrivalDate date,
	@DepartureDate date,
	@TotalCost money
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Bookings(RoomId, GuestId, ArrivalDate, DepartureDate, TotalCost)
	VALUES(@RoomId, @GuestId, @ArrivalDate, @DepartureDate, @TotalCost);
END
