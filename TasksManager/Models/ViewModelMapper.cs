using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Entities;
using BLL.Interfaces.Entities;

namespace TasksManager.Models
{
    public static class ViewModelMapper
    {
        public static SaleViewModel GetSaleViewModel(this SaleEntity bllEntity)
        {
            if (bllEntity == null)
                return null;
            return new SaleViewModel()
            {
                Id = bllEntity.Id,
                Name = bllEntity.Name,
                SaleDate  = bllEntity.SaleDate,
                Description = bllEntity.Description,
                BuyerId = bllEntity.BuyerId,
                ShopId = bllEntity.ShopId,
                IsConfirmed = bllEntity.IsConfirmed,
                Price = bllEntity.Price,
                Discount = bllEntity.Discount
            };
        }

        public static SalesViewModel GetSalesViewModel(this List<SaleEntity> listBllEntity)
        {
            SalesViewModel model = new SalesViewModel()
            {
                Sales = listBllEntity.Where(t => t.IsConfirmed != true).Select(t => t.GetSaleViewModel()).ToList(),


            };
            model.CountSales = model.Sales.Count;

            return model;
        }

        public static ProductViewModel GetProductViewModel(this ProductEntity BllEntity)
        {
            if (BllEntity == null)
                return null;
            return new ProductViewModel()
            {
                Id = BllEntity.Id,
                Description = BllEntity.Description,
                Name = BllEntity.Name,
                Price = BllEntity.Price,
                ShopId = BllEntity.ShopId
            };
        }

        public static UserViewModel GetUserViewModel(this UserEntity bllEntity)
        {
            if (bllEntity == null)
                return null;
            return new UserViewModel()
            {
                Id = bllEntity.Id,
                Name = bllEntity.Name,
                Email = bllEntity.Email
            };
        }


    }
}