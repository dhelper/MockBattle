using FakeItEasy;
using Microsoft.QualityTools.Testing.Fakes;
using Moq;
using NSubstitute;
using NUnit.Framework;
using System;
using TestClasses;
using TestClasses.Fakes;
using TypeMock.ArrangeActAssert;

namespace RobustMocks
{
    [TestFixture]
    public class DefaultReturnValue
    {
        [Test]
        public void NMock3RecusrsiveFakeTest()
        {
            var factory = new NMock.MockFactory();

            var fakeA = factory.CreateMock<ClassA>();

            var isThisB = fakeA.MockObject.IWantB();

            Assert.IsNotNull(isThisB);
        }

        [Test]
        public void RhinoMockRecusrsiveFakeTest()
        {
            var fakeA = Rhino.Mocks.MockRepository.GenerateStub<ClassA>();

            var isThisB = fakeA.IWantB();

            Assert.IsNotNull(isThisB);
        }

        [Test]
        public void MoqRecusrsiveFakeTest()
        {
            var fakeA = new Mock<ClassA>().Object;

            var isThisB = fakeA.IWantB();

            Assert.IsNotNull(isThisB);
        }

        [Test]
        public void MsFakesShimsRecusrsiveFakeTest()
        {
            using (ShimsContext.Create())
            {
                var shimClassA = new ShimClassA();

                var isThisB = shimClassA.Instance.IWantB();

                Assert.IsNotNull(isThisB);
            }
        }

        [Test]
        public void MsFakesRecusrsiveFakeTest()
        {
            var fakeA = new StubClassA();

            var isThisB = fakeA.IWantB();

            Assert.IsNotNull(isThisB);
        }

        [Test]
        public void nSubtituteRecusrsiveFakeTest()
        {
            var fakeA = Substitute.For<ClassA>();

            var isThisB = fakeA.IWantB();

            Assert.IsNotNull(isThisB);
        }

        [Test]
        public void FakeItEasyRecusrsiveFakeTest()
        {
            var fakeA = A.Fake<ClassA>();

            var isThisB = fakeA.IWantB();

            Assert.IsNotNull(isThisB);
        }

        [Test, Isolated]
        public void IsolatorRecursiveFakeTest()
        {
            var fakeA = Isolate.Fake.Instance<ClassA>();

            var isThisB = fakeA.IWantB();

            Assert.IsNotNull(isThisB);
        }

        [Test]
        public void JustMockRecursiveFakeTest()
        {
            var fakeA = Telerik.JustMock.Mock.Create<ClassA>();

            var isThisB = fakeA.IWantB();

            Assert.IsNotNull(isThisB);
        }
    }
}
