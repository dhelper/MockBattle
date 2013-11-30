using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ServiceReference1.CalculatorServiceClient();
            client.Open();

            var data = new DataAccess();

            var engine = new DistrobutedCalculator(data, client);

            var result = engine.Calculate();

            Console.WriteLine(result);
        }
    }
}
