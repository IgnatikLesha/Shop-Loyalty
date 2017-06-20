using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasksManager.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public int ShopId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}