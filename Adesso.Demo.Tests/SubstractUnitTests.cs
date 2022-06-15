
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Adesso.Demo.Tests
{
    public class SubstractUnitTests
    {
        [Fact]
        public void SubstractShouldReturnFiveUsingMock() {
            //expecting fail because of wrong calculation in Mathematic calculate mod instead of substraction.
            //but using mock not give wrong answer, gives predetermined returns.
            //using mock
            #region Arrange
            int first = 10, second = 5;
            int expected = 5;
            var mock = new Mock<IMathematic>();
            mock.Setup(x=>x.Subtract(first,second)).Returns(expected);
            #endregion
            #region Act
            var actual = mock.Object.Subtract(first,second);
            #endregion
            #region Assert
            Assert.Equal(expected,actual);
            #endregion
        } 
        [Fact]
        public void SubstractShouldReturnFive() {
            //expecting fail because of wrong calculation in Mathematic calculate mod instead of substraction.
            
            #region Arrange
            int first = 10, second = 5;
            int expected = 5;
            var math = new Mathematic();
            #endregion
            #region Act
            var actual = math.Subtract(first,second);
            #endregion
            #region Assert
            Assert.Equal(expected,actual);
            #endregion
        }
    }
}
