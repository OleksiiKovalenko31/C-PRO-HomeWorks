SELECT * FROM [dbo].Employees -- ok
SELECT * FROM [dbo].[Services] -- ok
SELECT * FROM [dbo].[Customers] -- ok
SELECT * FROM [dbo].[Orders] --ok
SELECT * FROM [dbo].[Days] -- ok
SELECT * FROM [dbo].[FeedBack] --ok
SELECT * FROM [dbo].[barberAvailableService] --ok
SELECT * FROM [dbo].[BarberAvailableDays] --ok


INSERT INTO [dbo].[Employees]([Name],[Surname],[Sex],[Phone],[Email],[DateBirth],[DateStartWork],[StatusWork]) --ok
VALUES
	('Piotr',	'Mazurski',	'm',	54664654,	'efefe@fefef.com',	'1996-09-29',	'2023-03-03',	'senior'),
	('Sasha',	'Druka',	'w',	54845356,	'dkfbdj@lfnjlfn.com',	'1998-07-20',	'2024-05-01',	'junior'),
	('Marcus',	'Gringo',	'm',	47852163,	'fdfd@gbdas.com',	'1997-11-15',	'2024-10-01',	'senior'),
	('Taen',	'Gared',	'm',	47852365,	'ssccs@ccvcv.com',	'1985-04-02',	'2020-08-03',	'chef')


INSERT INTO [dbo].[Customers](CustomerID,Name,Surname,Phone,Email) --ok
VALUES
	('Patrick',	'Frako',	457863981,	'Patrick@jenflj.com'),
	('David',	'Mariush',	478521651,	'David@jiihfi.com'),
	('Mark',	'Drag',	    875341851,	'Mark@gmail.com')

INSERT INTO [dbo].[Days]([DayID],[NameDay]) -- ok
VALUES
	(1,	'Monday'),
	(2,	'Thusday'),
	(3,	'Wensday'),
	(4,	'Thursday'),
	(5,	'Friday'),
	(6,	'Saturday'),
	(7,	'Sunday')

INSERT INTO [dbo].[BarberAvailableDays]([Employees].BarberID,[Days].DayID) --ok
VALUES
(1,1),
(1,4),
(1,5),
(2,1),
(2,3),
(2,4),
(3,2),
(3,3),
(3,5),
(3,6)


INSERT INTO [dbo].[barberAvailableService]([Employees].BarberID,[Services].ServiceID) --ok
VALUES
	(1,	'b1'),
	(1,	'b2'),
	(1,	'r1'),
	(2,	'b2'),
	(2,	'r1'),
	(3,	'b1'),
	(3,	'r1')




insert into [dbo].[Orders] ([dbo].[Customers].[CustomerID],[dbo].[Services].[serviceID],[dbo].[Employees].[BarberID],[DayID],[Date],[Status]) --ok
values
	(3,	'b1',	4,	3,  '2025-08-20',   'active'),
	(2, 'b1',	2,	4,	'2025-08-13',	'archive'),
	(2,	'r1',	3,	6,	'2025-08-15',	'archive'),
	(1,	'b2',	1,	5,	'2025-08-14',	'archive')

INSERT INTO [dbo].[FeedBack]([Orders].[OrderID],[Review],[Rating]) 
VALUES
(2,	'good',	4),
(1,	'very good',	5),
(3,	'very good',	5)

--ALTER TABLE [dbo].[FeedBack]
--DROP COLUMN [BarberID]

--ALTER TABLE [dbo].[FeedBack]
--DROP COLUMN [CustomerID]



--DELETE  FROM [Customers]
--DBCC CHECKIDENT ('[Customers]', RESEED, 0);