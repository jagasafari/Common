namespace Common
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public class ProcessExecutor : IDisposable
    {
        private readonly StringBuilder _outputFromProcess;

        public ProcessExecutor()
        {
            _outputFromProcess = new StringBuilder();
            _processInstance = new Process();
        }

        public string Output => _outputFromProcess.ToString();
        public void Dispose()
        {
            _processInstance.Kill();
        }

        private readonly Process _processInstance;

        public void Execute(string fileName, string arguments)
        {
            _processInstance.StartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            _processInstance.OutputDataReceived +=
                (sender, e) => { _outputFromProcess.AppendLine(e.Data); };
            _processInstance.ErrorDataReceived +=
                (sender, e) => { _outputFromProcess.AppendLine(e.Data); };
            _processInstance.Exited += (sender, e) => { };
            _processInstance.EnableRaisingEvents = true;

            _processInstance.Start();
            _processInstance.StandardInput.Dispose();
            _processInstance.BeginOutputReadLine();
            _processInstance.BeginErrorReadLine();
        }
    }
}