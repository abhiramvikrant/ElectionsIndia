----------------------------------------------------------------------------
-- Insert a single record into City
----------------------------------------------------------------------------
CREATE PROC [dbo].[City_Insert] @Name                NVARCHAR(200), 
                               @IsActive            BIT, 
                               @DistrictID          INT, 
                               @StateLanguageName   NVARCHAR(200) = NULL, 
                               @StateLanguageName_1 NVARCHAR(200) = NULL, 
                               @StateLanguageName_2 NVARCHAR(200) = NULL, 
                               @StateLanguageName_3 NVARCHAR(200) = NULL, 
                               @StateLanguagename_4 NVARCHAR(200) = NULL, 
                               @StateLanguageName_5 NVARCHAR(200) = NULL
AS
     INSERT INTO City
     (Name, 
      IsActive, 
      DistrictID, 
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
      @DistrictID, 
      @StateLanguageName, 
      @StateLanguageName_1, 
      @StateLanguageName_2, 
      @StateLanguageName_3, 
      @StateLanguagename_4, 
      @StateLanguageName_5
     )
