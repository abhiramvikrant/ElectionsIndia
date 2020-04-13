CREATE PROC AreaList
AS
     SELECT 0 AS AreaLanguageID, 
            0 AS LanguageID, 
            a.AreaID, 
            a.Name, 
            a.CountryID, 
            a.StateID, 
            'English' AS LanguageName, 
            c.Name AS CountryName, 
            s.Name AS StateName
     FROM Areas a
          INNER JOIN Countries c ON a.CountryID = c.CountryId
          INNER JOIN States s ON a.StateID = s.StateID
     UNION
     SELECT AreaLanguages.AreaLanguageID, 
            AreaLanguages.LanguageID, 
            AreaLanguages.AreaID, 
            AreaLanguages.Name, 
            AreaLanguages.CountryID, 
            AreaLanguages.StateID, 
            Languages.Name AS LanguageName, 
            Countries.Name AS CountryName, 
            States.Name AS StateName
     FROM AreaLanguages
          INNER JOIN Languages ON AreaLanguages.LanguageID = Languages.LanguageID
          INNER JOIN Countries ON AreaLanguages.CountryID = Countries.CountryId
          INNER JOIN States ON AreaLanguages.StateID = States.StateID