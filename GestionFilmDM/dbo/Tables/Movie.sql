CREATE TABLE [dbo].[Movie] (
    [Id]          INT            NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Duration]    INT            NULL,
    [ReleaseDate] DATE           NULL,
    [Note]        TINYINT        NULL,
    [Data]        NVARCHAR (MAX) NOT NULL,
    [Poster]      NVARCHAR (MAX) NULL,
    [Viewed]      BIT            NOT NULL,
    [Genre]       INT            NOT NULL,
    [AddDate] DATE NOT NULL DEFAULT CURRENT_TIMESTAMP, 
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Movie_Genre] FOREIGN KEY ([Genre]) REFERENCES [dbo].[Genre] ([Id])
);

