CREATE TABLE [dbo].[PoliticalPartyLanguages] (
    [PoliticalPartyLanguageID] INT            IDENTITY (1, 1) NOT NULL,
    [LanguageID]               INT            NOT NULL,
    [Name]                     NVARCHAR (100) NOT NULL,
    [StateID]                  INT            NULL,
    [EnglishPartyID]           INT            NOT NULL,
    [PartyPhotoPath]           NVARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([PoliticalPartyLanguageID] ASC),
    FOREIGN KEY ([LanguageID]) REFERENCES [dbo].[Languages] ([LanguageID]),
    FOREIGN KEY ([StateID]) REFERENCES [dbo].[States] ([StateID])
);

