namespace TestClasses
{
    public class Dependency : IDependency
    {
        public int SomeMethodWithParams(int i, string s)
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
        int SomeMethodWithParams(int i, string s);
        int AnotherMethodWithParams(int result);
    }
}
