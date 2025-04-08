CREATE DATABASE CodingTracker;
GO

USE CodingTracker;
GO

CREATE SCHEMA TCSA;
GO
  
CREATE TABLE CodingTracker.TCSA.CodingSessions (
       Id INTEGER PRIMARY KEY IDENTITY (1, 1),
       StartDateTime DATETIME2(7) NOT NULL,
       EndDateTime DATETIME2(7) NOT NULL,
       Duration DECIMAL(20, 2) NOT NULL
);
GO