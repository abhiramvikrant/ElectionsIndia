CREATE TABLE [dbo].[ElectionResult] (
    [ElectionResultID] INT      IDENTITY (1, 1) NOT NULL,
    [CountryID]        INT      NOT NULL,
    [StateID]          INT      NOT NULL,
    [AreaID]           INT      NOT NULL,
    [WardID]           INT      NOT NULL,
    [CandidateID]      INT      NOT NULL,
    [PoliticalPartyID] INT      NOT NULL,
    [UserID]           INT      NULL,
    [ElectionTypeID]   INT      NOT NULL,
    [VoteCastedON]     DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([ElectionResultID] ASC),
    CONSTRAINT [FK_ElectionResult_Areas] FOREIGN KEY ([AreaID]) REFERENCES [dbo].[Areas] ([AreaID]),
    CONSTRAINT [FK_ElectionResult_Candidates] FOREIGN KEY ([CandidateID]) REFERENCES [dbo].[Candidates] ([CandidateID]),
    CONSTRAINT [FK_ElectionResult_Countries] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[Countries] ([CountryId]),
    CONSTRAINT [FK_ElectionResult_States] FOREIGN KEY ([StateID]) REFERENCES [dbo].[States] ([StateID])
);

