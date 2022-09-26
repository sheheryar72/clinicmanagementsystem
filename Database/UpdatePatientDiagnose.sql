IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'UpdatePatientDiagnose'
)
BEGIN
	EXEC ('Create Procedure UpdatePatientDiagnose as set nocount on;')	
END
Go

Alter Procedure UpdatePatientDiagnose
	@Id int, 
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
	IF EXISTS (
		Select * from PatientDiagnose
		where Id = @Id
	)
	BEGIN
		Update PatientDiagnose
		Set Diagnose = @Diagnose,
			Discription = @Discription,
			Visit = @Visit,
			NextVisit = @NextVisit,
			BP = @BP,
			Weight = @Weight,
			PatientId = @PatientId,
			UserId = @UserId,
			MedicineId = @MedicineId,
			Active = @Active,
			CreatedAt = @CreatedAt,
			CreatedBy = @CreatedBy,
			ModifiedAt = @ModifiedAt,
			ModifiedBy = @ModifiedBy
			where Id = @Id
		Select @Id
	END
END


