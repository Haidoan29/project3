create database project3;
use project3;
-- Bảng Cancellation
CREATE TABLE Cancellation (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PRNNo NVARCHAR(MAX) NOT NULL,
    CancellationDate DATETIME2 NOT NULL,
    CancellationFee DECIMAL(18, 2) NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NULL,
    IsDeleted BIT NULL
);

-- Bảng CancellationFeeRule
CREATE TABLE CancellationFeeRule (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Class NVARCHAR(MAX) NOT NULL, -- FareClass enum sẽ được xử lý dưới dạng chuỗi
    CancellationFee DECIMAL(18, 2) NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NULL,
    IsDeleted BIT NULL
);

-- Bảng Customer
CREATE TABLE Customer (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Email NVARCHAR(MAX) NOT NULL,
    Phone NVARCHAR(MAX) NOT NULL,
    CCCD NVARCHAR(MAX) NOT NULL, -- Căn cước công dân
    Address NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NULL,
    IsDeleted BIT NULL
);

-- Bảng DailyCashTransaction
CREATE TABLE DailyCashTransaction (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TransactionDate DATETIME2 NOT NULL,
    MoneyReceived DECIMAL(18, 2) NOT NULL,
    MoneyRefund DECIMAL(18, 2) NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NULL,
    IsDeleted BIT NULL
);

-- Bảng Station
CREATE TABLE Station (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StationCode NVARCHAR(MAX) NOT NULL,
    StationName NVARCHAR(MAX) NOT NULL,
    DivisionName NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NULL,
    IsDeleted BIT NULL
);
-- Bảng Router
CREATE TABLE Router (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RouteName NVARCHAR(MAX) NOT NULL,
    StartStationID INT NOT NULL,
    EndStation INT NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NULL,
    IsDeleted BIT NULL,
    FOREIGN KEY (StartStationID) REFERENCES Station(Id),
    FOREIGN KEY (EndStation) REFERENCES Station(Id)
);

-- Bảng Train
CREATE TABLE Train (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TrainName NVARCHAR(MAX) NOT NULL,
    NumCoachesAC3 INT NOT NULL,
    NumCoachesFirstClass INT NOT NULL,
    NumCoachesSleeper INT NOT NULL,
    UpDownStatus INT NOT NULL, -- UpDownStatus enum sẽ được xử lý dưới dạng số nguyên
    RouteID INT NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NULL,
    IsDeleted BIT NULL,
    FOREIGN KEY (RouteID) REFERENCES Router(Id)
);

-- Bảng DayMaster
CREATE TABLE DayMaster (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DayID INT NOT NULL,
    TrainID INT NOT NULL,
    DayOfWeek INT NOT NULL, -- DayOfWeek enum sẽ được xử lý dưới dạng số nguyên
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NULL,
    IsDeleted BIT NULL,
    FOREIGN KEY (TrainID) REFERENCES Train(Id)
);

-- Bảng FareRule
CREATE TABLE FareRule (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Class NVARCHAR(MAX) NOT NULL, -- FareClass enum sẽ được xử lý dưới dạng chuỗi
    Distance INT NOT NULL,
    Fare DECIMAL(18, 2) NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NULL,
    IsDeleted BIT NULL
);

-- Bảng ReservationSuperFastFee
CREATE TABLE ReservationSuperFastFee (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Class NVARCHAR(MAX) NOT NULL, -- FareClass enum sẽ được xử lý dưới dạng chuỗi
    ReservationFee DECIMAL(18, 2) NOT NULL,
    SuperFastFee DECIMAL(18, 2) NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NULL,
    IsDeleted BIT NULL
);





-- Bảng TrainSchedule
CREATE TABLE TrainSchedule (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ScheduleID INT NOT NULL,
    TrainID INT NOT NULL,
    StartStationID INT NOT NULL,
    EndStationID INT NOT NULL,
    DepartureTime TIME NOT NULL,
    ArrivalTime TIME NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NULL,
    IsDeleted BIT NULL,
    FOREIGN KEY (TrainID) REFERENCES Train(Id),
    FOREIGN KEY (StartStationID) REFERENCES Station(Id),
    FOREIGN KEY (EndStationID) REFERENCES Station(Id)
);

-- Bảng Transaction
CREATE TABLE [Transaction] (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PRNNo NVARCHAR(MAX) NOT NULL,
    TrainID INT NOT NULL,
    CustomerID INT NOT NULL,
    JourneyDate DATETIME2 NOT NULL,
    FromStationID INT NOT NULL,
    ToStationID INT NOT NULL,
    SeatNo NVARCHAR(MAX) NOT NULL,
    CoachNo NVARCHAR(MAX) NOT NULL,
    ReservationFee DECIMAL(18, 2) NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NULL,
    IsDeleted BIT NULL,
    FOREIGN KEY (TrainID) REFERENCES Train(Id),
    FOREIGN KEY (FromStationID) REFERENCES Station(Id),
    FOREIGN KEY (ToStationID) REFERENCES Station(Id),
    FOREIGN KEY (CustomerID) REFERENCES Customer(Id)
);
