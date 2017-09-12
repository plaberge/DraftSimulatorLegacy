/* Table Name:   tblTeam                                                              */
/* Description:  List of teams supported in the draft simulator.                      */
CREATE TABLE [dbo].[tblTeam](
	[TeamID] [int] NOT NULL,
	[LeagueID] [int] NOT NULL,
	[TeamCity] [varchar](50) NULL,
	[TeamName] [varchar](50) NULL,
	[TeamAbbr] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TeamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
