IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'GetAllUser'
)
BEGIN
	EXEC ('Create Procedure GetAllUser as set nocount on;')
END
GO

Alter Procedure GetAllUser
As
BEGIN
	Select * from [User]
END



