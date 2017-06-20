using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using Helpers;
using ORM;

namespace DAL.Concrete
{
    public class ProductRepository: IProductRepository
    {
        private LoyaltyModel context;

        public ProductRepository(LoyaltyModel uow)
        {
            if (uow == null)
            {
                throw new ArgumentNullException("entitiesContext");
            }
            this.context = uow;
        }

        public void Create(DalProduct dalProduct)
        {
            context.Products.Add(dalProduct.GetORMEntity());
            context.SaveChanges();
            //context.Set<ORM.Sale>().Add(dalTask.GetORMEntity());
        }


        public int CreateProduct(DalProduct dalProduct)
        {
            context.Set<ORM.Product>().Add(dalProduct.GetORMEntity());
            return context.Set<ORM.Product>().Max(t => t.Id) + 1;
        }

        public void Delete(DalProduct dalProduct)
        {
            context.Set<ORM.Product>().Attach(dalProduct.GetORMEntity());
            context.Set<ORM.Product>().Remove(dalProduct.GetORMEntity());
        }

        public void Update(DalProduct dalProduct)
        {
            context.Set<ORM.Product>().AddOrUpdate(dalProduct.GetORMEntity());
            context.SaveChanges();
        }

        public IEnumerable<DalProduct> GetAll()
        {
            var products = context.Set<Product>().ToList();
            return products.Select(prod => prod.GetDalEntity());
        }

        public DalProduct GetById(int key)
        {
            var sale = context.Set<ORM.Product>().FirstOrDefault(f => f.Id == key);
            return sale == null ? null : sale.GetDalEntity();
        }

        public DalProduct GetByPredicate(Expression<Func<DalProduct, bool>> f)
        {
            return GetAllByPredicate(f).FirstOrDefault();
        }

        public IEnumerable<DalProduct> GetAllByPredicate(Expression<Func<DalProduct, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<DalProduct, ORM.Product>(Expression.Parameter(typeof(ORM.Product), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<ORM.Product, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            var products = context.Set<ORM.Product>().Where(exp2).ToList();
            return products.Select(prod => prod.GetDalEntity());
        }
    }
}
