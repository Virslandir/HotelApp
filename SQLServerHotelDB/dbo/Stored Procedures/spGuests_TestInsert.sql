CREATE PROCEDURE [dbo].[spGuests_TestInsert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
	BEGIN
		SET NOCOUNT ON;

		INSERT INTO dbo.Guests(FirstName, LastName)
		VALUES(@FirstName, @LastName);

	END
RETURN 0
