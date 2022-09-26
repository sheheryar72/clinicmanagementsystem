IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'GetPatientDiagnoseById'
)
BEGIN
	EXEC ('Create Procedure GetPatientDiagnoseById as set nocount on;')
END
GO

Alter Procedure GetPatientDiagnoseById
	@Id varchar(50)

AS
BEGIN
	Select * from PatientDiagnose
	where Id = @Id
END


