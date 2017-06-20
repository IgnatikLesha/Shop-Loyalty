using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BLL.Entities;
using BLL.Interfaces;

namespace TasksManager.Providers
{
    public class CustomRoleProvider : RoleProvider
    {

        private readonly IRoleService roleService;
        private readonly IUserService userService;

        public CustomRoleProvider(IRoleService roleService, IUserService userService)
        {
            this.roleService = roleService;
            this.userService = userService;
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            roleService.Create(new RoleEntity() { Name = roleName });
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            var user = userService.GetByPredicate(u => u.Name == username);
            if (user == null)
                return roles;
            var role = user.Roles;
            if (role != null)
                roles = new string[] { role.Select(r => r.Name).ToString() };
            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var user = userService.GetByPredicate(u => u.Name == username);
            if (user == null)
                return false;
            var role = user.Roles.Select(r => r.Name == roleName);
            if (role != null)
                return true;

            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}