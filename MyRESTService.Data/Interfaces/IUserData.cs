﻿using MyRESTService.Domain.Models;
using System.Collections.Generic;

namespace MyRESTService.Data.Interfaces
{
    public interface IUserData : ICrudData<User>
    {
        Task<IEnumerable<User>> GetAllWithRoles();
        Task<User> GetUserWithRoles(string username);
        Task<User> GetByUsername(string username);
        Task<User> Login(string username, string password);
        Task<Task> ChangePassword(string username, string newPassword);
    }
}
