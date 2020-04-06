using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TEGram.DAL;
using TEGram.Models;

namespace TEGram.Tests.DAL
{
    [TestClass]
    public class FavoriteSqlDALTests : TEGramDALTests
    {
        [TestMethod]
        public void FavoredPostByUserId_Should_Work()
        {
            IFavoriteDAO fDao = new FavoriteSqlDAO(ConnectionString);
            IPostDAO pDao = new PostSqlDAO(ConnectionString);
            fDao.FavorPostByUserId(NewPostId, NewUserOneId); // Post favored their own post
            IList<Post> favorites = pDao.GetFavoritesByUserId(this.NewUserOneId);
            Assert.AreEqual(1, favorites.Count);
        }

        [TestMethod]
        public void FavoredPostByUserId_Favored_Twice_By_Same_User_Should_Not_Throw_Exception()
        {
            IFavoriteDAO fDao = new FavoriteSqlDAO(ConnectionString);
            IPostDAO pDao = new PostSqlDAO(ConnectionString);
            fDao.FavorPostByUserId(NewPostId, NewUserTwoId); // NewUserTwoId already liked in test-script.sql
            IList<Post> favorites = pDao.GetFavoritesByUserId(NewUserTwoId);
            Assert.AreEqual(1, favorites.Count);
        }

        [TestMethod]
        public void UnfavorPostByUserId_Should_Work()
        {
            IFavoriteDAO fDao = new FavoriteSqlDAO(ConnectionString);
            IPostDAO pDao = new PostSqlDAO(ConnectionString);
            fDao.DisfavorPostByUserId(NewPostId, NewUserTwoId); // NewUserTwoId now unliking post they liked in test-script.sql
            IList<Post> favorites = pDao.GetFavoritesByUserId(NewUserTwoId);
            Assert.AreEqual(0, favorites.Count);
        }

        [TestMethod]
        public void UnfavorPostByUserId_Unfavored_By_User_Who_Never_Liked_Post_Should_Not_Throw_Exception()
        {
            IFavoriteDAO fDao = new FavoriteSqlDAO(ConnectionString);
            IPostDAO pDao = new PostSqlDAO(ConnectionString);
            fDao.DisfavorPostByUserId(NewPostId, NewUserOneId); // Only NewUserTwoId liked the post in test-script.sql
            IList<Post> favorites = pDao.GetFavoritesByUserId(NewUserTwoId);
            Assert.AreEqual(1, favorites.Count);
        }
    }
}
