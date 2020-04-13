CREATE PROC UpdateStates
(
@StateID INT,
@Name NVARCHAR(100),
@IsActive BIT,
@CountryID INT,
@LanguageID INT
)
AS
BEGIN
SELECT * from Languages
END
