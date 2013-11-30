namespace TestClasses
{
    public class Dependency : IDependency
    {
        public int SomeMethodWithParams1(int i, string s)
        {
            throw new System.NotImplementedException();
        }

        public int AnotherMethodWithParams(int result)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IDependency
    {
        int SomeMethodWithParams1(int i, string s);
        int AnotherMethodWithParams(int result);
    }
}
