CREATE TABLE [dbo].[Areas] (
    [AreaID]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [IsActive]  BIT            NOT NULL,
    [CountryID] INT            NOT NULL,
    [StateID]   INT            NOT NULL,
    CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED ([AreaID] ASC)
);

