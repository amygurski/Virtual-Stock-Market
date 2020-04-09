using StockMarketApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.DAL
{
    public class TransactionSqlDAO : ITransactionDAO
    {
        private readonly string connectionString;

        public TransactionSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<StockTransaction> GetTransactionsByGameAndUser(int gameId, int userId)
        {
            List<StockTransaction> result = new List<StockTransaction>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM transactions WHERE  user_id = @userId AND game_id = @gameId", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@gameId", gameId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(MapRowToTransaction(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return result;
        }

        private StockTransaction MapRowToTransaction(SqlDataReader reader)
        {
            return new StockTransaction()
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                GameId = Convert.ToInt32(reader["game_id"]),
                StockSymbol = Convert.ToString(reader["stock_symbol"]),
                NumberOfShares = Convert.ToInt32(reader["number_of_shares"]),
                TransactionPrice = Convert.ToDecimal(reader["transaction_share_price"]),
                TransactionDate = Convert.ToDateTime(reader["transaction_date"]),
                IsPurchase = Convert.ToBoolean(reader["is_buy"])
            };
        }
    }
}
