using System;
using Client;
using Client.Fakes;
using Client.ServiceReference1.Fakes;
using NUnit.Framework;

namespace MsFakesTests
{
    [TestFixture]
    public class DistributedCalculatorTests
    {
        [Test]
        public void Calculate_ReturnTwoValidNumbers_ServerCalled()
        {
            IDataAccess fakeDataAccess = new StubIDataAccess
                {
                    GetDataString = _ => new Tuple<int, int>(2, 3)
                };

            var wasCalled = false;
            var fakeCalculatorService = new StubICalculatorService
                {
                    AddInt32Int32 = (a, b) =>
                        {
                            wasCalled = a == 2 && b == 3;

                            return a + b;
                        }
                };

            var cut = new DistrobutedCalculator(fakeDataAccess, fakeCalculatorService);

            cut.Calculate();

            Assert.True(wasCalled);
        }
    }
}
