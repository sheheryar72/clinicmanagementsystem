IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'GetUserByEmail'
)
BEGIN
	EXEC ('Create Procedure GetUserByEmail as set nocount on;')
END
GO

Alter Procedure GetUserByEmail
	@Email varchar(50)

AS
BEGIN
	Select * from [User]
	where Email = @Email
END

