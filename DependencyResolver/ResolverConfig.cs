using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Interfaces.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interfaces;
using DAL.Interfaces.Repository;
using Ninject;
using Ninject.Web.Common;
using ORM;

namespace DependencyResolver
{
    public static class ResolverConfig 
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<DbContext>().To<LoyaltyModel>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<ISaleRepository>().To<SaleRepository>();
            kernel.Bind<IBonusRepository>().To<BonusRepository>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<ICreditCardRepository>().To<CreditCardRepository>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ISaleService>().To<SaleService>();
            kernel.Bind<IBonusService>().To<BonusService>();
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<ICreditCardService>().To<CreditCardService>();
        }
    }
}
