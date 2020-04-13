CREATE TABLE [dbo].[Candidates] (
    [CandidateID]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (100) NOT NULL,
    [IsActive]           BIT            NOT NULL,
    [CountryID]          INT            NOT NULL,
    [StateID]            INT            NOT NULL,
    [AreaID]             INT            NOT NULL,
    [WardID]             INT            NOT NULL,
    [LanguageID]         INT            NOT NULL,
    [DateOFBirth]        DATETIME       NOT NULL,
    [MobileNumber]       NVARCHAR (50)  NULL,
    [HasCriminalRecords] BIT            DEFAULT ((0)) NOT NULL,
    [Address1]           NVARCHAR (100) NULL,
    [Address2]           NVARCHAR (100) NULL,
    [Email]              NVARCHAR (100) NULL,
    [PhotoURL]           NVARCHAR (255) NULL,
    [PropertyValue]      DECIMAL (18)   NOT NULL,
    [PoliticalPartyID]   INT            NULL,
    [Education]          NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Candidates] PRIMARY KEY CLUSTERED ([CandidateID] ASC),
    CONSTRAINT [FK_Candidates_Areas] FOREIGN KEY ([AreaID]) REFERENCES [dbo].[Areas] ([AreaID])
);

