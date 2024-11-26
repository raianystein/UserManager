using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Net;
using FluentValidation.Results;
using System.Text.Json.Serialization;
using UserManager.Domain.Interfaces;

namespace UserManager.Domain.Models;

public class CommandResultModel<TData> : CommandResultModel
{
    [JsonConstructor]
    public CommandResultModel(IEnumerable<ValidationFailure> errors, TData? data)
    {
        Data = data;
        Errors = errors;
    }

    public CommandResultModel()
    {
    }

    public TData? Data { get; private set; }

    public CommandResultModel<TData> AddData(TData data)
    {
        Data = data;
        return this;
    }

    public new static CommandResultModel<TData> Build()
    {
        return new CommandResultModel<TData>();
    }

    public new static CommandResultModel<TData> BuildErrorByException(Exception e)
    {
        var result = new CommandResultModel<TData>();
        if (e is ArgumentException argumentException)
        {
            result.SetHttpStatusCode(HttpStatusCode.BadRequest);
            if (argumentException.ParamName != null)
                result.AddError(argumentException.ParamName, argumentException.Message);
            else
                result.AddError(argumentException.Message);
            return result;
        }

        result.AddError(e.Message);
        result.SetHttpStatusCode(HttpStatusCode.InternalServerError);


        return result;
    }

    public new CommandResultModel<TData> AddError(string errorMessage)
    {
        base.AddError(errorMessage);
        return this;
    }
}

public class CommandResultModel : ICommandResultModel
{
    private readonly ConcurrentBag<ValidationFailure> _errors = [];


    public IEnumerable<ValidationFailure> Errors
    {
        get => _errors.ToImmutableList();
        init
        {
            foreach (var failure in value)
                _errors.Add(failure);
        }
    }

    [JsonIgnore] public HttpStatusCode HttpStatusCode { get; private set; } = HttpStatusCode.OK;


    public CommandResultModel SetHttpStatusCode(HttpStatusCode statusCode)
    {
        HttpStatusCode = statusCode;
        return this;
    }

    public CommandResultModel AddError(string errorMessage)
    {
        _errors.Add(new ValidationFailure(null, errorMessage));
        HttpStatusCode = HttpStatusCode.BadRequest;
        return this;
    }

    public CommandResultModel AddError(string propertyName, string errorMessage)
    {
        _errors.Add(new ValidationFailure(propertyName, errorMessage));
        HttpStatusCode = HttpStatusCode.BadRequest;
        return this;
    }

    public static CommandResultModel Build()
    {
        return new CommandResultModel();
    }

    public static CommandResultModel BuildErrorByException(Exception e)
    {
        var result = new CommandResultModel();
        if (e is ArgumentException argumentException)
        {
            result.SetHttpStatusCode(HttpStatusCode.BadRequest);
            if (argumentException.ParamName != null)
                result.AddError(argumentException.ParamName, argumentException.Message);
            else
                result.AddError(argumentException.Message);
            return result;
        }

        result.SetHttpStatusCode(HttpStatusCode.InternalServerError);

        result.AddError(e.Message);

        return result;
    }

    public CommandResultModel AddError(Exception e)
    {
        if (e is ArgumentException argumentException)
        {
            HttpStatusCode = HttpStatusCode.BadRequest;
            _errors.Add(new ValidationFailure(argumentException.ParamName, argumentException.Message));
            return this;
        }

        _errors.Add(new ValidationFailure(null, e.Message));
        HttpStatusCode = HttpStatusCode.InternalServerError;

        return this;
    }
}
