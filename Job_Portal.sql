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
create table Jobs(
JobId int primary key identity (1,1),
JobTitle varchar(50),
NumberOfPositions varchar(50),
JobDescription varchar(MAX),
Qualification varchar(50),
Experience varchar(50),
Requirements varchar(MAX),
LastDateToApply date,
JobType varchar(50),
CompanyName varchar(50),
ComapnyLogo varchar(MAX),
Website varchar(100),
CompanyEmail varchar(50),
CompanyAddress varchar(MAX),
CompanyCoutry varchar(50),
CompanyState varchar(50),
CrateDate_C datetime
)
