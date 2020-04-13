CREATE TABLE [dbo].[ElectionParties] (
    [ElectionParties]  INT IDENTITY (1, 1) NOT NULL,
    [PoliticalPartyID] INT NOT NULL,
    CONSTRAINT [PK_ElectionParties] PRIMARY KEY CLUSTERED ([ElectionParties] ASC)
);

