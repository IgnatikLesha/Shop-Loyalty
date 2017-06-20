using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Interfaces.DTO;
using DAL.Mappers;
using Helpers;
using ORM;

namespace DAL.Concrete
{
    public class SaleRepository : ISaleRepository
    {
        private LoyaltyModel context;

        public SaleRepository(LoyaltyModel uow)
        {
            if (uow == null)
            {
                throw new ArgumentNullException("entitiesContext");
            }
            this.context = uow;
        }

        public void Create(DalSale dalSale)
        {
            context.Sales.Add(dalSale.GetORMEntity());
            context.SaveChanges();
            //context.Set<ORM.Sale>().Add(dalSale.GetORMEntity());
        }


        public int CreateSale(DalSale dalSale)
        {
            context.Set<ORM.Sale>().Add(dalSale.GetORMEntity());
            return context.Set<ORM.Sale>().Max(t => t.Id) + 1;
        }

        public void Delete(DalSale dalSale)
        {
            context.Set<ORM.Sale>().Attach(dalSale.GetORMEntity());
            context.Set<ORM.Sale>().Remove(dalSale.GetORMEntity());
        }

        public void Update(DalSale dalSale)
        {
            context.Set<ORM.Sale>().AddOrUpdate(dalSale.GetORMEntity());
            context.SaveChanges();
        }

        public IEnumerable<DalSale> GetAll()
        {
            var Sales = context.Set<Sale>().ToList();
            return Sales.Select(Sale => Sale.GetDalEntity());
        }

        public DalSale GetById(int key)
        {
            var sale = context.Set<ORM.Sale>().FirstOrDefault(f => f.Id == key);
            return sale == null ? null : sale.GetDalEntity();
        }

        public DalSale GetByPredicate(Expression<Func<DalSale, bool>> f)
        {
            return GetAllByPredicate(f).FirstOrDefault();
        }

        public IEnumerable<DalSale> GetAllByPredicate(Expression<Func<DalSale, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<DalSale, ORM.Sale>(Expression.Parameter(typeof(ORM.Sale), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<ORM.Sale, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            var sales = context.Set<ORM.Sale>().Where(exp2).ToList();
            return sales.Select(sale => sale.GetDalEntity());
        }



    }
}
