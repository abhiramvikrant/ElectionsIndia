CREATE PROC [dbo].[VoteResultByPlotiticalPartyId]
AS

select p.ShortName, count(1) Votes from VoteResult v INNER JOIN PoliticalParties p on V.PoliticalPartyId = p.PoliticalPartyID group by p.Name, p.ShortName order by   count(1) desc


