using Microsoft.VisualStudio.TestTools.UnitTesting;
using Savaged.HasMyPasswordBeenPwned.Lib;

namespace Savaged.HasMyPasswordBeenPwned.Test
{
    [TestClass]
    public class HashServiceTests
    {
        [TestMethod]
        public void TestHash()
        {
            var hashServ = new HashService("password");
            var result = hashServ.Hash;
            Assert.AreEqual(
                "5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8", 
                result);
        }
    }
}
