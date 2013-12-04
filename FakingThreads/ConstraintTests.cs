using Moq;
using NUnit.Framework;

namespace FakingFile
{
    [TestFixture]
    public class ConstraintTests
    {
        [Test]
        public void TestMySystemCalls()
        {
            var fakeFile = new Mock<IFile>();

            fakeFile.Setup(file => file.Exists(It.IsAny<string>())).Returns(true);

            var obj = new ClassUnderTest(fakeFile.Object);

            obj.CheckIfFileExists("!@@$#%%#$^");
        }
    }
}