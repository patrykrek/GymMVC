using Gym.DTO;
using Gym.Models;

namespace Gym.Interfaces
{
    public interface IReservationService
    {
        Task<List<GetReservationDTO>> DisplayUserReservationsAsync(string userId);
        Task<ReservationResult> CreateReservationAsync(CreateReservationDTO reservationDTO);
        Task<List<GetReservationDTO>> DisplayEveryUserReservationAsync();
    }
}
