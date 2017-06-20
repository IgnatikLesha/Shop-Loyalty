using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using DAL.Interfaces.DTO;

namespace BLL.Mappers
{
    public static class BonusMapper
    {
        public static BonusEntity GetBllEntity(this DalBonus dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new BonusEntity()
            {
                Id = dalEntity.Id,
                UserName = dalEntity.UserName,
                Points = dalEntity.Points,
                IsActive = dalEntity.IsActive
            };
        }

        public static DalBonus GetDalEntity(this BonusEntity bllEntity)
        {
            return new DalBonus()
            {
                Id = bllEntity.Id,
                UserName = bllEntity.UserName,
                Points = bllEntity.Points,
                IsActive = bllEntity.IsActive
            };
        }
    }
}
