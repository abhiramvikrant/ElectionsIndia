CREATE TABLE [dbo].[Districts] (
    [DistrictID]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (100) NOT NULL,
    [IsActive]            BIT            NOT NULL,
    [StateID]             INT            NOT NULL,
    [CountryID]           INT            NULL,
    [StateLanguageName]   NVARCHAR (100) NULL,
    [StateLanguageName_1] NVARCHAR (100) NULL,
    [StateLanguageName_2] NVARCHAR (100) NULL,
    [StateLanguageName_3] NVARCHAR (100) NULL,
    [StateLanguagename_4] NVARCHAR (100) NULL,
    [StateLanguageName_5] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Districts] PRIMARY KEY CLUSTERED ([DistrictID] ASC)
);

