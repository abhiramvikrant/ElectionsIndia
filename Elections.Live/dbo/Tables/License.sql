CREATE TABLE [dbo].[License] (
    [LicenseID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_License] PRIMARY KEY CLUSTERED ([LicenseID] ASC),
    CONSTRAINT [FK_License_Voters] FOREIGN KEY ([LicenseID]) REFERENCES [dbo].[Voters] ([VoterID])
);

