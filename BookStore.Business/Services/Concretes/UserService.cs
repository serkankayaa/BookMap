using System;
using System.Linq;
using BookStore.Business.Generic;
using BookStore.Dto;
using BookStore.Entity.Context;
using BookStore.Entity.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookStore.Business.Services
{
    public class UserService : EFRepository<User>, IUserService
    {
        private BookDbContext _context;

        public UserService(BookDbContext context) : base(context)
        {
            _context = context;
        }

        public object PostUser(DtoUser model)
        {
            using(IDbContextTransaction trnsc = _context.Database.BeginTransaction())
            {
                if(model == null)
                {
                    return new DtoUser();
                }

                bool checkUser = _context.User.Where(c=> c.UserName == model.UserName || c.EmailAddress == model.EmailAddress).Any();

                if(checkUser)
                {
                    return false;
                } 

                User user = new User();
                user.EmailAddress = model.EmailAddress;
                user.EmailConfirmed = true; //TODO: Onaylama sistemi yazılacak.
                user.VerificationCode = "Test: Code"; //TODO: Onaylama sistemi yazılacak.
                user.UserName = model.UserName;
                user.Role = model.Role;
                user.CreatedBy = model.CreatedBy;
                user.CreatedDate = DateTime.Now;

                this._context.User.Add(user);
                this._context.SaveChanges();
                
                //İlk kez kullanıcı oluştururken çalışacak.
                if(!String.IsNullOrEmpty(model.PasswordHash) && user.Id != Guid.Empty)
                {
                    SavePassword(user.Id, model.PasswordHash, model.CreatedBy);
                }
                else
                {
                    return false;
                }

                //İlk kez kullanıcı oluştururken çalışacak.
                if(!String.IsNullOrEmpty(model.Name) && !String.IsNullOrEmpty(model.Surname))
                {
                    SaveProfile(model);
                }
                else
                {
                    return false;
                }
                
                trnsc.Commit();

                return true;
            }
        }
        
        //Method hem ilk şifreyi kaydetmeyi hem de sadece şifreyi değiştirmeyi sağlıyor.
        public object SavePassword(Guid userId, string passwordHash, string grantedUser)
        {
            var passwordDate = _context.UserPassword.Where(c=> c.UserIdFk == userId && c.PasswordHash == passwordHash)
                                                    .Select(k=> k.CreatedDate).FirstOrDefault();

            //Kullanıcının şifresi ilk kez kaydedilirse çalışır.
            if(passwordDate == DateTime.MinValue)
            {
                UserPassword newUserPassword = new UserPassword();
                newUserPassword.PasswordHash = passwordHash;
                newUserPassword.UserIdFk = userId;
                newUserPassword.IsActive = true;
                newUserPassword.CreatedBy = grantedUser;
                newUserPassword.CreatedDate = DateTime.Now;

                this._context.UserPassword.Add(newUserPassword);
                this._context.SaveChanges();

                return true;
            }
            
            //Eğer kullanıcı eski bir şifresini girdiyse, eski girdiği şifrenin kaydedilme tarihini döndürür.
            if(passwordDate == null && passwordDate != DateTime.MinValue)
            {
                return passwordDate; 
            }

            UserPassword userPassword = new UserPassword();
            userPassword.PasswordHash = passwordHash;
            userPassword.UserIdFk = userId;
            userPassword.IsActive = true;
            userPassword.CreatedBy = grantedUser;
            userPassword.CreatedDate = DateTime.Now;

            this._context.UserPassword.Add(userPassword);
            this._context.SaveChanges();

            //Son aktif şifrenin statüsünü pasife çekmek için veritabanından çekilir.
            var lastActivePassword = this._context.UserPassword.Where(c=> c.UserIdFk == userId && c.IsActive == true).OrderBy(k=> k.CreatedDate).FirstOrDefault();
            
            if(lastActivePassword == null)
            {
                return false;
            }

            lastActivePassword.IsActive = false;
            lastActivePassword.UpdatedBy = grantedUser;
            lastActivePassword.UpdatedDate = DateTime.Now;

            this._context.UserPassword.Update(lastActivePassword);
            this._context.SaveChanges();
            
            return true;
        }

        public object SaveProfile(DtoUser model)
        {
            UserProfile userProfile = new UserProfile();
            userProfile.Name = model.Name;
            userProfile.Surname = model.Surname;
            userProfile.Address = model.Address;
            userProfile.BirthDate = model.BirthDate;
            userProfile.UserIdFk = model.UserId;
            userProfile.ImageIdFk = model.ImageIdFk;
            userProfile.CreatedBy = model.CreatedBy;
            userProfile.CreatedDate = DateTime.Now;

            this._context.UserProfile.Add(userProfile);
            this._context.SaveChanges();

            return true;
        }
    }
}