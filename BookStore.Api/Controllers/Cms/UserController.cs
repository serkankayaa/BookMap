using System;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.Cms
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("/User")]
        [HttpPost]
        public object PostUser(DtoUser model)
        {
            return _userService.PostUser(model);
        }

        [Route("/User")]
        [HttpPut]
        public object EditAccountUser(DtoUser model)
        {
            return _userService.EditAccountUser(model);
        }

        [Route("/User/Password")]
        [HttpPost]
        public object SavePassword(Guid userId, string passwordHash, string grantedUser)
        {
            return _userService.SavePassword(userId, passwordHash, grantedUser);
        }

        [Route("User/Profile")]
        [HttpPut]
        public object EditUserProfile(DtoUser model)
        {
            return _userService.EditUserProfile(model);
        }

        [Route("User/Login")]
        [HttpPost]
        public object Login(string userName, string email, string passwordHash)
        {
            return _userService.Login(userName, email, passwordHash);
        }

        [Route("User/ChangeRole")]
        [HttpPut]
        public object ChangeRole(Guid userId)
        {
            return _userService.ChangeRole(userId);
        }
    }
}