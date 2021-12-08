using Mecalux.OrderingWords.Applications.Enums;
using System.Collections.Generic;

namespace Mecalux.OrderingWords.Application.Contracts.Service
{
    public interface IOrderWordsStrategy
    {
        public ICollection<string> Execute(string textToOrder, OrderOptions orderOptions);
    }
}
