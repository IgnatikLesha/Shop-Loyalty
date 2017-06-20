using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces
{
    public interface ISaleRepository
    {
        void Create(DalSale entity);

        void Delete(DalSale entity);

        void Update(DalSale entity);

        int CreateSale(DalSale entity);

        IEnumerable<DalSale> GetAll();

        DalSale GetById(int key);

        DalSale GetByPredicate(Expression<Func<DalSale, bool>> predicate);

        IEnumerable<DalSale> GetAllByPredicate(Expression<Func<DalSale, bool>> predicate);


    }
}
