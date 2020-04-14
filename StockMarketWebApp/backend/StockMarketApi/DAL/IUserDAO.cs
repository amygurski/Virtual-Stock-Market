using StockMarketApi.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.DAL
{
    /// <summary>
    /// An interface for user data objects.
    /// </summary>
    public interface IUserDAO
    {
        /// <summary>
        /// Retrieves a user from the system by username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        UserModel GetUser(string username);

        /// <summary>
        /// Retrieves a user from the system by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserModel GetUser(int id);

        /// <summary>
        /// Retrieves a list of users from the system by game id.
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        IList<UserModel> GetUsersByGame(int gameId);

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user"></param>
        void CreateUser(UserModel user);

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser(UserModel user);

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        /// <param name="user"></param>
        void DeleteUser(UserModel user);
    }
}
