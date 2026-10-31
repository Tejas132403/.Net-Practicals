-- =============================================
-- SQL Script for Practical: PlacementDashboard
-- Database: PlacementDB  (localdb)\MSSQLLocalDB
-- =============================================

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'PlacementDB')
BEGIN
    CREATE DATABASE PlacementDB;
END
GO

USE PlacementDB;
GO

IF OBJECT_ID('Placements', 'U') IS NULL
BEGIN
    CREATE TABLE Placements (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        StudentName NVARCHAR(100) NOT NULL,
        CompanyName NVARCHAR(100) NOT NULL,
        JobRole NVARCHAR(100) NOT NULL,
        Package NVARCHAR(50) NOT NULL
    );
END
ELSE
BEGIN
    TRUNCATE TABLE Placements;
END
GO

INSERT INTO Placements (StudentName, CompanyName, JobRole, Package) VALUES
('Tejas', 'Google', 'Software Developer', '50 LPA'),
('Dhyey', 'Infosys', 'System Engineer', '5.0 LPA'),
('Het', 'Tcs', 'Web Developer', '4.0 LPA'),
('Yash', 'Accenture', 'Software Engineer', '6.0 LPA');
GO

SELECT * FROM Placements;
GO
