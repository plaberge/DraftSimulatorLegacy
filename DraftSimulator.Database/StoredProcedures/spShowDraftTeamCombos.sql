/* Stored Procedure Name:  spShowDraftTeamCombos                                      */
/* Description:            This stored procedure returns the available draft combos   */
/*                         based on which ball is being drafted.                      */




CREATE PROCEDURE [dbo].[spShowDraftTeamCombos]
	@DraftBallNumber int,
	@DraftBallValue1 int,
	@DraftBallValue2 int,
	@DraftBallValue3 int,
	@DraftBallValue4 int,
	@LeagueID int
AS
BEGIN
	IF (@DraftBallNumber = 1)
	BEGIN

		SELECT DISTINCT TeamID, TeamCity, TeamName, TeamAbbr
		FROM fnDraftBallsAndTeams(2016, @LeagueID)
		WHERE
			Ball1 = @DraftBallValue1;
	
	END
	ELSE IF (@DraftBallNumber = 2)
	BEGIN

		SELECT DISTINCT TeamID, TeamCity, TeamName, TeamAbbr
		FROM fnDraftBallsAndTeams(2016, @LeagueID)
		WHERE
			Ball1 = @DraftBallValue1 AND
			Ball2 = @DraftBallValue2;
	END
	ELSE IF (@DraftBallNumber = 3)
	BEGIN

		SELECT DISTINCT TeamID, TeamCity, TeamName, TeamAbbr
		FROM fnDraftBallsAndTeams(2016, @LeagueID)
		WHERE
			Ball1 = @DraftBallValue1 AND
			Ball2 = @DraftBallValue2 AND
			Ball3 = @DraftBallValue3;

	END
	ELSE
	BEGIN
		
		SELECT TeamID, TeamCity, TeamName, TeamAbbr, DraftBallRow, TeamDraftChance 
		FROM fnDraftBallsAndTeams(2016, @LeagueID)
		WHERE
			Ball1 = @DraftBallValue1 AND
			Ball2 = @DraftBallValue2 AND
			Ball3 = @DraftBallValue3 AND 
			Ball4 = @DraftBallValue4;

	END

	RETURN 0
END
GO
