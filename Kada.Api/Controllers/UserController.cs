using HR.LeaveManagement.Application.Contracts.Identity;
using Kada.Application.Contracts.Identity;
using Kada.Application.Models.Identity;
using Kada.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Kada.Api.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("users")]
        public async Task<List<UserModel>> GetUserList()
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

        [HttpGet("user/{id}")]
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

        [HttpGet("roles")]
        public async Task<List<RoleModel>> GetRoleList()
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

        [HttpPost("roles/add")]
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

        [HttpDelete("roles/{id}")]
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
