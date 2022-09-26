IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'GetAllPatient'
)
BEGIN
	EXEC ('Create Procedure GetAllPatient as set nocount on;')
END
GO

Alter Procedure GetAllPatient
As
BEGIN
	Select * from Patient
END