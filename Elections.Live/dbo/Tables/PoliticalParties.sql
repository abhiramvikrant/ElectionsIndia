CREATE TABLE [dbo].[PoliticalParties] (
    [PoliticalPartyID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (100) NULL,
    [CountryID]        INT            NOT NULL,
    [ShortName]        NVARCHAR (10)  NULL,
    [IsActive]         BIT            CONSTRAINT [DF_PoliticalParties_IsActive] DEFAULT ((1)) NULL,
    PRIMARY KEY CLUSTERED ([PoliticalPartyID] ASC)
);

