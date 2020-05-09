-- =============================================
-- Author:		Vikrant
-- Create date: 09-April-2020
-- Description:	This procedure gets both assinged and non-assigned ElectionBooth
-- Modified: 
-- =============================================
CREATE PROCEDURE [dbo].[ElectionBoothByWardId](@WardId INT)
AS
     SET NOCOUNT OFF
    BEGIN
        SELECT a.ElectionBoothID, 
               a.Name,
			   a.IsActive,
               ISNULL(a.ElectionBoothID, -1) AS ElectionBoothId,
               CASE
                   WHEN a.ElectionBoothID = @WardId
                   THEN CONVERT(BIT, 1)
                   WHEN(ISNULL(a.ElectionBoothID, 0) = 0)
                   THEN CONVERT(BIT, 0)
               END AS BelongsToWard, 
               ISNULL(c.Name, '') AS ElectionWard, 
               -1 AS InitialWardId,
               '' AS InitialWardName
        FROM ElectionBooth a
             LEFT OUTER JOIN  ElectionWard c ON a.ElectionWardID = c.ElectionWardID
        WHERE(a.ElectionWardID = @WardId
              OR ISNULL(a.ElectionWardID, 0) = 0)
             AND a.IsActive = 1
    END

	/**
	EXEC [ElectionBoothByWardId] 1
	**/