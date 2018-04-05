/*
Script de déploiement pour GestionFilm

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "GestionFilm"
:setvar DefaultFilePrefix "GestionFilm"
:setvar DefaultDataPath "D:\Programmes\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "D:\Programmes\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Suppression de contrainte sans nom sur [dbo].[Movie]...';


GO
ALTER TABLE [dbo].[Movie] DROP CONSTRAINT [DF__Movie__AddDate__3D5E1FD2];


GO
PRINT N'Suppression de [dbo].[FK_Movie_Genre]...';


GO
ALTER TABLE [dbo].[Movie] DROP CONSTRAINT [FK_Movie_Genre];


GO
PRINT N'Début de la régénération de la table [dbo].[Genre]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Genre] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Genre1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Genre])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Genre] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Genre] ([Id], [Name])
        SELECT   [Id],
                 [Name]
        FROM     [dbo].[Genre]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Genre] OFF;
    END

DROP TABLE [dbo].[Genre];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Genre]', N'Genre';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Genre1]', N'PK_Genre', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Début de la régénération de la table [dbo].[Movie]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Movie] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Duration]    INT            NULL,
    [ReleaseDate] DATE           NULL,
    [Note]        TINYINT        NULL,
    [Data]        NVARCHAR (MAX) NOT NULL,
    [Poster]      NVARCHAR (MAX) NULL,
    [Viewed]      BIT            NOT NULL,
    [Genre_Id]    INT            NOT NULL,
    [AddDate]     DATE           DEFAULT CURRENT_TIMESTAMP NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Movie1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Movie])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Movie] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Movie] ([Id], [Name], [Duration], [ReleaseDate], [Note], [Data], [Poster], [Viewed], [Genre_Id], [AddDate])
        SELECT   [Id],
                 [Name],
                 [Duration],
                 [ReleaseDate],
                 [Note],
                 [Data],
                 [Poster],
                 [Viewed],
                 [Genre_Id],
                 [AddDate]
        FROM     [dbo].[Movie]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Movie] OFF;
    END

DROP TABLE [dbo].[Movie];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Movie]', N'Movie';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Movie1]', N'PK_Movie', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Création de [dbo].[FK_Movie_Genre]...';


GO
ALTER TABLE [dbo].[Movie] WITH NOCHECK
    ADD CONSTRAINT [FK_Movie_Genre] FOREIGN KEY ([Genre_Id]) REFERENCES [dbo].[Genre] ([Id]);


GO
PRINT N'Vérification de données existantes par rapport aux nouvelles contraintes';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Movie] WITH CHECK CHECK CONSTRAINT [FK_Movie_Genre];


GO
PRINT N'Mise à jour terminée.';


GO
