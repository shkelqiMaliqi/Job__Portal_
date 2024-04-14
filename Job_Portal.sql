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

select * 
from DBO.Users 

create table Contact_Form(
C_Id int primary key identity(1,1),		
C_Name varchar (255),
C_Surname varchar(255),
C_Email varchar (MAX),
C_Subject varchar (255),
C_Message varchar (MAX),
C_TimeCreated datetime

)
INSERT INTO Contact_Form (C_Name, C_Surname, C_Email, C_Subject, C_Message, C_TimeCreated)
VALUES ('John', 'Doe', 'john.doe@example.com', 'Query about your services', 'Hello, I am interested in learning more about your services.', GETDATE());

create table Jobs(
JobId int primary key identity (1,1),
JobTitle varchar(50),
NumberOfPositions int ,
JobDescription varchar(MAX),
Qualification varchar(MAX),
Experience varchar(50),
Requirements varchar(MAX),
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
ALTER TABLE Jobs
ADD JobCategoryId int,
CONSTRAINT FK_Jobs_JobCategories FOREIGN KEY (JobCategoryId) REFERENCES JobCategories(JobCategoryId);

-- Add foreign key reference from Contact_Form table to Users table
ALTER TABLE Contact_Form
ADD U_Id int,
CONSTRAINT FK_Contact_Form_Users FOREIGN KEY (U_Id) REFERENCES Users(U_Id);

-- Add foreign key reference from Jobs table to Users table (for company information)
ALTER TABLE Jobs
ADD U_Id int,
CONSTRAINT FK_Jobs_Users FOREIGN KEY (U_Id) REFERENCES Users(U_Id);