CREATE TABLE [dbo].[posts] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [user_id]        INT            NOT NULL,
    [image]          VARCHAR (200)  NOT NULL,
    [caption]        NVARCHAR (100) NULL,
    [datetime_stamp] DATETIME       DEFAULT (getdate()) NULL,
    CONSTRAINT [pk_posts] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fk_posts] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
);

