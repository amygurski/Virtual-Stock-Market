USE [StockMarketDB]
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [firstname], [email], [username], [password], [salt], [role]) VALUES (1, N'john', N'email@email.com', N'user', N'jUE98uhvS5tdIlxRsmz1W7/Qaqo=', N'9CWPUTvXqQ4=', N'User')
INSERT [dbo].[users] ([id], [firstname], [email], [username], [password], [salt], [role]) VALUES (2, N'Mike', N'mmorel@TE.com', N'webmaster', N'aSepEtqUZVo4EXu71Kswa6LSJgU=', N'ugcDbPAWItU=', N'Admin')
INSERT [dbo].[users] ([id], [firstname], [email], [username], [password], [salt], [role]) VALUES (3, N'Dan', N'test@test', N'Dan', N'0PeH6GLfE21aqqyYsdTuK4BeN84=', N'AlD7BvS/cwI=', N'User')
INSERT [dbo].[users] ([id], [firstname], [email], [username], [password], [salt], [role]) VALUES (4, N'Amy', N'test@test', N'Amy', N'ghPYL72j3cr5WyL+Mh8ws4S6mUE=', N'y2+/K6+HKbA=', N'User')
INSERT [dbo].[users] ([id], [firstname], [email], [username], [password], [salt], [role]) VALUES (5, N'Allan', N'test@test', N'Allan', N'FiHPuP1cZlTQF+CbGGQuYuuumGE=', N'OMfJY9cw2GQ=', N'User')
INSERT [dbo].[users] ([id], [firstname], [email], [username], [password], [salt], [role]) VALUES (6, N'Chelsea', N'test@test', N'Chelsea', N'tjP4ZPSKoPlsawhEFOY2z+bzttE=', N'SWpaSU39WlI=', N'User')
INSERT [dbo].[users] ([id], [firstname], [email], [username], [password], [salt], [role]) VALUES (7, N'Mike', N'test@test', N'Mike', N'0HwxKTQPp+nLfM2IVTZdOFGRmuI=', N'J7DrCWNHp8Q=', N'User')
SET IDENTITY_INSERT [dbo].[users] OFF
GO
