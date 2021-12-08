using Mecalux.OrderingWords.Application.Contracts.Service;
using Mecalux.OrderingWords.Applications.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mecalux.OrderingWords.Application.Services
{
    public class OrderWordsLengthAsc : IOrderWordsOptions
    {
        public OrderOptions OrderOptions => OrderOptions.LengthAsc;

        public ICollection<string> Execute(string textToOrder)
        {
            string[] textSplitedBySpace = textToOrder.Split(" ");
            Array.Sort(textSplitedBySpace, (a, b) => a.Length - b.Length);
            return textSplitedBySpace.ToList();
        }
    }
}
