namespace ProcessExecution
{
    using System.Diagnostics;
    using Microsoft.Extensions.Logging;
    using Model;

    public class ProcessProviderServices
    {
        public Process OutputProcess(ProcessInstructions instructions)
            => new OutputProcessFactory(instructions).Create();

        public FinishingProcessExecutor FinishingProcessExecutor(
            ProcessInstructions instructions, ILogger logger) => 
            new FinishingProcessExecutor(OutputProcess(instructions), instructions, logger);

        public LivingProcessExecutor LivingProcessExecutor(
            ProcessInstructions instructions, ILogger logger)=>
            new LivingProcessExecutor(OutputProcess(instructions),instructions, logger);
    }
}