using FakeItEasy;
using Moq;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMock.ArrangeActAssert;

namespace RobustMocks
{
    [TestFixture]
    public class DefaultReturnValue
    {
        [Test]
        public void MoqRecusrsiveFakeTest()
        {
            var fakeA = new Mock<ClassA>().Object;

            var isThisB = fakeA.GetB();

            Assert.Null(isThisB);
        }

        [Test]
        public void nSubtituteRecusrsiveFakeTest()
        {
            var fakeA = Substitute.For<ClassA>();

            var isThisB = fakeA.GetB();

            Assert.Null(isThisB);
        }

        [Test]
        public void NMock3RecusrsiveFakeTest()
        {
            var factory = new NMock.MockFactory();

            var fakeA = factory.CreateMock<ClassA>();

            var isThisB = fakeA.MockObject.GetB();

            Assert.IsNull(isThisB);
        }
    }

    public class ClassA
    {
        virtual public IClassB GetB()
        {
            throw new NotImplementedException();
        }
    }
}
