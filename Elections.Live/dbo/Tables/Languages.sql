CREATE TABLE [dbo].[Languages] (
    [LanguageID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [IsActive]   BIT            CONSTRAINT [DF_Languages_IsActive] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED ([LanguageID] ASC)
);

