using Gym.DTO;
using Gym.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        public IActionResult Trainings()
        {
            return View();
        }

        public async Task<IActionResult> DisplayTrainings()
        {
            var displayTraining = await _trainingService.DisplayTrainingsAsync();

            return View(displayTraining);
        }

        public async Task<IActionResult> AddTrainingsForm(AddTrainingDTO training)
        {
            if (!ModelState.IsValid)
            {
                return View("AddTrainings", training);
            }

            var newTraining = await _trainingService.AddTrainingAsync(training);
            
         
            return RedirectToAction("DisplayTrainings");
        }

        public IActionResult AddTrainings()
        {
            return View();
        }

        public async Task<IActionResult> DeleteTrainings(UpdateTrainingDTO training)
        {
            await _trainingService.DeleteTrainingAsync(training);

            return RedirectToAction("DisplayTrainings");
        }

        public async Task<IActionResult> EditTrainings(int id)
        {

            var training = await _trainingService.GetTrainingForEditAsync(id);

            return View(training);
        }

        public async Task<IActionResult> EditTrainingsForm(UpdateTrainingDTO training)
        {
            if (!ModelState.IsValid)
            {
                return View("EditTrainings", training);
            }
            await _trainingService.EditTrainingAsync(training);

            return RedirectToAction("DisplayTrainings");
        }
    }
}
