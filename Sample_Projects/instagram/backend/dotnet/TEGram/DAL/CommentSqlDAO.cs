using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TEGram.Models;

namespace TEGram.DAL
{
    public class CommentSqlDAO : ICommentDAO
    {
        private const string DELETE_COMMENT = "DELETE FROM comments WHERE id=@commentId";
        private const string INSERT_COMMENT = @"
            INSERT INTO comments(post_id, user_id, message) 
                VALUES (@postId, @userId, @message);
            SELECT c.*, u.username, u.image 'userimage' from comments c
                join users u on c.user_id = u.id
                where c.id = scope_identity();
        ";

        private readonly string connectionString;

        public CommentSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Comment CreateComment(Comment comment)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    try
                    {
                        SqlCommand cmd = new SqlCommand(INSERT_COMMENT, conn);
                        cmd.Parameters.AddWithValue("@postId", comment.PostId);
                        cmd.Parameters.AddWithValue("@userId", comment.UserId);
                        cmd.Parameters.AddWithValue("@message", comment.Message);

                        SqlDataReader rdr = cmd.ExecuteReader();

                        rdr.Read();
                        comment = ConvertReaderToComment(rdr);
                    }
                        catch (SqlException exception)
                        {
                            throw;
                        }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return comment;
        }

        public void DeleteComment(int commentId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    try
                    {
                        SqlCommand cmd = new SqlCommand(DELETE_COMMENT, conn);
                        cmd.Parameters.AddWithValue("@commentId", commentId);
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException exception)
                    {
                        throw;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        //public void DeletePostCommentByUserId(int postId, int userId)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            SqlCommand cmd = new SqlCommand("DELETE comments WHERE post_id=@postId AND user_id=@userId", conn);

        //            cmd.Parameters.AddWithValue("@postId", postId);
        //            cmd.Parameters.AddWithValue("@userId", userId);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw;
        //    }
        //}

        //public IList<Comment> GetAllPostCommentsByPostId(int postId)
        //{
        //    IList<Comment> comments = new List<Comment>();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            SqlCommand cmd = new SqlCommand("SELECT * FROM comments WHERE post_id=@postId", conn);

        //            cmd.Parameters.AddWithValue("@postId", postId);

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                Comment comment = ConvertReaderToComment(reader);
        //                comments.Add(comment);
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {

        //        throw;
        //    }

        //    return comments;
        //}

        //public Comment GetPostCommentsByUserId(int postId, int userId)
        //{
        //    Comment comment = new Comment();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            SqlCommand cmd = new SqlCommand("SELECT * FROM comments WHERE post_id=@postId AND user_id=@userId", conn);

        //            cmd.Parameters.AddWithValue("@postId", postId);
        //            cmd.Parameters.AddWithValue("@userId", userId);

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                comment = ConvertReaderToComment(reader);
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {

        //        throw;
        //    }

        //    return comment;
        //}

        //public Comment SavePostComment(Comment comment)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("INSERT INTO comments(post_id, user_id, message) VALUES(@postId, @userId, @message)", conn);

        //                cmd.Parameters.AddWithValue("@postId", comment.PostId);
        //                cmd.Parameters.AddWithValue("@userId", comment.UserId);
        //                cmd.Parameters.AddWithValue("@message", comment.Message);

        //                cmd.ExecuteNonQuery();
        //            }
        //            catch(SqlException ex)
        //            {
        //                try
        //                {
        //                    SqlCommand cmd = new SqlCommand("UPDATE comments SET message=@message, datetime_stamp=@dateTimeStamp WHERE post_id=@postId And user_id=@userId", conn);

        //                    cmd.Parameters.AddWithValue("@postId", comment.PostId);
        //                    cmd.Parameters.AddWithValue("@userId", comment.UserId);
        //                    cmd.Parameters.AddWithValue("@message", comment.Message);
        //                    cmd.Parameters.AddWithValue("@dateTimeStamp", DateTime.Now);

        //                    cmd.ExecuteNonQuery();
        //                }
        //                catch (SqlException exception)
        //                {
        //                    throw;
        //                }
        //            }

        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //            throw;
        //    }
        //    return comment;
        //}

        static internal Comment ConvertReaderToComment(SqlDataReader reader, string prefix = "")
        {
            Comment comment = new Comment();
            comment.Id = Convert.ToInt32(reader[prefix+"id"]);
            comment.PostId = Convert.ToInt32(reader[prefix + "post_id"]);
            comment.UserId = Convert.ToInt32(reader[prefix + "user_id"]);
            comment.UserName = Convert.ToString(reader[prefix + "username"]);
            comment.UserImage = Convert.ToString(reader[prefix + "userimage"]);
            comment.Message = Convert.ToString(reader[prefix + "message"]);
            comment.DateTimeStamp = Convert.ToDateTime(reader[prefix + "datetime_stamp"]);
            return comment;
        }
    }
}
