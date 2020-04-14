-- Switch to the system (aka master) database
USE master;
GO

-- Delete the Hangfire Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='StockMarketHangfireDB')
DROP DATABASE StockMarketHangfireDB;
GO

-- Create a new Stock Market Database
CREATE DATABASE StockMarketHangfireDB;
GO