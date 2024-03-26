namespace APIContagem.Middlewares;

public class MiddlewareExecutionNotificator
{
    private readonly RequestDelegate _next;

    public MiddlewareExecutionNotificator(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        var logger = (ILogger<MiddlewareExecutionNotificator>)httpContext
            .RequestServices.GetService(typeof(ILogger<MiddlewareExecutionNotificator>))!;
        logger.LogWarning("MiddlewareExecutionNotificator - Inicio da execucao");
        await _next(httpContext);
        logger.LogWarning("MiddlewareExecutionNotificator - Fim da execucao");
    }
}