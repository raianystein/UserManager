using Mediator;
using System.ComponentModel.DataAnnotations;
using UserManager.Domain.Models;

namespace UserManager.Domain.Commands;

public class UpdateUserCommand : ICommand<CommandResultModel>
{
    public Guid? Id { get; init; }
    public string? CPF { get; init; }
    public string? Email { get; init; }
    public string? Password { get; init; }
    public string? PhoneNumber { get; init; }
    [MaxLength(100)]
    public string? Address { get; init; }
    public string? Language { get; init; }
}