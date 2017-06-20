using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Repository
{
    public interface ICreditCardRepository
    {
        void Create(DalCreditCard entity);

        int CreateCreditCard(DalCreditCard entity);

        void Delete(DalCreditCard entity);

        void Update(DalCreditCard entity);

        IEnumerable<DalCreditCard> GetAll();
       

        DalCreditCard GetById(int key);

        DalCreditCard GetByPredicate(Expression<Func<DalCreditCard, bool>> predicates);

        IEnumerable<DalCreditCard> GetAllByPredicate(Expression<Func<DalCreditCard, bool>> predicate);
    }
}
