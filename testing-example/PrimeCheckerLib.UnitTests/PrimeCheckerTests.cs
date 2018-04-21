using System;
using Xunit;

namespace PrimeCheckerLib.UnitTests
{
    public class PrimeCheckerTests
    {
        [Fact]
        public void _2_Should_Be_Prime()
        {
            Assert.True(PrimeChecker.IsPrime(2));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(6)]
        public void Even_Numbers_Should_Not_Be_Prime(int n)
        {
            Assert.False(PrimeChecker.IsPrime(n));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void Should_Return_True_For_All_Primes_Less_Than_10(int n)
        {
            Assert.True(PrimeChecker.IsPrime(n));
        }
    }
}
