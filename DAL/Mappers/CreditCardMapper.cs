using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Mappers
{
    public static class CreditCardMapper
    {
        public static ORM.CreditCard GetORMEntity(this DalCreditCard dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new ORM.CreditCard()
            {
                Id = dalEntity.Id,
                UserId = dalEntity.UserId,
                Number = dalEntity.Number,
                Amount = dalEntity.Amount
            };
        }

        public static DalCreditCard GetDalEntity(this ORM.CreditCard ormEntity)
        {
            return new DalCreditCard()
            {
                Id = ormEntity.Id,
                UserId = ormEntity.UserId,
                Number = ormEntity.Number,
                Amount = ormEntity.Amount
            };
        }
    }
}
