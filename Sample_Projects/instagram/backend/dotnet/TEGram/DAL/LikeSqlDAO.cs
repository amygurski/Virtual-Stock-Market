using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TEGram.Models;

namespace TEGram.DAL
{
    public class LikeSqlDAO : ILikeDAO
    {
        private readonly string connectionString;

        private const string SQL_LIKESBYPOSTID = @"
            SELECT * FROM users where id in 
                (select user_id FROM likes WHERE post_id=@postId)
        ";

        private const string SQL_INSERTLIKE = @"
            IF NOT EXISTS(SELECT * FROM likes where post_id = @postId and user_id = @userId)
                INSERT INTO likes(post_id, user_id) VALUES(@postId, @userId);
            SELECT COUNT(*) FROM likes WHERE post_id = @postId;
        ";

        private const string SQL_DELETELIKE = @"
            DELETE likes WHERE post_id=@postId AND user_id=@userId;
            SELECT COUNT(*) FROM likes WHERE post_id = @postId;
        ";


        public LikeSqlDAO(string dbconnectionString)
        {
            connectionString = dbconnectionString;
        }

        public IList<User> GetAllLikesByPostId(int postId)
        {
            IList<User> users = new List<User>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_LIKESBYPOSTID, conn);

                    cmd.Parameters.AddWithValue("@postId", postId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = UserSqlDAO.MapRowToUser(reader);
                        users.Add(user);
                    }
                }
            }
            catch (SqlException ex)
            {

                throw;
            }

            return users;
        }

        //public bool IsPostLikedByUserId(int postId, int userId)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            SqlCommand cmd = new SqlCommand("SELECT * FROM likes WHERE post_id=@postId AND user_id=@userId", conn);

        //            cmd.Parameters.AddWithValue("@postId", postId);
        //            cmd.Parameters.AddWithValue("@userId", userId);

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {

        //        throw;
        //    }
        //}

        public int LikePostByUserId(int postId, int userId)
        {
            int numLikes = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_INSERTLIKE, conn);

                    cmd.Parameters.AddWithValue("@postId", postId);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    numLikes = Convert.ToInt32(cmd.ExecuteScalar());
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
            return numLikes;
        }

        public int UnlikePostByUserId(int postId, int userId)
        {
            int numLikes = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_DELETELIKE, conn);

                    cmd.Parameters.AddWithValue("@postId", postId);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    numLikes = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return numLikes;
        }

        //static internal Like ConvertReaderToLike(SqlDataReader reader)
        //{
        //    Like like = new Like();
        //    like.PostId = Convert.ToInt32(reader["post_id"]);
        //    like.UserId = Convert.ToInt32(reader["user_id"]);
        //    return like;
        //}
    }
}
