create Database Job_Portal
use Job_Portal


create table Users(
U_Id int primary key identity(1,1),
U_Name varchar (255),
U_Surname varchar(255),
U_Email varchar (MAX),
U_Username varchar(255),
U_Phone int ,
U_Password varchar(255),
U_RepeatPassword varchar(255),
U_TimeCreated datetime

)
INSERT INTO Users (U_Name, U_Surname, U_Email, U_Username, U_Phone, U_Password, U_RepeatPassword, U_TimeCreated)
VALUES ('John', 'Doe', 'john.doe@example.com', 'johndoe', 1234567890, 'password123', 'password123', GETDATE());

create table Contact_Form(
C_Id int primary key identity(1,1),		
C_Name varchar (255),
C_Surname varchar(255),
C_Email varchar (MAX),
C_Subject varchar (255),
C_Message varchar (MAX),
C_TimeCreated datetime

)
create table Jobs(
JobId int primary key identity (1,1),
JobTitle varchar(50),
NumberOfPositions int ,
JobDescription varchar(MAX),
Qualification varchar(MAX),
Experience varchar(50),
Requirements varchar(MAX),
LastDateToApply varchar(255),
JobType varchar(50),
CompanyName varchar(50),
CompanyLogo varchar(MAX),
Website varchar(100),
CompanyEmail varchar(50),
CompanyAddress varchar(MAX),
CompanyCountry varchar(50),
CompanyState varchar(50),
CompanyPhone int,
CreateDate_C datetime
)
INSERT INTO Jobs (
    JobTitle,
    NumberOfPositions,
    JobDescription,
    Qualification,
    Experience,
    Requirements,
    LastDateToApply,
    JobType,
    CompanyName,
    CompanyLogo,
    Website,
    CompanyEmail,
    CompanyAddress,
    CompanyCountry,
    CompanyState,
    CompanyPhone,
    CreateDate_C
) VALUES (
    'Software Engineer',
    3,
    'We are seeking a talented Software Engineer to join our team...',
    'Bachelor’s degree in Computer Science or related field',
    '2+ years',
    'Strong knowledge of C#, .NET Core, and SQL Server',
    '12Shkurt'
    'Full-time',
    'ABC Technologies',
    'https://example.com/logo.png',
    'https://www.example.com',
    'info@example.com',
    '123 Main St, City, Country',
    'Country',
    'State',
    1234567890,
    GETDATE() -- Current date and time
);
select * from jobs

create table JobCategories(
JobCategoryId int primary key identity(1,1),
JobCategoryName varchar (255)
)

INSERT INTO JobCategories (JobCategoryName)
VALUES ('Teknologji Informative');

select * from JobCategories