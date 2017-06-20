using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;
using DAL.Interfaces.DTO;
using Helpers;

namespace BLL.Services
{
    public class SaleService : ISaleService
    {
        private readonly IUnitOfWork uow;

        private readonly ISaleRepository _saleRepository;

        public SaleService(IUnitOfWork uow, ISaleRepository _saleRepository)
        {
            this.uow = uow;
            this._saleRepository = _saleRepository;
        }

        public IEnumerable<SaleEntity> GetAllEntities()
        {
            var tasks = _saleRepository.GetAll();
            return tasks.Select(sale => sale.GetBllEntity()).ToList();
        }

        public SaleEntity GetById(int id)
        {
            return _saleRepository.GetById(id).GetBllEntity();
        }

        public SaleEntity GetByPredicate(Expression<Func<SaleEntity, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<SaleEntity, DalSale>(Expression.Parameter(typeof(DalSale), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalSale, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            return _saleRepository.GetByPredicate(exp2).GetBllEntity();
        }

        public IEnumerable<SaleEntity> GetAllByPredicate(Expression<Func<SaleEntity, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<SaleEntity, DalSale>(Expression.Parameter(typeof(DalSale), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalSale, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            //ToList
            return _saleRepository.GetAllByPredicate(exp2).Select(sale => sale.GetBllEntity()).ToList();
        }

        public void Create(SaleEntity entity)
        {
            entity.SaleDate = DateTime.Now;
            _saleRepository.Create(entity.GetDalEntity());
            uow.Commit();
        }

        public int CreateSale(SaleEntity entity)
        {
            entity.SaleDate = DateTime.Now;
            int id = _saleRepository.CreateSale(entity.GetDalEntity());
            uow.Commit();
            return id;
        }


        public void Edit(SaleEntity entity)
        {
            _saleRepository.Update(entity.GetDalEntity());
            uow.Commit();
        }

        public void Delete(SaleEntity entity)
        {
            _saleRepository.Delete(entity.GetDalEntity());
            uow.Commit();
        }

        public void ConfirmSale(SaleEntity entity)
        {
            entity.IsConfirmed = true;
            entity.SaleDate = DateTime.Now;
            _saleRepository.Update(entity.GetDalEntity());
            uow.Commit();
        }
    }
}
