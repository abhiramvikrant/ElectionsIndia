----------------------------------------------------------------------------
-- Insert a single record into ElectionArea
----------------------------------------------------------------------------
CREATE PROC [dbo].[ElectionArea_Insert] @Name                NVARCHAR(200), 
                                       @IsActive            BIT, 
                                       @CityID              INT, 
                                       @StateLanguageName   NVARCHAR(200) = NULL, 
                                       @StateLanguageName_1 NVARCHAR(200) = NULL, 
                                       @StateLanguageName_2 NVARCHAR(200) = NULL, 
                                       @StateLanguageName_3 NVARCHAR(200) = NULL, 
                                       @StateLanguagename_4 NVARCHAR(200) = NULL, 
                                       @StateLanguageName_5 NVARCHAR(200) = NULL
AS
     INSERT INTO ElectionArea
     (Name, 
      IsActive, 
      CityID, 
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
      @CityID, 
      @StateLanguageName, 
      @StateLanguageName_1, 
      @StateLanguageName_2, 
      @StateLanguageName_3, 
      @StateLanguagename_4, 
      @StateLanguageName_5
     )
     RETURN SCOPE_IDENTITY()