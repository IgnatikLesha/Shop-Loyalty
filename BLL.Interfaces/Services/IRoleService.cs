using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IRoleService
    {
        void Create(RoleEntity entity);

        void Delete(RoleEntity entity);

        void Edit(RoleEntity entity);

        IEnumerable<RoleEntity> GetAllEntities();

        RoleEntity GetById(int id);

        RoleEntity GetByPredicate(Expression<Func<RoleEntity, bool>> predicate);

        IEnumerable<RoleEntity> GetAllByPredicate(Expression<Func<RoleEntity, bool>> predicate);




    }
}
