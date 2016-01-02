using System.Diagnostics;
using Common.ProcessExecution.Model;

namespace Common.ProcessExecution
{
    public interface IOutputProcessFactory
    {
        Process Create(ProcessInstructions instructions);
    }
}