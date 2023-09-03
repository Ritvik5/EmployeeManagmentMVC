CREATE DATABASE EmployeeManagementMVC;

USE EmployeeManagementMVC;

Select * From Employee;
CREATE TABLE Employee(
	EmployeeId INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	ProfileImage VARCHAR(MAX) NOT NULL,
	Gender VARCHAR(10) NOT NULL,
	Department VARCHAR(50) NOT NULL,
	Salary MONEY NOT NULL,
	StartDate DATE NOT NULL,
	Notes VARCHAR(MAX) NOT NULL);

CREATE OR ALTER PROCEDURE spAddEmployee(
	@Name VARCHAR(50),
	@ProfileImage VARCHAR(MAX),
	@Gender CHAR(1),
	@Department VARCHAR(50),
	@Salary MONEY,
	@StartDate DATE,
	@Notes VARCHAR(MAX)
)
AS
BEGIN
	INSERT INTO Employee(Name,ProfileImage,Gender,Department,Salary,StartDate,Notes)
	VALUES(@Name,@ProfileImage,@Gender,@Department,@Salary,@StartDate,@Notes)

	SELECT SCOPE_IDENTITY() AS EmployeeId;
END

CREATE OR ALTER PROCEDURE spGetAllEmployees
AS
BEGIN
	SELECT * FROM Employee
END

CREATE OR ALTER PROCEDURE spUpdateEmployee(
	@EmployeeId INT,
	@Name VARCHAR(50),
	@ProfileImage VARCHAR(MAX),
	@Gender CHAR(1),
	@Department VARCHAR(50),
	@Salary MONEY,
	@StartDate DATE,
	@Notes VARCHAR(MAX)
)
AS
BEGIN
	UPDATE Employee
	SET 
	Name = @Name,
	ProfileImage = @ProfileImage,
	Gender = @Gender,
	Department = @Department,
	Salary = @Salary,
	StartDate = @StartDate,
	Notes = @Notes
END