IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'GetUserById'
)
BEGIN
	EXEC ('Create Procedure GetUserById as set nocount on;')
END
GO

Alter Procedure GetUserById
	@Id varchar(50)

AS
BEGIN
	Select * from [User]
	where Id = @Id
END



