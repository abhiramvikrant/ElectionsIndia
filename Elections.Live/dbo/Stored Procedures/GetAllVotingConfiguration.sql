CREATE PROC GetAllVotingConfiguration
AS
     SELECT  VoteConfiguration.VoteConfigurationId, 
                      VoteConfiguration.CandidateId, 
                      VoteConfiguration.CountryId, 
                      VoteConfiguration.StateId, 
                      VoteConfiguration.DistrictId, 
                      VoteConfiguration.AreaiD, 
                      VoteConfiguration.WardId, 
                      VoteConfiguration.BoothId, 
                      VoteConfiguration.KioskId, 
                      VoteConfiguration.ElectionTypeId, 
                      VoteConfiguration.VoteConfigurationUID, 
                      VoteConfiguration.PoliticalPartyId, 
                      Candidates.Name AS CanddiateName, 
                      Countries.Name AS CountryName, 
                      States.Name AS StateName, 
                      Districts.Name AS DistrictNane, 
                      ElectionWard.Name AS WardName, 
                      Areas.Name AS AreaName, 
                      ElectionBooth.Name AS BoothName, 
                      ElectionKiosk.Name AS KioskName, 
                      ElectionKiosk.IsActive, 
                      ElectionBooth.IsActive AS Expr1, 
                      Areas.IsActive AS Expr2, 
                      ElectionWard.IsActive AS Expr3, 
                      Districts.IsActive AS Expr4, 
                      States.IsActive AS Expr5, 
                      Countries.IsActive AS Expr6, 
                      Candidates.IsActive AS Expr7
     FROM VoteConfiguration
          INNER JOIN ElectionWard ON VoteConfiguration.WardId = ElectionWard.ElectionWardID
          INNER JOIN ElectionKiosk ON VoteConfiguration.BoothId = ElectionKiosk.ElectionBoothId
          INNER JOIN ELectionBooth ON VoteConfiguration.KioskId = ElectionKiosk.ElectionKioskID
          INNER JOIN Candidates ON VoteConfiguration.CandidateId = Candidates.CandidateID
          INNER JOIN Countries ON VoteConfiguration.CountryId = Countries.CountryId
          INNER JOIN States ON VoteConfiguration.StateId = States.StateID
          INNER JOIN Districts ON VoteConfiguration.DistrictId = Districts.DistrictID
          INNER JOIN Areas ON VoteConfiguration.AreaID = Areas.AreaID
     WHERE(ElectionKiosk.IsActive = 1)
          AND (ElectionBooth.IsActive = 1)
          AND (Areas.IsActive = 1)
          AND (ElectionWard.IsActive = 1)
          AND (Districts.IsActive = 1)
          AND (States.IsActive = 1)
          AND (Countries.IsActive = 1)
          AND (Candidates.IsActive = 1)