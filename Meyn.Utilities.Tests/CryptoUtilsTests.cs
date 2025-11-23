using Common.Utilities;
using Xunit;

namespace Meyn.Utilities.Tests
{
    public class CryptoUtilsTests
    {
        [Fact]
        public void GetRandomNumber_ReturnsCorrectLength()
        {
            int length = 10;
            string result = CryptoUtils.GetRandomNumber(length);
            Assert.Equal(length, result.Length);
            Assert.All(result, c => Assert.True(char.IsDigit(c)));
        }

        [Fact]
        public void ComputeSha512Hash_ReturnsCorrectHash()
        {
            string input = "test";
            string expectedHash = "ee26b0dd4af7e749aa1a8ee3c10ae9923f618980772e473f8819a5d4940e0db27ac185f8a0e1d5f84f88bc887fd67b143732c304cc5fa9ad8e6f57f50028a8ff";
            string result = CryptoUtils.ComputeSha512Hash(input);
            Assert.Equal(expectedHash, result);
        }

        [Fact]
        public void ToBase64_ReturnsCorrectBase64()
        {
            string input = "hello world";
            string expected = "aGVsbG8gd29ybGQ=";
            string result = CryptoUtils.ToBase64(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FromBase64_ReturnsCorrectString()
        {
            string input = "aGVsbG8gd29ybGQ=";
            string expected = "hello world";
            string result = CryptoUtils.FromBase64(input);
            Assert.Equal(expected, result);
        }
    }
}
