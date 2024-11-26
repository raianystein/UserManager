using UserManager.Domain.Entities;
using UserManager.Domain.Interfaces;

namespace UserManager.ServiceApplication.Services;

public class Service(IRepository repository) : IServices
{
    private readonly IRepository _repository = repository;

    public Task CreateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(Guid? id, string? cpf)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByIdAsync(Guid? id, string? cpf)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUserAsync(Guid? id, string? cpf, string? email, string? password, string? phoneNumber, string? address, string? language)
    {
        throw new NotImplementedException();
    }
}
