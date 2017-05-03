using Layer.Domain.Entity;
using System.Collections.Generic;

namespace Layer.Domain.Repositories
{
    public interface IShopStatusHistoryRepository: IBaseRepository<ShopStatusHistory>
    {
        List<ShopStatusHistory> GetAllByShopId(long shopId);

    }
}
