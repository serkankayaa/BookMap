using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreMap.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("api/PostUser")]
        [HttpPost]
        public bool UserAdd(DtoUser model)
        {
            return _userService.UserAdd(model);
        }

        [Route("api/GetAllUser")]
        [HttpPost]
        public List<DtoUser> GetAllUser()
        {
            return _userService.GetUsers();
        }

        [Route("api/DeleteUser")]
        [HttpDelete]
        public bool DeleteUser(Guid id)
        {
            return _userService.DeleteUser(id);
        }

        [Route("api/UpdateUser")]
        [HttpPut]
        public object UpdateUser(DtoUser model)
        {
            return _userService.UpdateUser(model);
        }

        [Route("api/RecoverPassword")]
        [HttpPut]
        public object RecoverPassword(DtoUserPassword model)
        {
            return _userService.RecoverPassword(model);
        }

    }
}