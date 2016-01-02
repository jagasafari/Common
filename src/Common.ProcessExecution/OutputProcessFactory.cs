namespace Common.ProcessExecution
{
    using System.Diagnostics;
    using Model;

    public class OutputProcessFactory : IOutputProcessFactory
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