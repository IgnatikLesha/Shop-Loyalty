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
    public class BonusService: IBonusService
    {
        private readonly IUnitOfWork uow;

        private readonly IBonusRepository _bonusRepository;

        public BonusService(IUnitOfWork uow, IBonusRepository bonusRepository)
        {
            this.uow = uow;
            this._bonusRepository = bonusRepository;
        }

        public IEnumerable<BonusEntity> GetAllEntities()
        {
            var products = _bonusRepository.GetAll();
            return products.Select(prod => prod.GetBllEntity()).ToList();
        }

        public BonusEntity GetById(int id)
        {
            return _bonusRepository.GetById(id).GetBllEntity();
        }

        public BonusEntity GetByPredicate(Expression<Func<BonusEntity, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<BonusEntity, DalBonus>(Expression.Parameter(typeof(DalBonus), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalBonus, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            return _bonusRepository.GetByPredicate(exp2).GetBllEntity();
        }

        public IEnumerable<BonusEntity> GetAllByPredicate(Expression<Func<BonusEntity, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<BonusEntity, DalBonus>(Expression.Parameter(typeof(DalBonus), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalBonus, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            //ToList
            return _bonusRepository.GetAllByPredicate(exp2).Select(sale => sale.GetBllEntity()).ToList();
        }

        public void Create(BonusEntity entity)
        {
            _bonusRepository.Create(entity.GetDalEntity());
            uow.Commit();
        }

        public int CreateBonus(BonusEntity entity)
        {
            int id = _bonusRepository.CreateBonus(entity.GetDalEntity());
            uow.Commit();
            return id;
        }


        public void Edit(BonusEntity entity)
        {
            _bonusRepository.Update(entity.GetDalEntity());
            uow.Commit();
        }

        public void UpdateBonus(BonusEntity bonus, double price)
        {
            bonus.Points += (int)price/10;
            if (bonus.Points >= 100)
            {
                bonus.IsActive = true;
            }
            _bonusRepository.Update(bonus.GetDalEntity());
        }

        public void UseBonus(BonusEntity bonus)
        {
            bonus.Points -= 100;
            if (bonus.Points < 100)
            {
                bonus.IsActive = false;
            }
            _bonusRepository.Update(bonus.GetDalEntity());
        }


        public void Delete(BonusEntity entity)
        {
            _bonusRepository.Delete(entity.GetDalEntity());
            uow.Commit();
        }
    }
}
