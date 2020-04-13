CREATE TABLE [dbo].[EletionTypeLanguages] (
    [ElectionTypeLanguageID] INT            IDENTITY (1, 1) NOT NULL,
    [LanguageID]             INT            NOT NULL,
    [CountryID]              INT            NOT NULL,
    [Name]                   NVARCHAR (100) NOT NULL,
    [ElectionTypeID]         INT            NOT NULL,
    CONSTRAINT [PK_EletionTypeLanguages] PRIMARY KEY CLUSTERED ([ElectionTypeLanguageID] ASC),
    CONSTRAINT [FK_EletionTypeLanguages_Languages] FOREIGN KEY ([LanguageID]) REFERENCES [dbo].[Languages] ([LanguageID])
);

