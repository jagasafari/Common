namespace Common.ProcessExecution
{
    using System;
    using Common.ProcessExecution.Abstraction;
    using Common.ProcessExecution.Exceptions;
    using Common.ProcessExecution.Model;

    public class FinishingProcessExecutor : IExecutor
    {
        private IOutputProcessExecutor _executor;
        private readonly Func<string, bool> _failurePredicate;

        public FinishingProcessExecutor(IOutputProcessExecutor executor,
            Func<string, bool> failurePredicate)
        {
            _executor = executor;
            _failurePredicate = failurePredicate;
        }

        public string Output
        {
            get
            {
                return _executor.Output;
            }
        }
        
        public ProcessInstructions Instructions { get; set; }
        
        public void Execute()
        {
            _executor.Execute();
            
            if (!WaitForExit())
                throw new ProcessFailiureException(Instructions,
                    _executor.Output);

            if (_failurePredicate(_executor.Output))
                throw new ProcessFailiureException(Instructions, _executor.Output);
        }
        
        private bool WaitForExit()
        {
            _executor.ProcessInstance.WaitForExit();
            return _executor.ProcessInstance.ExitCode == 0;
        }
    }
}