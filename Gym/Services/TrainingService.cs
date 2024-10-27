using AutoMapper;
using Gym.Data;
using Gym.DTO;
using Gym.Interfaces;
using Gym.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private List<Training> Trainings = new List<Training>();

        public TrainingService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetTrainingDTO>> DisplayTrainingsAsync()
        {
            var getDbTraining = await _context.Trainings.ToListAsync();

            var getTraining = getDbTraining.Select(tr => _mapper.Map<GetTrainingDTO>(tr)).ToList();

            return getTraining;
        }
        public async Task<GetTrainingDTO> AddTrainingAsync(AddTrainingDTO trainingDTO)
        {
                     

            var newtraining = new Training
            {
                Name = trainingDTO.Name,
                Description = trainingDTO.Description,
                StartDate = trainingDTO.StartDate,
                Duration = trainingDTO.Duration,
                TrainerId = trainingDTO.TrainerId,
            };

            Trainings.Add(newtraining);

            await _context.Trainings.AddAsync(newtraining);

            await _context.SaveChangesAsync();

            var getTraining =  _mapper.Map<GetTrainingDTO>(newtraining);

            return getTraining;
        }

        public async Task DeleteTrainingAsync(UpdateTrainingDTO training)
        {
            var findTraining = await _context.Trainings.FindAsync(training.Id);

            if (findTraining != null)
            {
                _context.Trainings.Remove(findTraining);

                await _context.SaveChangesAsync();
            }
        }

        public async Task EditTrainingAsync(UpdateTrainingDTO training)
        {
            var findTraining = await _context.Trainings.FirstOrDefaultAsync(tr => tr.Id == training.Id);

            if (findTraining != null)
            {
                findTraining.Name = training.Name;
                findTraining.Description = training.Description;
                findTraining.StartDate = training.StartDate;
                findTraining.Duration = training.Duration;
                findTraining.TrainerId = training.TrainerId;    

                await _context.SaveChangesAsync();
            }
        }

        public async Task<UpdateTrainingDTO> GetTrainingForEditAsync(int id)
        {
            var findTraining = await _context.Trainings.FindAsync(id);

            return new UpdateTrainingDTO
            {
                Id = id,
                Name = findTraining.Name,
                Description = findTraining.Description,
                StartDate = findTraining.StartDate,
                Duration = findTraining.Duration,
                TrainerId = findTraining.TrainerId

            };
        }

        
    }
}
