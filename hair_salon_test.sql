CREATE DATABASE [hair_salon_test]
GO
USE [hair_salon_test]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 6/13/2017 8:51:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stylists]    Script Date: 6/13/2017 8:51:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (26, N'Adam', 1)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (27, N'Michelle', 2)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (28, N'Miguel', 3)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (29, N'Michael', 4)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (30, N'Hunter', 5)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (31, N'Josie', 6)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (32, N'Noah', 7)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (33, N'Levi', 8)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (34, N'Charlie', 9)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (35, N'Rebecca', 10)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (36, N'Edmund', 10)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (37, N'Marcus', 9)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (38, N'Pete', 8)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (39, N'David', 7)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (40, N'Joshua', 6)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (41, N'Jessica', 5)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (42, N'Lebron', 4)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (43, N'Guy', 3)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (44, N'Lucas', 2)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (45, N'Lewise', 1)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([id], [name]) VALUES (1, N'Sarah')
INSERT [dbo].[stylists] ([id], [name]) VALUES (2, N'Don')
INSERT [dbo].[stylists] ([id], [name]) VALUES (3, N'Mitch')
INSERT [dbo].[stylists] ([id], [name]) VALUES (4, N'Kylea')
INSERT [dbo].[stylists] ([id], [name]) VALUES (5, N'Diamond')
INSERT [dbo].[stylists] ([id], [name]) VALUES (6, N'Hunter')
INSERT [dbo].[stylists] ([id], [name]) VALUES (7, N'Richtofen')
INSERT [dbo].[stylists] ([id], [name]) VALUES (8, N'Lincoln')
INSERT [dbo].[stylists] ([id], [name]) VALUES (9, N'Lincoln')
INSERT [dbo].[stylists] ([id], [name]) VALUES (10, N'Tyler')
SET IDENTITY_INSERT [dbo].[stylists] OFF
