using Mecalux.OrderingWords.Application.Contracts.Repository;
using Mecalux.OrderingWords.Applications.Enums;
using Mecalux.OrderingWords.Infrastructure.Helpers;
using System.Collections.Generic;

namespace Mecalux.OrderingWords.Infrastructure.Repository
{
    public class OrderOptionsRepository : IOrderOptionsRepository
    {
        public ICollection<KeyValuePair<string, int>> GetOrderOptions()
        {
            return EnumHelper.GetEnumList<OrderOptions>();
        }
    }
}
