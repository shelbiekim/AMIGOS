DROP TABLE IF EXISTS Organizers
DROP TABLE IF EXISTS Venues
DROP TABLE IF EXISTS Bookings
DROP TABLE IF EXISTS Events

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
[Id] int IDENTITY(1,1) NOT NULL,
[OrganizerID] int NOT NULL,
[EventType] nvarchar(max) NOT NULL,
[URL] nvarchar(max) NULL,
[VenueID] int NULL,
[Capacity] int NOT NULL,
[Name] nvarchar(max) NOT NULL,
[StartDate] datetime NOT NULL,
[EndDate] datetime NOT NULL,
[Comments] int NOT NULL,
[Image] nvarchar(max) NULL,
    PRIMARY KEY (Id),
);
GO

-- Creating table 'Organizers'
CREATE TABLE [dbo].[Organizers] (
[Id] int IDENTITY(1,1) NOT NULL,
[Name] nvarchar(max) NOT NULL,
[Email] nvarchar(max) NOT NULL,
    PRIMARY KEY (Id),
);
GO

-- Creating table 'Venues'
CREATE TABLE [dbo].[Venues] (
[Id] int IDENTITY(1,1) NOT NULL,
[Name] nvarchar(max) NOT NULL,
[Longitude] nvarchar(max) NOT NULL,
[Latitude] nvarchar(max) NOT NULL,
[Address] nvarchar(max) NULL,
    PRIMARY KEY (Id),
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
[Id] int IDENTITY(1,1) NOT NULL,
[AttendeeName] nvarchar(max) NOT NULL,
[AttendeeEmail] nvarchar(max) NOT NULL,
[EventId] int NOT NULL,
[BookingDate] datetime NOT NULL
    PRIMARY KEY (Id),
);
GO

-- Creating foreign key on [OrganizerId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Event_Organizer]
    FOREIGN KEY ([OrganizerId])
    REFERENCES [dbo].[Organizers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO


-- Creating foreign key on [VenueId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Event_Venue]
    FOREIGN KEY ([VenueId])
    REFERENCES [dbo].[Venues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [EventId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_Booking_Event]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO