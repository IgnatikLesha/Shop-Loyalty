using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Entities
{
    public class CreditCardEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Number { get; set; }

        public double Amount { get; set; }
    }
}
