namespace Common.ProcessExecution
{
    using System;
    using Common.ProcessExecution.Abstraction;
    using Common.ProcessExecution.Exceptions;
    using Common.ProcessExecution.Model;

    public class FinishingProcessExecutor : IFinishingProcessExecutor
    {
        private IOutputProcessExecutor _executor;
        private readonly Func<string, bool> _failurePredicate;
        private readonly IProcessFactory _processFactory;

        public FinishingProcessExecutor(IOutputProcessExecutor executor, IProcessFactory processFactory)
        {
            _executor = executor;
            _processFactory = processFactory;
        }
        
        public string Output => _executor.Output;

        public void Execute(string program, string arguments, Func<string, bool> failurePredicate)
        {
            var instruction = new ProcessInstructions
            {
                Program = program,
                Arguments = arguments
            };

            if (_executor.ProcessInstance == null)
                _executor.ProcessInstance = _processFactory.Create(instruction);

            _executor.Execute();

            if (!WaitForExit())
                throw new ProcessFailiureException(instruction, _executor.Output);

            if (failurePredicate(_executor.Output))
                throw new ProcessFailiureException(instruction, _executor.Output);
        }

        private bool WaitForExit()
        {
            _executor.ProcessInstance.WaitForExit();
            return _executor.ProcessInstance.ExitCode == 0;
        }
    }
}