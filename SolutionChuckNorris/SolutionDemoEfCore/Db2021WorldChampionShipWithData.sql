USE [Db2021WorldChampionShip]
GO
/****** Object:  User [Db2021WorldChampionShipUser]    Script Date: 1/16/2022 11:43:44 AM ******/
CREATE USER [Db2021WorldChampionShipUser] 
FOR LOGIN [Db2021WorldChampionShipUser] 
WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Db2021WorldChampionShipUser]
GO
/****** Object:  Table [dbo].[Athete]    Script Date: 1/16/2022 11:43:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Athete](
	[Id] [int] NOT NULL,
	[Name] [varchar](max) NULL,
	[DOB] [datetime2](7) NULL,
	[TeamId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Result]    Script Date: 1/16/2022 11:43:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[AthleteId] [int] NOT NULL,
	[WorldChampionShipId] [int] NOT NULL,
	[Rank] [int] NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[AthleteId] ASC,
	[WorldChampionShipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 1/16/2022 11:43:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[Id] [int] NOT NULL,
	[Country] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorldChampionShip]    Script Date: 1/16/2022 11:43:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorldChampionShip](
	[Id] [int] NOT NULL,
	[City] [varchar](max) NULL,
	[Year] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (1, N'Hildegarde', NULL, 1)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (2, N'Henri', NULL, 1)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (3, N'Hermann', NULL, 1)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (4, N'Hilda', NULL, 1)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (5, N'Hélène', NULL, 1)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (6, N'Harry', NULL, 1)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (7, N'Hans', NULL, 1)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (8, N'Harold', NULL, 1)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (9, N'Hugues', NULL, 1)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (10, N'Hervé', NULL, 1)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (11, N'Hubert', NULL, 1)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (12, N'Honoré', NULL, 1)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (13, N'Olivia', NULL, 2)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (14, N'Olga', NULL, 2)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (15, N'Oscar', NULL, 2)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (16, N'Orianne', NULL, 2)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (17, N'Odile', NULL, 2)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (18, N'Olivier', NULL, 2)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (19, N'Oswald', NULL, 2)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (20, N'Octavie', NULL, 2)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (21, N'Olympe', NULL, 2)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (22, N'Odette', NULL, 2)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (23, N'Yvon', NULL, 3)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (24, N'Yolande', NULL, 3)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (25, N'Yoann', NULL, 3)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (26, N'Yannick', NULL, 3)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (27, N'Yves', NULL, 3)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (28, N'Yvonne', NULL, 3)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (29, N'Yann', NULL, 3)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (30, N'Yvan', NULL, 3)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (100, N'Torri Edwards', NULL, 1)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (200, N'Chandra Sturrup', NULL, 2)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (300, N'Chirstine Arron', NULL, 3)
GO
INSERT [dbo].[Athete] ([Id], [Name], [DOB], [TeamId]) VALUES (400, N'Ekaterini Thanou', NULL, 4)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (1, 2, 11)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (2, 3, 8)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (3, 1, 2)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (3, 2, 1)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (4, 1, 8)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (6, 2, 4)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (7, 1, 3)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (7, 3, 3)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (8, 1, 4)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (8, 2, 6)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (8, 3, 5)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (8, 4, 1)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (9, 2, 2)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (9, 3, 4)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (11, 1, 1)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (11, 2, 5)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (12, 1, 9)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (14, 2, 7)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (14, 3, 2)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (17, 2, 8)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (17, 3, 1)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (19, 3, 6)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (20, 2, 9)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (21, 3, 8)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (22, 1, 5)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (22, 2, 3)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (27, 1, 6)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (29, 1, 7)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (29, 2, 10)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (30, 2, 3)
GO
INSERT [dbo].[Result] ([AthleteId], [WorldChampionShipId], [Rank]) VALUES (30, 3, 7)
GO
INSERT [dbo].[Team] ([Id], [Country]) VALUES (1, N'USA')
GO
INSERT [dbo].[Team] ([Id], [Country]) VALUES (2, N'JAM')
GO
INSERT [dbo].[Team] ([Id], [Country]) VALUES (3, N'FRANCE')
GO
INSERT [dbo].[Team] ([Id], [Country]) VALUES (4, N'GREECE')
GO
INSERT [dbo].[WorldChampionShip] ([Id], [City], [Year]) VALUES (1, N'Paris', 2003)
GO
INSERT [dbo].[WorldChampionShip] ([Id], [City], [Year]) VALUES (2, N'Doha', 2019)
GO
INSERT [dbo].[WorldChampionShip] ([Id], [City], [Year]) VALUES (3, N'london', 2017)
GO
INSERT [dbo].[WorldChampionShip] ([Id], [City], [Year]) VALUES (4, N'Beijing', 2013)
GO
ALTER TABLE [dbo].[Athete]  WITH CHECK ADD  CONSTRAINT [FK_TEAM] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO
ALTER TABLE [dbo].[Athete] CHECK CONSTRAINT [FK_TEAM]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Athlete] FOREIGN KEY([AthleteId])
REFERENCES [dbo].[Athete] ([Id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Athlete]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_WorldChampionShip] FOREIGN KEY([WorldChampionShipId])
REFERENCES [dbo].[WorldChampionShip] ([Id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_WorldChampionShip]
GO
