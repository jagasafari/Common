namespace Common.ProcessExecution
{
    using System;

    public class FinishingProcessExecutor : IExecutor
    {
        private OutputProcessExecutor _executor;
        private readonly Func<string, bool> _failurePredicate;

        public FinishingProcessExecutor(OutputProcessExecutor executor,
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

        public void Execute()
        {
            _executor.Execute();
            
            if (!WaitForExit())
                throw new ProcessFailiureException(_executor.Instructions,
                    _executor.Output);

            if (_failurePredicate(_executor.Output))
                throw new ProcessFailiureException(_executor.Instructions, _executor.Output);
        }
        
        private bool WaitForExit()
        {
            _executor.ProcessInstance.WaitForExit();
            return _executor.ProcessInstance.ExitCode == 0;
        }
    }
}