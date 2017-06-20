using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using Helpers;

namespace BLL.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly IUnitOfWork uow;

        private readonly ICreditCardRepository _creditCardRepository;

        public CreditCardService(IUnitOfWork uow, ICreditCardRepository creditCardRepository)
        {
            this.uow = uow;
            this._creditCardRepository = creditCardRepository;
        }

        public IEnumerable<CreditCardEntity> GetAllEntities()
        {
            var cards = _creditCardRepository.GetAll();
            return cards.Select(prod => prod.GetBllEntity()).ToList();
        }

        public CreditCardEntity GetById(int id)
        {
            return _creditCardRepository.GetById(id).GetBllEntity();
        }

        public CreditCardEntity GetByPredicate(Expression<Func<CreditCardEntity, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<CreditCardEntity, DalCreditCard>(Expression.Parameter(typeof(DalCreditCard), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalCreditCard, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            return _creditCardRepository.GetByPredicate(exp2).GetBllEntity();
        }

        public IEnumerable<CreditCardEntity> GetAllByPredicate(Expression<Func<CreditCardEntity, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<CreditCardEntity, DalCreditCard>(Expression.Parameter(typeof(DalCreditCard), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalCreditCard, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            //ToList
            return _creditCardRepository.GetAllByPredicate(exp2).Select(sale => sale.GetBllEntity()).ToList();
        }

        public void Create(CreditCardEntity entity)
        {
            _creditCardRepository.Create(entity.GetDalEntity());
            uow.Commit();
        }

        public int CreateCreditCard(CreditCardEntity entity)
        {
            int id = _creditCardRepository.CreateCreditCard(entity.GetDalEntity());
            uow.Commit();
            return id;
        }


        public void Edit(CreditCardEntity entity)
        {
            _creditCardRepository.Update(entity.GetDalEntity());
            uow.Commit();
        }

        public void Delete(CreditCardEntity entity)
        {
            _creditCardRepository.Delete(entity.GetDalEntity());
            uow.Commit();
        }

        public void AccrueAmount(CreditCardEntity card, double amount)
        {
            card.Amount += amount;
            _creditCardRepository.Update(card.GetDalEntity());
        }

        public void Withdraw(CreditCardEntity card, double amount)
        {
            card.Amount -= amount;
            _creditCardRepository.Update(card.GetDalEntity());
        }
    }
}
