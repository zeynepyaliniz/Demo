using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

namespace Adesso.Demo.Tests
{
    [Collection("DivisionUnitTests")]
    public class DivisionUnitTests
    {
        [Theory]
        [InlineData(2, 4)]
        public void DivisionShouldReturnDoubleType(int first, int second)
        {
            #region Arrange
            Mathematic math = new Mathematic();
            #endregion
            #region Act
            var actual = math.Divide(first, second);
            #endregion
            Assert.IsType<double>(actual);
        }
        [Fact]
        public void DivisionShouldReturnFive()
        {
            #region Arrange
            int first = 10, second = 2;
            var math = new Mathematic();
            var expected = 5;
            #endregion
            #region Act            
            double actual = math.Divide(first, second);
            #endregion
            #region Assert
            Assert.Equal(expected, actual);
            #endregion
        }

        [Fact]
        public void DivisionShouldThrowDivideByZeroException()
        {
            Mathematic math = new Mathematic();
            Assert.Throws<DivideByZeroException>(() => math.Divide(1, 0));
        }

        [Theory]
        [InlineData(2, 4, 0.5)]
        [InlineData(6, 2, 3)]
        [InlineData(7, 2, 3.5)]
        public void DivisionShouldReturnTrue(int first, int second, double expected)
        {
            #region Arrange
            Mathematic math = new Mathematic();
            #endregion
            #region Act
            Double actual = math.Divide(first, second);
            #endregion
            #region Assert
            Assert.Equal(expected, actual);
            #endregion
        }
        public static IEnumerable<object[]> Data => new List<object[]> {
            new object[]{ 2, 4, 0.5},
            new object[]{ 6, 2, 3},
            new object[]{ 7, 2, 3.5}
        };
        [Theory]
        [MemberData(nameof(Data))]
        public void DivisionShouldReturnTruewithMemberData(int first, int second, double expected)
        {
            #region Arrange
            Mathematic math = new Mathematic();
            #endregion
            #region Act
            Double actual = math.Divide(first, second);
            #endregion
            #region Assert
            Assert.Equal(expected, actual);
            #endregion
        }
        [Theory]
        [MemberData(nameof(MemberDatas.Datas), MemberType = typeof(MemberDatas))]
        public void DivisionShouldReturnTruewithAnotherMemberData(int first, int second, double expected)
        {
            #region Arrange
            Mathematic math = new Mathematic();
            #endregion
            #region Act
            Double actual = math.Divide(first, second);
            #endregion
            #region Assert
            Assert.Equal(expected, actual);
            #endregion
        }
        [Theory]
        [MemberData(nameof(MemberDatas.Datas), MemberType = typeof(MemberDatas), DisableDiscoveryEnumeration = true)]
        public void DivisionShouldReturnTruewithAnotherMemberDataDisable(int first, int second, double expected)
        {
            #region Arrange
            Mathematic math = new Mathematic();
            #endregion
            #region Act
            Double actual = math.Divide(first, second);
            #endregion
            #region Assert
            Assert.Equal(expected, actual);
            #endregion
        }
        [Theory]
        [ClassData(typeof(Datas))]
        public void DivisionShouldReturnTrueWithClassData(int first, int second, double expected)
        {
            #region Arrange
            Mathematic math = new Mathematic();
            #endregion
            #region Act
            Double actual = math.Divide(first, second);
            #endregion
            #region Assert
            Assert.Equal(expected, actual);
            #endregion
        }
        [Theory]
        [ClassData(typeof(TypeSafeData))]
        public void DivisionShouldReturnTrueWithTypeSafe(int first, int second, double expected)
        {
            #region Arrange
            Mathematic math = new Mathematic();
            #endregion
            #region Act
            Double actual = math.Divide(first, second);
            #endregion
            #region Assert
            Assert.Equal(expected, actual);
            #endregion
        }

    }
    public class Datas : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 4, 0.5 };
            yield return new object[] { 6, 2, 3 };
            yield return new object[] { 7, 2, 3.5 };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class MemberDatas
    {
        public static IEnumerable<object[]> Datas => new List<object[]> {
            new object[]{ 2, 4, 0.5},
            new object[]{ 6, 2, 3},
            new object[]{ 7, 2, 3.5}
        };
    }
    public class TypeSafeData : TheoryData<int, int, double>
    {
        public TypeSafeData()
        {
            Add(2, 4, 0.5);
            Add(6, 2, 3);
            Add(7, 2, 3.5);
        }
    }
}

