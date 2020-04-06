using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TEGram.Models;

namespace TEGram.DAL
{
    public class PostSqlDAO : IPostDAO
    {
        private readonly string connectionString;
        private const string INSERT_POST = @"
            INSERT INTO posts(user_id, image, caption) 
                VALUES (@userId, @image, @caption);
            SELECT scope_identity();
        ";

        private const string GET_POSTS = @"
--            DECLARE @user_id int;
--            SELECT @user_id = id FROM users WHERE username = @currentusername;
            select p.*, pu.username, pu.image 'userimage', c.id comment_id, c.post_id comment_post_id, 
                c.user_id comment_user_id, cu.username 'comment_username', cu.image 'comment_userimage',
				c.message 'comment_message', c.datetime_stamp 'comment_datetime_stamp',  
                isNull(l.likes_count, 0) as likes_count, 
                (select case when ld.user_id is null then 0 else 1 end) as liked, 
                (select case when f.user_id is null then 0 else 1 end) as favored
            from posts p
			join users pu on p.user_id = pu.id
            left join comments c on p.id=c.post_id
			left join users cu on c.user_id = cu.id
            left join (select post_id, count(post_id) as likes_count from likes group by post_id) as l on p.id=l.post_id
            left join likes as ld on ld.user_id=@user_id and p.id=ld.post_id
            left join favorites as f on f.user_id=@user_id and p.id=f.post_id
            ";

        private const string GET_POSTS_WHERE = "where (p.user_id=@user_id or @currentUserOnly = 0) and (@postId = 0 or p.id=@postId)";
        private const string GET_POSTS_WHEREFAVORITE = "where p.id in (select post_id from favorites where user_id = @user_id)";
        private const string GET_POSTS_ORDERBY = "order by datetime_stamp desc";
        public PostSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Post> GetAllPosts(int userId)
        {
            SqlCommand cmd = GetCommandAllPosts(userId, false);
            return GetPosts(cmd);
        }

        public IList<Post> GetAllPostsByUserId(int userId)
        {
            SqlCommand cmd = GetCommandAllPosts(userId, true);
            return GetPosts(cmd);
        }

        public Post GetPostById(int id, int currentUserId)
        {
            SqlCommand cmd = GetCommandPostId(currentUserId, id);
            return GetPosts(cmd).FirstOrDefault();
        }

        public IList<Post> GetFavoritesByUserId(int userId)
        {
            SqlCommand cmd = GetCommandFavorites(userId);
            return GetPosts(cmd);
        }

        #region These methods return Commands for each of the Post Select statements
        // Get command object for Get All Posts and Get Posts by User
        private SqlCommand GetCommandAllPosts(int currentUserId, bool userPostsOnly)
        {
            string sql = $"{GET_POSTS} {GET_POSTS_WHERE} {GET_POSTS_ORDERBY}";
            SqlCommand cmd = new SqlCommand(sql);

            cmd.Parameters.AddWithValue("@user_id", currentUserId);
            cmd.Parameters.AddWithValue("@currentUserOnly", userPostsOnly);
            cmd.Parameters.AddWithValue("@postId", 0);

            return cmd;
        }

        // Get command object for Get Posts by Id
        private SqlCommand GetCommandPostId(int currentUserId, int postId)
        {
            string sql = GET_POSTS + " " + GET_POSTS_WHERE;
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@user_id", currentUserId);
            cmd.Parameters.AddWithValue("@currentUserOnly", false);
            cmd.Parameters.AddWithValue("@postId", postId);
            return cmd;
        }

        // Get command object for Get user Favorites posts
        private SqlCommand GetCommandFavorites(int currentUserId)
        {
            string sql = $"{GET_POSTS} {GET_POSTS_WHEREFAVORITE} {GET_POSTS_ORDERBY}";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@user_id", currentUserId);
            return cmd;
        }

        private IList<Post> GetPosts(SqlCommand cmd)
        {
            IList<Post> posts = new List<Post>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();

                    int lastPostId = 0;
                    Post post = null;
                    while (reader.Read())
                    {
                        int nextPostId = Convert.ToInt32(reader["id"]);
                        if (nextPostId != lastPostId)
                        {
                            lastPostId = nextPostId;
                            post = ConvertReaderToPost(reader);
                            posts.Add(post);
                        }
                        if (reader["comment_id"] != DBNull.Value)
                        {
                            Comment comment = CommentSqlDAO.ConvertReaderToComment(reader, "comment_");
                            post.Comments.Add(comment);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
            return posts;
        }
        #endregion

        static internal Post ConvertReaderToPost(SqlDataReader reader)
        {
            Post post = new Post();
            post.Id = Convert.ToInt32(reader["id"]);
            post.UserId = Convert.ToInt32(reader["user_id"]);
            post.UserName = Convert.ToString(reader["username"]);
            post.UserImage = Convert.ToString(reader["userimage"]);
            post.Image = Convert.ToString(reader["image"]);
            post.Caption = Convert.ToString(reader["caption"]);
            post.DateTimeStamp = Convert.ToDateTime(reader["datetime_stamp"]);
            post.IsFavored = Convert.ToBoolean(reader["favored"]);
            post.NumberOfLikes = Convert.ToInt32(reader["likes_count"]);
            post.IsLiked = Convert.ToBoolean(reader["liked"]);

            return post;
        }

        public Post CreatePost(Post post)
        {
            int newId;
            int userId = post.UserId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    try
                    {
                        SqlCommand cmd = new SqlCommand(INSERT_POST, conn);
                        cmd.Parameters.AddWithValue("@userId", post.UserId);
                        cmd.Parameters.AddWithValue("@image", post.Image);
                        cmd.Parameters.AddWithValue("@caption", post.Caption);

                        newId = Convert.ToInt32(cmd.ExecuteScalar());
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
            // Go get the added post
            post = this.GetPostById(newId, userId);
            return post;
        }
    }
}
