using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Business.Generic;
using BookStore.Dto;
using BookStore.Entity.Context;
using BookStore.Entity.Models;

namespace BookStore.Business.Services
{
    public class UserService : EFRepository<User>, IUserService
    {
        #region Field

        private BookDbContext _context;

        #endregion

        #region Ctor

        public UserService(BookDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Method

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        public List<DtoUser> GetUsers()
        {
            var users = this.GetAll();

            var totalUsers = users.Select(c => new DtoUser
            {
                USER_ID = c.USER_ID,
                FIRST_NAME = c.FIRST_NAME,
                SECOND_NAME = c.SECOND_NAME,
                FULL_NAME = c.FIRST_NAME + " " + c.SECOND_NAME,
                EMAIL_ADDRESS = c.EMAIL_ADDRESS,
                BIRTH_DATE = c.BIRTH_DATE,
                LOCATION = c.LOCATION
            }).ToList();

            return totalUsers;
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public object UserAdd(DtoUser model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                Account account = new Account();

                var isExistedName = _context.Account.Where(c=> c.NAME == model.USER_NAME).Any();
                if(isExistedName)
                {
                    //eğer gelen username zaten kayıtlı ise false döndür.
                    return false;
                }

                account.NAME = model.USER_NAME;

                if(model.IS_ADMIN)
                {
                    account.TYPE = (byte)UserType.Admin;
                }
                else
                {
                    account.TYPE = (byte)UserType.User;
                }

                _context.Account.Add(account);
                this.Save();

                User user = new User();
                user.FIRST_NAME = model.FIRST_NAME;
                user.SECOND_NAME = model.SECOND_NAME;
                user.EMAIL_ADDRESS = model.EMAIL_ADDRESS;
                user.LOCATION = model.LOCATION;
                user.BIRTH_DATE = model.BIRTH_DATE;
                user.CREATED_BY = model.CREATED_BY;
                user.CREATED_DATE = DateTime.Now;
                user.ACCOUNT_ID_FK = account.ACCOUNT_ID;

                _context.User.Add(user);
                this.Save();

                User_Password user_password = new User_Password();
                user_password.PASSWORD_HASH = model.PASSWORD_HASH;
                user_password.CREATED_BY = model.CREATED_BY;
                user_password.USER_ID_FK = user.USER_ID;
                user_password.IS_ACTIVE = true;
                user_password.CREATED_DATE = DateTime.Now;

                _context.User_Password.Add(user_password);
                this.Save();

                transaction.Commit();
                return model;
            }
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteUser(Guid id)
        {
            var userData = this.GetById(id);
            this.Delete(userData);

            return true;
        }

        /// <summary>
        /// Update User without password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DtoUser UpdateUser(DtoUser model)
        {
            var userData = this.GetById(model.USER_ID);

            userData.FIRST_NAME = model.FIRST_NAME;
            userData.SECOND_NAME = model.SECOND_NAME;
            userData.EMAIL_ADDRESS = model.EMAIL_ADDRESS;
            userData.BIRTH_DATE = model.BIRTH_DATE;
            userData.LOCATION = model.LOCATION;
            userData.MODIFIED_BY = model.MODIFIED_BY;
            userData.MODIFIED_DATE = DateTime.Now;

            _context.User.Update(userData);
            this.Save();

            return model;
        }

        /// <summary>
        /// Recover New Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public object RecoverPassword(DtoUserPassword model)
        {
            //TODO: Email onaylama işlemi yapılacak.
            var isSamePassword = _context.User_Password.Where(c => c.USER_PASS_ID == model.USER_PASS_ID && c.IS_ACTIVE == true).Any();

            //değiştireceği şifre aktif olan şifreyle aynı ise false döndür.
            if (isSamePassword)
            {
                return false;
            }

            var userPasswords = _context.User_Password.Where(c => c.USER_ID_FK == model.USER_ID).ToList();
            var lastUserPassword = userPasswords.OrderByDescending(c => c.MODIFIED_DATE).FirstOrDefault();

            foreach (var userPassword in userPasswords)
            {
                if (model.PASSWORD_HASH == userPassword.PASSWORD_HASH)
                {
                    //Eğer şifreyi daha önce oluşturmuşsa ilgili tarihi döndür.
                    if (userPasswords.Count == 1)
                    {
                        return userPassword.CREATED_DATE;
                    }
                    
                    //Eğer daha önce oluşturup değiştirdiyse, değiştirdiği tarihi döndürür.
                    else
                    {
                        return userPassword.MODIFIED_DATE;
                    }
                }
            }

            lastUserPassword.IS_ACTIVE = false;
            _context.User_Password.Update(lastUserPassword);

            User_Password newPassword = new User_Password();

            newPassword.PASSWORD_HASH = model.PASSWORD_HASH;
            newPassword.CREATED_BY = model.USER_NAME;
            newPassword.CREATED_DATE = DateTime.Now;
            newPassword.IS_ACTIVE = true;
            newPassword.USER_ID_FK = model.USER_ID;

            _context.User_Password.Add(newPassword);
            this.Save();

            return model;
        }

        #endregion
    }
}
