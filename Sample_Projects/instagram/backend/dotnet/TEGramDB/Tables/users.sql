CREATE TABLE [dbo].[users] (
    [id]		INT           IDENTITY (1, 1) NOT NULL,
    [username]  VARCHAR (50)	NOT NULL,
	[password]	VARCHAR(50)		NOT NULL,
	[salt]		VARCHAR(50)		NOT NULL,
	[role]		VARCHAR(50)		default('user'),
    [image]		VARCHAR (200)	NULL,
    CONSTRAINT [pk_users] PRIMARY KEY CLUSTERED ([id] ASC)
);

