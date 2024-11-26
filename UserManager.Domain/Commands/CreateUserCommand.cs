using Mediator;
using System.ComponentModel.DataAnnotations;
using UserManager.Domain.Models;

namespace UserManager.Domain.Commands;

public class CreateUserCommand : ICommand<CommandResultModel>
{
    public required DateTime BirthDate { get; init; }
    public required string CPF { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string PhoneNumber { get; init; }
    [MaxLength(100)]
    public string? Address { get; init; } = string.Empty;
    public string? Language { get; init; } = "pt-br";
}
