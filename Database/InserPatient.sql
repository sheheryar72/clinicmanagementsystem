IF NOT EXISTS (
	Select name from sys.procedures
	where name = 'InserPatient'
)
--drop procedure InsertUser
BEGIN
	exec ('create procedure InserPatient as set nocount on;')
END
Go

Alter Procedure InserPatient	
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
As
BEGIN
	Insert into Patient (
		Name,
		Address,
		CNIC,
		DOB,
		Contact,
		Gender,
		UserId,
		Active,
		CreatedBy,
		CreatedAt,
		ModifiedBy,
		ModifiedAt
	) 
	Select	@Name,
		@Address,
		@CNIC,
		@DOB,
		@Contact,
		@Gender,
		@UserId,
		@Active,
		@CreatedBy,
		@CreatedAt,
		@ModifiedBy,
		@ModifiedAt

	Select @@IDENTITY
END
