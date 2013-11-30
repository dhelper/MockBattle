using System.IO;

namespace FakingThreads
{
    public interface IFile
    {
        void Copy(string source, string dest);
        void Delete(string fn);
        bool Exists(string fn);
    }

    public class FileImpl : IFile
    {
        public virtual void Copy(string source, string dest)
        {
            File.Copy(source, dest);
        }

        public virtual void Delete(string fn)
        {
            File.Delete(fn);
        }

        public virtual bool Exists(string fn)
        {
            return File.Exists(fn);
        }
    }

    public class ClassUnderTest
    {
        private readonly IFile _filesystem;

        public ClassUnderTest(IFile filesystem)
        {
            _filesystem = filesystem;
        }

        public void CheckIfFileExists(string fileName)
        {
            _filesystem.Exists(fileName);
        }
    }
}
