using Moq;
using Xunit;

namespace FakingThreads
{
    public class ConstraintTests
    {
        [Fact]
        public void TestMySystemCalls()
        {
            var fakeFile = new Mock<IFile>();

            fakeFile.Setup(file => file.Exists(It.IsAny<string>())).Returns(true);

            var obj = new ClassUnderTest(fakeFile.Object);

            obj.CheckIfFileExists("!@@$#%%#$^");
        }
    }
}