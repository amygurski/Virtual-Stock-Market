using StockMarketApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.DAL
{
    /// <summary>
    /// A SQL DAO for game objects
    /// </summary>
    public class GameSqlDAO : IGameDAO
    {
        private readonly string connectionString;

        public GameSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Game> GetAllActiveGames()
        {
            List<Game> result = new List<Game>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM games WHERE  enddate > @now", conn);
                    cmd.Parameters.AddWithValue("@now", DateTime.Now);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(MapRowToGame(reader));
                    }
                }

                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private Game MapRowToGame(SqlDataReader reader)
        {
            return new Game()
            {

                GameId = Convert.ToInt32(reader["gameId"]),
                CreatorId = Convert.ToInt32(reader["creatorId"]),
                GameName = Convert.ToString(reader["gameName"]),
                DateCreated = Convert.ToDateTime(reader["dateCreated"]),
                EndDate = Convert.ToDateTime(reader["endDate"])
            };
        }
    }
}

