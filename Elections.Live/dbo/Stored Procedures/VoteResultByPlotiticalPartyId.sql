CREATE PROC [dbo].[VoteResultByPlotiticalPartyId]
AS
     SELECT p.Name, 
            p.ShortName, 
            COUNT(1) AS Votes, 
            Candidates.Name AS CandidateName
     FROM VoteResult AS v
          INNER JOIN PoliticalParties AS p ON v.PoliticalPartyId = p.PoliticalPartyID
          INNER JOIN Candidates ON v.CandidateId = Candidates.CandidateID
     GROUP BY p.Name, 
              p.ShortName, 
              Candidates.Name
     ORDER BY Votes DESC


