namespace Common.ProcessExecution
{
    using System;
    using System.Diagnostics;
    using Common.Core;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Model;

    public class ProcessProviderServices
    {
        private readonly IServiceProvider _serviceProvider;

        public ProcessProviderServices()
        {
            _serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddTransient<IOutputProcessFactory, OutputProcessFactory>()
                .AddTransient<OutputProcessExecutor>()
                .BuildServiceProvider();

            _serviceProvider.GetService<ILoggerFactory>().AddConsole().MinimumLevel = LogLevel.Information;
        }

        public OutputProcessExecutor OutputProcessExecutor(ProcessInstructions instructions)
        {
            var outputProcessExecutor = _serviceProvider.GetService<OutputProcessExecutor>();

            outputProcessExecutor.ProcessInstance = Check.NotNull<Process>(_serviceProvider.GetService<IOutputProcessFactory>().Create(instructions));
            return outputProcessExecutor;
        }

        public ProcessInstructions ProcessInstructions(string program, string arguments) =>
            new ProcessInstructions
            {
                Program = program,
                Arguments = arguments
            };


        public IExecutor FinishingExecutor(string program, string arguments, Func<string, bool> failurePredicate)
        {
            var instructions = ProcessInstructions(program, arguments);
            return new FinishingProcessExecutor(OutputProcessExecutor(instructions), failurePredicate) { Instructions = instructions };
        }

        public LongRunningExecutor LivingExecutor(string program, string arguments)
        {
            var instructions = ProcessInstructions(program, arguments);
            return new LongRunningExecutor(OutputProcessExecutor(instructions));
        }
    }
}