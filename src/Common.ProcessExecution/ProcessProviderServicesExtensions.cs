namespace Common.ProcessExecution
{
    using Microsoft.Extensions.DependencyInjection;
    using Common.ProcessExecution.Abstraction;
    public static class ProcessProviderServicesExtensions{
        public static IServiceCollection AddProceesProviderServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<IProcessFactory, ProcessFactory>()
                .AddTransient<IOutputProcessExecutor, OutputProcessExecutor>()
                .AddTransient<IFinishingExecutorFactory, FinishingExecutorFactory>()
                .AddTransient<ILongRunningExecutorFactory, LongRunningExecutorFactory>();
        }
    }
}