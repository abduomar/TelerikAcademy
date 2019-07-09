using LightPay.Data.Context;
using LightPay.Models;
using LightPay.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace LightPay.Website.Services.Test.AccountServiceTest
{
    [TestClass]
    public class GetAccount_Should
    {
       [TestMethod]
        public async Task Succeed_Get_Account()
        {
            TestUtils.PopulateContextWithAccountParams(nameof(Succeed_Get_Account));

            using (var assertContext = new LightPayContext(
                TestUtils.GetOptions(nameof(Succeed_Get_Account))))
            {
                var sut = new AccountService(assertContext);

                //Act
                Account account = await sut.GetAccount("1234567890");                

                //Assert
                Assert.AreSame("1234567890", account.Nickname);
                }
            }

        [TestMethod]
        public async Task Succeed_GetAccountsAsync()
        {
            TestUtils.PopulateContextWithAccountParams(nameof(Succeed_GetAccountsAsync));

            using (var assertContext = new LightPayContext(
                TestUtils.GetOptions(nameof(Succeed_GetAccountsAsync))))
            {
                var sut = new AccountService(assertContext);

                //Act
                var accounts = await sut.GetAccountsAsync();

                //Assert
                Assert.AreEqual(3, accounts.Count);
            }
        }

        [TestMethod]
        public async Task Succeed_GetAccountBalance()
        {
            TestUtils.PopulateContextWithAccountParams(nameof(Succeed_GetAccountBalance));

            using (var assertContext = new LightPayContext(
                TestUtils.GetOptions(nameof(Succeed_GetAccountBalance))))
            {
                var sut = new AccountService(assertContext);

                //Act
                var account = await sut.GetAccountBalance("1234567890");

                //Assert
                Assert.AreEqual(3000000, account);
            }
        }
    }
}

