using FluentValidation;
using FluentValidation.Results;
using Mediator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UserManager.Domain.Interfaces;

namespace UserManager.Domain.PipelineBehaviors;

public class ValidatorPipelineBehavior<TMessage, TResponse>(
    ILogger<ValidatorPipelineBehavior<TMessage, TResponse>> logger,
    IServiceProvider serviceProvider)
    : IPipelineBehavior<TMessage, TResponse> where TMessage : IMessage
{
    public async ValueTask<TResponse> Handle(TMessage message, CancellationToken cancellationToken,
        MessageHandlerDelegate<TMessage, TResponse> next)
    {
        var typeName = typeof(TMessage).FullName;
        logger.LogInformation("Validate {Type}", typeName);

        var validationResults = new List<ValidationResult>();
        var validators = serviceProvider.GetServices<IValidator<TMessage>>().ToList();

        logger.LogInformation("Found validators {Count}", validators.Count);

        foreach (var validator in validators)
        {
            var validationResult = await validator.ValidateAsync(message, cancellationToken);
            if (validationResult.IsValid == false)
                validationResults.Add(validationResult);
        }

        if (validationResults.Count == 0) return await next(message, cancellationToken);

        logger.LogInformation("Invalid");
        if (typeof(TResponse).GetInterface(nameof(ICommandResultModel)) != null)
        {
            var instance = Activator.CreateInstance<TResponse>();

            foreach (var validationFailure in validationResults.SelectMany(x => x.Errors))
            {
                (instance as ICommandResultModel)!.AddError(validationFailure.PropertyName,
                    validationFailure.ErrorMessage);

                logger.LogInformation("{Prop} | {Error}", validationFailure.PropertyName,
                    validationFailure.ErrorMessage);
            }

            return instance;
        }

        logger.LogInformation("Throw invalid exception");
        throw new ValidationException(validationResults.SelectMany(x => x.Errors));
    }
}
