using Gym.DTO;
using Gym.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gym.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult Reservations()
        {
            return View();
        }

        public IActionResult CreateReservation()
        {
            return View();
        }


        public async Task<IActionResult> CreateReservationForm(CreateReservationDTO reservationDTO)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (user == null)
            {
                return Unauthorized();
            }

            reservationDTO.UserId = user;

           
            var result = await _reservationService.CreateReservationAsync(reservationDTO);

            if (!result.Success)
            {
                if (result.ErrorMessage == "You don't have membership")
                {
                    return RedirectToAction("MembershipRequired", new { message = result.ErrorMessage });
                }
                else
                {
                    return RedirectToAction("TrainingNotFound", new { message = result.ErrorMessage });
                }
                
            }

                return RedirectToAction("Reservations");
                             
        }

        public async Task<IActionResult> GetUserReservations()
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (user == null)
            {
                return Unauthorized();
            }

            var getReser = await _reservationService.DisplayUserReservationsAsync(user);

            return View(getReser);
        }

        public async Task<IActionResult> GetEveryUserReservations()
        {
            var getReser = await _reservationService.DisplayEveryUserReservationAsync();

            return View(getReser);
        }

        public IActionResult MembershipRequired(string message)
        {
            ViewData["ErrorMessage"] = message; 

            return View();
        }

        public IActionResult TrainingNotFound(string message)
        {
            ViewData["ErrorMessage"] = message;

            return View();
        }
    }
}
