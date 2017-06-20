using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface IProductService
    {
        void Create(ProductEntity entity);

        void Delete(ProductEntity entity);

        void Edit(ProductEntity entity);

        int CreateProduct(ProductEntity saleEntity);  //! ! ! 

        IEnumerable<ProductEntity> GetAllEntities();

        ProductEntity GetById(int id);

        ProductEntity GetByPredicate(Expression<Func<ProductEntity, bool>> predicate);

        IEnumerable<ProductEntity> GetAllByPredicate(Expression<Func<ProductEntity, bool>> predicate);
    }
}
