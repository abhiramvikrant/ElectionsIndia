CREATE PROC [dbo].[StateLanguagesByID](@statelanguageid INT)
AS
    BEGIN
        SELECT StateLanguages.StateLanguagesID, 
               StateLanguages.LanguageID, 
               StateLanguages.StateID, 
               StateLanguages.Name as StateName, 
               StateLanguages.CountryID, 
               ISNULL(StateLanguages.IsActive,0) as IsActive, 
               Languages.Name AS LanguageName, 
               Countries.Name AS CountryName,
			    StateLanguages.LanguageID AS StateEnglishID,
				  StateLanguages.CountryID AS CountryEnglishID,
				     Languages.Name AS Language
        FROM StateLanguages
             INNER JOIN Languages ON StateLanguages.LanguageID = Languages.LanguageID
             INNER JOIN Countries ON StateLanguages.CountryID = Countries.CountryId
        WHERE StateLanguages.StateLanguagesID = @statelanguageid
    END