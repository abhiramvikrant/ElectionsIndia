----------------------------------------------------------------------------
-- Update a single record in City
----------------------------------------------------------------------------
CREATE PROC City_Update
	@CityID int,
	@Name nvarchar(200),
	@IsActive bit,
	@DistrictID int
	
AS

UPDATE	City
SET	Name = @Name,
	IsActive = @IsActive,
	DistrictID = @DistrictID
	
WHERE 	CityID = @CityID

