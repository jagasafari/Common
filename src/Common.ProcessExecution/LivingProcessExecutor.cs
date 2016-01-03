using Common.ProcessExecution.Abstraction;

namespace Common.ProcessExecution
{
    public class LongRunningExecutor : ILongRunningExecutor
    {
        private OutputProcessExecutor _executor;

        public string Output
        {
            get
            {
                return _executor.Output;
            }
        }

        public LongRunningExecutor(OutputProcessExecutor executor)
        {
            _executor = executor;
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