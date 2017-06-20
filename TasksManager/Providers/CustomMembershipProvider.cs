using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Web.Security;
using BLL.Entities;
using BLL.Interfaces;
using BLL.Mappers;
using BLL.Services;
using DAL.Interfaces;
using DAL.Interfaces.DTO;
using DAL.Mappers;
using ORM;

namespace TasksManager.Providers
{
    public class CustomMembershipProvider : MembershipProvider
    {
        public IUserRepository UserRepository
           => (IUserRepository)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserRepository));

        //public IRoleRepository RoleRepository
        //    => (IRoleRepository)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleRepository));

        public MembershipUser CreateUser(string email, string password, string name)
        {
            MembershipUser membershipUser = GetUser(email, false);

            if (membershipUser != null)
            {
                return null;
            }

            var user = new DalUser
            {
                Name = name,
                Email = email,
                Password = password //Crypto.HashPassword(password)
            };


            UserRepository.Create(user);
            membershipUser = GetUser(email, false);
            return membershipUser;
        }

        public override bool ValidateUser(string email, string password)
        {
            var user = UserRepository.GetByPredicate(u=>u.Email==email);

            //if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
            if (user != null && user.Password.Equals(password))
            //Определяет, соответствуют ли заданный хэш RFC 2898 и пароль друг другу
            {
                return true;
              }
            return false;
        }

        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            var user = UserRepository.GetByPredicate(u=>u.Email==email).GetORMEntity();

            if (user == null) return null;

            var memberUser = new MembershipUser("CustomMembershipProvider", user.Email,
                null, null, null, null,
                false, false, DateTime.Now, 
                DateTime.MinValue, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue);

            return memberUser;
        }

        //private IUserService service;

        //public override MembershipUser GetUser(string username, bool userIsOnline)
        //{
        //    service = System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService)) as IUserService;
        //    try
        //    {
        //        var user = service.GetAllByPredicate(u => u.Name == username).FirstOrDefault();
        //        if (user == null)
        //            return null;
        //        MembershipUser member = new MembershipUser("CustomMembershipProvider", user.Name, null, null, null, null,
        //            false, false, DateTime.Now, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
        //        return member;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}


        //public override bool ValidateUser(string username, string password)
        //{
        //    service = System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService)) as IUserService;
        //    bool isValid = false;
        //    try
        //    {
        //        var user = service.GetAllByPredicate(u => u.Name == username).FirstOrDefault();
        //        if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
        //        {
        //            isValid = true;
        //        }
        //    }
        //    catch
        //    {
        //        isValid = false;
        //    }
        //    return isValid;
        //}

        //public IEnumerable<UserEntity> GetAllUsers()
        //{
        //    return service.GetAllEntities();
        //}

        //public MembershipUser CreateUser(UserEntity user)
        //{

        //    MembershipUser member = GetUser(user.Name, false);

        //    if (member == null)
        //    {
        //        try
        //        {
        //            service.Create(user);
        //            member = GetUser(user.Name, false);
        //            return member;
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //    return null;
        //}


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

        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }



        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }


    }
}