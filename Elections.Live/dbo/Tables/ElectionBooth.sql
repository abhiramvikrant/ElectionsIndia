CREATE TABLE [dbo].[ElectionBooth] (
    [ElectionBoothID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (100) NOT NULL,
    [IsActive]        BIT            NOT NULL,
    [ElectionWardID]  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([ElectionBoothID] ASC),
    FOREIGN KEY ([ElectionWardID]) REFERENCES [dbo].[ElectionWard] ([ElectionWardID])
);

