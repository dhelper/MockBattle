using System;
using Client;
using Client.ServiceReference1;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasyTests
{
    [TestFixture]
    public class DistributedCalculatorTests
    {
        [Test]
        public void Calculate_ReturnTwoValidNumbers_ServerCalled()
        {
            IDataAccess fakeDataAccess = A.Fake<IDataAccess>();
            A.CallTo(() => fakeDataAccess.GetData(A<string>.Ignored)).Returns(new Tuple<int, int>(2, 3));

            var fakeCalculatorService = A.Fake<ICalculatorService>();

            var cut = new DistrobutedCalculator(fakeDataAccess, fakeCalculatorService);

            cut.Calculate();

            A.CallTo(() => fakeCalculatorService.Add(2,3)).MustHaveHappened();
        }
    }
}
