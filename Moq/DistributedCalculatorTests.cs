using System;
using Client;
using Client.ServiceReference1;
using Moq;
using NUnit.Framework;

namespace MoqTests
{
    [TestFixture]
    public class DistributedCalculatorTests
    {
        [Test]
        public void Calculate_ReturnTwoValidNumbers_ServerCalled()
        {
            Mock<IDataAccess> fakeDataAccess = new Mock<IDataAccess>();
            fakeDataAccess.Setup(access => access.GetData(It.IsAny<string>())).Returns(new Tuple<int, int>(2, 3));

            Mock<ICalculatorService> fakeCalculatorService = new Mock<ICalculatorService>();

            var cut = new DistributedCalculator(fakeDataAccess.Object, fakeCalculatorService.Object);

            cut.Calculate();

            fakeCalculatorService.Verify(service => service.Add(2, 3));
        }
    }
}
