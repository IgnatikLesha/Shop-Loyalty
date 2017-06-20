using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    public class RoleService : IRoleService
    {

        private readonly IUnitOfWork unit;
        private readonly IRoleRepository roleRepository;

        public RoleService(IUnitOfWork uow, IRoleRepository repository)
        {
            this.unit = uow;
            this.roleRepository = repository;
        }

        public void Create(RoleEntity entity)
        {
            roleRepository.Create(entity.GetDalEntity());
            unit.Commit();
        }

        public void Delete(RoleEntity entity)
        {
            roleRepository.Delete(entity.GetDalEntity());
            unit.Commit();
        }

        public void Edit(RoleEntity entity)
        {
            roleRepository.Update(entity.GetDalEntity());
            unit.Commit();
        }

        public IEnumerable<RoleEntity> GetAllByPredicate(Expression<Func<RoleEntity, bool>> predicate)
        {
            var visitor = new HelperExpressionVisitor<RoleEntity, DalRole>(Expression.Parameter(typeof(DalRole), predicate.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalRole, bool>>(visitor.Visit(predicate.Body), visitor.NewParameterExp);
            return roleRepository.GetAllByPredicate(exp2).Select(r => r.GetBllEntity());
        }

        public IEnumerable<RoleEntity> GetAllEntities()
        {
            return roleRepository.GetAll().Select(role => role.GetBllEntity());
        }

        public RoleEntity GetById(int id)
        {
            return roleRepository.GetById(id).GetBllEntity();
        }

        public RoleEntity GetByPredicate(Expression<Func<RoleEntity, bool>> predicate)
        {
            var visitor = new HelperExpressionVisitor<RoleEntity, DalRole>(Expression.Parameter(typeof(DalRole), predicate.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalRole, bool>>(visitor.Visit(predicate.Body), visitor.NewParameterExp);
            return roleRepository.GetByPredicate(exp2).GetBllEntity();
        }
    }
}
