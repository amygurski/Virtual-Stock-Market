using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleApi.Controllers;
using SampleApi.DAL;
using SampleApi.Models;
using SampleApi.Models.Account;
using SampleApi.Providers.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApi.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTests
    {
        private Mock<ITokenGenerator> mockGenerator = new Mock<ITokenGenerator>();
        private Mock<IPasswordHasher> mockHasher = new Mock<IPasswordHasher>();
        private Mock<IUserDAO> mockDao = new Mock<IUserDAO>();

        [TestInitialize]
        public void Initialize()
        {
            // Mocks the jwt generator to return "token"
            mockGenerator.Setup(m => m.GenerateToken("user", "User")).Returns("token");

            // Mocks the password hasher to "compute a hash"
            mockHasher.Setup(m => m.ComputeHash("password")).Returns(new PasswordHash("hashedPassword", "salt"));
            mockHasher.Setup(m => m.VerifyHashMatch("hashedPassword", "password", "salt")).Returns(true);

            mockDao.Setup(m => m.GetUser("user")).Returns(new User() { Password = "hashedPassword", Salt = "salt", Username = "user", Role = "User" });
        }

        [TestMethod]
        public void Register_Adds_The_User_And_Returns_A_Token()
        {
            var controller = new AccountController(mockGenerator.Object, mockHasher.Object, mockDao.Object);
            var model = new AuthenticationModel() { Username = "user", Password = "password" };

            var result = controller.Register(model) as OkObjectResult;

            Assert.IsNotNull(result);           // verify we got an answer
            Assert.AreEqual("token", result.Value); //verify we got a token
            mockDao.Verify(m => m.CreateUser(It.IsAny<User>()));   // verify we called create user
        }

        [TestMethod]
        public void Authenticate_Validates_Credentials_And_Returns_A_Token()
        {
            var controller = new AccountController(mockGenerator.Object, mockHasher.Object, mockDao.Object);
            var model = new AuthenticationModel() { Username = "user", Password = "password" };

            var result = controller.Login(model) as OkObjectResult;

            Assert.IsNotNull(result);           // verify we got an answer
            Assert.AreEqual("token", result.Value); //verify we got a token
        }
    }
}
