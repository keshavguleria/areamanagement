USE [master]

GO
CREATE DATABASE [AreaManagement]
GO

USE [AreaManagement]
GO
CREATE TABLE [dbo].[Areas](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
	[UpdatedBy] [int] NULL)
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[UserName] [nvarchar](200) NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL)
GO

SET IDENTITY_INSERT [dbo].[Areas] ON 

INSERT [dbo].[Areas] ([Id], [Name], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (1, N'Front Lawn', CAST(N'2020-01-29T06:12:53.8439434+00:00' AS DateTimeOffset), 1, CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), 0)
SET IDENTITY_INSERT [dbo].[Areas] OFF

SET IDENTITY_INSERT [dbo].[Users] ON 
INSERT [dbo].[Users] ([Id], [UserName], [CreatedOn]) VALUES (1, N'admin', CAST(N'2020-01-28T14:32:26.2400000+00:00' AS DateTimeOffset))
SET IDENTITY_INSERT [dbo].[Users] OFF

ALTER TABLE [dbo].[Users] ADD  DEFAULT (getutcdate()) FOR [CreatedOn]
GO

