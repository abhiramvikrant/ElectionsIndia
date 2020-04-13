CREATE PROC [dbo].[ElectionAreaList]
AS
     SELECT ElectionArea.ElectionAreaID, 
            ElectionArea.Name AS AreaName, 
            ElectionArea.IsActive, 
            ElectionArea.CityID, 
            ElectionArea.StateLanguageName, 
            ElectionArea.StateLanguageName_1, 
            ElectionArea.StateLanguageName_2, 
            ElectionArea.StateLanguageName_3, 
            ElectionArea.StateLanguagename_4, 
            ElectionArea.StateLanguageName_5, 
            Districts.Name AS DistrictName, 
            States.Name AS StateName, 
            Countries.Name AS CountryName, 
            City.Name AS CityName
     FROM States
          INNER JOIN Countries ON States.CountryID = Countries.CountryId
          INNER JOIN Districts ON States.StateID = Districts.StateID
          INNER JOIN City ON Districts.DistrictID = City.DistrictID
          INNER JOIN ElectionArea ON City.CityID = ElectionArea.CityID