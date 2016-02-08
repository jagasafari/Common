namespace Common.ProcessExecution.Abstraction
{
    using System;
    public interface ILongRunningExecutor : IDisposable, IExecutor
    {
        void Execute(string program, string arguments);
    }
}