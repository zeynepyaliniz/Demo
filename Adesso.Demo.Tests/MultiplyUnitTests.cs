using Moq;
using System;
using Xunit;

namespace Adesso.Demo.Tests
{
    [Collection("MultiplyUnitTests")]
    public class MultiplyUnitTests
    {
        private readonly Mock<IMathematic> mock;
        public MultiplyUnitTests()
        {
            mock = new Mock<IMathematic>();

        }
        [Theory]
        [InlineData(2,5,10)]
        [InlineData(5,4,20)]
        public void MultiplyShouldReturnExpected(int first,int second,int expected)
        {
            #region Arrange
            mock.Setup(result => result.Multiply(first, second))
                .Returns(expected);

            var actual = mock.Object.Multiply(first, second);
            #endregion
            #region Act
            Assert.Equal(expected, actual);
            #endregion
        }
        [Fact]
        public void MultiplyShouldReturn20()
        {
            #region Arrange
            int first = 5, second = 4;
            int expected = 20;
            mock.Setup(result => result.Multiply(first, second))
                .Returns(expected);
            var actual = mock.Object.Multiply(first, second);
            #endregion
            #region Act
            Assert.Equal(expected, actual);
            mock.Verify(r => r.Multiply(first, second), Times.AtLeast(1));
            #endregion
        }
        [Fact]
        public void MultiplyShouldThrowArgumentException() {
            #region Arrange 
            int first = 5, second = 0;
            mock.Setup(x => x.Multiply(first, second)).Throws<ArgumentException>();
            #endregion
            #region Assert
            Assert.Throws<ArgumentException>(()=>mock.Object.Multiply(first, second));
            #endregion
        }
      
    }
}
