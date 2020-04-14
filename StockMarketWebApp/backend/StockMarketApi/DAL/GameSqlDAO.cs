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

        public IList<GameModel> GetAllActiveGames()
        {
            List<GameModel> result = new List<GameModel>();

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

        public IList<GameModel> GetAllExpiredGames()
        {
            List<GameModel> result = new List<GameModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM games WHERE end_date < @now AND is_completed = 0", conn);
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

        public GameModel GetGameById(int id)
        {
            GameModel result = new GameModel();

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

        public int CreateGame(GameModel game)
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

        public IList<GameModel> GetMyGames(int userId)
        {
            List<GameModel> result = new List<GameModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM user_game u JOIN games g ON u.game_id = g.id WHERE user_id = @userId", conn);
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


        public bool JoinGame(int userId, int gameId)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO user_game (user_id, game_id)  
                                                      VALUES (@userId, @gameId)", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@gameId", gameId);

                    cmd.ExecuteNonQuery();

                    result = true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
                
            }

            return result;
        }

        private GameModel MapRowToGame(SqlDataReader reader)
        {
            return new GameModel()
            {

                Id = Convert.ToInt32(reader["id"]),
                CreatorId = Convert.ToInt32(reader["creator_id"]),
                Name = Convert.ToString(reader["game_name"]),
                Description = Convert.ToString(reader["game_desc"]),
                DateCreated = Convert.ToDateTime(reader["date_created"]),
                EndDate = Convert.ToDateTime(reader["end_date"])
            };
        }

        public void UpdateTransactionsEndGame(int id)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE games SET is_completed = 1 WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return;
        }
    }

}

