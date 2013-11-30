using TypeMock.ArrangeActAssert;
using Xunit;

namespace FutureFaking
{
    public class UnconstraintedTests
    {
        [Fact, Isolated]
        public void FakeInternalDependecy()
        {
            var fakeDependecy = Isolate.Fake.NextInstance<SomeDependency>();
            Isolate.WhenCalled(() => fakeDependecy.ReturnFive()).WillReturn(10);

            var cut = new ClassWithoutDi();

            var result = cut.ReturnFive();

            Assert.Equal(10, result);
        }
    }
}
