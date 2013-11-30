using System;

namespace Client
{
    public interface IDataAccess
    {
        Tuple<int, int> GetData(string id);
    }

    public class DataAccess : IDataAccess
    {
        public Tuple<int, int> GetData(string id)
        {
            throw new NotImplementedException();
        }
    }
}
