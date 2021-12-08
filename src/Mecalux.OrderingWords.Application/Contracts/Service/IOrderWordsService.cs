using Mecalux.OrderingWords.Applications.Enums;
using Mecalux.OrderingWords.Domain.Entities;
using System.Collections.Generic;

namespace Mecalux.OrderingWords.Application.Contracts.Service
{
    public interface IOrderWordsService
    {
        TextStatistics GetStatic(string textToAnalize);

        int CountWordsByHyphens(string textToAnalize);

        ICollection<string> GetOrderedText(string textToOrder, OrderOptions orderOptions);
    }
}
