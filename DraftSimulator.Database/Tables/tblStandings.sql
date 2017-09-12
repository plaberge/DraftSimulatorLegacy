CREATE TABLE [dbo].[tblStandings](
	[Id] [int] NOT NULL,
	[Season] [varchar](50) NOT NULL,
	[LeagueID] [int] NOT NULL,
	[TeamID] [int] NOT NULL,
	[Rank] [int] NOT NULL,
	[Wins] [int] NULL,
	[Losses] [int] NULL,
	[OvertimeLosses] [int] NULL,
	[Points] [int] NOT NULL,
	[StandingsDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
