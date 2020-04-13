CREATE PROC [dbo].[DistrictList]
AS
     SELECT d.DistrictID, 
            d.Name, 
            d.IsActive, 
            d.StateID, 
            d.CountryID, 
            d.StateLanguageName, 
            d.StateLanguageName_1, 
            d.StateLanguageName_2, 
            d.StateLanguageName_3, 
            d.StateLanguagename_4, 
            d.StateLanguageName_5, 
            s.Name AS StateName, 
            c.Name AS CountryName
     FROM Districts d
          INNER JOIN States s ON d.StateID = s.StateID
          INNER JOIN Countries c ON s.CountryID = c.CountryId