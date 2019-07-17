using System;
using BookStore.Dto;

namespace BookStore.Business.Services
{
    public interface IUserService
    {
        object PostUser(DtoUser model);
        object SavePassword(Guid userId, string passwordHash, string grantedUser);
        object SaveProfile(DtoUser model);
    }
}