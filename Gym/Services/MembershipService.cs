using AutoMapper;
using Gym.Data;
using Gym.DTO;
using Gym.Interfaces;
using Gym.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private List<Membership> Memberships = new List<Membership>();

        public MembershipService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetMembershipDTO>> DisplayMembershipAsync()
        {
            var getDbMembership = await _context.Memberships.ToListAsync();

            var getMembership = getDbMembership.Select(m => _mapper.Map<GetMembershipDTO>(m)).ToList();

            return getMembership;

        }
        
        public async Task<List<GetUserMembershipDTO>> DisplayUserMembershipAsync(string userId) // for users
        {
            var getDbUserMembership = await _context.UserMemberships.Where(u => u.userId == userId).ToListAsync();

            var getUserMembership = getDbUserMembership.Select(um => _mapper.Map<GetUserMembershipDTO>(um)).ToList();

            return getUserMembership;
        }

        public async Task<List<GetUserMembershipDTO>> DisplayEveryUserMembershipsAsync() // for admin
        {
            var getDb = await _context.UserMemberships.ToListAsync();

            var getReser = getDb.Select(um => _mapper.Map<GetUserMembershipDTO>(um)).ToList();

            return getReser;
        }
        public async Task<GetMembershipDTO> AddMembershipAsync(AddMembershipDTO membership)
        {
            var newmembership = new Membership
            {
                Id = membership.Id,
                Name = membership.Name,
                PricePerMonth = membership.PricePerMonth,
            };

            Memberships.Add(newmembership);

            await _context.Memberships.AddAsync(newmembership);

            await _context.SaveChangesAsync();

            var getMembership = _mapper.Map<GetMembershipDTO>(newmembership);

            return getMembership;

            

        }

        public async Task DeleteMembershipAsync(UpdateMembershipDTO membership)
        {
            var findMembership = await _context.Memberships.FindAsync(membership.Id);

            if (findMembership != null)
            {
                Memberships.Remove(findMembership);

                _context.Memberships.Remove(findMembership);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<UpdateMembershipDTO> GetMembershipForEditAsync(int id)
        {
            var findMembership = await _context.Memberships.FindAsync(id);

            return new UpdateMembershipDTO
            {
                Id = findMembership.Id,
                Name = findMembership.Name,
                PricePerMonth = findMembership.PricePerMonth,

            };
        }

        public async Task EditMembershipAsync(UpdateMembershipDTO membership)
        {
            var findMembership = await _context.Memberships.FirstOrDefaultAsync(m => m.Id == membership.Id);

            if (findMembership != null)
            {
                findMembership.Name = membership.Name;
                findMembership.PricePerMonth = membership.PricePerMonth;

                await _context.SaveChangesAsync();
            }
        }

        public async Task BuyMembershipAsync(int membershipId, string userId)
        {
            var findMembership = _context.Memberships.Find(membershipId);

            if (findMembership != null)
            {
                var userMembership = new UserMembership
                {
                    MembershipId = membershipId,
                    userId = userId
                };

                await _context.UserMemberships.AddAsync(userMembership);

                await _context.SaveChangesAsync();
            }
        }
    }
}
