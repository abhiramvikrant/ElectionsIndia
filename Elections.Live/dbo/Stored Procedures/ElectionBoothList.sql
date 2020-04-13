CREATE PROC [dbo].[ElectionBoothList]
AS
     SELECT ElectionBooth.ElectionBoothID, 
            ElectionBooth.Name AS BoothName, 
            ElectionBooth.IsActive, 
            ElectionBooth.ElectionWardID, 
            ElectionArea.Name AS AreaName, 
            States.Name as StateName, 
            Countries.Name AS CountryName, 
            City.Name AS CityName, 
            Districts.Name AS DistrictName, 
            ElectionWard.Name AS WardName
     FROM ElectionBooth
          INNER JOIN ElectionWard ON ElectionBooth.ElectionWardID = ElectionWard.ElectionWardID
          INNER JOIN ElectionArea ON ElectionWard.ElectionAreaID = ElectionArea.ElectionAreaID
          INNER JOIN City ON ElectionArea.CityID = City.CityID
          INNER JOIN Districts ON City.DistrictID = Districts.DistrictID
          INNER JOIN States ON Districts.StateID = States.StateID
          INNER JOIN Countries ON States.CountryID = Countries.CountryId