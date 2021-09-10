CREATE TABLE [Brand] (
    [Id]        UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [Name]      NVARCHAR(255)    NOT NULL,
    CONSTRAINT  [PK_Brand]                PRIMARY KEY ([Id]),
    CONSTRAINT  [UNQ_Brand_Name]          UNIQUE([Name])
);