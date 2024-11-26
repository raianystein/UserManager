using FluentValidation.Results;
using System.Net;
using UserManager.Domain.Models;

namespace UserManager.Domain.Interfaces;

public interface ICommandResultModel
{
    IEnumerable<ValidationFailure> Errors { get; init; }
    HttpStatusCode HttpStatusCode { get; }
    CommandResultModel SetHttpStatusCode(HttpStatusCode statusCode);
    CommandResultModel AddError(string errorMessage);
    CommandResultModel AddError(string propertyName, string errorMessage);
}

