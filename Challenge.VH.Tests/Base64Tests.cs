using NUnit.Framework;

namespace Challenge.VH.Tests
{
    [TestFixture]
    public class Base64Tests
    {
        [Test]
        public void ShouldHandleSentences()
        {
            Assert.AreEqual("dGhpcyBpcyBhIHN0cmluZyEh", ConvertToBase64.Base64Encode("this is a string!!"));
            Assert.AreEqual("dGhpcyBpcyBhIHRlc3Qh", ConvertToBase64.Base64Encode("this is a test!"));
        }
    }
}
