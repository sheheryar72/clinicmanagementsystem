IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'DeletePatient'
)
BEGIN
	EXEC ('Create Procedure DeletePatient as set nocount on;')	
END
Go

Alter Procedure DeletePatient
	@Id int
AS
BEGIN
	BEGIN
		IF EXISTS (
			Select * from Patient
			Where Id = @Id
		)
	Delete FROM Patient
		Where Id = @Id
	END
END

