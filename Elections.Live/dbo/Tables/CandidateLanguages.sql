CREATE TABLE [dbo].[CandidateLanguages] (
    [CandidateLanguagesID] INT            IDENTITY (1, 1) NOT NULL,
    [CandidateID]          INT            NOT NULL,
    [Name]                 NVARCHAR (100) NOT NULL,
    [IsActive]             BIT            NOT NULL,
    [LanguageID]           INT            NOT NULL,
    [DateOFBirth]          DATETIME       NOT NULL,
    [MobileNumber]         NVARCHAR (50)  NULL,
    [Address1]             NVARCHAR (100) NULL,
    [Address2]             NVARCHAR (100) NULL,
    [Education]            NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([CandidateLanguagesID] ASC)
);

