using Microsoft.VisualStudio.TestTools.UnitTesting;
using Savaged.HasMyPasswordBeenPwned.CLI;

namespace Savaged.HasMyPasswordBeenPwned.Test
{
    [TestClass]
    public class CliTests
    {
        [TestMethod]
        public void TestMain()
        {
            var program = new Program();
            var feedback = program
                .Run(new string[] { "password" });
            Assert.AreEqual(
                "Pwned! Change it!", 
                feedback);
        }
    }
}
