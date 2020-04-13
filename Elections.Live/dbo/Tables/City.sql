CREATE TABLE [dbo].[City] (
    [CityID]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (100) NOT NULL,
    [IsActive]            BIT            NOT NULL,
    [DistrictID]          INT            NOT NULL,
    [StateLanguageName]   NVARCHAR (100) NULL,
    [StateLanguageName_1] NVARCHAR (100) NULL,
    [StateLanguageName_2] NVARCHAR (100) NULL,
    [StateLanguageName_3] NVARCHAR (100) NULL,
    [StateLanguagename_4] NVARCHAR (100) NULL,
    [StateLanguageName_5] NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([CityID] ASC),
    FOREIGN KEY ([DistrictID]) REFERENCES [dbo].[Districts] ([DistrictID])
);

