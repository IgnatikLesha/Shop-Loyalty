using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;


namespace DAL.Interfaces.Repository
{
    public interface IProductRepository
    {
        void Create(DalProduct entity);

        int CreateProduct(DalProduct entity);

        void Delete(DalProduct entity);

        void Update(DalProduct entity);

        IEnumerable<DalProduct> GetAll();

        DalProduct GetById(int key);

        DalProduct GetByPredicate(Expression<Func<DalProduct, bool>> predicates);

        IEnumerable<DalProduct> GetAllByPredicate(Expression<Func<DalProduct, bool>> predicate);
    }
}
