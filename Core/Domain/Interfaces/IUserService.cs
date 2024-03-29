using BusStation_API.Core.Domain.Entities;

namespace BusStation_API.Core.Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<BaseUser>> GetWorkers();
        Task<BaseUser?> GetWorkerById(string id);
        Task<string> GetRolesFromUser(string token);
        Task<bool> DeleteUserById(string id);
        Task<string> DeleteAllRefreshTokenForUserById(string userId);
    }
}
