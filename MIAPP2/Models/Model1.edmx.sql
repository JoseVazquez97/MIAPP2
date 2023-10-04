
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/04/2023 16:24:21
-- Generated from EDMX file: D:\Viru\repos Pc vieja\MIAPP2\MIAPP2\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PARTIDOSYA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[USUARIO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[USUARIO];
GO
IF OBJECT_ID(N'[dbo].[USUARIO2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[USUARIO2];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'USUARIO'
CREATE TABLE [dbo].[USUARIO] (
    [UsuarioID] bigint IDENTITY(1,1) NOT NULL,
    [UsuarioNick] varchar(24)  NOT NULL,
    [UsuarioPass] varchar(24)  NOT NULL,
    [UsuarioTipo] varchar(1)  NOT NULL,
    [UsuarioEstado] varchar(1)  NOT NULL
);
GO

-- Creating table 'USUARIO2'
CREATE TABLE [dbo].[USUARIO2] (
    [Usuario2ID] bigint IDENTITY(1,1) NOT NULL,
    [Usuario2Nick] varchar(24)  NOT NULL,
    [Usuario2Pass] varchar(24)  NOT NULL,
    [Usuario2Tipo] varchar(1)  NOT NULL,
    [Usuario2Estado] varchar(1)  NOT NULL,
    [Usuario2Fecha] varchar(1)  NOT NULL,
    [Usuario2Status] varchar(1)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [UsuarioID] in table 'USUARIO'
ALTER TABLE [dbo].[USUARIO]
ADD CONSTRAINT [PK_USUARIO]
    PRIMARY KEY CLUSTERED ([UsuarioID] ASC);
GO

-- Creating primary key on [Usuario2ID] in table 'USUARIO2'
ALTER TABLE [dbo].[USUARIO2]
ADD CONSTRAINT [PK_USUARIO2]
    PRIMARY KEY CLUSTERED ([Usuario2ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------