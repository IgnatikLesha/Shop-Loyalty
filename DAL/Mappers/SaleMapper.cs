using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Interfaces.DTO;
using ORM;
using Task = System.Threading.Tasks.Task;

namespace DAL.Mappers
{
    public static class SaleMapper
    {
        public static ORM.Sale GetORMEntity(this DalSale dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new ORM.Sale()
            {
                Id = dalEntity.Id,
                BuyerId = dalEntity.BuyerId,
                ShopId = dalEntity.ShopId,
                SaleDate = dalEntity.SaleDate,
                Name = dalEntity.Name,
                Description = dalEntity.Description,
                Price = dalEntity.Price,
                IsConfirmed = dalEntity.IsConfirmed,
                Discount = dalEntity.Discount
            };
        }

        public static DalSale GetDalEntity(this ORM.Sale ormEntity)
        {
            return new DalSale()
            {
                Id = ormEntity.Id,
                BuyerId = ormEntity.BuyerId,
                ShopId = ormEntity.ShopId,
                SaleDate = ormEntity.SaleDate,
                Name = ormEntity.Name,
                Description = ormEntity.Description,
                Price = ormEntity.Price,
                IsConfirmed = ormEntity.IsConfirmed,
                Discount = ormEntity.Discount
            };
        }
    }
}
