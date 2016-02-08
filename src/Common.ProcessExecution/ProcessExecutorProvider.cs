namespace Common.ProcessExecution
{
    using System;
    using Common.ProcessExecution.Abstraction;
    using Microsoft.Extensions.DependencyInjection;

    public class ProcessExecutorProvider : IProcessExecutorProvider
    {
        private readonly IServiceProvider _serviceProvider;
        public ProcessExecutorProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Create<T>() => _serviceProvider.GetService<T>();
    }
}
