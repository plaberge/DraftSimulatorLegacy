CREATE FUNCTION [dbo].[fnDraftBallsAndTeams]
(
	@DraftYear int,
	@LeagueID int
)
RETURNS @returntable TABLE
(
	DraftBallSequence int,
	Ball1 int,
	Ball2 int,
	Ball3 int, 
	Ball4 int,
	DraftBallSeqString varchar(50),
	DraftBallRow varchar(50),
	TeamDraftChance int,
	TeamID int, 
	TeamAbbr varchar(50), 
	TeamCity varchar(50), 
	TeamName varchar(50)
)
AS
BEGIN
	INSERT @returntable

	SELECT a.DraftBallSequence, a.Ball1, a.Ball2, a.Ball3, a.Ball4, a.DraftBallSeqString, b.DraftBallSeq AS DraftBallRow, b.SequenceNumber AS TeamDraftChance, c.TeamID, c.TeamAbbr, c.TeamCity, c.TeamName
	FROM tblDraftCombinations a, tblDraftTeam b, tblTeam c, tblStandings d
	WHERE
		a.DraftBallSequence = b.DraftBallSeq AND
		b.Rank = d.Rank AND
		d.TeamID = c.TeamID AND
		c.LeagueID = @LeagueID AND
		b.Year = @DraftYear
	
	RETURN
END
GO
