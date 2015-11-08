namespace Common.ProcessExecution
{
    using System;

    public class FinishingProcessExecutor : OutputProcessExecutor
    {
        public FinishingProcessExecutor(
            OutputProcessFactory processFactory)
            : base(processFactory)
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