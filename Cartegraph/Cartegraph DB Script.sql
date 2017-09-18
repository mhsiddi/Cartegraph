create database CartegraphTest

go

use CartegraphTest
go

CREATE TABLE Employee(

EmployeeID int primary key identity(1,1) not null,
JobTitle nvarchar(50) not null,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null

)

CREATE TABLE Citizen(

CitizenID int primary key identity(1,1) not null,
FirstName nvarchar(50) not null,
LastName nvarchar(50)  not null,
Email nvarchar(50) not null,
Phone nvarchar(12) not null
)

CREATE TABLE IssueType (

IssueTypeID int primary key identity(1,1),
IssueType nvarchar(50) not null
)

CREATE TABLE Issues(

IssueID int primary key identity(1,1) not null,
IssueTypeID int foreign key references IssueType(IssueTypeID), 
Details nvarchar(100) not null,
Location nvarchar(500) not null,
ReportedBy int foreign key references Employee(EmployeeID) not null,
CitizenID int foreign key references Citizen(CitizenID),
CreateDate DATETIME DEFAULT GetDate()
)

GO

CREATE proc [dbo].[CreateIssue] (

@IssueType int,
@Details nvarchar(100),
@Location nvarchar(50),
@ReportedBy int,
@CFirst nvarchar(50),
@CLast nvarchar(50),
@CEmail nvarchar(50),
@CPhone nvarchar(50)

)

as

if not exists (select * from Citizen where email = @CEmail)
begin
insert into Citizen
values(@CFirst, @CLast, @CEmail, @CPhone)

insert into Issues 
values(@IssueType, @Details, @Location, @ReportedBy,(select CitizenID from Citizen where Email = @CEmail), GETDATE()) 

end

else
begin

insert into Issues 
values(@IssueType, @Details, @Location, @ReportedBy,(select CitizenID from Citizen where Email = @CEmail), GETDATE()) 


end
GO

create proc GetAllIssues

as

select t1.IssueID, t1.IssueTypeID, t1.Details, t1.Location, t1.ReportedBy, t2.IssueType, t3.FirstName + ' ' + t3.LastName as [EmployeeName], t4.FirstName + ' ' + t4.LastName AS [CitizenName], t4.Email as [CEmail], t4.Phone as [CPhone] from Issues t1
inner join IssueType t2
	on t1.IssueTypeID = t2.IssueTypeID 
inner join Employee t3 
	on t1.ReportedBy = t3.EmployeeID
inner join Citizen t4
	on t1.CitizenID = t4.CitizenID 


GO



insert into Employee
values('Construction Contractor', 'Joe', 'Smith'),
('Mayor', 'Bat', 'Man'),
('Police', 'Robert', 'Junior')

GO
create proc GetAllEmployees
as

select * from Employee 

GO

insert into IssueType 
values('Pot Hole'),
('Environment'),
('Housing'),
('Society'),
('Signs'),
('Plants'),
('Other')

GO

create proc [dbo].[GetIssueTypes]

as

select * from IssueType
GO