-- =============================================
-- Author:		Vikrant
-- Create date: 27-April-2020
-- Description:	This procedure gets both assinged and non-assigned states to Country
-- =============================================
CREATE PROCEDURE StateListByCountryId(@CountryId INT)
AS
SET NOCOUNT OFF
    BEGIN
     SELECT        States.StateID, States.Name AS State, States.CountryID, 1 AS BelongsToCountry, Countries.Name AS Country
FROM            States INNER JOIN
                         Countries ON States.CountryID = Countries.CountryId
WHERE        (States.CountryID = @CountryId) AND (States.IsActive = 1)
        UNION
     SELECT        States.StateID, States.Name AS State, States.CountryID, 0 AS BelongsToCountry, Countries.Name AS Country
FROM            States INNER JOIN
                         Countries ON States.CountryID = Countries.CountryId
WHERE        (States.CountryID <> @CountryId) AND (States.IsActive = 1)
    END
	SET NOCOUNT ON