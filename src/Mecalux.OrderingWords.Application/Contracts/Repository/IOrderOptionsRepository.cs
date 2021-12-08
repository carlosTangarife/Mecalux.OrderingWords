using System.Collections.Generic;

namespace Mecalux.OrderingWords.Application.Contracts.Repository
{
    public interface IOrderOptionsRepository
    {
        ICollection<KeyValuePair<string, int>> GetOrderOptions();
    }
}
