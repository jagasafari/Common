namespace Common.ProcessExecution.Abstraction
{
    public interface IProcessExecutorProvider
    {
        T Create<T>();
    }
}
