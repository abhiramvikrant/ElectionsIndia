CREATE PROC ElectionKioskList
AS
     SELECT ElectionBooth.Name AS BoothName, 
            ElectionKiosk.Name, 
            ElectionKiosk.IsActive, 
            ElectionKiosk.ElectionKioskID
     FROM ElectionKiosk
          INNER JOIN ElectionBooth ON ElectionKiosk.ElectionBoothId = ElectionBooth.ElectionBoothID