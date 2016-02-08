namespace Common.ProcessExecution
{
    using System;
    using System.IO;

    public class CurrentDirectorySetter : IDisposable
    {
        private readonly string _initialDirectory;
        public CurrentDirectorySetter(string curretDirectory)
        {
            _initialDirectory = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(curretDirectory);
        }

        public void Dispose()
        {
            Directory.SetCurrentDirectory(_initialDirectory);
        }
    }
}
