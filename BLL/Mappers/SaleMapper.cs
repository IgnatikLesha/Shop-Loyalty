using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using DAL.Interfaces.DTO;

namespace BLL.Mappers
{
    public static class SaleMapper
    {
        public static SaleEntity GetBllEntity(this DalSale dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new SaleEntity()
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

        public static DalSale GetDalEntity(this SaleEntity bllEntity)
        {
            return new DalSale()
            {
                Id = bllEntity.Id,
                BuyerId = bllEntity.BuyerId,
                ShopId = bllEntity.ShopId,
                SaleDate = bllEntity.SaleDate,
                Name = bllEntity.Name,
                Description = bllEntity.Description,
                Price = bllEntity.Price,
                IsConfirmed = bllEntity.IsConfirmed,
                Discount = bllEntity.Discount
            };
        }
    }
}
