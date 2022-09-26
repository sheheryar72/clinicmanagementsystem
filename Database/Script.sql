IF NOT EXISTS (
	select name from sys.databases where name = 'ClinicManagementSystem'
)
BEGIN
Create database ClinicManagementSystem
END

Use ClinicManagementSystem

IF NOT EXISTS (
	Select name from sys.tables where name = 'Admin'
)
BEGIN
Create Table [Admin](
	Id int identity(1,1) not null constraint admin_pk_id primary key clustered,
	[Name] varchar(150) not null,
	Email varchar(150) not null,
	[Password] varchar(150) not null
)
END

IF NOT EXISTS (
	Select name from sys.tables where name = 'User'
)
BEGIN
Create Table [User](
	Id int identity(1,1) not null constraint user_pk_id primary key clustered,
	[Name] varchar(150) not null,
	Email varchar(150) not null,
	[Password] varchar(150) not null,
	AdminId int not null constraint user_fk_adminId foreign key References [Admin](Id), 
	Active bit not null default(1),
	CreatedAt datetime not null,
	CreatedBy int not null,
	ModifiedAt datetime null,
	ModifiedBy int null
)
END

IF NOT EXISTS (
	Select name from sys.tables where name = 'Patient'
)
BEGIN
Create Table [Patient](
	Id int identity(1,1) not null constraint patient_pk_id primary key clustered,
	[Name] varchar(150) not null,
	Address varchar(300) not null,
	CNIC bigint not null,
	DOB date not null,
	Contact bigint not null,
	Gender varchar(10) not null,
	UserId int null constraint patient_fk_userid foreign key references [User](Id),
	Active bit not null default(1),
	CreatedAt datetime not null,
	CreatedBy int not null,
	ModifiedAt datetime null,
	ModifiedBy int null
)
END

IF NOT EXISTS (
	Select name from sys.tables where name = 'Medicine'
)
BEGIN
Create Table [Medicine](
	Id int identity(1,1) not null constraint medicine_pk_id primary key clustered,
	[Name] varchar(150) not null,
	Quanitity int not null,
	Dosage int not null,
	Active bit not null default(1),
	UserId int null constraint medicine_fk_userid foreign key references [User](Id),
	CreatedAt datetime not null,
	CreatedBy int not null,
	ModifiedAt datetime null,
	ModifiedBy int null
)
END


IF NOT EXISTS (
	Select name from sys.tables where name = 'PatientDiagnose'
)
BEGIN
Create Table [PatientDiagnose](
	Id int identity(1,1) not null constraint patientdiagnose_pk_id primary key clustered,
	Diagnose Nvarchar(200) not null,
	Discription Nvarchar(500) null,
	Visit datetime not null,
	NextVisit datetime null,
	BP varchar(150) null,
	[Weight] varchar(50) null,
	PatientId int null constraint patientdiagnose_fk_patientid foreign key references [Patient](Id),
	UserId int null constraint patientdiagnose_fk_userid foreign key references [User](Id),
	MedicineId int null constraint patientdiagnose_fk_medicineid foreign key references [Medicine](Id),
	Active bit not null default(1),
	CreatedAt datetime not null,
	CreatedBy int not null,
	ModifiedAt datetime null,
	ModifiedBy int null
)
END


















