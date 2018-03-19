USE [Test123]
GO
/****** Object:  Table [dbo].[Control]    Script Date: 3/19/2018 6:11:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Control](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameControl] [nvarchar](50) NULL,
	[IsRequired] [bit] NULL,
	[Type] [int] NULL,
	[NameChild] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_Control] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Form]    Script Date: 3/19/2018 6:11:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Form](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameForm] [nvarchar](50) NULL,
	[IdControl] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_Form] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormControlMapping]    Script Date: 3/19/2018 6:11:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormControlMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdForm] [int] NULL,
	[IdControl] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_FormControlMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tank]    Script Date: 3/19/2018 6:11:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tank](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_Tank] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TankData]    Script Date: 3/19/2018 6:11:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TankData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTank] [int] NULL,
	[IdFormTankMapping] [nchar](10) NULL,
	[Data] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_TankData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TankFormMapping]    Script Date: 3/19/2018 6:11:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TankFormMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTank] [int] NULL,
	[IdForm] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_TankFormMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FormControlMapping]  WITH CHECK ADD  CONSTRAINT [FK_FormControlMapping_Control] FOREIGN KEY([IdForm])
REFERENCES [dbo].[Control] ([Id])
GO
ALTER TABLE [dbo].[FormControlMapping] CHECK CONSTRAINT [FK_FormControlMapping_Control]
GO
ALTER TABLE [dbo].[FormControlMapping]  WITH CHECK ADD  CONSTRAINT [FK_FormControlMapping_Form] FOREIGN KEY([IdForm])
REFERENCES [dbo].[Form] ([Id])
GO
ALTER TABLE [dbo].[FormControlMapping] CHECK CONSTRAINT [FK_FormControlMapping_Form]
GO
ALTER TABLE [dbo].[TankData]  WITH CHECK ADD  CONSTRAINT [FK_TankData_Tank] FOREIGN KEY([IdTank])
REFERENCES [dbo].[Tank] ([Id])
GO
ALTER TABLE [dbo].[TankData] CHECK CONSTRAINT [FK_TankData_Tank]
GO
ALTER TABLE [dbo].[TankFormMapping]  WITH CHECK ADD  CONSTRAINT [FK_TankFormMapping_Form] FOREIGN KEY([IdForm])
REFERENCES [dbo].[Form] ([Id])
GO
ALTER TABLE [dbo].[TankFormMapping] CHECK CONSTRAINT [FK_TankFormMapping_Form]
GO
ALTER TABLE [dbo].[TankFormMapping]  WITH CHECK ADD  CONSTRAINT [FK_TankFormMapping_Tank] FOREIGN KEY([IdTank])
REFERENCES [dbo].[Tank] ([Id])
GO
ALTER TABLE [dbo].[TankFormMapping] CHECK CONSTRAINT [FK_TankFormMapping_Tank]
GO
