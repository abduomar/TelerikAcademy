using LightPay.Data.Context;
using LightPay.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace LightPay.Website.Services.Test.UserServiceTest
{
    [TestClass]
    public class User_Should
    {
        [TestMethod]
        public async Task Succeed_WhenDataIsValid()
        {
            using (var assertContext = new LightPayContext(
                TestUtils.GetOptions(nameof(Succeed_WhenDataIsValid))))
            {
                var sut = new UserService(assertContext);

                //Act
                var user = await sut.CreateUserAsync("Mike", "Mike246@", "Mickael");

                //Assert
                Assert.AreSame("Mike", user.Username);
            }
        }

        [TestMethod]
        public async Task GetUsersAsync_Succeed_WhenUserExist()
        {
            TestUtils.PopulateContextWithUsers(nameof(GetUsersAsync_Succeed_WhenUserExist));

            using (var assertContext = new LightPayContext(
                TestUtils.GetOptions(nameof(GetUsersAsync_Succeed_WhenUserExist))))
            {
                var sut = new UserService(assertContext);

                //Act
                var users = await sut.GetUsersAsync();

                //Assert

                Assert.AreSame("Mickael", users[0].Name);

                /*await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await sut.MakePayment("1234567890", 500, "1245373456","test", false));*/

            }
        }
    }
}
