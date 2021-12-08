using Mecalux.OrderingWords.Applications.Enums;
using System.Collections.Generic;

namespace Mecalux.OrderingWords.Application.Contracts.Service
{
    public interface IOrderWordsOptions
    {
        public OrderOptions OrderOptions { get; }

        public ICollection<string> Execute(string textToOrder);

    }
}
