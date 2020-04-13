----------------------------------------------------------------------------
-- Update a single record in City
----------------------------------------------------------------------------
CREATE PROC City_Update
	@CityID int,
	@Name nvarchar(200),
	@IsActive bit,
	@DistrictID int,
	@StateLanguageName nvarchar(200) = NULL,
	@StateLanguageName_1 nvarchar(200) = NULL,
	@StateLanguageName_2 nvarchar(200) = NULL,
	@StateLanguageName_3 nvarchar(200) = NULL,
	@StateLanguagename_4 nvarchar(200) = NULL,
	@StateLanguageName_5 nvarchar(200) = NULL
AS

UPDATE	City
SET	Name = @Name,
	IsActive = @IsActive,
	DistrictID = @DistrictID,
	StateLanguageName = @StateLanguageName,
	StateLanguageName_1 = @StateLanguageName_1,
	StateLanguageName_2 = @StateLanguageName_2,
	StateLanguageName_3 = @StateLanguageName_3,
	StateLanguagename_4 = @StateLanguagename_4,
	StateLanguageName_5 = @StateLanguageName_5
WHERE 	CityID = @CityID

