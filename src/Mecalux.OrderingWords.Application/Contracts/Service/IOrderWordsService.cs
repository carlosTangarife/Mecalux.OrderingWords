using Mecalux.OrderingWords.Domain.Entities;

namespace Mecalux.OrderingWords.Application.Contracts.Service
{
    public interface IOrderWordsService
    {
        TextStatistics GetStatic(string textToAnalize);

        int CountWordsByHyphens(string textToAnalize);
    }
}
