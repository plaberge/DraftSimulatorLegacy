/* Table Name:   tblLeague                                                            */
/* Description:  Table of leagues that are associated to this draft simulator.        */

CREATE TABLE [dbo].[tblLeague](
	[LeagueID] [int] NOT NULL,
	[LeagueAbbr] [varchar](50) NOT NULL,
	[LeagueName] [varchar](50) NULL,
	[Sport] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LeagueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
