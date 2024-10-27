using AutoMapper;
using Gym.Data;
using Gym.DTO;
using Gym.Interfaces;
using Gym.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.Services
{
    public class ReservationService : IReservationService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReservationService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetReservationDTO>> DisplayUserReservationsAsync(string userId) // for users
        {
            var getDbUserReservations = await _context.Reservations.Where(r => r.UserId == userId).ToListAsync();

            var getUserReservations = getDbUserReservations.Select(r => _mapper.Map<GetReservationDTO>(r)).ToList();

            return getUserReservations;
        }

        public async Task<List<GetReservationDTO>> DisplayEveryUserReservationAsync() // for admin
        {
            var getDb = await _context.Reservations.ToListAsync();

            var getReser = getDb.Select(r => _mapper.Map<GetReservationDTO>(r)).ToList();

            return getReser;
        } 
        public async Task<ReservationResult> CreateReservationAsync(CreateReservationDTO reservationDTO)
        {
            var findUserMembership = await _context.UserMemberships.FirstOrDefaultAsync(um => um.userId == reservationDTO.UserId);

            if (findUserMembership == null)
            {
                return new ReservationResult { Success = false, ErrorMessage = "You don't have membership" };
            }

            var findTraining = await _context.Trainings.FindAsync(reservationDTO.TrainingId);

            if (findTraining == null)
            {
                return new ReservationResult { Success = false, ErrorMessage = $"Training with ID '{reservationDTO.TrainingId}' not found" };
            }
                   
                     
            var reservation = new Reservation
            {
                ReservationDate = DateTime.Now,
                TrainingId = reservationDTO.TrainingId,
                UserId = reservationDTO.UserId,
            };

            await _context.Reservations.AddAsync(reservation);

            await _context.SaveChangesAsync();

            return new ReservationResult { Success = true };

           


        }

       
    }
}
