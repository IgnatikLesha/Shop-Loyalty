using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void Create(UserEntity entity);

        void Delete(UserEntity entity);

        void Edit(UserEntity entity);

        IEnumerable<UserEntity> GetAllEntities();

        UserEntity GetById(int id);

        UserEntity GetByPredicate(Expression<Func<UserEntity, bool>> predicate);

        IEnumerable<UserEntity> GetAllByPredicate(Expression<Func<UserEntity, bool>> predicate);



    }
}
