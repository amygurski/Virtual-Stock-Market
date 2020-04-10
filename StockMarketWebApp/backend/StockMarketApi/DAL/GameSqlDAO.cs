using StockMarketApi.Models.DatabaseModels;
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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM games WHERE  end_date > @now", conn);
                    cmd.Parameters.AddWithValue("@now", DateTime.Now);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(MapRowToGame(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return result;
        }

        public Game GetGameById(int id)
        {
            Game result = new Game();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM games WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = MapRowToGame(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return result;
        }

        public int CreateGame(Game game)
        {
            int gameId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO games (creator_id, game_name, game_desc, date_created, end_date)  
                                                      VALUES (@creator_id, @game_name, @game_desc, @date_created, @end_date); SELECT @@identity As NewId", conn);
                    cmd.Parameters.AddWithValue("@creator_id", game.CreatorId);
                    cmd.Parameters.AddWithValue("@game_name", game.Name);
                    cmd.Parameters.AddWithValue("@game_desc", game.Description);
                    cmd.Parameters.AddWithValue("@date_created", game.DateCreated);
                    cmd.Parameters.AddWithValue("@end_date", game.EndDate);

                    gameId =  Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return gameId;
        }

        public IList<Game> GetMyGames(int userId)
        {
            List<Game> result = new List<Game>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM games WHERE creator_Id = @userId", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(MapRowToGame(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return result;
        }

        private Game MapRowToGame(SqlDataReader reader)
        {
            return new Game()
            {

                Id = Convert.ToInt32(reader["id"]),
                CreatorId = Convert.ToInt32(reader["creator_id"]),
                Name = Convert.ToString(reader["game_name"]),
                Description = Convert.ToString(reader["game_desc"]),
                DateCreated = Convert.ToDateTime(reader["date_created"]),
                EndDate = Convert.ToDateTime(reader["end_date"])
            };
        }
    }
}

