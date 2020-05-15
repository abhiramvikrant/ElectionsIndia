----------------------------------------------------------------------------
-- Insert a single record into City
----------------------------------------------------------------------------
CREATE PROC [dbo].[City_Insert] @Name                NVARCHAR(200), 
                               @IsActive            BIT, 
                               @DistrictID          INT
                             
AS
     INSERT INTO City
     (Name, 
      IsActive, 
      DistrictID
      
     )
     VALUES
     (@Name, 
      @IsActive, 
      @DistrictID
      
     )
