CREATE PROC [dbo].[InsertDistrict]
(@Name                NVARCHAR(100), 
 @IsActive            BIT, 
 @StateID             INT, 
 @CountryID           INT
 
)
AS
    BEGIN
        INSERT INTO Districts
        (Name, 
         IsActive, 
         StateID, 
         CountryID 
      
        )
        VALUES
        (@Name, 
         @IsActive, 
         @StateID, 
         @CountryID
        
        )
    END