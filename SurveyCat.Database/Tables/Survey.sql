CREATE TABLE [Survey] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_Survey_Id] DEFAULT  NEWID() NOT NULL,
    [Rating]    INT                                                         NOT NULL,
    [Comment]   NVARCHAR(MAX)                                               NOT NULL,
    [ProductId] UNIQUEIDENTIFIER                                            NOT NULL,
    CONSTRAINT  [PK_Survey]               PRIMARY KEY ([Id]),
    CONSTRAINT  [FK_Survey_Product]       FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);