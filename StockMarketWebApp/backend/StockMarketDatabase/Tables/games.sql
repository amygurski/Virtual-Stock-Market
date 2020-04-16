CREATE TABLE [dbo].[games] (
    [id]           INT           IDENTITY (1653, 1) NOT NULL,
    [creator_id]   INT           NOT NULL,
    [game_name]    VARCHAR (50)  NOT NULL,
    [date_created] DATE          NOT NULL,
    [end_date]     DATETIME      NOT NULL,
    [game_desc]    VARCHAR (300) NULL,
    [is_completed] BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fk_games_users] FOREIGN KEY ([creator_id]) REFERENCES [dbo].[users] ([id])
);

