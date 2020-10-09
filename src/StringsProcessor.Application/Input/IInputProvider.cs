using System.Threading.Tasks;

namespace StringsProcessor.Application.Input
{
    public interface IInputProvider
    {
        Task<string> GetAsync();
    }
}
