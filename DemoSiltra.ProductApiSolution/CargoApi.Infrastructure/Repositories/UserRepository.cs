using CargoApi.Domain.Entities;
using CargoApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static CargoApi.Domain.Enums.UserEnums;
using CargoApi.Application.Interfaces.Repositories;

namespace CargoApi.Infrastructure.Repositories
{
    public class UserRepository : Repository<DataUser>, IUserRepository 
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<DataUser> GetByExternalIdAsync(string externalId)
        {
            return await _context.DataUsers
                .FirstOrDefaultAsync(u => u.ExternalUserId == externalId);
        }

        public async Task<DataUser> GetByEmailAsync(string email)
        {
            return await _context.DataUsers
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<DataUser>> GetUsersByStatusAsync(UserStatus status)
        {
            return await _context.DataUsers
                .Where(u => u.GeneralStatus == status)
                .ToListAsync();
        }

        public async Task<DataUser> GetUserWithDetailsAsync(int id)
        {
            return await _context.DataUsers
                .Include(u => u.BankAccount)
                .Include(u => u.DataClient)
                .Include(u => u.DataCompany)
                .Include(u => u.Driver)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
          
        public async Task<bool> SoftDeleteAsync(int id, string userDeletion)
        {
            var user = await GetByIdAsync(id);
            if (user == null) return false;

            user.DateDeletionAt = DateTime.UtcNow;
            user.UserDeletion = userDeletion;
            user.GeneralStatus = UserStatus.Inactivo;

            await UpdateAsync(user);
            return true;
        }
    }
}
