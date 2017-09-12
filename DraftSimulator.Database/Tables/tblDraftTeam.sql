/* Table Name:   tblDraftTeam                                                         */
/* Description:  Table that provides combinations of teams based on data in the       */
/*               associated tblDraftCombinations table, which contains combinations   */
/*               of draft ball values.                                                */


CREATE TABLE [dbo].[tblDraftTeam](
	[Id] [int] NOT NULL,
	[DraftBallSeq] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[LeagueID] [int] NOT NULL,
	[SequenceNumber] [int] NOT NULL,
	[Rank] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
