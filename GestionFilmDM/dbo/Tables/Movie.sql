CREATE TABLE [dbo].[Movie] (
    [Id]          INT            NOT NULL IDENTITY,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Duration]    INT            NULL,
    [ReleaseDate] DATE           NULL,
    [Note]        TINYINT        NULL,
    [Data]        NVARCHAR (MAX) NOT NULL,
    [Poster]      NVARCHAR (MAX) NULL,
    [Viewed]      BIT            NOT NULL,
    [Genre_Id]       INT            NOT NULL,
    [AddDate] DATE NOT NULL DEFAULT CURRENT_TIMESTAMP, 
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Movie_Genre] FOREIGN KEY ([Genre_Id]) REFERENCES [dbo].[Genre] ([Id])
);

