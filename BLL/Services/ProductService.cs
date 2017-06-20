using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using Helpers;

namespace BLL.Services
{
    public class ProductService: IProductService
    {
        private readonly IUnitOfWork uow;

        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork uow, IProductRepository productRepository)
        {
            this.uow = uow;
            this._productRepository = productRepository;
        }

        public IEnumerable<ProductEntity> GetAllEntities()
        {
            var products = _productRepository.GetAll();
            return products.Select(prod => prod.GetBllEntity()).ToList();
        }

        public ProductEntity GetById(int id)
        {
            return _productRepository.GetById(id).GetBllEntity();
        }

        public ProductEntity GetByPredicate(Expression<Func<ProductEntity, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<ProductEntity, DalProduct>(Expression.Parameter(typeof(DalProduct), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalProduct, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            return _productRepository.GetByPredicate(exp2).GetBllEntity();
        }

        public IEnumerable<ProductEntity> GetAllByPredicate(Expression<Func<ProductEntity, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<ProductEntity, DalProduct>(Expression.Parameter(typeof(DalProduct), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalProduct, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            //ToList
            return _productRepository.GetAllByPredicate(exp2).Select(sale => sale.GetBllEntity()).ToList();
        }

        public void Create(ProductEntity entity)
        {
            _productRepository.Create(entity.GetDalEntity());
            uow.Commit();
        }

        public int CreateProduct(ProductEntity entity)
        {
            int id = _productRepository.CreateProduct(entity.GetDalEntity());
            uow.Commit();
            return id;
        }


        public void Edit(ProductEntity entity)
        {
            _productRepository.Update(entity.GetDalEntity());
            uow.Commit();
        }

        public void Delete(ProductEntity entity)
        {
            _productRepository.Delete(entity.GetDalEntity());
            uow.Commit();
        }
    }
}
