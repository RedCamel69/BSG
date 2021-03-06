USE [PluginBlog]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 14/04/2014 22:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[UrlSlug] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Post]    Script Date: 14/04/2014 22:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[ShortDescription] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Meta] [nvarchar](1000) NOT NULL,
	[UrlSlug] [nvarchar](1000) NOT NULL,
	[Published] [bit] NOT NULL,
	[PostedOn] [datetime] NOT NULL,
	[LastModified] [datetime] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_dbo.Post] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tag]    Script Date: 14/04/2014 22:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[UrlSlug] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TagPost]    Script Date: 14/04/2014 22:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagPost](
	[Tag_Id] [int] NOT NULL,
	[Post_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TagPost] PRIMARY KEY CLUSTERED 
(
	[Tag_Id] ASC,
	[Post_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Post_dbo.Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_dbo.Post_dbo.Category_CategoryId]
GO
ALTER TABLE [dbo].[TagPost]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TagPost_dbo.Post_Post_Id] FOREIGN KEY([Post_Id])
REFERENCES [dbo].[Post] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TagPost] CHECK CONSTRAINT [FK_dbo.TagPost_dbo.Post_Post_Id]
GO
ALTER TABLE [dbo].[TagPost]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TagPost_dbo.Tag_Tag_Id] FOREIGN KEY([Tag_Id])
REFERENCES [dbo].[Tag] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TagPost] CHECK CONSTRAINT [FK_dbo.TagPost_dbo.Tag_Tag_Id]
GO
