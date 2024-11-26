using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Domain.Models;

public class UserResponse
{
    public required string BirthDate { get; init; }
    public required string CPF { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required string PhoneNumber { get; init; }
    [MaxLength(100)]
    public string? Address { get; init; } = string.Empty;
    public string? Language { get; init; }
    public DateTime? CreatedAt { get; init; }
}
