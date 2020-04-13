CREATE TABLE [dbo].[AreaTypeLanguages] (
    [AreaTypeLanguageID] INT            IDENTITY (1, 1) NOT NULL,
    [LanguageID]         INT            NOT NULL,
    [AreaTypeID]         INT            NOT NULL,
    [Name]               NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([AreaTypeLanguageID] ASC),
    CONSTRAINT [FK_AreaTypeLanguages_AreaTypes] FOREIGN KEY ([AreaTypeID]) REFERENCES [dbo].[AreaTypes] ([AreaTypeID])
);

