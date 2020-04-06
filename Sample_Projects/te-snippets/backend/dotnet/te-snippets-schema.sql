USE master
GO

DROP DATABASE IF EXISTS [te-snippets]
GO

CREATE DATABASE [te-snippets]
GO


CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[salt] [varchar](50) NOT NULL,
	[role] [varchar](50) NULL,
 CONSTRAINT [pk_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[users] ADD  DEFAULT ('user') FOR [role]
GO


CREATE TABLE [dbo].[snippets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](255) NOT NULL,
	[filename] [nvarchar](255) NOT NULL,
	[sourcecode] [text] NOT NULL,
	[tags] [nvarchar](255) NOT NULL,
	[user_id] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


