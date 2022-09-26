IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'DeleteMedicine'
)
BEGIN
	EXEC ('Create Procedure DeleteMedicine as set nocount on;')	
END
Go

Alter Procedure DeleteMedicine
	@Id int
AS
BEGIN
	BEGIN
		IF EXISTS (
			Select * from Medicine
			Where Id = @Id
		)
	Delete FROM Medicine
		Where Id = @Id
	END
END

