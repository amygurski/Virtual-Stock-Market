CREATE TABLE [dbo].[likes] (
    [user_id] INT NOT NULL,
    [post_id] INT NOT NULL,
    CONSTRAINT [pk_likes] PRIMARY KEY CLUSTERED ([user_id] ASC, [post_id] ASC),
    CONSTRAINT [fk_likes_posts] FOREIGN KEY ([post_id]) REFERENCES [dbo].[posts] ([id]),
    CONSTRAINT [fk_likes_users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
);

