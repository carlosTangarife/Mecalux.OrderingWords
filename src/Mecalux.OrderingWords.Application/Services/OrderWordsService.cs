using Mecalux.OrderingWords.Application.Contracts.Service;
using Mecalux.OrderingWords.Applications.Enums;
using Mecalux.OrderingWords.Domain.Entities;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Mecalux.OrderingWords.Application.Services
{
    public class OrderWordsService : IOrderWordsService
    {
        public TextStatistics GetStatic(string textToAnalize)
        {
            var textSplitedBySpace = textToAnalize.Split(" ");

            return new TextStatistics
            {
                HyphensQuantity = CountWordsByHyphens(textToAnalize),
                WordQuantity = textSplitedBySpace.Length,
                SpacesQuantity = textSplitedBySpace.Length - 1
            };
        }

        public int CountWordsByHyphens(string textToAnalize)
        {
            string pattern = "[-]";
            Regex regex = new(pattern);
            MatchCollection matchedAuthors = regex.Matches(textToAnalize);
            return matchedAuthors.Count;
        }

        public ICollection<string> GetOrderedText(string textToOrder, OrderOptions orderOptions)
        {
            throw new System.NotImplementedException();
        }
    }
}
