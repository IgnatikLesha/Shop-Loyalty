using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using DAL.Interfaces.DTO;

namespace BLL.Mappers
{
    public static class CreditCardMapper
    {
        public static CreditCardEntity GetBllEntity(this DalCreditCard dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new CreditCardEntity()
            {
                Id = dalEntity.Id,
                UserId = dalEntity.UserId,
                Number = dalEntity.Number,
                Amount = dalEntity.Amount
            };
        }

        public static DalCreditCard GetDalEntity(this CreditCardEntity bllEntity)
        {
            return new DalCreditCard()
            {
                Id = bllEntity.Id,
                UserId = bllEntity.UserId,
                Number = bllEntity.Number,
                Amount = bllEntity.Amount
            };
        }
    }
}
