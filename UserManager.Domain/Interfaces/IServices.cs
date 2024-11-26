﻿using UserManager.Domain.Entities;

namespace UserManager.Domain.Interfaces;

public interface IServices
{
    Task<User> GetUserByIdAsync(Guid? id, string? cpf);
    Task CreateUserAsync(User user);
    Task<List<User>> GetAllUsersAsync();
    Task DeleteUserAsync(Guid? id, string? cpf);
    Task<User> UpdateUserAsync(Guid? id, string? cpf, string? email, string? password, string? phoneNumber, string? address, string? language);
}