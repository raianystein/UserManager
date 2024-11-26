using AutoMapper;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Commands;
using UserManager.Domain.Entities;
using UserManager.Domain.Interfaces;
using UserManager.Domain.Models;

namespace UserManager.Domain.Handlers;

public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, CommandResultModel>
{
    private readonly IServices _services;
    private readonly IMapper _mapper;
    public DeleteUserCommandHandler(IServices services, IMapper mapper)
    {
        _services = services;
        _mapper = mapper;
    }

    public async ValueTask<CommandResultModel> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var response = new CommandResultModel<string>();
        try
        {
            await _services.DeleteUserAsync(id: command.Id, cpf: command.CPF);
            return response.AddData($"Usuário deletado com sucesso. Identificação: {command.CPF}{command.Id}");
        }
        catch (Exception ex) { return response.AddError(ex.Message); }
    }
}