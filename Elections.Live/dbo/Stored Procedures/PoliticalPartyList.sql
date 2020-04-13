CREATE PROC [dbo].[PoliticalPartyList]
AS
     SELECT States.Name AS StateName, 
            ppl.Name AS PoliticalPartyName, 
			ppl.Name AS PoliticalPartyLanguageName,
            Ppl.PoliticalPartyLanguageID, 
            Languages.Name AS LanguageName, 
            Countries.Name AS CountryName, 
            ppl.EnglishPartyID AS EnglishPartyID, 
            EnglishLanguage.Name AS EnglishPartyName,
			Languages.LanguageID,States.StateID,
			ppl.PartyPhotoPath
     FROM PoliticalPartyLanguages ppl
          INNER JOIN States ON ppl.StateID = States.StateID
          INNER JOIN Languages ON ppl.LanguageID = Languages.LanguageID
          INNER JOIN Countries ON States.CountryID = Countries.CountryId
          LEFT OUTER JOIN PoliticalPartyLanguages EnglishLanguage ON ppl.EnglishPartyID = EnglishLanguage.PoliticalPartyLanguageID