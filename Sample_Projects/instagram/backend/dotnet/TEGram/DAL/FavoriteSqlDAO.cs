using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TEGram.Models;

namespace TEGram.DAL
{
    public class FavoriteSqlDAO : IFavoriteDAO
    {
        private readonly string connectionString;

        private const string INSERT_FAVORITE = "INSERT INTO favorites(post_id, user_id) VALUES(@postId, @userId)";
        private const string DELETE_FAVORITE = "DELETE favorites WHERE post_id=@postId AND user_id=@userId";
        public FavoriteSqlDAO(string dbconnectionString)
        {
            connectionString = dbconnectionString;
        }

        public void DisfavorPostByUserId(int postId, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(DELETE_FAVORITE, conn);

                    cmd.Parameters.AddWithValue("@postId", postId);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public void FavorPostByUserId(int postId, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(INSERT_FAVORITE, conn);

                    cmd.Parameters.AddWithValue("@postId", postId);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY"))
                {
                    // Eat the exception, because the user already liked the post
                }
                else
                {
                    throw;
                }
            }
        }

        public IList<Post> GetFavoritesByUserId(int userId)
        {
            return new PostSqlDAO(this.connectionString).GetFavoritesByUserId(userId);
        }

        //static internal Favorite ConvertReaderToFavorite(SqlDataReader reader)
        //{
        //    Favorite favorite = new Favorite();
        //    favorite.PostId = Convert.ToInt32(reader["post_id"]);
        //    favorite.UserId = Convert.ToInt32(reader["user_id"]);
        //    return favorite;
        //}
    }
}
