IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'GetMedicineById'
)
BEGIN
	EXEC ('Create Procedure GetMedicineById as set nocount on;')
END
GO

Alter Procedure GetMedicineById
	@Id varchar(50)

AS
BEGIN
	Select * from Medicine
	where Id = @Id
END


