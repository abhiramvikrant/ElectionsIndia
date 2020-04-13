CREATE TABLE [dbo].[VoteResult] (
    [VoteResultId]     INT              IDENTITY (1, 1) NOT NULL,
    [CandidateId]      INT              NOT NULL,
    [CountryId]        INT              NULL,
    [StateId]          INT              NULL,
    [DistrictId]       INT              NULL,
    [AreaiD]           INT              NULL,
    [WardId]           INT              NULL,
    [BoothId]          INT              NULL,
    [KioskId]          INT              NULL,
    [ElectionTypeId]   INT              NULL,
    [PoliticalPartyId] INT              NULL,
    [VoteResultUID]    UNIQUEIDENTIFIER DEFAULT (newid()) NULL,
    PRIMARY KEY CLUSTERED ([VoteResultId] ASC)
);

