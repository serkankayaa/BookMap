using System;
using BookStore.Dto;

namespace BookStore.Business.Services
{
    public interface IUserService
    {
        object PostUser(DtoUser model);
        object SavePassword(Guid userId, string passwordHash, string grantedUser);
        object EditUserProfile(DtoUser model);
        object EditAccountUser(DtoUser model);
        object Login(string userName, string email, string passwordHash);
        object ChangeRole(Guid userId);
    }
}