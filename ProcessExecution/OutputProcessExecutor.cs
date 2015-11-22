namespace ProcessExecution
{
    using System.Diagnostics;
    using System.Text;
    using Common;
    using Microsoft.Extensions.Logging;
    using Model;

    public abstract class OutputProcessExecutor
    {
        protected readonly StringBuilder OutputBuilder;

        protected readonly Process ProcessInstance;

        protected readonly ILogger Logger;

        protected OutputProcessExecutor(Process process,
             ProcessInstructions instructions, ILogger logger)
        {
            ProcessInstance = Check.NotNull<Process>(process);
            Instructions = Check.NotNull<ProcessInstructions>(instructions);
            Logger = Check.NotNull<ILogger>(logger);
            OutputBuilder = new StringBuilder();
        }

        public string Output => OutputBuilder.ToString();

        protected ProcessInstructions Instructions { get; set; }

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