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
    public class CreditCardRepository: ICreditCardRepository
    {
        private LoyaltyModel context;

        public CreditCardRepository(LoyaltyModel uow)
        {
            if (uow == null)
            {
                throw new ArgumentNullException("entitiesContext");
            }
            this.context = uow;
        }

        public void Create(DalCreditCard dalCreditCard)
        {
            context.CreditCards.Add(dalCreditCard.GetORMEntity());
            context.SaveChanges();
            //context.Set<ORM.CreditCard>().Add(dalCreditCard.GetORMEntity());
        }


        public int CreateCreditCard(DalCreditCard dalCreditCard)
        {
            context.Set<ORM.CreditCard>().Add(dalCreditCard.GetORMEntity());
            return context.Set<ORM.CreditCard>().Max(t => t.Id) + 1;
        }

        public void Delete(DalCreditCard dalCreditCard)
        {
            context.Set<ORM.CreditCard>().Attach(dalCreditCard.GetORMEntity());
            context.Set<ORM.CreditCard>().Remove(dalCreditCard.GetORMEntity());
        }

        public void Update(DalCreditCard dalCreditCard)
        {
            context.Set<ORM.CreditCard>().AddOrUpdate(dalCreditCard.GetORMEntity());
            context.SaveChanges();
        }


        public DalCreditCard GetById(int key)
        {
            var card = context.Set<ORM.CreditCard>().FirstOrDefault(f => f.Id == key);
            return card == null ? null : card.GetDalEntity();
        }

        public IEnumerable<DalCreditCard> GetAll()
        {
            return context.Set<CreditCard>().Select(card => card.GetDalEntity());
        }

        public DalCreditCard GetByPredicate(Expression<Func<DalCreditCard, bool>> f)
        {
            return GetAllByPredicate(f).FirstOrDefault();
        }

        public IEnumerable<DalCreditCard> GetAllByPredicate(Expression<Func<DalCreditCard, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<DalCreditCard, ORM.CreditCard>(Expression.Parameter(typeof(ORM.CreditCard), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<ORM.CreditCard, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            var bonuses = context.Set<ORM.CreditCard>().Where(exp2).ToList();
            return bonuses.Select(card => card.GetDalEntity());
        }
    }
}
