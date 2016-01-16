namespace Common.ProcessExecution
{
    using System.Diagnostics;
    using Common.ProcessExecution.Abstraction;
    using Model;

    public class ProcessFactory : IProcessFactory
    {
        public Process Create(ProcessInstructions instructions)
        {
            var startInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                FileName = instructions.Program,
                Arguments = instructions.Arguments,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            
            return new Process { StartInfo = startInfo };
        }

    }

}