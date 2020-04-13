CREATE TABLE [dbo].[Elections] (
    [ElectionID]     INT      IDENTITY (1, 1) NOT NULL,
    [ElectionTypeID] INT      NULL,
    [ElectionDate]   DATETIME NULL,
    [CountryID]      INT      NOT NULL,
    [StateID]        INT      NOT NULL,
    [WardID]         INT      NOT NULL,
    [AreaID]         INT      NOT NULL,
    CONSTRAINT [PK_Elections] PRIMARY KEY CLUSTERED ([ElectionID] ASC),
    CONSTRAINT [FK_Elections_Areas] FOREIGN KEY ([AreaID]) REFERENCES [dbo].[Areas] ([AreaID]),
    CONSTRAINT [FK_Elections_Countries] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[Countries] ([CountryId]),
    CONSTRAINT [FK_Elections_ElectionType] FOREIGN KEY ([ElectionTypeID]) REFERENCES [dbo].[ElectionType] ([ElectionTypeID]),
    CONSTRAINT [FK_Elections_States] FOREIGN KEY ([StateID]) REFERENCES [dbo].[States] ([StateID])
);

