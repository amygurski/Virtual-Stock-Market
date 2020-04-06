CREATE TABLE [dbo].[favorites] (
    [user_id] INT NOT NULL,
    [post_id] INT NOT NULL,
    CONSTRAINT [pk_favorites] PRIMARY KEY CLUSTERED ([user_id] ASC, [post_id] ASC),
    CONSTRAINT [fk_favorites_posts] FOREIGN KEY ([post_id]) REFERENCES [dbo].[posts] ([id]),
    CONSTRAINT [fk_favorites_users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
);

