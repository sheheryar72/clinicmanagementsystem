IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'DeleteUser'
)
BEGIN
	EXEC ('Create Procedure DeleteUser as set nocount on;')	
END
Go

Alter Procedure DeleteUser
	@Id int
AS
BEGIN
	BEGIN
		IF EXISTS (
			Select * from [User]
			Where Id = @Id
		)
	Delete FROM [User]
		Where Id = @Id
	END
END

