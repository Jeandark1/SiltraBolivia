using CargoApi.Domain.Entities;
using static CargoApi.Domain.Enums.UserEnums;

namespace CargoApi.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<DataUser>
    {
        Task<DataUser> GetByExternalIdAsync(string externalId);
        Task<DataUser> GetByEmailAsync(string email);
        Task<IEnumerable<DataUser>> GetUsersByStatusAsync(UserStatus status);
        Task<DataUser> GetUserWithDetailsAsync(int id);
        Task<bool> SoftDeleteAsync(int id, string userDeletion);
    }
}
