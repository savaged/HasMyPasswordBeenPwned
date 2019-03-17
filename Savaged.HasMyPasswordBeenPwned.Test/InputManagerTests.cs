using Microsoft.VisualStudio.TestTools.UnitTesting;
using Savaged.HasMyPasswordBeenPwned.Lib;

namespace Savaged.HasMyPasswordBeenPwned.Test
{
    [TestClass]
    public class InputManagerTests
    {
        [TestMethod]
        public void TestValidateInput()
        {
            string[] args = null;
            var inputMgr = new InputManager(args);

            var result = inputMgr
                .ValidateInput(out string feedback);
            Assert.IsFalse(result);
            Assert.AreEqual(
                "Include a command line argument" +
                " as a value to check", feedback);
            
            args = new string[] { "One", "Two" };
            inputMgr = new InputManager(args);
            result = inputMgr
                .ValidateInput(out feedback);
            Assert.IsTrue(result);
            Assert.AreEqual(
                "Warning! Concatenating all your inputs to one.", feedback);

            args = new string[] { "One" };
            inputMgr = new InputManager(args);
            result = inputMgr
                .ValidateInput(out feedback);
            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, feedback);
        }

        [TestMethod]
        public void TestInput()
        {
            string[] args = null;
            var inputMgr = new InputManager(args);

            var result = inputMgr.Input;
            Assert.AreEqual(string.Empty, result);

            args = new string[] { "One", "Two" };
            inputMgr = new InputManager(args);
            result = inputMgr.Input;
            Assert.AreEqual("One Two", result);

            args = new string[] { "One" };
            inputMgr = new InputManager(args);
            result = inputMgr.Input;
            Assert.AreEqual("One", result);
        }
    }
}
