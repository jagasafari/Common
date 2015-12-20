namespace Common.ProcessExecution
{
    using System;
    using System.Diagnostics;
    using Microsoft.Extensions.Logging;
    using Model;

    public class LivingProcessExecutor : IExecutor, IDisposable
    {
        private OutputProcessExecutor _executor;

        public string Output
        {
            get
            {
                return _executor.Output;
            }
        }

        public LivingProcessExecutor(Process process, 
                ProcessInstructions instructions, ILogger logger)
        {
            _executor = new OutputProcessExecutor(process, instructions, logger);
        }
        
        public void Execute()
        {
            _executor.Execute();
        }
        
        public void Dispose()
        { 
            _executor.ProcessInstance.Kill();
            _executor.ProcessInstance.Dispose();
        }
    }
}