namespace Common.ProcessExecution{
    public interface IExecutor{
        void Execute();
        string Output {get;}
    }
}