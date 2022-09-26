IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'InsertPatientDiagnose'
)
BEGIN
	Exec ('Create Procedure InsertPatientDiagnose as set nocount on;')
END
GO

Alter Procedure InsertPatientDiagnose
	@Diagnose nvarchar(200),
	@Discription nvarchar(500) = null,
	@Visit datetime,
	@NextVisit datetime,
	@BP varchar(150) = null,
	@Weight varchar(50) = null,
	@PatientId int,
	@UserId int,
	@MedicineId int,
	@Active bit,
	@CreatedAt datetime,
	@CreatedBy int,
	@ModifiedAt datetime,
	@ModifiedBy int

AS
BEGIN

	Insert into PatientDiagnose(
		Diagnose,
		Discription,
		Visit,
		NextVisit,
		BP,
		Weight,
		PatientId,
		UserId,
		MedicineId,
		Active,
		CreatedAt,
		CreatedBy,
		ModifiedAt,
		ModifiedBy
	)	
	Select @Diagnose,
		@Discription,
		@Visit,
		@NextVisit,
		@BP,
		@Weight,
		@PatientId,
		@UserId,
		@MedicineId,
		@Active,
		@CreatedAt,
		@CreatedBy,
		@ModifiedAt,
		@ModifiedBy

	Select @@IDENTITY
END



























