using Kada.Application.Contracts.Identity;
using Kada.Application.Models.Identity;
using Kada.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<ApplicationUser> userManager, 
            IHttpContextAccessor contextAccessor,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _roleManager = roleManager;
        }

        public string UserId { get => _contextAccessor?.HttpContext?.User?.FindFirstValue("uid"); }

        public async Task<UserModel> GetUtilisateur(string userId)
        {
            var utilisateur = await _userManager.FindByIdAsync(userId);
            return new UserModel
            {
                Email = utilisateur.Email,
                Id = utilisateur.Id,
                Firstname = utilisateur.FirstName,
                Lastname = utilisateur.LastName,
                Roles = await _userManager.GetRolesAsync(utilisateur)
            };
        }

        public async Task<List<UserModel>> GetUtilisateurs()
        {
            var utilisateurs = await _userManager.Users.ToListAsync();
            var userModels = utilisateurs?.Select(async q => new UserModel
            {
                Id = q.Id,
                Email = q.Email,
                Firstname = q.FirstName,
                Lastname = q.LastName,
                Roles = await _userManager.GetRolesAsync(q)
            }).ToList();

            var usersWithRoles = await Task.WhenAll(userModels);

            return usersWithRoles.ToList();
        }

        public async Task<List<RoleModel>> GetRoles()
        {
            var role = await _roleManager.Roles.ToListAsync();
            return role.Select(r => new RoleModel()
            {
                Id = r.Id,
                Name = r.Name,
                NormalizedName = r.NormalizedName,
                ConcurrencyStamp= r.ConcurrencyStamp,
            }).ToList();
        }

        public async Task<string> CreateRole(CreateRoleModel role)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole()
            {
                Name = role.Name,
                NormalizedName = role.NormalizedName,
            });

            return result.ToString();
        }

        public async Task<string> DeleteRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            var result = await _roleManager.DeleteAsync(role);
            return result.ToString();
        }
    }
}
