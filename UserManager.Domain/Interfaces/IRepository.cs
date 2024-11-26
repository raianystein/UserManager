using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Entities;

namespace UserManager.Domain.Interfaces;

public interface IRepository
{
    Task<User> GetUserByIdAsync(Guid? id, string? cpf);
    Task CreateUserAsync(User user);
    Task<List<User>> GetAllUsersAsync();
    Task DeleteUserAsync(Guid? id, string? cpf);
    Task<User> UpdateUserAsync(Guid? id, string? cpf, string? email, string? password, string? phoneNumber, string? address, string? language);
}
