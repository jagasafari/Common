namespace Common.ProcessExecution.Abstraction{
    public interface ILongRunningExecutorFactory
    {
        ILongRunningExecutor Create(string program, string arguments);
    }
}