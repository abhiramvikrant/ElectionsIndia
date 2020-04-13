CREATE TABLE [dbo].[StateLanguages] (
    [StateLanguagesID] INT            IDENTITY (1, 1) NOT NULL,
    [LanguageID]       INT            NOT NULL,
    [StateID]          INT            NOT NULL,
    [Name]             NVARCHAR (100) NOT NULL,
    [CountryID]        INT            NULL,
    [IsActive]         BIT            NULL,
    CONSTRAINT [PK_StateLanguages] PRIMARY KEY CLUSTERED ([StateLanguagesID] ASC),
    CONSTRAINT [FK_StateLanguages_States] FOREIGN KEY ([StateID]) REFERENCES [dbo].[States] ([StateID])
);

