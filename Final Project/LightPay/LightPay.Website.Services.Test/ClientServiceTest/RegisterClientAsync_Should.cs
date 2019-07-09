using LightPay.Data.Context;
using LightPay.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace LightPay.Website.Services.Test.ClientServiceTest
{
    [TestClass]
    public class RegisterClientAsync_Should
    {
        [TestMethod]
        public async Task Succeed_WhenNameIsValid()
        {
            using (var assertContext = new LightPayContext(
                TestUtils.GetOptions(nameof(Succeed_WhenNameIsValid))))
            {
                var sut = new ClientService(assertContext);

                //Act
                var registerClient = await sut.RegisterClientAsync("FirstTest");

                //Assert
                Assert.AreSame("FirstTest", registerClient.Name);
            }
        }


        [TestMethod]
        public async Task Failed_WhenNameExist()
        {
            TestUtils.PopulateContextWithClientParams(nameof(Failed_WhenNameExist));

            using (var assertContext = new LightPayContext(
                TestUtils.GetOptions(nameof(Failed_WhenNameExist))))
            {
                var sut = new ClientService(assertContext);

                //Assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await sut.RegisterClientAsync("Telerik"));

            }
        }
    }
}
