CREATE TABLE [dbo].[AreaTypes] (
    [AreaTypeID]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (100) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF_AreaTypes_IsActive] DEFAULT ((0)) NOT NULL,
    [CreatedOn]        DATETIME       NOT NULL,
    [CreatedBy]        INT            NOT NULL,
    [AreaTypeUniqueID] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_AreaTypes] PRIMARY KEY CLUSTERED ([AreaTypeID] ASC)
);

