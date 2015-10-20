use NerderyDB
/****** Object:  Table [dbo].[Suggestions]    Script Date: 2/16/2015 9:05:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suggestions](
	[Id] [int] IDENTITY(491,1) NOT NULL,
	[SnackId] [int] NOT NULL,
	[SuggestedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Suggestions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Votes]    Script Date: 2/16/2015 9:05:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votes](
	[Id] [int] IDENTITY(657,1) NOT NULL,
	[SnackId] [int] NOT NULL,
	[VotedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Votes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Index [IX_Suggestions_by_date]    Script Date: 2/16/2015 9:05:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Suggestions_by_date] ON [dbo].[Suggestions]
(
	[SuggestedOn] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Index [IX_Votes_by_date]    Script Date: 2/16/2015 9:05:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Votes_by_date] ON [dbo].[Votes]
(
	[VotedOn] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
