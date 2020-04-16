CREATE TABLE [dbo].[transactions] (
    [id]                      INT         IDENTITY (1, 1) NOT NULL,
    [user_id]                 INT         NOT NULL,
    [game_id]                 INT         NOT NULL,
    [stock_symbol]            VARCHAR (6) NOT NULL,
    [number_of_shares]        INT         NOT NULL,
    [transaction_share_price] FLOAT (53)  NOT NULL,
    [transaction_date]        DATETIME    NOT NULL,
    [is_buy]                  BIT         NOT NULL,
    [net_transaction_change]  FLOAT (53)  NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fk_transactions_games] FOREIGN KEY ([game_id]) REFERENCES [dbo].[games] ([id]),
    CONSTRAINT [fk_transactions_stocks] FOREIGN KEY ([stock_symbol]) REFERENCES [dbo].[stocks] ([stock_symbol]),
    CONSTRAINT [fk_transactions_users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
);

