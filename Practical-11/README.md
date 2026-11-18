# Practical 11: Smart Campus Service Portal

## Aim
To design and develop a full-stack web application for the **Smart Campus Service Portal** that integrates **ASP.NET MVC**, **ADO.NET (SQL Server)**, and **RESTful Web API**.

---

## Features
- **MVC Architecture:** Separation of Concerns with Models, Views, and Controllers.
- **Database Connectivity:** Direct ADO.NET connection to SQL Server LocalDB (`SmartCampusDB`).
- **CRUD Operations:** List all tickets, submit a new service request, update ticket status, and delete tickets.
- **RESTful API:** Exposes endpoints for mobile/third-party clients (`GET`, `POST`, `PUT`).
- **Interactive UI:** Responsive dashboard with ticket statistics, priority/status badges, and validation.

---

## Database Design (`SmartCampusDB`)
The database setup script is available in [SetupDatabase.sql](./SetupDatabase.sql).

### Table: `ServiceRequests`
| Column Name | Data Type | Constraints | Description |
| :--- | :--- | :--- | :--- |
| `RequestId` | `INT` | `PRIMARY KEY IDENTITY(1,1)` | Unique Request ID |
| `StudentName` | `NVARCHAR(100)` | `NOT NULL` | Name of the student |
| `Department` | `NVARCHAR(100)` | `NOT NULL` | Department / Branch |
| `ServiceType` | `NVARCHAR(100)` | `NOT NULL` | IT Support, Library, Maintenance, Transport |
| `Description` | `NVARCHAR(MAX)` | `NOT NULL` | Problem description |
| `Priority` | `NVARCHAR(50)` | `NOT NULL` | Low / Medium / High |
| `Status` | `NVARCHAR(50)` | `DEFAULT 'Pending'` | Pending / In Progress / Completed |
| `RequestDate` | `DATETIME` | `DEFAULT GETDATE()` | Date & time of request submission |

---

## Available Project Implementations

### 1. ASP.NET MVC & Web API (.NET Framework 4.8)
- Solution File: `SmartCampusPortal.sln`
- Run via PowerShell: `.\run.ps1`

### 2. ASP.NET Core MVC & REST API (.NET 10)
- Project Folder: `StudentCampusPortal/`
- Solution File: `StudentCampusPortal/StudentCampusPortal.slnx`
- Run command:
  ```bash
  cd StudentCampusPortal
  dotnet run
  ```

---

## API Endpoints
| HTTP Method | Route | Description |
| :--- | :--- | :--- |
| `GET` | `/api/ServiceApi` | Retrieve all campus service requests in JSON format |
| `GET` | `/api/ServiceApi/{id}` | Retrieve request details by ID |
| `POST` | `/api/ServiceApi` | Create a new service request |
| `PUT` | `/api/ServiceApi/UpdateStatus/{id}` | Update the status of an existing request |

---

## Author
**Tejas Andodariya**  
B.Tech Computer Engineering  
Marwadi University
