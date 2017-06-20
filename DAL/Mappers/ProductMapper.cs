using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Mappers
{
    public static class ProductMapper
    {
        public static ORM.Product GetORMEntity(this DalProduct dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new ORM.Product()
            {
                Id = dalEntity.Id,
                ShopId = dalEntity.ShopId,
                Name = dalEntity.Name,
                Description = dalEntity.Description,
                Price = dalEntity.Price
            };
        }

        public static DalProduct GetDalEntity(this ORM.Product ormEntity)
        {
            return new DalProduct()
            {
                Id = ormEntity.Id,
                ShopId = ormEntity.ShopId,
                Name = ormEntity.Name,
                Description = ormEntity.Description,
                Price = ormEntity.Price
            };
        }
    }
}
