using NUnit.Framework;
using NextBiggerNumber;

namespace Tests
{
    public class KataTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestInvalidNumbers()
        {
            Assert.AreEqual(-1, Kata.NextBiggerNumber(9));
            Assert.AreEqual(-1, Kata.NextBiggerNumber(111));
            Assert.AreEqual(-1, Kata.NextBiggerNumber(531));
        }
        [Test]
        public void TestSmallNumbers()
        {
            Assert.AreEqual(21, Kata.NextBiggerNumber(12));
            Assert.AreEqual(531, Kata.NextBiggerNumber(513));
            Assert.AreEqual(2071, Kata.NextBiggerNumber(2017));
            Assert.AreEqual(441, Kata.NextBiggerNumber(414));
            Assert.AreEqual(414, Kata.NextBiggerNumber(144));
        }
        [Test]
        public void TestBigNumbers()
        {
            Assert.AreEqual(59884848483559, Kata.NextBiggerNumber(59884848459853));
            Assert.AreEqual(536479, Kata.NextBiggerNumber(534976));
            Assert.AreEqual(251678, Kata.NextBiggerNumber(218765));
        }

    }
}