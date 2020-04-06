using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TeSnippets.DAL;
using TeSnippets.Models;

namespace TeSnippets.DAL
{
    /// <summary>
    /// A SQL Dao for snippet objects.
    /// </summary>
    public class SnippetSqlDAO : ISnippetDAO
    {

        private readonly string connectionString;

        /// <summary>
        /// Creates a new sql dao for snippet objects.
        /// </summary>
        /// <param name="connectionString">the database connection string</param>
        public SnippetSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// I will find a snippet by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Snippet FindById(int id, int userid)
        {

            Snippet snippet = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM SNIPPETS WHERE id = @id AND user_id = @userid;", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@userid", userid);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        snippet = MapRowToSnippet(reader);
                    }
                }

                return snippet;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// I will return a list of snippets for a given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Snippet> GetSnippets(int userId)
        {

            List<Snippet> snippets = new List<Snippet>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM SNIPPETS WHERE user_id = @userId", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        snippets.Add(new Snippet
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Description = Convert.ToString(reader["description"]),
                            Filename = Convert.ToString(reader["filename"]),
                            SourceCode = Convert.ToString(reader["sourcecode"]),
                            Tags = Convert.ToString(reader["tags"])
                        });

                    }
                }

                return snippets;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// I will save a new snippet.
        /// </summary>
        /// <param name="snippet"></param>
        /// <returns></returns>
        public Snippet CreateSnippet(Snippet snippet)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO snippets VALUES (@description, @filename, @sourcecode, @tags, @userid);", conn);
                    cmd.Parameters.AddWithValue("@description", snippet.Description);
                    cmd.Parameters.AddWithValue("@filename", snippet.Filename);
                    cmd.Parameters.AddWithValue("@sourcecode", snippet.SourceCode);
                    cmd.Parameters.AddWithValue("@tags", snippet.Tags);
                    cmd.Parameters.AddWithValue("@userid", snippet.UserId);
                    cmd.ExecuteNonQuery();

                    return snippet;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// I will update an exsiting snippet
        /// </summary>
        /// <param name="snippet"></param>
        public Snippet UpdateSnippet(Snippet snippet)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE snippets SET description = @description, filename = @filename, sourcecode = @sourcecode, tags = @tags WHERE id = @id AND user_id = @userid;", conn);
                    cmd.Parameters.AddWithValue("@id", snippet.Id);
                    cmd.Parameters.AddWithValue("@description", snippet.Description);
                    cmd.Parameters.AddWithValue("@filename", snippet.Filename);
                    cmd.Parameters.AddWithValue("@sourcecode", snippet.SourceCode);
                    cmd.Parameters.AddWithValue("@tags", snippet.Tags);
                    cmd.Parameters.AddWithValue("@userid", snippet.UserId);

                    cmd.ExecuteNonQuery();

                    return snippet;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// I will delete a snippet by it's id.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteSnippet(int id, int userid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM snippets WHERE id = @id AND user_id = @userid;", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private Snippet MapRowToSnippet(SqlDataReader reader)
        {
            return new Snippet()
            {
                Id = Convert.ToInt32(reader["id"]),
                Description = Convert.ToString(reader["description"]),
                Filename = Convert.ToString(reader["filename"]),
                SourceCode = Convert.ToString(reader["sourcecode"]),
                Tags = Convert.ToString(reader["tags"])
            };
        }

    }
}
