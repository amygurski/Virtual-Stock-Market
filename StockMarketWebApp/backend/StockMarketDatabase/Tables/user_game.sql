CREATE TABLE [dbo].[user_game] (
    [game_id] INT NOT NULL,
    [user_id] INT NOT NULL,
    CONSTRAINT [pk_usergame_userid_gameid] PRIMARY KEY CLUSTERED ([game_id] ASC, [user_id] ASC),
    CONSTRAINT [fk_usergame_games] FOREIGN KEY ([game_id]) REFERENCES [dbo].[games] ([id]),
    CONSTRAINT [fk_usergame_users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
);

