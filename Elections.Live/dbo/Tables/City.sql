CREATE TABLE [dbo].[City] (
    [CityID]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [IsActive]   BIT            NOT NULL,
    [DistrictID] INT            NULL,
    PRIMARY KEY CLUSTERED ([CityID] ASC)
);



