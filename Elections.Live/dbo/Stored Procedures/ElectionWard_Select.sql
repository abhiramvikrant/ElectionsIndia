----------------------------------------------------------------------------
-- Select a single record from ElectionWard
----------------------------------------------------------------------------
CREATE PROC [dbo].[ElectionWard_Select] @ElectionWardID INT
AS
     SELECT ElectionWard.ElectionWardID, 
            ElectionWard.Name, 
            ElectionWard.IsActive, 
            ElectionWard.ElectionAreaID, 
            ElectionWard.StateLanguageName, 
            ElectionWard.StateLanguageName_1, 
            ElectionWard.StateLanguageName_2, 
            ElectionWard.StateLanguageName_3, 
            ElectionWard.StateLanguagename_4, 
            ElectionWard.StateLanguageName_5, 
            States.Name AS StateName, 
            Countries.Name AS CountryName, 
            ElectionArea.Name AS AreaName, 
            City.Name AS CityName, 
            Districts.Name AS DistrictName

     FROM ElectionWard
          INNER JOIN ElectionArea ON ElectionWard.ElectionAreaID = ElectionArea.ElectionAreaID
          INNER JOIN City ON ElectionArea.CityID = City.CityID
          INNER JOIN Districts ON City.DistrictID = Districts.DistrictID
          INNER JOIN States ON Districts.StateID = States.StateID
          INNER JOIN Countries ON States.CountryID = Countries.CountryId
     WHERE(ElectionWard.ElectionWardID = @ElectionWardID)