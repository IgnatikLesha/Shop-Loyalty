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
    public class BonusRepository: IBonusRepository
    {
        private LoyaltyModel context;

        public BonusRepository(LoyaltyModel uow)
        {
            if (uow == null)
            {
                throw new ArgumentNullException("entitiesContext");
            }
            this.context = uow;
        }

        public void Create(DalBonus dalBonus)
        {
            context.Bonus.Add(dalBonus.GetORMEntity());
            context.SaveChanges();
            //context.Set<ORM.Sale>().Add(dalTask.GetORMEntity());
        }


        public int CreateBonus(DalBonus dalBonus)
        {
            context.Set<ORM.Bonus>().Add(dalBonus.GetORMEntity());
            return context.Set<ORM.Bonus>().Max(t => t.Id) + 1;
        }

        public void Delete(DalBonus dalBonus)
        {
            context.Set<ORM.Bonus>().Attach(dalBonus.GetORMEntity());
            context.Set<ORM.Bonus>().Remove(dalBonus.GetORMEntity());
        }

        public void Update(DalBonus dalBonus)
        {
            context.Set<ORM.Bonus>().AddOrUpdate(dalBonus.GetORMEntity());
            context.SaveChanges();
        }

        public IEnumerable<DalBonus> GetAll()
        {
            var bonuses = context.Set<Bonus>().ToList();
            return bonuses.Select(bon => bon.GetDalEntity());
        }

        public DalBonus GetById(int key)
        {
            var bon = context.Set<ORM.Bonus>().FirstOrDefault(f => f.Id == key);
            return bon == null ? null : bon.GetDalEntity();
        }

        public DalBonus GetByPredicate(Expression<Func<DalBonus, bool>> f)
        {
            return GetAllByPredicate(f).FirstOrDefault();
        }

        public IEnumerable<DalBonus> GetAllByPredicate(Expression<Func<DalBonus, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<DalBonus, ORM.Bonus>(Expression.Parameter(typeof(ORM.Bonus), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<ORM.Bonus, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            var bonuses = context.Set<ORM.Bonus>().Where(exp2).ToList();
            return bonuses.Select(prod => prod.GetDalEntity());
        }
    }
}
