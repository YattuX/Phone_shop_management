
using Kada.Application.Models.Identity;

namespace Kada.Application.Contracts.Identity;

public interface IUserService
    {
        Task<List<UserModel>> GetUtilisateurs();
        Task<UserModel> GetUtilisateur(string userId);
        Task<List<RoleModel>> GetRoles();
        Task<string> CreateRole(CreateRoleModel role);
        Task<string> DeleteRole(string roleId);
        public string UserId { get; }
    }

