using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface ICreditCardService
    {
        void Create(CreditCardEntity entity);

        void Delete(CreditCardEntity entity);

        void Edit(CreditCardEntity entity);

        int CreateCreditCard(CreditCardEntity cardEntity);  //! ! ! 

        void AccrueAmount(CreditCardEntity card, double amount);

        void Withdraw(CreditCardEntity card, double amount);

        CreditCardEntity GetById(int id);

        CreditCardEntity GetByPredicate(Expression<Func<CreditCardEntity, bool>> predicate);


    }
}
