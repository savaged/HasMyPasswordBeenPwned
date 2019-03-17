using Microsoft.VisualStudio.TestTools.UnitTesting;
using Savaged.HasMyPasswordBeenPwned.Lib;
using System.Threading.Tasks;

namespace Savaged.HasMyPasswordBeenPwned.Test
{
    [TestClass]
    public class PwnedServiceTests
    {
        [TestMethod]
        public async Task TestPwned()
        {
            var hashServ = new HashService("password");
            var pwnedServ = new PwnedService(
                hashServ.Hash);
            var result = pwnedServ.IsPwned;
            Assert.IsNull(result);

            await pwnedServ.LoadAsync();
            result = pwnedServ.IsPwned;
            Assert.IsTrue(result == true);
        }
    }
}
