CREATE TABLE [dbo].[stock_history] (
    [id]           INT         IDENTITY (1, 1) NOT NULL,
    [stock_symbol] VARCHAR (6) NOT NULL,
    [trading_day]  DATE        NOT NULL,
    [open_price]   FLOAT (53)  NULL,
    [daily_high]   FLOAT (53)  NULL,
    [daily_low]    FLOAT (53)  NULL,
    [close_price]  FLOAT (53)  NULL,
    [volume]       INT         NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fk_stock_history] FOREIGN KEY ([stock_symbol]) REFERENCES [dbo].[stocks] ([stock_symbol])
);

