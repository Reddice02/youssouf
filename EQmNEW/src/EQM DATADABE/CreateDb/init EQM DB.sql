USE [EQM]
GO
/****** Object:  Table [dbo].[EQM_ActionPlan]    Script Date: 18/10/2022 14:24:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EQM_ActionPlan](
	[ActionPlanID] [bigint] IDENTITY(1,1) NOT NULL,
	[ActionPointID] [bigint] NULL,
	[Title] [varchar](255) NOT NULL,
	[Description] [text] NULL,
	[Manager] [varchar](255) NULL,
	[ActionPlanOrder] [tinyint] NULL,
	[ActionPlanPriority] [tinyint] NULL,
	[Statuts] [tinyint] NULL,
	[StartDateExpected] [datetime] NULL,
	[EndDateExpected] [datetime] NULL,
	[StartDateEffective] [datetime] NULL,
	[EndDateEffective] [datetime] NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_EQM_ActionPlan] PRIMARY KEY CLUSTERED 
(
	[ActionPlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EQM_ActionPoint]    Script Date: 18/10/2022 14:24:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EQM_ActionPoint](
	[ActionPointID] [bigint] IDENTITY(1,1) NOT NULL,
	[NatureID] [int] NULL,
	[AuditID] [bigint] NULL,
	[Title] [varchar](255) NOT NULL,
	[Description] [text] NULL,
	[ActionPointLevel] [tinyint] NULL,
	[ActionPointPriority] [tinyint] NULL,
	[ThirdPartyProcessStep] [text] NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_EQM_ActionPoint] PRIMARY KEY CLUSTERED 
(
	[ActionPointID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EQM_ActionPointNature]    Script Date: 18/10/2022 14:24:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EQM_ActionPointNature](
	[NatureID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_EQM_ActionPointNature] PRIMARY KEY CLUSTERED 
(
	[NatureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EQM_Audit]    Script Date: 18/10/2022 14:24:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EQM_Audit](
	[AuditID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProcessID] [bigint] NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[Description] [text] NULL,
	[StartDateExpected] [datetime] NULL,
	[EndDateExpected] [datetime] NULL,
	[StartDateEffective] [datetime] NULL,
	[EndDateEffective] [datetime] NULL,
	[Report] [text] NULL,
	[Reference] [varchar](50) NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_EQM_Audit] PRIMARY KEY CLUSTERED 
(
	[AuditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EQM_Process]    Script Date: 18/10/2022 14:24:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EQM_Process](
	[ProcessID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[Description] [text] NULL,
	[TurnaroundTimes] [tinyint] NULL,
	[Participants] [text] NULL,
	[ThirdPartyProcesses] [text] NULL,
	[Manager] [varchar](255) NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_EQM_Process] PRIMARY KEY CLUSTERED 
(
	[ProcessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EQM_ActionPointNature] ON 

INSERT [dbo].[EQM_ActionPointNature] ([NatureID], [Title], [CreateBy], [Created]) VALUES (3, N'Non conformité', N'admin', CAST(N'2022-10-18T09:27:00.243' AS DateTime))
INSERT [dbo].[EQM_ActionPointNature] ([NatureID], [Title], [CreateBy], [Created]) VALUES (4, N'Amélioration', N'admin', CAST(N'2022-10-18T09:27:00.320' AS DateTime))
INSERT [dbo].[EQM_ActionPointNature] ([NatureID], [Title], [CreateBy], [Created]) VALUES (5, N'jdhj', N'admin', CAST(N'2022-10-18T12:35:18.730' AS DateTime))
SET IDENTITY_INSERT [dbo].[EQM_ActionPointNature] OFF
GO
ALTER TABLE [dbo].[EQM_ActionPlan]  WITH CHECK ADD  CONSTRAINT [FK_EQM_ActionPlan_EQM_ActionPoint] FOREIGN KEY([ActionPointID])
REFERENCES [dbo].[EQM_ActionPoint] ([ActionPointID])
GO
ALTER TABLE [dbo].[EQM_ActionPlan] CHECK CONSTRAINT [FK_EQM_ActionPlan_EQM_ActionPoint]
GO
ALTER TABLE [dbo].[EQM_ActionPoint]  WITH CHECK ADD  CONSTRAINT [FK_EQM_ActionPoint_EQM_ActionPointNature] FOREIGN KEY([NatureID])
REFERENCES [dbo].[EQM_ActionPointNature] ([NatureID])
GO
ALTER TABLE [dbo].[EQM_ActionPoint] CHECK CONSTRAINT [FK_EQM_ActionPoint_EQM_ActionPointNature]
GO
ALTER TABLE [dbo].[EQM_ActionPoint]  WITH CHECK ADD  CONSTRAINT [FK_EQM_ActionPoint_EQM_Audit] FOREIGN KEY([AuditID])
REFERENCES [dbo].[EQM_Audit] ([AuditID])
GO
ALTER TABLE [dbo].[EQM_ActionPoint] CHECK CONSTRAINT [FK_EQM_ActionPoint_EQM_Audit]
GO
ALTER TABLE [dbo].[EQM_Audit]  WITH CHECK ADD  CONSTRAINT [FK_EQM_Audit_EQM_Process] FOREIGN KEY([ProcessID])
REFERENCES [dbo].[EQM_Process] ([ProcessID])
GO
ALTER TABLE [dbo].[EQM_Audit] CHECK CONSTRAINT [FK_EQM_Audit_EQM_Process]
GO
