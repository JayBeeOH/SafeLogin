--'------------------------------------------------------------------------------------------
--'           Notice of My Copyright and Intellectual Property Rights
--'
--'            Copyright © 2017 Joseph L. Bolen. All rights reserved.
--'        All trademarks remain the property of their respective owners.
--'
--'    This program Is free software: you can redistribute it And/Or modify
--'    it under the terms Of the GNU General Public License As published by
--'    the Free Software Foundation, either version 3 Of the License, Or
--'    any later version.
--'
--'    This program Is distributed In the hope that it will be useful,
--'    but WITHOUT ANY WARRANTY; without even the implied warranty Of
--'    MERCHANTABILITY Or FITNESS FOR A PARTICULAR PURPOSE.  See the
--'    GNU General Public License For more details.
--'
--'    You should have received a copy Of the GNU General Public License
--'    along with this program.  If Not, see < http: //www.gnu.org/licenses/>.
--'
--'-------------------------------------------------------------------------------------------
--' Program Name:   Safe Login
--' SqlScript:      PersonQueries
--'
--' Author:         Joseph L. Bolen
--' Date Created:   06 JUN 2017
--'
--' Description:    Demonstration of not storing passwords, but storing the salt and hash.
--'
--'-------------------------------------------------------------------------------------------'
--'                 Documentation is at:
--'                   App's documentation is at:  https://jaybeeoh.github.io/SafeLogin/
--'                   Video tutorials at YouTube: http://www.youtube.com/user/bolenpresents
--'-------------------------------------------------------------------------------------------

USE JLBSampleDB;
GO
 
IF OBJECT_ID('dbo.Title', 'U') IS NOT NULL 
  DROP TABLE dbo.Title; 

IF OBJECT_ID('dbo.Suffix', 'U') IS NOT NULL 
	DROP TABLE dbo.Suffix;
GO

IF OBJECT_ID('dbo.Password', 'U') IS NOT NULL 
	DROP TABLE dbo.Password;
GO

IF OBJECT_ID('dbo.Person', 'U') IS NOT NULL 
	DROP TABLE dbo.Person;
GO

CREATE TABLE Title (
	TitleID		Int	NOT NULL IDENTITY,
	Seq			Int NOT NULL,
	Title		NVarChar(10) NOT NULL,
CONSTRAINT PK_Title_TitleID PRIMARY KEY CLUSTERED (TitleID));
GO

CREATE INDEX IX_Title_Title ON Title (Seq, Title);
GO

INSERT INTO Title
	(Seq, Title)
VALUES
	(10, 'Mr.'),
	(20, 'Mrs.'),
	(30, 'Ms.'),
	(40, 'Dr.'),
	(50, 'Rev.'),
	(60, 'Hon.'),
	(70, 'Prof.'),
	(80, 'Gen.'),
	(90, 'LtG.'),
	(100, 'Col.'),
	(110, 'Maj.'),
	(120, 'Capt.'),
	(130, 'Lt.'),
	(140, 'Sgt.'),
	(150, 'Pvt.'),
	(160, 'Amn.'),
	(170, 'Adm.'),
	(180, 'Cdr.'),
	(190, 'Ens.'),
	(200, 'PO.'),
	(210, 'SN.');
GO

CREATE TABLE Suffix (
	SuffixID		Int	NOT NULL IDENTITY,
	Seq				Int NOT NULL,
	Suffix			NVarChar(10) NOT NULL,
CONSTRAINT PK_Suffix_SuffixID PRIMARY KEY CLUSTERED (SuffixID));
GO

CREATE INDEX IX_Suffix_Suffix ON Suffix (Seq, Suffix);
GO

INSERT INTO Suffix
	(Seq, Suffix)
VALUES
	(10, 'Jr.'),
	(20, 'Sr.'),
	(30, 'II'),
	(40, 'III'),
	(50, 'Esq.'),
	(60, 'Ret.');
GO

CREATE TABLE Person (
	PersonID		Int	NOT NULL IDENTITY,
	PersonType		NChar(2) NOT NULL,
	PersonStatus	NChar(1) NOT NULL,
	TitleID			Int NULL,
	FirstName		NVarChar(35) NOT NULL,
	MiddleName		NVarChar(35) NULL,
	LastName		NVarChar(35) NOT NULL,
	SuffixID		Int NULL,
	UserName		NVarChar(35) NOT NULL,
	DateAdded		DateTime NOT NULL,
	DateModified	DateTime NOT NULL,
	RV				RowVersion NOT NULL,
CONSTRAINT PK_Person_PersonID PRIMARY KEY CLUSTERED (PersonID));
GO

ALTER TABLE Person WITH CHECK ADD CONSTRAINT CK_Person_PersonType
	CHECK  (PersonType IS NULL
			OR (upper(PersonType)='EM' 
			OR upper(PersonType)='ST' 
			OR upper(PersonType)='SP' 
			OR upper(PersonType)='CT' 
			OR upper(PersonType)='ID' ));
GO

ALTER TABLE Person WITH CHECK ADD CONSTRAINT CK_Person_Status
	CHECK  (PersonStatus IS NULL 
			OR (upper(PersonStatus)='A' 
			OR upper(PersonStatus)='I' 
			OR upper(PersonStatus)='D'));
GO

ALTER TABLE Person ADD  CONSTRAINT DF_Person_PersonType DEFAULT 'ID' FOR PersonType;
GO

ALTER TABLE Person ADD  CONSTRAINT DF_Person_PersonStatus DEFAULT 'A' FOR PersonStatus;
GO

ALTER TABLE Person ADD  CONSTRAINT DF_Person_DateAdded DEFAULT (getdate()) FOR DateAdded;
GO

ALTER TABLE Person ADD  CONSTRAINT DF_Person_DateModified DEFAULT (getdate()) FOR DateModified;
GO

ALTER TABLE Person ADD CONSTRAINT FK_Person_Title FOREIGN KEY (TitleID) REFERENCES Title(TitleID);
GO

ALTER TABLE Person ADD CONSTRAINT FK_Person_Suffix FOREIGN KEY (SuffixID) REFERENCES Suffix(SuffixID);
GO

CREATE UNIQUE INDEX IX_Person_UserName ON Person (UserName);
GO

INSERT INTO Person (
	TitleID
	,FirstName
	,MiddleName
	,LastName
	,SuffixID
	,UserName)
VALUES
	(1,'Joseph', 'Lee', 'Bolen', 3,'JayBeeOH')
	,(1,'Daniel', 'P','Bolen', NULL, 'DeeBeeOH')
	,(NULL,'Cathy', NULL, 'Cunningham', NULL ,'CathyCee');
GO

SELECT * FROM Title;

SELECT * FROM Suffix;

SELECT	p.PersonID, 
		p.PersonType, 
		p.PersonStatus, 
		t.Title,
		p.FirstName,
		p.MiddleName,
		p.LastName,
		s.Suffix,
		p.UserName,
		CONVERT (date, p.DateAdded) AS 'Date Added',
		CONVERT (date, p.DateModified) AS 'Date Modified',
		RV
FROM Person AS p 
LEFT JOIN Title AS t ON p.TitleID = t.TitleID
LEFT JOIN Suffix AS s ON p.SuffixID = s.SuffixID
ORDER BY p.LastName, p.FirstName;
GO

SELECT PersonID
FROM Person
WHERE UserName = 'JayBeeOH';
GO

SELECT	p.PersonID, 
		p.PersonType, 
		p.PersonStatus, 
		t.Title,
		p.FirstName,
		p.MiddleName,
		p.LastName,
		s.Suffix,
		p.UserName,
		p.DateAdded AS 'Date Added',
		p.DateModified AS 'Date Modified',
		RV
FROM Person AS p 
LEFT JOIN Title AS t ON p.TitleID = t.TitleID
LEFT JOIN Suffix AS s ON p.SuffixID = s.SuffixID
WHERE p.UserName = 'DeeBeeOH';
GO

CREATE TABLE Password (
	PersonID	 INT NOT NULL,
	PasswordSalt BINARY(24) NOT NULL,
	PasswordHash BINARY(128) NOT NULL,
	ModifiedDate DATETIME NOT NULL,
CONSTRAINT PK_Password_PersonID PRIMARY KEY (PersonID));
GO

ALTER TABLE Password ADD  CONSTRAINT DF_Password_ModifiedDate  DEFAULT (getdate()) FOR ModifiedDate;
GO

ALTER TABLE Password  WITH CHECK ADD CONSTRAINT FK_Password_Person FOREIGN KEY(PersonID)
REFERENCES Person (PersonID);
GO

----To Reset Person and Password Tables

--USE JLBSampleDB;
--GO

--TRUNCATE TABLE Password;
--GO

--DELETE FROM Person;
--GO

--DBCC CHECKIDENT   
--	(Person, RESEED, 0);
--GO 