CREATE TABLE [dbo].[Genre] (
    [Id]   INT           NOT NULL IDENTITY,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED ([Id] ASC)
);

