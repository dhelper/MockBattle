namespace FutureFaking
{
    public class ClassWithoutDi
    {
        private readonly SomeDependency _dependency;
        public ClassWithoutDi()
        {
            _dependency = new SomeDependency();
        }

        public int ReturnFive()
        {
            return _dependency.ReturnFive();
        }
    }

    public class SomeDependency
    {
        public int ReturnFive()
        {
            return 5;
        }
    }

}