CREATE TABLE [dbo].[PoliticalPartyTranslation] (
    [PoliticalPartyTranslationId] INT            IDENTITY (1, 1) NOT NULL,
    [PartyId]                     INT            NOT NULL,
    [LanguageId]                  INT            NOT NULL,
    [PartyName]                   NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_PoliticalPartyTranslation] PRIMARY KEY CLUSTERED ([PoliticalPartyTranslationId] ASC)
);

