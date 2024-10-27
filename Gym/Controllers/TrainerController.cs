using Gym.Data;
using Gym.DTO;
using Gym.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gym.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ITrainerService _trainerService;
        private readonly DataContext _context;
        
        public TrainerController(ITrainerService trainerService, DataContext context)
        {
            _trainerService = trainerService;
            context = _context;
            
        }

        public IActionResult Trainers()
        {
            return View();
        }

        public async Task<IActionResult> DisplayTrainers()
        {
            var trainers = await _trainerService.GetAllTrainersAsync();

            return View(trainers);
        }

       
        public async Task<IActionResult> AddTrainersForm(AddTrainerDTO trainer)
        {
            if (!ModelState.IsValid)
            {
                return View("AddTrainers",trainer);
            }

            if (trainer.Id == 0)
            {
                await _trainerService.AddTrainerAsync(trainer);
            }
           
           
           

            return RedirectToAction("DisplayTrainers");

            
        }

        public IActionResult AddTrainers()
        {
           
            return View();
        }

        public async Task<IActionResult> EditTrainers(int id)
        {
            var trainerForEdit =  await _trainerService.GetTrainerForEditAsync(id);

            return View(trainerForEdit);
        }

        public async Task<IActionResult> EditTrainersForm(UpdateTrainerDTO trainer) 
        {
            await _trainerService.EditTrainersAsync(trainer);
   
            return RedirectToAction("DisplayTrainers");

            
        }

        public async Task<IActionResult> DeleteTrainers(UpdateTrainerDTO trainer)
        {
            await _trainerService.DeleteTrainersAsync(trainer);

            return RedirectToAction("DisplayTrainers");
        }




    }
}
