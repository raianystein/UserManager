using AutoMapper;
using Mediator;
using UserManager.Domain.Commands;
using UserManager.Domain.Entities;
using UserManager.Domain.Interfaces;
using UserManager.Domain.Models;

namespace UserManager.Domain.Handlers;

public class GetUserCommandHandler : ICommandHandler<GetUserCommand, CommandResultModel>
{
    private readonly IServices _services;
    private readonly IMapper _mapper;
    public GetUserCommandHandler(IServices services, IMapper mapper)
    {
        _services = services;
        _mapper = mapper;
    }

    public async ValueTask<CommandResultModel> Handle(GetUserCommand command, CancellationToken cancellationToken)
    {
        var response = new CommandResultModel<UserResponse>();
        try
        {
            var user = await _services.GetUserByIdAsync(id: command.Id, cpf: command.CPF);
            var responseModel = _mapper.Map<UserResponse>(user);
            return response.AddData(responseModel);
        }
        catch (Exception ex) { return response.AddError(ex.Message); }
    }
}
