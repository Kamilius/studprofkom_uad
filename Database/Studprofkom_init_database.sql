﻿USE [master]
GO
/****** Object:  Database [StudProfkomUAD]    Script Date: 15.10.2014 7:25:04 ******/
CREATE DATABASE [StudProfkomUAD]
GO
USE [StudProfkomUAD]
/****** Object:  Table [dbo].[Application]    Script Date: 15.10.2014 7:25:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Application](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](250) NULL,
	[Faculty_FK] [int] NULL,
	[Phone] [nvarchar](25) NULL,
	[CreateDate] [datetime] NULL,
	[City] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 15.10.2014 7:25:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NewsArticle]    Script Date: 15.10.2014 7:25:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsArticle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Text] [nvarchar](max) NOT NULL,
	[ImageName] [nvarchar](255) NULL,
	[IsEvent] [bit] NOT NULL,
	[EventShortDescription] [nvarchar](255) NULL,
	[GooglePlusUserId] [nvarchar](50) NULL,
	[GooglePlusAlbumId] [nvarchar](50) NULL,
	[ArticleShortDescription] [nvarchar](max) NULL,
	[PublicationDate] [bigint] NOT NULL,
	[EventStartDate] [bigint] NULL,
 CONSTRAINT [PK_NewsArticle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [StudProfkomUAD] SET  READ_WRITE 
GO
