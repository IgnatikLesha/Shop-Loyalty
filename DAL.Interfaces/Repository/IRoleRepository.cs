using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces
{
    public interface IRoleRepository
    {
        void Create(DalRole entity);

        void Delete(DalRole entity);

        void Update(DalRole entity);

        IEnumerable<DalRole> GetAll();

        DalRole GetById(int key);

        DalRole GetByPredicate(Expression<Func<DalRole, bool>> predicates);

        IEnumerable<DalRole> GetAllByPredicate(Expression<Func<DalRole, bool>> predicate);
        

    }
}
