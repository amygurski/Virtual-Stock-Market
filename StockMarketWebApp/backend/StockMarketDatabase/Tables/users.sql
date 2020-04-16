CREATE TABLE [dbo].[users] (
    [id]        INT          IDENTITY (1, 1) NOT NULL,
    [firstname] VARCHAR (50) NOT NULL,
    [email]     VARCHAR (50) NOT NULL,
    [username]  VARCHAR (50) NOT NULL,
    [password]  VARCHAR (50) NOT NULL,
    [salt]      VARCHAR (50) NOT NULL,
    [role]      VARCHAR (50) DEFAULT ('user') NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

