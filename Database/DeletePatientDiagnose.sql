IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'DeletePatientDiagnose'
)
BEGIN
	EXEC ('Create Procedure DeletePatientDiagnose as set nocount on;')
END
GO

Alter Procedure DeletePatientDiagnose
	@Id int
AS
BEGIN
	Delete from PatientDiagnose
	where Id = @Id
END



