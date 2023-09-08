﻿using HR.LeaveManagement.Application.Contracts.Identity;
using Kada.Application.Contracts.Identity;
using Kada.Application.Models.Identity;
using Kada.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Kada.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public async Task<List<UserModel>> GetUserListPage()
        {
            try
            {
                return await _userService.GetUtilisateurs();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<UserModel> GetUser(string id)
        {
            try
            {
                return await _userService.GetUtilisateur(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<List<RoleModel>> GetRoleListPage()
        {
            try
            {
                return await _userService.GetRoles();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<string> CreateRole(CreateRoleModel role)
        {
            try
            {
                return await _userService.CreateRole(role);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<string> DeleteRole(string roleId)
        {
            try
            {
                return await _userService.DeleteRole(roleId);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
