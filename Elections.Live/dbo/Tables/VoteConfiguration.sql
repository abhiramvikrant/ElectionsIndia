CREATE TABLE [dbo].[VoteConfiguration] (
    [VoteConfigurationId]  INT              IDENTITY (1, 1) NOT NULL,
    [CandidateId]          INT              NOT NULL,
    [CountryId]            INT              NULL,
    [StateId]              INT              NULL,
    [DistrictId]           INT              NULL,
    [AreaiD]               INT              NULL,
    [WardId]               INT              NULL,
    [BoothId]              INT              NULL,
    [KioskId]              INT              NULL,
    [ElectionTypeId]       INT              NULL,
    [VoteConfigurationUID] UNIQUEIDENTIFIER CONSTRAINT [DF__VoteConfi__VoteC__2D12A970] DEFAULT (newid()) NULL,
    [PoliticalPartyId]     INT              NULL,
    CONSTRAINT [PK_VoteConfiguration] PRIMARY KEY CLUSTERED ([VoteConfigurationId] ASC)
);

