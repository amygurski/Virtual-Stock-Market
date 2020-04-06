using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;

namespace TEGram.Tests.DAL
{
    [TestClass]
    public class TEGramDALTests
    {
        protected string ConnectionString { get; } = "Server=.\\SQLEXPRESS;Database=TEgram;Trusted_Connection=True;";

        // Holds the newly generated Ids
        protected int NewUserOneId { get; private set; }
        protected int NewUserTwoId { get; private set; }
        protected string NewUserOneName { get; private set; }
        protected string NewUserTwoName { get; private set; }
        protected int NewPostId { get; private set; }
        protected int NewCommentId { get; private set; }

        /// <summary>
        /// The transaction for each test--when you instantiate it, this BEGINS A NEW TRANSACTION
        /// </summary>
        private TransactionScope transaction;

        [TestInitialize]
        public void Setup()
        {
            // Begin the transaction
            transaction = new TransactionScope();

            // Get the SQL script to run
            string sql = File.ReadAllText("test-script.sql");

            // Execute the script
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // If there is a row to read
                if (reader.Read())
                {
                    // The "as" part in your query
                    this.NewUserOneId = Convert.ToInt32(reader["newUserOneId"]);
                    this.NewUserTwoId = Convert.ToInt32(reader["newUserTwoId"]);
                    this.NewUserOneName = Convert.ToString(reader["newUserOneName"]);
                    this.NewUserTwoName = Convert.ToString(reader["newUserTwoName"]);
                    this.NewPostId = Convert.ToInt32(reader["newPostId"]);
                    this.NewCommentId = Convert.ToInt32(reader["newCommentId"]);
                }
            }

        }

        [TestCleanup]
        public void Cleanup()
        {
            // Roll back the transaction (aka dispose, in this context)
            transaction.Dispose();
        }
    }
}
