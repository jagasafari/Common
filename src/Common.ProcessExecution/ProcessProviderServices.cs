namespace Common.ProcessExecution
{
    using System;
    using System.Diagnostics;
    using Microsoft.Extensions.Logging;
    using Model;

    public class ProcessProviderServices
    {
        public Process OutputProcess(ProcessInstructions instructions)
            => new OutputProcessFactory(instructions).Create();
        
        public OutputProcessExecutor OutputProcessExecutor(ProcessInstructions instructions, ILogger logger)=>
          new OutputProcessExecutor(OutputProcess(instructions), instructions, logger);

        public FinishingProcessExecutor FinishingProcessExecutor(ProcessInstructions instructions, ILogger logger, Func<string, bool> failurePredicate) => 
            new FinishingProcessExecutor(OutputProcessExecutor(instructions, logger), failurePredicate);

        public LivingProcessExecutor LivingProcessExecutor(ProcessInstructions instructions, ILogger logger)=>
            new LivingProcessExecutor(OutputProcess(instructions), instructions, logger);
            
        public FinishingProcessExecutor FinishingExecutor(string program, string arguments, ILogger logger, Func<string, bool> failurePredicate)
        {
            var instructions = new ProcessInstructions
            {
                Program = program,
                Arguments = arguments
            };
            return FinishingProcessExecutor(instructions, logger, failurePredicate);
        }
    }
}