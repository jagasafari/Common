namespace Common.ProcessExecution
{
    using System.Diagnostics;
    using System.Text;
    using Microsoft.Extensions.Logging;

    public class OutputProcessExecutor
    {
        protected readonly StringBuilder OutputBuilder;

        public Process ProcessInstance {get;set;}

        protected readonly ILogger<OutputProcessExecutor> Logger;

        public OutputProcessExecutor(ILogger<OutputProcessExecutor> logger)
        {
            Logger = logger;
            OutputBuilder = new StringBuilder();
        }

        public string Output => OutputBuilder.ToString();

        public void Execute()
        {
            ProcessInstance.OutputDataReceived +=
                (sender, e) =>
                {
                    var data = e?.Data??string.Empty;
                    OutputBuilder.AppendLine(data);
                    Logger.LogInformation(data);
                };
            ProcessInstance.ErrorDataReceived +=
                (sender, e) =>
                {
                    var data = e?.Data??string.Empty;
                    OutputBuilder.AppendLine(data);
                    Logger.LogError(data);
                };
            ProcessInstance.Exited += (sender, e) => { 
                Logger.LogInformation("process exited");
            };
            ProcessInstance.EnableRaisingEvents = true;

            ProcessInstance.Start();
            ProcessInstance.StandardInput.Dispose();
            ProcessInstance.BeginOutputReadLine();
            ProcessInstance.BeginErrorReadLine();
        }
    }
}