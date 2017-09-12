CREATE VIEW [dbo].[vDraftBallsAndTeams]
	AS SELECT a.DraftBallSequence, a.Ball1, a.Ball2, a.Ball3, a.Ball4, a.DraftBallSeqString, b.DraftBallSeq AS DraftBallRow, b.SequenceNumber AS TeamDraftChance, c.TeamID, c.TeamAbbr, c.TeamCity, c.TeamName, d.Rank
	FROM tblDraftCombinations a, tblDraftTeam b, tblTeam c, tblStandings d
	WHERE
		a.DraftBallSequence = b.DraftBallSeq AND
		b.Rank = d.Rank AND 
		d.TeamID = c.TeamID AND
		c.LeagueID = 1 AND
		b.Year = 2016
GO
