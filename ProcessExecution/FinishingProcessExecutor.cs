namespace ProcessExecution
{
    using System;
    using System.Diagnostics;
    using Model;

    public class FinishingProcessExecutor : OutputProcessExecutor
    {
        public FinishingProcessExecutor(Process process, ProcessInstructions instructions)
            : base(process, instructions)
        {
        } 

        public void ExecuteAndWait(Func<string, bool> failurePredicate)
        {
            ExecuteAndWait();

            if(failurePredicate(Output))
                throw new ProcessFailiureException(Instructions, Output);
        }

        private void ExecuteAndWait()
        {
            Execute();
            ProcessInstance.WaitForExit();

            if(ProcessInstance.ExitCode != 0)
                throw new ProcessFailiureException(Instructions,
                    Output);
        }
    }
}