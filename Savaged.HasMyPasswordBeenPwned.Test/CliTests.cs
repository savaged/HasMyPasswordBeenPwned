using Microsoft.VisualStudio.TestTools.UnitTesting;
using Savaged.HasMyPasswordBeenPwned.CLI;
using System;

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
                $"{Environment.NewLine}Pwned! Change it!", 
                feedback);
        }
    }
}
