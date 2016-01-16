namespace Common.ProcessExecution{

    using Common.ProcessExecution.Abstraction;
    using Common.ProcessExecution.Model;

    public class LongRunningExecutorFactory : ILongRunningExecutorFactory
    {
        private IOutputProcessExecutor _outputProcessExecutor;
        private IProcessFactory _processFactory;
        
        public LongRunningExecutorFactory(IOutputProcessExecutor outputProcessExecutor,
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
            //make it lazy
            return new LongRunningExecutor(instructions, _processFactory, _outputProcessExecutor);
        }
    }
}