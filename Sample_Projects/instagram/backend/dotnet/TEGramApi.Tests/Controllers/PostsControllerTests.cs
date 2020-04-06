using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Claims;
using TEGramApi.Controllers;
using TEGram.DAL;
using TEGram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Moq;

namespace TEGram.Tests.Controllers
{
    // A sample controller test.
    // This shows how to create a "fake" controllerContext and associate a ClaimsPrincipal (user), so the
    // controllers that are [Authorize]'d and interrogate the base class's User.Identity do not fail.
    //
    // This also shows an example of how to use Moq.
    [TestClass]
    public class PostsControllerTests
    {
        private Mock<IUserDAO> mockUserDao = new Mock<IUserDAO>();
        private Mock<IPostDAO> mockPostDao = new Mock<IPostDAO>();

        /// <summary>
        /// Setup the Moq objects before each test.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            mockUserDao.Setup(m => m.GetUser("user")).Returns(new User() { Id=100, Password = "hashedPassword", Salt = "salt", Username = "user", Role = "User" });
            mockPostDao.Setup(m => m.CreatePost(It.IsAny<Post>())).Returns( (Post p) => new Post() { Id = 101, DateTimeStamp = DateTime.Now, Caption = p.Caption, Image = p.Image, UserId = p.UserId });
        }

        /// <summary>
        /// This private method creates a new controller of the type we are testing and associates a fake 
        /// ClaimsPrincipal to its new context.
        /// </summary>
        /// <returns>A new PostController for testing</returns>
        private PostsController NewController()
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "user"),
                new Claim(ClaimTypes.NameIdentifier, "userId"),
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "TestAuthType");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            PostsController controller = new PostsController(mockPostDao.Object, mockUserDao.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = claimsPrincipal }
            };
            return controller;
        }

        /// <summary>
        /// A sample test to execute a controller action
        /// </summary>
        [TestMethod]
        public void CreatePost()
        {
            // ARRANGE
            // Create the controller mocked with identity
            PostsController controller = NewController();

            // ACT
            // Create a new post object
            Post post = new Post();
            post.Caption = "Caption";
            post.Image = "https://www.manmadekennels.com/wp-content/uploads/2018/12/PUPPY.jpg";

            // Call the Create method on the controller to add the post to the db
            ActionResult<Post> viewresult = controller.Post(post);
            ObjectResult result = viewresult.Result as ObjectResult;
            post = result.Value as Post;
            // Assert

            // The new post has an id assigned from the database
            Assert.AreEqual(post.Id, 101);

            // The user id of the current user was assigned to the post
            Assert.AreEqual(post.UserId, 100);

            // The post got a timestamp assigned
            Assert.IsTrue((DateTime.Now - post.DateTimeStamp).TotalSeconds < 2);

        }
    }
}
