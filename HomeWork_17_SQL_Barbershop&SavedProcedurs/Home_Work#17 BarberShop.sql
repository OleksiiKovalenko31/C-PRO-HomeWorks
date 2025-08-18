CREATE TABLE [dbo].[Employees]
(
	[BarberID] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (20) NOT NULL,
	[Surname] NVARCHAR (20) NOT NULL,
	[Sex] CHAR (1) NOT NULL,
	[Phone] INT NOT NULL,
	[Email] NVARCHAR (100) NOT NULL,
	[DateBirth] DATE NOT NULL,
	[DateStartWork] DATE NOT NULL,
	[StatusWork] NVARCHAR (6) NOT NULL,	
);

CREATE TABLE [dbo].[Services]
(
	[Name] NVARCHAR (80) NOT NULL,
	[Price] DECIMAL (5,2) NOT NULL,
	[Time] TIME NOT NULL,
	[serviceID] NVARCHAR (2) UNIQUE NOT NULL
);



CREATE TABLE [dbo].[Customers]
(
	[CustomerID] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (20) NOT NULL,
	[Surname] NVARCHAR (20) NOT NULL,
	[Phone] INT UNIQUE NOT NULL,
	[Email] NVARCHAR (80) NOT NULL
);

CREATE TABLE [dbo].[Orders] 
(
	[OrderID] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	[CustomerID] INT NOT NULL,
	[ServiceID] NVARCHAR (2) NOT NULL,
	[BarberID] INT NOT NULL,
	[Date] DATE NOT NULL,
	[DayID] INT NOT NULL,
	[Status] NVARCHAR (10) NOT NULL, 

	FOREIGN KEY(CustomerID) REFERENCES [Customers](CustomerID), 
	FOREIGN KEY(BarberID) REFERENCES [Employees](BarberID),
	FOREIGN KEY(ServiceID) REFERENCES [Services](ServiceID),


);

CREATE TABLE [dbo].[FeedBack]
(
	[FeedbackID] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,

	[BarberID] INT NOT NULL,
	[CustomerID] INT NOT NULL,
	[Review] NVARCHAR (MAX) NOT NULL,
	[Rating] INT CHECK (Rating >=0 AND Rating < 10),

	FOREIGN KEY(FeedbackID) REFERENCES [Orders](OrderID)
);

CREATE TABLE [dbo].[Days]
(
	[DayID] INT CHECK (DayID >= 1  AND DayID <= 7) PRIMARY KEY,
	[NameDay] NVARCHAR (8) NOT NULL
);

CREATE TABLE [dbo].[BarberAvailableDays]
(
	[BarberID] INT NOT NULL,
	[DayID] INT NOT NULL

	FOREIGN KEY (BarberID) REFERENCES [Employees](BarberID),
	FOREIGN KEY (DayID) REFERENCES [Days](DayID)
);

CREATE TABLE [dbo].[barberAvailableService]
(
	[BarberID] INT NOT NULL,
	[ServiceID] NVARCHAR (2)

	FOREIGN KEY (BarberID) REFERENCES [Employees](BarberID),
	FOREIGN KEY (ServiceID) REFERENCES [Services](ServiceID)
);
-- 1 Повернути ПІБ барберів
SELECT [Name], [Surname], [StatusWork] FROM [dbo].[Employees]

-- 2 Повернути інформацію про всіх синьйор-барберів. 
SELECT [Name],[Surname],[StatusWork] FROM [dbo].[Employees]
WHERE [StatusWork] = 'senior'

--3 Повернути інформацію про всіх барберів, які можуть надати послугу традиційного гоління бороди. 
SELECT  [Name],[Surname],[StatusWork] FROM [dbo].[Employees]
RIGHT JOIN [dbo].[barberAvailableService] ON [dbo].[Employees].BarberID = [dbo].[barberAvailableService].[BarberID]
WHERE [dbo].[barberAvailableService].[ServiceID] = 'b2'

--4 Повернути інформацію про всіх барберів, які можуть надати конкретну послугу. Інформація про потрібну послугу надається як параметр.
DECLARE  @serviceParametr NVARCHAR (2);
SET @serviceParametr  = 'B2'

SELECT  [Name],[Surname],[StatusWork] FROM [dbo].[Employees]
RIGHT JOIN [dbo].[barberAvailableService] ON [dbo].[Employees].BarberID = [dbo].[barberAvailableService].[BarberID]
WHERE [dbo].[barberAvailableService].[ServiceID] = @serviceParametr

--5 Повернути інформацію про всіх барберів, які працюють понад зазначену кількість років. Кількість років передається як параметр. 
DECLARE  @DatediffParametr INT;
SET @DatediffParametr  = 2

SELECT  [Name],[Surname],[StatusWork] FROM [dbo].[Employees]
WHERE DATEDIFF (YEAR, [dbo].[Employees].DateStartWork, GETDATE()) > @DatediffParametr

--6 Повернути кількість синьйор-барберів та кількість джуніор-барберів. 

SELECT
  COUNT(CASE WHEN [StatusWork] = 'Senior' THEN 1 END) AS senior_count,
  COUNT(CASE WHEN [StatusWork] = 'Junior' THEN 1 END) AS junior_count
FROM Employees;

--SELECT COUNT(*) AS сount
--FROM Employees
--WHERE [StatusWork] IN ('Senior','junior')
--GROUP BY [StatusWork]

--7 Повернути інформацію про постійних клієнтів. Критерій постійного клієнта: був у салоні задану кількість разів. Кількість передається як параметр. 
DECLARE @min_visits INT
SET @min_visits = 2

SELECT [dbo].[Orders].[CustomerID], [dbo].[Customers].[Name],[dbo].[Customers].[Surname] FROM [dbo].[Orders]
RIGHT JOIN [dbo].[Customers] ON  [dbo].[Orders].CustomerID = [dbo].[Customers].CustomerID
GROUP BY [dbo].[Orders].CustomerID,[dbo].[Customers].[Name],[dbo].[Customers].[Surname]
HAVING COUNT (*) >= @min_visits

--8 Заборонити можливість видалення інформації про чиф-барбер, якщо не додано другий чиф-барбер. 
GO
CREATE TRIGGER trg_PreventDeleteLastChefBarber
ON Employees
AFTER DELETE
AS
BEGIN
    -- Перевірка, чи видаляється chef-barber
    IF EXISTS (SELECT 1 FROM DELETED WHERE [StatusWork] = 'chef-barber')
    BEGIN
        -- Кількість chef-barber, що залишаються в таблиці після видалення
        DECLARE @RemainingChefBarbers INT
        SELECT @RemainingChefBarbers = COUNT(*)
        FROM Employees
        WHERE [StatusWork] = 'chef-barber'
        AND [BarberID] NOT IN (SELECT [BarberID] FROM DELETED)

        -- Якщо не залишиться хоча б один chef-barber, скасувати видалення
        IF @RemainingChefBarbers < 1
        BEGIN
            RAISERROR ('Неможливо видалити останнього chef-barber. Додайте іншого перед видаленням.', 16, 1)
            ROLLBACK TRANSACTION
        END
    END
END
GO

--9 Заборонити додавати барберів молодше 21 року
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT CHK_Employee_Age
CHECK (DATEDIFF(YEAR, [DateBirth], GETDATE()) - 
       CASE 
           WHEN DATEADD(YEAR, DATEDIFF(YEAR, [DateBirth], GETDATE()), [DateBirth]) > GETDATE() THEN 1 
           ELSE 0 
       END >= 21);

--Функція користувача повертає вітання в стилі «Hello, ІМ'Я!» Де ІМ'Я передається як параметр. Наприклад, якщо передали Nick, то буде Hello, Nick! 
DECLARE @name NVARCHAR(20) = 'Miriam'
PRINT 'Hello ' + @name

--Функція користувача повертає інформацію про поточну кількість хвилин; 
PRINT 'Now minute ' + CAST(DATEPART(minute, GETDATE()) AS VARCHAR);

--Функція користувача повертає інформацію про поточний рік; 
GO
CREATE FUNCTION dbo.IsNowYear()
RETURNS NVARCHAR(20)
AS 
BEGIN
	DECLARE @nowDate INT = CAST(DATEPART(year, GETDATE()) AS VARCHAR)
	RETURN @nowDate;
END
GO

PRINT 'Now year ' + dbo.IsNowYear();

-- Функція користувача повертає інформацію про те: парний або непарний рік; 
GO
CREATE FUNCTION dbo.IsEvenOrOddYear (@inputDate DATE)
RETURNS NVARCHAR(20)
AS
BEGIN
    DECLARE @year INT = YEAR(@inputDate)
    DECLARE @result NVARCHAR(20)

    IF @year % 2 = 0
        SET @result = 'Парний рік'
    ELSE
        SET @result = 'Непарний рік'

    RETURN @result
END;
GO

PRINT dbo.IsEvenOrOddYear(GETDATE()) ;
SELECT dbo.IsEvenOrOddYear('2024-08-18') AS Year;

--Функція користувача приймає як параметри п'ять чисел. Повертає суму мінімального та максимального значення з переданих п'яти параметрів;
GO
CREATE FUNCTION dbo.MinMaxSum
(
    @a INT,
    @b INT,
    @c INT,
    @d INT,
    @e INT
)
RETURNS INT
AS
BEGIN
    DECLARE @min INT;
    DECLARE @max INT;

  
    SET @min = (
        SELECT MIN(val)
        FROM (VALUES (@a), (@b), (@c), (@d), (@e)) AS V(val)
    );

 
    SET @max = (
        SELECT MAX(val)
        FROM (VALUES (@a), (@b), (@c), (@d), (@e)) AS V(val)
    );

    RETURN @min + @max;
END
GO

SELECT dbo.MinMaxSum(3, 8, 1, 6, 4) AS ResultMinMax;
PRINT ' ResultMinMax = ' + CAST(dbo.MinMaxSum(-5, 0, 15, 7, 3) AS NVARCHAR);


-- Збережена процедура виводить «Hello, world!»; 
GO
CREATE PROCEDURE dbo.SayHello
AS
BEGIN
    SELECT 'Hello, world!' AS Message;
END
GO

-- Збережена процедура повертає інформацію про поточний час; 
GO
CREATE PROCEDURE dbo.GetCurrentTimeDetails
AS
BEGIN
    SELECT
        GETDATE() AS [FullDateTime],
        CAST(GETDATE() AS DATE) AS [OnlyDate],
        CAST(GETDATE() AS TIME) AS [OnlyTime],
        DATENAME(WEEKDAY, GETDATE()) AS [DayOfWeek],
        DATENAME(MONTH, GETDATE()) AS [MonthName],
        DATEPART(HOUR, GETDATE()) AS [Hour],
        DATEPART(MINUTE, GETDATE()) AS [Minute],
        DATEPART(SECOND, GETDATE()) AS [Second];
END
GO
EXEC dbo.GetCurrentTimeDetails;
-- Збережена процедура приймає число та символ. 
-- В результаті роботи збереженої процедури відображається  лінія довжиною, що дорівнює числу. Лінія побудована із символу, вказаного у другому параметрі. 
-- Наприклад, якщо було передано 5 та #, ми отримаємо лінію такого виду #####; 
GO
CREATE PROCEDURE dbo.PrintLine
    @Length INT,
    @Char NCHAR(1)
AS
BEGIN
  
    IF @Length IS NULL OR @Length <= 0
    BEGIN
        PRINT 'Length must be a positive integer.';
        RETURN;
    END

    IF @Char IS NULL OR LEN(@Char) = 0
    BEGIN
        PRINT 'Character must be provided.';
        RETURN;
    END

   
    DECLARE @Line NVARCHAR(MAX);
    SET @Line = REPLICATE(@Char, @Length);

    
    PRINT @Line;
END
GO

EXEC dbo.PrintLine @Length = 10, @Char = '*';

--  Збережена процедура приймає як параметр число і повертає його факторіал. 
--  Формула розрахунку факторіалу: n! = 1 * 2 * ... n. Наприклад, 3! = 1 * 2 * 3 = 6; 
GO
CREATE PROCEDURE dbo.CalculateFactorial
    @n INT
AS
BEGIN
   
    IF @n IS NULL OR @n < 0
    BEGIN
        PRINT 'Число повинно бути цілим і невід’ємним (0 або більше).';
        RETURN;
    END

    DECLARE @result BIGINT = 1;
    DECLARE @i INT = 1;

    WHILE @i <= @n
    BEGIN
        SET @result = @result * @i;
        SET @i = @i + 1;
    END

    SELECT @result AS Factorial;
END
GO
EXEC dbo.CalculateFactorial @n = 5;

--Збережена процедура приймає два числові параметри. Перший параметр – це число. 
--Другий параметр – це ступінь. Процедура повертає число, зведене до ступеня. 
--Наприклад, якщо параметри дорівнюють 2 і 3, тоді повернеться 2 у третьому ступені, тобто 8.
GO
CREATE PROCEDURE dbo.PowerNumber
    @base FLOAT,
    @exponent FLOAT
AS
BEGIN
 
    DECLARE @result FLOAT;
    SET @result = POWER(@base, @exponent);

 
    SELECT @result AS Result;
END
GO

EXEC dbo.PowerNumber @base = 9, @exponent = 0.5;