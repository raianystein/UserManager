using AutoMapper;
using Mediator;
using UserManager.Domain.Commands;
using UserManager.Domain.Entities;
using UserManager.Domain.Interfaces;
using UserManager.Domain.Models;

namespace UserManager.Domain.Handlers;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, CommandResultModel>
{
    private readonly IServices _services;
    private readonly IMapper _mapper;
    public CreateUserCommandHandler(IServices services, IMapper mapper)
    {
        _services = services;
        _mapper = mapper;
    }

    public async ValueTask<CommandResultModel> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var response = new CommandResultModel<UserResponse>();
        try
        {
            var entity = User.BuildByCommand(command);
            await _services.CreateUserAsync(entity);
            var responseModel = _mapper.Map<UserResponse>(entity);
            return response.AddData(responseModel);
        }
        catch (Exception ex) { return response.AddError(ex.Message); }
    }
}
