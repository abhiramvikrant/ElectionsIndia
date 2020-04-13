CREATE PROC [dbo].[PoliticalPartyByID](@partyid INT)
AS
     SELECT States.Name AS StateName, 
            ppl.Name AS Name,
            ppl.Name AS PoliticalPartyLanguageName, 
            Ppl.PoliticalPartyLanguageID, 
            Languages.Name AS LanguageName, 
            Countries.Name AS CountryName, 
            ppl.EnglishPartyID AS EnglishPartyID, 
            EnglishLanguage.Name AS EnglishPartyName, 
            Languages.LanguageID, 
            States.StateID, 
            ppl.PartyPhotoPath
     FROM PoliticalPartyLanguages ppl
          INNER JOIN States ON ppl.StateID = States.StateID
          INNER JOIN Languages ON ppl.LanguageID = Languages.LanguageID
          INNER JOIN Countries ON States.CountryID = Countries.CountryId
          LEFT OUTER JOIN PoliticalPartyLanguages EnglishLanguage ON ppl.EnglishPartyID = EnglishLanguage.PoliticalPartyLanguageID
     WHERE ppl.PoliticalPartyLanguageID = @partyid