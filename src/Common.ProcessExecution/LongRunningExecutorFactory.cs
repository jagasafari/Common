namespace Common.ProcessExecution{

    using Common.ProcessExecution.Abstraction;
    using Common.ProcessExecution.Model;

    public class LongRunningExecutorFactory : ILongRunningExecutorFactory
    {
        private OutputProcessExecutor _outputProcessExecutor;
        private IProcessFactory _processFactory;
        
        public LongRunningExecutorFactory(OutputProcessExecutor outputProcessExecutor,
            IProcessFactory processFactory)
        {
            _outputProcessExecutor = outputProcessExecutor;
            _processFactory = processFactory;
        }
        

        public ILongRunningExecutor Create(string program, string arguments)
        {
            var instructions = new ProcessInstructions
            {
                Program = program,
                Arguments = arguments
            };
            
            _outputProcessExecutor.ProcessInstance = _processFactory.Create(instructions);
            return new LongRunningExecutor(_outputProcessExecutor);
        }
    }
}