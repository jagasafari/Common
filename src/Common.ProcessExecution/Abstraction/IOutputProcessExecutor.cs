namespace Common.ProcessExecution.Abstraction
{
    using System.Diagnostics;

    public interface IOutputProcessExecutor : IExecutor
    {
        Process ProcessInstance { get; set; }
    }
}