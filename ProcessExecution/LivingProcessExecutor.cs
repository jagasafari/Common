namespace ProcessExecution
{
    using System;
    using System.Diagnostics;
    using Model;

    public class LivingProcessExecutor : OutputProcessExecutor, IDisposable
    {
        public LivingProcessExecutor(Process process, ProcessInstructions instructions)
            :base(process, instructions)
        {
        }

        public void Dispose() => ProcessInstance.Dispose();

    }
}