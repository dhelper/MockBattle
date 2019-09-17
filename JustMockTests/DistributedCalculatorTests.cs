using System;
using Client;
using Client.ServiceReference1;
using Telerik.JustMock;
using NUnit.Framework;

namespace JustMockTests
{
    [TestFixture]
    public class DistributedCalculatorTests
    {
        [Test]
        public void Calculate_ReturnTwoValidNumbers_ServerCalled()
        {
            IDataAccess fakeDataAccess = Mock.Create<IDataAccess>();
            Mock.Arrange(() => fakeDataAccess.GetData(Arg.IsAny<string>())).Returns(new Tuple<int, int>(2, 3));
            
            var fakeCalculatorService = Mock.Create<ICalculatorService>();

            var cut = new DistributedCalculator(fakeDataAccess, fakeCalculatorService);

            cut.Calculate();

            Mock.Assert(() => fakeCalculatorService.Add(2, 3));
        }
    }
}
