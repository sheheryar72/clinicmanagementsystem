IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'GetAllMedicine'
)
BEGIN
	EXEC ('Create Procedure GetAllMedicine as set nocount on;')
END
GO

Alter Procedure GetAllMedicine
As
BEGIN
	Select * from Medicine
END
