CREATE TABLE [dbo].[Voters] (
    [VoterID]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100) NULL,
    [CountryID]   INT            NOT NULL,
    [StateID]     INT            NOT NULL,
    [WardID]      INT            NOT NULL,
    [DateOfBirth] DATETIME       NULL,
    [LicenseID]   INT            NULL,
    PRIMARY KEY CLUSTERED ([VoterID] ASC),
    CONSTRAINT [FK_Voters_Countries] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[Countries] ([CountryId]),
    CONSTRAINT [FK_Voters_States] FOREIGN KEY ([StateID]) REFERENCES [dbo].[States] ([StateID])
);

