using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;
using Client.ServiceReference1;
using NSubstitute;
using NUnit.Framework;

namespace nSubtituteTests
{
    [TestFixture]
    public class DistributedCalculatorTests
    {
        [Test]
        public void Calculate_ReturnTwoValidNumbers_ServerCalled()
        {
            IDataAccess fakeDataAccess = Substitute.For<IDataAccess>();
            fakeDataAccess.GetData(Arg.Any<string>()).Returns(new Tuple<int, int>(2, 3));
            
            ICalculatorService fakeCalculatorService = Substitute.For<ICalculatorService>();

            var cut = new DistributedCalculator(fakeDataAccess, fakeCalculatorService);

            cut.Calculate();

            fakeCalculatorService.Received().Add(2, 3);
        }
    }
}
