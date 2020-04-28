CREATE TABLE [dbo].[KiokAdmin] (
    [KioskAdminId] INT            IDENTITY (1, 1) NOT NULL,
    [UserId]       NVARCHAR (500) NULL,
    [IsActive]     BIT            NOT NULL,
    [KioskId]      INT            NOT NULL,
    [BoothId]      INT            NOT NULL,
    [CountryId]    INT            NULL,
    [StateId]      INT            NULL,
    [DistrictID]   INT            NULL,
    [CityId]       INT            NULL,
    [AreaId]       INT            NULL,
    [WardId]       INT            NULL,
    PRIMARY KEY CLUSTERED ([KioskAdminId] ASC)
);

