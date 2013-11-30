using FakeItEasy;
using Xunit;

namespace FakingThreads
{
    public class ConstraintTests
    {
        [Fact]
        public void TestMySystemCalls()
        {
            var filesystem = A.Fake<IFile>();

            A.CallTo(() => filesystem.Exists(A<string>.Ignored)).Returns(true);

            var obj = new ClassUnderTest(filesystem);
            
            obj.CheckIfFileExists("!@@$#%%#$^"); 
        }
    }
}