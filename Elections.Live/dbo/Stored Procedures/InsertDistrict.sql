CREATE PROC [dbo].[InsertDistrict]
(@Name     NVARCHAR(100), 
 @IsActive BIT, 
 @StateID  INT
)
AS
    BEGIN
        INSERT INTO Districts
        (Name, 
         IsActive, 
         StateID
        )
        VALUES
        (@Name, 
         @IsActive, 
         @StateID
        )
    END