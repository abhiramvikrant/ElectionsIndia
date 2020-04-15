/****** Object:  View [dbo].[VW_CityWithActive]    Script Date: 15-Apr-20 8:35:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VW_CityWithActive]
AS
SELECT        Name, CityID
FROM            dbo.City
WHERE        (IsActive = 1)

GO



