/* Table Name:   tblDraftCombinations                                                */
/* Description:  This table provides draft ball combination sequences, WITHOUT teams */
/*               linked to it.  This allows the draft sequence to be genericized and */
/*               more flexibly linked to a separate table (tblDraftTeam).            */

CREATE TABLE [dbo].[tblDraftCombinations](
	[Id] [int] NOT NULL,
	[DraftBallSequence] [int] NOT NULL,
	[Ball1] [int] NOT NULL,
	[Ball2] [int] NOT NULL,
	[Ball3] [int] NOT NULL,
	[Ball4] [int] NOT NULL,
	[DraftBallSeqString] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
