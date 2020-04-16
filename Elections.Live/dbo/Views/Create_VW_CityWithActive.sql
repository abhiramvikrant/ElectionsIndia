/****** Object:  View [dbo].[VW_CityWithActive]    Script Date: 15-Apr-20 8:35:57 AM ******/


CREATE VIEW [dbo].[VW_CityWithActive]
AS
SELECT        Name, CityID
FROM            dbo.City
WHERE        (IsActive = 1)

GO



