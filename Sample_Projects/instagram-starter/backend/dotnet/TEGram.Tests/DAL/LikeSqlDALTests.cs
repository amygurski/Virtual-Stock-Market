using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TEGram.DAL;
using TEGram.Models;

namespace TEGram.Tests.DAL
{
    [TestClass]
    public class LikeSqlDALTests : TEGramDALTests
    {
        [TestMethod]
        public void GetAllLikesByPostId_Should_Return_All_Likes()
        {
            ILikeDAO dao = new LikeSqlDAO(ConnectionString);
            IList<User> users = dao.GetAllLikesByPostId(NewPostId);
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        public void LikePostByUserId_Should_Work()
        {
            // See how many users like the post first
            ILikeDAO dao = new LikeSqlDAO(ConnectionString);
            IList<User> users = dao.GetAllLikesByPostId(NewPostId);
            int numLikes = users.Count;
            Assert.AreEqual(1, numLikes);

            // Like the post
            dao.LikePostByUserId(NewPostId, NewUserOneId); // Poster liking their own post

            // Check that the number increased by one
            users = dao.GetAllLikesByPostId(NewPostId);
            Assert.AreEqual(numLikes+1, users.Count);
        }

        [TestMethod]
        public void LikePostByUserId_Liked_Twice_By_Same_User_Should_Not_Throw_Exception()
        {
            ILikeDAO dao = new LikeSqlDAO(ConnectionString);
            dao.LikePostByUserId(NewPostId, NewUserTwoId); // NewUserTwoId already liked in test-script.sql
            IList<User> users = dao.GetAllLikesByPostId(NewPostId);
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        public void UnLikePostByUserId_Should_Work()
        {
            ILikeDAO dao = new LikeSqlDAO(ConnectionString);
            dao.UnlikePostByUserId(NewPostId, NewUserTwoId); // NewUserTwoId now unliking post they liked in test-script.sql
            IList<User> users = dao.GetAllLikesByPostId(NewPostId);
            Assert.AreEqual(0, users.Count);
        }

        [TestMethod]
        public void UnLikePostByUserId_Unliked_By_User_Who_Never_Liked_Post_Should_Not_Throw_Exception()
        {
            ILikeDAO dao = new LikeSqlDAO(ConnectionString);
            dao.UnlikePostByUserId(NewPostId, NewUserOneId); // Only NewUserTwoId liked the post in test-script.sql
            IList<User> users = dao.GetAllLikesByPostId(NewPostId);
            Assert.AreEqual(1, users.Count);
        }
    }
}
