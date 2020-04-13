CREATE PROC InsertDistrict
(@Name                NVARCHAR(100), 
 @IsActive            BIT, 
 @StateID             INT, 
 @CountryID           INT, 
 @StateLanguageName   NVARCHAR(100), 
 @StateLanguageName_1 NVARCHAR(100), 
 @StateLanguageName_2 NVARCHAR(100), 
 @StateLanguageName_3 NVARCHAR(100), 
 @StateLanguagename_4 NVARCHAR(100), 
 @StateLanguageName_5 NVARCHAR(100)
)
AS
    BEGIN
        INSERT INTO Districts
        (Name, 
         IsActive, 
         StateID, 
         CountryID, 
         StateLanguageName, 
         StateLanguageName_1, 
         StateLanguageName_2, 
         StateLanguageName_3, 
         StateLanguagename_4, 
         StateLanguageName_5
        )
        VALUES
        (@Name, 
         @IsActive, 
         @StateID, 
         @CountryID, 
         @StateLanguageName, 
         @StateLanguageName_1, 
         @StateLanguageName_2, 
         @StateLanguageName_3, 
         @StateLanguageName_4, 
         @StateLanguageName_5
        )
    END