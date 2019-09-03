DELETE FROM LIKE_POST;
DELETE FROM PUBLICACIONES;
DELETE FROM USERS;






-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/02/2019 14:59:24
-- Generated from EDMX file: C:\Users\CDS12\source\repos\BrotApi0\BrotApi0\Models\BROT_FK.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BorrarDB_Brot];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_like_post]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[like_post] DROP CONSTRAINT [FK_like_post];
GO
IF OBJECT_ID(N'[dbo].[FK_Like_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[like_post] DROP CONSTRAINT [FK_Like_user];
GO
IF OBJECT_ID(N'[dbo].[FK_post_user_creator]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[publicaciones] DROP CONSTRAINT [FK_post_user_creator];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[like_post]', 'U') IS NOT NULL
    DROP TABLE [dbo].[like_post];
GO
IF OBJECT_ID(N'[dbo].[publicaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[publicaciones];
GO
IF OBJECT_ID(N'[dbo].[users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'publicaciones'
CREATE TABLE [dbo].[publicaciones] (
    [id_post] int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [id_user] int  NULL,
    [img] varchar(100)  NULL,
    [descripcion] varchar(300)  NULL,
    [fecha_creacion] datetime  NULL,
    [fecha_actualizacion] datetime  NULL
);
GO

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [id_user] int PRIMARY KEY IDENTITY(1,1) NOT NULL ,
    [username] varchar(50)  NULL,
    [nombre] varchar(50)  NULL,
    [apellido] varchar(50)  NULL,
    [descripcion] varchar(300)  NULL,
    [pass] varchar(50)  NULL,
    [isVendor] bit  NULL,
    [puntaje] int  NULL,
    [email] varchar(50)  NULL
);
GO

CREATE TABLE [dbo].[datos_vendedor] (
    id_datos_vendedor int PRIMARY KEY IDENTITY(1,1) NOT NULL ,
    xlat REAL  NULL,
    ylon REAL  NULL,
    isActive bit  NULL,
    dui varchar(300)  NULL,
    num_telefono varchar(50)  NULL,
    id_user int  NULL,
    descripcion int  NULL
);
GO

CREATE TABLE [dbo].[like_comentario](
	id_like_comentario int primary key not null identity(1,1),
	id_user int,
	comentario_id int
);
GO

CREATE TABLE [dbo].[seguidores](
	id_seguidores int Primary key not null IDENTITY(1,1),
	seguidor_id int,
	seguido_id int,
	accepted bit,
);
GO

-- Creating table 'like_post'
CREATE TABLE [dbo].[like_post] (
    [id] int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [id_user] int  NOT NULL,
    [id_post] int  NOT NULL
);
GO


CREATE TABLE [dbo].[comentarios](
	id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	id_user int NOT NULL,
	id_post int NOT NULL,
	contenido varchar(200) NOT NULL,
	fecha_creacion datetime not null

);
GO







-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [user_id] in table 'publicaciones' ---eL QUE CREO LA PUBLICACION
ALTER TABLE [dbo].[publicaciones]
ADD CONSTRAINT [FK_post_user_creator]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[users]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_post_user_creator' 
CREATE INDEX [IX_FK_post_user_creator]
ON [dbo].[publicaciones]
    ([user_id]);
GO

-- Creating foreign key on [post_id] in table 'like_post' ---
ALTER TABLE [dbo].[like_post]
ADD CONSTRAINT [FK_like_post]
    FOREIGN KEY ([post_id])
    REFERENCES [dbo].[publicaciones]
        ([post_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_like_post'
--CREATE INDEX [IX_FK_like_post]
--ON [dbo].[like_post]
--    ([post_id]);
--GO

-- Creating foreign key on [user_id] in table 'like_post'


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------




SELECT * FROM USERS;

SELECT * FROM PUBLICACIONES;

SELECT * FROM like_post;
