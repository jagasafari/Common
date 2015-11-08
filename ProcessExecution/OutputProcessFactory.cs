namespace Common.ProcessExecution
{
    using System.Diagnostics;
    using Model;

    public class OutputProcessFactory
    {
        private ProcessStartInfo StartInfo => new ProcessStartInfo
        {
            UseShellExecute = false,
            FileName = Instructions.Program,
            Arguments = Instructions.Arguments,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };

        public ProcessInstructions Instructions { get; set; }

        public Process Create() => new Process{StartInfo = StartInfo};
    }
}