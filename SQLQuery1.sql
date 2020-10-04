DROP TABLE IF EXISTS Books
DROP TABLE IF EXISTS Publishers
DROP TABLE IF EXISTS Authors

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
[Id] int IDENTITY(1,1) NOT NULL,
[Title] nvarchar(max) NOT NULL,
[TotalPages] int NOT NULL,
[ISBN] nvarchar(max) NOT NULL,
[PublishedDate] date NOT NULL,
[AuthorId] int NOT NULL,
[PublisherId] int NOT NULL,
[ImageId] int NOT NULL,
    PRIMARY KEY (Id),
);
GO

-- Creating table 'Publishers'
CREATE TABLE [dbo].[Publishers] (
[Id] int IDENTITY(1,1) NOT NULL,
[PublisherName] nvarchar(max) NOT NULL,
    PRIMARY KEY (Id),
);
GO

-- Creating table 'Authors'
CREATE TABLE [dbo].[Authors] (
[Id] int IDENTITY(1,1) NOT NULL,
[AuthorName] nvarchar(max) NOT NULL,
    PRIMARY KEY (Id),
);
GO


-- Creating table 'Imagess'
CREATE TABLE [dbo].[Images] (
[Id] int IDENTITY(1,1) NOT NULL,
[ImageTitle] nvarchar(max) NOT NULL,
[ImagePath] nvarchar(max) NOT NULL,
    PRIMARY KEY (Id),
);
GO

-- Creating foreign key on [PublisherId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_Book_Publisher]
    FOREIGN KEY ([PublisherId])
    REFERENCES [dbo].[Publishers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AuthorId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_Book_Author]
    FOREIGN KEY ([AuthorId])
    REFERENCES [dbo].[Authors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ImageId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_Book_Image]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[Images]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
