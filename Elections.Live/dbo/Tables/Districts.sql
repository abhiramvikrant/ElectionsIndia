CREATE TABLE [dbo].[Districts] (
    [DistrictID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [IsActive]   BIT            NOT NULL,
    [StateId]    INT            NULL,
    CONSTRAINT [PK_Districts] PRIMARY KEY CLUSTERED ([DistrictID] ASC)
);







