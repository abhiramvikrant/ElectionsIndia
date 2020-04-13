CREATE TABLE [dbo].[CountryLanguages] (
    [CountryLanguageID] INT            IDENTITY (1, 1) NOT NULL,
    [LanguageID]        INT            NOT NULL,
    [CountryID]         INT            NOT NULL,
    [Name]              NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_CountryLanguages] PRIMARY KEY CLUSTERED ([CountryLanguageID] ASC),
    CONSTRAINT [FK_CountryLanguages_Countries] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[Countries] ([CountryId])
);

