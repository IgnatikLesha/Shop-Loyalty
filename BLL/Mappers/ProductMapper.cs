using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces.Entities;
using DAL.Interfaces.DTO;

namespace BLL.Mappers
{
    public static class ProductMapper
    {
        public static ProductEntity GetBllEntity(this DalProduct dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new ProductEntity()
            {
                Id = dalEntity.Id,
                ShopId = dalEntity.ShopId,
                Name = dalEntity.Name,
                Description = dalEntity.Description,
                Price = dalEntity.Price
            };
        }

        public static DalProduct GetDalEntity(this ProductEntity bllEntity)
        {
            return new DalProduct()
            {
                Id = bllEntity.Id,
                ShopId = bllEntity.ShopId,
                Name = bllEntity.Name,
                Description = bllEntity.Description,
                Price = bllEntity.Price
            };
        }
    }
}
