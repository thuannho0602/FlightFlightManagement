BEGIN TRANSACTION;
GO

CREATE TABLE [BookAPlace] (
    [Id] int NOT NULL IDENTITY,
    [StartDate] datetime2 NOT NULL,
    [ReturnDay] datetime2 NULL,
    [FlightID] int NOT NULL,
    [ClientID] int NOT NULL,
    CONSTRAINT [PK_BookAPlace] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [HoldtheSeat] (
    [Id] int NOT NULL IDENTITY,
    [CodePlace] nvarchar(max) NOT NULL,
    [BookAPlaceId] int NOT NULL,
    CONSTRAINT [PK_HoldtheSeat] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230629100729_NewDatabaseBookAPlace_HoldtheSeat', N'6.0.0');
GO

COMMIT;
GO

