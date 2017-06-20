using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class Product
    {
        public int Id { get; set; }

        public int ShopId { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(80)]
        public string Description { get; set; }

        public double Price { get; set; }
    }
}
