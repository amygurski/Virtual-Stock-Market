
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the Stock Market Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='StockMarketDB')
DROP DATABASE StockMarketDB;
GO

-- Create a new Stock Market Database
CREATE DATABASE StockMarketDB;
GO

-- Switch to the Stock Market Database
USE StockMarketDB
GO

BEGIN TRANSACTION;

CREATE TABLE users
(
	id			int		Primary Key	identity(1,1),
	firstname   varchar(50) not null,
	email		varchar(50) not null,
	username	varchar(50)	not null,
	password	varchar(50)	not null,
	salt		varchar(50)	not null,
	role		varchar(50)	default('user'),

);

COMMIT TRANSACTION;

BEGIN TRANSACTION;

CREATE TABLE games
(
	
	id int Primary Key identity(1653, 1),
	creator_id int not null,
	game_name varchar(50) not null,
	date_created date not null,
	end_date date not null,
	game_desc varchar (300) null,

	Constraint fk_games_users foreign key (creator_id) references users (id)

);

COMMIT TRANSACTION;

BEGIN TRANSACTION;

CREATE TABLE stocks
(

	stock_symbol varchar(12) primary key not null,
	name_of_company varchar(50) not null,
	current_share_price money not null,
	percent_daily_change varchar(5) not null,

);

COMMIT TRANSACTION;

BEGIN TRANSACTION;

CREATE TABLE stock_history
(
	symbol varchar(12) Primary Key,
	time_stamp datetime null,
	trading_day date not null,
	open_price varchar(10) null,
	daily_high varchar(10) null,
	daily_low varchar(10) null,
	close_price varchar(10) null,
	volume varchar(20) null,
	open_interest varchar(20) null,

	constraint fk_stock_history_stocks foreign key (symbol) references stocks (stock_symbol)
);

COMMIT TRANSACTION;

BEGIN TRANSACTION;

CREATE TABLE transactions
(

	user_id int not null,
	game_id int not null,
	stock_symbol varchar(12) not null,
	number_of_shares int not null,
	transaction_share_price money not null,
	is_buy bit not null,

	constraint fk_transactions_users foreign key (user_id) references users (id),
	constraint fk_transactions_games foreign key (game_id) references games (id),
	constraint fk_transactions_stocks foreign key (stock_symbol) references stocks (stock_symbol),
	constraint pk_transactions_user_id_game_id primary key (user_id, game_id)

);

COMMIT TRANSACTION;

-- Seed Database Section
BEGIN TRANSACTION;

-- default username of 'user' and default password of 'greatwall'
INSERT INTO users
  (firstname, email, username, password, salt, role)
VALUES
  ('john', 'email@email.com', 'user', 'jUE98uhvS5tdIlxRsmz1W7/Qaqo=', '9CWPUTvXqQ4=', 'User'),
  ('Mike', 'mmorel@TE.com', 'webmaster', 'aSepEtqUZVo4EXu71Kswa6LSJgU=', 'ugcDbPAWItU=', 'Admin');

COMMIT TRANSACTION;

--Seed database section
BEGIN TRANSACTION;

--default games for testing
INSERT INTO games
	(creator_id, game_name, date_created, end_date)
VALUES
	(1, 'testGame1', '2020-04-07', '2020-04-08'),
	(1, 'testGame2', '2020-03-09', '2020-04-09'),
	(1, 'testGame3', '2020-04-07', '2020-04-07'),
	(1, 'testGame4', '2020-03-10', '2020-04-15');

COMMIT TRANSACTION;

BEGIN TRANSACTION;

--default games for testing
INSERT INTO stocks
	(stock_symbol, name_of_company, current_share_price, percent_daily_change)
VALUES
	('SYSTEMTRANS', 'Default Transaction', 1, 0);

COMMIT TRANSACTION;

BEGIN TRANSACTION;

INSERT INTO transactions
	(user_id, game_id, stock_symbol, number_of_shares, transaction_share_price, is_buy)
VALUES
	(1, 1653,'SYSTEMTRANS', 1, 100000.00, 0),
	(1, 1654,'SYSTEMTRANS', 1, 100000.00, 0),
	(1, 1655,'SYSTEMTRANS', 1, 100000.00, 0),
	(1, 1656,'SYSTEMTRANS', 1, 100000.00, 0);

COMMIT TRANSACTION;