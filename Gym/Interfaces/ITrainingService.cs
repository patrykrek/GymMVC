using Gym.DTO;

namespace Gym.Interfaces
{
    public interface ITrainingService
    {
        Task<List<GetTrainingDTO>> DisplayTrainingsAsync();
        Task<GetTrainingDTO> AddTrainingAsync(AddTrainingDTO trainingDTO);
        Task DeleteTrainingAsync(UpdateTrainingDTO training);
        Task EditTrainingAsync(UpdateTrainingDTO training);
        Task<UpdateTrainingDTO> GetTrainingForEditAsync(int id);
    }
}
