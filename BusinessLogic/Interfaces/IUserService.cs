﻿using Data.Models;

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
