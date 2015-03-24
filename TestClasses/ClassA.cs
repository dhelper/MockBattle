using System;

namespace TestClasses
{
    public class ClassA
    {
        virtual public IClassB IWantB()
        {
            throw new NotImplementedException();
        }

        virtual public int ReturnFive()
        {
            return 5;
        }
    }
}