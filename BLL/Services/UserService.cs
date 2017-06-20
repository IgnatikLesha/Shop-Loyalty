using System;
using System.Collections.Generic;
using System.IO;
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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unit;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.unit = unitOfWork;
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }
        public void Create(UserEntity user)
        {
            user.Roles = new List<RoleEntity> { roleRepository.GetById(1).GetBllEntity() };
            userRepository.Create(user.GetDalEntity());
            if (!(Directory.Exists(user.Name)))
            {
                try
                {
                    Directory.CreateDirectory(user.Name);
                }
                catch (Exception error)
                {

                }
            }
            unit.Commit();
        }

        public void Edit(UserEntity entity)
        {
            userRepository.Update(entity.GetDalEntity());
            unit.Commit();
        }

        public void Delete(UserEntity entity)
        {
            userRepository.Delete(entity.GetDalEntity());
            unit.Commit();
        }

        public IEnumerable<UserEntity> GetAllEntities()
        {
            return userRepository.GetAll().Select(u => u.GetBllEntity()).ToList();
        }
        public UserEntity GetById(int id)
        {
            return userRepository.GetById(id).GetBllEntity();
        }

        public IEnumerable<UserEntity> GetAllByPredicate(Expression<Func<UserEntity, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<UserEntity, DalUser>(Expression.Parameter(typeof(DalUser), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalUser, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            //ToList()
            return userRepository.GetAllByPredicate(exp2).Select(user => user.GetBllEntity()).ToList();
        }

        public UserEntity GetByPredicate(Expression<Func<UserEntity, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<UserEntity, DalUser>(Expression.Parameter(typeof(DalUser), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalUser, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            return userRepository.GetByPredicate(exp2).GetBllEntity();
        }
    }
}
