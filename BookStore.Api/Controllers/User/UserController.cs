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
        public object PostUser(DtoUser model)
        {
            return _userService.UserAdd(model);
        }

        [Route("api/GetUser/{id:Guid}")]
        [HttpGet]
        public object GetUser(Guid id)
        {
            return _userService.GetUser(id);
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

        [Route("api/UserLogin")]
        [HttpPost]
        public bool UserLogin(DtoUserLogin model)
        {
            return _userService.UserLogin(model);
        } 
    }
}