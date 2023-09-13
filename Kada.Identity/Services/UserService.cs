using Kada.Application.Contracts.Identity;
using Kada.Application.DTOs.Search;
using Kada.Application.Models.Identity;
using Kada.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
                Roles = await GetRoleInfos(utilisateur),
                PhoneNumber = utilisateur.PhoneNumber,
                Username = utilisateur.UserName,
            };
        }

        public async Task<UserModelUpdate> UpdateUser(UserModelUpdate model)
        {
            var user =  _userManager.FindByIdAsync(model.Id).Result;
            if(user == null)
            {
                return null;
            }
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.FirstName = model.Firstname;
            user.LastName = model.Lastname;
            user.UserName = model.Username;

            try
            {
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    var rolesUser = await _userManager.GetRolesAsync(user);
                    var normalizedRolesUser = await _roleManager.Roles
                    .Where(role => rolesUser.Contains(role.Name))
                    .Select(role => role.NormalizedName)
                    .ToListAsync();

                    var rolesToRemove = normalizedRolesUser.Except(model.Roles).ToList();

                    if (rolesToRemove.Any())
                    {
                        var resultat = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
                    }

                    var rolesToAdd = model.Roles.Except(normalizedRolesUser).ToList();
                    if (rolesToAdd.Any())
                    {
                        var roles = await _userManager.AddToRolesAsync(user, rolesToAdd);
                        if (roles.Succeeded)
                        {
                            return model;
                        }
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SearchResult<UserModel>> GetUtilisateursListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var utilisateurs = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            
            List<UserModel> usersWithRoles = new();

            foreach (var utilisateur in utilisateurs)
            {
                var rolesInfo = await GetRoleInfos(utilisateur);

                usersWithRoles.Add(new UserModel {
                    Id = utilisateur.Id,
                    Email = utilisateur.Email,
                    Firstname = utilisateur.FirstName,
                    Lastname = utilisateur.LastName,
                    Roles = rolesInfo,
                    PhoneNumber = utilisateur.PhoneNumber,
                    Username = utilisateur.UserName
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

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user =await  _userManager.Users.Where(user => user.Id == id.ToString()).FirstOrDefaultAsync();
            if(user == null)
            {
                return false;
            }
            await _userManager.DeleteAsync(user);
            return true;
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
        
        private async Task<List<RoleInfo>> GetRoleInfos(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var rolesInfo = await _roleManager.Roles
                .Where(role => roles.Contains(role.Name))
                .Select(role => new RoleInfo
                {
                    Name = role.Name,
                    NormalizedName = role.NormalizedName
                }).ToListAsync();
            return rolesInfo;
        }
    }
}
