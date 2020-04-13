----------------------------------------------------------------------------
-- Insert a single record into ElectionWard
----------------------------------------------------------------------------
CREATE PROC ElectionWard_Insert
	@Name nvarchar(200),
	@IsActive bit,
	@ElectionAreaID int,
	@StateLanguageName nvarchar(200) = NULL,
	@StateLanguageName_1 nvarchar(200) = NULL,
	@StateLanguageName_2 nvarchar(200) = NULL,
	@StateLanguageName_3 nvarchar(200) = NULL,
	@StateLanguagename_4 nvarchar(200) = NULL,
	@StateLanguageName_5 nvarchar(200) = NULL
AS

INSERT ElectionWard(Name, IsActive, ElectionAreaID, StateLanguageName, StateLanguageName_1, StateLanguageName_2, StateLanguageName_3, StateLanguagename_4, StateLanguageName_5)
VALUES (@Name, @IsActive, @ElectionAreaID, @StateLanguageName, @StateLanguageName_1, @StateLanguageName_2, @StateLanguageName_3, @StateLanguagename_4, @StateLanguageName_5)

RETURN SCOPE_IDENTITY()

