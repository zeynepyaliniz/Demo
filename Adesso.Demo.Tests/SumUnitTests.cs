
using System;
using Xunit;

namespace Adesso.Demo.Tests
{
    [Collection("SumUnitTests")]
    public class SumUnitTests:IClassFixture<Mathematic>
    {
        private readonly Mathematic mathematic;
        public SumUnitTests(Mathematic mathematic)
        {
            this.mathematic = mathematic ?? throw new ArgumentNullException(nameof(mathematic));
        }
        [Fact]
        public void SumShouldReturnFive() {
            #region Assert
            int first = 2,second=3;
            int expected = 5;
            #endregion
            #region Act 
            int actual = mathematic.Sum(first,second);
            #endregion
            #region Assert
            Assert.Equal(expected,actual);
            #endregion
        }
    }
}
