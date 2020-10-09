using Microsoft.Extensions.DependencyInjection;

namespace StringsProcessor.Application.Iterator
{
    public static class DiExtensions
    {
        public static void AddElementsIteratorFactory(this IServiceCollection services)
        {
            services.AddSingleton<IElementsEnumerableFactory, DefaultElementsEnumerableFactory>();
        }
    }
}
