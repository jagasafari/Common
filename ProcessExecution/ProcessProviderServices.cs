namespace ProcessExecution
{
    using System.Diagnostics;
    using Model;

    public class ProcessProviderServices
    {
        public Process OutputProcess(ProcessInstructions instructions)
            => new OutputProcessFactory(instructions).Create();

        public FinishingProcessExecutor FinishingProcessExecutor(
            ProcessInstructions instructions) => 
            new FinishingProcessExecutor(OutputProcess(instructions), instructions);

        public LivingProcessExecutor LivingProcessExecutor(ProcessInstructions instructions)=>
            new LivingProcessExecutor(OutputProcess(instructions),instructions);
    }
}