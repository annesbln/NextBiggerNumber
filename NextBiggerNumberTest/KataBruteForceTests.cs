using NUnit.Framework;
using NextBiggerNumberBruteForce;

namespace TestsBruteForce
{
    public class KataBruteForceTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestInvalidNumbers()
        {
            Assert.AreEqual(-1, KataBruteForce.NextBiggerNumber(9));
            Assert.AreEqual(-1, KataBruteForce.NextBiggerNumber(111));
            Assert.AreEqual(-1, KataBruteForce.NextBiggerNumber(531));
        }
        [Test]
        public void TestSmallNumbers()
        {
            Assert.AreEqual(21, KataBruteForce.NextBiggerNumber(12));
            Assert.AreEqual(531, KataBruteForce.NextBiggerNumber(513));
            Assert.AreEqual(2071, KataBruteForce.NextBiggerNumber(2017));
            Assert.AreEqual(441, KataBruteForce.NextBiggerNumber(414));
            Assert.AreEqual(414, KataBruteForce.NextBiggerNumber(144));
        }
        [Test]
        public void TestBigNumbers()
        {
            Assert.AreEqual(59884848483559, KataBruteForce.NextBiggerNumber(59884848459853));
            Assert.AreEqual(536479, KataBruteForce.NextBiggerNumber(534976));
            Assert.AreEqual(251678, KataBruteForce.NextBiggerNumber(218765));
        }

    }
}