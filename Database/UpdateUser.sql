IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'UpdateUser'
)
BEGIN
	EXEC ('Create Procedure UpdateUser as set nocount on;')	
END
Go

Alter Procedure UpdateUser
	@Id int, 
	@Name varchar(150),
	@Email varchar(150),
	@Password varchar(150),
	@AdminId int = null,
	@Active bit,
	@CreatedAt datetime,
	@CreatedBy int,
	@ModifiedAt datetime,
	@ModifiedBy int
AS
BEGIN
	IF EXISTS (
		Select * from [User]
		where Id = @Id
	)
	BEGIN
		Update [User]
		Set Name = @Name,
			Email = @Email,
			Password = @Password,
			AdminId = @AdminId,
			Active = @Active,
			CreatedAt = @CreatedAt,
			CreatedBy = @CreatedBy,
			ModifiedAt = @ModifiedAt,
			ModifiedBy = @ModifiedBy
			where Id = @Id
		Select @Id
	END
END


