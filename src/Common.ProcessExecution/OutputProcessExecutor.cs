namespace Common.ProcessExecution
{
    using System.Diagnostics;
    using System.Text;
    using Common.Core;
    using Common.ProcessExecution.Abstraction;
    using Microsoft.Extensions.Logging;

    public class OutputProcessExecutor : IOutputProcessExecutor
    {
        private readonly StringBuilder _outputBuilder;

        private Process _process;
        protected readonly ILogger<OutputProcessExecutor> Logger;

        public OutputProcessExecutor(ILogger<OutputProcessExecutor> logger)
        {
            Logger = logger;
            _outputBuilder = new StringBuilder();
        }

        public Process ProcessInstance { get { return _process; } set { _process = Check.NotNull(value, nameof(value)); } }

        public string Output => _outputBuilder.ToString();

        public void Execute()
        {
            ProcessInstance.OutputDataReceived +=
                (sender, e) =>
                {
                    var data = e?.Data ?? string.Empty;
                    _outputBuilder.AppendLine(data);
                    Logger.LogInformation(data);
                };
            ProcessInstance.ErrorDataReceived +=
                (sender, e) =>
                {
                    var data = e?.Data ?? string.Empty;
                    _outputBuilder.AppendLine(data);
                    Logger.LogError(data);
                };
            ProcessInstance.Exited += (sender, e) => Logger.LogInformation("process exited");
            ProcessInstance.EnableRaisingEvents = true;

            ProcessInstance.Start();
            ProcessInstance.StandardInput.Dispose();
            ProcessInstance.BeginOutputReadLine();
            ProcessInstance.BeginErrorReadLine();
        }
    }
}