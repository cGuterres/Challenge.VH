using NUnit.Framework;

namespace Challenge.VH.Tests
{
    [TestFixture]
    public sealed class MorseCodeTests
    {
        [Test]
        public void BasicCases()
        {
            Assert.AreEqual(new string[] { "E" }, MorseCode.Possibilities("."));
            Assert.AreEqual(new string[] { "D" }, MorseCode.Possibilities(".-"));
        }

        [Test]
        public void WordsWithASingleUnknownSignal()
        {
            Assert.AreEqual(new string[] { "E", "T" }, MorseCode.Possibilities("?"));
            Assert.AreEqual(new string[] { "I", "N" }, MorseCode.Possibilities("?."));
            Assert.AreEqual(new string[] { "I", "A" }, MorseCode.Possibilities(".?"));
        }
    }
}