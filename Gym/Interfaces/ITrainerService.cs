using Gym.DTO;

namespace Gym.Interfaces
{
    public interface ITrainerService
    {
        Task<List<GetTrainerDTO>> GetAllTrainersAsync();
        Task<GetTrainerDTO> AddTrainerAsync(AddTrainerDTO addTrainer);
        Task DeleteTrainersAsync(UpdateTrainerDTO trainer);
        Task EditTrainersAsync(UpdateTrainerDTO trainer);
        Task<UpdateTrainerDTO> GetTrainerForEditAsync(int id);
    }
}
