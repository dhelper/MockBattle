namespace TestClasses
{
    public class MyObject
    {
        private readonly IDependency _dependency;

        public MyObject(IDependency dependency)
        {
            _dependency = dependency;            
        }

        public void SomeMethod()
        {
            var result =  _dependency.SomeMethodWithParams(0, "dummy");

            _dependency.AnotherMethodWithParams(result);
        }
    }
}