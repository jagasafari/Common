namespace Common.ProcessExecution.Abstraction
{
    using System;

    public interface IFinishingExecutorFactory
    {
        IExecutor Create(string program, string arguments, Func<string, bool> failurePredicate);
    }
}