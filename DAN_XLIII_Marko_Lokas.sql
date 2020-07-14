IF DB_ID('ManagerApp') IS NULL
CREATE DATABASE ManagerApp
GO

USE ManagerApp

ALTER DATABASE ManagerApp COLLATE Croatian_CI_AS;
GO

-- Drop Foreign Keys
IF OBJECT_ID('tblEmployee', 'U') IS NOT NULL 
	ALTER TABLE tblEmployee DROP CONSTRAINT FK_Employee_AccessLevel;
IF OBJECT_ID('tblEmployee', 'U') IS NOT NULL 
	ALTER TABLE tblEmployee DROP CONSTRAINT FK_Employee_Sector;
IF OBJECT_ID('tblReport', 'U') IS NOT NULL 
	ALTER TABLE tblReport DROP CONSTRAINT FK_Report_Employee;
--===================================================================

-- Drop Primary Keys 
IF OBJECT_ID('tblReport', 'U') IS NOT NULL 
	ALTER TABLE tblReport DROP CONSTRAINT PK_Report;
IF OBJECT_ID('tblGenre', 'U') IS NOT NULL 
	ALTER TABLE tblGenre DROP CONSTRAINT PK_Genre;
IF OBJECT_ID('tblSector', 'U') IS NOT NULL 
	ALTER TABLE tblSector DROP CONSTRAINT PK_Sector;
IF OBJECT_ID('tblEmployee', 'U') IS NOT NULL 
	ALTER TABLE tblEmployee DROP CONSTRAINT PK_Employee;
--===================================================================

-- Drop UNUQUE
IF OBJECT_ID('tblEmployee', 'U') IS NOT NULL 
	ALTER TABLE tblEmployee DROP CONSTRAINT UC_JMBG;
IF OBJECT_ID('tblEmployee', 'U') IS NOT NULL 
	ALTER TABLE tblEmployee DROP CONSTRAINT UC_AccountNumber;
--===================================================================

-- Drop tables
IF OBJECT_ID('tblAccessLevel', 'U') IS NOT NULL 
	DROP TABLE tblAccessLevel;
IF OBJECT_ID('tblSector', 'U') IS NOT NULL 
	DROP TABLE tblSector;
IF OBJECT_ID('tblEmployee', 'U') IS NOT NULL 
	DROP TABLE tblEmployee;
IF OBJECT_ID('tblReport', 'U') IS NOT NULL 
	DROP TABLE tblReport;
IF OBJECT_ID('vwReportEmployee', 'V') IS NOT NULL 
	DROP VIEW vwReportEmployee;
IF OBJECT_ID('vwManager', 'V') IS NOT NULL 
	DROP VIEW vwManager;
--===================================================================

-- Create tables
CREATE TABLE tblAccessLevel(
	AccessLevelID		int identity(1,1) NOT NULL,
	AccessLevel			nvarchar (20) NOT NULL
	)



CREATE TABLE tblSector(
	SectorID	int identity(1,1) NOT NULL,
	SectorName	nvarchar (20) NOT NULL
	)

CREATE TABLE tblEmployee(
	EmployeeID			int identity(1,1) NOT NULL,
	EmployeeName		nvarchar (70) NOT NULL,
	EmployeeSurname		nvarchar (70) NOT NULL,
	DateOfBirthday		date NOT NULL,
	JMBG				char(13) NOT NULL,
	AccountNumber		nvarchar(20) NOT NULL,
	EMail				nvarchar(100) NOT NULL,
	Salary				nvarchar(15) NOT NULL,
	Position			nvarchar(30) NOT NULL,
	UsernameLogin		nvarchar(30) NOT NULL,
	PasswordLogin		nvarchar(30) NOT NULL,
	SectorName			int,
	AccessLevel			int
	)

CREATE TABLE tblReport(
	ReportID		int identity(1,1) NOT NULL,
	CurrentDate		date NOT NULL,
	ProjectName		nvarchar(20) NOT NULL,
	WorkHour		nvarchar(5) NOT NULL,
	Employee		int NOT NULL,
	Position		nvarchar(30) NOT NULL
	)
--===================================================================




-- Add contraints for PK
ALTER TABLE tblAccessLevel
	ADD CONSTRAINT PK_AccessLevel
	PRIMARY KEY (AccessLevelID)
ALTER TABLE tblSector
	ADD CONSTRAINT PK_Sector
	PRIMARY KEY (SectorID)
ALTER TABLE tblEmployee
	ADD CONSTRAINT PK_Employee
	PRIMARY KEY (EmployeeID)
ALTER TABLE tblReport
	ADD CONSTRAINT PK_Report
	PRIMARY KEY (ReportID)
--===================================================================

-- Add contraints for UNIQUE
ALTER TABLE tblEmployee
	ADD CONSTRAINT UC_JMBG
	UNIQUE (JMBG)
ALTER TABLE tblEmployee
	ADD CONSTRAINT UC_AccountNumber
	UNIQUE (AccountNumber)
--===================================================================

-- Add contraints for FK
ALTER TABLE tblEmployee 
	ADD CONSTRAINT FK_Employee_AccessLevel
	FOREIGN KEY (AccessLevel) 
	REFERENCES tblAccessLevel (AccessLevelID)
ALTER TABLE tblEmployee
	ADD CONSTRAINT FK_Employee_Sector
	FOREIGN KEY (SectorName)
	REFERENCES tblSector(SectorID)
ALTER TABLE tblReport
	ADD CONSTRAINT FK_Report_Employee
	FOREIGN KEY (Employee)
	REFERENCES tblEmployee(EmployeeID)
--===================================================================

-- Add CHECK contraints

-- JMBG - Must have 13 characters and all characters is number,
ALTER TABLE tblEmployee
	ADD CONSTRAINT CK_JMBG 
	CHECK(LEN(JMBG) = 13 AND JMBG LIKE ('[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))

-- DateOfBirth - User must be at least 16 years old
ALTER TABLE tblEmployee 
	ADD CONSTRAINT CK_DateOfBirthday
	CHECK(DateOfBirthday < DATEADD(YEAR, -16, GETDATE()))


--View

GO
CREATE VIEW vwReportEmployee AS
SELECT        dbo.tblReport.ReportID, dbo.tblReport.CurrentDate, dbo.tblReport.ProjectName, dbo.tblReport.WorkHour, dbo.tblReport.Employee, dbo.tblReport.Position, dbo.tblEmployee.EmployeeName, dbo.tblEmployee.EmployeeSurname, 
                         dbo.tblEmployee.EmployeeID, dbo.tblEmployee.Position AS Expr1
FROM            dbo.tblReport INNER JOIN
                         dbo.tblEmployee ON dbo.tblReport.Employee = dbo.tblEmployee.EmployeeID
GO

CREATE VIEW vwManager AS
SELECT        dbo.tblEmployee.EmployeeID, dbo.tblEmployee.EmployeeName, dbo.tblEmployee.EmployeeSurname, dbo.tblEmployee.DateOfBirthday, dbo.tblEmployee.JMBG, dbo.tblEmployee.AccountNumber, dbo.tblEmployee.EMail, 
                         dbo.tblEmployee.Salary, dbo.tblEmployee.Position, dbo.tblEmployee.UsernameLogin, dbo.tblEmployee.PasswordLogin, dbo.tblEmployee.SectorName, dbo.tblEmployee.AccessLevel, dbo.tblSector.SectorID, 
                         dbo.tblSector.SectorName AS Expr1, dbo.tblAccessLevel.AccessLevelID, dbo.tblAccessLevel.AccessLevel AS Expr2
FROM            dbo.tblAccessLevel INNER JOIN
                         dbo.tblEmployee ON dbo.tblAccessLevel.AccessLevelID = dbo.tblEmployee.AccessLevel INNER JOIN
                         dbo.tblSector ON dbo.tblEmployee.SectorName = dbo.tblSector.SectorID
GO

INSERT INTO tblAccessLevel (AccessLevel)
VALUES('modify')
INSERT INTO tblAccessLevel (AccessLevel)
VALUES('read-only')


INSERT INTO tblSector(SectorName)
VALUES('HR')
INSERT INTO tblSector(SectorName)
VALUES('Finance')
INSERT INTO tblSector(SectorName)
VALUES('R&D')