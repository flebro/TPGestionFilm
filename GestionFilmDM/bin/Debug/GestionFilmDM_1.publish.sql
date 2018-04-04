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
ALTER TABLE [dbo].[Movie] DROP CONSTRAINT [DF__Movie__AddDate__398D8EEE];


GO
PRINT N'Création de contrainte sans nom sur [dbo].[Movie]...';


GO
ALTER TABLE [dbo].[Movie]
    ADD DEFAULT CURRENT_TIMESTAMP FOR [AddDate];


GO
PRINT N'Mise à jour terminée.';


GO
