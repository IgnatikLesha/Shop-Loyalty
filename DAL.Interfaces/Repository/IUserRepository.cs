using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        bool Create(DalUser entity);

        void Delete(DalUser entity);

        void Update(DalUser entity);

        IEnumerable<DalUser> GetAll();

        DalUser GetById(int key);

        DalUser GetByPredicate(Expression<Func<DalUser, bool>> predicate);

        IEnumerable<DalUser> GetAllByPredicate(Expression<Func<DalUser, bool>> predicate);


    }
}
