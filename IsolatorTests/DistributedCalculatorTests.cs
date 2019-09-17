using System;
using Client;
using Client.ServiceReference1;
using TypeMock.ArrangeActAssert;
using NUnit.Framework;

namespace IsolatorTests
{
    [TestFixture, Isolated]
    public class DistributedCalculatorTests
    {
        [Test]
        public void Calculate_ReturnTwoValidNumbers_ServerCalled()
        {
            var fakeDataAccess = Isolate.Fake.Instance<IDataAccess>();
            Isolate.WhenCalled(() => fakeDataAccess.GetData("")).WillReturn(new Tuple<int, int>(2, 3));

            var fakeCalculatorService = Isolate.Fake.Instance<ICalculatorService>();

            var cut = new DistributedCalculator(fakeDataAccess, fakeCalculatorService);

            cut.Calculate();

            Isolate.Verify.WasCalledWithExactArguments(() => fakeCalculatorService.Add(2, 3));
        }
    }
}
