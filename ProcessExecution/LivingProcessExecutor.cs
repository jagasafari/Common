namespace Common.ProcessExecution
{
    using System;

    public class LivingProcessExecutor : OutputProcessExecutor, IDisposable
    {
        public LivingProcessExecutor(OutputProcessFactory processFactory)
            :base(processFactory)
        {
        }

        public void Dispose() => ProcessInstance.Kill();

    }
}