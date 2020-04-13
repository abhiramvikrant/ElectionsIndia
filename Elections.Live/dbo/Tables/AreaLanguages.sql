CREATE TABLE [dbo].[AreaLanguages] (
    [AreaLanguageID] INT            IDENTITY (1, 1) NOT NULL,
    [LanguageID]     INT            NOT NULL,
    [AreaID]         INT            NOT NULL,
    [Name]           NVARCHAR (100) NOT NULL,
    [CountryID]      INT            NULL,
    [StateID]        INT            NULL,
    PRIMARY KEY CLUSTERED ([AreaLanguageID] ASC),
    CONSTRAINT [FK_AreaLanguages_Areas] FOREIGN KEY ([AreaID]) REFERENCES [dbo].[Areas] ([AreaID])
);

