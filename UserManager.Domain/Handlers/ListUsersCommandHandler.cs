using AutoMapper;
using Mediator;
using UserManager.Domain.Commands;
using UserManager.Domain.Entities;
using UserManager.Domain.Interfaces;
using UserManager.Domain.Models;

namespace UserManager.Domain.Handlers;

public class ListUsersCommandHandler : ICommandHandler<ListUsersCommand, CommandResultModel>
{
    private readonly IServices _services;
    private readonly IMapper _mapper;
    public ListUsersCommandHandler(IServices services, IMapper mapper)
    {
        _services = services;
        _mapper = mapper;
    }

    public async ValueTask<CommandResultModel> Handle(ListUsersCommand command, CancellationToken cancellationToken)
    {
        var response = new CommandResultModel<IEnumerable<UserResponse>>();
        try
        {
            var users = await _services.GetAllUsersAsync();
            var responseModel = _mapper.Map<IEnumerable<UserResponse>>(users);
            return response.AddData(responseModel);
        }
        catch (Exception ex) { return response.AddError(ex.Message); }
    }
}
