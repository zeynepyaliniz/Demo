using Adesso.Demo.ApiConsumer;
using Adesso.Demo.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Adesso.Demo.Tests
{
    public class ApiConsumerTests
    {
        private readonly Mock<IClient> _mockClient;
        public ApiConsumerTests()
        {
            _mockClient = new Mock<IClient>();
            SetUp();
        }
        void SetUp() {
            User user = new User
            {
                Name = "test",
                Id = 123,
                Address = new Address { 
                    City = "Test Istanbul",
                    Geo = new Geo { },
                    Street = "test Street",
                    Suite = "Test Suite",
                    Zipcode = "34"
                },
                Company = new Company { 
                    Bs = "",
                    CatchPhrase = "",
                    Name = "Adesso"
                },
                Email = "test@adesso.com",
                Phone = "216",
                Website = "www",
                Username = "testUsername",
                
            };
            User invalid = new User
            {
                Username = "",
                Id = -1
            };
            User invalidUsername = new User
            {
                Username = null,
                Id = 0
            };
            IEnumerable<User> users = new List<User> { 
                new User { Name = "test1", Id = 123 },
                new User { Name = "test2", Id = 124 },
                new User { Name = "test3", Id = 125 },
                new User { Name = "test4", Id = 126 },
                new User { Name = "test5", Id = 127 },
                new User { Name = "test6", Id = 128 }
            };
            _mockClient.Setup(x => x.GetUserByUsername(It.IsAny<string>())).Returns(user);
            _mockClient.Setup(x => x.GetUserByUsername(invalid.Username)).Throws<ArgumentNullException>();
            _mockClient.Setup(x => x.GetUserByUsername(invalidUsername.Username)).Throws<ArgumentNullException>();
            _mockClient.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(user);
           
            _mockClient.Setup(x => x.GetUserById(invalid.Id)).Throws<ArgumentOutOfRangeException>();
            _mockClient.Setup(x => x.GetUserById(invalidUsername.Id)).Throws<ArgumentOutOfRangeException>();
            _mockClient.Setup(x => x.GetUsers()).Returns(users);
        }
        [Fact]
        public void GetUserByUsernameShouldReturnNameAsTest() {
            #region Arrange
            var expected = "test";
            var username = "test";
            #endregion
            #region Act
            var actual = _mockClient.Object.GetUserByUsername(username);
            #endregion
            #region Assert
            Assert.Equal(expected,actual.Name);
            #endregion
        }
        [Fact]
        public void GetUserByIdShouldReturn123() {
            #region Arrange
            var expected = 123;
            var id = 123;
            #endregion
            #region Act
            var actual = _mockClient.Object.GetUserById(id);
            #endregion
            #region Assert
            Assert.Equal(expected,actual.Id);
            #endregion
        }
        [Fact]
        public void GetUsersShouldReturnCountOfSix() {
            #region Arrange 
            var expected = 6;
            #endregion
            #region Act
            var actual = _mockClient.Object.GetUsers();
            #endregion
            #region Arrange
            Assert.Equal(expected,actual.Count());
            #endregion
        } 
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void GetUserByUsernameShouldThrowArgumentNullException(string username) {
            #region Arrange 
            #endregion
            #region Act
            #endregion
            #region Arrange
            Assert.Throws<ArgumentNullException>(() => _mockClient.Object.GetUserByUsername(username));
            #endregion
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void GetUserByIdShouldThrowArgumentOutOfRangeException(int id) {
            #region Arrange 
            #endregion
            #region Act
            #endregion
            #region Arrange
            Assert.Throws<ArgumentOutOfRangeException>(() => _mockClient.Object.GetUserById(id));
            #endregion
        }
    }
}
