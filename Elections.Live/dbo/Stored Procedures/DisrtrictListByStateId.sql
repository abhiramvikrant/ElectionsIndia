-- =============================================
-- Author:		Vikrant
-- Create date: 30-April-2020
-- Description:	This procedure gets both assinged and non-assigned districts
-- Modified: 
-- =============================================
CREATE PROCEDURE [dbo].[DisrtrictListByStateId](@StateId INT)
AS
     SET NOCOUNT OFF
    BEGIN
        SELECT dist.DistrictID, 
               dist.Name, 
			   dist.IsActive,
               ISNULL(dist.StateId, -1) AS StateID,
               CASE
                   WHEN dist.StateId = @StateId
                   THEN CONVERT(BIT, 1)
                   WHEN(ISNULL(dist.StateId, 0) = 0)
                   THEN CONVERT(BIT, 0)
               END AS BelongsToState, 
               ISNULL(st.Name, '') AS State, 
               -1 AS InitialStateId, 
               '' AS InitialStateName
        FROM dbo.Districts dist
             LEFT OUTER JOIN dbo.States st ON dist.StateId = st.StateID
        WHERE(st.StateID = @StateId
              OR ISNULL(st.StateID, 0) = 0)
             AND dist.IsActive = 1
    END

	/**
	EXEC DisrtrictListByStateId 1
	**/