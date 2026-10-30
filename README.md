
# DVLD — Driving License Management System

## 1. Project Overview

The Driving License Management System (DVLD) is a desktop application designed to manage driving-license services, applicants, system users, driving tests, and issued licenses.

The system centralizes applicant information and supports the complete licensing process, from submitting an application and scheduling tests to issuing, renewing, and replacing driving licenses.

It aims to maintain data consistency, enforce licensing rules, and reduce data duplication through a structured database and a layered software architecture.

## 2. Key Features

### People Management
- Register, view, search, update, and delete people.
- Search for individuals using their national number.
- Prevent duplicate person records.
- Maintain personal information and photographs.

### User Management
- Create system users linked to existing people.
- Manage user accounts and credentials.
- Activate, deactivate, and manage user permissions.

### Application Management
- Create and manage driving-license service applications.
- Search applications by application number or national number.
- Track application status and associated fees.
- Prevent duplicate unfinished applications of the same service type.

### Driving-License Management
- Manage predefined driving-license classes.
- Configure minimum age, validity period, and license fees.
- Validate applicant eligibility before processing applications.
- Issue and manage driving licenses.
- Support multiple license classes for the same person.

### Test Management
- Schedule eyesight, theoretical, and practical driving tests.
- Record test results and scores.
- Manage test appointments and retests.
- Enforce the required test sequence.

### Driving-License Services
- First-time driving-license issuance.
- Driving-license renewal.
- Replacement of lost or damaged licenses.
- Release of impounded licenses.
- International driving-license issuance.

### Additional Features
- License impoundment and release management.
- System configuration for test fees and license classes.
- Audit trail for recording system operations and their associated users.

## 3. Architecture

The system follows a **three-tier architecture** that separates presentation, business logic, and data access responsibilities.

This architectural approach promotes separation of concerns, maintainability, and easier testing by assigning each layer a clearly defined responsibility.

The system is organized into the following layers:

- **Presentation Layer:** Handles user interactions and displays system information.
- **Business Logic Layer (BLL):** Implements business rules, validations, and application workflows.
- **Data Access Layer (DAL):** Handles database operations and communication with SQL Server.

For a detailed explanation of the architecture, project dependencies, data flow, and database design, see the [Architecture Documentation](docs/Architecture.md).

## 4. Technologies Used

- **Programming Language:** C#
- **Framework:** .NET
- **Database Management System:** Microsoft SQL Server
- **Data Access Technology:** ADO.NET
- **Architecture:** Three-Tier Architecture
- **Development Environment:** Visual Studio

## 5. Database

The system uses Microsoft SQL Server to store and manage its data.

The database maintains relationships between people, system users, applications, driving tests, and issued licenses.

Key database design considerations include:

- Referential integrity between related entities.
- Prevention of duplicate national numbers.
- Reusability of person records across the system.
- Support for multiple applications and licenses per person.
- Consistent tracking of application and licensing records.

For the database design and related documentation, see [Architecture Documentation](docs/Architecture.md).

## 6. Documentation

[Architecture](docs/Architecture.md) Architectural design, layer responsibilities, project dependencies, data flow, and database design.

## 7. Project Structure

The solution is organized into separate projects according to their architectural responsibilities.

```text
DVLD/
│
├── DVLD_DataAccess/
│   └── Data access operations
│
├── Business/
│   └── Business logic and validation
│
├── Presentation/
│   └── User interface
│
├── docs/
│   ├── Requirements.md
│   └── Architecture.md
│
└── README.md
```

Each project is responsible for a specific part of the system, maintaining a clear separation between the user interface, business logic, and database operations.

## 8. Future Improvements

Potential improvements include:

- Enhanced reporting and statistics.
- Improved application performance.
- Additional security and auditing mechanisms.
- Expanded automated testing.
- Integration with external licensing services.

---

**Project:** Driving License Management System (DVLD)  
**Architecture:** Three-Tier Architecture  
**Database:** Microsoft SQL Server  
**Language:** C#
