CREATE TABLE [dbo].[comments] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [post_id]        INT            NOT NULL,
    [user_id]        INT            NOT NULL,
    [message]        NVARCHAR (200) NOT NULL,
    [datetime_stamp] DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fk_comments_posts] FOREIGN KEY ([post_id]) REFERENCES [dbo].[posts] ([id]),
    CONSTRAINT [fk_comments_users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
);

