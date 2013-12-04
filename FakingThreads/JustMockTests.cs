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
    }
}
