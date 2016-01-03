namespace Common.ProcessExecution.Abstraction
{
    using System.Diagnostics;
    using Common.ProcessExecution.Model;
    public interface IProcessFactory
    {
        Process Create(ProcessInstructions instructions);
    }
}