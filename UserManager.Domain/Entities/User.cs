using System.ComponentModel.DataAnnotations;
using UserManager.Domain.Commands;

namespace UserManager.Domain.Entities;

public class User
{
    public required Guid Id { get; init; }
    public required DateTime BirthDate { get; init; }
    public required string CPF { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string PhoneNumber { get; init; }
    [MaxLength(100)]
    public string? Address { get; init; } = string.Empty;
    public string? Language { get; init; }
    public DateTime CreatedAt { get; init; }
    public bool IsActive { get; init; }

    public static User BuildByCommand(CreateUserCommand command)
    {
        return (
            new User
            {
                Id = Guid.NewGuid(),
                BirthDate = command.BirthDate,
                CPF = command.CPF,
                FullName = command.FullName,
                Email = command.Email,
                Password = command.Password,
                PhoneNumber = command.PhoneNumber,
                Address = command.Address,
                Language = command.Language,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            }
        );
    }
}