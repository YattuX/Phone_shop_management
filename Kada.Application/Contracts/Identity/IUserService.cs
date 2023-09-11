
using Kada.Application.DTOs.Search;
using Kada.Application.Models.Identity;

namespace Kada.Application.Contracts.Identity;

public interface IUserService
    {
        Task<SearchResult<UserModel>> GetUtilisateursListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters);
        Task<UserModel> GetUtilisateur(string userId);
        Task<List<RoleModel>> GetRoles();
        Task<string> CreateRole(CreateRoleModel role);
        Task<string> DeleteRole(string roleId);
        public string UserId { get; }
    }

