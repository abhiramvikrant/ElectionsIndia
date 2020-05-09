-- =============================================
-- Author:		Vikrant
-- Create date: 09-April-2020
-- Description:	This procedure gets both assinged and non-assigned ElectionWards
-- Modified: 
-- =============================================
CREATE PROCEDURE [dbo].[ElectionWardByAreaId](@AreaId INT)
AS
     SET NOCOUNT OFF
    BEGIN
        SELECT a.ElectionWardID, 
               a.Name,
			   a.IsActive,
               ISNULL(a.ElectionAreaID, -1) AS ElectionAreaId,
               CASE
                   WHEN a.ElectionAreaID = @AreaId
                   THEN CONVERT(BIT, 1)
                   WHEN(ISNULL(a.ElectionAreaID, 0) = 0)
                   THEN CONVERT(BIT, 0)
               END AS BelongsToArea, 
               ISNULL(c.Name, '') AS ElectionArea, 
               -1 AS InitialAreaId,
               '' AS InitialAreaName
        FROM ElectionWard a
             LEFT OUTER JOIN  ElectionArea c ON a.ElectionAreaID = c.ElectionAreaID
        WHERE(a.ElectionAreaID = @AreaId
              OR ISNULL(a.ElectionAreaID, 0) = 0)
             AND a.IsActive = 1
    END

	/**
	EXEC [ElectionWardByAreaId] 1
	**/