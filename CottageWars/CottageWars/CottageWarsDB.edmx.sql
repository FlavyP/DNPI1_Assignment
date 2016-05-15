
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/15/2016 20:51:20
-- Generated from EDMX file: C:\Users\Lapos\Source\Repos\DNPI1_Assignment\CottageWars\CottageWars\CottageWarsDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CottageWarsDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserBuildings]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_UserBuildings];
GO
IF OBJECT_ID(N'[dbo].[FK_BuildingsBarracks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [FK_BuildingsBarracks];
GO
IF OBJECT_ID(N'[dbo].[FK_BuildingsClay]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [FK_BuildingsClay];
GO
IF OBJECT_ID(N'[dbo].[FK_BuildingsIron]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [FK_BuildingsIron];
GO
IF OBJECT_ID(N'[dbo].[FK_BuildingsWood]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [FK_BuildingsWood];
GO
IF OBJECT_ID(N'[dbo].[FK_BuildingsStorage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [FK_BuildingsStorage];
GO
IF OBJECT_ID(N'[dbo].[FK_BuildingsTownhall]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [FK_BuildingsTownhall];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUnits]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_UserUnits];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Buildings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Buildings];
GO
IF OBJECT_ID(N'[dbo].[Units]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Units];
GO
IF OBJECT_ID(N'[dbo].[Townhalls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Townhalls];
GO
IF OBJECT_ID(N'[dbo].[Woods]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Woods];
GO
IF OBJECT_ID(N'[dbo].[Clays]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clays];
GO
IF OBJECT_ID(N'[dbo].[Irons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Irons];
GO
IF OBJECT_ID(N'[dbo].[Barracks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Barracks];
GO
IF OBJECT_ID(N'[dbo].[Storages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Storages];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [LastVisited] nvarchar(max)  NOT NULL,
    [Building_Id] int  NOT NULL,
    [Unit_Id] int  NOT NULL
);
GO

-- Creating table 'Buildings'
CREATE TABLE [dbo].[Buildings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [clayAmount] smallint  NOT NULL,
    [woodAmount] smallint  NOT NULL,
    [ironAmount] smallint  NOT NULL,
    [Barrack_Id] int  NOT NULL,
    [Clay_Id] int  NOT NULL,
    [Iron_Id] int  NOT NULL,
    [Wood_Id] int  NOT NULL,
    [Storage_Id] int  NOT NULL,
    [Townhall_Id] int  NOT NULL
);
GO

-- Creating table 'Units'
CREATE TABLE [dbo].[Units] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Infatry] smallint  NOT NULL,
    [Gladiator] smallint  NOT NULL,
    [Brute] smallint  NOT NULL
);
GO

-- Creating table 'Townhalls'
CREATE TABLE [dbo].[Townhalls] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [cost] smallint  NOT NULL,
    [level] smallint  NOT NULL,
    [population] smallint  NOT NULL,
    [PPH] smallint  NOT NULL
);
GO

-- Creating table 'Woods'
CREATE TABLE [dbo].[Woods] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PPH] smallint  NOT NULL,
    [cost] smallint  NOT NULL,
    [level] smallint  NOT NULL
);
GO

-- Creating table 'Clays'
CREATE TABLE [dbo].[Clays] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PPH] smallint  NOT NULL,
    [cost] smallint  NOT NULL,
    [level] smallint  NOT NULL
);
GO

-- Creating table 'Irons'
CREATE TABLE [dbo].[Irons] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PPH] smallint  NOT NULL,
    [cost] smallint  NOT NULL,
    [level] smallint  NOT NULL
);
GO

-- Creating table 'Barracks'
CREATE TABLE [dbo].[Barracks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [maxUnits] smallint  NOT NULL,
    [cost] smallint  NOT NULL,
    [level] smallint  NOT NULL,
    [unitCost] smallint  NOT NULL
);
GO

-- Creating table 'Storages'
CREATE TABLE [dbo].[Storages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [maxResource] smallint  NOT NULL,
    [cost] smallint  NOT NULL,
    [level] smallint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Buildings'
ALTER TABLE [dbo].[Buildings]
ADD CONSTRAINT [PK_Buildings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Units'
ALTER TABLE [dbo].[Units]
ADD CONSTRAINT [PK_Units]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Townhalls'
ALTER TABLE [dbo].[Townhalls]
ADD CONSTRAINT [PK_Townhalls]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Woods'
ALTER TABLE [dbo].[Woods]
ADD CONSTRAINT [PK_Woods]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clays'
ALTER TABLE [dbo].[Clays]
ADD CONSTRAINT [PK_Clays]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Irons'
ALTER TABLE [dbo].[Irons]
ADD CONSTRAINT [PK_Irons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Barracks'
ALTER TABLE [dbo].[Barracks]
ADD CONSTRAINT [PK_Barracks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Storages'
ALTER TABLE [dbo].[Storages]
ADD CONSTRAINT [PK_Storages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Building_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_UserBuildings]
    FOREIGN KEY ([Building_Id])
    REFERENCES [dbo].[Buildings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserBuildings'
CREATE INDEX [IX_FK_UserBuildings]
ON [dbo].[Users]
    ([Building_Id]);
GO

-- Creating foreign key on [Barrack_Id] in table 'Buildings'
ALTER TABLE [dbo].[Buildings]
ADD CONSTRAINT [FK_BuildingsBarracks]
    FOREIGN KEY ([Barrack_Id])
    REFERENCES [dbo].[Barracks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BuildingsBarracks'
CREATE INDEX [IX_FK_BuildingsBarracks]
ON [dbo].[Buildings]
    ([Barrack_Id]);
GO

-- Creating foreign key on [Clay_Id] in table 'Buildings'
ALTER TABLE [dbo].[Buildings]
ADD CONSTRAINT [FK_BuildingsClay]
    FOREIGN KEY ([Clay_Id])
    REFERENCES [dbo].[Clays]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BuildingsClay'
CREATE INDEX [IX_FK_BuildingsClay]
ON [dbo].[Buildings]
    ([Clay_Id]);
GO

-- Creating foreign key on [Iron_Id] in table 'Buildings'
ALTER TABLE [dbo].[Buildings]
ADD CONSTRAINT [FK_BuildingsIron]
    FOREIGN KEY ([Iron_Id])
    REFERENCES [dbo].[Irons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BuildingsIron'
CREATE INDEX [IX_FK_BuildingsIron]
ON [dbo].[Buildings]
    ([Iron_Id]);
GO

-- Creating foreign key on [Wood_Id] in table 'Buildings'
ALTER TABLE [dbo].[Buildings]
ADD CONSTRAINT [FK_BuildingsWood]
    FOREIGN KEY ([Wood_Id])
    REFERENCES [dbo].[Woods]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BuildingsWood'
CREATE INDEX [IX_FK_BuildingsWood]
ON [dbo].[Buildings]
    ([Wood_Id]);
GO

-- Creating foreign key on [Storage_Id] in table 'Buildings'
ALTER TABLE [dbo].[Buildings]
ADD CONSTRAINT [FK_BuildingsStorage]
    FOREIGN KEY ([Storage_Id])
    REFERENCES [dbo].[Storages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BuildingsStorage'
CREATE INDEX [IX_FK_BuildingsStorage]
ON [dbo].[Buildings]
    ([Storage_Id]);
GO

-- Creating foreign key on [Townhall_Id] in table 'Buildings'
ALTER TABLE [dbo].[Buildings]
ADD CONSTRAINT [FK_BuildingsTownhall]
    FOREIGN KEY ([Townhall_Id])
    REFERENCES [dbo].[Townhalls]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BuildingsTownhall'
CREATE INDEX [IX_FK_BuildingsTownhall]
ON [dbo].[Buildings]
    ([Townhall_Id]);
GO

-- Creating foreign key on [Unit_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_UserUnits]
    FOREIGN KEY ([Unit_Id])
    REFERENCES [dbo].[Units]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUnits'
CREATE INDEX [IX_FK_UserUnits]
ON [dbo].[Users]
    ([Unit_Id]);
GO

INSERT INTO Storages(maxResource, cost, level) VALUES ('200','50','1');
INSERT INTO Storages(maxResource, cost, level) VALUES ('400','100','2');
INSERT INTO Storages(maxResource, cost, level) VALUES ('800','200','3');
INSERT INTO Storages(maxResource, cost, level) VALUES ('1600','400','4');
INSERT INTO Storages(maxResource, cost, level) VALUES ('3200','800','5');
INSERT INTO Barracks(maxUnits, cost, level, unitCost) VALUES ('10','50','1','10');
INSERT INTO Barracks(maxUnits, cost, level, unitCost) VALUES ('20','100','2','8');
INSERT INTO Barracks(maxUnits, cost, level, unitCost) VALUES ('40','200','3','6');
INSERT INTO Barracks(maxUnits, cost, level, unitCost) VALUES ('80','400','4','4');
INSERT INTO Barracks(maxUnits, cost, level, unitCost) VALUES ('160','800','5','2');
INSERT INTO Townhalls(cost, level, population, PPH) VALUES ('50','1','5','1');
INSERT INTO Townhalls(cost, level, population, PPH) VALUES ('100','2','10','2');
INSERT INTO Townhalls(cost, level, population, PPH) VALUES ('200','3','20','4');
INSERT INTO Townhalls(cost, level, population, PPH) VALUES ('400','4','40','8');
INSERT INTO Townhalls(cost, level, population, PPH) VALUES ('800','5','80','16');
INSERT INTO Clays(PPH, cost, level) VALUES ('5','50','1');
INSERT INTO Clays(PPH, cost, level) VALUES ('10','100','2');
INSERT INTO Clays(PPH, cost, level) VALUES ('20','200','3');
INSERT INTO Clays(PPH, cost, level) VALUES ('40','400','4');
INSERT INTO Clays(PPH, cost, level) VALUES ('80','800','5');
INSERT INTO Woods(PPH, cost, level) VALUES ('5','50','1');
INSERT INTO Woods(PPH, cost, level) VALUES ('10','100','2');
INSERT INTO Woods(PPH, cost, level) VALUES ('20','200','3');
INSERT INTO Woods(PPH, cost, level) VALUES ('40','400','4');
INSERT INTO Woods(PPH, cost, level) VALUES ('80','800','5');
INSERT INTO Irons(PPH, cost, level) VALUES ('5','50','1');
INSERT INTO Irons(PPH, cost, level) VALUES ('10','100','2');
INSERT INTO Irons(PPH, cost, level) VALUES ('20','200','3');
INSERT INTO Irons(PPH, cost, level) VALUES ('40','400','4');
INSERT INTO Irons(PPH, cost, level) VALUES ('80','800','5');
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------