namespace Common.ProcessExecution.Abstraction
{
    using System;
    public interface IFinishingProcessExecutor : IExecutor
    {
        void Execute(string program, string arguments, Func<string, bool> failurePredicate);
        string Output { get; }
    }
}
