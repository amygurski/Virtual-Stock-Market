using StockMarketApi.Models.ApiReturnModels;
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
