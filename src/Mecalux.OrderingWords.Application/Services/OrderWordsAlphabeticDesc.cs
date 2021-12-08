using Mecalux.OrderingWords.Application.Contracts.Service;
using Mecalux.OrderingWords.Applications.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mecalux.OrderingWords.Application.Services
{
    public class OrderWordsAlphabeticDesc : IOrderWordsOptions
    {
        public OrderOptions OrderOptions => OrderOptions.AlphabeticDesc;

        public ICollection<string> Execute(string textToOrder)
        {
            string[] textSplitedBySpace = textToOrder.Split(" ");
            Array.Sort(textSplitedBySpace, (a, b) => string.Compare(b, a));
            return textSplitedBySpace.ToList();
        }
    }
}
