using FakeItEasy;
using NUnit.Framework;
using TestClasses;
using TestClasses.Fakes;

namespace RobustMocks
{
    [TestFixture]
    public class TestMethodChange
    {
        [Test]
        public void MsFakesTest()
        {
            var fakeObject = new StubIDependency
                {
                    SomeMethodWithParamsInt32String = (i, s) =>
                        {
                            return 42;
                        }
                };

            var cut = new MyObject(fakeObject);

            cut.SomeMethod();
        }
        
        [Test]
        public void FakeItEasyTest()
        {
            var fakeObject = A.Fake<IDependency>();
            A.CallTo(() => fakeObject.SomeMethodWithParams(A<int>.Ignored, A<string>.Ignored)).Returns(42);

            var cut = new MyObject(fakeObject);

            cut.SomeMethod();
        }
    }
}
