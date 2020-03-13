using FluentAssertions;
using NUnit.Framework;

namespace thegame_tests
{
    [TestFixture]
    public class thegame_Tests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void DoNothingTest()
        {
            int a = 1;
            Assert.AreEqual(1, a);
        }
    }
}
