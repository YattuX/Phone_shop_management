using Kada.Application.Contracts.Identity;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
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

        public async Task<SearchResult<UserModel>> GetUtilisateursListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var utilisateurs = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            
            List<UserModel> usersWithRoles = new();

            foreach (var utilisateur in utilisateurs)
            {
                var roles = await _userManager.GetRolesAsync(utilisateur);
                usersWithRoles.Add(new UserModel {
                    Id = utilisateur.Id,
                    Email = utilisateur.Email,
                    Firstname = utilisateur.FirstName,
                    Lastname = utilisateur.LastName,
                    Roles = roles
                });
            }

            return new SearchResult<UserModel>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = usersWithRoles
            };
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

        public IQueryable<ApplicationUser> GetFilteredQuery(Dictionary<string, string> filter)
        {
            IQueryable<ApplicationUser> userQuery = _userManager.Users;

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }

                switch (key)
                {
                    case "email":
                        userQuery = userQuery.Where(x => x.Email.Contains(filter[key]));
                        break;
                    case "firstname":
                        userQuery = userQuery.Where(x => x.FirstName.Contains(filter[key]));
                        break;
                    case "lastname":
                        userQuery = userQuery.Where(x => x.LastName.Contains(filter[key]));
                        break;
                    case "phoneNumber":
                        userQuery = userQuery.Where(x=> x.PhoneNumber.Contains(filter[key]));
                        break;
                }
            }
            return userQuery;
        }

    }
}
