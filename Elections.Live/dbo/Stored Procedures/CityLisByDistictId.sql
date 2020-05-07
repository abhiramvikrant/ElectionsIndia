-- =============================================
-- Author:		Vikrant
-- Create date: 03-April-2020
-- Description:	This procedure gets both assinged and non-assigned cities
-- Modified: 
-- =============================================
CREATE PROCEDURE [dbo].[CityLisByDistictId](@DistrictId INT)
AS
     SET NOCOUNT OFF
    BEGIN
        SELECT c.CityID, 
               c.Name, 
			   c.IsActive,
               ISNULL(c.DistrictID, -1) AS DistrictID,
               CASE
                   WHEN c.DistrictID = @DistrictId
                   THEN CONVERT(BIT, 1)
                   WHEN(ISNULL(c.DistrictID, 0) = 0)
                   THEN CONVERT(BIT, 0)
               END AS BelongsToDistrict, 
               ISNULL(dist.Name, '') AS District, 
               -1 AS InitialDistrictId,
               '' AS InitialDistrictName
        FROM City c
             LEFT OUTER JOIN Districts dist ON c.DistrictID = dist.DistrictID
        WHERE(c.DistrictId = @DistrictId
              OR ISNULL(c.DistrictID, 0) = 0)
             AND c.IsActive = 1
    END

	/**
	EXEC [CityLisByDistictId] 1
	**/