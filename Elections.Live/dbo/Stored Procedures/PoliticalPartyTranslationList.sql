create proc PoliticalPartyTranslationList
AS
SELECT       ppt.PoliticalPartyTranslationId, ppt.PartyId, ppt.LanguageId, ppt.PartyName, L.Name as LanguageName, pp.Name as PartyName
FROM     PoliticalPartyTranslation ppt INNER JOIN
                    Languages L ON ppt.LanguageId = L.LanguageID INNER JOIN
                         PoliticalParties pp ON ppt.PartyId = pp.PoliticalPartyID
