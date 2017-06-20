using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface ISaleService
    {
        void Create(SaleEntity entity);

        void Delete(SaleEntity entity);

        void Edit(SaleEntity entity);

        int CreateSale(SaleEntity saleEntity);  //! ! ! 

        IEnumerable<SaleEntity> GetAllEntities();

        SaleEntity GetById(int id);

        SaleEntity GetByPredicate(Expression<Func<SaleEntity, bool>> predicate);

        IEnumerable<SaleEntity> GetAllByPredicate(Expression<Func<SaleEntity, bool>> predicate);

        void ConfirmSale(SaleEntity entity);


    }
}
