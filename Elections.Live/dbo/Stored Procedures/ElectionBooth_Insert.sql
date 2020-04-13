----------------------------------------------------------------------------
-- Insert a single record into ElectionBooth
----------------------------------------------------------------------------
CREATE PROC ElectionBooth_Insert
	@Name nvarchar(200),
	@IsActive bit,
	@ElectionWardID int
AS

INSERT ElectionBooth(Name, IsActive, ElectionWardID)
VALUES (@Name, @IsActive, @ElectionWardID)

RETURN SCOPE_IDENTITY()

