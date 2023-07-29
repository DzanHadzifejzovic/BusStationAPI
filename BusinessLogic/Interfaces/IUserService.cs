using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
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
