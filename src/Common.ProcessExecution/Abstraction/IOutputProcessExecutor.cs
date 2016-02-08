namespace Common.ProcessExecution.Abstraction
{
    using System.Diagnostics;

    public interface IOutputProcessExecutor
    {
        void Execute();
        Process ProcessInstance { get; set; }
        string Output { get; }
    }
}