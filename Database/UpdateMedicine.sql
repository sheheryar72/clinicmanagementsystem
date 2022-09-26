IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'UpdateMedicine'
)
BEGIN
	EXEC ('Create Procedure UpdateMedicine as set nocount on;')	
END
Go

Alter Procedure UpdateMedicine
		@Id int, 
		@Name varchar(150),
		@Quantity int,
		@Dosage int,
		@UserId int,
		@Active bit,
		@CreatedAt datetime,
		@CreatedBy int,
		@ModifiedAt datetime,
		@ModifiedBy int
AS
BEGIN
	IF EXISTS (
		Select * from Medicine
		where Id = @Id
	)
	BEGIN
		Update Medicine
		Set Name = @Name,
			Quanitity = @Quantity,
			Dosage = @Dosage,
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


