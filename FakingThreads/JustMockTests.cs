using NUnit.Framework;
using System.IO;
using Telerik.JustMock;

namespace FakingFile
{
    [TestFixture]
    public class JustMockTests
    {
        [Test]
        public void IDontNeedNoInterfacesTest()
        {
            Mock.Arrange(() => File.Exists(Arg.IsAny<string>())).Returns(true);

            var result = File.Exists("@#!!%^#%#%$");

            Assert.True(result);
        }

        [Test]
        public void FakingRealObjects()
        {
            var real = new RealClass();

            Mock.Arrange(() => real.NonVirtualMethod()).Returns(10);

            Assert.AreEqual(10, real);
        }
    }

    public class RealClass
    {
        public int NonVirtualMethod()
        {
            return 5;
        }
    }
}
