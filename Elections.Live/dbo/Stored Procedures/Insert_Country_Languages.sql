CREATE PROC [dbo].[Insert_Country_Languages]
(@CountryName NVARCHAR(100), 
 @IsActive    BIT           = 0, 
 @LanguageID  INT

)
AS
    BEGIN
        DECLARE @EnglishLanguageID INT
       Declare @countryid int
        SELECT @EnglishLanguageID = LanguageID
        FROM Languages
        WHERE Name = 'English'
        IF(@LanguageID = @EnglishLanguageID)
            BEGIN
                IF NOT EXISTS
                (
                    SELECT 1
                    FROM Countries
                    WHERE Name = @CountryName
                )
                    BEGIN
                        INSERT INTO Languages
                        (Name, 
                         IsActive
                        )
                        VALUES
                        (@CountryName, 
                         @IsActive
                        )
                END
        END
            ELSE
            BEGIN
                IF NOT EXISTS
                (
                    SELECT 1
                    FROM countrylanguages
                    WHERE LanguageID = @LanguageID
                          AND CountryID = @CountryId
                )
                    BEGIN
                        INSERT INTO countrylanguages
                        VALUES
                        (@LanguageID, 
                         @CountryID, 
                         @CountryName
                        )
                END
        END
    END