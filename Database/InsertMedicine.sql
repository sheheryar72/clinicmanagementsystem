IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'InsertMedicine'
)
--drop procedure InsertUser
BEGIN
	exec ('create procedure InsertMedicine as set nocount on;')
END
Go

Alter Procedure InsertMedicine	
		@Name varchar(150),
		@Quantity int,
		@Dosage int,
		@UserId int,
		@Active bit,
		@CreatedAt datetime,
		@CreatedBy int,
		@ModifiedAt datetime,
		@ModifiedBy int
As
BEGIN
	Insert into Medicine(
		Name,
		Quanitity,
		Dosage,
		UserId,
		Active,
		CreatedBy,
		CreatedAt,
		ModifiedBy,
		ModifiedAt
	) 
	Select	@Name,
		@Quantity,
		@Dosage,
		@UserId,
		@Active,	
		@CreatedBy,
		@CreatedAt,
		@ModifiedBy,
		@ModifiedAt

	Select @@IDENTITY
END
