using LifeTimeTesting.Service;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LifeTimeTesting.Filter;

//IActionFilter means you can use it in action methods
public class LifetimeIndicatorFilter : IActionFilter // IAsyncActionFilter
{
    private readonly IIdGenerator _idGenerator;
    private readonly ILogger<LifetimeIndicatorFilter> _logger;

    public LifetimeIndicatorFilter(IIdGenerator idGenerator, ILogger<LifetimeIndicatorFilter> logger)
    {
        _idGenerator = idGenerator;
        _logger = logger;
    }    

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var id = _idGenerator.Id;
        _logger.LogInformation($"{nameof(OnActionExecuting)} id was: {id}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var id = _idGenerator.Id;
        _logger.LogInformation($"{nameof(OnActionExecuted)} id was: {id}");
    }
}
