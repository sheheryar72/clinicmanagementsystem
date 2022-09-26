IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'InsertUser'
)
--drop procedure InsertUser
BEGIN
	exec ('create procedure InsertUser as set nocount on;')
END
Go

Alter Procedure InsertUser	
		@Name varchar(150),
		@Email varchar(150),
		@Password varchar(150),
		@AdminId int,
		@Active bit,
		@CreatedAt datetime,
		@CreatedBy int,
		@ModifiedAt datetime,
		@ModifiedBy int
As
BEGIN
	Insert into [User] (
		Name,
		Email,
		Password,
		AdminId,
		Active,
		CreatedBy,
		CreatedAt,
		ModifiedBy,
		ModifiedAt
	) 
	Select	@Name,
		@Email,
		@Password,
		@AdminId,
		@Active,	
		@CreatedBy,
		@CreatedAt,
		@ModifiedBy,
		@ModifiedAt

	Select @@IDENTITY
END
