using System;
using Client;
using Client.ServiceReference1;
using NMock;
using NUnit.Framework;

namespace NMockTests
{
    [TestFixture]
    public class DistributedCalculatorTests
    {
        private readonly MockFactory _factory = new MockFactory();

        [TearDown]
        public void TearDown()
        {
            _factory.ClearExpectations();
        }

        [Test]
        public void Calculate_ReturnTwoValidNumbers_ServerCalled()
        {
            Mock<IDataAccess> fakeDataAccess = _factory.CreateMock<IDataAccess>();

            fakeDataAccess.Expects.Any.MethodWith(access => access.GetData("data-1")).WillReturn(new Tuple<int, int>(2, 3));

            var fakeCalculatorService = _factory.CreateMock<ICalculatorService>();
            fakeCalculatorService.Expects.AtLeastOne.MethodWith(service => service.Add(2, 3));

            var cut = new DistributedCalculator(fakeDataAccess.MockObject, fakeCalculatorService.MockObject);

            cut.Calculate();

            _factory.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
