CREATE TABLE [dbo].[stocks] (
    [stock_symbol]         VARCHAR (6)  NOT NULL,
    [name_of_company]      VARCHAR (50) NOT NULL,
    [current_share_price]  FLOAT (53)   NOT NULL,
    [percent_daily_change] FLOAT (53)   NOT NULL,
    PRIMARY KEY CLUSTERED ([stock_symbol] ASC)
);

