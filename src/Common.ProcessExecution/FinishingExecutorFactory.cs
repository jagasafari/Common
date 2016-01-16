namespace Common.ProcessExecution{
    using System;
    using Common.ProcessExecution.Abstraction;
    using Common.ProcessExecution.Model;

    public class FinishingExecutorFactory : IFinishingExecutorFactory
    {
        private IOutputProcessExecutor _outputProcessExecutor;
        private IProcessFactory _processFactory;
        public FinishingExecutorFactory(IOutputProcessExecutor outputProcessExecutor,
            IProcessFactory processFactory)
        {
            _outputProcessExecutor = outputProcessExecutor;
            _processFactory = processFactory;
        }
        
        public IExecutor Create(string program, string arguments, Func<string, bool> failurePredicate)
        {
            var instructions = new ProcessInstructions
            {
                Program = program,
                Arguments = arguments
            };
            _outputProcessExecutor.ProcessInstance = _processFactory.Create(instructions);
            return new FinishingProcessExecutor(_outputProcessExecutor, failurePredicate) { Instructions = instructions };
        }
    }
}