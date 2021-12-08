using Mecalux.OrderingWords.Application.Contracts.Service;
using Mecalux.OrderingWords.Applications.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mecalux.OrderingWords.Application.Services
{
    public class OrderWordsAlphabeticAsc : IOrderWordsOptions
    {
        public OrderOptions OrderOptions => OrderOptions.AlphabeticAsc;

        public ICollection<string> Execute(string textToOrder)
        {
            string[] textSplitedBySpace = textToOrder.Split(" ");
            Array.Sort(textSplitedBySpace, (a, b) => string.Compare(a, b));
            return textSplitedBySpace.ToList();
        }
    }
}
