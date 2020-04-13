CREATE TABLE [dbo].[ElectionSetup] (
    [ElectionSetupID]  INT            IDENTITY (1, 1) NOT NULL,
    [ElectionDate]     DATETIME       NOT NULL,
    [ElecxtionName]    NVARCHAR (100) NOT NULL,
    [CountryID]        INT            NOT NULL,
    [StateID]          INT            NOT NULL,
    [ElectionComplete] BIT            NOT NULL,
    [ElectionTypeID]   INT            NOT NULL,
    [ElectionStarted]  BIT            NOT NULL,
    [StartedOn]        DATETIME       NOT NULL,
    CONSTRAINT [PK_ElectionSetup] PRIMARY KEY CLUSTERED ([ElectionSetupID] ASC)
);

