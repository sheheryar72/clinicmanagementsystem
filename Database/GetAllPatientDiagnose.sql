IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'GetAllPatientDiagnose'
)
BEGIN
	EXEC ('Create Procedure GetAllPatientDiagnose as set nocount on;')
END
GO

Alter Procedure GetAllPatientDiagnose
As
BEGIN
	Select pd.*, p.* from PatientDiagnose pd inner join Patient p on pd.PatientId = p.Id

END

