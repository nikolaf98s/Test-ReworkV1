﻿CREATE TABLE [Product] (
    [Id]          UNIQUEIDENTIFIER CONSTRAINT [DF_Product_Id] DEFAULT  NEWID() NOT NULL,
    [Name]        NVARCHAR(255)                                                NOT NULL,
    [BrandId]     UNIQUEIDENTIFIER                                             NOT NULL,
    CONSTRAINT    [PK_Product]              PRIMARY KEY ([Id]),
    CONSTRAINT    [FK_Product_Brand]        FOREIGN KEY ([BrandId]) REFERENCES [Brand] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);
