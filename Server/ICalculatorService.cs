using System.ServiceModel;

namespace Server
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        int Add(int a, int b);
    }
}