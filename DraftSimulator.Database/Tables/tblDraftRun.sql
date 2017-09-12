/* Table Name:   tblDraftRun                                                          */
/* Description:  This table stores the results of each individual draft run.  User ID */
/*               is optional as this field is for authenticated users and anonymous   */
/*               draft simulations are also allowed.                                  */

CREATE TABLE [dbo].[tblDraftRun](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DraftRunDateTime] [datetime] NOT NULL,
	[SelectedDraftBallSeq] [int] NOT NULL,
	[SelectedTeamID] [int] NOT NULL,
	[UserID] [int] NULL,
	[Channel] [varchar](15) NULL,
	[DraftRunCountry] [varchar](50) NULL,
	[DraftRunCity] [varchar](50) NULL,
	[DraftRunLatitude] [numeric](10, 6) NULL,
	[DraftRunLongitude] [numeric](10, 6) NULL,
	[Season] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
