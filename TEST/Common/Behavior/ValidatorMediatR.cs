using MediatR;
using FluentValidation;

namespace PANAMA.Common.ValidatorMediatR
{
    public class ValidatorMediatR<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidatorMediatR(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validatorType = typeof(IValidator<>).MakeGenericType(request.GetType());
            var validators = _serviceProvider.GetServices(validatorType);

            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = new List<FluentValidation.Results.ValidationFailure>();

                foreach (var validator in validators)
                {
                    var result = await ((IValidator<TRequest>)validator).ValidateAsync(context, cancellationToken);
                    if (!result.IsValid)
                    {
                        validationResults.AddRange(result.Errors);
                    }
                }

                if (validationResults.Any())
                {
                    throw new ValidationException("Validation failed", validationResults);
                }
            }
            return await next();
        }
    }
}
