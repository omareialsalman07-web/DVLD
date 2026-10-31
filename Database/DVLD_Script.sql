/* =====================================================================
   DVLD - Full database script (SQL Server)
   Safe to run multiple times:
     - the database is created only if it does not exist
     - every table is created only if it does not exist
     - every lookup table is seeded only if it is empty
   Nothing is ever dropped or deleted.
   ===================================================================== */

USE [master];
GO

IF DB_ID(N'DVLD') IS NULL
BEGIN
    CREATE DATABASE [DVLD];
END
GO

USE [DVLD];
GO

/* =====================================================================
   1) TABLES  (ordered so every foreign key target already exists)
   ===================================================================== */

/* ---------- Countries ---------- */
IF OBJECT_ID(N'dbo.Countries', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Countries (
        CountryID   INT IDENTITY(1,1) NOT NULL,
        CountryName NVARCHAR(50)      NOT NULL,
        CONSTRAINT PK_Countries PRIMARY KEY CLUSTERED (CountryID)
    );
END
GO

/* ---------- People ---------- */
IF OBJECT_ID(N'dbo.People', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.People (
        PersonID             INT IDENTITY(1,1) NOT NULL,
        NationalNo           NVARCHAR(20)      NOT NULL,
        FirstName            NVARCHAR(20)      NOT NULL,
        SecondName           NVARCHAR(20)      NOT NULL,
        ThirdName            NVARCHAR(20)      NULL,
        LastName             NVARCHAR(20)      NOT NULL,
        DateOfBirth          DATETIME          NOT NULL,
        Gendor               TINYINT           NOT NULL
                             CONSTRAINT DF_People_Gendor DEFAULT (0),   -- 0 Male, 1 Female
        [Address]            NVARCHAR(500)     NOT NULL,
        Phone                NVARCHAR(20)      NOT NULL,
        Email                NVARCHAR(50)      NULL,
        NationalityCountryID INT               NOT NULL,
        ImagePath            NVARCHAR(250)     NULL,
        CONSTRAINT PK_People PRIMARY KEY CLUSTERED (PersonID),
        CONSTRAINT UQ_People_NationalNo UNIQUE (NationalNo),
        CONSTRAINT FK_People_Countries
            FOREIGN KEY (NationalityCountryID) REFERENCES dbo.Countries(CountryID)
    );
END
GO

/* Column description on People.Gendor (added only once) */
IF NOT EXISTS (
    SELECT 1
    FROM sys.extended_properties ep
    WHERE ep.name = N'MS_Description'
      AND ep.major_id = OBJECT_ID(N'dbo.People')
      AND ep.minor_id = COLUMNPROPERTY(OBJECT_ID(N'dbo.People'), N'Gendor', 'ColumnId')
)
BEGIN
    EXEC sys.sp_addextendedproperty
        @name = N'MS_Description', @value = N'0 Male , 1 Female',
        @level0type = N'SCHEMA', @level0name = N'dbo',
        @level1type = N'TABLE',  @level1name = N'People',
        @level2type = N'COLUMN', @level2name = N'Gendor';
END
GO

/* ---------- Users ---------- */
IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users (
        UserID   INT IDENTITY(1,1) NOT NULL,
        PersonID INT               NOT NULL,
        UserName NVARCHAR(20)      NOT NULL,
        [Password] NVARCHAR(500)   NOT NULL,
        IsActive BIT               NOT NULL CONSTRAINT DF_Users_IsActive DEFAULT (1),
        CONSTRAINT PK_Users PRIMARY KEY CLUSTERED (UserID),
        CONSTRAINT UQ_Users_UserName UNIQUE (UserName),
        CONSTRAINT FK_Users_People
            FOREIGN KEY (PersonID) REFERENCES dbo.People(PersonID)
    );
END
GO

/* ---------- ApplicationTypes ---------- */
IF OBJECT_ID(N'dbo.ApplicationTypes', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ApplicationTypes (
        ID    INT IDENTITY(1,1) NOT NULL,
        Title NVARCHAR(50)      NOT NULL,
        Fees  FLOAT             NOT NULL,
        CONSTRAINT PK_ApplicationTypes PRIMARY KEY CLUSTERED (ID)
    );
END
GO

/* ---------- TestTypes ---------- */
IF OBJECT_ID(N'dbo.TestTypes', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.TestTypes (
        ID          INT IDENTITY(1,1) NOT NULL,
        Title       NVARCHAR(50)      NOT NULL,
        Description NVARCHAR(500)     NULL,
        Fees        FLOAT             NOT NULL,
        CONSTRAINT PK_TestTypes PRIMARY KEY CLUSTERED (ID)
    );
END
GO

/* ---------- LicenseClasses ---------- */
IF OBJECT_ID(N'dbo.LicenseClasses', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.LicenseClasses (
        LicenseClassID    INT IDENTITY(1,1) NOT NULL,
        ClassName         NVARCHAR(50)      NOT NULL,
        ClassDescription  NVARCHAR(500)     NOT NULL,
        MinimumAllowedAge TINYINT           NOT NULL,
        ValidityLength    TINYINT           NOT NULL,   -- years
        ClassFees         FLOAT             NOT NULL,
        CONSTRAINT PK_LicenseClasses PRIMARY KEY CLUSTERED (LicenseClassID)
    );
END
GO

/* ---------- LicenseIssueTypes ---------- */
IF OBJECT_ID(N'dbo.LicenseIssueTypes', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.LicenseIssueTypes (
        IssueTypeID INT IDENTITY(1,1) NOT NULL,
        IssueType   NVARCHAR(50)      NOT NULL,
        CONSTRAINT PK_LicenseIssueTypes PRIMARY KEY CLUSTERED (IssueTypeID)
    );
END
GO

/* ---------- Applications ---------- */
IF OBJECT_ID(N'dbo.Applications', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Applications (
        ApplicationID     INT IDENTITY(1,1) NOT NULL,
        ApplicationTypeID INT               NOT NULL,
        [Date]            DATETIME          NOT NULL,
        [Status]          TINYINT           NOT NULL,   -- 1 New, 2 Cancelled, 3 Completed
        CreatedByUserID   INT               NOT NULL,
        CONSTRAINT PK_Applications PRIMARY KEY CLUSTERED (ApplicationID),
        CONSTRAINT FK_Applications_ApplicationTypes
            FOREIGN KEY (ApplicationTypeID) REFERENCES dbo.ApplicationTypes(ID),
        CONSTRAINT FK_Applications_Users
            FOREIGN KEY (CreatedByUserID) REFERENCES dbo.Users(UserID)
    );
END
GO

/* ---------- LocalLicenseApplications ---------- */
IF OBJECT_ID(N'dbo.LocalLicenseApplications', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.LocalLicenseApplications (
        LocalLicenseApplicationID INT IDENTITY(1,1) NOT NULL,   -- L.L.AID
        ApplicationID             INT               NOT NULL,
        LicenseClassID            INT               NOT NULL,
        PersonID                  INT               NOT NULL,
        CONSTRAINT PK_LocalLicenseApplications PRIMARY KEY CLUSTERED (LocalLicenseApplicationID),
        CONSTRAINT FK_LocalLicenseApplications_Applications
            FOREIGN KEY (ApplicationID) REFERENCES dbo.Applications(ApplicationID),
        CONSTRAINT FK_LocalLicenseApplications_LicenseClasses
            FOREIGN KEY (LicenseClassID) REFERENCES dbo.LicenseClasses(LicenseClassID),
        CONSTRAINT FK_LocalLicenseApplications_People
            FOREIGN KEY (PersonID) REFERENCES dbo.People(PersonID)
    );
END
GO

/* ---------- Drivers ---------- */
IF OBJECT_ID(N'dbo.Drivers', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Drivers (
        DriverID        INT IDENTITY(1,1) NOT NULL,
        PersonID        INT               NOT NULL,
        CreatedByUserID INT               NOT NULL,
        CONSTRAINT PK_Drivers PRIMARY KEY CLUSTERED (DriverID),
        CONSTRAINT FK_Drivers_People
            FOREIGN KEY (PersonID) REFERENCES dbo.People(PersonID),
        CONSTRAINT FK_Drivers_Users
            FOREIGN KEY (CreatedByUserID) REFERENCES dbo.Users(UserID)
    );
END
GO

/* ---------- Licenses ---------- */
IF OBJECT_ID(N'dbo.Licenses', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Licenses (
        LicenseID       INT IDENTITY(1,1) NOT NULL,
        IssueTypeID     INT               NOT NULL,
        IssueDate       DATETIME          NOT NULL,
        ExpirationDate  DATETIME          NOT NULL,
        DriverID        INT               NOT NULL,
        CreatedByUserID INT               NOT NULL,
        CONSTRAINT PK_Licenses PRIMARY KEY CLUSTERED (LicenseID),
        CONSTRAINT FK_Licenses_LicenseIssueTypes
            FOREIGN KEY (IssueTypeID) REFERENCES dbo.LicenseIssueTypes(IssueTypeID),
        CONSTRAINT FK_Licenses_Drivers
            FOREIGN KEY (DriverID) REFERENCES dbo.Drivers(DriverID),
        CONSTRAINT FK_Licenses_Users
            FOREIGN KEY (CreatedByUserID) REFERENCES dbo.Users(UserID)
    );
END
GO

/* ---------- LocalLicenses ---------- */
IF OBJECT_ID(N'dbo.LocalLicenses', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.LocalLicenses (
        LocalLicenseID INT IDENTITY(1,1) NOT NULL,   -- L.LID
        LicenseID      INT               NOT NULL,
        LicenseClassID INT               NOT NULL,
        CONSTRAINT PK_LocalLicenses PRIMARY KEY CLUSTERED (LocalLicenseID),
        CONSTRAINT FK_LocalLicenses_Licenses
            FOREIGN KEY (LicenseID) REFERENCES dbo.Licenses(LicenseID),
        CONSTRAINT FK_LocalLicenses_LicenseClasses
            FOREIGN KEY (LicenseClassID) REFERENCES dbo.LicenseClasses(LicenseClassID)
    );
END
GO

/* ---------- InternationalLicenses ---------- */
IF OBJECT_ID(N'dbo.InternationalLicenses', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.InternationalLicenses (
        InternationalLicenseID INT IDENTITY(1,1) NOT NULL,   -- I.LID
        LicenseID              INT               NOT NULL,
        LocalLicenseID         INT               NOT NULL,   -- L.LID
        CONSTRAINT PK_InternationalLicenses PRIMARY KEY CLUSTERED (InternationalLicenseID),
        CONSTRAINT FK_InternationalLicenses_Licenses
            FOREIGN KEY (LicenseID) REFERENCES dbo.Licenses(LicenseID),
        CONSTRAINT FK_InternationalLicenses_LocalLicenses
            FOREIGN KEY (LocalLicenseID) REFERENCES dbo.LocalLicenses(LocalLicenseID)
    );
END
GO

/* ---------- InternationalLicenseApplications ---------- */
IF OBJECT_ID(N'dbo.InternationalLicenseApplications', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.InternationalLicenseApplications (
        InternationalLicenseApplicationID INT IDENTITY(1,1) NOT NULL,   -- I.LAID
        ApplicationID                     INT               NOT NULL,
        LocalLicenseID                    INT               NOT NULL,   -- L.LID
        CONSTRAINT PK_InternationalLicenseApplications
            PRIMARY KEY CLUSTERED (InternationalLicenseApplicationID),
        CONSTRAINT FK_InternationalLicenseApplications_Applications
            FOREIGN KEY (ApplicationID) REFERENCES dbo.Applications(ApplicationID),
        CONSTRAINT FK_InternationalLicenseApplications_LocalLicenses
            FOREIGN KEY (LocalLicenseID) REFERENCES dbo.LocalLicenses(LocalLicenseID)
    );
END
GO

/* ---------- DetainedFreedLicenses ---------- */
IF OBJECT_ID(N'dbo.DetainedFreedLicenses', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.DetainedFreedLicenses (
        DFL_ID           INT IDENTITY(1,1) NOT NULL,
        LicenseID        INT               NOT NULL,
        IsReleased       BIT               NOT NULL,
        DetainedDate     DATETIME          NOT NULL,
        ReleasedDate     DATETIME          NULL,
        CreatedByUserID  INT               NOT NULL,
        ReleasedByUserID INT               NULL,
        CONSTRAINT PK_DetainedFreedLicenses PRIMARY KEY CLUSTERED (DFL_ID),
        CONSTRAINT FK_DetainedFreedLicenses_Licenses
            FOREIGN KEY (LicenseID) REFERENCES dbo.Licenses(LicenseID),
        CONSTRAINT FK_DetainedFreedLicenses_CreatedBy
            FOREIGN KEY (CreatedByUserID) REFERENCES dbo.Users(UserID),
        CONSTRAINT FK_DetainedFreedLicenses_ReleasedBy
            FOREIGN KEY (ReleasedByUserID) REFERENCES dbo.Users(UserID)
    );
END
GO

/* ---------- Tests ---------- */
IF OBJECT_ID(N'dbo.Tests', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Tests (
        TestID                    INT IDENTITY(1,1) NOT NULL,
        TestTypeID                INT               NOT NULL,
        PrerequisiteTestTypeID    INT               NULL,
        Result                    BIT               NOT NULL,
        Notes                     NVARCHAR(500)     NULL,
        LocalLicenseApplicationID INT               NOT NULL,
        CreatedByUserID           INT               NOT NULL,
        CONSTRAINT PK_Tests PRIMARY KEY CLUSTERED (TestID),
        CONSTRAINT FK_Tests_TestTypes
            FOREIGN KEY (TestTypeID) REFERENCES dbo.TestTypes(ID),
        CONSTRAINT FK_Tests_PrerequisiteTestTypes
            FOREIGN KEY (PrerequisiteTestTypeID) REFERENCES dbo.TestTypes(ID),
        CONSTRAINT FK_Tests_LocalLicenseApplications
            FOREIGN KEY (LocalLicenseApplicationID)
            REFERENCES dbo.LocalLicenseApplications(LocalLicenseApplicationID),
        CONSTRAINT FK_Tests_Users
            FOREIGN KEY (CreatedByUserID) REFERENCES dbo.Users(UserID)
    );
END
GO

/* ---------- TestAppointments ---------- */
IF OBJECT_ID(N'dbo.TestAppointments', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.TestAppointments (
        TestAppointmentID INT IDENTITY(1,1) NOT NULL,
        TestID            INT               NOT NULL,
        [Date]            DATETIME          NOT NULL,
        IsLocked          BIT               NOT NULL,
        PaidFees          FLOAT             NOT NULL,
        CreatedByUserID   INT               NOT NULL,
        CONSTRAINT PK_TestAppointments PRIMARY KEY CLUSTERED (TestAppointmentID),
        CONSTRAINT FK_TestAppointments_Tests
            FOREIGN KEY (TestID) REFERENCES dbo.Tests(TestID),
        CONSTRAINT FK_TestAppointments_Users
            FOREIGN KEY (CreatedByUserID) REFERENCES dbo.Users(UserID)
    );
END
GO

/* =====================================================================
   2) LOOKUP DATA  (each block runs only if its table is empty)
   ===================================================================== */

/* ---------- ApplicationTypes ---------- */
IF NOT EXISTS (SELECT 1 FROM dbo.ApplicationTypes)
BEGIN
    SET IDENTITY_INSERT dbo.ApplicationTypes ON;
    INSERT INTO dbo.ApplicationTypes (ID, Title, Fees)
    VALUES
        (1, N'New Local Driving License Service',         15),
        (2, N'Renew Driving License Service',              7),
        (3, N'Replacement for a Lost Driving License',    10),
        (4, N'Replacement for a Damaged Driving License',  5),
        (5, N'Release Detained Driving License',          15),
        (6, N'New International License',                 51),
        (7, N'Retake Test',                                5);
    SET IDENTITY_INSERT dbo.ApplicationTypes OFF;
END
GO

/* ---------- TestTypes ---------- */
IF NOT EXISTS (SELECT 1 FROM dbo.TestTypes)
BEGIN
    SET IDENTITY_INSERT dbo.TestTypes ON;
    INSERT INTO dbo.TestTypes (ID, Title, Description, Fees)
    VALUES
        (1, N'Vision Test',
            N'This assesses the applicant''s visual acuity to ensure they can read road signs and identify hazards.', 10),
        (2, N'Written (Theory) Test',
            N'This test assesses the applicant''s knowledge of traffic rules, road signs, and safe driving practices.', 20),
        (3, N'Practical (Street) Test',
            N'This test evaluates the applicant''s driving skills and ability to control the vehicle in real traffic conditions.', 35);
    SET IDENTITY_INSERT dbo.TestTypes OFF;
END
GO

/* ---------- LicenseClasses ---------- */
IF NOT EXISTS (SELECT 1 FROM dbo.LicenseClasses)
BEGIN
    SET IDENTITY_INSERT dbo.LicenseClasses ON;
    INSERT INTO dbo.LicenseClasses
        (LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, ValidityLength, ClassFees)
    VALUES
        (1, N'Class 1 - Small Motorcycle',
            N'Allows the driver to drive small motorcycles with small capacity engines.', 18, 5, 15),
        (2, N'Class 2 - Heavy Motorcycle License',
            N'Allows the driver to drive heavy and large-capacity motorcycles.', 21, 5, 30),
        (3, N'Class 3 - Ordinary driving license',
            N'Allows the driver to drive ordinary private cars.', 18, 10, 20),
        (4, N'Class 4 - Commercial',
            N'Allows the driver to drive taxis and commercial vehicles.', 21, 10, 200),
        (5, N'Class 5 - Agricultural',
            N'Allows the driver to drive agricultural vehicles and tractors.', 21, 10, 50),
        (6, N'Class 6 - Small and medium bus',
            N'Allows the driver to drive small and medium buses.', 21, 10, 250),
        (7, N'Class 7 - Truck and heavy vehicle',
            N'Allows the driver to drive trucks and heavy vehicles.', 21, 10, 300);
    SET IDENTITY_INSERT dbo.LicenseClasses OFF;
END
GO

/* ---------- LicenseIssueTypes ---------- */
IF NOT EXISTS (SELECT 1 FROM dbo.LicenseIssueTypes)
BEGIN
    SET IDENTITY_INSERT dbo.LicenseIssueTypes ON;
    INSERT INTO dbo.LicenseIssueTypes (IssueTypeID, IssueType)
    VALUES
        (1, N'First Time'),
        (2, N'Renew'),
        (3, N'Replacement for Damaged'),
        (4, N'Replacement for Lost');
    SET IDENTITY_INSERT dbo.LicenseIssueTypes OFF;
END
GO

/* ---------- Countries ---------- */
IF NOT EXISTS (SELECT 1 FROM dbo.Countries)
BEGIN
    SET IDENTITY_INSERT dbo.Countries ON;
    INSERT INTO dbo.Countries (CountryID, CountryName)
    VALUES
        (1, N'Afghanistan'), (2, N'Albania'), (3, N'Algeria'), (4, N'Andorra'), (5, N'Angola'),
        (6, N'Antigua and Barbuda'), (7, N'Argentina'), (8, N'Armenia'), (9, N'Austria'), (10, N'Azerbaijan'),
        (11, N'Bahrain'), (12, N'Bangladesh'), (13, N'Barbados'), (14, N'Belarus'), (15, N'Belgium'),
        (16, N'Belize'), (17, N'Benin'), (18, N'Bhutan'), (19, N'Bolivia'), (20, N'Bosnia and Herzegovina'),
        (21, N'Botswana'), (22, N'Brazil'), (23, N'Brunei'), (24, N'Bulgaria'), (25, N'Burkina Faso'),
        (26, N'Burundi'), (27, N'Cabo Verde'), (28, N'Cambodia'), (29, N'Cameroon'), (30, N'Canada'),
        (31, N'Central African Republic'), (32, N'Chad'), (33, N'Channel Islands'), (34, N'Chile'), (35, N'China'),
        (36, N'Colombia'), (37, N'Comoros'), (38, N'Congo'), (39, N'Costa Rica'),
        (40, N'C' + NCHAR(244) + N'te d''Ivoire'),
        (41, N'Croatia'), (42, N'Cuba'), (43, N'Cyprus'), (44, N'Czech Republic'), (45, N'Denmark'),
        (46, N'Djibouti'), (47, N'Dominica'), (48, N'Dominican Republic'), (49, N'DR Congo'), (50, N'Ecuador'),
        (51, N'Egypt'), (52, N'El Salvador'), (53, N'Equatorial Guinea'), (54, N'Eritrea'), (55, N'Estonia'),
        (56, N'Eswatini'), (57, N'Ethiopia'), (58, N'Faeroe Islands'), (59, N'Finland'), (60, N'France'),
        (61, N'French Guiana'), (62, N'Gabon'), (63, N'Gambia'), (64, N'Georgia'), (65, N'Germany'),
        (66, N'Ghana'), (67, N'Gibraltar'), (68, N'Greece'), (69, N'Grenada'), (70, N'Guatemala'),
        (71, N'Guinea'), (72, N'Guinea-Bissau'), (73, N'Guyana'), (74, N'Haiti'), (75, N'Holy See'),
        (76, N'Honduras'), (77, N'Hong Kong'), (78, N'Hungary'), (79, N'Iceland'), (80, N'India'),
        (81, N'Indonesia'), (82, N'Iran'), (83, N'Iraq'), (84, N'Ireland'), (85, N'Isle of Man'),
        (86, N'Israel'), (87, N'Italy'), (88, N'Jamaica'), (89, N'Japan'), (90, N'Jordan'),
        (91, N'Kazakhstan'), (92, N'Kenya'), (93, N'Kuwait'), (94, N'Kyrgyzstan'), (95, N'Laos'),
        (96, N'Latvia'), (97, N'Lebanon'), (98, N'Lesotho'), (99, N'Liberia'), (100, N'Libya'),
        (101, N'Liechtenstein'), (102, N'Lithuania'), (103, N'Luxembourg'), (104, N'Macao'), (105, N'Madagascar'),
        (106, N'Malawi'), (107, N'Malaysia'), (108, N'Maldives'), (109, N'Mali'), (110, N'Malta'),
        (111, N'Mauritania'), (112, N'Mauritius'), (113, N'Mayotte'), (114, N'Mexico'), (115, N'Moldova'),
        (116, N'Monaco'), (117, N'Mongolia'), (118, N'Montenegro'), (119, N'Morocco'), (120, N'Mozambique'),
        (121, N'Myanmar'), (122, N'Namibia'), (123, N'Nepal'), (124, N'Netherlands'), (125, N'Nicaragua'),
        (126, N'Niger'), (127, N'Nigeria'), (128, N'North Korea'), (129, N'North Macedonia'), (130, N'Norway'),
        (131, N'Oman'), (132, N'Pakistan'), (133, N'Panama'), (134, N'Paraguay'), (135, N'Peru'),
        (136, N'Philippines'), (137, N'Poland'), (138, N'Portugal'), (139, N'Qatar'),
        (140, N'R' + NCHAR(233) + N'union'),
        (141, N'Romania'), (142, N'Russia'), (143, N'Rwanda'), (144, N'Saint Helena'), (145, N'Saint Kitts and Nevis'),
        (146, N'Saint Lucia'), (147, N'Saint Vincent and the Grenadines'), (148, N'San Marino'),
        (149, N'Sao Tome & Principe'), (150, N'Saudi Arabia'), (151, N'Senegal'), (152, N'Serbia'),
        (153, N'Seychelles'), (154, N'Sierra Leone'), (155, N'Singapore'), (156, N'Slovakia'), (157, N'Slovenia'),
        (158, N'Somalia'), (159, N'South Africa'), (160, N'South Korea'), (161, N'South Sudan'), (162, N'Spain'),
        (163, N'Sri Lanka'), (164, N'State of Palestine'), (165, N'Sudan'), (166, N'Suriname'), (167, N'Sweden'),
        (168, N'Switzerland'), (169, N'Syria'), (170, N'Taiwan'), (171, N'Tajikistan'), (172, N'Tanzania'),
        (173, N'Thailand'), (174, N'The Bahamas'), (175, N'Timor-Leste'), (176, N'Togo'),
        (177, N'Trinidad and Tobago'), (178, N'Tunisia'), (179, N'Turkey'), (180, N'Turkmenistan'),
        (181, N'Uganda'), (182, N'Ukraine'), (183, N'United Arab Emirates'), (184, N'United Kingdom'),
        (185, N'United States'), (186, N'Uruguay'), (187, N'Uzbekistan'), (188, N'Venezuela'),
        (189, N'Vietnam'), (190, N'Western Sahara'), (191, N'Yemen'), (192, N'Zambia'), (193, N'Zimbabwe');
    SET IDENTITY_INSERT dbo.Countries OFF;
END
GO

/* =====================================================================
   3) CHECK
   ===================================================================== */
SELECT name AS TableName FROM sys.tables ORDER BY name;   -- expect 17 tables (+ sysdiagrams if you use diagrams)
GO

/* =====================================================================
   4) DEFAULT ADMIN USER  (created only when there are no users yet)
      UserName : admin
      Password : 1234 change it after the fisrt login
   ===================================================================== */
IF NOT EXISTS (SELECT 1 FROM dbo.Users)
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @PersonID INT;

        -- reuse the admin person if it already exists, otherwise create it
        SELECT @PersonID = PersonID FROM dbo.People WHERE NationalNo = N'ADMIN-0001';

        IF @PersonID IS NULL
        BEGIN
            INSERT INTO dbo.People
                (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                 Gendor, [Address], Phone, Email, NationalityCountryID, ImagePath)
            VALUES
                (N'ADMIN-0001', N'System', N'Admin', NULL, N'Account', '1990-01-01',
                 0, N'Head Office', N'0000000000', NULL,
                 (SELECT TOP 1 CountryID FROM dbo.Countries WHERE CountryName = N'Jordan'),
                 NULL);

            SET @PersonID = SCOPE_IDENTITY();
        END

        INSERT INTO dbo.Users (PersonID, UserName, [Password], IsActive)
        VALUES (@PersonID, N'admin', '1234' , 1);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

SELECT u.UserID, u.UserName, u.IsActive, p.FirstName, p.LastName
FROM dbo.Users u JOIN dbo.People p ON p.PersonID = u.PersonID;
GO
