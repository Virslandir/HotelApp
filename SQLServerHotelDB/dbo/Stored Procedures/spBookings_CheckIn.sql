CREATE PROCEDURE [dbo].[spBookings_CheckIn]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.Bookings
	SET CheckedIn = 'true'
	WHERE
	Id = @id;
END
