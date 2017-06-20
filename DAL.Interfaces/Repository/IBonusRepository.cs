using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Repository
{
    public interface IBonusRepository
    {
        void Create(DalBonus entity);

        int CreateBonus(DalBonus entity);

        void Delete(DalBonus entity);

        void Update(DalBonus entity);

        IEnumerable<DalBonus> GetAll();

        DalBonus GetById(int key);


        DalBonus GetByPredicate(Expression<Func<DalBonus, bool>> predicates);

        IEnumerable<DalBonus> GetAllByPredicate(Expression<Func<DalBonus, bool>> predicate);
    }
}
