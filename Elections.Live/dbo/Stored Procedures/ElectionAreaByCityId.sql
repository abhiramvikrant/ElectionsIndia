-- =============================================
-- Author:		Vikrant
-- Create date: 08-April-2020
-- Description:	This procedure gets both assinged and non-assigned ElectionAreas
-- Modified: 
-- =============================================
CREATE PROCEDURE [dbo].ElectionAreaByCityId(@CityId INT)
AS
     SET NOCOUNT OFF
    BEGIN
        SELECT a.ElectionAreaID, 
               a.Name,
			   a.IsActive,
               ISNULL(a.CityId, -1) AS CityId,
               CASE
                   WHEN a.CityId = @CityId
                   THEN CONVERT(BIT, 1)
                   WHEN(ISNULL(a.CityId, 0) = 0)
                   THEN CONVERT(BIT, 0)
               END AS BelongsToCity, 
               ISNULL(c.Name, '') AS City, 
               -1 AS InitialCityId,
               '' AS InitialCityName
        FROM ElectionArea a
             LEFT OUTER JOIN  City c ON a.CityId = c.CityID
        WHERE(a.CityId = @CityId
              OR ISNULL(a.CityId, 0) = 0)
             AND a.IsActive = 1
    END

	/**
	EXEC [ElectionAreaByCityId] 1
	**/