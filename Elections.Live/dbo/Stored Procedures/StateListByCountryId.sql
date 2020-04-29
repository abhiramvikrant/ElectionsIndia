-- =============================================
-- Author:		Vikrant
-- Create date: 27-April-2020
-- Description:	This procedure gets both assinged and non-assigned states to Country
-- Modified: 29-April-2020: Commented out the block after UNION and also UNION
-- =============================================
CREATE PROCEDURE [dbo].[StateListByCountryId](@CountryId INT)
AS
     SET NOCOUNT OFF
    BEGIN
        SELECT States.StateID, 
               States.Name AS State, 
              ISNULL(States.CountryID,-1) AS CountryID, 
               CASE 
			    WHEN States.CountryID = @CountryId THEN CONVERT(BIT, 1)
				WHEN (iSNULL(States.CountryID,0) = 0) THEN CONVERT(BIT, 0) 
				END  AS BelongsToCountry,
               ISNULL(Countries.Name,'') AS Country, 
               -1 AS InitialCountryId, 
               '' AS InitialCountryName
        FROM dbo.States
             LEFT OUTER JOIN dbo.Countries ON States.CountryID = Countries.CountryId
        WHERE(States.CountryID = @CountryId OR iSNULL(States.CountryID,0) = 0 )
             AND (States.IsActive = 1)
  --      UNION
  --      SELECT States.StateID, 
  --             States.Name AS State, 
  --             ISNULL(States.CountryID,-1) AS CountryID,  
  --             CONVERT(BIT, 0) AS BelongsToCountry, 
  --              ISNULL(Countries.Name,'') AS Country, 
  --             -1 AS InitialCountryId, 
  --             '' AS InitialCountryName
  --      FROM dbo.States
  --           LEFT OUTER JOIN dbo.Countries ON Countries.CountryId = States.CountryID
  --      WHERE 
		--iSNULL(States.CountryID,0) = 0  AND
		-- (States.IsActive = 1)
    END
     SET NOCOUNT ON

/** 
    EXEC StateListByCountryId 1
	EXEC StateListByCountryId 2

	select * from states

	update states set CountryId = NULL where country  <= 4
	**/