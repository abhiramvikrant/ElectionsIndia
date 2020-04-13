CREATE PROC [dbo].[InsertStates]
(@Name       NVARCHAR(100), 
 @IsActive   BIT, 
 @CountryID  INT, 
 @LanguageID INT,
 @StateID INT
)
AS
    BEGIN
        DECLARE @englang INT;
       
        SELECT @englang = LanguageID
        FROM Languages
        WHERE Name = 'English'
        IF @englang = @LanguageID
            BEGIN
                IF NOT EXISTS
                (
                    SELECT 1
                    FROM states
                    WHERE lower(Name) = lower(@Name)
                )
                    BEGIN
                        INSERT INTO States
                        (Name, 
                         IsActive, 
                         CountryID
                        )
                        VALUES
                        (@Name, 
                         @IsActive, 
                         @CountryID
                        )
                END
        END
            ELSE
            BEGIN
                INSERT INTO StateLanguages
                (LanguageID, 
                 StateID, 
                 Name, 
                 CountryID,
				 IsActive
                )
                VALUES
                (@LanguageID, 
                 @StateID, 
                 @Name, 
                 @CountryID,
				 @IsActive
                )
        END
    END