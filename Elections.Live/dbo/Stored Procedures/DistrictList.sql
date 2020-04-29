CREATE PROC [dbo].[DistrictList]
AS
     SELECT d.DistrictID, 
            d.Name, 
            d.IsActive, 
            d.StateID, 
            d.CountryID, 
            s.Name AS StateName, 
            c.Name AS CountryName
     FROM Districts d
          INNER JOIN States s ON d.StateID = s.StateID
          INNER JOIN Countries c ON s.CountryID = c.CountryId