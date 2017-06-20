using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Mappers
{
    public static class BonusMapper
    {
        public static ORM.Bonus GetORMEntity(this DalBonus dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new ORM.Bonus()
            {
                Id = dalEntity.Id,
                UserName  = dalEntity.UserName,
                Points = dalEntity.Points,
                IsActive = dalEntity.IsActive
            };
        }

        public static DalBonus GetDalEntity(this ORM.Bonus ormEntity)
        {
            return new DalBonus()
            {
                Id = ormEntity.Id,
                UserName = ormEntity.UserName,
                Points = ormEntity.Points,
                IsActive = ormEntity.IsActive
            };
        }
    }
}
