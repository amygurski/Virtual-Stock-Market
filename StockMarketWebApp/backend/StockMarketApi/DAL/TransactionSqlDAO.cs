﻿using StockMarketApi.Models;
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
                    string Sql =
@"SELECT t.*, s.name_of_company 
FROM transactions t
JOIN stocks s ON t.stock_symbol = s.stock_symbol
WHERE  t.user_id = @userId AND t.game_id = @gameId";

                    SqlCommand cmd = new SqlCommand(Sql, conn);
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
                Id = Convert.ToInt32(reader["id"]),
                UserId = Convert.ToInt32(reader["user_id"]),
                GameId = Convert.ToInt32(reader["game_id"]),
                StockSymbol = Convert.ToString(reader["stock_symbol"]),
                CompanyName = Convert.ToString(reader["name_of_company"]),
                NumberOfShares = Convert.ToInt32(reader["number_of_shares"]),
                TransactionPrice = Convert.ToDecimal(reader["transaction_share_price"]),
                TransactionDate = Convert.ToDateTime(reader["transaction_date"]),
                IsPurchase = Convert.ToBoolean(reader["is_buy"]),
                NetValue = Convert.ToDecimal(reader["net_transaction_change"])
            };
        }
    }
}
