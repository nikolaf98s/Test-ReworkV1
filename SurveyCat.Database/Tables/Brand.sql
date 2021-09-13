CREATE TABLE [Brand] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_Brand_Id] DEFAULT  NEWID() NOT NULL,
    [Name]      NVARCHAR(255)                                              NOT NULL,
    CONSTRAINT  [PK_Brand]                                PRIMARY KEY ([Id]),
    CONSTRAINT  [UNQ_Brand_Name]                          UNIQUE([Name]),
);