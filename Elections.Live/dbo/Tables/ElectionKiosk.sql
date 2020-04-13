CREATE TABLE [dbo].[ElectionKiosk] (
    [ElectionKioskID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (100) NOT NULL,
    [IsActive]        BIT            NOT NULL,
    [ElectionBoothId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([ElectionKioskID] ASC),
    FOREIGN KEY ([ElectionBoothId]) REFERENCES [dbo].[ElectionBooth] ([ElectionBoothID])
);

