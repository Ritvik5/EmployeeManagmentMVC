CREATE DATABASE EmployeeManagementMVC;

USE EmployeeManagementMVC;

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
	@Gender VARCHAR(10),
	@Department VARCHAR(50),
	@Salary MONEY,
	@StartDate DATE,
	@Notes VARCHAR(MAX)
)
AS
BEGIN
	INSERT INTO Employee(Name,ProfileImage,Gender,Department,Salary,StartDate,Notes)
	VALUES(@Name,@ProfileImage,@Gender,@Department,@Salary,@StartDate,@Notes)
END

CREATE PROCEDURE spGetAllEmployees
AS
BEGIN
	SELECT * FROM Employee
END