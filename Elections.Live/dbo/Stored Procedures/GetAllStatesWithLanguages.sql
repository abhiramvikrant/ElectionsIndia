CREATE PROC [dbo].[GetAllStatesWithLanguages]
AS
    BEGIN
        DECLARE @languageid INT
        SELECT @languageid = languageid
        FROM Languages
        WHERE LOWER(Name) = 'english'

        SELECT States.Name AS StateName, 
               States.CountryID, 
			   @languageid AS LanguageID,
               0 AS StateLanguagesID, 
               cou.Name AS CountryName, 
               'English' AS LanguageName, 
               States.IsActive, 
               States.StateID
        FROM States
             INNER JOIN Countries AS cou ON States.CountryID = cou.CountryId
        UNION
        SELECT sl.Name AS StateName, 
               sl.CountryID, 
               sl.LanguageID, 
               sl.StateLanguagesID, 
               cou.Name AS CountryName, 
               lang.Name AS LanguageName, 
               sl.IsActive, 
               0 AS StateID
        FROM StateLanguages sl
             INNER JOIN Countries AS cou ON sl.CountryID = cou.CountryId
             INNER JOIN Languages AS lang ON sl.LanguageID = lang.LanguageID
    END