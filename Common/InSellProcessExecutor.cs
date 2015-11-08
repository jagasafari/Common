namespace Common
{
    using System;
    using System.Diagnostics;

    public class InSellProcessExecutor
    {
        public static void ExecuteAndWait(string programPath,
            string arguments)
        {
            var processStartInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = programPath,
                Arguments = arguments
            };
            var process = Process.Start(processStartInfo);
            process.WaitForExit();
            if(process.ExitCode != 0)
                throw new Exception("Process Exit Code failure.");
        }
    }
}