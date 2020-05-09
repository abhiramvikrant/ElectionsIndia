-- =============================================
-- Author:		Vikrant
-- Create date: 09-April-2020
-- Description:	This procedure gets both assinged and non-assigned ElectionBooth
-- Modified: 
-- =============================================
CREATE PROCEDURE [dbo].[ElectionKioskByBoothId](@BoothId INT)
AS
     SET NOCOUNT OFF
    BEGIN
        SELECT a.ElectionBoothID, 
               a.Name,
			   a.IsActive,
               ISNULL(a.ElectionBoothID, -1) AS ElectionBoothId,
               CASE
                   WHEN a.ElectionBoothID = @BoothId
                   THEN CONVERT(BIT, 1)
                   WHEN(ISNULL(a.ElectionBoothID, 0) = 0)
                   THEN CONVERT(BIT, 0)
               END AS BelongsToBooth, 
               ISNULL(c.Name, '') AS ElectionBooth, 
               -1 AS InitialBoothId,
               '' AS InitialBoothName
        FROM ElectionKiosk a
             LEFT OUTER JOIN  ElectionBooth c ON a.ElectionBoothId = c.ElectionBoothID
        WHERE(a.ElectionBoothId = @BoothId
              OR ISNULL(a.ElectionBoothId, 0) = 0)
             AND a.IsActive = 1
    END

	/**
	EXEC [ElectionKioskByBoothId] 1
	**/