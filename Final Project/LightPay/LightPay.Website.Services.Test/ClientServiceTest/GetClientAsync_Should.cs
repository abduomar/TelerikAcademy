using LightPay.Data.Context;
using LightPay.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace LightPay.Website.Services.Test.ClientServiceTest
{
    [TestClass]
    public class GetClientAsync_Should
    {
        
       [TestMethod]
      public async Task Succeed_WhenClientExist() 
      {

          TestUtils.PopulateContextWithClientParams(nameof(Succeed_WhenClientExist));

          using (var assertContext = new LightPayContext(
              TestUtils.GetOptions(nameof(Succeed_WhenClientExist))))
          {
              var sut = new ClientService(assertContext);

              //Act
              var registerClient = await sut.GetClientsAsync();

              //Assert
              Assert.AreEqual(registerClient.Count, 2);
          }
      }       
    }
}
