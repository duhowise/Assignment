using MediatR;

namespace Assignment.Domain.Behaviour;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        try
        {
            _logger.LogInformation($"{typeof(TRequest).Name} executing");
            var response = await next();
            _logger.LogInformation($"{typeof(TRequest).Name} completed");
            return response;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An exception occred while executing {typeof(TRequest).Name}");
            throw;
        }
    }
}