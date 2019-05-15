using BookStore.Dto;
using System;
using System.Collections.Generic;

namespace BookStore.Business.Services
{
    public interface IUserService
    {
        object GetUser(Guid id);
        List<DtoUser> GetUsers();
        object UserAdd(DtoUser model);
        bool DeleteUser(Guid id);
        DtoUser UpdateUser(DtoUser model);
        object RecoverPassword(DtoUserPassword model);
    }
}
