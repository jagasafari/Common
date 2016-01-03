namespace Common.ProcessExecution.Abstraction
{
    public interface IExecutor{
        void Execute();
        string Output {get;}
    }
}