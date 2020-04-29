CREATE PROC [dbo].[DistrictList]
AS
     SELECT d.DistrictID, 
            d.Name, 
            d.IsActive, 
            d.StateID, 
            s.Name AS StateName
     FROM Districts d
          INNER JOIN States s ON d.StateID = s.StateID