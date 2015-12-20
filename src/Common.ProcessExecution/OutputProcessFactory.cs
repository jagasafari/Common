namespace Common.ProcessExecution
{
    using System.Diagnostics;
    using Model;

    internal class OutputProcessFactory
    {
        public OutputProcessFactory(ProcessInstructions instructions)
        {
            _instructions = instructions;
        }

        private ProcessStartInfo StartInfo => new ProcessStartInfo
        {
            UseShellExecute = false,
            FileName = _instructions.Program,
            Arguments = _instructions.Arguments,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };

        private readonly ProcessInstructions _instructions;

        public Process Create() => new Process{StartInfo = StartInfo};

    }
}