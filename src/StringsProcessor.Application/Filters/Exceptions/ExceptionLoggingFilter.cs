using System;
using System.Threading.Tasks;
using GreenPipes;

namespace StringsProcessor.Application.Filters.Exceptions
{
    internal class ExceptionLoggingFilter<TContext> : IFilter<TContext> where TContext : class, PipeContext
    {
        public async Task Send(TContext context, IPipe<TContext> next)
        {
            try
            {
                await next.Send(context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Probe(ProbeContext context) { }
    }
}
