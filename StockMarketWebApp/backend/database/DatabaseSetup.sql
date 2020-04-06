
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
	id			int			identity(1,1),
	username	varchar(50)	not null,
	password	varchar(50)	not null,
	salt		varchar(50)	not null,
	role		varchar(50)	default('user'),

	constraint pk_users primary key (id)
);


COMMIT TRANSACTION;

-- Seed Database Section
BEGIN TRANSACTION;

-- default username of 'user' and default password of 'greatwall'
INSERT INTO users
  (username,password,salt,role)
VALUES
  ('user', 'jUE98uhvS5tdIlxRsmz1W7/Qaqo=', '9CWPUTvXqQ4=', 'User');

COMMIT TRANSACTION;