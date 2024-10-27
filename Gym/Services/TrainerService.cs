using AutoMapper;
using Gym.Data;
using Gym.DTO;
using Gym.Interfaces;
using Gym.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private List<Trainer> trainers = new List<Trainer>();
        public TrainerService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetTrainerDTO>> GetAllTrainersAsync()
        {
            var getDbTrainer = await _context.Trainers.ToListAsync();

            var getTrainer = getDbTrainer.Select(t => _mapper.Map<GetTrainerDTO>(t)).ToList();

            return getTrainer;
        }

        public async Task<GetTrainerDTO> AddTrainerAsync(AddTrainerDTO addTrainer)
        {
            var newtrainer = new Trainer
            {
                FirstName = addTrainer.FirstName,
                LastName = addTrainer.LastName,
                Bio = addTrainer.Bio,
            };

            trainers.Add(newtrainer);

            await _context.Trainers.AddAsync(newtrainer);

            await _context.SaveChangesAsync();

            var getTrainer = _mapper.Map<GetTrainerDTO>(newtrainer);

            return getTrainer;



        }

        public async Task EditTrainersAsync(UpdateTrainerDTO trainer)
        {
            var findTrainer = await _context.Trainers.FirstOrDefaultAsync(tr => tr.Id == trainer.Id);

            if (findTrainer != null)
            {               
                findTrainer.FirstName = trainer.FirstName;
                findTrainer.LastName = trainer.LastName;
                findTrainer.Bio = trainer.Bio;


                await _context.SaveChangesAsync();

            }                    
        }

        public async Task<UpdateTrainerDTO> GetTrainerForEditAsync(int id)
        {
            var findtrainer = await _context.Trainers.FindAsync(id);

            return new UpdateTrainerDTO
            {
                Id = id,
                FirstName = findtrainer.FirstName,
                LastName = findtrainer.LastName,
                Bio = findtrainer.Bio
            };
        }

        public async Task DeleteTrainersAsync(UpdateTrainerDTO trainer)
        {
            var findtrainer = await _context.Trainers.FindAsync(trainer.Id);

            if (findtrainer != null)
            {
                _context.Trainers.Remove(findtrainer);

                await _context.SaveChangesAsync();
            }          
        }

       

        
    }
}
