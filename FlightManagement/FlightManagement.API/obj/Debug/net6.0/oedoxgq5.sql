BEGIN TRANSACTION;
GO

CREATE TABLE [AirportDeparture] (
    [Id] int NOT NULL IDENTITY,
    [Code] nvarchar(max) NOT NULL,
    [NameAirportDeparture] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_AirportDeparture] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230628085415_NewAirportDepartureDatabase', N'6.0.0');
GO

COMMIT;
GO

