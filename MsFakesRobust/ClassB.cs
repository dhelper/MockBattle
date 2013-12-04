using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobustMocks
{
    public interface IClassB
    {
        int GetFive();
        IClassC GetC();
    }

    public interface IClassC
    {

    }
}
