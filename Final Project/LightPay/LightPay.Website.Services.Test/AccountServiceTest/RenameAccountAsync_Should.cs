using LightPay.Data.Context;
using LightPay.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace LightPay.Website.Services.Test.AccountServiceTest
{
    [TestClass]
    public class RenameAccountAsync_Should
    {
        [TestMethod]
        public async Task Succeed_WhenAccountExist()
        {
            TestUtils.PopulateContextWithAccountParams(nameof(Succeed_WhenAccountExist));

            using (var assertContext = new LightPayContext(
                TestUtils.GetOptions(nameof(Succeed_WhenAccountExist))))
            {
                var sut = new AccountService(assertContext);

                //Act
                var accountName = await sut.RenameAccountAsync("1999999456", "Test");

                //Assert
                Assert.AreSame("Test", accountName.Nickname);
            }
        }
        
        [TestMethod]
        public async Task GetAccount_Succeed_WhenAccountExist()
        {
            TestUtils.PopulateContextWithAccountParams(nameof(GetAccount_Succeed_WhenAccountExist));

            using (var assertContext = new LightPayContext(
                TestUtils.GetOptions(nameof(GetAccount_Succeed_WhenAccountExist))))
            {
                var sut = new AccountService(assertContext);

                //Act
                var account = await sut.GetAccount("1234567890");

                //Assert
                Assert.AreEqual(3000000, account.Balance);
            }
        }
    }
}
