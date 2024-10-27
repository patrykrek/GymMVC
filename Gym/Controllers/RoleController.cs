using Gym.Interfaces;
using Gym.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Roles()
        {
            return View();
        }

        public async Task<IActionResult> DisplayRoles()
        {
            var Roles = await _roleService.DisplayRoles();

            return View(Roles);
        }

        public IActionResult AssignRoles()
        {
            return View();
        }
        public async Task<IActionResult> AssignRolesForm(UserRole userRole)
        {
            if (!ModelState.IsValid)
            {
                return View("AssignRoles", userRole);
            }
            await _roleService.AssignRole(userRole.Email, userRole.Roles);

            return RedirectToAction("DisplayRoles");

            
        }
    }
}
