using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TEGram.DAL;
using TEGram.Models;

namespace TEGram.Tests.DAL
{
    [TestClass]
    public class PostSqlDALTests : TEGramDALTests
    {
        [TestMethod]
        public void CreatePost_Should_Create_New_Post()
        {
            // First check the count of posts
            IPostDAO dao = new PostSqlDAO(ConnectionString);
            IList<Post> posts = dao.GetAllPosts(this.NewUserOneId);
            int count = posts.Count;
            Assert.AreEqual(count, 3);

            // Add a post
            Post post = new Post();

            post.UserId = this.NewUserOneId;
            post.Caption = "A new test post";
            post.Image = "http://foo.com";
            post = dao.CreatePost(post);

            // Check that the returned post has an id and a timstamp
            Assert.AreNotEqual(post.Id, 0);
            Assert.IsTrue((DateTime.Now - post.DateTimeStamp).Minutes < 1);
            

            // Count should be increased
            posts = dao.GetAllPosts(this.NewUserOneId);
            Assert.AreEqual(count+1, posts.Count);
        }

        [TestMethod]
        public void GetAllPostsBy_Should_Return_All_Posts()
        {
            IPostDAO dao = new PostSqlDAO(ConnectionString);

            //            IList<Post> posts = dao.GetAllPosts("legoman");
            IList<Post> posts = dao.GetAllPosts(this.NewUserOneId);
            Assert.AreEqual(3, posts.Count);
            Assert.AreEqual(1, posts[0].Comments.Count);
            Assert.AreEqual(1, posts[0].NumberOfLikes);
            Assert.AreEqual(0, posts[2].Comments.Count);
            Assert.AreEqual(0, posts[2].NumberOfLikes);

            Assert.AreEqual(true, posts[0].IsFavored);
            Assert.AreEqual(false, posts[1].IsFavored);
            Assert.AreEqual(false, posts[2].IsFavored);
            Assert.AreEqual(false, posts[0].IsLiked);
            Assert.AreEqual(true, posts[1].IsLiked);
            Assert.AreEqual(false, posts[2].IsLiked);
        }

        [TestMethod]
        public void GetAllPostsByUserName_Should_Return_All_Posts_For_User_Named()
        {
            IPostDAO dao = new PostSqlDAO(ConnectionString);
            //IList<Post> posts = dao.GetAllPostsByUserName("legoman");
            IList<Post> posts = dao.GetAllPostsByUserId(this.NewUserOneId);
            Assert.AreEqual(2, posts.Count);
            Assert.AreEqual(1, posts[0].Comments.Count);
            Assert.AreEqual(1, posts[0].NumberOfLikes);
            Assert.AreEqual(0, posts[1].Comments.Count);
            Assert.AreEqual(0, posts[1].NumberOfLikes);
        }

        [TestMethod]
        public void GetPostByPostId_Should_Work()
        {
            IPostDAO dao = new PostSqlDAO(ConnectionString);
            //Post post = dao.GetPostById(NewPostId, "legoman");
            Post post = dao.GetPostById(NewPostId, this.NewUserOneId);
            Assert.AreEqual(NewPostId, post.Id);
            Assert.AreEqual(1, post.Comments.Count);
            Assert.AreEqual(1, post.NumberOfLikes);
        }

        [TestMethod]
        public void GetFavoritesByUserName_Should_Return_Favorites_For_User_Named()
        {
            IPostDAO dao = new PostSqlDAO(ConnectionString);
            //IList<Post> posts = dao.GetFavoritesByUserName("legoman");
            IList<Post> posts = dao.GetFavoritesByUserId(this.NewUserOneId);
            Assert.AreEqual(1, posts.Count);
            Assert.AreEqual(true, posts[0].IsFavored);
            Assert.AreEqual(false, posts[0].IsLiked);
        }
    }
}
