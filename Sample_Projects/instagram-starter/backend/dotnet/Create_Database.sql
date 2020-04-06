/*
Deployment script for TEgram
*/

GO
USE [master];

GO

GO
PRINT N'Creating database TEGram...'
GO
CREATE DATABASE TEGram
GO
USE TEGram;
GO

PRINT N'Creating [dbo].[comments]...';
GO
CREATE TABLE [dbo].[comments] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [post_id]        INT            NOT NULL,
    [user_id]        INT            NOT NULL,
    [message]        NVARCHAR (200) NOT NULL,
    [datetime_stamp] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[favorites]...';
GO
CREATE TABLE [dbo].[favorites] (
    [user_id] INT NOT NULL,
    [post_id] INT NOT NULL,
    CONSTRAINT [pk_favorites] PRIMARY KEY CLUSTERED ([user_id] ASC, [post_id] ASC)
);


GO
PRINT N'Creating [dbo].[likes]...';
GO
CREATE TABLE [dbo].[likes] (
    [user_id] INT NOT NULL,
    [post_id] INT NOT NULL,
    CONSTRAINT [pk_likes] PRIMARY KEY CLUSTERED ([user_id] ASC, [post_id] ASC)
);


GO
PRINT N'Creating [dbo].[posts]...';
GO
CREATE TABLE [dbo].[posts] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [user_id]        INT            NOT NULL,
    [image]          VARCHAR (200)  NOT NULL,
    [caption]        NVARCHAR (100) NULL,
    [datetime_stamp] DATETIME       NULL,
    CONSTRAINT [pk_posts] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[users]...';
GO
CREATE TABLE [dbo].[users] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [username] VARCHAR (50)  NOT NULL,
    [password] VARCHAR (50)  NOT NULL,
    [salt]     VARCHAR (50)  NOT NULL,
    [role]     VARCHAR (50)  NULL,
    [image]    VARCHAR (200) NULL,
    CONSTRAINT [pk_users] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating unnamed constraint on [dbo].[comments]...';
GO
ALTER TABLE [dbo].[comments]
    ADD DEFAULT (getdate()) FOR [datetime_stamp];


GO
PRINT N'Creating unnamed constraint on [dbo].[posts]...';
GO
ALTER TABLE [dbo].[posts]
    ADD DEFAULT (getdate()) FOR [datetime_stamp];


GO
PRINT N'Creating unnamed constraint on [dbo].[users]...';
GO
ALTER TABLE [dbo].[users]
    ADD DEFAULT ('user') FOR [role];


GO
PRINT N'Creating [dbo].[fk_comments_posts]...';
GO
ALTER TABLE [dbo].[comments]
    ADD CONSTRAINT [fk_comments_posts] FOREIGN KEY ([post_id]) REFERENCES [dbo].[posts] ([id]);


GO
PRINT N'Creating [dbo].[fk_comments_users]...';
GO
ALTER TABLE [dbo].[comments]
    ADD CONSTRAINT [fk_comments_users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id]);


GO
PRINT N'Creating [dbo].[fk_favorites_posts]...';
GO
ALTER TABLE [dbo].[favorites]
    ADD CONSTRAINT [fk_favorites_posts] FOREIGN KEY ([post_id]) REFERENCES [dbo].[posts] ([id]);


GO
PRINT N'Creating [dbo].[fk_favorites_users]...';
GO
ALTER TABLE [dbo].[favorites]
    ADD CONSTRAINT [fk_favorites_users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id]);


GO
PRINT N'Creating [dbo].[fk_likes_posts]...';
GO
ALTER TABLE [dbo].[likes]
    ADD CONSTRAINT [fk_likes_posts] FOREIGN KEY ([post_id]) REFERENCES [dbo].[posts] ([id]);


GO
PRINT N'Creating [dbo].[fk_likes_users]...';
GO
ALTER TABLE [dbo].[likes]
    ADD CONSTRAINT [fk_likes_users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id]);


GO
PRINT N'Creating [dbo].[fk_posts]...';
GO

ALTER TABLE [dbo].[posts]
    ADD CONSTRAINT [fk_posts] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id]);
GO

PRINT N'Database schema created.  Loading Data...';
GO

SET IDENTITY_INSERT [dbo].[users] ON 
INSERT [dbo].[users] ([id], [username], [password], [salt], [role], [image]) VALUES (5, N'Rick Astley', N'L52gY4/xxjO5NdDCexRsCcBfnTM=', N'm2I90fqfEx4=', N'User', N'https://ui-avatars.com/api/?name=Rick+Astley&length=2&size=128&rounded=true&color=FFD700&background=8B4513&uppercase=false&bold=true')
INSERT [dbo].[users] ([id], [username], [password], [salt], [role], [image]) VALUES (6, N'Josh T', N'56Np2Gz1L0gSxMm2BuBBuwMtWuc=', N'tEqzVUcB/QI=', N'User', N'https://ui-avatars.com/api/?name=Josh+T&length=2&size=128&rounded=true&color=FFE4C4&background=7FFF00&uppercase=false&bold=true')
INSERT [dbo].[users] ([id], [username], [password], [salt], [role], [image]) VALUES (7, N'Cohort 10', N'/0KPX1RkQcQIMoIsN0g27eUKe+s=', N'EhZEC8CSxlQ=', N'User', N'https://ui-avatars.com/api/?name=Cohort+10&length=2&size=128&rounded=true&color=FAFAD2&background=483D8B&uppercase=false&bold=true')
INSERT [dbo].[users] ([id], [username], [password], [salt], [role], [image]) VALUES (8, N'Tech Elevator', N'aYXfdC5WAHaSjghxJFkricAr088=', N'f61B4t/HOMY=', N'User', N'https://ui-avatars.com/api/?name=Tech+Elevator&length=2&size=128&rounded=true&color=FAFAD2&background=8B4513&uppercase=false&bold=true')
SET IDENTITY_INSERT [dbo].[users] OFF
SET IDENTITY_INSERT [dbo].[posts] ON 
INSERT [dbo].[posts] ([id], [user_id], [image], [caption], [datetime_stamp]) VALUES (8, 5, N'https://res.cloudinary.com/tech-elevator/image/upload/v1554345353/TEMP%20-%20TE%20Gram/lp2huzhbruifuyetet2n.jpg', N'My first selfie!', CAST(N'2019-04-03T22:35:58.467' AS DateTime))
INSERT [dbo].[posts] ([id], [user_id], [image], [caption], [datetime_stamp]) VALUES (9, 6, N'https://res.cloudinary.com/tech-elevator/image/upload/v1554345419/TEMP%20-%20TE%20Gram/eggnutbc7exmk5jiudvx.jpg', N'I hope it looks like this on opening day!', CAST(N'2019-04-03T22:37:07.667' AS DateTime))
INSERT [dbo].[posts] ([id], [user_id], [image], [caption], [datetime_stamp]) VALUES (10, 7, N'https://res.cloudinary.com/tech-elevator/image/upload/v1554384089/TEMP%20-%20TE%20Gram/sehyde2nsja4nu6rsjvf.png', N'Loved attending the St Patrick''s Day #learntocode', CAST(N'2019-04-04T09:21:49.147' AS DateTime))
INSERT [dbo].[posts] ([id], [user_id], [image], [caption], [datetime_stamp]) VALUES (12, 8, N'https://res.cloudinary.com/tech-elevator/image/upload/v1554407052/TEMP%20-%20TE%20Gram/ptofflxnm45iou3kbbin.png', N'Cohort 7 Group Shot!', CAST(N'2019-04-04T15:44:41.267' AS DateTime))
INSERT [dbo].[posts] ([id], [user_id], [image], [caption], [datetime_stamp]) VALUES (13, 8, N'https://res.cloudinary.com/tech-elevator/image/upload/v1554407104/TEMP%20-%20TE%20Gram/vwiuai7ve7gakrgqpiqx.jpg', N'Throwback to Cohort 0!', CAST(N'2019-04-04T15:45:11.600' AS DateTime))
INSERT [dbo].[posts] ([id], [user_id], [image], [caption], [datetime_stamp]) VALUES (14, 8, N'https://res.cloudinary.com/tech-elevator/image/upload/v1554407132/TEMP%20-%20TE%20Gram/eyjkj7rir8fui9s6gp7v.jpg', N'What a funny group!', CAST(N'2019-04-04T15:45:49.840' AS DateTime))
INSERT [dbo].[posts] ([id], [user_id], [image], [caption], [datetime_stamp]) VALUES (15, 8, N'https://res.cloudinary.com/tech-elevator/image/upload/v1554407230/TEMP%20-%20TE%20Gram/wkiue8zjrlnxetuovhdq.png', N'Getting ready for matchmaking! #dreamjob', CAST(N'2019-04-04T15:47:19.117' AS DateTime))
INSERT [dbo].[posts] ([id], [user_id], [image], [caption], [datetime_stamp]) VALUES (16, 8, N'https://res.cloudinary.com/tech-elevator/image/upload/v1554407270/TEMP%20-%20TE%20Gram/n0lbjc1rwsaqgvqdgihe.jpg', N'Hear great war stories from experienced developers!', CAST(N'2019-04-04T15:48:00.680' AS DateTime))
INSERT [dbo].[posts] ([id], [user_id], [image], [caption], [datetime_stamp]) VALUES (17, 5, N'https://res.cloudinary.com/tech-elevator/image/upload/v1554317361/TEMP%20-%20TE%20Gram/djkwllxzdq63n6gtd8vj.jpg', N'Blaze, at ATTENTION', CAST(N'2019-04-04T16:48:00.680' AS DateTime))
INSERT [dbo].[posts] ([id], [user_id], [image], [caption], [datetime_stamp]) VALUES (18, 5, N'https://cdn.pixabay.com/photo/2016/03/25/02/24/cute-1278095__340.jpg', N'Future terror!', CAST(N'2019-04-04T17:18:00.680' AS DateTime))



SET IDENTITY_INSERT [dbo].[posts] OFF
SET IDENTITY_INSERT [dbo].[comments] ON 
INSERT [dbo].[comments] ([id], [post_id], [user_id], [message], [datetime_stamp]) VALUES (6, 9, 7, N'It certainly did not!', CAST(N'2019-04-04T09:20:54.820' AS DateTime))
INSERT [dbo].[comments] ([id], [post_id], [user_id], [message], [datetime_stamp]) VALUES (7, 9, 5, N'I remember this game though!', CAST(N'2019-04-04T15:20:09.780' AS DateTime))
INSERT [dbo].[comments] ([id], [post_id], [user_id], [message], [datetime_stamp]) VALUES (8, 14, 5, N'I think that was Cohort[6]!', CAST(N'2019-04-04T15:46:24.217' AS DateTime))
SET IDENTITY_INSERT [dbo].[comments] OFF
INSERT [dbo].[favorites] ([user_id], [post_id]) VALUES (6, 8)
INSERT [dbo].[favorites] ([user_id], [post_id]) VALUES (6, 9)
INSERT [dbo].[favorites] ([user_id], [post_id]) VALUES (6, 12)
INSERT [dbo].[favorites] ([user_id], [post_id]) VALUES (6, 13)
INSERT [dbo].[favorites] ([user_id], [post_id]) VALUES (6, 14)
INSERT [dbo].[favorites] ([user_id], [post_id]) VALUES (6, 16)
INSERT [dbo].[favorites] ([user_id], [post_id]) VALUES (7, 8)
INSERT [dbo].[favorites] ([user_id], [post_id]) VALUES (7, 9)
INSERT [dbo].[likes] ([user_id], [post_id]) VALUES (5, 9)
INSERT [dbo].[likes] ([user_id], [post_id]) VALUES (5, 14)
INSERT [dbo].[likes] ([user_id], [post_id]) VALUES (6, 8)
INSERT [dbo].[likes] ([user_id], [post_id]) VALUES (6, 9)
INSERT [dbo].[likes] ([user_id], [post_id]) VALUES (6, 10)
INSERT [dbo].[likes] ([user_id], [post_id]) VALUES (6, 13)
INSERT [dbo].[likes] ([user_id], [post_id]) VALUES (7, 8)
INSERT [dbo].[likes] ([user_id], [post_id]) VALUES (7, 9)
INSERT [dbo].[likes] ([user_id], [post_id]) VALUES (8, 12)
GO

PRINT N'Done.';
GO



/****
https://cdn.pixabay.com/photo/2016/03/25/02/24/cute-1278095__340.jpg
https://res.cloudinary.com/tech-elevator/image/upload/v1554317361/TEMP%20-%20TE%20Gram/djkwllxzdq63n6gtd8vj.jpg
https://www.k9ofmine.com/wp-content/uploads/2017/06/best-dog-booties-800x534.jpg
***/