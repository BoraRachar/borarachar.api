using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Application.Bases;


[ExcludeFromCodeCoverage]
public class FailRequestBehaviorWithResponseHandler<TRequest, TResponse> : IPipelineBehavior<TRequest, ResponseDto<TResponse>>
    where TRequest : IRequest<ResponseDto<TResponse>>
{
    private readonly IEnumerable<IValidator> _validators;
    private readonly ILogger<TRequest> _logger;

    public FailRequestBehaviorWithResponseHandler(IEnumerable<IValidator<TRequest>> validators, ILogger<TRequest> logger)
    {
        _validators = validators;
        _logger = logger;
    }

    private static Task<ResponseDto<TResponse>> Errors(IEnumerable<ValidationFailure> failures)
        => Task.FromResult(ResponseDto<TResponse>.Fail(failures.Select(x =>
            ErrorResponse.CreateError(x.ErrorMessage)
                .WithDeveloperMessage(x.ToString()))
        ));

    public Task<ResponseDto<TResponse>> Handle(TRequest request, RequestHandlerDelegate<ResponseDto<TResponse>> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        
        _logger.LogInformation("Validate: ", request.ToString());

        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        return failures.Any()
            ? Errors(failures)
            : next();
    }
}