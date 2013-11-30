using System;
using Client;
using Client.ServiceReference1;
using Rhino.Mocks;
using NUnit.Framework;

namespace RhinoMocksTests
{
    [TestFixture]
    public class DistributedCalculatorTests
    {
        [Test]
        public void Calculate_ReturnTwoValidNumbers_ServerCalled()
        {
            IDataAccess fakeDataAccess = MockRepository.GenerateStub<IDataAccess>();
            fakeDataAccess.Stub(access => access.GetData("data-1")).Return(new Tuple<int, int>(2, 3));

            var fakeCalculatorService = MockRepository.GenerateMock<ICalculatorService>();

            var cut = new DistrobutedCalculator(fakeDataAccess, fakeCalculatorService);

            cut.Calculate();

            fakeCalculatorService.AssertWasCalled(service => service.Add(2, 3));
        }
    }
}
