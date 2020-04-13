CREATE PROC [dbo].[GetAllCountries]
AS
     SELECT Countries.CountryID, 
            Countries.Name, 
			Countries.IsActive,
            0 AS StatesStateId
     FROM Countries