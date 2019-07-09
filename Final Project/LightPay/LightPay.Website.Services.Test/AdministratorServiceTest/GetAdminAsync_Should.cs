using LightPay.Data.Context;
using LightPay.Models;
using LightPay.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace LightPay.Website.Services.Test.AdministratorServiceTest
{
    [TestClass]
    public class GetAdminAsync_Should
    {
        [TestMethod]
        public async Task Failed_WhenAdminNotExist()
        {
            /*using (var arrangeContext = new LightPayContext(
                TestUtils.GetOptions(nameof(Succeed_WhenAdminExist))))
            {
                arrangeContext.Administrators.Add(new Administrator { Username = "John", Password = "John567@"});
                
                arrangeContext.SaveChanges();
            }*/
            TestUtils.PopulateContextWithAdmin(nameof(Failed_WhenAdminNotExist));

            using (var assertContext = new LightPayContext(
                TestUtils.GetOptions(nameof(Failed_WhenAdminNotExist))))
            {
                var sut = new AdministratorService(assertContext);

                
                //Assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await sut.GetAdminAsync("Telerik", "abs"));
                
            }
        }
    }
}
