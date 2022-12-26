CREATE PROCEDURE [dbo].[spGuests_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS(SELECT 1 FROM dbo.Guests WHERE FirstName = @FirstName AND LastName = @LastName)
	BEGIN
		INSERT INTO dbo.Guests(FirstName, LastName)
		VALUES(@FirstName, @LastName);
	END

	SELECT TOP 1 [Id], [FirstName], [LastName]
	FROM dbo.Guests 
	WHERE FirstName = @FirstName AND LastName = @LastName;

END

