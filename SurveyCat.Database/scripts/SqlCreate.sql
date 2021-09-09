CREATE TABLE [Brand] (
    [Id]        UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [BrandName] NVARCHAR(255),
    CONSTRAINT  [PK_Brand] PRIMARY KEY ([Id]),
);
GO

CREATE TABLE [Product] (
    [Id]          UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [ProductName] NVARCHAR(255),
    [BrandId]     UNIQUEIDENTIFIER,
    CONSTRAINT    [PK_Product] PRIMARY KEY ([Id]),
    CONSTRAINT    [FK_Product_Brand] FOREIGN KEY ([BrandId]) REFERENCES [Brand] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

CREATE TABLE Survey (
    [Id]        UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [Rating]    INT              NULL,
    [Comment]   NVARCHAR(MAX)    NULL,
    [ProductId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Survey] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Survey_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

CREATE VIEW v_Report
AS 
	SELECT CAST(AVG(s.Rating) AS DECIMAL(7,4)) as AverageRating, p.ProductName
	FROM Survey S
	INNER JOIN Product P
	ON S.ProductId = P.Id
	GROUP BY P.Id, P.ProductName

