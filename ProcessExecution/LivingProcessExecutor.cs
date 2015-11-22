namespace ProcessExecution
{
    using System;
    using System.Diagnostics;
    using Microsoft.Extensions.Logging;
    using Model;

    public class LivingProcessExecutor : OutputProcessExecutor, IDisposable
    {
        public LivingProcessExecutor(Process process, 
                ProcessInstructions instructions, ILogger logger)
            :base(process, instructions, logger)
        {
        }

        public void Dispose() => ProcessInstance.Dispose();

    }
}