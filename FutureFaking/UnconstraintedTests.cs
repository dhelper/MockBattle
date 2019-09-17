using NUnit.Framework;
using Telerik.JustMock;
using TypeMock.ArrangeActAssert;

namespace FutureFaking
{
    [TestFixture]
    public class UnconstraintedTests
    {
        [Test, Isolated]
        public void FakeInternalDependecy()
        {
            var fakeDependecy = Isolate.Fake.NextInstance<SomeDependency>();
            Isolate.WhenCalled(() => fakeDependecy.ReturnFive()).WillReturn(10);

            var cut = new ClassWithoutDi();

            var result = cut.ReturnFive();

            Assert.AreEqual(10, result);
        }

        [Test]
        public void FakeInternalDependecyJustMock()
        {
            var fakeDependecy = Mock.Create<SomeDependency>();
            Mock.Arrange(() => fakeDependecy.ReturnFive()).IgnoreInstance().Returns(10);

            var cut = new ClassWithoutDi();

            var result = cut.ReturnFive();

            Assert.AreEqual(10, result);
        }
    }
}
