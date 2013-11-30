using System.IO;
using Telerik.JustMock;
using Xunit;

namespace FakingThreads
{
    public class JustMockTests
    {
        [Fact]
        public void IDontNeedNoInterfacesTest()
        {
            Mock.Arrange(() => File.Exists(Arg.IsAny<string>())).Returns(true);

            var result = File.Exists("@#!!%^#%#%$");

            Assert.True(result);
        }
    }
}
