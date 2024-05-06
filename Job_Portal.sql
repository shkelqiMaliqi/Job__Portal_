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
U_RepeatPassword varchar(255)

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

----------------------------- THE CV FIELD -----------------------------------------
create table CV (
Cv_Id int primary key identity(1,1),
Cv_Name varchar (50),
Cv_Surname varchar (50),
Cv_DateOfBirth date,
Cv_PhoneNumber int,
Cv_Email varchar(255),

)
INSERT INTO CV (Cv_Name, Cv_Surname, Cv_DateOfBirth, Cv_PhoneNumber, Cv_Email)
VALUES ('John', 'Doe', '1990-01-01', 1234567890, 'john@example.com');

create table Cv_Education(
CvEdu_Id int primary key identity(1,1),
CvEdu_Education varchar(MAX)
)

create table Cv_Experience(
CvExp_Id int primary key identity(1,1),
CvExp_Experiences varchar(MAX)
)

create table Cv_Industry(
CvIndustry_Id int primary key identity(1,1),
CvIndustry_IndustryType varchar(MAX)
)

create table Cv_TechnicalSkills(
CvTs_Id int primary key identity(1,1),
CvTs_TSkills varchar(MAX)
)

create table Cv_Certifications(
CvCertifications_Id int primary key identity(1,1),
CvCertifications_Certifications varchar(MAX)
)

create table Cv_AdditionalSkills(
CvAs_Id int primary key identity(1,1),
CvAs_ASkills varchar(MAX)
)

create table Cv_Courses(
CvCourses_Id int primary key identity(1,1),
CvCourses_C varchar(MAX)
)

create table Cv_Languages(
CvLang_Id int primary key identity(1,1),
CvLang_Lang varchar(MAX)
)

create table Cv_AddMore(
CvAddMore_Id int primary key identity(1,1),
CvAddMore_Add varchar(MAX)
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


---------------------------------- CV Foreigns -------------------------

ALTER TABLE CV
ADD U_Id int,
CONSTRAINT FK_CV_Users FOREIGN KEY (U_Id) REFERENCES Users(U_Id);




ALTER TABLE Cv_Education
ADD Cv_Id int,
CONSTRAINT FK_Cv_Education_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id);


ALTER TABLE Cv_Experience
ADD Cv_Id int,
CONSTRAINT FK_Cv_Experience_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id);


ALTER TABLE Cv_Industry
ADD Cv_Id int,
CONSTRAINT FK_Cv_Industry_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id);

ALTER TABLE Cv_TechnicalSkills
ADD Cv_Id int,
CONSTRAINT FK_Cv_TechnicalSkills_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id);


ALTER TABLE Cv_Certifications
ADD Cv_Id int,
CONSTRAINT FK_Cv_Certifications_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id);


ALTER TABLE Cv_AdditionalSkills
ADD Cv_Id int,
CONSTRAINT FK_Cv_AdditionalSkills_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id);


ALTER TABLE Cv_Courses
ADD Cv_Id int,
CONSTRAINT FK_Cv_Courses_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id);


ALTER TABLE Cv_Languages
ADD Cv_Id int,
CONSTRAINT FK_Cv_Languages_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id);


ALTER TABLE Cv_AddMore
ADD Cv_Id int,
CONSTRAINT FK_Cv_AddMore_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id);

---------------------------------- Training and Courses -------------------------

CREATE TABLE TrainingCourses (
    TrainingCourseId int primary key identity(1,1),	
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    StartDate DATE,
    EndDate DATE,
    Instructor VARCHAR(255),
    Price DECIMAL(10, 2)
);

CREATE TABLE EnrollmentTypes (
    EnrollmentTypeId int primary key identity(1,1),	
    TypeName VARCHAR(255) NOT NULL
);

CREATE TABLE ExperienceLevels (
    ExperienceLevelId int primary key identity(1,1),	
    LevelName VARCHAR(255) NOT NULL
);

-----------------------Normal or Business User-------------------
create table BusinessUser (
	B_Id int primary key identity(1,1),
    B_CompanyName varchar(255),
    B_Email varchar(MAX),
    B_Username varchar(255),
    B_Phone int,
    B_Password varchar(255),
    B_RepeatPassword varchar(255),
);

create table UserType (
    UserType_Id int primary key identity(1,1),
    UserType_Name varchar(50) 
);

create table BusinessType (
    BusinessType_Id int primary key identity(1,1),
    BusinessType_Name varchar(255)
);
