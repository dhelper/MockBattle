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
        public void FakeItEasyReturnNull()
        {
            var fakeA = A.Fake<ClassA>();

            var isThisB = fakeA.GetB();

            Assert.Null(isThisB);
        }

        [Test]
        public void MoqRecusrsiveFakeReturnNull()
        {
            var fakeA = new Mock<ClassA>().Object;

            var isThisB = fakeA.GetB();

            Assert.Null(isThisB);
        }

        [Test]
        public void nSubtituteReturnNull()
        {
            var fakeA = Substitute.For<ClassA>();

            var isThisB = fakeA.GetB();

            Assert.Null(isThisB);
        }
        
        [Test, Isolated]
        public void IsolatorRecusrsiveFake()
        {
            var fakeA = Isolate.Fake.Instance<ClassA>();

            var isThisB = fakeA.GetB();

            Assert.Null(isThisB);
        }


    }

    public class ClassA
    {
        public IClassB GetB()
        {
            return null;
        }
    }
}
