/* tblDraftBalls */
/* Description:  Table with draft ball combinations AND teams associated with it. */
/*               FYI - this table is largely deprecated.                          */


CREATE TABLE [dbo].[tblDraftBalls](
	[Id] [int] NOT NULL,
	[LeagueID] [int] NOT NULL,
	[DraftYear] [int] NOT NULL,
	[DraftBallSequence] [int] NOT NULL,
	[Ball1] [int] NOT NULL,
	[Ball2] [int] NOT NULL,
	[Ball3] [int] NOT NULL,
	[Ball4] [int] NOT NULL,
	[TeamID] [int] NOT NULL,
	[TeamSeq] [int] NOT NULL,
	[DraftBallSeqString] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
