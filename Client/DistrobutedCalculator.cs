using System;
using Client.ServiceReference1;

namespace Client
{
    public class DistrobutedCalculator
    {
        private readonly IDataAccess _dataAccess;
        private readonly ICalculatorService _calculator;

        public DistrobutedCalculator(IDataAccess dataAccess, ICalculatorService calculator)
        {
            _dataAccess = dataAccess;
            _calculator = calculator;
        }

        public int Calculate()
        {
            try
            {
                var nextValue = _dataAccess.GetData("data-1");

                var result = _calculator.Add(nextValue.Item1, nextValue.Item2);

                return result;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
