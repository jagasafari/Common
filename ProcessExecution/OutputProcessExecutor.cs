namespace ProcessExecution
{
    using System.Diagnostics;
    using System.Text;
    using Model;

    public abstract class OutputProcessExecutor
    {
        protected readonly StringBuilder OutputBuilder;

        protected readonly Process ProcessInstance;

        protected OutputProcessExecutor(Process process, ProcessInstructions instructions)
        {
            ProcessInstance = process;
            Instructions = instructions;
            OutputBuilder = new StringBuilder();
        }

        public string Output => OutputBuilder.ToString();

        protected ProcessInstructions Instructions { get; set; }

        public void Execute()
        {
            ProcessInstance.OutputDataReceived +=
                (sender, e) => { OutputBuilder.AppendLine(e.Data); };
            ProcessInstance.ErrorDataReceived +=
                (sender, e) => { OutputBuilder.AppendLine(e.Data); };
            ProcessInstance.Exited += (sender, e) => { };
            ProcessInstance.EnableRaisingEvents = true;

            ProcessInstance.Start();
            ProcessInstance.StandardInput.Dispose();
            ProcessInstance.BeginOutputReadLine();
            ProcessInstance.BeginErrorReadLine();
        }
    }
}