CREATE TABLE [dbo].[CandidateLicenses] (
    [CandidateLicenseID] INT            IDENTITY (1, 1) NOT NULL,
    [CandidateID]        INT            NOT NULL,
    [LicenseID]          INT            NOT NULL,
    [LicenseUploadURL]   NVARCHAR (255) NULL,
    CONSTRAINT [PK_CandidateLicenses] PRIMARY KEY CLUSTERED ([CandidateLicenseID] ASC),
    CONSTRAINT [FK_CandidateLicenses_Candidates] FOREIGN KEY ([CandidateID]) REFERENCES [dbo].[Candidates] ([CandidateID])
);

