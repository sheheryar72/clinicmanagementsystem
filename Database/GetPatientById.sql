IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'GetPatientById'
)
BEGIN
	EXEC ('Create Procedure GetPatientById as set nocount on;')
END
GO

Alter Procedure GetPatientById
	@Id varchar(50)

AS
BEGIN
	Select * from Patient
	where Id = @Id
END


