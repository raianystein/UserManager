using Mediator;
using UserManager.Domain.Models;

namespace UserManager.Domain.Commands;

public class DeleteUserCommand : ICommand<CommandResultModel>
{
    public Guid? Id { get; init; }
    public string? CPF { get; init; }
}