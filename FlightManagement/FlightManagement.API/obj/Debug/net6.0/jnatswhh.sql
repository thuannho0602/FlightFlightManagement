BEGIN TRANSACTION;
GO

CREATE TABLE [Flight] (
    [Id] int NOT NULL IDENTITY,
    [DepartureTime] time NOT NULL,
    [Time] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [ArrivalAirportId] int NOT NULL,
    [AirportDepartureId] int NOT NULL,
    [PlaneId] int NOT NULL,
    CONSTRAINT [PK_Flight] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Flight_AirportDeparture_AirportDepartureId] FOREIGN KEY ([AirportDepartureId]) REFERENCES [AirportDeparture] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Flight_ArrivalAirport_ArrivalAirportId] FOREIGN KEY ([ArrivalAirportId]) REFERENCES [ArrivalAirport] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Flight_Planes_PlaneId] FOREIGN KEY ([PlaneId]) REFERENCES [Planes] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Flight_AirportDepartureId] ON [Flight] ([AirportDepartureId]);
GO

CREATE INDEX [IX_Flight_ArrivalAirportId] ON [Flight] ([ArrivalAirportId]);
GO

CREATE INDEX [IX_Flight_PlaneId] ON [Flight] ([PlaneId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230628131454_NewFlightDatabase', N'6.0.0');
GO

COMMIT;
GO

