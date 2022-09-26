IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'UpdatePatient'
)
BEGIN
	EXEC ('Create Procedure UpdatePatient as set nocount on;')	
END
Go

Alter Procedure UpdatePatient
	@Id int, 
	@Name varchar(150),
	@Address varchar(300),
	@CNIC bigint,
	@DOB date,
	@Contact bigint,
	@Gender varchar(10),
	@UserId int,
	@Active bit,
	@CreatedAt datetime,
	@CreatedBy int,
	@ModifiedAt datetime,
	@ModifiedBy int
AS
BEGIN
	IF EXISTS (
		Select * from Patient
		where Id = @Id
	)
	BEGIN
		Update Patient
		Set Name = @Name,
			Address = @Address,
			CNIC = @CNIC,
			DOB = @DOB,
			Contact = @Contact,
			Gender = @Gender,
			UserId = @UserId,
			Active = @Active,
			CreatedAt = @CreatedAt,
			CreatedBy = @CreatedBy,
			ModifiedAt = @ModifiedAt,
			ModifiedBy = @ModifiedBy
			where Id = @Id
		Select @Id
	END
END


