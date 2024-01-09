-- tạo cơ sở dữ liệu
CREATE DATABASE StudentDB;
GO


-- sử dụng cơ sở dữ liệu
USE StudentDB;
GO


-- tạo bảng Student
CREATE TABLE Student(
	[Id] [int] IDENTITY(100, 1) PRIMARY KEY,
	[Name] [varchar](100) NULL,
	[Email] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL
);
GO


-- tạo bảng Course
CREATE TABLE Course(
	[Id] [int] IDENTITY(1, 1) PRIMARY KEY,
	[Name] [varchar](100) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL
);
GO


-- thêm dữ liệu vào bảng Student
INSERT INTO Student VALUES ('Anurag','Anurag@dotnettutorial.net','1234567890');
INSERT INTO Student VALUES ('Priyanka','Priyanka@dotnettutorial.net','2233445566');
INSERT INTO Student VALUES ('Preety','Preety@dotnettutorial.net','6655443322');
INSERT INTO Student VALUES ('Sambit','Sambit@dotnettutorial.net','9876543210');


-- thêm dữ liệu vào bảng Course
INSERT INTO Course VALUES ('Math','2004/01/31','2005/12/25');
INSERT INTO Course VALUES ('Literature','2020/02/05','2020/08/15');
INSERT INTO Course VALUES ('English','1991/10/30','2023/09/12');
INSERT INTO Course VALUES ('Chemistry','2014/03/03','2016/07/18');
INSERT INTO Course VALUES ('Physics','2019/06/01','2025/01/01');


-- tạo stored procedure
CREATE PROCEDURE GetAllStudent
AS
BEGIN
     SELECT *
     FROM Student;

	 SELECT *
     FROM Course;
END;


-- thực thi stored procedure
EXECUTE GetAllStudent;


-- xóa stored procedure
-- DROP PROCEDURE GetAllStudent;


-- tạo stored procedure có truyền tham số
CREATE PROCEDURE GetStudentById
(
	@Id int
)
AS
BEGIN
	SELECT *
	FROM Student
	WHERE Id = @Id;



	-- khai báo biến
	DECLARE @queryStr nvarchar(200);

	-- câu lệnh gán, dùng SELECT để gán
	SELECT @queryStr = N'
		SELECT *
		FROM Student
		WHERE Id = ' + CAST(@Id AS nvarchar(50));

	-- thực thi chuỗi được lưu trong biến @queryStr
	EXECUTE(@queryStr);
END;


-- xóa stored procedure
-- DROP PROCEDURE GetStudentById;