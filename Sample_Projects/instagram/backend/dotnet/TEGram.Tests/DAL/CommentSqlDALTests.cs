using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TEGram.DAL;
using TEGram.Models;

namespace TEGram.Tests.DAL
{
    [TestClass]
    public class CommentSqlDALTests : TEGramDALTests
    {
        [TestMethod]
        public void DeleteComment_Should_Work()
        {
            IPostDAO pDao = new PostSqlDAO(ConnectionString);
            Post post = pDao.GetPostById(this.NewPostId, this.NewUserOneId);
            int commentCount = post.Comments.Count;

            ICommentDAO cDao = new CommentSqlDAO(ConnectionString);
            cDao.DeleteComment(this.NewCommentId);

            post = pDao.GetPostById(this.NewPostId, this.NewUserOneId);
            Assert.AreEqual(post.Comments.Count + 1, commentCount);

            // Try to delete the comment again. Should not fail, even though
            // there is no change in the data.
            cDao.DeleteComment(this.NewCommentId);

            post = pDao.GetPostById(this.NewPostId, this.NewUserOneId);
            Assert.AreEqual(post.Comments.Count + 1, commentCount);
        }

        [TestMethod]
        public void CreateComment_Should_CreateComment()
        {
            IPostDAO pDao = new PostSqlDAO(ConnectionString);
            Post post = pDao.GetPostById(this.NewPostId, this.NewUserOneId);
            int commentCount = post.Comments.Count;

            ICommentDAO cDao = new CommentSqlDAO(ConnectionString);
            Comment comment = new Comment();
            comment.PostId = this.NewPostId;
            comment.UserId = this.NewUserOneId;
            comment.Message = "This is a test comment";
            comment = cDao.CreateComment(comment);

            // Assert that we got a new ID
            int commentId = comment.Id;
            Assert.AreNotEqual(0, commentId);

            // Assert that the post has one more comment than it did.
            post = pDao.GetPostById(this.NewPostId, this.NewUserOneId);
            Assert.AreEqual(post.Comments.Count, ++commentCount);

            // Add a second comment by the same user - should be allowed and should be a new Id
            comment = new Comment();
            comment.PostId = this.NewPostId;
            comment.UserId = this.NewUserOneId;
            comment.Message = "This is a SECOND test comment";
            comment = cDao.CreateComment(comment);

            // Assert that we got a new ID, different from the previous one
            Assert.AreNotEqual(0, comment.Id);
            Assert.AreNotEqual(commentId, comment.Id);

            // Assert that the post has one more comment than it did.
            post = pDao.GetPostById(this.NewPostId, this.NewUserOneId);
            Assert.AreEqual(post.Comments.Count, ++commentCount);

        }
    }
}
