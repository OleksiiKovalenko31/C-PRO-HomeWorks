CREATE TABLE [dbo].[Departments]
(
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	[Bilding] INT CHECK (Bilding >= 1 AND Bilding <= 5) NOT NULL,
	[Financing] DECIMAL(8,2) DEFAULT 0 CHECK ( Financing !<0) NOT NULL,
	
);

CREATE TABLE [dbo].[Diseases]
(
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (100) UNIQUE NOT NULL ,
	[Severity] INT CHECK (Severity < 1) DEFAULT 1 NOT NULL,

);

CREATE TABLE [dbo].[Doctors]
(
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR(MAX) NOT NULL,
	[Surname] NVARCHAR(MAX) NOT NULL,
	[Phone] CHAR(10) NOT NULL ,
	[Salary] DECIMAL (6,2) CHECK (Salary !=0 ) NOT NULL,
);

CREATE TABLE  [dbo].[Examinations]
(
	[Name] NVARCHAR(100) UNIQUE NOT NULL,
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	[DayOfWeek] INT  CHECK ([DayOfWeek] >= 1 AND [DayOfWeek] <= 7 )  NOT NULL,
	[StartTime] TIME CHECK ([StartTime] >= '08:00' AND [StartTime] <= '18:00') DEFAULT('08:00') NOT NULL,
	[EndTime] TIME   NOT NULL,
	
	CHECK ([EndTime] > [StartTime])
);
	


CREATE TABLE [dbo].[Wards]
(
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	[Building] INT CHECK ([Building] >= 1 AND [Building] <= 5) NOT NULL,
	[Floor] INT CHECK ([Floor] >= 1) NOT NULL,
	[Name] NVARCHAR(20) UNIQUE NOT NULL 
);


SELECT 
	[Doctors].[Id],[Doctors].[Name],[Surname],[Bilding],[Floor],
	[Diseases].[Name], [Diseases].Severity

FROM [Hospital].[dbo].[Doctors] 
RIGHT JOIN [Hospital].[dbo].[Departments] ON Doctors.Id = Departments.Id 
INNER JOIN [Hospital].[dbo].[Wards] ON Doctors.Id = Wards.Id 
RIGHT JOIN [Hospital].[dbo].[Diseases] ON Doctors.Id = Diseases.Id
WHERE Doctors.Id >= 15 AND Doctors.Id <= 50
-- 1
SELECT * FROM [Hospital].[dbo].[Wards]
-- 2
SELECT [Name], [Surname], [Phone] FROM [Hospital].[dbo].[Doctors] AS [List doctors]
-- 3
SELECT DISTINCT  [Floor] FROM [Hospital].[dbo].[Wards] AS [Unique name Floor]
-- 4
SELECT [Name] AS [Name of Disease], [Severity] AS [Severity of Disease] FROM [Hospital].[dbo].[Diseases] 
-- 6
SELECT [Name],[Financing] FROM [Hospital].[dbo].[Departments]
INNER JOIN [Hospital].[dbo].[Wards] ON [Departments].[Id] = [Wards].[Id]
WHERE [Bilding]=5 AND [Financing] < 20
ORDER BY [Financing]

--7
SELECT [Name],[Financing] FROM [Hospital].[dbo].[Departments]
INNER JOIN [Hospital].[dbo].[Wards] ON [Departments].[Id] = [Wards].[Id]
WHERE [Bilding]=3 AND [Financing] > 12 AND  [Financing] < 15
ORDER BY [Financing]
 --8
SELECT [Name]FROM [Hospital].[dbo].[Wards]
WHERE [Building] = 4 OR [Building] = 5 AND [Floor] = 1
--9
SELECT [Name],[Financing],[Bilding] FROM [Hospital].[dbo].[Examinations]
INNER JOIN [Hospital].[dbo].[Departments] ON [Departments].[Id] = [Examinations].[Id]
WHERE [Bilding] = 3 OR [Bilding] = 5 AND [Financing] > 11 AND [Financing] < 25
ORDER BY [Bilding],[Financing]

--10
SELECT [Surname], [Salary] FROM [Hospital].[dbo].[Doctors]
WHERE [Salary] > 1500
ORDER BY [Surname]

--12
SELECT DISTINCT [Name] FROM [Hospital].[dbo].[Examinations]
WHERE ([DayOfWeek] >= 1 AND [DayOfWeek] <= 3) AND ([StartTime] >= '09:00:00.0000000' AND [StartTime] <= '11:59:00.0000000')
ORDER BY [Name]

--13
SELECT DISTINCT [Name],[Building] FROM [Hospital].[dbo].[Wards]
WHERE [Building] = 1 OR [Building]= 3 OR [Building]=8 OR [Building] = 10

--14
SELECT [Name], [Severity] FROM [Hospital].[dbo].[Diseases]
WHERE [Severity] != 1 AND [Severity] != 2
ORDER BY [Severity]

--15
SELECT [Name] FROM [Hospital].[dbo].[Wards]
WHERE [Building] !=1 AND [Building] != 3

--16
SELECT [Name] FROM [Hospital].[dbo].[Wards]
WHERE [Building] = 1 OR [Building] = 3

--17
SELECT [Name],[Surname] FROM [Hospital].[dbo].[Doctors]
WHERE [Surname] LIKE 'a%'


--DELETE  FROM [Examinations]
--DBCC CHECKIDENT ('[Examinations]', RESEED, 0);



--DROP TABLE [dbo].[Examinations]