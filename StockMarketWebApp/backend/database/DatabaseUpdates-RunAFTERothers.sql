BEGIN TRANSACTION

INSERT INTO stocks
	(stock_symbol, name_of_company, current_share_price, percent_daily_change)
VALUES
	('COMFEE', 'Commission Fee', 19.95, 0);

COMMIT TRANSACTION;