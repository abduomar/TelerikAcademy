using LightPay.Data.Context;
using LightPay.Models;
using LightPay.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightPay.Website.Services.Test.AccountServiceTest
{
    [TestClass]
    public class RegisterAccountAsync_Should
    {
        /*[TestMethod]
        public async Task Succeed_WhenDataIsValid()
        {
            //TestUtils.PopulateContextWithAccountParams(nameof(Succeed_WhenDataIsValid));

            using (var arrangeContext = new LightPayContext(
                TestUtils.GetOptions(nameof(Succeed_WhenDataIsValid))))
            {
                arrangeContext.Clients.Add(new Client {Id = Guid.Parse("A"), Name = "Test" });

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new LightPayContext(
                TestUtils.GetOptions(nameof(Succeed_WhenDataIsValid))))
            {
                var sut = new AccountService(assertContext);

                //Act
                                
                var registerAccount = await sut.RegisterAccountAsync(34000, Guid.Parse("A"));

                //Assert
                Assert.AreSame("Telerik", registerAccount.Client.Name);
            }
    }*/
}
}
