using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repository;

namespace DAL.Interfaces.DTO
{
    public class DalSale: IEntity
    {
        public int Id { get; set; }

        public int BuyerId { get; set; }

        public int ShopId { get; set; }

        public DateTime SaleDate { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public bool IsConfirmed { get; set; }

        public bool Discount { get; set; }
    }
}
