-- ������� �������
CREATE TABLE  StudentGrades
(
	Id  INT PRIMARY KEY IDENTITY(1,1),
	NameStudent NVARCHAR (40) NOT NULL,
	Sity NVARCHAR (30) UNIQUE NOT NULL,
	Country NVARCHAR (20) UNIQUE,
	DateOfBirth  DATE,
	Email NVARCHAR (20),
	Phone INT,
	GroupName NVARCHAR (15) UNIQUE,
	CourseNameMin NVARCHAR (20) UNIQUE,
	MaxGrade TINYINT,	
	CourseNameMax NVARCHAR (20) UNIQUE,
	MinGrade TINYINT,	
	AverageGrade TINYINT,
);

INSERT INTO StudentGrades (NameStudent,Sity, Country, DateOfBirth, Email, Phone,	GroupName, CourseNameMax, MaxGrade, CourseNameMin, MinGrade, AverageGrade)
VALUES

('Kraine David', 'Rom','Italy','12/05/2006', 'David@work.com', 567254789,	'Socialization',	'painting', 10,	'mathematics',3,7),
('Lopez Marianna', 'Gwadalachara ','Mexica', '2005/06/25', 'Marianna@work.com', 468264789,	'History',	'history',	9,	'literature', 4,7),
('Noble Dona', 'Kardiff','Britain', '2003/01/10', 'Dona@work.com',	458639745, 'Geografy',	'geografy',	10,'music'	,2,	6),
('Grocia Elizbeth', 'Madrid','Hispania','2009/10/15',	'Elizbeth@work.com', 597856457,	'Programming',	'programming', 9,	'history', 2, 5),
('Sam Topical',	'Berlin','Germany', '2010/04/23', 'Sam@work.com', 478693541, 'Literature',	'socialization', 10, 'geografy' ,3, 6);

SELECT * FROM StudentGrades  -- �� ������

SELECT NameStudent FROM StudentGrades -- ����� ��������

SELECT NameStudent, AverageGrade FROM StudentGrades -- �������� ������� ������ ��������

SELECT NameStudent, Country FROM StudentGrades -- �������� ����� ��������

SELECT NameStudent, Sity FROM StudentGrades -- �������� ���� ��������

SELECT NameStudent, GroupName FROM StudentGrades -- �������� ����� ��������

SELECT NameStudent, CourseNameMin, MinGrade, CourseNameMax, MaxGrade FROM StudentGrades ORDER BY MinGrade DESC -- �������� ��� �� ���� ������

SELECT NameStudent, MinGrade FROM StudentGrades -- �������� ��. ������ ����� �� �������
WHERE MinGrade > 2

DELETE FROM StudentGrades -- ��������� ����� � �������


DROP TABLE StudentGrades -- ��������� �������
