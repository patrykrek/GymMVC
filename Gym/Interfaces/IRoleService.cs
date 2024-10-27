using Gym.Models;

namespace Gym.Interfaces
{
    public interface IRoleService
    {
        Task AssignRole(string Email, string[] Roles);
        Task<List<Role>> DisplayRoles();
    }
}
