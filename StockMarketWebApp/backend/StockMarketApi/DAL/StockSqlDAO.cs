using StockMarketApi.Models.ApiReturnModels;
using StockMarketApi.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.DAL
{
    public class StockSqlDAO : IStockDAO
    {
        private readonly string connectionString;

        public StockSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets all current stock information
        /// </summary>
        /// <returns></returns>
        public IList<CurrentStocksModel> GetCurrentStocks()
        {
            List<CurrentStocksModel> result = new List<CurrentStocksModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM stocks", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(MapRowToCurrentStock(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Get single stock details
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public CurrentStocksModel GetStockBySymbol(string symbol)
        {
            CurrentStocksModel result = new CurrentStocksModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM stocks WHERE stock_symbol = @symbol", conn);
                    cmd.Parameters.AddWithValue("@symbol", symbol);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = MapRowToCurrentStock(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// CURRENTLY NOTE USED
        /// Gets 6 month stock history
        /// </summary>
        /// <returns></returns>
        public IList<StockHistoryModel> GetAllStocksHistory()
        {
            List<StockHistoryModel> result = new List<StockHistoryModel>();

            //Get 6 months ago
            //Subtract 6 months
            DateTime sixMonthsAgo = DateTime.Today.AddMonths(-6);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from stock_history where trading_day >= @startdate", conn);
                    cmd.Parameters.AddWithValue("@startdate", sixMonthsAgo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(MapRowToStockHistory(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return result;
        }

        public void UpdateStock(StockModel stock)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"UPDATE stocks 
                                                      SET current_share_price = @currentPrice,
                                                          percent_daily_change = @percentChange
                                                      WHERE stock_symbol = @stockSymbol", conn);
                    cmd.Parameters.AddWithValue("@stock_symbol", stock.Symbol);
                    cmd.Parameters.AddWithValue("@current_share_price", stock.LastPrice);
                    cmd.Parameters.AddWithValue("@percent_daily_change", stock.PercentChange);

                    cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Saves a stock to the database
        /// </summary>
        /// <param name="stock"></param>
        public void SaveStock(StockModel stock)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO stocks (stock_symbol, name_of_company, current_share_price, percent_daily_change) 
                                                      VALUES (@stock_symbol, @name_of_company, @current_share_price, @percent_daily_change);", conn);
                    cmd.Parameters.AddWithValue("@stock_symbol", stock.Symbol);
                    cmd.Parameters.AddWithValue("@name_of_company", stock.Name);
                    cmd.Parameters.AddWithValue("@current_share_price", stock.LastPrice);
                    cmd.Parameters.AddWithValue("@percent_daily_change", stock.PercentChange);

                    cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            //return stockId;
        }

        /// <summary>
        /// Get info for research stocks view where user can see some preliminary details aboutt he current stock
        /// </summary>
        /// <returns>list of researchstocksAPImode</returns>
        public IList<ResearchStocksAPIModel> GetStocksResearch()
        {
            List<ResearchStocksAPIModel> result = new List<ResearchStocksAPIModel>();

            //Get 6 months ago
            //Subtract 6 months
            DateTime startDate = DateTime.Today.AddMonths(-6);

            string sql = @"select stock_history.stock_symbol, stocks.name_of_company, stocks.current_share_price, stocks.percent_daily_change, MAX(daily_high) AS six_month_high, MIN(daily_low) AS six_month_low
                        from stock_history
                        join stocks
                        on stock_history.stock_symbol = stocks.stock_symbol
                        where trading_day >= '2019-10-14'
                        group by stock_history.stock_symbol, stocks.name_of_company, stocks.current_share_price, stocks.percent_daily_change";


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@startdate", startDate);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SixMonthHighLowModel stock = new SixMonthHighLowModel();
                        stock.StockSymbol = Convert.ToString(reader["stock_symbol"]);
                        stock.SixMonthLow = Convert.ToDouble(reader["six_month_low"]);
                        stock.SixMonthHigh = Convert.ToDouble(reader["six_month_high"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return result;
        }

        private StockHistoryModel MapRowToStockHistory(SqlDataReader reader)
        {
            StockHistoryModel stock = new StockHistoryModel();
            stock.StockSymbol = Convert.ToString(reader["stock_symbol"]);
            stock.TradingDay = Convert.ToDateTime(reader["trading_day"]);
            stock.OpenPrice = Convert.ToDouble(reader["open_price"]);
            stock.DailyHigh = Convert.ToDouble(reader["daily_high"]);
            stock.ClosePrice = Convert.ToDouble(reader["close_price"]);
            stock.DailyLow = Convert.ToDouble(reader["daily_low"]);
            stock.Volume = Convert.ToInt32(reader["volume"]);

            return stock;
        }

        /// <summary>
        /// Map a database row on the stocks table to a CurrentStocksModel model
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>A Stock</returns>
        private CurrentStocksModel MapRowToCurrentStock(SqlDataReader reader)
        {
            return new CurrentStocksModel()
            {
                StockSymbol = Convert.ToString(reader["stock_symbol"]),
                CompanyName = Convert.ToString(reader["name_of_company"]),
                CurrentPrice = Convert.ToDecimal(reader["current_share_price"]),
                PercentChange = Convert.ToDecimal(reader["percent_daily_change"])
            };
        }


    }
}
