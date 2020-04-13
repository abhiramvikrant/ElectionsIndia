CREATE PROC [dbo].[PoliticalPartyInsert]
(
 @LanguageID               INT, 
 @Name                     NVARCHAR(100), 
 @StateID                  INT, 
 @EnglishPartyID           INT,
 @PhotoPath NVARCHAR(500)
)
AS
     INSERT INTO PoliticalPartyLanguages
     (
      LanguageID, 
      Name, 
      StateID, 
      EnglishPartyID,
	  PartyPhotoPath
     )
     VALUES
     (
      @LanguageID, 
      @Name, 
      @StateID, 
      @EnglishPartyID,
	  @PhotoPath
     )