----------------------------------------------------------------------------
-- Update a single record in ElectionBooth
----------------------------------------------------------------------------
CREATE PROC ElectionBooth_Update
	@ElectionBoothID int,
	@Name nvarchar(200),
	@IsActive bit,
	@ElectionWardID int
AS

UPDATE	ElectionBooth
SET	Name = @Name,
	IsActive = @IsActive,
	ElectionWardID = @ElectionWardID
WHERE 	ElectionBoothID = @ElectionBoothID

