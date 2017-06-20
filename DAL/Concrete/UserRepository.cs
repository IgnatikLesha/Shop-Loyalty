using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DAL.Interfaces;
using DAL.Interfaces.DTO;
using DAL.Mappers;
using Helpers;
using ORM;
using Task = System.Threading.Tasks.Task;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly LoyaltyModel context;

        public UserRepository(LoyaltyModel uow)
        {
            if (uow == null)
            {
                throw new ArgumentNullException("entitiesContext");
            }
            this.context = uow;
        }


        //private readonly DbContext context;

        //public UserRepository(DbContext uow)
        //{
        //    if (uow == null)
        //    {
        //        throw new ArgumentNullException("entitiesContext");
        //    }
        //    this.context = uow;
        //}

        public bool Create(DalUser user)
        {
            if (user.Id != 0) return false;
            var user1 = user.GetORMEntity();
            user1.Roles = new List<Role>() {context.Roles.Find(1) };
            context.Users.Add(user1);
            context.SaveChanges();
            return true;
        }

        public void Delete(DalUser e)
        {
            var user = context.Set<User>().Single(u => u.Id == e.Id);
            var tasksId = context.Set<ORM.Sale>().Where(t => t.BuyerId == user.Id || t.ShopId == user.Id).ToList();
            context.Set<ORM.Sale>().RemoveRange(tasksId);
            context.Set<ORM.User>().Remove(e.GetORMEntity());
            context.SaveChanges();
        }

        public void Update(DalUser e)
        {
            context.Set<ORM.User>().AddOrUpdate(e.GetORMEntity());
            context.SaveChanges();
        }
 
        public IEnumerable<DalUser> GetAll()
        {
            var x = context.Set<User>().Include(u => u.Roles).ToList();
            return x.Select(user => user.GetDalEntity());
        }

        public DalUser GetById(int key)
        {
            var ormUser = context.Set<User>().Include(u => u.Roles).FirstOrDefault(u => u.Id == key);
            return ormUser == null ? null : ormUser.GetDalEntity();
        }


        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> f)
        {
            return GetAllByPredicate(f).FirstOrDefault();
        }

        public IEnumerable<DalUser> GetAllByPredicate(Expression<Func<DalUser, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<DalUser, User>(Expression.Parameter(typeof(User), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<User, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            var x = context.Set<User>().Include(user => user.Roles).Where(exp2).ToList();
            return x.Select(user => user.GetDalEntity());
        }
    }
}
