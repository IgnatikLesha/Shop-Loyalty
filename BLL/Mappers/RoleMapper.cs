using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using DAL.Interfaces.DTO;
using ORM;

namespace BLL.Mappers
{
    public static class RoleMapper
    {
        public static RoleEntity GetBllEntity(this DalRole dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new RoleEntity()
            {
                Id = dalEntity.Id,
                Name = dalEntity.Name
            };
        }

        public static DalRole GetDalEntity(this RoleEntity bllEntity)
        {
            return new DalRole()
            {
                Id = bllEntity.Id,
                Name = bllEntity.Name
            };
        }
    }
}
