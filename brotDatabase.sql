
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/06/2019 19:59:25
-- Generated from EDMX file: R:\Xamarin\BrotAPI\BROT_API3\Models\Model1.edmx
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

IF OBJECT_ID(N'[dbo].[fk_comentarios_post]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[comentarios] DROP CONSTRAINT [fk_comentarios_post];
GO
IF OBJECT_ID(N'[dbo].[fk_like_comentario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[like_comentario] DROP CONSTRAINT [fk_like_comentario];
GO
IF OBJECT_ID(N'[dbo].[fk_like_comentario_users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[like_comentario] DROP CONSTRAINT [fk_like_comentario_users];
GO
IF OBJECT_ID(N'[dbo].[FK_like_post]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[like_post] DROP CONSTRAINT [FK_like_post];
GO
IF OBJECT_ID(N'[dbo].[FK_Like_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[like_post] DROP CONSTRAINT [FK_Like_user];
GO
IF OBJECT_ID(N'[dbo].[FK_post_user_creator]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[publicaciones] DROP CONSTRAINT [FK_post_user_creator];
GO
IF OBJECT_ID(N'[dbo].[fk_seguidores_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[seguidores] DROP CONSTRAINT [fk_seguidores_user];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[comentarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[comentarios];
GO
IF OBJECT_ID(N'[dbo].[like_comentario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[like_comentario];
GO
IF OBJECT_ID(N'[dbo].[like_post]', 'U') IS NOT NULL
    DROP TABLE [dbo].[like_post];
GO
IF OBJECT_ID(N'[dbo].[publicaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[publicaciones];
GO
IF OBJECT_ID(N'[dbo].[seguidores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[seguidores];
GO
IF OBJECT_ID(N'[dbo].[users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'comentarios'
CREATE TABLE [dbo].[comentarios] (
    [id_comentario] int IDENTITY(1,1) NOT NULL,
    [id_user] int  NOT NULL,
    [id_post] int  NOT NULL,
    [contenido] varchar(200)  NOT NULL,
    [fecha_creacion] datetime  NULL
);
GO

-- Creating table 'like_comentario'
CREATE TABLE [dbo].[like_comentario] (
    [id_like_comentario] int IDENTITY(1,1) NOT NULL,
    [id_user] int  NOT NULL,
    [id_comentario] int  NOT NULL,
    [fecha] datetime  NULL
);
GO

-- Creating table 'like_post'
CREATE TABLE [dbo].[like_post] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_user] int  NOT NULL,
    [id_post] int  NOT NULL,
    [fecha] datetime  NULL
);
GO

-- Creating table 'publicaciones'
CREATE TABLE [dbo].[publicaciones] (
    [id_post] int IDENTITY(1,1) NOT NULL,
    [id_user] int  NOT NULL,
    [img] varchar(100)  NULL,
    [isImg] bit  NULL,
    [descripcion] varchar(300)  NULL,
    [fecha_creacion] datetime  NULL,
    [fecha_actualizacion] datetime  NULL
);
GO

-- Creating table 'seguidores'
CREATE TABLE [dbo].[seguidores] (
    [id_seguidores] int IDENTITY(1,1) NOT NULL,
    [seguidor_id] int  NOT NULL,
    [id_seguido] int  NOT NULL,
    [accepted] bit  NOT NULL,
    [fecha] datetime  NULL
);
GO

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [id_user] int IDENTITY(1,1) NOT NULL,
    [username] varchar(50)  NOT NULL,
    [nombre] varchar(50)  NULL,
    [apellido] varchar(50)  NULL,
    [descripcion] varchar(200)  NULL,
    [pass] varchar(50)  NULL,
    [isVendor] bit  NULL,
    [puntaje] int  NULL,
    [email] varchar(50)  NULL,
    [xlat] real  NULL,
    [ylon] real  NULL,
    [isActive] smallint  NULL,
    [dui] varchar(15)  NULL,
    [num_telefono] varchar(15)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id_comentario] in table 'comentarios'
ALTER TABLE [dbo].[comentarios]
ADD CONSTRAINT [PK_comentarios]
    PRIMARY KEY CLUSTERED ([id_comentario] ASC);
GO

-- Creating primary key on [id_like_comentario] in table 'like_comentario'
ALTER TABLE [dbo].[like_comentario]
ADD CONSTRAINT [PK_like_comentario]
    PRIMARY KEY CLUSTERED ([id_like_comentario] ASC);
GO

-- Creating primary key on [id] in table 'like_post'
ALTER TABLE [dbo].[like_post]
ADD CONSTRAINT [PK_like_post]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id_post] in table 'publicaciones'
ALTER TABLE [dbo].[publicaciones]
ADD CONSTRAINT [PK_publicaciones]
    PRIMARY KEY CLUSTERED ([id_post] ASC);
GO

-- Creating primary key on [id_seguidores] in table 'seguidores'
ALTER TABLE [dbo].[seguidores]
ADD CONSTRAINT [PK_seguidores]
    PRIMARY KEY CLUSTERED ([id_seguidores] ASC);
GO

-- Creating primary key on [id_user] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([id_user] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_post] in table 'comentarios'
ALTER TABLE [dbo].[comentarios]
ADD CONSTRAINT [fk_comentarios_post]
    FOREIGN KEY ([id_post])
    REFERENCES [dbo].[publicaciones]
        ([id_post])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_comentarios_post'
CREATE INDEX [IX_fk_comentarios_post]
ON [dbo].[comentarios]
    ([id_post]);
GO

-- Creating foreign key on [id_comentario] in table 'like_comentario'
ALTER TABLE [dbo].[like_comentario]
ADD CONSTRAINT [fk_like_comentario]
    FOREIGN KEY ([id_comentario])
    REFERENCES [dbo].[comentarios]
        ([id_comentario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_like_comentario'
CREATE INDEX [IX_fk_like_comentario]
ON [dbo].[like_comentario]
    ([id_comentario]);
GO

-- Creating foreign key on [id_user] in table 'like_comentario'
ALTER TABLE [dbo].[like_comentario]
ADD CONSTRAINT [fk_like_comentario_users]
    FOREIGN KEY ([id_user])
    REFERENCES [dbo].[users]
        ([id_user])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_like_comentario_users'
CREATE INDEX [IX_fk_like_comentario_users]
ON [dbo].[like_comentario]
    ([id_user]);
GO

-- Creating foreign key on [id_post] in table 'like_post'
ALTER TABLE [dbo].[like_post]
ADD CONSTRAINT [FK_like_post]
    FOREIGN KEY ([id_post])
    REFERENCES [dbo].[publicaciones]
        ([id_post])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_like_post'
CREATE INDEX [IX_FK_like_post]
ON [dbo].[like_post]
    ([id_post]);
GO

-- Creating foreign key on [id_user] in table 'like_post'
ALTER TABLE [dbo].[like_post]
ADD CONSTRAINT [FK_Like_user]
    FOREIGN KEY ([id_user])
    REFERENCES [dbo].[users]
        ([id_user])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Like_user'
CREATE INDEX [IX_FK_Like_user]
ON [dbo].[like_post]
    ([id_user]);
GO

-- Creating foreign key on [id_user] in table 'publicaciones'
ALTER TABLE [dbo].[publicaciones]
ADD CONSTRAINT [FK_post_user_creator]
    FOREIGN KEY ([id_user])
    REFERENCES [dbo].[users]
        ([id_user])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_post_user_creator'
CREATE INDEX [IX_FK_post_user_creator]
ON [dbo].[publicaciones]
    ([id_user]);
GO

-- Creating foreign key on [seguidor_id] in table 'seguidores'
ALTER TABLE [dbo].[seguidores]
ADD CONSTRAINT [fk_seguidores_user]
    FOREIGN KEY ([seguidor_id])
    REFERENCES [dbo].[users]
        ([id_user])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_seguidores_user'
CREATE INDEX [IX_fk_seguidores_user]
ON [dbo].[seguidores]
    ([seguidor_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------