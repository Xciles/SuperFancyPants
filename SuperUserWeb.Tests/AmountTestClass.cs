using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuperUserWeb.Business.Interfaces;
using SuperUserWeb.Controllers;
using SuperUserWeb.Data;
using SuperUserWeb.Models.RoomViewModels;
using SuperUserWeb.Utils;

namespace SuperUserWeb.Tests
{
    [TestClass]
    public class AmountTestClass
    {
        // unit test code  
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;

            Account account = new Account
            {
                Name = "Mr. T",
                Balance = beginningBalance
            };

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
    }

    [TestClass]
    public class RoomControllerTests
    {
        // unit test code  
        [TestMethod]
        public void IndexTestDefault()
        {
            //var mockContext = new Mock<FancyDbContext>();
            //var iRoom = new Mock<IRoom>();
            //iRoom.Setup(x => x.CreatePost(It.IsAny<RoomViewModel>())).Returns(Task.CompletedTask);

            //var roomController = new RoomController(mockContext.Object, iRoom.Object, null, null);
            //roomController.Index();

            //iRoom.ve
        }
    }
}
