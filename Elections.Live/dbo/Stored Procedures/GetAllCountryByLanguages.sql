CREATE PROC [dbo].[GetAllCountryByLanguages]
AS
     SELECT CL.CountryLanguageID, 
            CO.Name AS CountryName, 
            CO.CountryId, 
            ISNULL(L.LanguageID, 0) AS LanguageID, 
            ISNULL(L.Name, '') as LanguageName, 
            CL.Name AS CountryLanguageName
     FROM Countries AS CO
          LEFT OUTER JOIN CountryLanguages AS CL ON CO.CountryId = CL.CountryID
          LEFT OUTER JOIN Languages L  ON CL.LanguageID = L.LanguageID