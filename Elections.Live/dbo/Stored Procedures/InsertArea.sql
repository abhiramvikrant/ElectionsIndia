CREATE PROC [dbo].[InsertArea]
(@AreaName   NVARCHAR(100), 
 @IsActive   BIT, 
 @CountryID  INT, 
 @StateID    INT = 0, 
 @LanguageID INT = 0, 
 @AreaID     INT = 0
)
AS
    BEGIN
        DECLARE @englang INT;
        SELECT @englang = LanguageID
        FROM Languages
        WHERE Name = 'English'
        IF @englang = @LanguageID
            BEGIN
                INSERT INTO Areas
                (Name, 
                 IsActive, 
                 CountryID, 
                 StateID
                )
                VALUES
                (@AreaName, 
                 @IsActive, 
                 @CountryID, 
                 @StateID
                )
        END
            ELSE
            BEGIN
                INSERT INTO AreaLanguages
                (LanguageID, 
                 AreaID, 
                 Name, 
                 CountryID, 
                 StateID
                )
                VALUES
                (@LanguageId, 
                 @AreaID, 
                 @AreaName, 
                 @CountryID, 
                 @StateID
                )
        END
    END