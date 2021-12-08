using Mecalux.OrderingWords.Application.Contracts.Service;
using Mecalux.OrderingWords.Applications.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mecalux.OrderingWords.Application.Services
{
    public class OrderWordsStrategy : IOrderWordsStrategy
    {
        private readonly IEnumerable<IOrderWordsOptions> _orderOptions;

        public OrderWordsStrategy(IEnumerable<IOrderWordsOptions> orderOptions)
        {
            _orderOptions = orderOptions;
        }

        public ICollection<string> Execute(string textToOrder, OrderOptions orderOptions)
        {
            return _orderOptions.FirstOrDefault(x => x.OrderOptions == orderOptions)?.Execute(textToOrder) ?? throw new ArgumentNullException(nameof(orderOptions));
        }
    }
}
