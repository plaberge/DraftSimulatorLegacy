/* Stored Procedure Name:  spLogDraftRun                                              */
/* Description:            This stored procedure inserts the data from a draft        */
/*                         simulation run.                                            */


CREATE PROCEDURE [dbo].[spLogDraftRun]
	@DraftBallSeq int,
	@TeamID int,
	@UserID int, 
	@Channel varchar(50),
	@Country varchar(50),
	@City varchar(50),
	@Latitude numeric(10,6),
	@Longitude numeric(10,6),
	@Season varchar(50)
AS
BEGIN

	INSERT INTO tblDraftRun(DraftRunDateTime, SelectedDraftBallSeq, SelectedTeamID, UserID, Channel, DraftRunCountry, DraftRunCity, DraftRunLatitude, DraftRunLongitude, Season) VALUES (CURRENT_TIMESTAMP, @DraftBallSeq, @TeamID, @UserID, @Channel, @Country, @City, @Latitude, @Longitude, @Season)

    RETURN 0;

END
GO
