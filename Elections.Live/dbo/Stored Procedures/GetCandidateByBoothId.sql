CREATE PROC [dbo].[GetCandidateByBoothId]
AS
     SELECT VoteConfiguration.CandidateId, 
            VoteConfiguration.CountryId, 
            VoteConfiguration.StateId, 
            VoteConfiguration.DistrictId, 
            VoteConfiguration.AreaiD, 
            VoteConfiguration.WardId, 
            VoteConfiguration.BoothId, 
            VoteConfiguration.KioskId, 
            VoteConfiguration.ElectionTypeId, 
            VoteConfiguration.PoliticalPartyId, 
            VoteConfiguration.VoteConfigurationUID, 
            Candidates.Name AS CandidateName, 
            PoliticalParties.Name AS PoliticalPartyName, 
            PoliticalParties.ShortName AS PoliticalPartyShortName, 
            VoteConfiguration.VoteConfigurationId
     FROM VoteConfiguration
          INNER JOIN PoliticalParties ON VoteConfiguration.PoliticalPartyId = PoliticalParties.PoliticalPartyID
          INNER JOIN Candidates ON VoteConfiguration.CandidateId = Candidates.CandidateID
     WHERE LOWER(PoliticalParties.ShortName) <> 'nota'
     UNION
     SELECT VoteConfiguration.CandidateId, 
            VoteConfiguration.CountryId, 
            VoteConfiguration.StateId, 
            VoteConfiguration.DistrictId, 
            VoteConfiguration.AreaiD, 
            VoteConfiguration.WardId, 
            VoteConfiguration.BoothId, 
            VoteConfiguration.KioskId, 
            VoteConfiguration.ElectionTypeId, 
            VoteConfiguration.PoliticalPartyId, 
            VoteConfiguration.VoteConfigurationUID, 
            Candidates.Name AS CandidateName, 
            PoliticalParties.Name AS PoliticalPartyName, 
            PoliticalParties.ShortName AS PoliticalPartyShortName, 
            VoteConfiguration.VoteConfigurationId
     FROM VoteConfiguration
          INNER JOIN PoliticalParties ON VoteConfiguration.PoliticalPartyId = PoliticalParties.PoliticalPartyID
          INNER JOIN Candidates ON VoteConfiguration.CandidateId = Candidates.CandidateID
     WHERE LOWER(PoliticalParties.ShortName) = 'nota'