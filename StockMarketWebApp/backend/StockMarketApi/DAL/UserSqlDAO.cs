using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using StockMarketApi.Models.DatabaseModels;

namespace StockMarketApi.DAL
{
    /// <summary>
    /// A SQL Dao for user objects.
    /// </summary>
    public class UserSqlDAO : IUserDAO
    {
        private readonly string connectionString;

        /// <summary>
        /// Creates a new sql dao for user objects.
        /// </summary>
        /// <param name="connectionString">the database connection string</param>
        public UserSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Saves the user to the database.
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(UserModel user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO users (username, firstname, email, password, salt, role) VALUES (@username, @firstname, @email, @password, @salt, @role);", conn);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@firstname", user.Firstname);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@salt", user.Salt);
                    cmd.Parameters.AddWithValue("@role", user.Role);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the user from the database.
        /// </summary>
        /// <param name="user"></param>
        public void DeleteUser(UserModel user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", user.Id);                    

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the user from the database.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public UserModel GetUser(string username)
        {
            UserModel user = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM USERS WHERE username = @username;", conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        user = MapRowToUser(reader);
                    }
                }

                return user;
            }
            catch (SqlException ex)
            {
                throw ex;
            }            
        }

        /// <summary>
        /// Gets the user from the database.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public UserModel GetUser(int id)
        {
            UserModel user = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM USERS WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        user = MapRowToUser(reader);
                    }
                }

                return user;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates the user in the database.
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(UserModel user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE users SET password = @password, salt = @salt, role = @role WHERE id = @id;", conn);                    
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@salt", user.Salt);
                    cmd.Parameters.AddWithValue("@role", user.Role);
                    cmd.Parameters.AddWithValue("@id", user.Id);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private UserModel MapRowToUser(SqlDataReader reader)
        {
            return new UserModel()
            {
                Id = Convert.ToInt32(reader["id"]),
                Username = Convert.ToString(reader["username"]),
                Firstname = Convert.ToString(reader["firstname"]),
                Email = Convert.ToString(reader["email"]),
                Password = Convert.ToString(reader["password"]),
                Salt = Convert.ToString(reader["salt"]),
                Role = Convert.ToString(reader["role"])
            };
        }
    }
}
