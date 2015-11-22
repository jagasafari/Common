namespace ProcessExecution
{
    using System;
    using System.Diagnostics;
    using Microsoft.Extensions.Logging;
    using Model;

    public class FinishingProcessExecutor : OutputProcessExecutor
    {
        public FinishingProcessExecutor(Process process, 
            ProcessInstructions instructions, ILogger logger)
             : base(process, instructions, logger)
        {
        }

        public void ExecuteAndWait(Func<string, bool> failurePredicate)
        {
            Execute();

            if (!WaitForExit())
                throw new ProcessFailiureException(Instructions,
                    Output);

            if (failurePredicate(Output))
                throw new ProcessFailiureException(Instructions, Output);
        }

        private bool WaitForExit()
        {
            ProcessInstance.WaitForExit();
            return ProcessInstance.ExitCode == 0;
        }
    }
}