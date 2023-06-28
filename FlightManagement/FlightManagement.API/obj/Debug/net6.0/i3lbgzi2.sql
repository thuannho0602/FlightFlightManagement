BEGIN TRANSACTION;
GO

CREATE TABLE [ArrivalAirport] (
    [Id] int NOT NULL IDENTITY,
    [Code] nvarchar(max) NOT NULL,
    [NameArrivalAirport] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ArrivalAirport] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230628111629_NewArrivalAirportDatabase', N'6.0.0');
GO

COMMIT;
GO

