namespace APIContagem.Middlewares;

public static class MiddlewareExecutionNotificatorExtensions
{
    public static IApplicationBuilder UseMiddlewareExecutionNotificator(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MiddlewareExecutionNotificator>();
    }
}