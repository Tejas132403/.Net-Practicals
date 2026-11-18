-- ====================================================================
-- Practical 11: Smart Campus Service Portal
-- Database Setup Script: SmartCampusDB
-- ====================================================================

-- 1. Create Database if it does not exist
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'SmartCampusDB')
BEGIN
    CREATE DATABASE SmartCampusDB;
    PRINT 'Database SmartCampusDB created successfully.';
END
ELSE
BEGIN
    PRINT 'Database SmartCampusDB already exists.';
END
GO

USE SmartCampusDB;
GO

-- 2. Create ServiceRequests Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ServiceRequests')
BEGIN
    CREATE TABLE ServiceRequests (
        RequestId INT IDENTITY(1,1) PRIMARY KEY,
        StudentName NVARCHAR(100) NOT NULL,
        Department NVARCHAR(100) NOT NULL,
        ServiceType NVARCHAR(100) NOT NULL,
        Description NVARCHAR(MAX) NOT NULL,
        Priority NVARCHAR(50) NOT NULL,
        Status NVARCHAR(50) DEFAULT 'Pending',
        RequestDate DATETIME DEFAULT GETDATE()
    );
    PRINT 'Table ServiceRequests created successfully.';

    -- 3. Insert Initial Sample Records
    INSERT INTO ServiceRequests (StudentName, Department, ServiceType, Description, Priority, Status, RequestDate)
    VALUES 
    (N'Tejas Andodariya', N'Computer Engineering', N'IT Support', N'Wi-Fi connection issue in Lab 3', N'High', N'In Progress', GETDATE()),
    (N'Rahul Sharma', N'Information Technology', N'Library', N'Need access to IEEE digital library', N'Medium', N'Pending', GETDATE()),
    (N'Priya Patel', N'Civil Engineering', N'Maintenance', N'Projector not working in Room 204', N'Low', N'Completed', GETDATE());

    PRINT 'Sample data inserted successfully.';
END
ELSE
BEGIN
    PRINT 'Table ServiceRequests already exists.';
END
GO

-- 4. Verify Records
SELECT * FROM ServiceRequests;
GO
