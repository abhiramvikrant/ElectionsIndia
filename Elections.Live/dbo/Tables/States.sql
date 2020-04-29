CREATE TABLE [dbo].[States] (
    [StateID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [IsActive]  BIT            CONSTRAINT [DF_States_IsActive] DEFAULT ((0)) NOT NULL,
    [CountryID] INT            NULL,
    [IsUT]      BIT            CONSTRAINT [DF_States_IsUT] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED ([StateID] ASC)
);





