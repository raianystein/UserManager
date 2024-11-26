using Mediator;
using UserManager.Domain.Models;

namespace UserManager.Domain.Commands;

public class ListUsersCommand : ICommand<CommandResultModel>;