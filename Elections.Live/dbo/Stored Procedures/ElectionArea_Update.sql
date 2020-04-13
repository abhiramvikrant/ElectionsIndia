----------------------------------------------------------------------------
-- Update a single record in ElectionArea
----------------------------------------------------------------------------
CREATE PROC [dbo].[ElectionArea_Update] @ElectionAreaID      INT, 
                                       @Name                NVARCHAR(200), 
                                       @IsActive            BIT, 
                                       @CityID              INT, 
                                       @StateLanguageName   NVARCHAR(200) = NULL, 
                                       @StateLanguageName_1 NVARCHAR(200) = NULL, 
                                       @StateLanguageName_2 NVARCHAR(200) = NULL, 
                                       @StateLanguageName_3 NVARCHAR(200) = NULL, 
                                       @StateLanguagename_4 NVARCHAR(200) = NULL, 
                                       @StateLanguageName_5 NVARCHAR(200) = NULL
AS
     UPDATE ElectionArea
       SET 
           Name = @Name, 
           IsActive = @IsActive, 
           CityID = @CityID, 
           StateLanguageName = @StateLanguageName, 
           StateLanguageName_1 = @StateLanguageName_1, 
           StateLanguageName_2 = @StateLanguageName_2, 
           StateLanguageName_3 = @StateLanguageName_3, 
           StateLanguagename_4 = @StateLanguagename_4, 
           StateLanguageName_5 = @StateLanguageName_5
     WHERE ElectionAreaID = @ElectionAreaID