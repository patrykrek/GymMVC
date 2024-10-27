using Gym.DTO;
using Gym.Interfaces;
using Gym.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gym.Controllers
{
    public class MembershipController : Controller
    {
        private readonly IMembershipService _membershipService;

        public MembershipController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public IActionResult Memberships()
        {
            return View();
        }

        public async Task<IActionResult> DisplayMemberships()
        {
            var memberships = await _membershipService.DisplayMembershipAsync();

            return View(memberships);
        }

        public async Task<IActionResult> DisplayUserMemberships()
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (user == null)
            {
                return Unauthorized();
            }

            var getmembership = await _membershipService.DisplayUserMembershipAsync(user);

            return View(getmembership);
        }

        public async Task<IActionResult> DisplayEveryUserMemberships()
        {
            var getMemb = await _membershipService.DisplayEveryUserMembershipsAsync();

            return View(getMemb);
        }

        public IActionResult AddMemberships()
        {
            return View();
        }

        public async Task<IActionResult> AddMembershipsForm(AddMembershipDTO membership)
        {
            if (!ModelState.IsValid)
            {
                return View("AddMemberships", membership);
            }

            var newmembership = await _membershipService.AddMembershipAsync(membership);

            return RedirectToAction("DisplayMemberships");
        }

        public async Task<IActionResult> EditMemberships(int id)
        {
            var membershipForEdit = await _membershipService.GetMembershipForEditAsync(id);

            return View(membershipForEdit);
        }

        public async Task<IActionResult> EditMembershipsForm(UpdateMembershipDTO membershipToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return View(membershipToUpdate);
            }

            await _membershipService.EditMembershipAsync(membershipToUpdate);

            return RedirectToAction("DisplayMemberships");
        }

        public async Task<IActionResult> BuyMembershipForm(int membershipId)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (user != null)
            {
                await _membershipService.BuyMembershipAsync(membershipId, user);
            }

            return RedirectToAction("Memberships");
        }
    }

}
