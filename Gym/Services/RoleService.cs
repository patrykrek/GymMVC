using Gym.Interfaces;
using Gym.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gym.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleService(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task AssignRole(string Email, string[] Roles)
        {
            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
            {
                throw new ArgumentException();
            }

            var roleExists = await RoleExists(Roles);

            if (roleExists != null || roleExists.Count == Roles.Length)
            {
                var assignRole = await _userManager.AddToRolesAsync(user, Roles);
            }

          
        }

        public async Task<List<Role>> DisplayRoles()
        {
            var getRoles = await _roleManager.Roles.Select(r => new Role { Id = Guid.Parse(r.Id), Name = r.Name }).ToListAsync();

            return getRoles;
        }

        private async Task<List<string>> RoleExists(string[] Roles)
        {
            var list = new List<string>();

            foreach (var role in Roles)
            {
                if (await _roleManager.RoleExistsAsync(role))
                {
                    list.Add(role);
                }
            }
            return list;
        }
    }
}
