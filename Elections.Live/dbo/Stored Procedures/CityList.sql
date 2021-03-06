﻿CREATE PROC [dbo].[CityList]
AS
     SELECT City.CityID, 
            City.Name, 
            City.IsActive, 
            City.DistrictID,           
            States.Name AS StateName, 
            Districts.Name AS DistrictName, 
            Countries.Name AS CountryName
     FROM City
          INNER JOIN Districts ON City.DistrictID = Districts.DistrictID
          INNER JOIN States ON Districts.StateID = States.StateID
          INNER JOIN Countries ON States.CountryID = Countries.CountryId