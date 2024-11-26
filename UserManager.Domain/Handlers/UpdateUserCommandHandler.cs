using AutoMapper;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Commands;
using UserManager.Domain.Interfaces;
using UserManager.Domain.Models;

namespace UserManager.Domain.Handlers;

public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, CommandResultModel>
{
    private readonly IServices _services;
    private readonly IMapper _mapper;
    public UpdateUserCommandHandler(IServices services, IMapper mapper)
    {
        _services = services;
        _mapper = mapper;
    }

    public async ValueTask<CommandResultModel> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var response = new CommandResultModel<UserResponse>();
        try
        {
            var userToUpdate = await _services.UpdateUserAsync(
                id: command.Id,
                cpf: command.CPF,
                email: command.Email,
                password: command.Password,
                phoneNumber: command.PhoneNumber,
                address: command.Address,
                language: command.Language
            );

            var responseModel = _mapper.Map<UserResponse>(userToUpdate);
            return response.AddData(responseModel);
        }
        catch (Exception ex) { return response.AddError(ex.Message); }
    }
}
