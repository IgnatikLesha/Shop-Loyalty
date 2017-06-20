using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class UserMapper
    {
        public static User GetORMEntity(this DalUser dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new User()
            {
                Id = dalEntity.Id,
                Name = dalEntity.Name,
                Password = dalEntity.Password,
                Email = dalEntity.Email,
                Roles =
                    dalEntity.Roles != null
                        ? dalEntity.Roles.Select(r => r.GetORMEntity()).ToList()
                        : null
            };
        }

        public static DalUser GetDalEntity(this User ormEntity)
        {
            return new DalUser()
            {
                Id = ormEntity.Id,
                Name = ormEntity.Name,
                Email = ormEntity.Email,
                Password = ormEntity.Password,
                Roles = ormEntity.Roles.Select(r => r.GetDalEntity()).ToList()
            };

        }
    }
}
