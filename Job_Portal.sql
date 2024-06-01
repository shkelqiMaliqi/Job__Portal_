CREATE DATABASE Job_Portal;
USE Job_Portal;

CREATE TABLE Users (
    U_Id INT PRIMARY KEY IDENTITY(1,1),
    U_Name VARCHAR(255) NOT NULL,
    U_Surname VARCHAR(255) NOT NULL,
    U_Email VARCHAR(255) NOT NULL,
    U_Username VARCHAR(255) NOT NULL,
    U_Phone VARCHAR(20) NOT NULL,  
    U_Password VARCHAR(255) NOT NULL,
	U_RepeatPassword Varchar(255) NOT NULL,
    U_Type VARCHAR (10) NOT NULL,  
    
);
select * from dbo.Users

CREATE TABLE Contact_Form (
    C_Id INT PRIMARY KEY IDENTITY(1,1),
    C_Name VARCHAR(255),
    C_Surname VARCHAR(255),
    C_Email VARCHAR(MAX),
    C_Subject VARCHAR(255),
    C_Message VARCHAR(MAX),
    U_Id INT,
    CONSTRAINT FK_Contact_Form_Users FOREIGN KEY (U_Id) REFERENCES Users(U_Id)
);


CREATE TABLE Jobs (
    JobId INT PRIMARY KEY IDENTITY(1,1),
    JobTitle VARCHAR(50),
    NumberOfPositions INT,
    JobDescription TEXT,
    Qualification TEXT,
    Experience VARCHAR(50),
    Requirements TEXT,
    JobType VARCHAR(50),
    CompanyName VARCHAR(50),
    CompanyLogo VARCHAR(MAX),
    Website VARCHAR(100),
    CompanyEmail VARCHAR(255),
    CompanyAddress TEXT,
    CompanyCountry VARCHAR(50),
    CompanyState VARCHAR(50),
    CompanyPhone VARCHAR(20),
    CreateDate_C DATETIME,
    JobCategoryId INT,
    JobCategories_ScheduleId INT,
    JobCategories_CityId INT,
    U_Id INT,
    CONSTRAINT FK_Jobs_JobCategories FOREIGN KEY (JobCategoryId) REFERENCES JobCategories(JobCategoryId),
    CONSTRAINT FK_Jobs_JobCategories_Schedule FOREIGN KEY (JobCategories_ScheduleId) REFERENCES JobCategories_Schedule(JobCategories_ScheduleId),
    CONSTRAINT FK_Jobs_JobCategories_City FOREIGN KEY (JobCategories_CityId) REFERENCES JobCategories_City(JobCategory_CityId),
    CONSTRAINT FK_Jobs_Users FOREIGN KEY (U_Id) REFERENCES Users(U_Id)
);


CREATE TABLE JobCategories (
    JobCategoryId INT PRIMARY KEY IDENTITY(1,1),
    JobCategoryName VARCHAR(255)
);

-- Create JobCategories_Schedule table
CREATE TABLE JobCategories_Schedule (
    JobCategories_ScheduleId INT PRIMARY KEY IDENTITY(1,1),
    JobCategories_Schedule_Time VARCHAR(255)
);

-- Create JobCategories_City table
CREATE TABLE JobCategories_City (
    JobCategory_CityId INT PRIMARY KEY IDENTITY(1,1),
    JobCategory_City_Name VARCHAR(255)
);

-- Create CV table
CREATE TABLE CV (
    Cv_Id INT PRIMARY KEY IDENTITY(1,1),
    Cv_Name VARCHAR(50),
    Cv_Surname VARCHAR(50),
    Cv_DateOfBirth DATE,
    Cv_PhoneNumber INT,
    Cv_Email VARCHAR(255),
    U_Id INT,
    CONSTRAINT FK_CV_Users FOREIGN KEY (U_Id) REFERENCES Users(U_Id)
);

-- Create Cv_Education table
CREATE TABLE Cv_Education (
    CvEdu_Id INT PRIMARY KEY IDENTITY(1,1),
    CvEdu_Education VARCHAR(MAX),
    Cv_Id INT,
    CONSTRAINT FK_Cv_Education_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id)
);

-- Create Cv_Experience table
CREATE TABLE Cv_Experience (
    CvExp_Id INT PRIMARY KEY IDENTITY(1,1),
    CvExp_Experiences VARCHAR(MAX),
    Cv_Id INT,
    CONSTRAINT FK_Cv_Experience_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id)
);

-- Create Cv_Industry table
CREATE TABLE Cv_Industry (
    CvIndustry_Id INT PRIMARY KEY IDENTITY(1,1),
    CvIndustry_IndustryType VARCHAR(MAX),
    Cv_Id INT,
    CONSTRAINT FK_Cv_Industry_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id)
);

-- Create Cv_TechnicalSkills table
CREATE TABLE Cv_TechnicalSkills (
    CvTs_Id INT PRIMARY KEY IDENTITY(1,1),
    CvTs_TSkills VARCHAR(MAX),
    Cv_Id INT,
    CONSTRAINT FK_Cv_TechnicalSkills_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id)
);

-- Create Cv_Certifications table
CREATE TABLE Cv_Certifications (
    CvCertifications_Id INT PRIMARY KEY IDENTITY(1,1),
    CvCertifications_Certifications VARCHAR(MAX),
    Cv_Id INT,
    CONSTRAINT FK_Cv_Certifications_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id)
);

-- Create Cv_AdditionalSkills table
CREATE TABLE Cv_AdditionalSkills (
    CvAs_Id INT PRIMARY KEY IDENTITY(1,1),
    CvAs_ASkills VARCHAR(MAX),
    Cv_Id INT,
    CONSTRAINT FK_Cv_AdditionalSkills_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id)
);

-- Create Cv_Courses table
CREATE TABLE Cv_Courses (
    CvCourses_Id INT PRIMARY KEY IDENTITY(1,1),
    CvCourses_C VARCHAR(MAX),
    Cv_Id INT,
    CONSTRAINT FK_Cv_Courses_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id)
);

-- Create Cv_Languages table
CREATE TABLE Cv_Languages (
    CvLang_Id INT PRIMARY KEY IDENTITY(1,1),
    CvLang_Lang VARCHAR(MAX),
    Cv_Id INT,
    CONSTRAINT FK_Cv_Languages_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id)
);

-- Create Cv_AddMore table
CREATE TABLE Cv_AddMore (
    CvAddMore_Id INT PRIMARY KEY IDENTITY(1,1),
    CvAddMore_Add VARCHAR(MAX),
    Cv_Id INT,
    CONSTRAINT FK_Cv_AddMore_CV FOREIGN KEY (Cv_Id) REFERENCES CV(Cv_Id)
);

-- Create TrainingCourses table
CREATE TABLE TrainingCourses (
    TrainingCourseId INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    StartDate DATE,
    EndDate DATE,
    Instructor VARCHAR(255),
    Price DECIMAL(10, 2)
);

-- Create CourseApplyForm table
CREATE TABLE CourseApplyForm (
    CourseApplyId INT PRIMARY KEY IDENTITY(1,1),
    Attendant_Name VARCHAR(255) NOT NULL,
    Attendant_Surname VARCHAR(255) NOT NULL,
    Attendant_Email VARCHAR(255),
    Attendant_PhoneNo INT NOT NULL,
    Courses_ApplyingName VARCHAR(255) NOT NULL
);

-- Create EnrollmentTypes table
CREATE TABLE EnrollmentTypes (
    EnrollmentTypeId INT PRIMARY KEY IDENTITY(1,1),
    TypeName VARCHAR(255) NOT NULL
);

-- Create ExperienceLevels table
CREATE TABLE ExperienceLevels (
    ExperienceLevelId INT PRIMARY KEY IDENTITY(1,1),
    LevelName VARCHAR(255) NOT NULL
);


