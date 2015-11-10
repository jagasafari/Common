namespace ProcessExecution
{
    using System.Diagnostics;
    using Model;

    public class InSellProcessExecutor
    {
        public static void ExecuteAndWait(ProcessInstructions instructions)
        {
            var processStartInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = instructions.Program,
                Arguments = instructions.Arguments
            };
            var process = Process.Start(processStartInfo);
            process.WaitForExit();
            if(process.ExitCode != 0)
                throw new ProcessFailiureException(instructions);
        }
    }
}