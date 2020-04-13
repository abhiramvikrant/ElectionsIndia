CREATE TABLE [dbo].[ElectionType] (
    [ElectionTypeID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (100) NOT NULL,
    [IsActive]       BIT            CONSTRAINT [DF_ElectionType_IsActive] DEFAULT ((0)) NOT NULL,
    [CreatedBy]      INT            NOT NULL,
    [CreatedOn]      DATETIME       NOT NULL,
    [CountryID]      INT            NOT NULL,
    CONSTRAINT [PK_ElectionType] PRIMARY KEY CLUSTERED ([ElectionTypeID] ASC)
);

