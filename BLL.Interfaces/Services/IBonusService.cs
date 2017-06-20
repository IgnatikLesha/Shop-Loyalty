using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface IBonusService
    {
        void Create(BonusEntity entity);

        void Delete(BonusEntity entity);

        void Edit(BonusEntity entity);

        int CreateBonus(BonusEntity saleEntity);  //! ! ! 

        IEnumerable<BonusEntity> GetAllEntities();

        void UseBonus(BonusEntity bonus);

        void UpdateBonus(BonusEntity bonus, double price);

        BonusEntity GetById(int id);

        BonusEntity GetByPredicate(Expression<Func<BonusEntity, bool>> predicate);

        IEnumerable<BonusEntity> GetAllByPredicate(Expression<Func<BonusEntity, bool>> predicate);
    }
}
