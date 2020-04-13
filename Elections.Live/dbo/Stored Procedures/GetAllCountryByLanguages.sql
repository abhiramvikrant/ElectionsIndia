CREATE PROC [dbo].[GetAllCountryByLanguages]
AS
     SELECT CL.CountryLanguageID, 
            CO.Name AS CountryName, 
            CO.CountryId, 
            L.LanguageID, 
            L.Name AS LanguageName, 
            CL.Name AS CountryLanguageName
     FROM Countries AS CO
          LEFT OUTER JOIN CountryLanguages AS CL ON CO.CountryId = CL.CountryID
          LEFT OUTER JOIN Languages L  ON CL.LanguageID = L.LanguageID